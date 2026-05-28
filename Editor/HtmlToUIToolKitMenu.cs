using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
namespace Xxhq.Htmltouitoolkit.Editor
{
    public class HtmlToUIToolKitMenu
    {
        private static readonly Regex s_ImgSrcExtractRegex = new Regex(@"<ui:Image\s+[^>]*?source\s*=\s*(?:""(?<source>[^""]*)""|'(?<source>[^']*)'|(?<source>[^\s>]+))[^>]*>?", RegexOptions.Compiled|RegexOptions.IgnoreCase);
        private static readonly Regex s_UssUrlExtractRegex = new Regex(@"url\s*\(\s*(?:'(?<url>[^']*)'|""(?<url>[^""]*)""|(?<url>[^)]*?))\s*\)", RegexOptions.Compiled|RegexOptions.IgnoreCase);
        [MenuItem("Tools/HtmlToUIToolKit/浏览器打开HTML转UIToolKit工具")]
        static void OpenHtmlToUIToolKitTool()
        {
            string path = GetDefaultFilePath();
            Debug.Log(path);
            if (string.IsNullOrEmpty(path))
                Debug.LogError("路径无效。");
            else
                Application.OpenURL(path);
        }

        [MenuItem("Assets/HtmlToUIToolKit/uxml、uss转图集切片路径", priority = 100)]
        static void ToSpriteAtlasSpritePathMenu()
        {
            HandlePath(true);
        }

        [MenuItem("Assets/HtmlToUIToolKit/uxml、uss转切片路径", priority = 101)]
        static void ToSpritePathMenu()
        {
            HandlePath(false);
        }

        static void HandlePath(bool isSpriteAtlas)
        {
            var objs = Selection.assetGUIDs;
            foreach (var item in objs)
            {
                string path = AssetDatabase.GUIDToAssetPath(item);
                if(string.IsNullOrEmpty(path)|| (!path.EndsWith(".uxml") && !path.EndsWith(".uss")))
                    continue;
                //TextAsset textAsset = AssetDatabase.LoadAssetAtPath<TextAsset>(path);
                if (File.Exists(path))
                {
                    string text = File.ReadAllText(path);
                    string result = ReplaceUssUrls(text, isSpriteAtlas);
                    if (path.EndsWith(".uxml"))
                    {
                        string resultImg = ReplaceImgSrcs(result ?? text, isSpriteAtlas);
                        if (!string.IsNullOrEmpty(resultImg))
                            result = resultImg;
                    }
                    if (string.IsNullOrEmpty(result))
                        continue;

                    Debug.Log("转换成功：" + path);
                    //Debug.Log(result);
                    File.WriteAllText(path, result, System.Text.Encoding.UTF8);
                    AssetDatabase.Refresh();
                }
            }
        }


        static string GetDefaultFilePath()
        {
            string path = GetRegularPath(GetCurrentFilePath());
            if (path.Contains("/Editor/"))
            {
                if (path.Contains("/Packages/") || path.Contains("/Library/"))
                {
                    path = path.Substring(0, path.LastIndexOf("/Editor/")).TrimStart('.').TrimStart('/');
                    if (!Path.IsPathRooted(path))
                    {
                        string projectPath = Application.dataPath.Substring(0, Application.dataPath.Length - 6);
                        path = projectPath + path;
                    }
                }
                else
                    path = path.Substring(0, path.LastIndexOf("/Editor/"));
                path = path + "/Tools/HtmlTools/HTML转UIToolKit工具.html";
                if (File.Exists(path))
                {
                    return path;
                }
            }
            return "";
        }

        public static string GetCurrentFilePath([CallerFilePath] string filePath = "")
        {
            return filePath;
        }

        /// <summary>
        /// 替换USS中的URL路径。
        /// </summary>
        /// <param name="uss">原始USS字符串</param>
        /// <param name="isSpriteAtlas">是否为图集</param>
        /// <returns>替换后的USS字符串</returns>
        public static string ReplaceUssUrls(string uss,bool isSpriteAtlas)
        {
            bool isReplace = false;
            var matches = s_UssUrlExtractRegex.Replace(uss, (m) => 
            {
                if (TryReplacePath(m.Value, isSpriteAtlas, out string url))
                    isReplace = true;
                return url;
            });

            if(isReplace)
                return matches;
            return null;
        }

        /// <summary>
        /// 替换图片路径。
        /// </summary>
        /// <param name="html">原始HTML字符串</param>
        /// <param name="isSpriteAtlas">是否为图集</param>
        /// <returns>替换后的HTML字符串</returns>
        public static string ReplaceImgSrcs(string html, bool isSpriteAtlas)
        {
            bool isReplace = false;
            var matches = s_ImgSrcExtractRegex.Replace(html, (m) =>
            {
                if (TryReplacePath(m.Value, isSpriteAtlas,out string url))
                    isReplace = true;
                return url;
            });

            if (isReplace)
                return matches;
            return null;
        }

        /// <summary>
        /// 尝试替换路径。
        /// </summary>
        /// <param name="m">原始路径字符串</param>
        /// <param name="isSpriteAtlas">是否为图集</param>
        /// <param name="url">替换后的路径</param>
        /// <returns>是否成功替换</returns>
        public static bool TryReplacePath(string m, bool isSpriteAtlas, out string url)
        {
            url = m;
            if (string.IsNullOrEmpty(m)|| m.StartsWith("project://"))
                return false;
            if (!url.Contains("."))
                return false;
            if (isSpriteAtlas)
            {
                if (url.Contains("#") || !url.Contains("/"))
                    return false;

                string spriteAtlasPath = url.Substring(0, url.LastIndexOf("/")) + ".png";
                string[] splits = url.Substring(url.LastIndexOf("/") + 1).Split('.');
                string spriteName=splits[0]+ splits[1].Replace("png", "");
                url = spriteAtlasPath + "#" + spriteName;
            }
            else
            {
                if (!url.Contains("#"))
                    return false;
                string spriteAtlasPath = url.Substring(0, url.LastIndexOf("#")).Replace(".png", "");
                int endIndex = url.LastIndexOf(")");
                if (url.EndsWith("')")||url.EndsWith("\")"))
                    endIndex --;
                else if(url.EndsWith("\"\")"))
                    endIndex -= 2;

                int startIndex = url.LastIndexOf("#") + 1;
                string spriteName = url.Substring(startIndex, endIndex- startIndex) + ".png"+ url.Substring(endIndex);
                url = spriteAtlasPath + "/" + spriteName;
            }
            //Debug.Log(url);
            return true;
        }

        /// <summary>
        /// 获取组合路径，并将其转换为正则化后的字符串。
        /// </summary>
        /// <param name="args">多路径</param>
        /// <returns>正则化后的字符串</returns>
        public static string GetCombinePath(params string[] args)
        {
            return GetRegularPath(Path.Combine(args));
        }
        /// <summary>
        /// 获取正则化后的字符串。
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>正则化后的字符串</returns>
        public static string GetRegularPath(string path)
        {
            return path.Replace("\\", "/");
        }
    }
}