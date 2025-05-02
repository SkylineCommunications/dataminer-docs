---
uid: AdvancedDataMinerDataPersistenceStandaloneParameters
---

# Standalone parameters

In order to make a standalone parameter persist in the database, set the [save](xref:Protocol.Params.Param-save) attribute of the Param tag to "true".

This is typically useful for parameters holding a configurable value. For example:

```xml
<Param id="903" trending="false" save="true">
    <Name>Inputs_AutoClear</Name>
    <Description>Auto Clear Inputs</Description>
    <Information>
        <Subtext>Indicates whether or not to automatically remove missing inputs every hour.</Subtext>
    </Information>
    <Type>read</Type>
    <Interprete>
        <RawType>numeric text</RawType>
        <LengthType>next param</LengthType>
        <Type>double</Type>
        <DefaultValue>1</DefaultValue>
    </Interprete>
    <Display>
        <RTDisplay>true</RTDisplay>
        <Positions>
            <Position>
                <Page>Inputs</Page>
                <Row>1</Row>
                <Column>0</Column>
            </Position>
        </Positions>
    </Display>
    <Measurement>
        <Type>discreet</Type>
        <Discreets>
            <Discreet>
                <Display>Disabled</Display>
                <Value>0</Value>
            </Discreet>
            <Discreet>
                <Display>Enabled</Display>
                <Value>1</Value>
            </Discreet>
        </Discreets>
    </Measurement>
</Param>
```
