---
uid: Naming_Conventions_For_Catalog_Item_Components
keywords: catalog, package, solution, naming, convention
---

# Naming Conventions for Catalog Item Components

## About naming conventions

Naming conventions should be applied to all components used in solutions, for the following reasons:

- **Prevention of naming conflicts**: Many components of a DataMiner System require a unique name. This naming convention helps to prevent naming conflicts and to ensure that the different solutions do not unintentionally use the same files.
- **Readability and Understandability**: Consistent and meaningful names make it easier for any user to understand for which solution it is used, and what the exact purpose of the component is.
- **Consistency**: Consistent naming conventions contribute to a unified style across all solutions.

## Abbreviations

In the naming conventions, references will be made to the following abbreviations:

- **SOLCODE**: Solution Code, a 3-letter code in uppercase, uniquely referencing the solution.
- **SOLNAME**: Solution Name, the human-readable name of the solution.
- **SOLCATEGORY**: Category of the solution, currently supporting the following values:
  - *Apps & Solutions*: Category that groups all apps & solutions.
  - *Frameworks*: Category that groups all solutions related to DataMiner Frameworks, such as [Process Automation](xref:PA_index), [SRM](xref:About_SRM), etc.
  - *DevOps*: Category that groups all solutions serving a learning purpose, i.e. examples or kickstart for an easy start on developments.
  - *General*: Category grouping all components deployed as stand-alone artifacts, meaning they are deployed as part of specific solutions (e.g. a script used in multiple solutions).

## General conventions

- A hyphen will be used between the solution code and the unique component name. Components with more visibility to end users, such as elements, dashboards, etc., will be separated with a space instead of a hyphen to enhance readability.
- PascalCase will be applied for the names of the components, i.e. different words will be appended to each other, using a single uppercase letter for each additional word.
- Names of components should express their purpose or intent. This facilitates understanding of what the specific component is doing.
- If dates are used in files, they should be listed as ISO 8601 formatted dates (YYYYMMDD).
- If numeric values are used, ensure there are sufficient digits to allow good sorting.
- A similar component structure is applied to all components, where possible.

## Overview

The table below provides an overview of naming conventions that should be applied to components used in a solution.

|Component  | Level 1 | Level 2 | Level 3 | Level 4 | Level 5 |
|-----------|--------|--------|--------|--------|--------|
|**Automation**|DataMiner Catalog|SOLCATEGORY|SOLNAME|*subfolders*|SOLCODE-TYPE-[name]|
|**Ad Hoc Datasource**|SOLCODE [name]|||||
|**Correlation**|DataMiner Catalog|SOLCATEGORY|SOLNAME|*subfolders*|SOLCODE-[name]|
|**Document**|DataMiner Catalog|SOLCATEGORY|SOLNAME|*subfolders*|SOLCODE-[name]|
|**View**|DataMiner Catalog|SOLCATEGORY|SOLNAME|*subviews*|[name] (SOLCODE)|
|**Dashboard**|DataMiner Catalog|SOLCATEGORY|SOLNAME|SOLCODE [name]||
|**Low-Code App**|DataMiner Catalog|SOLCATEGORY|SOLNAME|SOLCODE [name]||
|**Element**|DataMiner Catalog|SOLNAME|SOLCODE [name]|||
|**Property**|SOLCODE [name]|||||
|**Protocols & Templates**|[vendor] SOLCODE [name]|||||
|**Scheduler**|SOLCODE_[name]|||||
|**Visio**|[view or protocol name]|||||
|**Simulation**|DataMiner Catalog|SOLNAME|SOLCODE [name]|||
|**User-Defined API**|api/custom|SOLCODE|[name]|||

> [!NOTE]
> - **Automation**: *Type* is the type of the script as defined in [Github repository naming convention](xref:Using_GitHub_for_CICD#repository-naming-convention).
> - **Documents**: The above-mentioned convention is applicable in the case of general documents.
> - **Element**: If multiple elements are used within a solution, the elements should be prefixed with SOLCODE, separated by a space character. Elements should also be hidden, where applicable.
> - **Properties**: The above-mentioned naming convention applies to custom properties. For generic properties, a list will be made available that provides an overview of all generic properties used in solutions. The objective here is to ensure the reuse of specific generic properties across multiple solutions. As a result, if a newly generated property needs to be created, it will need to go through an approval process to ensure alignment.
> - **Low-Code Apps**: One low-code app can be named in a similar way as a solution. Others will require a SOLCODE prefix.
