---
uid: Assistant_custom_data_tools
---

# Custom data tools

You can define new data tools yourself to give an agent access to a data source that is not covered by a native data tool, or to expose an existing data source with a different description, parameters, or columns tailored to a specific use case.

The following data sources are supported:

- **GQI ad hoc data sources**: Any GQI data sources registered in your DataMiner System. Ad hoc data sources are defined by a C# class in an automation script library that implements specific interfaces. You select the data source from a list, without any need to know its underlying implementation details. If the data source accepts input parameters, provide example values and describe them so the Assistant knows how to use it.

- **DOM instances of a DOM definition**: All instances of a specific DOM definition within a specific DOM module. The tool's output columns are derived automatically from the fields defined on that DOM definition.

## Creating or editing custom data tools in the Assistant app

You can create custom data tools on the *Tools* page of the Assistant app with the *+ New tool* button or edit them using the pencil button next to the tool on that page (see [Creating and managing tools](xref:Assistant_Tools)).

When you create or edit a data tool, you will need to configure the following fields:

- **Name**: A unique identifier for the tool, which must meet the following restrictions:

  - Must be lowercase and may only contain letters, digits, and hyphens.
  - Cannot start or end with a hyphen.
  - Cannot contain consecutive hyphens (`--`).
  - Maximum 128 characters.

- **Type**: *Data*. For information about the *Script* type, refer to [Script tools](xref:Assistant_ScriptTools).

- **Description**: A brief description of when the data source should be used. This helps the Assistant decide when to pick this tool. Maximum 1024 characters.

- **Source type**: The kind of data source the tool queries. Two options are available:

  - **Ad hoc**: A GQI [ad hoc data source](xref:GQI_Ad_hoc_data_sources) registered in the DataMiner System, defined by a C# class in an automation script library that implements specific interfaces.
  - **DOM**: [DOM](xref:DOM) instances of a specific DOM definition.

- **Data source**: The specific GQI data source or DOM definition to query. Select the appropriate entry from the dropdown. DOM definitions are listed in `module / definition` format.

- **Parameters**: Input arguments for the data source. Only available for the **Ad hoc** source type. For each parameter, the following fields are available:

  - **Name**: The parameter name.
  - **Type**: The data type (e.g., string, Int32, DateTime).
  - **Example**: A value used both to retrieve the columns for this data source and as an example that helps the Assistant understand the expected format.
  - **Description**: A description that helps the Assistant determine the appropriate input value. Maximum 1024 characters.

- **Columns**: The output columns returned by the data source. For each column, the following fields are available:

  - **Name**: The column name.
  - **Type**: The data type (e.g., string, Int32, DateTime).
  - **Description**: A description that helps the Assistant interpret the returned data. Maximum 1024 characters.

- **Context**: Additional instructions or context about the data source. This helps the Assistant understand the usage, data interpretation, and any important details. Maximum 8192 characters.

## Configuring data tool files

Instead of using the Assistant app, you can also add or edit data tools directly as Markdown files in the following folders:

- Ad hoc: `C:\ProgramData\Skyline Communications\DataMiner Assistant\Synced Documents\Context\Custom\Adhoc`
- DOM: `C:\ProgramData\Skyline Communications\DataMiner Assistant\Synced Documents\Context\Custom\Dom`

These files are automatically discovered and synced across the cluster.

The files must be configured as follows:

- A data tool file is a markdown (`.md`) file with YAML front matter.
- Any content below the front matter is optional, and is configured similar to the *Context* field in the Assistant app, as detailed above.
- Each file must contain one data source definition.

### Common front matter fields

Both ad hoc and DOM files share the following front matter fields:

- `name`: Required. The data source name. Must be lowercase and may only contain letters, digits, and hyphens. Cannot start or end with a hyphen, and cannot contain consecutive hyphens (`--`). This is also used as the tool name and as the display name written in generated queries.

- `description`. Required. A brief description of the data source. Helps the Assistant decide when to pick this tool.

- `columns`. Optional. A list of output columns, each described by a `name` and `type`, and optionally a `description`. This information helps the Assistant pick the appropriate data source and interpret the returned data.

### Ad hoc data source files

Ad hoc data source files are stored in the `Adhoc` folder and describe a GQI ad hoc data source. Each ad hoc data source is defined by a C# class in an automation script library that implements specific interfaces.

For this source type, the front matter must contain the following additional fields:

- `dataSource`: Required. A JSON-encoded object identifying the backing GQI ad hoc data source: `DataSourceInterface`, `ScriptName`, `LibraryName`, `TypeFullName`, and `TypeName`.

  This value is the stable, rename-proof identifier the tool is bound to; the `name` field is only the display name.

- `inputArguments`: Required if the data source accepts parameters; otherwise omitted. A list of input arguments, each described by its `name`, `type`, and `description`. This information helps the Assistant determine appropriate input values. See [Input argument types](#input-argument-types) below.

#### Example: ad hoc data source file

```yaml
---
name: "customer-orders"
description: "Retrieve customer orders filtered by date range and customer type"
dataSource: "{\"DataSourceInterface\":\"Skyline.DataMiner.Analytics.GenericInterface.IGQIDataSource\",\"ScriptName\":\"GQI-CustomerOrders\",\"LibraryName\":\"GQICustomerOrders\",\"TypeFullName\":\"CustomerOrders\",\"TypeName\":\"CustomerOrders\"}"
columns:
  - name: "OrderID"
    type: "Int32"
    description: "Unique order identifier"
  - name: "CustomerName"
    type: "String"
    description: "Name of the customer"
  - name: "OrderDate"
    type: "DateTime"
    description: "Date when the order was placed"
  - name: "TotalAmount"
    type: "Double"
    description: "Total order amount in USD"
  - name: "Status"
    type: "String"
    description: "Order status (Pending, Completed, Cancelled)"
inputArguments:
  - name: "StartDate"
    type: "DateTime"
    description: "Start of the date range filter"
    example: "2024-01-01"
  - name: "EndDate"
    type: "DateTime"
    description: "End of the date range filter"
    example: "2024-12-31"
  - name: "CustomerType"
    type: "String"
    description: "Type of customer to filter (Premium, Standard, Basic)"
    example: "Premium"
  - name: "MinAmount"
    type: "Int32"
    description: "Minimum order amount to include"
    example: "100"
---

# Customer Orders Data Source

This data source returns customer orders based on the provided input parameters.

## Usage

Use the input arguments to filter the results by date range, customer type, and minimum amount.
```

#### Input argument types

Ad hoc data sources can accept different types of input arguments, each with specific validation behavior.

- **Single string** argument: The basic input argument type. The Assistant provides a single string value.

  Example in front matter:

  ```yaml
  inputArguments:
    - name: "ElementName"
      type: "String"
      description: "Name of the element to query"
      example: "MyDevice"
  ```

- **Dropdown** argument: The distinct possible values must be mentioned. The following validation behavior is applied:

  - The selected option must exist in the dropdown list.
  - The corresponding option value is used.
  - Validation errors include the list of possible values.

- **List** argument: The following validation behavior is applied:

  - Comma-separated input is split into individual selections.
  - Each selected option must exist in the list.
  - At least one option must be selected (empty lists are rejected).
  - Validation errors include the list of possible values.

### DOM data source files

DOM data source files are stored in the `Dom` folder and describe all instances of a specific DOM definition within a specific DOM module.

For this source type, the front matter must contain the following additional fields:

- `module`: Required. The name of the DOM module that contains the DOM definition.

- `definition`: Required. The ID (GUID) of the DOM definition whose instances the tool retrieves.

  Together with `module`, this is the stable, rename-proof identifier the tool is bound to; the `name` field is only the display name.

For DOM files, `columns` is derived automatically from the fields defined on the DOM definition; only the column descriptions can be customized afterwards.

#### Example: DOM data source

```yaml
---
name: "asset-management-asset"
description: "DOM data source for module 'asset_management', definition 'Asset'."
module: "asset_management"
definition: "9035d110-47f3-412d-ac8a-fde31bd4b00f"
columns:
- name: "Name"
  type: "string"
- name: "Asset ID"
  type: "string"
- name: "Serial number"
  type: "string"
- name: "Asset Class"
  type: "string"
- name: "Geo Latitude"
  type: "string"
- name: "Geo Longitude"
  type: "string"
- name: "Facility"
  type: "string"
- name: "Building"
  type: "string"
- name: "Floor"
  type: "string"
---
```
