---
metadata_version: 1
uid: DMSScript.Name
description: "Reference the DataMiner Automation script schema entry for Name element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaAutomationScript
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Name element

Specifies the name of the automation script.

## Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Pattern|`^[^/\\:;\*\?><\|°"]+$`||

## Parent

[DMSScript](xref:DMSScript)

## Remarks

- The name of the script must be unique.
- The following characters are prohibited: \ / : * ? " < > | ° ;
- Automation scripts are saved in the Scripts folder of DataMiner. The name of the automation script file is as follows: Script_[Name].xml, where [Name] is the specified name.
