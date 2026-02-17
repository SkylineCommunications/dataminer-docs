---
uid: DMSScript.Name
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
