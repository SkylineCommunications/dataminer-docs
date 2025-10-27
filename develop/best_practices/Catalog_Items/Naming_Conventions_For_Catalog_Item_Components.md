---
uid: Naming_Conventions_For_Catalog_Item_Components
keywords: catalog, package, solution, naming, convention
---

# Naming conventions for Catalog item components

Naming conventions should be applied to all components used in solutions, for the following reasons:

- **Prevention of naming conflicts**: Many components of a DataMiner System require a unique name. These naming conventions help to prevent naming conflicts and to ensure that the different solutions do not unintentionally use the same files.
- **Readability and understandability**: Consistent and meaningful names make it easier for users to understand for which solution a component is used and what the exact purpose of the component is.
- **Consistency**: Consistent naming conventions contribute to a unified style across all solutions.

This applies to all places where users see your solution, from the Catalog item itself to the components visible in DataMiner.

## Abbreviations used in these naming conventions

In the naming conventions, references will be made to the following abbreviations:

- **SOLCODE**: Solution Code; a 3-letter code in uppercase, uniquely referencing the solution.
- **SOLNAME**: Solution Name; the human-readable name of the solution.
- **SOLCATEGORY**: The category of the solution. The following values are currently supported:
  - *Apps & Solutions*: Category that groups all apps and solutions.
  - *Frameworks*: Category that groups all solutions related to DataMiner frameworks, such as [Process Automation](xref:PA_index), [SRM](xref:About_SRM), etc.
  - *DevOps*: Category that groups all solutions serving a learning purpose, i.e. examples or solutions to easily kickstart development.
  - *General*: Category that groups all components deployed as standalone artifacts, meaning they are deployed as part of specific solutions (e.g. a script used in multiple solutions).

## General naming conventions

- Between the **solution code** and the **unique component name**, usually a **hyphen** is used. For components with more visibility to end users, such as elements, dashboards, etc., a **space** should be used instead of a hyphen to enhance readability.
- **PascalCase** should be applied for the names of the components, i.e. the different words are appended to each other, each word starting with a single uppercase letter.
- Names of components should **express their purpose** or intent. This facilitates understanding of what the specific component is meant for.
- If **dates** are used in files, use the ISO 8601 format (YYYYMMDD).
- If **numeric values** are used, ensure there are **sufficient digits** to allow good sorting.
- A **similar component structure** should be applied to all components wherever possible.

## Naming conventions per component

### Automation script

Generic Automation scripts and Automation scripts that are used in solutions should have a name in the following format, where *[TYPE]* is the type of the script as defined in [Github repository naming convention](xref:Using_GitHub_for_CICD#repository-naming-convention): `[SOLCODE]-[TYPE]-[name]`

For scripts created by Skyline for a specific customer, the customer abbreviation should be used instead of [SOLCODE]. For a list of these abbreviations, refer to [DCP](https://dcp.skyline.be/Lists/Customers/AllItems.aspx) (internal link for Skyline employees only).

Scripts should be added in the Automation module in the following folders, depending on the type of script:

- For standalone scripts:

  - **Regular** Automation script: `DataMiner Catalog/Automation`
  - **Ad hoc data source** script: `DataMiner Catalog/Ad Hoc Data Sources`
  - **Data transformer** script: `DataMiner Catalog/Data Transformers`
  - **User-defined API** script: `DataMiner Catalog/User-Defined APIs`
  - **ChatOps** script: `DataMiner Catalog/ChatOps/bot`

- For scripts that are part of a **solution**: `DataMiner Catalog/[SOLCATEGORY]/[SOLNAME]/[subfolders]`

  For example: `DataMiner Catalog/Apps & Solutions/MediaOps/Common`

  > [!NOTE]
  > ChatOps scripts should always be included in a `bot` subfolder. See [Adding custom commands for the Teams bot](xref:DataMiner_Teams_bot#adding-custom-commands-for-the-teams-bot-to-a-dms).

### Ad hoc data source

For the name of the ad hoc data source as shown in the DataMiner web apps, use the following format: `[SOLCODE] [name]`

For the name of the Automation script used for an ad hoc data source, see [Automation script](#automation-script).

### Correlation rule

Correlation rules should have a name in the following format: `[SOLCODE] [name]`

They should be added in the Correlation module in the following folder: `DataMiner Catalog/[SOLCATEGORY]/[SOLNAME]/[subfolders]`

### Dashboard

Dashboards should have a name in the following format: `[SOLCODE] [name]`

They should be added in the Dashboards app in the following folder: `DataMiner Catalog/[SOLCATEGORY]/[SOLNAME]`

### Data transformer

For the name of the data transformer as shown in the DataMiner web apps, use the following format: `[SOLCODE] [name]`

For the name of the Automation script used for a data transformer, see [Automation script](#automation-script).

### Document

Documents should have a name in the following format: `[SOLCODE] [name]`

They should be added in the Documents module in the following folder: `DataMiner Catalog/[SOLCATEGORY]/[SOLNAME]/[subfolders]`

### Element

Elements should have a name in the following format: `[SOLCODE] [name]`

They should be added to the Surveyor in the following view structure: `DataMiner Catalog/[SOLNAME]`

Elements should also be hidden where applicable.

### Low-code app

A low-code app should have the name of the solution.

It should be placed in a category reflecting the solution market. This can be one of the following categories:

- MediaOps
- GridOps
- SatOps
- NetOps
- IoTOps

If none of the above are a match, you can use a custom category that does match your solution (e.g. "Business Administration" for the "People & Organization" low-code app).

### Property

Properties should have a name in the following format: `[SOLCODE] [name]`

### Protocol/template

A protocol or template should have a name in the following format: `[vendor] [SOLCODE] [name]`

### Scheduled task

A scheduled task should have a name in the following format: `[SOLCODE] [name]`

### Simulation

A simulation should have a name in the following format: `[SOLCODE] [name]`

It should be added to the folder `DataMiner Catalog/[SOLNAME]`.

### User-Defined API

A user-defined API should have a URL in the following format: `http(s)://<HOSTNAME>/api/custom/[SOLCODE]/[name]`

For the name of the Automation script used for a user-defined API, see [Automation script](#automation-script).

### View

A view should have a name in the following format: `[name] ([SOLCODE])`

It should be added to the Surveyor in the following view structure: `DataMiner Catalog/[SOLCATEGORY]/[SOLNAME]/[subviews]`

### Visio file

A Visio file should be named after the corresponding view or protocol.
