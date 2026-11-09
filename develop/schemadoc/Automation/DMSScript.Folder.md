---
uid: DMSScript.Folder
description: "Organize automation scripts into DataMiner Cube folders using the Folder element, noting prohibited naming characters and script cache update behavior."
---

# Folder element

Specifies the folder in which the automation script is included.

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

- The folders only exist in Cube. All automation scripts are present in the *Scripts* folder of DataMiner.
- The following characters are prohibited: : * ? " < > | ° ;
- When this value is updated in the script itself, the update will only be shown after all \*.txf files are removed in the *Scripts* folder and DataMiner is restarted.
