---
uid: Connector_help_Delec_Oratis_IF_Dante_Card
---

# Delec Oratis IF Dante Card

This connector is used to monitor an **Oratis IF Dante card** (Audio Processor) produced by Delec.

The functionalities of the connector include:

- Polling and monitoring device parameters
- Configuring parameters
- Synchronizing the device file system and rebooting the device - see "General page" section below
- Taking and restoring a full backup - see "General page - Backup" section below
- Polling Rx Flows and Tx Flows using the Dante API

## About

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

The polling IP of the card must be defined during element creation. All other settings are preconfigured and do not need to be changed.

Note that the IP address has to be configured twice: once for the main **serial connection**, and once for the **HTTP connection**.

As from v1.0.0.3, the SLDanteRouting.dll and dante_dnssd.dll need to be available in C:\Skyline DataMiner\Files folder for the communication with the Dante API to work.

## Usage

For most pages in this connector, the content is self-explanatory. For the **General** page and its subpages, however, you can find more information below.

### General page

On this page, you can find status information about the device: **Uptime**, **Temperature** and **Model name**.

The page also contains several buttons in the second column that can be used to perform special actions:

- **Sync FS**: Sends a command to the device to synchronize the file system. It is advisable to do a **Force Repoll** after this.
- **Reboot:** Sends a command to the device to reboot. It is advisable to do a **Force Repoll** after this.
- **FTP Credentials**: Leads to a page where you can set the login username and password required for backup operations. Make sure these parameters have been set before you start a backup or restore.
- **Backup:** Leads to a page with buttons and status information that can be used to take or restore a backup.

The page also contains parameters related to the internal functioning of the connector. These parameters are:

- **Last Response Received:** Indicates the number of seconds that have passed since a response was received from the device.

  As the connector frequently polls the device, the value should never be more then 30 seconds. If the value is more, this indicates a communication problem. If the value is 200 seconds or more, the connector will poll all parameters again once the connection is restored.

- **Force Poll**: Button that can be used to force an update of all parameters. If, for instance, the current values might not be correct or up to date, clicking this button will instantly update all parameters.

  The button can also be used after a reboot or backup/restore. However, if a restore was executed by the connector, all data should automatically be polled again.

### General page - FTP Credentials

This page has only two parameters: **FTP User Name** and **FTP Password**. Taking or restoring a backup is not possible until these parameters have been configured.

### General page - Backup

This page contains a button to take a backup, and a parameter, **Status Backup Creation**, that is used to track the status of a backup. When the status becomes "*Finished,*" a file with the backup data will be available in the documents folder. This file can be found under "*Documents\Delec Oratis *IF Dante Card*\\Element Name\]\Backup\\Time Stamp\].unito.xml*". The time stamp is formatted as "*YYYY-MM-DD_HH-mm".*

The page also contains a parameter that can be used to select an existing backup in order to restore it: **Backup To Restore**. It has a drop-down list with the files found in the backup folder. To restore a file, select it with this parameter, and then click the **Restore** **Backup** button. You can follow the status of the restore operation with the **Status Backup Restoration** parameter.

Finally, you can also use the **Restore Last** button in order to restore the most recent file in the element's backup folder to the device. When you do so, the name of the most recent file will be shown in the **Backup To Restore** parameter.

## Notes

1. The FTP Credentials must be configured before backups will work. If you encounter issues when trying to take a backup, verify these settings first.
1. The backup data will not be visible in the element stream.
1. After a restore or a backup, a "File System Sync" and Reboot command are sent to the device. A Force Poll action is also scheduled to refresh the parameters.
