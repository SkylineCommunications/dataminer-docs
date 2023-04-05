---
uid: I-DOCSIS_maps_deployment_multiple_backends
---

# Systems with multiple backend elements

This procedure has to be followed on this order:

1. [Visio](#visio)
1. [Map Configuration Files](#map-configuration-files)

## Visio

1. Upload the latest version of the [Skyline EPM Platform visio](https://svn.skyline.be/!/#SystemEngineering/view/head/Visios/Generic/Protocols/Skyline/EPM%20Platform) to the DMS.

## Map Configuration Files

> [!IMPORTANT]
> Examples of several map configuration files already prepared for a system with two backends: [EPM Maps - Multiple BEs](https://skylinebe.sharepoint.com/:f:/s/DataMinerSolutions-DAA/EmQ3x6z4ssVAmmew81qf9BEBgqNwzKHSuU23jNUG8fLnCw?e=Z55chX).
> It is recommended that these example files are used to follow the steps described below.

1. Get the configuration file for the node segment maps (*EPM_MAPS_NODE_SEGMENT.xml*).

1. Make sure that the elementVar field of all passive layers contains the name of the card variable (name without the underline at the beginning) used on the Skyline EPM Platform visio:
![Verify if elementVar field contains the card variable created](~/user-guide/images/EPM_I_DOCSIS_maps_deployment_maps_config_one_backend.png)

1. Create a relation layer per backend element. You can copy one of the existing layers on the configuration file, and paste it until you match the number of backend elements on the DMS. For example, if the DMS has 11 backend elements, you need to create 11 relation layers on the map configuration file.

    - A relation layer has the following structure:

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

1. Verify, on each relation layers, that the DataMiner ID and Element ID tags contain the *DMAID* and *ELEMID* of a backend element. For example, 26458/13 is the *DMAID/ELEMID* of the first backend element and 26459/29 is the *DMAID/ELEMID* of the second backend element:

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
> The order by which each backend element is assigned to which relation layer does not matter. Make sure that all relation layers contain different *DMAID/ELEMID* values, and that each backend on the system has a correspondent relation layer.

1. Repeat step 2, on the following files:
    - *EPM_MAPS_AMPLIFIER.xml*
    - *EPM_MAPS_AMPLIFIER_CPE.xml*

1. Repeat steps 2, 3, and 4 on the following files:
    - *EPM_MAPS_NODE_SEGMENT_CPE.xml*
    - *EPM_MAPS_NODE.xml*
    - *EPM_MAPS_NODE_CPE.xml*

1. Add all map configuration files to: `C:\Skyline DataMiner\Maps\Configs` on the DMA where the Frontend element is located. If there is no Configs folder inside the Maps folder, you can create one.

1. Add the following [icon files](https://skylinebe.sharepoint.com/:f:/s/DataMinerSolutions-DAA/Er0-2xHloyJAtijNn5fD2SoBZs87yrqVmZW-dZCToJGO5w?e=ODoCr9) to : `C:\Skyline DataMiner\Webpages\Maps\v1\images\icons` on the DMA, where the Frontend element is located.
