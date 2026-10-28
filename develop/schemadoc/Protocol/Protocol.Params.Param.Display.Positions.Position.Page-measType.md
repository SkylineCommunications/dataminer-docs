---
uid: Protocol.Params.Param.Display.Positions.Position.Page-measType
description: "Use the measType attribute in a DataMiner protocol to override how a parameter is displayed on one specified Data Display page."
---

# measType attribute

Specifies that this parameter has to be displayed in a specific way on the specified page.

## Content Type

[EnumParamMeasurementType](xref:Protocol-EnumParamMeasurementType)

## Parent

[Page](xref:Protocol.Params.Param.Display.Positions.Position.Page)

## Examples

In the following example, the parameter will be displayed on page P1 as well as on page P5.

- On page P1, it will be displayed as specified in its Protocol.Params.Param.Measurement.Type tag.
- On page P5, it will be displayed as a parameter of type “analog”.

```xml
<Positions>
    <Position>
        <Page>P1</Page>
        <Row>0</Row>
        <Column>1</Column>
    </Position>
    <Position>
        <Page measType="analog">P5</Page>
        <Row>0</Row>
        <Column>1</Column>
    </Position>
</Positions>
```
