---
uid: I-DOCSIS_maps_deployment_multiple_backends
---

# Systems with multiple back-end elements

> [!NOTE]
> The configuration files mentioned in the procedure below are automatically installed when you upgrade to the latest EPM I-DOCSIS version. You can find them in the following folder on the DMA where the front-end element is located: `C:\Skyline DataMiner\Maps\Configs`.

To deploy the I-DOCSIS EPM maps to a DataMiner System with multiple elements using the [Skyline EPM Platform DOCSIS](https://catalog.dataminer.services/result/driver/7209) protocol:

1. Get the configuration file for the node segment maps (*EPM_MAPS_NODE_SEGMENT.xml*).

1. Make sure that the *elementVar* field of all passive layers contains the name of the card variable (without the initial underscore) used in the Skyline EPM Platform Visio drawing:

   ![Verify if the elementVar field contains the card variable](~/user-guide/images/EPM_I_DOCSIS_maps_deployment_maps_config_one_backend.png)

1. Create a relation layer per back-end element. You can copy one of the existing layers in the configuration file and paste it until you match the number of back-end elements in the DMS. For example, if the DMS has 11 back-end elements, you need to create 11 relation layers in the map configuration file.

   A relation layer has the following structure:

   ```xml
   <Layer sourceType="relations" allowToggle="false" name="AmpTapsRelation" visible="true" limitToBounds="true">
      <ForeignKeyRelationsSourceInfo filterVars="myFilter">
         <DataMinerID></DataMinerID>
         <ElementID></ElementID>
         <DestinationTableID></DestinationTableID>
         <SourceLatitudeColumnPID></SourceLatitudeColumnPID>
         <SourceLongitudeColumnPID></SourceLongitudeColumnPID>
         <DestinationLatitudeColumnPID></DestinationLatitudeColumnPID>
         <DestinationLongitudeColumnPID></DestinationLongitudeColumnPID>
         <SourceTableFilters>
            ...
         </SourceTableFilters>
         <DestinationTableFilters>
            ...
         </DestinationTableFilters>
      </ForeignKeyRelationsSourceInfo>
      <LineOptions weight="2" color="black" opacity="1" geodesic="true" />
   </Layer>
   ```

1. Verify for each relation layer that the *DataMinerID* and *ElementID* tags contain the DataMiner ID and element ID of a back-end element.

   For example, if 26458/13 is the DataMiner ID/element ID combination of the first back-end element and 26459/29 is the DataMiner ID/element ID combination of the second back-end element:

    - First relation layer

      ```xml
      <Layer sourceType="relations" allowToggle="false" name="AmpTapsRelation" visible="true" limitToBounds="true">
         <ForeignKeyRelationsSourceInfo filterVars="myFilter">
            <DataMinerID>26458</DataMinerID>
            <ElementID>13</ElementID>
            ...
         </ForeignKeyRelationsSourceInfo>
         <LineOptions weight="2" color="black" opacity="1" geodesic="true" />
      </Layer>
      ```

    - Second relation layer

      ```xml
      <Layer sourceType="relations" allowToggle="false" name="AmpTapsRelation" visible="true" limitToBounds="true">
         <ForeignKeyRelationsSourceInfo filterVars="myFilter">
             <DataMinerID>26459</DataMinerID>
             <ElementID>29</ElementID>
             ...
         </ForeignKeyRelationsSourceInfo>
         <LineOptions weight="2" color="black" opacity="1" geodesic="true" />
      </Layer>
      ```

   > [!NOTE]
   > The order in which each back-end element is assigned to each relation layer does not matter. Make sure that all relation layers contain different DataMiner ID/element ID values, and that each back-end element in the system has a corresponding relation layer.

1. Get the files *EPM_MAPS_AMPLIFIER.xml* and *EPM_MAPS_AMPLIFIER_CPE.xml* and make sure that the *elementVar* field of all passive layers contains the name of the card variable (without the initial underscore) used in the Skyline EPM Platform Visio drawing.

1. Get the following files:

   - *EPM_MAPS_NODE_SEGMENT_CPE.xml*

   - *EPM_MAPS_NODE.xml*

   - *EPM_MAPS_NODE_CPE.xml*

1. Apply the following steps for these three files as well:

   1. Make sure that the *elementVar* field of all passive layers contains the name of the card variable (without the initial underscore) used in the Skyline EPM Platform Visio drawing.

   1. Create a relation layer per backend element, as detailed above.

   1. Verify for each relation layer that the *DataMinerID* and *ElementID* tags contain the DataMiner ID and element ID of a back-end element, as detailed above.
