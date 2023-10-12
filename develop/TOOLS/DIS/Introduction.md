---
uid: Overall_concept_of_the_DataMiner_Integration_Studio
---

# Introduction

DataMiner Integration Studio (DIS) is a [Visual Studio IDE extension](https://visualstudio.microsoft.com/vs/features/extend/). It includes many features that facilitate the development of DataMiner connectors and Automation scripts.

## Features

After installation of the DataMiner Integration Studio extension, Microsoft Visual Studio turns into a full-blown DataMiner IDE with the following editors:

- An [XML editor](xref:XML_editor), which features on-the-fly XML Schema validation and IntelliSense.
- A [C# editor](xref:C_editor), which features full C# editing and debugging capabilities.
- A [display editor](xref:Display_editor), which allows you to design Data Display pages using simple drag-and-drop operations.
- A [function editor](xref:Function_editor), which allows you to manage the functions defined in a function XML file and design function pages using simple drag-and-drop operations.
- A [table editor](xref:Table_editor), which allows you to design parameter tables using simple drag-and-drop operations.
- A [version editor](xref:Version_editor), which allows editing the version history.

Additionally, the following tool windows are available:

- [Tree view](xref:DisTreeViewToolWindow): This tool window acts as a table of contents, allowing you to easily navigate to a particular location in the connector or Automation script you are working on.
- [Mapping view](xref:DisMappingViewToolWindow): This tool window allows you to visualize relationships between items in the connector you are working on.
- [Grid view](xref:DisGridViewToolWindow): This tool window allows you to manage and configure all parameters in the protocol using a spreadsheet-like view.
- [Diagram](xref:DisDiagramToolWindow): This window shows a graphical representation of a protocol. It allows you to see how a protocol is built, navigate through its logic and investigate flow issues.
- [Validator](xref:DisValidatorToolWindow): This window lists the results of the latest protocol validation in a tree structure, grouped by severity and category.
- [Comparer](xref:DisComparerToolWindow):This tool window allows you to compare two connector versions.
- [Macros](xref:DisMacrosToolWindow): This tool window allows you to create C# scripts that can be used to make changes to e.g. a protocol XML file.
- [Inject](xref:DisInjectToolWindow): This tool window allows you to make the necessary preparations before debugging the connector QAction(s) or Automation script C# Exe block(s) you are editing.
- [MIB Browser](xref:DisMibBrowserToolWindow): his tool window allows you to build [Param](xref:Protocol.Params.Param) tags in a connector based on OID data in MIB files.

An top of this, it includes snippets and XML schemas to assist and speed up your development of connectors and Automation scripts.

![DIS Overview](~/develop/images/DataMinerIntegrationStudio.svg)
