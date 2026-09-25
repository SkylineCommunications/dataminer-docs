---
metadata_version: 1
uid: Protocol-EnumParamConfirmPopup
description: "Review the allowed values for the EnumParamConfirmPopup simple type and what each value represents in DataMiner connector protocols."
---

# EnumParamConfirmPopup simple type

Specifies the confirmation type.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|always|The confirmation popup will always appear, regardless of the value of the “*Never ask for confirmation after setting parameter value*” setting in DataMiner Cube.|
|&nbsp;&nbsp;Enumeration|never|The confirmation popup will never appear, regardless of the value of the “*Never ask for confirmation after setting parameter value*” setting in DataMiner Cube.|
|&nbsp;&nbsp;Enumeration|dm|The confirmation popup will appear or not, depending on the value of the “*Never ask for confirmation after setting parameter value*” setting in DataMiner Cube.|
