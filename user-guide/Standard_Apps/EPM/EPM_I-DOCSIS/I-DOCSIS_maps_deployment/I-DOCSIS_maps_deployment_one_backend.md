---
uid: I-DOCSIS_maps_deployment_one_backend
---

# Systems with one backend element

This procedure has to be followed on this order:

1. [Visio](#visio)
1. [Map Configuration Files](#map-configuration-files)

## Visio

1. Upload the latest version of the [Skyline EPM Platform visio](https://svn.skyline.be/!/#SystemEngineering/view/head/Visios/Generic/Protocols/Skyline/EPM%20Platform) to the DMA.  

## Map Configuration files

> [!IMPORTANT]
> Examples of map configuration files to be used on a system with one backend are available on [EPM Maps - Single BE](https://skylinebe.sharepoint.com/:f:/s/DataMinerSolutions-DAA/Ej8kDjNbl3hGsXarmMu3QYQBsHjSSlDPI7eKJnvwIE4nHQ?e=89O0lc).
> It is recommended that these example files are used to follow the steps described below.

1. Get the configuration file for the node segment maps (*EPM_MAPS_NODE_SEGMENT.xml*).

1. Make sure that the elementVar field of all passive layers contains the card variable used on the Skyline EPM Platform visio:
![Verify if elementVar field contains the card variable created](~/user-guide/images/EPM_I_DOCSIS_maps_deployment_maps_config_one_backend.png)

1. Verify, on the relation layer, that the DataMiner ID and Element ID tags contain the *DMAID* and *ELEMID* of the backend element. For example, 26458/13 is the *DMAID/ELEMID* of the backend element:

    ```xml
    <Layer sourceType="relations" allowToggle="false" name="AmpTapsRelation" visible="true" limitToBounds="true">
        <ForeignKeyRelationsSourceInfo filterVars="myFilter">
        <DataMinerID>26458</DataMinerID>
        <ElementID>13</ElementID>
        ...
    </Layer>
    ```

1. Repeat step 2, on the following files:
    - *EPM_MAPS_AMPLIFIER.xml*
    - *EPM_MAPS_AMPLIFIER_CPE.xml*

1. Repeat steps 2 and 3, on the following files:
    - *EPM_MAPS_NODE_SEGMENT_CPE.xml*
    - *EPM_MAPS_NODE.xml*
    - *EPM_MAPS_NODE_CPE.xml*

1. Add all map configuration files to: `C:\Skyline DataMiner\Maps\Configs` on the DMA where the Frontend element is located. If the Configs folder does not exist, you can create one.

1. Add the following [icon files](https://skylinebe.sharepoint.com/:f:/s/DataMinerSolutions-DAA/Er0-2xHloyJAtijNn5fD2SoBZs87yrqVmZW-dZCToJGO5w?e=ODoCr9) to : `C:\Skyline DataMiner\Webpages\Maps\v1\images\icons` on the DMA, where the Frontend element is located.
