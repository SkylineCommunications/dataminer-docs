---
uid: Intelligence_custom_data_tools
description: "Create custom data tools that let DataMiner Intelligence agents query GQI ad hoc data sources and DataMiner Object Model (DOM) instances."
---

# Custom data tools

You can define new data tools yourself to give an agent access to a data source that is not covered by a native data tool, or to expose an existing data source with a different description, parameters, or columns tailored to a specific use case.

The following data sources are supported:

- **GQI ad hoc data sources**: Any GQI data sources registered in your DataMiner System. You select the data source from a list, without needing to know its underlying implementation details.
- **DOM instances of a DOM definition**: All instances of a specific DOM definition within a specific DOM module. The tool's output columns are derived from the fields defined on that DOM definition.

## Creating or editing custom data tools in the Assistant app

You can create custom data tools on the *Tools* page of the Assistant app with the *+ New tool* button or edit them using the pencil button next to a tool (see [Creating and managing tools](xref:Intelligence_Tools)).

When you create or edit a data tool, configure the following fields:

- **Name**: A unique identifier using lowercase letters, digits, and single hyphens, with a maximum of 128 characters.
- **Type**: *Data*.
- **Description**: A description of when to use the data source. The maximum length is 1,024 characters.
- **Source type**: *Ad hoc* or *DOM*.
- **Data source**: The specific GQI data source or DOM definition to query. DOM definitions are listed in `module / definition` format.
- **Parameters**: Input arguments for an ad hoc source. Provide a name, type, example, and description for each parameter.
- **Columns**: Output columns returned by the data source. Provide a name, type, and optional description for each column.
- **Context**: Instructions on how to use the data source and interpret the results. The maximum length is 8,192 characters.

For an ad hoc source, the data source must be a GQI [ad hoc data source](xref:GQI_Ad_hoc_data_sources) registered in the DataMiner System. For a DOM source, select the [DOM](xref:DOM) definition whose instances the tool should query.

## Authoring data tools as files

For data tools managed in source control or deployed through an Intelligence project, see [Authoring tools](xref:Adding_tools_to_an_intelligence_agent).
