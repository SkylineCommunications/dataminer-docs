---
uid: Troubleshooting_Surveyor
---

# Troubleshooting - Surveyor

> [!NOTE]
> This page is currently still being developed. The content is not yet optimized and may not yet be fully accurate.

## Surveyor

### Overview

<div class="mermaid">
flowchart TD
%% Define styles %%
linkStyle default stroke:#cccccc
classDef classTerminal fill:#1e5179,stroke:#1e5179,color:#ffffff,stroke-width:0px;
classDef classDecision fill:#4baeea,stroke:#4baeea,color:#ffffff,stroke-width:0px;
classDef classExternalRef fill:#9ddaf5,stroke:#9ddaf5,color:#1E5179,stroke-width:0px;
classDef classActionClickable fill:#999999,stroke:#999999,color:#ffffff,stroke-width:0px;
classDef classAction fill:#dddddd,stroke:#dddddd,color:#1E5179,stroke-width:0px;
classDef classSolution fill:#58595b,stroke:#58595b,color:#ffffff,stroke-width:0px;
%% Define blocks %%
START([Surveyor])
Views([Views])
Elements([Elements])
Services([Services])
Additional{{Issues with other functionalities?}}
RedundancyGroups([Redundancy Groups])
Sla([SLAs])
Export(["Export/import"])
etc([other])
%% Connect blocks %%
START --- Elements
START --- Services
START --- Views
START --- Additional
Additional --- RedundancyGroups
Additional --- Sla
Additional --- Export
Additional --- etc
%% Define hyperlinks %%
click Views "#views"
click Elements "#elements"
click Services "#services"
click RedundancyGroups "#redundancy-groups"
click Sla "#slas"
click Export "#exportimport"
%% Apply styles to blocks %%
class START classTerminal;
class Additional,Surveyor classDecision;
class etc,Views,RedundancyGroups,Export,Sla,Elements,Services, classExternalRef;
</div>

### Views

> [!TIP]
> For more information on views, see [Managing views](xref:Managing_views).

- **Issue**: A view appears on one DMA, but not on the other.

  **Plan of attack**: Refer to [SLDMS Flowchart](xref:Troubleshooting_SLDMS_exe).

- **Issue**: It takes a long time for a view to appear.

  **Plan of attack**: Refer to [SLDMS Flowchart](xref:Troubleshooting_SLDMS_exe).

- **Issue**: The alarm color of a view does not match that of its alarms.

  **Plan of attack**: Refer to [SLElement flowchart](xref:Troubleshooting_SLElement_exe).

### Elements

> [!TIP]
> For more information on elements, see [Elements](xref:About_elements).

**Issue**: Element data is not filled in, but there is a run-time error

**Plan of attack**: Refer to RTE Flowchart

### Services

> [!TIP]
> For more information on services, see [About services and service templates](xref:About_services).

### Redundancy groups

> [!TIP]
> For more information on redundancy groups, see [Redundancy groups](xref:RedundancyGroups).

### SLAs

> [!TIP]
> For more information on SLAs, see [DataMiner Business Intelligence](xref:sla).

### Export/Import

> [!TIP]
> For more information on export and import, see [Importing and exporting elements](xref:Importing_and_exporting_elements).

### Other
