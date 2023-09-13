---
uid: Connector_help_Telenor_MAT_File_Validator
---

# Telenor MAT File Validator

The **Telenor MAT File Validator** connector consolidates data from multiple servers to a single location. The data consists of **.mat files** and **.dat files** representing Beacon, Signal and Weather Information. The consistency of these files is validated through multiple checks. You can also view requested .mat and .dat files with the connector. Alarm monitoring and trending are enabled for certain parameters, so that it is possible to monitor these or follow their trend information.

## About

The information retrieved by this connector is displayed on different pages. The information and settings displayed on each page are described in the "Usage" section of this document.

### Version Info

This connector does DB queries to the local DataMiner database and is not Cassandra-compliant.

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

## Installation and Timing

### Creation

This connector uses a **virtual** connection and does not require any input during element creation.

However, you should follow the steps below to install the connector:

- Download and install **Scilab** (32-bit version) from http://www.scilab.org/.

  Note: the 64-bit version will not function properly with this connector.

- On every server of the cluster, add the **DotNet-Component-Scilab.dll** to the folder *C:\Skyline DataMiner\ProtocolScripts*.
- Create a new element and select the correct connector and version.

### Configuration

After creating the element, you can set up the connector using the following steps:

- On the **Configuration** page:

  - Fill in the **User**, **Domain** and **Password** required to connect to the remote servers. Make sure that the selected user has the necessary rights to access files on all remote servers.
  - Check that the **Local Workfolder** is set to an accessible path. This folder will be automatically created when data appears.

- On the **Locations** page:

  - Use **Add New Location** to add records to the **Location Mapping** table:

    - Locations must be entered using the UNC path.
    - Make sure the path does not end with a backslash ("\\).
    - Locations must end with a folder named "Signal", "Beacon", "TB" or "WXT" (used to indicate the type of data).
    - The same location cannot be added twice. If this is attempted anyway, a notification will appear.
    - E.g. [\\192.168.0.2\c\$\RemoteServerRootFolder\Signal](file://///192.168.0.2/c$/RemoteServerRootFolder/Signal).

  - Polling is by default *Disabled*. Use the button **Enable All** to start polling, or use the button **Resync All Locations** to manually request a resync.

  - Note: No files are ever deleted by the connector. Deletion and cleanup of files must be done manually by the user.

Important note: Make sure the **Local Workfolder** is **empty** of all other folders except the ones created by the connector. The file-checking algorithm will select the last X files from the entire root folder, so if the Local Workfolder contains other folders, files from a 'non-aggregated' folder could be included.

## Usage

### Configuration page

The right-hand side of the page contains the logon information for remote servers. The left-hand side contains the configuration parameters for the different file validity checks. The validity checks are arranged according to file type: Signal, Beacon, TB and WXT.

Four page buttons are available on this page that can be used to set up thresholds for the internal data checks. The page buttons lead to tables that indicate the custom name, minimum value and maximum value for a specific column of the data file for a specific type.

Note: The **Row Check Amount** is the number of rows inside each data file for which the validity will be checked. Increasing this number increases the likelihood that issues are discovered; however, this is at the cost of additional processing power.

### Locations page

This page contains the **Location Mapping** table. This table indicates all the remote folder locations that are being monitored. The polling time for each folder can be adjusted and polling can be enabled and disabled.

- The **Health Check** column in the table uses the adjustable **Max Healthy Time** to monitor if new files are created within the indicated time frame.

- The **Location Validity** column indicates if the entered network location exists and is available.

- The **Sync Threshold** indicates from which date the connector should begin syncing the files. All files that have their **Last Edit Date** set to lower than this threshold will be ignored.

  - To enter a date, use the following format: *yyyy.MM.dd*. E.g. "*2014.01.17*" indicates that all files from this folder are to be copied when their last edit date is larger than or equal to the 17th of January, 2014.
  - Adding a new location will set the **Threshold Date** to the current date by default.
  - When you leave the **Sync Threshold** blank, this indicates that a Full Sync of all files should occur.

### File Table page

The **File Table** provides the user with a configurable number of records indicating specific data files in chronological order.

- The **File Status** column contains the **Validity Status** after performing all checks. The possible values for **File Status** are:

  - Not Checked: Indicates that the file still needs to be checked.
  - Checked - OK: All checks have been successfully passed and the file is healthy.
  - Checked - NOK: Bad File Size - Check failed against the File Size parameter.
  - Checked - NOK: Insufficient Values - Check failed against the Low Row Number Limit.
  - Checked - NOK: Threshold Violated - A cell in the file has violated a set value range from the Threshold page buttons.
  - Checked - NOK: Bad File Type - The file is located in an incorrect folder (used to indicate Type), indicating that the configuration of the **Locations** page is incorrect.
  - Checked - NOK: Bad File Extension - An incorrect file extension is used. The only allowed extensions are .mat and .dat.
  - MASKED - Alarm Masked: Alarm is masked, no further checks will be done until the alarm is unmasked or a 'Force Full Recheck' is called.
  - Checking ERROR - See Element Log: An exception has occurred in the code to process this file, please check the element log and provide Skyline Communications with a copy of this log and the file in question for debugging.

    Only one error will be visible at a time. The checking hierarchy is as follows:

    - Check 1: File Extension test.
    - Check 2: File Type test.
    - Check 3: File Size test.
    - Check 4: Value Count / Row Count check.
    - Check 5: Threshold Checks (stops at the first error).

- The **Additional Info** column displays detailed information about the first point of failure in a specific file.
- The **Configure View Page** button automatically fills in the file path and if necessary the range 10 below and 10 above a threshold violation on the **View Files** page. Click **Read** on the View Files to access the correct information. A **Masking** column was added, enabling the user to mask or unmask an alarm.

### View Files page

This page can be used to access and open any of the .mat or .dat files. **View Range** can be left blank and will be set to show 200 rows by default. Using the format "min-max", you can fill in a minimum and maximum value to create the window you want.

### Copy Progress Monitor Page

This page indicates how many files are still waiting to be copied, how many files from the current buffer have been copied, and an overall progress bar.

There is also a **Max Copy Chunk Size** parameter, which indicates how many copies are attempted at the same time. This size is self-regulating, and as such does not require any manual changes. If chunks are taking too long to copy, the max size will be lowered, and if chunks are copied too quickly for the OS to handle the network connections, the chunk size is increased.

Most of the time, these parameters will not show much (as usually only 10 new files are detected every 15 minutes). However, they are useful when a large number of new files are suddenly detected or have to be transferred.
