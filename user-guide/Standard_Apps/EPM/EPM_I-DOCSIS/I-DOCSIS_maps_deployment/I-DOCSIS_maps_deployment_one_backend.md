---
uid: I-DOCSIS_maps_deployment_one_backend
---

# Systems with one back-end element

> [!IMPORTANT]
> The configuration files mentioned in the procedure below are automatically installed when you upgrade to the latest EPM I-DOCSIS version. You can find them in the following folder on the DMA where the front-end element is located: `C:\Skyline DataMiner\Maps\Configs`.

To deploy the I-DOCSIS EPM maps to a DataMiner System with one element using the [Skyline EPM Platform DOCSIS](https://catalog.dataminer.services/result/driver/7209) protocol:

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
