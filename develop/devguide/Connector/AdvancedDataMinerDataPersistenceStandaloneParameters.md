---
metadata_version: 1
uid: AdvancedDataMinerDataPersistenceStandaloneParameters
description: "Describe the DataMiner connector development topic Standalone parameters, including its purpose, behavior, implementation guidance, and relevant constrain."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
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
