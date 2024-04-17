---
uid: EpmIntegrationTrainingOtherOptions
---

# Other configuration options

## Titlebox Data section

The native look of the Data section of an EPM Entity is two columns filled with all of the information in two columns related to the row of the entity in the column order of the table. All columns that are shown are also shown in the Data section. If a column has width=0, then it will not show in this section and will be unable to be shown.

To further configure the look of the data section and also add title boxes, you need to create a page called CPEIntegration/[EPM System Type] i.e. CPEIntegration/Region.

On this page, you may add parameters as you would any other page, but you may also add individual column parameters associated with the entity. If using duplicateAs option, both the native and view table column will occupy the same space but will not cause issues in DataMiner.

![EPM Data layout](~/develop/images/EPM_Data_Layout.png)

![EPM Data page](~/develop/images/EPM_Data_page.png)

## EPM configuration

There are a couple of options that are required for the EPM protocol to have so the DMS knows which element is the front end of the system. First is a parameter named “Elementmanagertype” and the other is having the Protocol.Display@type attribute set to "element manager". More information can be found here: [EPM Integration in Cube](xref:AdvancedEpm)

On startup, the DMS will crawl through the system to find which element has these conditions met to establish it as the front end. To avoid having to do this crawl, you can set this property using an Automation script. The [EpmConfig](https://catalog.dataminer.services/details/automation-script/3713) script will do so after inputting the DataMiner and Element ID of the front end.

### Topology soft launch

To see the topology app in Cube, you must enable the [soft-launch option](xref:Overview_of_Soft_Launch_Options#cpeintegration) on all DMAs you would like to see the app on. This can be done by creating a file, if not already present, called “SoftLaunchOptions.xml” on the root directory of the Skyline DataMiner folder that has the following:

```xml
<SLNet>
   <CPEIntegration>true</CPEIntegration>
</SLNet>
```

## SLScripting processes per collector

The collectors in an EPM environment are the powerhouses in the solution. Because of this, one typically wants to ensure that they are given all the resources they can. To do so you can [create more](xref:Configuration_of_DataMiner_processes#configuring-a-separate-slprotocol-process-for-every-protocol-used) SLProtocol/SLScripting processes and/or create a SLProtocol/SLScripting process for [every element running a specified protocol](xref:Configuration_of_DataMiner_processes#configuring-separate-slprotocol-and-slscripting-instances-for-a-specific-protocol).
