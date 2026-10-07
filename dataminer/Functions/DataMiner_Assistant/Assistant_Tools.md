---
uid: Assistant_Tools
---

# Assistant tools

Tools are actionable capabilities that give AI agents the ability to query data and execute actions within a DataMiner System. Unlike [skills](xref:Assistant_Skills), which provide instructions and workflows, tools perform concrete operations.

Tools can be assigned as references to [specialized agents](xref:Assistant_Specialized_Agents), giving them explicit access to specific data sources or scripts. [Native agents](xref:Assistant_Agents#native-agents) have access to all available tools by default.

## Types of tools

The following types of tools are available:

- **[Data tools](xref:Assistant_DataTools)**: These allow agents to discover and query supported GQI data sources, including standard sources, DOM instances, and ad hoc data sources. Several native data tools are available, and it is also possible to create custom data tools.
- **[Script tools](xref:Assistant_ScriptTools)**: These allow [specialized agents](xref:Assistant_Specialized_Agents) to execute explicitly assigned DataMiner Automation scripts.

## Creating and managing tools

You can create and manage tools on the *Tools* page of the Assistant app. This page displays the available tools in searchable lists. With the buttons at the top, you can switch between data and script tools.

In the data tools list, tags indicate native data tools, custom data tools based on DOM, and custom data tools based on an ad hoc data source

![Tools overview page](~/dataminer/images/Assistant_Tools_page.png)

From this page, you can:

- **Search** for existing tools by name using the search bar.

- **Create a new tool** by clicking the *+ New tool* button.

- **Edit a tool** by clicking the pencil button next to the tool in the list.

- **Duplicate or delete a tool** by clicking the ... button next to a tool in the list. Selecting *Duplicate* creates a copy of the tool, pre-filled with all the original data and an automatically generated unique name. Selecting *Delete* removes the tool entirely.

> [!TIP]
> For details about the tool editor, see [Creating or editing custom data tools](xref:Assistant_custom_data_tools#creating-or-editing-custom-data-tools-in-the-assistant-app) and [Creating or editing script tools](xref:Assistant_ScriptTools#creating-or-editing-script-tools-in-the-assistant-app).

> [!NOTE]
> While no specific permissions are required to view existing tools, creating or editing tools requires the [Modules > System configuration > Tools > Admin tools](xref:DataMiner_user_permissions#modules--system-configuration--tools--admin-tools) user permission.

### Validation constraints

The following validation rules are applied when you create or update tool:

| Field | Constraint |
| --- | --- |
| Name | Required. Maximum 128 characters. Must be lowercase and may only contain letters, digits, and hyphens. Cannot start or end with a hyphen, and cannot contain consecutive hyphens (`--`). |
| Description | Maximum 1024 characters. |
| Instructions/usage information | Maximum 8192 characters. |

If a field exceeds its limit, a descriptive error is returned indicating which field is too long and by how much. These limits keep tool definitions well-formed and protect response quality by preventing oversized content from being pulled into the AI context.
