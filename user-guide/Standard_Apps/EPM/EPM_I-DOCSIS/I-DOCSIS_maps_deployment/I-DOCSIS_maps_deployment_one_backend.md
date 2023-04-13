---
uid: I-DOCSIS_maps_deployment_one_backend
---

# Systems with one back-end element

> [!IMPORTANT]
> Several example map configuration files are available for a system with one back-end element: [EPM Maps - Single BE](https://skylinebe.sharepoint.com/:f:/s/DataMinerSolutions-DAA/Ej8kDjNbl3hGsXarmMu3QYQBsHjSSlDPI7eKJnvwIE4nHQ?e=89O0lc). We recommend using these example files to follow this procedure.

To deploy the I-DOCSIS EPM maps to a DataMiner System with one element using the [Skyline EPM Platform DOCSIS](https://catalog.dataminer.services/result/driver/7209) protocol:

1. Upload the latest version of the [Skyline EPM Platform Visio drawing](https://svn.skyline.be/!/#SystemEngineering/view/head/Visios/Generic/Protocols/Skyline/EPM%20Platform) to the DMA.

1. Get the configuration file for the node segment maps (*EPM_MAPS_NODE_SEGMENT.xml*).

1. Make sure that the *elementVar* field of all passive layers contains the card variable used in the Skyline EPM Platform Visio drawing:

   ![Verify if the elementVar field contains the card variable](~/user-guide/images/EPM_I_DOCSIS_maps_deployment_maps_config_one_backend.png)

1. Verify on the relation layer that the *DataMinerID* and *ElementID* tags contain the DataMiner ID and element ID of the back-end element.

   For example, if 26458/13 is the DataMiner ID/element ID combination of the back-end element:

   ```xml
   <Layer sourceType="relations" allowToggle="false" name="AmpTapsRelation" visible="true" limitToBounds="true">
      <ForeignKeyRelationsSourceInfo filterVars="myFilter">
      <DataMinerID>26458</DataMinerID>
      <ElementID>13</ElementID>
      ...
   </Layer>
   ```

1. Get the files *EPM_MAPS_AMPLIFIER.xml* and *EPM_MAPS_AMPLIFIER_CPE.xml* and make sure that the *elementVar* field of all passive layers contains the card variable used in the Skyline EPM Platform Visio drawing.

1. Get the following files:

   - *EPM_MAPS_NODE_SEGMENT_CPE.xml*

   - *EPM_MAPS_NODE.xml*

   - *EPM_MAPS_NODE_CPE.xml*

1. Apply the following steps for these three files as well:

   1. Make sure that the *elementVar* field of all passive layers contains the card variable used in the Skyline EPM Platform Visio drawing.

   1. Verify on the relation layer that the *DataMinerID* and *ElementID* tags contain the DataMiner ID and element ID of the back-end element, as detailed above.

1. Add all map configuration files to the folder `C:\Skyline DataMiner\Maps\Configs` on the DMA where the front-end element is located. If this folder does not exist yet, you can create it.

1. Add the files from the [Icons folder](https://skylinebe.sharepoint.com/:f:/s/DataMinerSolutions-DAA/Er0-2xHloyJAtijNn5fD2SoBZs87yrqVmZW-dZCToJGO5w?e=ODoCr9) to the folder `C:\Skyline DataMiner\Webpages\Maps\v1\images\icons` on the DMA where the front-end element is located.
