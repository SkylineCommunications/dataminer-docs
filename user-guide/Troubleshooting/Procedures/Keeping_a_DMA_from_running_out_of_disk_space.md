---
uid: Keeping_a_DMA_from_running_out_of_disk_space
---

# Keeping a DMA from running out of disk space

Below, you can find information on how to free resources in order to ensure hard disk space of a DMA does not run low, as this may affect DataMiner performance.

## Required knowledge

For this procedure, you need to have knowledge of the following:

- Windows disk space management
- TTL settings in DataMiner Cube
- Database commands
- Alarm and trend template configuration

## Total estimated time

Total estimated time of the procedure: approximately 40 minutes, depending on the results of the initial analysis and on the number of protocols on the DMA.

## Procedure

1. As a first step, it is best to check which folders are using up the most disk space. You can do so using a tool such as *WinDirStat* or *TreeSize*.

1. Depending on the results of this initial analysis, you can then make the following adjustments:

    - **Adjusting the TTL settings – 5 minutes**

        Adjust your TTL settings, so that data are removed from the local database more quickly. On a DMA with an SQL local database, changing these settings will have an effect in approximately one hour. However, on a DMA with a Cassandra database, there will be no immediate effect, as it is the TTL at the time a record is created that determines when that record is removed.

    - **Cleaning up the IIS logs – 5 minutes**

        To clean up the IIS logs, you can for instance create a scheduled task to periodically clean up the old logs, using a command like in the following example. This task will run every Sunday and will remove any files in the specified folder that are more than 30 days old.

        ```txt
        at 12:00 /EVERY:Su Forfiles.exe -p C:\WINDOWS\system32\LogFiles\W3SVC1 -m *.log -d -30 -c\"Cmd.exe /C del @path\"
        ```

    - **Checking the upgrade folder – 5 minutes**

        Check the upgrade folder `C:\Skyline DataMiner\Upgrades\Packages`. This folder contains subfolders with the files related to past upgrades. You can remove all subfolders related to upgrades that have been completed already. However, keep in mind that this means you will lose all detailed information on what happened during these upgrades.

    - **Checking the minidump and crashdump folders – 5 minutes**

        Check the `C:\Skyline DataMiner\Logging\MiniDump` and `C:\Skyline DataMiner\Logging\CrashDump` folders, and remove any items that are old enough to be no longer relevant, e.g. anything more than one year old.

    - **Removing old backup files – 5 minutes**

        In the `C:\Skyline DataMiner\Backup` folder, there may be many log files from past backups. Remove the log files that are old enough to be no longer relevant.

        > [!CAUTION]
        > Only remove old .log files. Do not remove anything else in this folder.

        > [!NOTE]
        > As a more permanent solution, you can use a symbolic link for your backups. For more information, see [Taking a backup using a symbolic link to another drive](xref:MOP_Taking_a_backup_using_a_symbolic_link_to_another_drive).

    - **Cleaning up Cassandra snapshots – 10 minutes**

        If you take a backup of a DMA that uses Cassandra, Cassandra takes snapshots of the database, which are then included in the DataMiner backup package. However, the snapshots Cassandra has taken remain on the disk and are not cleaned up automatically. They can eventually take up a lot of disk space. To manage these snapshots, you can use *nodetool*, which is available in the `C:\Program Files\Cassandra\bin\` folder.

        - To check the size of the snapshots, run the following command in a command prompt window:

            ```txt
            nodetool listsnapshots
            ```

        - To clean up the snapshots, run the following command in a command prompt window. This will mark all snapshots as ready for deletion. However, to make sure they are effectively removed, you will then also need to restart the Cassandra service.

            ```txt
            nodetool clearsnapshot
            ```

    - **Cleaning up alarm and trend templates – approx. 2 minutes/protocol**

        In the *Protocols & Templates* app, check if alarm and trend templates can be refined to avoid unnecessarily detailed monitoring or trending:

        - Reduce the number of alarm thresholds defined in the alarm templates, if possible.
        - If a parameter value tends to fluctuate a lot, add hysteresis in the alarm template to avoid frequent and unwanted alarms.
        - If possible, use average trending instead of real-time trending.

    - **Cleaning up DELT packages – approx. 2 minutes**

        Check the DELT directory `C:\Skyline DataMiner\System Cache\DELT`. You will find two folders, *Import* and *Export*. There might be old remnants of DELT packages in these. Remove files older than one day, as these will likely have failed.

    - **Cleaning up of the GenIf folder – approx. 2 minutes**

        When debugging GQI, the GenIf folder may have been enabled but never removed again. This is a [known issue](xref:KI_GenIf_Folder_Growing_In_Size) in DataMiner versions prior to  10.3.0 [CU5]/10.3.8. If your system has a `C:\Skyline DataMiner\Logging\GenIf` folder, you can remove this folder, but only if no active investigations are in progress. **Check with your Skyline contact before removing this folder** to make sure that this is the case.

        > [!NOTE]
        > As of DataMiner version 10.3.0 [CU5]/10.3.8, the size of the `GenIf` folder is automatically limited to a maximum of 100 MB<!-- RN 36642 -->.
