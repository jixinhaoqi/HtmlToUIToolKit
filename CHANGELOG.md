# Changelog

[(English)](CHANGELOG_EN.md)

All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [0.1.0] - 2026-05-29

### 首次发布

- **浏览器端 HTML 转 UXML/USS 转换工具** — ([`HTML转UIToolKit工具.html`](Tools/HTMLTools/HTML转UIToolKit工具.html) v1.7.40)
  - 支持 30+ HTML 标签到 UI Toolkit 元素的智能映射
  - 支持 50+ CSS 属性到 USS 的自动转换
  - 实时 iframe 预览
  - 一键下载 UXML/USS 文件
  - 参考 [`使用教程`](Tools/HTMLTools/HTML转UIToolKit工具使用教程.md)
- **AI 直接生成 UXML/USS 的 SKILL Prompt** — ([`SKILL.md`](Tools/HTMLTools/AI生成HTML提示词/SKILL.md))
  - AI 可直接输出符合 Unity 6 标准的 UXML/USS 代码
  - 无需浏览器工具即可完成转换
- **Unity Editor 路径后处理** — ([`HtmlToUIToolKitMenu.cs`](Editor/HtmlToUIToolKitMenu.cs))
  - `Assets/HtmlToUIToolKit/uxml、uss转图集切片路径`：图片路径 → Sprite Atlas 引用
  - `Assets/HtmlToUIToolKit/uxml、uss转切片路径`：Sprite Atlas 引用 → 图片路径
- **示例场景** — ([`Example`](Samples~/Example/))（通过 Package Manager 导入）
  - 包含完整的 HTML 源码、转换后的 UXML/USS 输出和 Sprite Atlas 图片资源