# HTML to UI Toolkit Conversion Tool Tutorial

This guide explains how to use [`HTML转UIToolKit工具.html`](HTML转UIToolKit工具.html) to convert HTML/CSS source code into Unity UI Toolkit UXML/USS format.

---

## Opening the Tool

Two ways to open the conversion tool:

1. In Unity Editor: menu **Tools > HtmlToUIToolKit > 浏览器打开HTML转UIToolKit工具**
2. Double-click [`HTML转UIToolKit工具.html`](HTML转UIToolKit工具.html) in your file explorer

The tool opens in your default browser with a three-panel layout.

---

## Interface Layout

```
+---------------------------------------------------------------+
|  [Convert]  [Download UXML]  [Download USS]   Status message  |
+---------------------------------------------------------------+
+------------------+------------------------+------------------+
|   HTML Source    |    Live Preview        |  UXML/USS Output |
|   (Left Panel)   |    (Center Panel)      |  (Right Panel)   |
|                  |                        |                  |
|  Paste HTML code |  iframe-rendered view  |  Top: USS code   |
|                  |  Adjustable resolution |  Bottom: UXML    |
|                  |                        |                  |
+------------------+------------------------+------------------+
```

### Panel Descriptions

| Area | Function |
| --- | --- |
| HTML Source (Left) | Input area for pasting or editing HTML/CSS code |
| Live Preview (Center) | HTML rendered via iframe, with adjustable resolution (width/height) |
| USS Output (Top-right) | Converted USS stylesheet with syntax highlighting |
| UXML Output (Bottom-right) | Converted UXML structure with syntax highlighting |
| Top Button Bar | Execute conversion, download files, copy code, status messages |

---

## Steps

### Step 1: Paste HTML Code

Paste the complete HTML code into the left editing area. It's recommended to include full `<html>`, `<head>`, and `<body>` tags to ensure the browser correctly renders styles.

> The tool auto-loads a sample login form HTML for reference.

### Step 2: Adjust Preview Resolution

Set the preview resolution using the input fields above the center panel:

- **Width (default 1920)**: Preview viewport width in pixels
- **Height (default 1080)**: Preview viewport height in pixels

Resolution affects CSS pixel value computation accuracy. Set it close to your target display scenario (e.g., game resolution). For mobile UIs, try 750x1334 or 1125x2436.

### Step 3: Execute Conversion

Click the **"执行转换"** (Convert) button at the top, or modify the HTML code (auto-triggers conversion after 300ms delay).

During conversion, the tool:
1. Renders HTML in an iframe
2. Retrieves computed styles via browser DOM API
3. Maps HTML elements to UI Toolkit elements
4. Maps CSS properties to USS properties
5. Generates formatted USS and UXML output

### Step 4: View Output

The right panel displays conversion results:

- **Top - USS**: USS stylesheet with all CSS rules, using class selectors
- **Bottom - UXML**: UXML structure with the complete element tree, each element auto-assigned a `name` attribute

Both panels feature syntax highlighting for readability.

### Step 5: Export Files

Use the top buttons to export:

| Button | Function |
| --- | --- |
| **下载 UXML** (Download UXML) | Download `.uxml` file |
| **下载 USS** (Download USS) | Download `.uss` file |
| **复制** (Copy, top-right of each output panel) | Copy code to clipboard |

> Place downloaded files in your Unity project's Assets directory and reference them via UI Builder or PanelSettings.

---

## Button Reference

| Button | Location | Function |
| --- | --- | --- |
| 执行转换 (Convert) | Top bar | Manually trigger HTML → UXML/USS conversion |
| 下载 UXML (Download UXML) | Top bar | Download generated UXML as `output.uxml` |
| 下载 USS (Download USS) | Top bar | Download generated USS as `output.uss` |
| 复制/Copy (USS) | USS panel top-right | Copy USS code to clipboard |
| 复制/Copy (UXML) | UXML panel top-right | Copy UXML code to clipboard |

---

## Notes

### Browser Compatibility

The tool uses ES6 syntax and DOM APIs. Requires modern browsers (Chrome 80+, Edge 80+, Firefox 75+, Safari 13+).

### Resolution Recommendations

- **Editor tool UI**: 1920x1080
- **Mobile portrait UI**: 750x1334
- **Tablet UI**: 1536x2048
- **Custom**: Set to match your target display scenario

### Style Limitations

Refer to the CSS property mapping reference and known limitations in [`HtmlToUIToolKit_EN.md`](../Documentation/HtmlToUIToolKit_EN.md).

### Path Post-Processing

Generated UXML/USS uses relative paths for image references. To use Sprite Atlas, right-click files in Unity and use the **HtmlToUIToolKit** menu for path conversion.

---

## FAQ

### Q: Converted styles don't match the preview?

A: Some CSS properties have no exact equivalent in Unity UI Toolkit (e.g., gradients become solid colors, Grid becomes Flexbox). Manually fine-tune via UI Builder after conversion.

### Q: Images not showing?

A: Check that image paths are correct and images are imported into Unity. Use the **Assets > HtmlToUIToolKit** menu for path post-processing.

### Q: Elements are identified as wrong UI Toolkit types?

A: The tool infers types based on HTML tags and computed styles. Modify HTML tags to adjust mapping (e.g., change `<div>` to `<button>` for explicit Button mapping).