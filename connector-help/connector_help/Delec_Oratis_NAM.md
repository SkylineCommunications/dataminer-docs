---
uid: Connector_help_Delec_Oratis_NAM
---

# Delec Oratis NAM

This connector is used to monitor an **Oratis Network Attached Monitor** (referred to as NAM) produced by Delec.

There are several versions of the connector. The 1.0.0.x range is used for older firmware versions, while the 1.1.0.x range was created for XML protocol definition v3.00.0001. The more recent version uses commands starting with "DLC" instead of "NAM". The connectors in the different ranges use different syntax and provide different, though similar parameters. There is no backwards compatibility between the connector ranges.

## About

### Version Info

| **Range**            | **Key Features**                            | **Based on** | **System Impact** |
|----------------------|---------------------------------------------|--------------|-------------------|
| 1.0.0.x \[Obsolete\] | Draft range. Obsolete - should not be used. | \-           | \-                |
| 1.1.0.x \[SLC Main\] | Initial version.                            | \-           | \-                |
| 1.2.0.x \[SLC Main\] | Range dedicated to the NAM x03 model.       | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                                                                                |
|-----------|-----------------------------------------------------------------------------------------------------------------------|
| 1.1.0.x   | Supported device types: NAM 201, NAM 202, NAM 601, NAM 602. Dante Firmware: 4.00.002.007 Dante Software: 4.00.004.019 |
| 1.2.0.x   | Supported device types: NAM x03                                                                                       |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.2.0.x   | No                  | Yes                     | \-                    | \-                      |

## Installation and configuration

The polling IP of the device must be defined during element creation. All other settings are preconfigured and do not need to be changed.

From version 1.1.0.2 onwards, a second **HTTP connection** must be configured. Use the same IP address for this connection and make sure the bus address field is set to *bypassproxy*. (This is the default value.)

## Usage

The main goal of the connector is to monitor the data from the NAM. No special actions are required to achieve this. Simply start the element and polling will be started.

However, the connector also provides a few extra functionalities that do require user input or configuration. These actions are explained in detail below, in the relevant page sections.

The functionalities of the connector include:

- Polling and monitoring device parameters.
- Configuring parameters.
- Scheduling tests - see "Test page" section below.
- Synchronizing the device file system and rebooting the device - see "General page" section below.
- Taking and restoring a full backup - see "General page - Backup" section below.

For most pages in this connector, the content is self-explanatory. For the **General** page, its subpages, and the **Test** page, however, you can find more information below.

### General page

This page contains several types of parameters.

A first group of parameters provides information about the device:

- Some parameters provide general information, such as the **Uptime**, **Temperature** and **Model name**.
- Other parameters provide more detailed information, such as the **Amplifier Mode**, **Supply Enable**, **Single Shot Measurement**, etc.

A second group of parameters is related to the internal functioning of the connector. These parameters are:

- **Last Response Received:** Indicates the number of seconds that have passed since a response was received from the device.
  As the connector frequently polls the device, this value should never be more than *30* seconds. If the value is more, this indicates a communication problem.
- **Max Time Allowed Before Timeout:** A user-configurable value that indicates how much time should be allowed after the last response before the element is set in timeout. A reasonable value would be *15* seconds.
- **Force Poll**: Button that can be used to force an update of all parameters. If, for instance, the current values might not be correct or up to date, clicking this button will instantly update all parameters.
  The button can also be used after a reboot or backup/restore. However, if a restore was executed by the connector, all data should automatically be polled again.

A last group of parameters, in the lower right corner, is a set of buttons that provide access to functions or settings requiring explicit user interaction:

- **Sync FS**: Sends a command to the device to synchronize the file system. It is advisable to do a **Force Repoll** after this.
- **Reboot:** Sends a command to the device to reboot. It is advisable to do a **Force Repoll** after this.
- **FTP Credentials:** Leads to a page where you can set the login username and password required for backup operations. Make sure these parameters have been set before you start a backup or restore.
- **Backup:** Leads to a page with buttons and status information that can be used to take or restore a backup.

In range 1.1.0.x, there is another parameter, **Unsaved Config**, that indicates if sets have been sent to the device without saving the config. Below this, the **Save Config** button allows you to write all changes to the disk, and the **Clear Flag** button allows you to set the flag to *No* without saving the parameters. Note that the parameter changes apply the moment the parameter is set, but they will only be "set" in active memory. This means that after a device reboot, the changes will be lost. The value of this flag is not retrieved from the device, but set after any set and cleared when the config is saved (or the flag is explicitly cleared.) The flag will also be cleared when the element is restarted.

### General page - FTP Credentials

This page has only two parameters: **FTP Username** and **FTP Password**. Taking or restoring a backup is not possible until these parameters have been configured.

### General page - Backup

This page contains a button to take a backup, and a parameter, **Status Backup Creation**, that is used to track the status of a backup. When the status becomes "*Finished",* a file with the backup data will be available in the documents folder. This file can be found under "*Documents\Delec Oratis NAM\\Element Name\]\Backup\\Time Stamp\].unito.xml*". The time stamp is formatted as "*YYYY-MM-DD_HH-mm".*

The page also contains a parameter that can be used to select an existing backup in order to restore it: **Backup To Restore**. It has a drop-down list with the files found in the backup folder. To restore a file, select it with this parameter and then click the **Restore** **Backup** button. You can follow the status of the restore operation with the **Status Backup Restoration** parameter.

Finally, you can also use the **Restore Last** button in order to restore the most recent file in the element's backup folder to the device. When you do so, the name of the most recent file will be shown in the **Backup To Restore** parameter.

### Test page

It is possible to schedule tests that are executed at fixed times during the day. When such a test is carried out, a pilot tone is sent to a channel and the output level is monitored. If a certain threshold is reached, the test is considered successful, otherwise it is considered to have failed.

There are limitations to these tests:

- Only one test can be active at a time.
- Each test monitors only one channel.

The following configuration parameters are available:

- **T - Name:** A user-configurable name, which always starts with "*AMP \[index\], CHAN \[index\]*". The name must be unique. If you configure a name that is not unique, the connector will automatically add an additional index number to it. If the channel (**T - Target**) changes, the name will automatically be updated to represent the correct channel and amplifier.

- **T - Target:** This field indicates the channel for which the test will be executed.

- **T - Time:** This field indicates the time when the test should start. Note that it is possible that a test is postponed if another test is still ongoing at the scheduled time.

- **T - Duration:** After the amount of time specified in this parameter, the current value of the targeted channel speaker status will be copied to the **T - Result** field.

- **T - Status:** Indicates the current status of a test. This can be:
  - *Idle*: The test is enabled, but not currently running.
  - *Disabled:* The test is not active.
  - *Running* The test is currently active.
  - *Error:* The test was enabled but has been disabled because it was still running when the element was stopped.

  You can set this field with one of the following values:

- *Disable*: Sets the status to *Disabled.*
  - *Enable*: Sets the status to *Idle.*
  - *Execute Now*: If no other test is running, the test will be executed and afterwards set to *Idle*. Otherwise, nothing will happen.
  - *Delete*: Deletes the line from the table if the test is not running.

- **T - 20 Khz Pilot Level:** The targeted channel's **Speaker Detect 20kHz Pilot Level** will be set to this value when the test starts.

- **T - Threshold:** The targeted channel's **Speaker Detect Threshold** will be set to this value when the test starts.

The following status parameters are available:

- **T - Status:** See "T-Status" above.
- **T - Result:** Contains the targeted channel's **Speaker Status** after a test is completed.
- **T - Last Executed:** Contains a timestamp in UTC time, indicating when the test was last executed.

To add a test, click the **Add Test** button in the lower right corner. This will add a new line in the **Test Table**. Configure the test using the parameters explained above, and then set the **T - Status** field to *Enable* or *Execute Now*.

## Notes

Regarding the **General** page:

- The FTP Credentials must be configured before backups will work. If you encounter issues when trying to take a backup, verify these settings first.
- The backup data will not be visible in the element stream.
- After a restore or a backup, a "File System Sync" and Reboot command are sent to the device. A Force Poll action is also scheduled to refresh the parameters.

Regarding the **Test** page:

- If the element is stopped while a test is active, the test will no longer be executed. Instead, when the element is restarted, the test **T - Status** field will be set to *Error.* (Enable the test again to activate it again.)
- When you change the name of a channel, overwrite the "*AMP X, CHAN Y*" section.
- Since usually this type of test is executed on all channels, it is important to note that this connector only executes a test on the targeted channel and ignores the results of the other channels.
