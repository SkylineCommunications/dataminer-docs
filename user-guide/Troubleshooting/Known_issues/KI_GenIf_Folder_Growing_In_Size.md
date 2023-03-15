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

## Issue description

The `C:\Skyline DataMiner\Logging\GenIf` folder keeps on growing in size and takes up a lot of disk space.
