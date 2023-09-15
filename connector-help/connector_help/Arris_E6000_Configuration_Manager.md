---
uid: Connector_help_Arris_E6000_Configuration_Manager
---

# Arris E6000 Configuration Manager

The **Arris E6000 Configuration Manager** is an element manager for Arris E6000 elements.

## About

This connector retrieves all elements using the Arris E6000 connector and allows you to **configure** the selected Arris E6000 elements, **upgrade/commit an image**, and **apply patches** **in** **bulk**. The bulk execution is performed with a maximum number of elements running simultaneously. For example, if **Elements Running Simultaneously** is set to 5 and there are 10 elements in the Selected Devices table, once you start an operation, the execution will be started for 5 elements and put in the queue for the other 5. When the execution finishes for one element, it will start for another element that will be taken from the queue.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

This connector is meant to be used as a DataMiner app with a custom visual overview. By default, the data pages of the element are not shown. The app consists of four tabs, as detailed below.

### Devices

This tab of the app displays two tables, the Available Devices table and the Selected Devices table.

The **Available Devices Table** displays all elements in the system using the **Arris E6000** **production** protocol. It displays the following columns in the same way as they are displayed in the elements themselves:

- Element Name
- Firmware Version
- Backup Config Destination Directory
- Backup Server Credentials
- Backup Server Username
- Backup Server Password
- Restore Config File Directory
- Restore Server Credentials
- Restore Server Username
- Restore Server Password
- Config File
- Firmware Source Directory
- Firmware File Type
- Firmware File Selected
- IP
- DMA Name
- Firmware Operation Status

Each row matches a CMTS, and on each row 3 buttons are available that trigger an operation solely on the matching element. These buttons are:

- **Add**: Adds the element to the Selected Devices table (see below).
- **Refresh**: Refreshes the config files.
- **Refresh**: Refreshes the firmware files.

These operations are explained in detail in the Arris E6000 connector help, in the sections "Backup & Restore Config Page" and "Image Upgrade Page".

The following additional buttons also allow actions on this table:

- **Select All**: Adds all elements to the **Selected Devices** table.
- **Refresh**: Refreshes the CMTS Table with Arris E6000 elements.

The **Selected Devices table** displays all the CMTSs that have been selected from the table above.

With this table, you can perform bulk operations on the available Arris E6000 devices/elements.

The table displays the following information:

- Element Name
- IP
- DMA Name
- Create Backup Config Status
- Restore Config Status
- Firmware Upload & Update Status
- Firmware Operation Status

In each row, a **Remove** button is available that can be used to remove the element from the **Selected Devices table**.

For bulk operations on the elements of this table, several buttons are available that trigger the selected operation for each element in the table:

- **Create Backup Config**
- **Restore Config**
- **Upload Firmware**
- **Update Firmware**
- **Commit Firmware**
- **Apply Patch**
- **Remove All**: Clears the table of all elements.
- **Remove All From Queue**: Removes all the elements waiting to have the current operation executed. Note: Doing this only removes the elements from the queue of the bulk execution. Once the execution has started for an element, it cannot be stopped.

These operations are explained in detail in the Arris E6000 connector help, in the sections "Backup & Restore Config Page" and "Upload & Upgrade Page".

**Current Operation Running** displays the operation that is running at the present moment. This can be Upload Firmware, Update Firmware, Commit, etc. or **None** if no operation is running at the moment.

### Directories

This tab displays different blocks of settings.

The **Table Settings** toggle button determines whether settings are changed for the elements in the two tables (*General*) or just for the elements in the Selected Devices table (*Selected*).

The following parameters make changes to the elements present in the table(s):

- **Backup Config File Destination**
- **Restore Config File Directory**
- **Firmware File Directory**
- **Firmware File Type**
- **Firmware File**

The parameter **Elements Running Simultaneously** indicates the maximum number of elements for which an operation can be executed at the same time. Once the execution of an operation finishes for one element, it will start for the next element in the queue, if any.

The following **SSH settings** must be configured to connect to the file server, in order to retrieve the list of files available on it: **SSH** **Username**, **SSH Password** and **SSH Timeout** (by default 100 ms).

### Directories Credentials

This tab allows you to specify the credentials for the backup and restore configuration file directories.

In case the backup files for the CMTS devices are located in the same folder, you can enter the username/password for this folder under **Set Backup Directory credentials for all devices.** However, if the folder **does not require** any access credentials, the **Backup Server Credentials** toggle button should be set to *Disabled*.

In case the restore files for the CMTS devices are located in the same folder, you can enter the username/password for this folder under **Set Restore Directory credentials for all devices**. However, if this folder **does not require** any access credentials, the **Restore Server Credentials** toggle button should be set to *Disabled*.

### Compare Configuration

On this tab, you can specify two file directories and configuration files in order to compare these files with each other.

When you have specified the directories and selected the files that you want to compare, click the Compare button to start the comparison. The function FixFile will then format the configuration files, combining the configuration lines that have more than one line in a single line. Every configuration line will start with the word "configure".

The comparison of the configuration lines within the files can either result in a match or a mismatch:

- Match: The line is the same in both files.

- Mismatch: Can be one of the following cases:

- Only the last word is different, e.g. "configure interface cable-mac 1 cable dynamic-secret mark" vs "configure interface cable-mac 1 cable dynamic-secret reject".
  - Negated configuration, e.g. "configure interface cable-downstream 12/0/22 cable shutdown" vs "configure interface cable-downstream 12/0/22 cable no shutdown".
  - The line is only found in one of the files.

Some lines can be repeated in both files, e.g. 4 lines repeated in one file and 8 repeated in the other. Only the first 4 lines will be considered matches.

The comparison results will be shown in the **Matching Lines** table. Matches and mismatches will be displayed differently, with the mismatches shown in bold.

## Notes

Although the app only allows one operation at a time, it is advisable to **lock the app** before you use it, in order to avoid conflicts on bulk operations when several users are using the app simultaneously, particularly on device selection and removal from the **Selected Devices** table.
