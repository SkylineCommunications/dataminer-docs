---
uid: DMSScript.Folder
---

# Folder element

Specifies the folder in which the Automation script is included.

## Type

|Item|Facet value|Description|
|--- |--- |--- |
|***Union***|||
|&nbsp;&nbsp;***string restriction***|||
|&nbsp;&nbsp;&nbsp;&nbsp;Max length|0||
|&nbsp;&nbsp;***string restriction***|||
|&nbsp;&nbsp;&nbsp;&nbsp;Pattern|`^[^\\:;\*\?><\|°"]*$`||

## Parent

[DMSScript](xref:DMSScript)

## Remarks

> [!NOTE]
>
> - The folders only exist in Cube. All automation scripts are present in the Scripts folder of DataMiner.
> - The following characters are prohibited: : * ? " < > | ° ;
> - When updating this value in the script itself, the update will only be shown after removing all *.txf files in the Scripts folder and restarting DataMiner.
