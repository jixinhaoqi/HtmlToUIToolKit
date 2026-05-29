# HtmlToUIToolKit：让 HTML 秒变 Unity UI Toolkit 界面

> 一个轻量级 Unity 编辑器包，将 HTML/CSS 布局一键转换为 UXML/USS，支持 AI 直接生成和浏览器可视化转换两种工作流。

---

## 引言

Unity UI Toolkit 是 Unity 官方力推的现代 UI 框架，但直接用 UXML/USS 手写界面布局，学习曲线陡峭，调试效率低。尤其是对设计师和前端开发者来说，从熟悉的 HTML/CSS 切换到 UXML/USS，就像换了一门语言。

**HtmlToUIToolKit** 正是为了解决这个问题而生。它提供了一个浏览器端的 HTML → UXML/USS 可视化转换工具，并内置 AI Prompt，让你可以直接用自然语言描述 UI，让 AI 生成标准 UXML/USS 代码。无论你是游戏开发者、Unity 插件作者还是编辑器工具开发者，都能大幅提升 UI 开发效率。

---

## 两种工作流，灵活选择

### 工作流 A：AI 直接生成 UXML/USS（推荐）

最高效的方式——无需浏览器，无需 HTML，直接用自然语言描述想要的界面。

1. 将内置的 [SKILL.md](Tools/HTMLTools/AI生成HTML提示词/SKILL.md) 作为 AI 系统提示词
2. 用自然语言描述你想要的 UI 布局
3. AI 直接返回符合 Unity 6 标准的 UXML/USS 代码
4. 保存为 `.uxml` 和 `.uss` 文件，直接在 Unity 中使用

```
AI 客户端 + SKILL Prompt → 生成 UXML/USS → 保存文件 → Unity 中使用
```

### 工作流 B：HTML 浏览器转换

适合已有 HTML/CSS 设计稿的场景，所见即所得地转换。

1. 打开 [在线工具](https://jixinhaoqi.github.io/HtmlToUIToolKit/) 或本地 HTML 文件
2. 粘贴 HTML 代码，左侧实时预览效果
3. 点击"执行转换"，右侧显示 UXML/USS 输出
4. 一键下载或复制，导入 Unity 即可使用

```
HTML/CSS 源码 → 浏览器预览 → 转换 → 下载 UXML/USS → Unity 中使用
```

---

## 核心功能

### 智能 HTML 标签映射

自动将 30+ HTML 元素映射为 UI Toolkit 控件：

| HTML 标签 | UI Toolkit 元素 |
| --- | --- |
| `div`, `section`, `nav`, `table`, `tr`, `td`... | `ui:VisualElement` |
| `p`, `h1`-`h6`, `a` | `ui:Label` |
| `button` | `ui:Button` |
| `img` | `ui:Image` |
| `input[type=text]` | `ui:TextField` |
| `select` | `ui:DropdownField` |
| `details` | `ui:Foldout` |
| `meter`, `progress` | `ui:ProgressBar` |
| `input[type=range]` | `ui:Slider` |
| `input[type=checkbox]` | `ui:Toggle` |
| ... | ... |

### CSS → USS 自动转换

支持 50+ CSS 属性到 USS 的精确转换：

- **盒模型**：`margin`、`padding`、`border` 自动展开为长格式
- **Flexbox 布局**：`flex-direction`、`align-items`、`justify-content` 完整支持
- **文本样式**：`font-size`、`text-align`（→ `-unity-text-align`）、`font-weight` + `font-style`（→ `-unity-font-style`）
- **Transform**：`translate`、`scale`、`rotate` 自动展开为 USS 独立属性
- **伪类**：`:hover`、`:active`、`:focus`、`:disabled` 等 8 种
- **CSS 简写**：`background` → `background-color/image/repeat`，`border` → 四边独立属性

### 内联元素智能分组

`<span>`、`<b>`、`<i>` 等内联元素自动包裹为 `flex-direction: row` 的横向容器，无需手动调整。

### 富文本支持

`<b>`/`<strong>`、`<i>`/`<em>`、`<u>`、`<s>`/`<del>`、`<a>` 等标签自动转换为 Unity 富文本标记语法。

### 编辑器路径后处理

在 Unity Project 窗口中右键 `.uxml` 或 `.uss` 文件，使用菜单：

- `uxml、uss转图集切片路径`：将独立图片路径转为 Sprite Atlas 引用
- `uxml、uss转切片路径`：将 Sprite Atlas 引用转回独立图片路径

适合批量调整项目中 UI 文件的资源引用方式。

---

## 安装

在 Unity Package Manager 中通过 Git URL 安装：

```
https://github.com/jixinhaoqi/HtmlToUIToolKit.git
```

安装后可在 Package Manager 的 Samples 列表中找到示例场景，点击 Import 导入即可查看完整 Demo。

---

## 使用示例

### 示例 1：AI 生成登录表单

将以下 Prompt 发送给 AI（已内置 SKILL.md 提示词）：

> 生成一个居中显示的登录表单，包含用户名输入框、密码输入框、"记住我"复选框和登录按钮。

AI 直接返回 UX 格式的 UXML 和 USS：

```xml
<ui:UXML xmlns:ui="UnityEngine.UIElements">
    <ui:VisualElement name="body" style="justify-content: center; align-items: center;">
        <ui:VisualElement name="card" style="background-color: white; padding: 40px; border-radius: 16px;">
            <ui:Label name="title" text="欢迎回来" />
            <ui:TextField name="username" placeholder-text="请输入用户名" />
            <ui:TextField name="password" placeholder-text="请输入密码" />
            <ui:Toggle name="remember" label="记住我" />
            <ui:Button name="login-btn" text="登 录" />
        </ui:VisualElement>
    </ui:VisualElement>
</ui:UXML>
```

### 示例 2：浏览器转换栅格化图片布局

给定一个包含多层绝对定位图片和文字的 HTML 页面，通过浏览器工具一键转换：

1. 将 HTML 粘贴到编辑器左侧
2. 设置分辨率 1920x1080
3. 点击"执行转换"
4. 下载生成的 `output.uxml` 和 `output.uss`

转换后的 UXML 自动将每个绝对定位的 `<div>` 映射为 `ui:VisualElement`，图片 `src` 转为 `<ui:Image source="...">`，并从 CSS 计算精确的 `position`/`width`/`height` 值。

---

## 适用场景

- 使用 AI 从零生成 UI 布局
- 将设计师的 HTML 稿快速转为 Unity UI
- 编辑器工具界面的原型开发
- 批量生成模板化 UI 组件
- 将 Web 前端技能直接应用于 Unity UI 开发

---

## 已知限制

| 限制项 | 说明 |
| --- | --- |
| `position: fixed/sticky` | 不支持 |
| CSS Grid 模板 | 自动转为 Flexbox 近似布局 |
| `vh/vw/em/rem` 单位 | 需设置固定分辨率 |
| CSS `transition` | 不被转换（Unity 使用不同动画系统） |
| 部分 CSS 属性 | 当前支持约 50 个，复杂属性需手动补充 |

---

## 结语

HtmlToUIToolKit 是一个小而美的工具，它的核心价值在于**降低 Unity UI Toolkit 的入门门槛**，让习惯 Web 开发的技术人员能无缝过渡到 Unity UI 开发。

无论你是想用 AI 快速出 UI，还是要把现有 HTML 设计稿导入 Unity，这个工具都能帮你省下大量手写 UXML/USS 的时间。

欢迎在 [GitHub](https://github.com/jixinhaoqi/HtmlToUIToolKit) 上给项目点个 Star，也欢迎提 Issue 和 PR！

---

> 项目地址：[https://github.com/jixinhaoqi/HtmlToUIToolKit](https://github.com/jixinhaoqi/HtmlToUIToolKit)  
> 在线体验：[https://jixinhaoqi.github.io/HtmlToUIToolKit/](https://jixinhaoqi.github.io/HtmlToUIToolKit/)  
> 作者：xxhq  
> 协议：MIT License