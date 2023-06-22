---
uid: KI_GenIf_Folder_Growing_In_Size
---

# GenIf folder takes up too much disk space

## Affected versions

From DataMiner 10.1.0/10.0.13 onwards.

## Cause

To investigate issues, a `GenIf` folder can be manually added in the folder `C:\Skyline DataMiner\Logging`. A recording of each GQI request is then created in this folder, but these recordings do not get removed over time. This means that folder will keep growing in size and taking up disk space, which will be especially noticeable if you often open dashboards or apps with many GQI queries.

## Fix

As soon as you no longer need the `GenIf` folder for debugging, remove this folder.

If you do wish to keep the folder, make sure it gets cleaned up automatically using Automation or another tool.

> [!NOTE]
> As of DataMiner version 10.3.0 [CU5]/10.3.8, the size of the `GenIf` folder is kept limited. For more information, see [RN 36642](xref:Web_apps_Feature_Release_10.3.8#gqi-session-recording-time-and-disk-space-limits-id_36642).

## Issue description

The `C:\Skyline DataMiner\Logging\GenIf` folder keeps on growing in size and takes up a lot of disk space.
