---
uid: Protocol.Params.Param-confirmPopup
description: "Use the confirmPopup attribute in a DataMiner protocol to override DataMiner Cube confirmation settings for parameter changes."
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
