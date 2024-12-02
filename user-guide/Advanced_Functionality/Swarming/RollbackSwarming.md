---
uid: SwarmingRollback
---

# Partially rolling back Swarming

> [!IMPORTANT]
> There is currently no good way to disable Swarming and keep everything in the DMS intact. The info below only partially recovers some data. If you are using a test system and it does not matter if all data are lost, a clean reinstall is advised.

When Swarming is enabled, the element config XML files (e.g. `Element.xml`, `ElementData.xml`, `Description.xml`, etc.) are moved from disk to the database. There is currently no procedure to move them back to disk.

However, there are some things you can do partially recover some data.

## Partial rolling back Swarming from a backup

When DataMiner is moving the XML files from disk to database, it will take a backup first. This migration happens during the first DataMiner startup after the Swarming feature is enabled.

The backup is initially stored in the *Recycle Bin* folder, but you can manually copy it over to a different location to have long-term access. It is stored in two .zip files, one for the elements folder and one for the redundancy folder. These .zip files are a snapshot from the moment Swarming was enabled. The files will for instance look like this:

- `2024_11_20 11_03_12_300_ElementFolder_BeforeSwarmingMigration.zip`
- `2024_11_20 11_03_12_300_RedundancyFolder_BeforeSwarmingMigration.zip`

To restore this backup and roll back Swarming:

1. Shut down all DMAs in the DMS.

1. On every DMA, restore the `C:\Skyline DataMiner\Elements\` and the `C:\Skyline DataMiner\Redundancy\` folder by replacing the folders on the disk with the ones in the zip files.

   This will restore both the elements and redundancy groups to be back as they were at the time of the backup, meaning that any changes or additions since the backup will be lost.

1. [Manually disable Swarming](#manually-disabling-swarming-in-the-config-files).

1. Restart all DMAs.

> [!IMPORTANT]
> When you restore the backup, any modifications to existing elements or redundancy groups since the backup and any new elements or redundancy groups created since the backup will be lost. Any reference to these elements could become invalid.

## Restoring elements using an export and import

For small systems, an alternative is to export the latest version of the elements, disable Swarming, and then import the elements again.

1. [Export the elements](xref:Exporting_elements_services_etc_to_a_dmimport_file) you want to save to a .dmimport file.

   Do not include any data from the database in the export. Only the element configuration should be included.

1. [Manually disable Swarming](#manually-disabling-swarming-in-the-config-files).

1. [Import the elements](xref:Importing_elements_services_etc_from_a_dmimport_file) again.

## Manually disabling Swarming in the config files

> [!IMPORTANT]
> This is not advised and can have big consequences for the system. For example, services, redundancy groups, etc. can have references to elements that no longer exist.

1. Shut down all DMAs in the DMS.

1. On every DMA, delete the file `C:\Skyline DataMiner\Swarming.xml`.

1. Restart all DMAs.
