# About HtmlToUIToolKit

HtmlToUIToolKit is a Unity editor package that converts HTML/CSS layouts into Unity UI Toolkit's UXML/USS format. It provides a browser-based visual conversion tool and a built-in AI prompt for direct AI-generated UXML/USS code.

Use cases:
- AI-generated UI layouts with direct UXML/USS output
- Converting designer HTML drafts into Unity UI
- Rapid prototyping of editor tools and game UI

![Example UI](images/example.png)

---

# Installing HtmlToUIToolKit

## Install via Git URL

1. Open Unity **Package Manager** (Window > Package Manager)
2. Click the **+** button → **"Add package from git URL..."**
3. Enter:
   ```
   https://github.com/jixinhaoqi/HtmlToUIToolKit.git
   ```
4. Click **Add** to complete installation

## Import Samples

1. Find **HtmlToUIToolKit** in Package Manager
2. Expand the **Samples** list
3. Click **Import** next to **Example**
4. Sample files are located at `Assets/Samples/HtmlToUIToolKit/0.1.0/Example/`

---

# Using HtmlToUIToolKit

## Workflow A: AI Direct UXML/USS Generation (Recommended)

The most efficient approach—AI outputs ready-to-use UXML/USS code directly.

### Steps

1. **Prepare the Prompt**: Use [`SKILL.md`](../Tools/HTMLTools/AI生成HTML提示词/SKILL.md) content as the AI system prompt
2. **Describe the UI**: Use natural language to describe your desired interface layout to the AI
3. **Get the Code**: The AI will return standard UXML and USS code
4. **Save Files**: Save the code as `.uxml` and `.uss` files respectively
5. **Use in Unity**: Reference these files via UI Builder or PanelSettings

### Path Post-Processing (Optional)

If the generated UXML/USS includes image assets, use the following menu items for path conversion:

- **Assets > HtmlToUIToolKit > uxml、uss转图集切片路径**
  - Converts `images/img/spriteName.png` format to `images/img.png#spriteName` (Sprite Atlas reference)
- **Assets > HtmlToUIToolKit > uxml、uss转切片路径**
  - Converts `images/img.png#spriteName` format back to `images/img/spriteName.png` (individual sprite path)

How to use: Select `.uxml` or `.uss` files in the Project window, right-click to access the menu. See [`HtmlToUIToolKitMenu.cs`](../Editor/HtmlToUIToolKitMenu.cs) for implementation details.

> Note: Conversion only modifies image references that do not start with `project://`. Assets already correctly referenced in Unity will not be altered.

---

## Workflow B: HTML Browser Conversion

Ideal for scenarios where you have existing HTML drafts and need visual preview before conversion.

### Steps

1. **Open the Tool**: Use menu **Tools > HtmlToUIToolKit > 浏览器打开HTML转UIToolKit工具**, or open [`HTML转UIToolKit工具.html`](../Tools/HTMLTools/HTML转UIToolKit工具.html) directly
2. **Paste HTML**: Paste the HTML source into the left panel
3. **Set Resolution**: Set the target resolution above the preview area (default 1920x1080)
4. **Preview**: The center panel shows the HTML rendering in real-time
5. **Convert**: Click the **"执行转换"** (Convert) button
6. **View Output**: The right panel displays USS and UXML code with syntax highlighting
7. **Export**: Use the **下载 UXML** / **下载 USS** buttons to save files

For detailed instructions, see the [`Tutorial`](../Tools/HTMLTools/HTML转UIToolKit工具使用教程_EN.md).

---

# Technical Details

## Requirements

This version of HtmlToUIToolKit is compatible with:

* Unity 2022.3 and later (recommended)

The browser conversion tool requires a modern ES6-compliant browser (Chrome, Edge, Firefox, etc.).

## HTML Tag Mapping Reference

| HTML Tag | UI Toolkit Element |
| --- | --- |
| `body`, `div`, `span`, `section`, `header`, `footer`, `nav`, `ul`, `ol`, `li`, `table`, `tr`, `td` | `ui:VisualElement` |
| `p`, `h1`-`h6`, `a`, `label`, `figcaption`, `pre`, `code`, `th`, `option` | `ui:Label` |
| `button`, `input[type=submit/button/reset]` | `ui:Button` |
| `img`, `svg`, `video` | `ui:Image` |
| `input[type=text/password/email/...]` | `ui:TextField` |
| `textarea` | `ui:TextField` (multiline) |
| `input[type=range]` | `ui:Slider` |
| `input[type=checkbox/radio]` | `ui:Toggle` |
| `input[type=number]` | `ui:IntegerField` |
| `select` | `ui:DropdownField` |
| `details` | `ui:Foldout` |
| `meter`, `progress` | `ui:ProgressBar` |

## CSS Property Mapping Reference

### Box Model
`width`, `height`, `min-width`, `max-width`, `min-height`, `max-height`, `margin-*`, `padding-*`, `border-*-width`, `border-*-color`, `border-*-radius`

### Flexbox
`flex-direction`, `flex-wrap`, `align-items`, `align-content`, `align-self`, `justify-content`, `flex-grow`, `flex-shrink`, `flex-basis`

### Visual
`color`, `background-color`, `background-image` (url), `background-repeat`, `background-position`, `opacity`, `visibility`, `overflow`

### Positioning
`position` (relative/absolute), `top`, `left`, `right`, `bottom`

### Text
`font-size`, `font-weight` (→ `-unity-font-style`), `font-style` (→ `-unity-font-style`), `text-align` (→ `-unity-text-align`), `letter-spacing`, `word-spacing`, `white-space`, `text-overflow`, `text-shadow`

### Transform
`translate`, `scale`, `rotate` (expanded to USS individual properties)

### Pseudo-classes
`:hover`, `:active`, `:inactive`, `:focus`, `:disabled`, `:enabled`, `:checked`, `:root`

## Known Limitations

HtmlToUIToolKit version 0.1.0 has the following known limitations:

* `position: fixed` and `position: sticky` are not supported
* CSS Grid `grid-template-columns` and `grid-template-rows` are not supported (Grid containers are converted to Flexbox approximations)
* Relative units `vh` / `vw` / `em` / `rem` are not supported (requires fixed-resolution preview)
* `text-shadow` only supports single-layer shadows
* The browser conversion tool relies on the DOM engine for style computation; minor deviations from Unity runtime may occur
* Currently supports approximately 50 CSS properties; some complex properties require manual USS additions
* CSS `transition` properties are not converted (Unity UI Toolkit uses a different animation system)

## Package Contents

| Path | Description |
| --- | --- |
| [`Editor/`](../Editor/) | Unity editor scripts, including [`HtmlToUIToolKitMenu.cs`](../Editor/HtmlToUIToolKitMenu.cs) for path post-processing |
| [`Tools/HTMLTools/`](../Tools/HTMLTools/) | Browser conversion tool and AI Prompt |
| [`Tools/HTMLTools/HTML转UIToolKit工具.html`](../Tools/HTMLTools/HTML转UIToolKit工具.html) | Browser-based HTML to UXML/USS converter |
| [`Tools/HTMLTools/AI生成HTML提示词/SKILL.md`](../Tools/HTMLTools/AI生成HTML提示词/SKILL.md) | AI system prompt for UXML/USS generation |
| [`Documentation/`](../Documentation/) | User documentation |
| [`Samples~/Example/`](../Samples~/Example/) | Example scene (import via Package Manager) |

## Document Revision History

| Date | Reason |
| --- | --- |
| May 29, 2026 | Initial document for version 0.1.0. |