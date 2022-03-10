---
uid: Protocol.Params.Param.Display.ParametersView-options
---

# options attribute

A pipe-separated list of options.

## Content Type

string

## Parent

[ParametersView](xref:Protocol.Params.Param.Display.ParametersView)

## Remarks

### height

Height of the chart (in pixels).

If you do not specify a height, the chart will take up the rest of the page.

In the following example, Parameter 40 displays the CPU values of all SL* processes in a pie chart with a height of 200 px:

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
