---
uid: Checking_the_upgrade_history_of_a_DataMiner_Agent
---

# Checking the upgrade history of a DataMiner Agent

You can easily check which upgrades have been performed on a particular DataMiner Agent.

## In the Upgrades folder

Go to the `C:\Skyline DataMiner\Upgrades` folder of the DataMiner Agent and open the file *VersionHistory.txt*. That file lists all the major upgrades that have been performed on that DataMiner Agent, each with the date at which the DataMiner Agent was first started after that particular upgrade.

Example:

```txt
2025-03-25 14:27:23;10.4.0.0-14772-20240821-release
2025-03-27 11:16:35;10.5.4.0-15588-20250319-release
```

In addition, the `C:\Skyline DataMiner\Upgrades\Packages` folder contains a subfolder for each major upgrade that has been performed on the DataMiner Agent. Within each of these folders, the *progress.log* file will contain detailed information about the upgrade.

Note that the *Upgrades* folder itself may also contain *update.log* files, but these are not related to DataMiner upgrades. Instead, these are generated when .dmimport packages are imported on the DMA.

## In DataMiner Cube

1. Click the user icon in the Cube header and select *About*.

1. In the *About* box, click the *Versions* tab and scroll all the way to the bottom to get to the upgrade history.

Example:

```txt
Upgrade History
---------------
2025-03-27 11:16:35 => 10.5.4.0-15588-20250319-release
2025-03-25 14:27:23 => 10.4.0.0-14772-20240821-release
```
