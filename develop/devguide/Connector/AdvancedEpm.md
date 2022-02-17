---
uid: AdvancedEpm
---

# EPM integration in Cube

A typical EPM (formerly known as CPE) environment usually consists of one front-end manager element (which allows you to access all data through direct view tables) and multiple back-end manager elements.

For EPM integration in Cube (RN 21798), you can indicate which of the manager elements is the front-end manager. This is done by adding a parameter of type "double" named "ElementManagerType" to the protocol of the front-end manager, and setting its value to "1":

```xml
<Param id="1" save="true" trending="false">
   <Name>ElementManagerType</Name>
   <Description>Element Manager Type</Description>
   <Information>
      <Subtext>Element Manager Type: Front-End or Back-End</Subtext>
      <Includes>
         <Include>time</Include>
         <Include>range</Include>
         <Include>steps</Include>
         <Include>units</Include>
      </Includes>
   </Information>
   <Type>read</Type>
   <Interprete>
      <RawType>numeric text</RawType>
      <LengthType>next param</LengthType>
      <Type>double</Type>
   </Interprete>
   <Display>
      <RTDisplay>true</RTDisplay>
      <Positions>
         <Position>
            <Page>General Configuration</Page>
            <Row>0</Row>
            <Column>0</Column>
         </Position>
      </Positions>
   </Display>
   <Measurement>
      <Type>discreet</Type>
      <Discreets>
         <Discreet>
            <Display>Front-End</Display>
            <Value>1</Value>
         </Discreet>
         <Discreet>
            <Display>Back-End</Display>
            <Value>2</Value>
         </Discreet>
      </Discreets>
   </Measurement>
</Param>
```

This is necessary to have an EPM tab in the Surveyor in Cube.

> [!NOTE]
> This parameter check will only be done on elements that are running a protocol where the Protocol.Display@type attribute has been set to "element manager".

*Feature introduced in DataMiner 9.6.7 (RN 21711).*
