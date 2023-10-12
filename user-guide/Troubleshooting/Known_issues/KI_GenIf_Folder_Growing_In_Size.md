---
uid: KI_GenIf_Folder_Growing_In_Size
---

# GenIf folder takes up too much disk space

## Affected versions

- DataMiner 10.1.0 up to 10.3.0 [CU4].
- DataMiner 10.0.13 up to 10.3.7.

## Cause

To investigate issues, a `GenIf` folder can be manually added in the folder `C:\Skyline DataMiner\Logging`. A recording of each GQI request is then created in this folder, but these recordings do not get removed over time. This means that folder will keep growing in size and taking up disk space, which will be especially noticeable if you often open dashboards or apps with many GQI queries.

## Fix

In DataMiner versions prior 10.3.0 [CU5]/10.3.8, as soon as you no longer need the `GenIf` folder for debugging, remove this folder. If you do wish to keep the folder, make sure it gets cleaned up automatically using Automation or another tool.

If you install DataMiner 10.3.0 [CU5] or 10.3.8, older recordings in the `GenIf` folder will automatically be removed when a new recording is created, so that the size of the folder is limited to at most 100 MB.<!-- RN 36642 -->

## Issue description

The `C:\Skyline DataMiner\Logging\GenIf` folder keeps on growing in size and takes up a lot of disk space.
