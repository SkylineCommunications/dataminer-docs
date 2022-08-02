---
uid: MOP_Taking_a_backup_using_a_symbolic_link_to_another_drive
---

# Taking a backup using a symbolic link to another drive

The procedure below shows you how to take a DataMiner backup to a drive other than C:\\ by creating a symbolic link to another drive (e.g. D or E).

## Requirements

- Remote access to the server(s).

  - This access can be either through a VPN connection or a host computer, fully or partially dedicated to the execution of this procedure.

- Permission to run CMD commands.

## Procedure

### Check the requirements

#### Prerequisites

- Remote access to the system
- User credentials with administrator rights
- Permission to run the necessary CMD commands to create symbolic folders
- Permission to rename folders

#### Steps

1. Connect to the system via the designated VPN or host PC.
1. Check the drive that you will be using.

### Create a symbolic folder pointing to another drive

#### Prerequisites

- Permission to rename folders
- Permission to create a new folder on the drive that you will be using
- Permission to run CMD commands

#### Steps

1. Check and modify the name of the original folder that DataMiner uses to take backups: `C:\Skyline DataMiner\Backup`. The folder should have a different name (e.g. "backup_old").

1. Copy all the *XML*, *EXE*, *BKS*, *JS* and *DLL* files from the old (original) folder to the new (symbolic) folder. If necessary, you can also copy the *TXT* log files. You should see at least the following files:

   - *BackupSettings.xml*
   - *DataMinerBackup.bks.xml*
   - *DataMinerBackup.js*
   - *DataMinerBackup.bks*
   - *Nest.dll*
   - *Elasticsearch.Net.dll*
   - *TakeBackup.exe*

1. Create a new folder on the drive that you want to use. You could, for example, create a folder named `Temp-Backup` on the E drive.

   - Check whether the new folder has been created.

1. Open a command window and run the following command:

   ```txt
   mklink /J "C:\Skyline DataMiner\Backup" "E:\Temp-Backup"
   ```

   - The following message should appear: `Junction created for C:\Skyline DataMiner\Backup <<===>> E:\Temp-Backup`
   - In `C:\Skyline DataMiner`, you should see a new shortcut to a folder named "Backup".

1. Take the backup and verify that DataMiner is writing to the folder located on the other drive. In the example above, that would be "E".

   - You should see the files in the folder that was created on the other drive.

> [!NOTE]
>
> - Adapt this procedure to match your local drives. In most cases, you will only have to modify the folder on the "other" drive, not the folder that DataMiner uses as a temporary folder (`C:\Skyline DataMiner\Backup`).
> - This procedure can be performed at any time. Nothing will be affected on a production system.

## Time estimate

| Item | Activity | Duration |
|------|----------|----------|
| 1    | Check the local folder structure. | 5 min. |
| 2    | Rename the existing folder, create a new folder, and copy files to the new symbolic folder. | 5 min.  |
| 3    | Run the necessary commands. | 5 min. |
| 4    | Check the results. | 5 min. |
