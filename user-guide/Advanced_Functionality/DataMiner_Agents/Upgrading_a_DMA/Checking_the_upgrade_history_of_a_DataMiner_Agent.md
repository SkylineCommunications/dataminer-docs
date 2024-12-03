---
uid: Checking_the_upgrade_history_of_a_DataMiner_Agent
---

# Checking the upgrade history of a DataMiner Agent

You can easily check which upgrades have been performed on a particular DataMiner Agent.

## In the C:\\Skyline DataMiner\\Upgrades\\ folder

Go to the *C:\\Skyline DataMiner\\Upgrades\\* folder of the DataMiner Agent and open the file *VersionHistory.txt*. That file lists all the major upgrades that have been performed on that DataMiner Agent, each with the date at which the DataMiner Agent was first started after that particular upgrade.

Example:

```txt
2014-04-22 11:22:52;8.0.6.3-2304-20140407-release
2014-05-09 11:05:10;8.0.7.4-2365-20140508-release
```

In that same *C:\\Skyline DataMiner\\Upgrades\\* folder, you can also find a log file for every upgrade that was performed.

Upgrade log files have a timestamp in their file name:

```txt
update.log.YYYY_MM_DD_HH_MM_SS.txt
```

## In DataMiner Cube

1. Click the user icon in the Cube header and select *About*.

1. In the *About* box, click the *Versions* tab and scroll all the way to the bottom to get to the upgrade history.

Example:

```txt
Upgrade History
---------------
2014-05-09 11:05:10 => 8.0.7.4-2365-20140508-release
2014-04-22 11:22:52 => 8.0.6.3-2304-20140407-release
```
