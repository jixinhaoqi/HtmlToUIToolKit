# 三种 UXML/USS 生成方案对比

[(English)](Compare_MCP_CLI_EN.md)

本工具并非唯一生成 UXML/USS 的方式。下表对比了本工具提供的三种方案，以及与外部 Unity MCP/CLI 方案的差异，帮助你选择最适合的方案。

---

## 方案概览

### 方案 1：AI Prompt 直接生成（本工具提供）

使用 [`SKILL.md`](Tools/HTMLTools/AI生成HTML提示词/SKILL.md) 作为 AI 系统提示词，让 AI 直接输出 UXML/USS。

**流程：**
```
AI 客户端 + SKILL Prompt → 生成 UXML/USS → 保存文件 → Unity 中使用（可选路径后处理）
```

### 方案 2：浏览器转换工具（本工具提供）

使用 [`HTML转UIToolKit工具.html`](Tools/HTMLTools/HTML转UIToolKit工具.html) 将 HTML/CSS 可视化转换为 UXML/USS。

**流程：**
```
HTML/CSS 源码 → 浏览器预览 → 转换 → 下载 UXML/USS → Unity 中使用（可选路径后处理）
```

### 方案 3：Unity MCP / CLI 对话生成

通过 Unity MCP Server 或 CLI 工具，在 Unity 编辑器内通过对话实时操作和生成 UI。

**流程：**
```
AI + MCP/CLI → 直接操作 Unity Editor → 实时创建 UXML/USS + UI 元素
```

---

## 对比表格

| 维度 | AI Prompt 直接生成 | 浏览器转换工具 | Unity MCP / CLI |
| --- | --- | --- | --- |
| **前置要求** | 任意 AI 客户端 | 浏览器 + HTML/CSS 源码 | Unity MCP Server / CLI 环境 |
| **输入格式** | 自然语言描述 | HTML/CSS 代码 | 自然语言描述 |
| **输出格式** | UXML + USS 文本 | UXML + USS 文件 | UXML/USS 文件 + 实时 Scene 修改 |
| **可预览性** | 不可预览 | 浏览器实时预览 | 依赖 Unity 渲染 |
| **样式精度** | 受 AI 模型理解限制 | 浏览器精确计算样式值 | 受 AI + MCP 工具链能力限制 |
| **CSS 属性覆盖面** | AI 自主决定 | 50+ 属性精确映射 | AI 自主决定 |
| **批量处理** | 支持（批量 Prompt） | 逐个转换 | 支持 |
| **离线可用** | 是 | 部分（Highlighter 依赖 CDN） | 取决于 MCP 实现 |
| **上手难度** | 低 | 低 | 中~高 |
| **调试方便度** | 需手动对比调整 | 实时预览所见即所得 | 实时所见即所得 |
| **与 Unity 集成深度** | 浅（独立生成文件） | 浅（独立生成文件） | 深（直接操作 Scene 和组件） |
| **学习成本** | 仅需描述 UI | 需了解 HTML/CSS | 需了解 MCP/CLI 操作方式 |
| **适合场景** | 快速原型、模板化 UI、批量生成 | 已有设计稿、精准样式还原 | 自动化流水线、CI/CD 集成、复杂交互 |

---

## 推荐策略

### 选择 AI Prompt 直接生成 当你：

- 从零开始设计UI，没有现成 HTML
- 需要快速生成大量相似结构的 UI 组件
- 对 AI 模型理解 UI 的能力有信心
- 不想安装额外工具

### 选择浏览器转换工具 当你：

- 已有 HTML/CSS 设计稿（如从设计工具导出）
- 需要精确控制像素级样式值
- 需要在转换前预览视觉效果
- 与设计师协作，设计师提供 HTML 稿

### 选择 Unity MCP / CLI 当你：

- 需要在现有场景中实时修改 UI
- 有 CI/CD 自动化生成 UI 的需求
- 已搭建好 MCP Server / CLI 环境
- 需要深度集成到 Unity 工作流中

---

## 总结

| 场景 | 推荐方案 |
| --- | --- |
| 从零创建新 UI | 方案 1（AI Prompt） |
| 有设计稿需转换 | 方案 2（浏览器工具） |
| 精益还原已有 HTML | 方案 2（浏览器工具） |
| 批量生成模板化 UI | 方案 1 或 3（AI Prompt / MCP） |
| CI/CD 自动化 | 方案 3（MCP/CLI） |
| 实时编辑器内交互 | 方案 3（MCP/CLI） |

本工具聚焦方案 1 和方案 2，提供**低门槛、无需额外环境配置**的 UXML/USS 生成能力。方案 1 适合与任何 AI 客户端配合使用，方案 2 适合需要精确控制样式的场景。