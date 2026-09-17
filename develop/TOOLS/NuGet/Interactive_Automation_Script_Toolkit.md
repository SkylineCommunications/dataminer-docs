---
uid: Interactive_Automation_Script_Toolkit
---

# Interactive Automation Script Toolkit

The Interactive Automation Script Toolkit (or “IAS Toolkit” in short) is a library that can be used to create interactive automation scripts. Its main purpose is to make developing interactive automation scripts easier. Where you previously had to deal with UIBlocks of different types, you can now use TextBoxes and Buttons.

The NuGet package identifier and the namespace used in C# code are different:

| Item | Value |
|---|---|
| NuGet package | `Skyline.DataMiner.Utils.InteractiveAutomationScriptToolkit` |
| C# namespace | `Skyline.DataMiner.Utils.InteractiveAutomationScript` |

Install the NuGet package, then import the C# namespace in the script with `using Skyline.DataMiner.Utils.InteractiveAutomationScript;`.

Main features:

- Dedicated classes for each widget

- Event driven

- Focus on building scripts

- Eliminates a lot of boilerplate code

- Easily create complex and robust scripts

- Reduces development time

> [!TIP]
> For more information on how to get started, see [Getting started with the IAS Toolkit](xref:Getting_Started_with_the_IAS_Toolkit).

## Versions

| Version | Description |
|--|--|
| 1.0.x | The first version of the toolkit that was made available as a library. Compatible with **DataMiner 10.0.13/10.1.0** and higher. |
| 2.0.x | Adds support for TreeViews. Compatible with **DataMiner 10.1.2** and higher. |
| 3.0.x | Fixes issues with the TreeView widget. Compatible with **DataMiner 10.1.5** and higher. |
| 4.0.x | Adds support for uploading files using the FileSelector widget. Compatible with **DataMiner 10.1.8** and higher. |
| 5.0.x | Adds support for a focus lost event on many widgets. Compatible with **DataMiner 10.1.10** and higher. |
| 6.0.x | Adds support for button styles. Compatible with **DataMiner 10.3.1** and higher. |
| 7.0.x | Adds support for downloading files using the DownloadButton widget. Compatible with **DataMiner 10.3.7** and higher. |

## InteractiveController lifecycle

The initial-dialog method changed between Toolkit versions:

| Toolkit version | Initial-dialog method |
|---|---|
| Up to 9.0.1 | `Run(initialDialog)` |
| 9.0.2–9.0.11 | `ShowDialog(initialDialog)` is preferred; `Run(initialDialog)` is obsolete |
| 10.0.1 and later | `ShowDialog(initialDialog)` |

Use the method supported by the Toolkit package referenced by the script. The versions not listed here are not inferred from this compatibility map.
