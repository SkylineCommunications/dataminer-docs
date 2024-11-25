---
uid: SwarmingRollback
---

# Partially rolling back Swarming

> [!IMPORTANT]
> There is currently no good way to disable Swarming and keep everything in the DMS intact. The info below only partially recovers some data. If this is a test system and all data can be lost, a clean reinstall is advised.

When Swarming is enabled, the element config XML files (eg `Element.xml`, `ElementData.xml`, `Description.xml`, etc.) are moved from disk to the database. There is currently no procedure to move them back to disk.

There are some things you can do partially recover some data.

## Partial Rollback from backup

When DataMiner is moving the XML files from disk to database, it will take a backup first. This migration happens during first startup after enabling the Swarming feature.

The backup gets initially stored in `Recycle Bin`, but could be manually copied over to a different locationto have long term access.
These .zip files are a snapshot in time at the moment Swarming was enabled.

> [!IMPORTANT]
> **Restoring these means that any modifications to existing elements or redundancy groups and any new elements or redundancy groups are lost.**

Any reference to these elements could become invalid.

There are 2 .zip files you need to restore, one for the elements folder and one for the redundancy folder.
E.g.

`2024_11_20 11_03_12_300_ElementFolder_BeforeSwarmingMigration.zip`

`2024_11_20 11_03_12_300_RedundancyFolder_BeforeSwarmingMigration.zip`

Restoring will go as follows:

1. Shut down all DMAs in the DMS.
1. On every DMA, restore the `C:\Skyline DataMiner\Elements\` and the `C:\Skyline DataMiner\Redundancy\` folder by replacing the folders on disk with the ones in the zip files. This will also restore all redundancy groups (and remove new ones).
1. [Manually disable Swarming](#manually-disabling-swarming-in-the-config-files)
1. Restart all DMAs.

## DELT

For small systems, an alternative is to use DELT to extract the latest version of the elements. You would then export the elements and reimport them once Swarming is disabled.

1. Export the elements you wish to save, don't export any data from database, you only want the element xml files.
1. [Manually disable Swarming](#manually-disabling-swarming-in-the-config-files)
1. Import the elements again, the same element ids must be retained.

## Manually disabling Swarming in the config files

> [!IMPORTANT]
> This is not advised and can have big consequences for the system.
> For example: services, redundancy groups, etc. can have references to elements that no longer exist.

1. Shut down all DMAs in the DMS.
1. On every agent, delete `C:\Skyline DataMiner\Swarming.xml`.
1. Restart all DMAs.
