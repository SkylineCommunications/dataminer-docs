---
uid: Protocol.Params.Param.Display.ParametersView-type
---

# type attribute

Specifies the chart type.

## Content Type

[EnumParametersViewType](xref:Protocol-EnumParametersViewType)

## Parent

[ParametersView](xref:Protocol.Params.Param.Display.ParametersView)

## Remarks

> [!NOTE]
>
> - Pie charts only work if the referenced values are either all positive or all negative.
> - StackedArea charts should not be used to display values that are constantly changing.

## Examples

```xml
<Param id="40">
    <Name>DataMiner CPU</Name>
    <Description>DataMiner CPU</Description>
    <Type>read</Type>
    <Display>
        <RTDisplay>true</RTDisplay>
        <Positions>
            <Position>
                <Page>Charts</Page>
                <Row>1</Row>
                <Column>0</Column>
            </Position>
        </Positions>
        <ParametersView type="pie" options="height:200">
            <Parameters>
                <Parameter id="99" tableIndex="sl*" options="" />
            </Parameters>
        </ParametersView>
    </Display>
    <Interprete>
        <Type>double</Type>
        <DefaultValue>0</DefaultValue>
    </Interprete>
    <Measurement>
        <Type>chart</Type>
    </Measurement>
</Param>
```
