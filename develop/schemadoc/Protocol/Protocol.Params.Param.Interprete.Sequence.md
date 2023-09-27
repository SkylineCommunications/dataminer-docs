---
uid: Protocol.Params.Param.Interprete.Sequence
---

# Sequence element

Specifies a mathematical operation to be performed on the parameter value.

## Type

string

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[loop](xref:Protocol.Params.Param.Interprete.Sequence-loop)|unsignedInt||Specifies the loop value for the sequence (integer).|
|[noset](xref:Protocol.Params.Param.Interprete.Sequence-noset)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)|Yes|Always use this attribute with value set to `true`.|

## Remarks

- Only use a Sequence on communication parameters (i.e. parameters that are directly filled in by polling via SNMP, serial, etc.). Do not use it for custom/retrieved parameters (parameters filled in via a QAction.)
- The Sequence should always be provided with the `noset="true"` attribute.
- Only a change of the parameter with the Sequence tag can trigger the sequence. If the Sequence uses "id" in its content, changing the content of the parameter with that ID will not force the sequence to run when the parameter with the Sequence tag is updated with the same value as before.
- A Sequence is only supported in combination with the [snmpSetAndGet](xref:Protocol.Params.Param-snmpSetAndGet) attribute when used on a single parameter.

  ```xml
  <Param id="10">
     ...
     <Interprete>
     ...  
        <Sequence noset="true">div:id:101</Sequence>
     ...
     </Interprete>
     ...
  </Param>
  ```

  In the example above, if the parameter with ID 101 changes, but the parameter with ID 10 keeps getting set with the same value, the new sequence will never be triggered.

- On write parameters, use the reverse math operation in the reverse order compared to the corresponding read parameter.

  Example

  - Read parameter: `<Sequence noset=”true”>div:100;+:5</Sequence>`.
  - Write parameter: `<Sequence noset=”true”>min:5;factor:100</Sequence> or <Sequence noset=”true”>-:5;*:100</Sequence>`.
- Contains at least one of the following mathematical operations, which must be specified using one of the following predefined formats:

  - Fixed value: `[operation]:[value]`
  - Value stored in a single parameter: `[operation]:id:[pid]`
  - Value stored in a column parameter of the same row: `[operation]:param:[pid]`

  If you specify multiple operations, separate them using semicolons (”;”).
  List of possible operations:

  |Operation|Description
  |--- |--- |
  |factor (*)|Multiply the parameter with a particular value.|
  |offset (+)|Add a particular value to the parameter.|
  |min (-)|Subtract a particular value from the parameter.|
  |pow (^)|Raise the parameter to a particular power.|
  |div|Divide the parameter by a particular value.|
  |rest (%)|Perform a modulo operation (remainder) on the parameter using a particular value.|
  |log10|Perform a 10*log10 operation on the parameter.|
  |log20|Perform a 20*log10 operation on the parameter.|

  *Column parameter option introduced in DataMiner 8.5.0 (RN 7634).*

## Examples

```xml
<Sequence noset="true">div:param:101</Sequence>
```
