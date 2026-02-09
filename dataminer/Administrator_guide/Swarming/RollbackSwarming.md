---
uid: SwarmingRollback
---

# Rolling back Swarming

When Swarming is enabled, the element config XML files (e.g. `Element.xml`, `ElementData.xml`, `Description.xml`, etc.) are moved from disk to the database. There is currently no procedure to move them back to disk, so you will instead need to [restore the files from a backup](#restoring-the-element-xml-files-from-a-backup) from before Swarming was enabled. Any **changes that happened to elements or redundancy groups after Swarming was enabled will be lost**. As a consequence, if you enabled Swarming but want to switch back, e.g. to temporarily go for a Failover setup and only enable Swarming later when failure detection has been implemented, the sooner you roll back Swarming again, the better.

The longer you wait, the greater the impact will be. Any modifications to existing elements or redundancy groups since the backup and any new elements or redundancy groups created since the backup will be lost, and any reference to them could become invalid. This for example means that services, redundancy groups, etc. could have references to elements that no longer exist.

For a small system, instead of restoring a backup, you can [restore elements using an export and import](#restoring-elements-using-an-export-and-import).

If you are using a test system and do not need to keep your data, we recommend doing a clean reinstall instead.

## Restoring the element XML files from a backup

When DataMiner is moving the XML files from disk to database, it will take a backup first. This migration happens during the first DataMiner startup after the Swarming feature is enabled.

The backup is initially stored in the *Recycle Bin* folder, but you can manually copy it over to a different location to have long-term access. It is stored in two .zip files, one for the elements folder and one for the redundancy folder. These .zip files are a snapshot from the moment Swarming was enabled. The files will for instance look like this:

- `2024_11_20 11_03_12_300_Elements - Elements 1591715048.zip`
- `2024_11_20 11_03_12_300_Redundancy - Redundancy 1722493042.zip`

To restore this backup and roll back Swarming:

1. Shut down all DMAs in the DMS.

1. On every DMA, restore the `C:\Skyline DataMiner\Elements\` and the `C:\Skyline DataMiner\Redundancy\` folder by replacing the folders on the disk with the ones in the zip files.

   This will restore both the elements and redundancy groups to be back as they were at the time of the backup, meaning that any changes or additions since the backup will be lost.

1. Manually disable Swarming:

   1. Shut down all DMAs in the DMS.

   1. On every DMA, delete the file `C:\Skyline DataMiner\Swarming.xml`.

   1. Restart all DMAs.

1. Restart all DMAs.

## Restoring elements using an export and import

For small systems, an alternative is to export the latest version of the elements, disable Swarming, and then import the elements again.

1. [Export the elements](xref:Exporting_elements_services_etc_to_a_dmimport_file) you want to save to a .dmimport file.

   Do not include any data from the database in the export. Only the element configuration should be included.

1. Manually disable Swarming:

   1. Shut down all DMAs in the DMS.

   1. On every DMA, delete the file `C:\Skyline DataMiner\Swarming.xml`.

   1. Restart all DMAs.

1. [Import the elements](xref:Importing_elements_services_etc_from_a_dmimport_file) again.
