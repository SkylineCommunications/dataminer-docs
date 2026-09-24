---
metadata_version: 1
uid: Protocol.Params.Param-confirmPopup
description: "Learn how to use the confirmPopup attribute to override DataMiner Cube confirmation settings for parameter changes in a DataMiner connector protocol."
---

# confirmPopup attribute

<!-- RN 11133 -->

Overrides the *Never ask for confirmation after setting parameter value* setting in DataMiner Cube. (See [Cube settings](xref:User_settings#cube-settings).)

## Content Type

[EnumParamConfirmPopup](xref:Protocol-EnumParamConfirmPopup)

## Parent

[Param](xref:Protocol.Params.Param)

## Examples

```xml
<Param id="1" confirmPopup="always">
```
