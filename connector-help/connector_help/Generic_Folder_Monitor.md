---
uid: Connector_help_Generic_Folder_Monitor
---

# Generic Folder Monitor

This connector uses a virtual connection to monitor a directory and its subdirectories.

## About

This virtual connector can check the content of a directory and its subdirectories on a regular basis. It provides details such as the time when the directory was created or last modified. It can also be used to monitor a folder where log files are dumped, for example by having an alarm triggered on the parameter that indicates how long ago the last modification or creation of a file in the directory occurred.

### Version Info

| **Range** | **Description**    | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version    | No                  | Yes                     |
| 1.0.1.x          | Support to Unicode | No                  | Yes                     |

## Installation and configuration

### Creation

This connector uses a **virtual connection** and does not require any input during element creation.

### Configuration

For this connector to work, you need to specify a **Directory Path Name** on the Configuration page. If the directory is on a network share and you do not use a local path name, you also need to specify a **Username** and **Password**.

From **version 1.0.0.3** onwards, the connector supports **SFTP**. In order to connect to SFTP, you need to specify the **SFTP Host** and the **SFTP Port (default: 22)** in the **Directory Path Name**, using the syntax: *sftp://\<host\>:\<port\>/\<url-path\>*.

In **version 1.0.0.4**, the **Connect** button is used to establish the communication to the SFTP server. Note that any change of the **Directory Path Name** will initiate a connection as well. Moreover, from this version onwards, **Renci.SshNet.dll** is deployed as the supported DLL.

From **version 1.0.0.13** onwards, the DLL ProcessAutomation must be available in the system.

## Usage

### Folder Monitor

This page displays the **Folder Table**, which contains all the files that are currently in the folder, along with some details.

- The first column is an auto-incremented **Key**. This was chosen as the key for performance reasons.
- The second column is the **Full Path Name**, but by default the width is set to 0. This is done because this path name contains the Directory Path Name as the prefix, so that this is not useful information for the user.
- The third column is the **Full File Name To Integer**, but by default the width is set to 0. This is done because this data is only informative for debugging purposes. See "Notes" section for more details.
- The key that will be used in alarms is the **Stripped File Name.** This is the Full Path Name without the prefix of the Directory Path Name that was configured on the Configuration Page.
- The **File Extension** is the suffix of the Full Path Name. This parameter is also available for alarm monitoring, so that for example an alarm can be raised if a certain file type is inserted in the directory.
- The **Created On** parameter indicates the date and time when the file was created.
- The **Modified On** parameter indicates the date and time when the file was last modified.
- The **Time Since Creation** parameter displays how much time has passed since this file was created, i.e. "the age of the file".
- The **Time Since Last Modification** parameter displays how much time has passed since this file was last modified, i.e. "the age of the last version of the file".

In addition to this table, this page also contains the parameter **Last Modification Or Creation**, indicating the date and time when a file was last created or modified in the folder. This is the most recent datetime that can be found in the column **Modified On** in the Folder Table.

The parameter **Time Since Last Modification Or Creation** is also available for alarm monitoring.

### Configuration

As mentioned in the "Installation and configuration" section above, the parameters **Location**, **Username** and **Password** must be configured correctly so that the connector can monitor the right folder. In order to connect to an **SFTP Server**, the parameters **Location**, **Username** and **Password** also have to be specified.

In addition, this page contains the **Directory Status**, which indicates whether the connector can access the directory. If the status is *Not OK*, more details can be found in the logging or in the **Summary of Last Check**.

There is also a toggle button to switch off the **monitoring of the folder** and to specify the interval between different checks. The lower the interval, the more frequently the folder check will be executed.

You can also choose to enable **Detailed Logging.** This does not change the functionality of the connector, but provides details about the flow of the connector in the logs of the file. This option should be used for debugging purposes only, and should be disabled in operational environments.

On the right-hand side of the page, the **Last Check** parameter indicates the date and time when the folder check was last executed. In addition, the **Summary of Last Check** details how many files were found, which files are new and which files disappeared compared to the previous check.

## Notes

#### Created On versus Modified On

- **Time/Date Created:** When you create a new file or directory, this value is set and does not normally change (unless you deliberately change it).
- **Time/Date Modified:** This is also called the Last Written date. Whenever the contents of the file are changed, or files are added to or deleted from a directory, this timestamp changes.

**Remarks:**

- Opening a file without making any changes or renaming a file is not seen as a modification in Windows and will therefore not alter the Last Modification Time.

- It is possible to end up with a file that has a modification time that is earlier than its creation time when you make a new copy of a file:

- Copying does not modify the file. The last modification time will stay the same and will be copied from the last modification time of the original file.
  - The creation time will be set to the time when the file was copied, as the file is treated as a new file. You take a hard copy of the file that was "born" at the moment of the copying.

- Moving a file will not change the creation time, as moving a file actually only changes the file name. (The path name is a part of the file name.)

#### Full File Name To Integer

This integer is the result of converting every character of the Full File Name to an integer, concatenating this integer in a string and then converting it back to an integer.

This was done because this integer will be used to check whether a file name was already there during the previous check. If the full file names were used instead, and a full file name contained a special character, the connector would ignore this special character when it saved the Full File Name to the table. In that case, when the check of the folder was done again, and the connector compared the found file names with the ones that were in the table, it would erroneously conclude that this is a new file because the character was ignored. **By converting all characters to integers and storing this here, we make sure that comparing old and new files can also handle special characters, even when these cannot be printed.**

Example:

