---
uid: Backing_up_a_DataMiner_Agent_using_DataMiner_Taskbar_Utility
description: Learn how to back up a DataMiner Agent with Taskbar Utility, including what to watch out for to ensure a successful restore later.
---

# Backing up a DataMiner Agent using DataMiner Taskbar Utility

> [!IMPORTANT]
> From DataMiner 10.6.9/10.7.0 onwards<!--RN 44352+45704-->, credential secrets are [encrypted at rest](xref:Encryption_in_DataMiner#credentials-at-rest) using per-node encryption keys that are bound to the local machine through the Windows Data Protection API (DPAPI). To ensure these credentials remain recoverable when a backup is restored on a different (virtual) machine, **before you take a backup**, set a **DMS backup password** in DataMiner Cube under *System Center* > *Backup*. If no DMS backup password is configured at backup time, encrypted credentials cannot be recovered when the backup is restored to a different machine.

## Backup procedure

1. In the Windows taskbar, right-click the [DataMiner Taskbar Utility](xref:DataMiner_Taskbar_Utility) icon and click *Maintenance \> Backup*.

1. In the *Backup* dialog box, select the type of backup you want to take.

   - **Full Backup**: Backup containing all data necessary to restore the entire DataMiner Agent (default).
   - **Full Backup without Database**: Similar to the full backup, but does not include the database. If you are using [STaaS](xref:STaaS), you can choose this option, as you do not have to manage the database yourself in that case.
   - **Configuration Backup**: Backup containing all data necessary to restore the configuration of the DataMiner Agent. This also contains parameter values saved in the database, but not alarm or trending data. This backup option does not include DataMiner Files and Logging.
   - **Configuration Backup without Database**: Similar to the configuration backup, but does not include any information from the database. If you are using [STaaS](xref:STaaS), you can choose this option, as you do not have to manage the database yourself in that case.
   - **Visual Configuration Backup**: Backup containing all protocols (including Visio files, WFMs, and the production protocol), all Visio files linked to views, and the contents of the folder `C:\Skyline DataMiner\Webpages`.

1. Click *Create*.

> [!NOTE]
> By default, backup files are placed in `C:\Skyline DataMiner Backups\`. If you want to specify another backup folder, right-click the DataMiner Taskbar Utility icon, click *Options* and specify a different folder in the *General* tab. From DataMiner 10.3.11/10.3.0 [CU8]/10.2.0 [CU20] onwards<!-- RN 37143 -->, the backups for each DataMiner Agent in the DMS will be stored in a dedicated subfolder of this folder. The subfolder will have the DMA ID as its name.

## Credential secret recoverability considerations

From DataMiner 10.6.9/10.7.0 onwards<!--RN 44352+45704-->, the *DMS Backup Password* field must be configured in DataMiner Cube under *System Center* > *Backup* before a backup is taken. As a result, you may encounter the following issues:

- **No DMS backup password configured at backup time**: The backup archive only contains the DPAPI-wrapped *encryptors.bin* file, which is bound to the source machine. When the backup is restored on a different machine, encrypted credentials cannot be recovered.

  To prevent this, always set a DMS backup password in DataMiner Cube under *System Center* > *Backup* **before** taking a backup.

- **DMS backup password lost after the backup was taken**: The passphrase-wrapped envelope (*backup_encryptors.bin*) in the archive can no longer be opened. In a multi-node cluster, a peer DataMiner Agent can resynchronize the encryption material to a restored node, but this should not be relied upon.

  To prevent this, always store the DMS backup password securely outside DataMiner, for example in a password manager.

- **Backup taken before DataMiner 10.6.9 or before the password was set**: The archive contains no encryption envelope. The restore will continue and warn that encrypted secrets cannot be recovered. Take a new backup once the DMS backup password is configured.

> [!TIP]
> See also: [Restoring a DMA using the DataMiner Taskbar Utility](xref:Restoring_a_DMA_using_the_DataMiner_Taskbar_Utility).
