---
uid: DataMiner_Visio_templates
---

# DataMiner Visio templates

On a DataMiner Agent, you can find a number of default Visio drawings. If you want to create your own default drawings, you can either make copies of the drawings supplied by Skyline and adapt those copies, or create your own default drawings from scratch.

In this section:

- [Overview of the default Visio templates supplied by Skyline](#overview-of-the-default-visio-templates-supplied-by-skyline)

- [Creating your own Microsoft Visio templates](#creating-your-own-microsoft-visio-templates)

## Overview of the default Visio templates supplied by Skyline

Every DataMiner Agent is shipped with the following default Visio files.

### C:\\Skyline DataMiner\\Views\\Templates

| Type of file                               | File name(s)                                                                                                                                                                                                           |
|--------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Default general-purpose drawing template   | SkylineNewDrawing.vdx<br> SkylineNewDrawing.vsdx                                                                                                                                                                       |
| Default DataMiner stencil file             | SkylineNewDrawing.vss<br> SkylineNewDrawing.vssx                                                                                                                                                                       |
| Stencil files containing geographical maps | United States Maps (US units).vss<br> World Maps (Metric).vss<br> World Maps (US units).vss                                                                                                                            |
| Stencil files containing device drawings   | AppearTV DC1000.vss<br> AppearTV DC1100.vss<br> AppearTV MC3000.vss<br> AppearTV MC3100.vss<br> AppearTV SC2000.vss<br> AppearTV SC2100.vss<br> BridgeTech.vss<br> Nimbra300.vss<br> Nimbra600.vss<br> NimbraNodes.vss |

> [!NOTE]
> From DataMiner version 9.0 onwards, if you create a new Visual Overview, by default the .vsdx version of the template file is used.

### C:\\Skyline DataMiner\\Views\\Default

| File name                  | Description                                                                                                   |
|----------------------------|---------------------------------------------------------------------------------------------------------------|
| SkylineDefaultView.vsdx    | Visio drawing that will automatically be linked to every view to which no custom Visio drawing was linked.    |
| SkylineDefaultElement.vsdx | Visio drawing that will automatically be linked to every element to which no custom Visio drawing was linked. |
| SkylineDefaultService.vsdx | Visio drawing that will automatically be linked to every service to which no custom Visio drawing was linked. |

> [!NOTE]
> The above-mentioned default drawings can be overwritten during DataMiner software updates. We therefore advise you not to make any changes to those drawings.

## Creating your own Microsoft Visio templates

If you want to create your own set of Visio templates, you can:

- make copies of the default drawings supplied by Skyline and adapt the copies, or

- create your own default drawings from scratch.

Every custom Visio template must have a name identical to its Skyline-supplied counterpart, but without the “Skyline” prefix. If you create a custom template, it will overrule its “Skyline” counterpart.

| The custom template named: | will overrule the Skyline template named: |
|----------------------------|-------------------------------------------|
| NewDrawing.vdx             | SkylineNewDrawing.vdx                     |
| NewDrawing.vss             | SkylineNewDrawing.vss                     |
| DefaultView.vsdx           | SkylineDefaultView.vsdx                   |
| DefaultElement.vsdx        | SkylineDefaultElement.vsdx                |
| DefaultService.vsdx        | SkylineDefaultService.vsdx                |

> [!TIP]
> See also:
> [Visio – Customizing default and template drawings](https://community.dataminer.services/video/visio-customizing-default-and-template-drawings/) ![Video](~/user-guide/images/video_Duo.png)
