---
uid: Topology_app_configuration
---

# Topology app configuration

> [!IMPORTANT]
> The Topology app is currently only available in preview. To enable this feature, activate the *CPEIntegration* soft-launch option. See [Soft-launch options](xref:SoftLaunchOptions).

## Front-end element configuration

To have an EPM tab in the Surveyor in Cube, the DMS must know which element is the front end of the system.

To configure this, add a parameter of type "double" named "ElementManagerType" to the protocol of the front-end manager, and set its value to "1".

This feature is supported from DataMiner 9.6.7 onwards<!-- RN 21711 -->.

> [!NOTE]
> This parameter check will only be done on elements that are running a protocol where the Protocol.Display@type attribute has been set to "element manager".

```xml
<Param id="1" save="true" trending="false">
   <Name>ElementManagerType</Name>
   <Description>Element Manager Type</Description>
   <Information>
      <Subtext>Element Manager Type: Front-End or Back-End</Subtext>
   </Information>
   <Type>read</Type>
   <Interprete>
      <RawType>numeric text</RawType>
      <Type>double</Type>
      <LengthType>next param</LengthType>
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

> [!TIP]
> On startup, the DMS will crawl through the system to find which element has these conditions met to establish it as the front end. When the DMS finds the element, it will register its DMA and element ID in the DMS cache. This cache is wiped when the DMS is shut down or restarted. To avoid having to do this crawl, you can register the element using an Automation script. You can use the [EpmConfig](https://catalog.dataminer.services/details/automation-script/3713) script to register the element after inputting the DataMiner and element ID of the front end.

## Data section configuration

The native look of the Data section of an EPM entity is two columns filled with all the information related to the row of the entity in the column order of the table. All columns that are configured to be shown are also shown in the Data section. If a column has width=0, it will not show in this section, and it will be impossible to be view this column.

To further configure the look of the Data section and also add title boxes, you need to create a page called *CPEIntegration/[EPM System Type]*, e.g. *CPEIntegration/Region*.

On this page, you can add parameters as you would on any other page, but you can also add individual column parameters associated with the entity. If you use the [duplicateAs](xref:Protocol.Params.Param-duplicateAs) option, both the native and view table column will occupy the same space, but this will not cause issues in DataMiner.

![EPM Data layout](~/develop/images/EPM_Data_Layout.png)

![EPM Data page](~/develop/images/EPM_Topology_Data_page.png)
