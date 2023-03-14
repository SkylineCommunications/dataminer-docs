---
uid: KI_GenIf_Folder_Growing_In_Size
---

# GenIf folder grows in size taking up disk space

## Affected versions

All DataMiner versions

## Cause

GenIf(now called GQI) can have a manually created folder in C:\\Skyline DataMiner\\Logging, called GenIf created for debug purposes.

It makes a recording of each GQI request in this folder so if you open dashboards and low-code apps a lot with GQI queries, this folder will grow in size and so taken up disk space.

## Fix

Manually remove this folder to disable recordings, or clean it up automatically(via Automation or another tool). There is also a [task](https://collaboration.dataminer.services/task/207347) to limit it's size.

We also refer to the following [Dojo question](https://community.dataminer.services/question/logging-can-i-clean-the-content-of-the-genif-folder/?hilite=genif)
