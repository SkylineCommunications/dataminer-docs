---
metadata_version: 1
uid: ChangeParameterInterprete
description: "Describe the DataMiner connector development topic Change parameter Interprete, including its purpose, behavior, implementation guidance, and relevant con."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Change parameter Interprete

Changing the Interprete of a parameter is considered a major change.

## Impact

- Possible changes in database trending.
- Custom reports might require changes.

*DIS MCC*

| Full ID | Error Message | Description                                                                                      |
|---------|---------------|--------------------------------------------------------------------------------------------------|
| 2.20.1  | UpdatedValue  | Interprete type on Param '{paramId}' has been changed from '{oldTypeValue}' to '{newTypeValue}'. |
| 2.20.2  | RemovedTag    | Interprete type on Param '{paramId}' has been removed.                                           |
| 2.20.3  | AddedTag      | New Type tag '{typeValue}' for interprete in Param '{paramId}' was added.                        |

## Workarounds

There is no workaround.
