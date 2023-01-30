---
uid: SLNetClientTest_forcing_file_sync
---

# Forcing file synchronization between DMAs

Usually, when two files have the exact same timestamp, these are not synchronized, even if the contents differ. From DataMiner 9.0.0 CU12 onwards, the SLNetClientTest tool allows you to carry out an advanced synchronization between Agents in a DMS, optionally also checking for differences between files that have the same timestamp.

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, select *Force Sync*.

1. Go to the *DMA* tab. The tab consists of two buttons, and two options:

   - *Force Sync DMA* button: Starts synchronization of the connected DMA only.

   - *Force Sync DMS* button: Starts synchronization of all files in the DMS.

   - *Verify size/CRC for files that have the same time in the SyncInfo changes file*: If this option is selected, when you click the *Force Sync* button, the DMA or DMS will be checked for files that were changed at the same moment, but have a different content. Any inconsistencies will be mentioned in information events. Extra log information can also be found in *SLDMS.txt* and *SLErrors.txt*.

   - *Fix inconsistency problems*: If this option is selected, when you click the *Force Sync* button, any inconsistencies that are found will be resolved. This option can only be selected if the option above is selected as well.

1. Select the options you want to apply, and either click *Force Sync DMA* or *Force Sync DMS*, depending on whether you want to sync the currently connected DMA only, or all DMAs in the DMS.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
