---
uid: Protocol.Params.Param.Dependencies.Id
---

# Id element

Specifies the IDs of the parameters that are linked to this parameter.

## Type

[TypeParamId](xref:Protocol-TypeParamId)

## Parent

[Dependencies](xref:Protocol.Params.Param.Dependencies)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[postSet](xref:Protocol.Params.Param.Dependencies.Id-postSet)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||Specifies whether the dependency parameter acts as a preset or a post-set.|

## Examples

Before a set on the param is done, the values of extra params (id 1, 2 and 3) need to be filled in.

```xml
<Dependencies>
   <Id>1</Id>
   <Id>2</Id>
   <Id>3</Id>
</Dependencies>
```

## Remarks

Linked parameters must have their [RTDisplay](xref:Protocol.Params.Param.Display.RTDisplay) tag set to true.
