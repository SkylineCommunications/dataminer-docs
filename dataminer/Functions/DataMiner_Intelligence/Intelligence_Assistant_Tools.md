---
uid: Intelligence_Tools
description: "Learn how DataMiner Intelligence agents use data and script tools, and how to manage those tools in the DataMiner Assistant app."
---

# Tools

Tools let DataMiner Intelligence agents query data and perform actions within a DataMiner System. Unlike [skills](xref:Intelligence_Skills), which provide instructions and workflows, tools perform concrete operations.

Tools can be assigned as references to [specialized agents](xref:Intelligence_Specialized_Agents), giving them explicit access to specific data sources or scripts. [Native agents](xref:Intelligence_Agents#native-agents) have access to all available tools by default.

## Types of tools

The following types of tools are available:

- **[Data tools](xref:Intelligence_DataTools)**: These allow agents to discover and query supported GQI data sources, including standard sources, DOM instances, and ad hoc data sources. Several native data tools are available, and it is also possible to create custom data tools.
- **[Script tools](xref:Intelligence_ScriptTools)**: These allow [specialized agents](xref:Intelligence_Specialized_Agents) to execute explicitly assigned DataMiner automation scripts.

## Creating and managing tools

You can create and manage tools on the *Tools* page of the [DataMiner Assistant app](xref:Intelligence_Assistant_app). This page displays the available tools in searchable lists. With the buttons at the top, you can switch between data and script tools.

In the data tools list, tags indicate native data tools, custom data tools based on DOM, and custom data tools based on an ad hoc data source.

![DataMiner Assistant tools overview listing available data and script tools](~/dataminer/images/Assistant_Tools_page.png)<br>*Data and script tools in the DataMiner Assistant app in DataMiner Web 10.7.1.*

From this page, you can:

- **Search** for existing tools by name using the search bar.

- **Create a new tool** by clicking the *+ New tool* button.

- **Edit a tool** by clicking the pencil button next to the tool in the list.

- **Duplicate or delete a tool** by clicking the ellipsis button (...) next to a tool in the list. Selecting *Duplicate* creates a copy of the tool, pre-filled with all the original data and an automatically generated unique name. Selecting *Delete* removes the tool entirely.

> [!TIP]
> For details about the tool editor, see [Creating or editing custom data tools](xref:Intelligence_custom_data_tools#creating-or-editing-custom-data-tools-in-the-assistant-app) and [Creating or editing script tools](xref:Intelligence_ScriptTools#creating-or-editing-script-tools-in-the-assistant-app).

> [!NOTE]
> The [Modules > System configuration > Tools > Admin tools](xref:DataMiner_user_permissions#modules--system-configuration--tools--admin-tools) user permission is not required to view existing tools, but it is required to create or edit tools.
