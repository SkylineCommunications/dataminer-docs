---
uid: AdvancedCustomPropertiesCustomElementProperties
---

# Custom element properties

Table 11000 contains the virtual elements to place the properties on.

Table 15000 is the property table.

Add `<Params loadSequence="15000">` at the beginning of protocol so the properties will be set at the element before all the rest when starting up.

```xml
<Relations>
    <Relation path="11000;15000"/>
</Relations>
<Params loadSequence="15000">
    …
    <Param id="15000" trending="false">
        <Name>Custom Generic Properties Table</Name>
        <Description>Custom Generic Properties Table</Description>
        <Type>array</Type>
        <ArrayOptions index="0" options=";propertyTable=15002,15003,15004,15005">
            <ColumnOption idx="0" pid="15001" type="autoincrement" value=""/><!--Index-->
            <ColumnOption idx="1" pid="15002" type="custom" value="" options=";save;foreignKey=11000"/><!-- Equip id-->
            <ColumnOption idx="2" pid="15003" type="custom" value="" options=";save"/><!-- Property Name-->
            <ColumnOption idx="3" pid="15004" type="custom" value="" options=";save"/><!--Property Type-->
            <ColumnOption idx="4" pid="15005" type="custom" value="" options=";save"/><!--Property Value-->
        </ArrayOptions>
        <Interprete>
            <RawType>other</RawType>
            <LengthType>next param</LengthType>
            <Type>double</Type>
        </Interprete>
        <Display>
            <RTDisplay>true</RTDisplay>
        <Positions>
            <Position>
                <Page>Properties Information</Page>
                <Row>1</Row>
                <Column>0</Column>
            </Position>
        </Positions>
        </Display>
        <Measurement>
            <Type options="tab=columns:15001|0-15002|1-15003|2-15004|3-15005|4,lines:25,width:100-200-200-200-200,sort:INT-STRING-STRING-STRING-STRING,filter:true">table</Type>
        </Measurement>
    </Param>
    <Param id="15001" trending="false">
    <Name>Custom Generic Property Index</Name>
    <Description>Custom Generic Property Index</Description>
    <Type>read</Type>
    <Interprete>
        <RawType>other</RawType>
        <LengthType>next param</LengthType>
        <Type>string</Type>
    </Interprete>
    <Display>
        <RTDisplay>true</RTDisplay>
    </Display>
    <Measurement>
        <Type>string</Type>
    </Measurement>
    </Param>
    <Param id="15002" trending="false">
    <Name>Custom Generic Property Equipment Id</Name>
    <Description>Custom Generic Property Equipment Id</Description>
    <Type>read</Type>
    <Interprete>
        <RawType>other</RawType>
        <LengthType>next param</LengthType>
        <Type>string</Type>
    </Interprete>
    <Display>
        <RTDisplay>true</RTDisplay>
    </Display>
    <Measurement>
        <Type>string</Type>
    </Measurement>
    </Param>
    <Param id="15003" trending="false">
    <Name>Custom Generic Property Name</Name>
    <Description>Custom Generic Property Name</Description>
    <Type>read</Type>
    <Interprete>
        <RawType>other</RawType>
        <LengthType>next param</LengthType>
        <Type>string</Type>
    </Interprete>
    <Display>
        <RTDisplay>true</RTDisplay>
    </Display>
    <Measurement>
        <Type>string</Type>
    </Measurement>
    </Param>
    <Param id="15004" trending="false">
    <Name>Custom Generic Property Type</Name>
    <Description>Custom Generic Property Type</Description>
    <Type>read</Type>
    <Interprete>
        <RawType>other</RawType>
        <LengthType>next param</LengthType>
        <Type>string</Type>
    </Interprete>
    <Display>
        <RTDisplay>true</RTDisplay>
    </Display>
    <Measurement>
        <Type>string</Type>
    </Measurement>
    </Param>
    <Param id="15005" trending="false">
    <Name>Custom Generic Property Value</Name>
    <Description>Custom Generic Property Value</Description>
    <Type>read</Type>
    <Interprete>
        <RawType>other</RawType>
        <LengthType>next param</LengthType>
        <Type>string</Type>
    </Interprete>
    <Display>
        <RTDisplay>true</RTDisplay>
    </Display>
    <Measurement>
        <Type>string</Type>
    </Measurement>
    </Param>
    ...
</Params>
```
