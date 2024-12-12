---
uid: Protocol.Params.Param.Mediation.LinkTo.ValueMapping
---

# ValueMapping element

<!-- RN 24127 -->

Specifies a conversion of a value on the device protocol to a different value on the base protocol. This functionality can, for instance, be used to map a discrete value on the device protocol (remoteValue) to an equivalent discrete represented by a different value on the base protocol.

## Parent

[LinkTo](xref:Protocol.Params.Param.Mediation.LinkTo)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[remoteValue](xref:Protocol.Params.Param.Mediation.LinkTo.ValueMapping-remoteValue)|string|Yes|Specifies the value in the other protocol.|
|[value](xref:Protocol.Params.Param.Mediation.LinkTo.ValueMapping-value)|string|Yes|Specifies the value in the current protocol.|

## Remarks

- Value mappings can be defined for both single-value and column parameters of type string or double. If you define them for parameters with Interprete type "high nibble", they will be ignored.
- In case of read/write parameters, value mappings have to be defined on both. Note, however, that they should not be identical. If a value mapping match is found when reading or writing a parameter, then the ops attribute of the LinkTo tag will be ignored. However, if no relevant mappings could be found for the value in question, the ops attribute will be taken into account. This can prove useful in case of exception values.

## Examples

Example of a value mapping defined in a base protocol:

```xml
<Mediation>
    <LinkTo protocol="Skyline Discreet Values" pid="10" ops="/:1000000">
        <ValueMapping remoteValue="-1" value="-2"/>
    </LinkTo>
</Mediation>
```

Example of a value mapping defined in a device protocol:

```xml
<Mediation>
    <LinkTo pid="70005">
        <ValueMapping remoteValue="1" value="5"/>
        <ValueMapping remoteValue="2" value="7"/>
    </LinkTo>
</Mediation>
```
