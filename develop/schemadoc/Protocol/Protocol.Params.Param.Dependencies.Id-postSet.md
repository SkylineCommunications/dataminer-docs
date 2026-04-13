---
uid: Protocol.Params.Param.Dependencies.Id-postSet
---

# postSet attribute

Specifies whether the dependency parameter acts as a preset or a post-set.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Id](xref:Protocol.Params.Param.Dependencies.Id)

## Remarks

Default value: false.

When set to "false", the dependency parameter acts as a preset, meaning that the dependency parameter needs to be configured first (i.e., it cannot be "Not initialized"). After the user confirms by clicking the "OK" button in the pop-up window, the set of this write parameter is initiated.

When set to "true", the dependency parameter acts as a post-set, meaning that the dependency parameter should be verified. However, the set of this write parameter will not wait for configuration and confirmation but will already be initiated. (In this case, the user could decide to close the pop-up window without setting any of the dependency parameters.)

Post-set can be used for example when changing a selection input (implemented by the write parameter) in case the user also has to send a commit (implemented by a dependency parameter) to the device afterwards to commit the change.

## Examples

```xml
<Dependencies>
	<Id postSet="true">1</Id>
	<Id postSet="true">2</Id>
	<Id postSet="true">3</Id>
</Dependencies>
```
