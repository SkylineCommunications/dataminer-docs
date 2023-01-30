---
uid: DMATopologyChainsField
---

# DMATopologyChainsField

| Item | Format | Description |
|--|--|--|
| Name | String | The name of the field. |
| FieldPID | Integer | The parameter ID used to request the possible field values (e.g. with the method *GetValuesForCPETopologyField*). |
| TableIndexPID | Integer | The parameter ID of the column that is filtered in order to get the parameters (with the method *GetParametersForCPEChain*) or the possible values (with the method *GetValuesForCPETopologyField*). |
| TablePID | Integer | The parameter ID of the table. |
| Type | String | The type of selector, which is either “combo”, denoting a drop-down list, or “edit”, denoting a text input field. |
| Childs | Array of DMATopologyChainsField | An array containing the same properties as the parent DMATopologyChainsField array, but without further child items. |
