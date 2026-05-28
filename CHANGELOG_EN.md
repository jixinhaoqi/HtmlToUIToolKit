# Changelog_EN.md

All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [0.1.0] - 2026-05-29

### Initial Release

- **Browser-based HTML to UXML/USS Conversion Tool** — ([`HTML转UIToolKit工具.html`](Tools/HTMLTools/HTML转UIToolKit工具.html) v1.7.40)
  - Intelligent mapping of 30+ HTML tags to UI Toolkit elements
  - Automatic conversion of 50+ CSS properties to USS
  - Real-time iframe preview
  - One-click download of UXML/USS files
  - See [`Tutorial`](Tools/HTMLTools/HTML转UIToolKit工具使用教程_EN.md)
- **SKILL Prompt for AI-Generated UXML/USS** — ([`SKILL.md`](Tools/HTMLTools/AI生成HTML提示词/SKILL.md))
  - AI can directly output Unity 6-compliant UXML/USS code
  - No browser tool required for conversion
- **Unity Editor Path Post-Processing** — ([`HtmlToUIToolKitMenu.cs`](Editor/HtmlToUIToolKitMenu.cs))
  - `Assets/HtmlToUIToolKit/uxml、uss转图集切片路径`: Image paths → Sprite Atlas references
  - `Assets/HtmlToUIToolKit/uxml、uss转切片路径`: Sprite Atlas references → Image paths
- **Example Scene** — ([`Example`](Samples~/Example/)) (import via Package Manager)
  - Includes complete HTML source, converted UXML/USS output, and Sprite Atlas assets