---
uid: Connector_help_Arris_E6000
---

# Arris E6000

The **Arris E6000 CER** is a next-generation Converged Cable Access Platform (**CCAP**). Range **1.0.0.x** of this connector polls data from the device using **SNMPv3** and uses a serial connection (**SSH**) to create backups of running configurations, to execute scripts, and to upgrade the firmware and patch images. The connector supports traps for alarm and notification monitoring. Range **2.0.0.x** of this connector only uses **SNMPv2** to poll data from the device, while range **2.0.1.x** uses **SNMPv3**.

## About

Range **1.0.0.x** of this connector monitors the device using SNMPv3. Two SNMPv3 connections are used: the first connection is used for SNMPv3 polling, the second is used to receive traps. An additional serial connection (SSH) allows you to execute CLI commands on the device, such as the creation of a backup of the running configuration.

Range **2.0.0.x** of the connector only uses one SNMPv2 connection to monitor the device.

Range **2.0.1.x** of the connector only uses one SNMPv3 connection to monitor the device.

### Version Info

| **Range**            | **Description**                  | **DCF Integration** | **Cassandra Compliant** |
|----------------------|----------------------------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version.                 | No                  | Yes                     |
| 2.0.0.x              | Supports a new firmware version. | No                  | Yes                     |
| 2.0.1.x              | Based on 2.0.0.3. Uses SNMPv3.   | No                  | Yes                     |
| 3.0.0.x              | Customer-specific version.       | No                  | Yes                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | CER_V04.05.00.0015     |
| 2.0.0.x   | CER_V04.05.00.0015     |
| 2.0.1.x   | CER_V04.05.00.0015     |
| 3.0.0.x   | CER_V04.00.00.0318     |

## Configuration

### Connections (Range 1.0.0.x)

This connector uses two Simple Network Management Protocol version 3 (**SNMPv3**) connections, as well as a **serial** connection (for SSH communication), and requires the following input during element creation:

#### SNMP main connection:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *192.168.10.2*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Security level and protocol**: Selection indicating whether authentication and privacy have been enabled.
- **User name**: The SNMPv3 username as configured on the Arris E6000 device.
- **Authentication password**: The SNMPv3 authentication password as configured on the Arris E6000 device.
- **Encryption password**: The SNMPv3 encryption password as configured on the Arris E6000 device.
- **Authentication algorithm**: The SNMPv3 authentication algorithm as configured on the Arris E6000 device, e.g. *HMAC-MD5*.
- **Encryption algorithm**: The SNMPv3 encryption algorithm as configured on the Arris E6000 device, e.g. *DES*.

#### SNMP traps connection:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *192.168.10.2.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Security level and protocol**: Selection indicating whether authentication and privacy have been enabled.
- **User name**: The SNMPv3 username as configured on the Arris E6000 device.
- **Authentication password**: The SNMPv3 authentication password as configured on the Arris E6000 device.
- **Encryption password**: The SNMPv3 encryption password as configured on the Arris E6000 device.
- **Authentication algorithm**: The SNMPv3 authentication algorithm as configured on the Arris E6000 device, e.g. *HMAC-MD5*.
- **Encryption algorithm**: The SNMPv3 encryption algorithm as configured on the Arris E6000 device, e.g. *DES*.

#### Serial connection:

- **IP address/host**: The IP address of the device, e.g. *192.168.10.2.*
- **IP port**: The port of the connected device, by default *22*.

### Creation (Range 2.0.0.x)

This connector uses a Simple Network Management Protocol version 2 (**SNMPv2**) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *192.168.10.2.*

SNMP Settings:

- **IP port**: The IP port of the device, by default *161.*
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Creation (Range 2.0.1.x)

This connector uses a Simple Network Management Protocol version 3 (**SNMPv3**) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *192.168.10.2.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Security level and protocol:** Selection indicating whether authentication and privacy have been enabled.
- **User name:** The SNMPv3 username as configured on the Arris E6000 device.
- **Authentication password**: The SNMPv3 authentication password as configured on the Arris E6000 device.
- **Encryption password**: The SNMPv3 encryption password as configured on the Arris E6000 device.
- **Authentication algorithm**: The SNMPv3 authentication algorithm as configured on the Arris E6000 device, e.g. *HMAC-MD5*.
- **Encryption algorithm**: The SNMPv3 encryption algorithm as configured on the Arris E6000 device, e.g. *DES*.

### Creation (Range 3.0.0.x)

This connector uses a Simple Network Management Protocol version 2 (**SNMPv2**) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *192.168.10.2.*

SNMP Settings:

- **IP port**: The IP port of the device, by default *161.*
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage (Range 1.0.0.x)

### General Page

This page contains general information about the device. It displays the **System Description**, **System Name**, **System Location**, and **System Contact**.

The button **Refresh Data** allows you to manually force a repoll of the data. In order to prevent excessive polling of the device, this operation is only allowed once every 30 minutes. The parameters **Last Manual Refresh Date Time** and **Last Refresh Operated By** indicate the last date and time a manual refresh was performed and who performed this refresh, respectively.

On the right-hand side of this page, several page buttons are displayed, which display the following information:

- **Disk Volume**: Displays theDisk Volume Table, which shows the Volume Name, Volume Size, Volume Usage, and Disk Capacity of each disk on the device.
- **PEM Status**: Contains information about the Power Entry Module (PEM). The chassis contains two redundant PEMs, which are monitored in the PEM Status table. The **PEM Status Table** monitors the overall LED status, feed presence, voltage, and current, and indicates whether breakers are enabled. Power distribution within the PEM is divided into 9 power branch circuits: A to I. This is indicated in the **PEM Branch Status Table**.
- **Fan Status**: Provides an overview of the status of the device fans. The chassis contains 3 fan trays, each containing three fans. (The fans are numbered 0, 1, 2 from the front view, left to right.) The **Fan Status Table** indicates the speed of the fans for each fan tray, the last measured speed level of the fans, and the ambient temperature.
- **Firmware Version**: Displays the hardware version, software version, and software uptime for slots on the device.
- **Linecard Status**: Displays a table with the status of the linecards on the Arris E6000 device. The table contains status parameters, the serial number, the hardware version, and the type.
- **Transceivers**: Displays a table with the status of the transceivers per slot and port.
- **PIC Table**: Displays a table that shows the link between a PIC (connector) and RF segment (ifAlias). Aside from the PIC and alias, it also shows the PIC MAC Index. The **Port Information** page button displays the indexes, consisting of the Card ID and Port ID, the PortConnector ID, and the MAC Interface Index.
- **Login**: Here you can provide the credentials (**User Name** and **Password**) used for SSH communication with the Arris E6000 device. The **Connection Status** parameter indicates the status of the connection. When you set the credentials, **Connection Status** is set to *Unknown*. When a CLI command is sent and succeeds, **Connection Status** is set to *Connected*. When the SSH connection could not be set up and a timeout occurs (e.g. because of invalid credentials), **Connection Status** is set to *Session Timeout*.

### Interfaces Page

The interfaces page contains an overview of the interfaces of the Arris E6000 device. The parameter **Number of Interfaces** shows the number of interfaces of the device. The **Interface Table** shows information for each interface, such as the description, the alias, the interface type, MTU, the interface speed, the physical address, status information, information about errors and discarded packets, and interface utilization.

The **Interface Entry** page button allows you to visualize more information about the interfaces in the **Interface Entry Table**. This table contains information about packets that have been sent or received through an interface. Link up/down traps for the interface can be enabled/disabled via the **Link Up Down Trap Enable** parameter.

Note**:**

- The interface utilization (Utilization In and Utilization Out) can be calculated from the Interfaces MIB tables, used from the Card Utilization Hidden Table (OID: 1.3.6.1.4.1.4998.1.1.10.2.23), or taken from the CLI with the command "show interface utilization". The parameter **Card Utilization Source** allows you to select which of these options should be used.
- The displayed interface speeds (Bandwidth) are based on the ifTable and the ifxTable. By default, the speed from the ifTable is used, unless its value is equal to 2^32 (4,294,967,295), in which case the speed from the ifxTable (ifHighSpeed) is used instead.

### Cards Page

This page shows information about the cards present on the Arris E6000 device. The **Card Table** contains information about each card on the device, such as status information, port count, detected type, the uptime of the card, and the last reset reason.

The **Card Data** page button allows you to retrieve more details about each card, such as the serial number, firmware version, software version, manufacturer, and product name.

### Alarms & Notifications Page

This page provides an overview of notifications and alarms received from the Arris E6000 device.

A distinction is made between alarms and notifications. When the device sends an alarm trap, the device is expected to send another related trap to acknowledge that the alarm has been cleared. Notifications, however, are considered to be just informational, so the device will not send any subsequent traps related to a notification. The connector contains two types of tables related to alarms and notifications.

The notifications tables (**Notifications Table** and **Generic Notifications** **Table**) contain notifications and the **Alarms Table** contains alarms.

With the **Auto Clear** page button, the number of notifications that should be stored in a notification table (Notifications Table and Generic Notifications Table) can be configured. A maximum duration (**Notification Max Duration**) can be set as a number of days. Notifications that are older than the set number of days will automatically be removed from the table. In addition, the maximum number of notifications that the notification table should contain can be set through the **Notification Max Number**parameter. Once the table contains more notifications than the specified number, the oldest notifications will automatically be removed from the table. The parameter **Notification Count** shows the number of notifications present in the table.

You can remove individual notifications from the table with the **Delete** button in the corresponding row. For each notification, the table provides the following information (when available): the timestamp, description, severity, OID, and event ID.

The **Alarms Table** contains entries for alarms. When a new alarm is received (e.g. card overload alarm), a new row is added to the table. Any subsequent alarms that are related to this alarm will update the row in the table. When a trap is received that indicates that the alarm is cleared, the row is removed from the table. An individual row can be deleted with the **Delete** button displayed in the row. As the expected number of entries in this table is small, the table has no auto-clearing configuration options.

Note that some traps will not appear in the table but will immediately update the corresponding value in the table.

The following table provides an overview of the traps that are processed by the connector. The "Type" column indicates whether the trap is shown in a notification table (type Notification), is shown in an alarm table (type Alarm), or updates a parameter in another table (type Table Update). In the latter case, the name of the table and the parameters that are updated are shown in the columns "Table" and "Updated Columns", respectively.

| **Trap OID**                   | **Trap Name**                           | **Type**     | **Table**                   | **Updated Columns**                                    |
|--------------------------------|-----------------------------------------|--------------|-----------------------------|--------------------------------------------------------|
| 1.3.6.1.4.1.4998.1.1.5.3.0.1   | cardOverload                            | Alarm        | Alarms Table                |                                                        |
| 1.3.6.1.4.1.4998.1.1.5.3.0.2   | sysOverload                             | Alarm        | Alarms Table                |                                                        |
| 1.3.6.1.4.1.4998.1.1.6.1.1.0.1 | aaaServerUnreachableTrap                | Notification | Notifications Table         |                                                        |
| 1.3.6.1.4.1.4998.1.1.6.1.1.0.2 | aaaServerGroupUnreachableTrap           | Notification | Notifications Table         |                                                        |
| 1.3.6.1.4.1.4998.1.1.6.1.1.0.3 | aaaServerAuthFailTrap                   | Notification | Notifications Table         |                                                        |
| 1.3.6.1.4.1.4998.1.1.6.1.1.0.4 | secuLocalAuthFailTrap                   | Notification | Notifications Table         |                                                        |
| 1.3.6.1.4.1.4998.1.1.6.1.1.0.5 | secuLineAuthFailTrap                    | Notification | Notifications Table         |                                                        |
| 1.3.6.1.4.1.4998.1.1.6.1.1.0.7 | cadIpdrNoPrimaryCollector               | Notification | Notifications Table         |                                                        |
| 1.3.6.1.4.1.4998.1.1.6.1.1.0.8 | cadIpdrStreamingDisabled                | Notification | Notifications Table         |                                                        |
| 1.3.6.1.4.1.4998.1.1.6.1.1.0.9 | cadIpdrReportCycleMissed                | Notification | Notifications Table         |                                                        |
| 1.3.6.1.4.1.4998.1.1.10.1.0.19 | cardTempOutOfRangeNotification          | Notification | Notifications Table         |                                                        |
| 1.3.6.1.4.1.4998.1.1.10.1.0.20 | cardTempNoReportNotification            | Notification | Notifications Table         |                                                        |
| 1.3.6.1.4.1.4998.1.1.10.1.0.21 | cardTempOverHeatNotification            | Notification | Notifications Table         |                                                        |
| 1.3.6.1.4.1.4998.1.1.10.1.0.24 | noLicenseNotification                   | Notification | Notifications Table         |                                                        |
| 1.3.6.1.4.1.4998.1.1.10.1.0.25 | cerCardPrStateChange                    | Table Update | Card Table                  | Card Primary State                                     |
| 1.3.6.1.4.1.4998.1.1.10.1.0.26 | cerCardSecStateChange                   | Table Update | Card Table                  | Card Secondary State                                   |
| 1.3.6.1.4.1.4998.1.1.10.1.0.27 | cerCardDetectedChange                   | Table Update | Card Table                  | Card Detected, Card Sub Detected                       |
| 1.3.6.1.4.1.4998.1.1.10.1.0.28 | cerCardDplxStatusChange                 | Table Update | Card Table                  | Card Duplexing Status,Card Detected, Card Sub Detected |
| 1.3.6.1.4.1.4998.1.1.10.1.0.29 | cerPortPrStateChange                    | Alarm        | Alarms Table                |                                                        |
| 1.3.6.1.4.1.4998.1.1.10.1.0.30 | cerPortSecStateChange                   | Alarm        | Alarms Table                |                                                        |
| 1.3.6.1.4.1.4998.1.1.10.1.0.35 | cerDiskVolumeUsageNotification          | Alarm        | Alarms Table                |                                                        |
| 1.3.6.1.4.1.4998.1.1.10.1.0.36 | cerDiskVolumeAutoDeleteFileNotification | Notification | Notifications Table         |                                                        |
| 1.3.6.1.4.1.4998.1.1.100.1.0.1 | cadCmtsExportNotification               | Notification | Notifications Table         |                                                        |
| 1.3.6.1.4.1.4998.1.1.100.1.0.2 | cadCmtsImportNotification               | Notification | Notifications Table         |                                                        |
| 1.3.6.1.6.3.1.1.5.1            | coldStart                               | Notification | Generic Notifications Table |                                                        |
| 1.3.6.1.6.3.1.1.5.3            | linkDown                                | Table Update | Interface Table             | Admin Status, Operational Status                       |
| 1.3.6.1.6.3.1.1.5.4            | linkUp                                  | Table Update | Interface Table             | Admin Status, Operational Status                       |
| 1.3.6.1.6.3.1.1.5.5            | authenticationFailure                   | Notification | Generic Notifications Table |                                                        |

### Backup & Restore Config Page

This page consists of a Backup and a Restore section.

#### Backup

This section allows you to create a backup of the running configuration. To do so:

1.  First provide a folder where the running configuration will be transferred after it has been created on the device.
2.  Click the **Create Backup** button to trigger the creation of a backup file for the running configuration on the Arris E6000 device (in the directory "/system/cfgfiles/").

The name of the backup file has the following format: "ELEMENTNAME_YYYYMMDD_HHMMSS.cfg". Once a backup file has been created, the connector will check for the presence of old configuration files on the device (i.e. files that were created more than 48 hours before the new .cfg file was created). If such files are found, the connector will delete them. Note that an element will only manage the backup files that start with the name of that element (i.e. backup files that start with ELEMENTNAME\_, where ELEMENTNAME is the name of the element).

Note: It is advisable to limit the number of backup files to manage in the device.

#### Restore

The restore procedure mainly consists of manual steps. These are listed when you click the **Restore** button. The **Source Directory** parameter points to a directory containing the source file that will be uploaded to the Arris E6000 device. After you select a directory, the dropdown box for the **Config File Name** parameter will be populated with files that have the extension ".cfg". After you select a configuration file, you can click the **Restore** button to upload the configuration file to the device. This operation will transfer the configuration file via SFTP to the directories "/system/cfgfiles/" and "/clone/system/cfgfiles/". After the configuration file has been uploaded, you should then perform the following remaining manual steps to complete the restore procedure:

1.  Erase the startup configuration. The erase nvram must be performed before the reload of a configuration file to clear the contents of the current configuration loaded on the E6000.
2.  Reset the current system configuration. The following command will force the E6000 to reset its configuration and lose access using SSH. After this command, access will only be available using serial communication. configure reset system After this command is executed, the system will reset the configuration and RSM cards will be started up. This process will take 5 minutes. After the wait time, you should be able to log back in using the serial connection.
3.  Verify the primary RSM card. Once the system has been reset, it is possible for any of the two RSM cards in the chassis to become the primary port. To differentiate Primary from Standby, you can use the command prompt to differentiate the two cards.
4.  Execute the file (backup) copy into the running configuration. After copying the configuration file from the SFTP server, use the following command:exc file /system/cfgfiles/backup_filename.cfg This will load the new configuration into the E6000.
5.  Save the running configuration to the startup configuration file. After starting up the new configuration, save the new configuration to the startup configuration by typing the following command:write mem

### Upload & Upgrade File Page

This page allows you to upload and upgrade a file in the Arris E6000 device. It contains parameters necessary to make an SSH connection to the file server and to upload a file from this to the Arris E6000, via SFTP.

Ideally, you should configure the SSH connection, specifically the **File Server Username** and **File Server Password**, before you specify the File Remote Source Directory and File Type.

To perform a file **upload**:

1.  Specify the **File Remote Source Directory** containing the directory path with the file that will be uploaded to the Arris E6000 device.
2.  Select the **File Type**: *Image*, *Patch* or *Other*.
3.  Select the **File** and click the **Upload** button.

To perform an image **upgrade**/**commit** or **apply a patch**:

1.  Make sure the file has been uploaded on the Arris E6000.

2.  Click the Upgrade and Commit or Apply Patch buttons:

3.  - The Upgrade button is required to upgrade the image. Only after the upgrade is completed, it will be possible to commit it.
    - It is not possible to select a patch file and use Upgrade and Commit, as well as select an image file and use Apply Patch. If you do so, the Progress Status parameter will show an error.

The **Refresh** button allows you to refresh the list of files in the dropdown list for the File parameter.

The **Progress Status** will display various types of status corresponding to the current operation: *Complete*, *Fail*, *Error*, *Timeout*, *File not selected*, etc.

The **Progress Bar** shows an overview in **percentage of the progress**. Except for the upload file operation, this progress bar is shown **as steps**. For example, if the image upgrade needs 4 steps to be completed, each step is 25%.

Other parameters:

- **File Server Remote Platform**: **Linux (via SSH)** / **Windows**: This parameter needs to correspond with the server platform.
- **File Location: Remote/Local**: This parameter allows you to access the **file server** (remote) or the **Arris E6000** itself (local). It can be used for cases where the file is present on the Arris E6000 and no longer exists on the file server. Please note that is not possible to use Upload if File Location is set to *Local*.
- **Commit Image Timeout**: The timeout time during the commit image operation.
- **Image Upgrade Reconnection Try Interval**: After the image upgrade, the device reboots. This parameter allows you to customize the reconnection try interval (in minutes) after the reboot. After the third retry, a **Timeout Error** is returned.
- **Apply Hitless Reconnection Try Interval**: The Arris E6000 reboots during the patch Apply Hitless. This parameter allows you to customize the reconnection try interval (in minutes) after this. After the third retry, a **Timeout Error** is returned.

Note: During the operations, SNMP polling will automatically be disabled.

### Script Execution Page

This page allows you to execute a script or configuration file on the Arris E6000 device. The **Script Directory** parameter refers to the directory containing the script that will be uploaded to the Arris E6000 device. After you have selected a directory, the dropdown box for the **Script File Name** parameter contains all files with extension ".cfg" in that directory. You can then select the desired script from this dropdown box.

When you click the **Execute** button, the selected file will be transferred to the Arris E6000 device via SFTP and will be executed.

Note: It is important that you set the **Script Expected Duration** parameter to a value that will exceed the real execution duration of the script. Otherwise, the connector will not be able to retrieve the final response of the device.

If all commands in the script were successful, the **Script Execution Status** will be set to *"Success*". If errors occurred, the status will be set to "*Errors Occurred*", and the error log file will be obtained from the Arris E6000 device. The content of this file will then be shown in the error log, which you can view via the **Error Log** page button.

After a script has been executed, the script will automatically be deleted from the Arris E6000 device, along with the error files (".err") when errors occurred.

#### New Script

The connector also allows you to create a new script. To do so, click the **New Script** page button. This will open a new page where commands can be added (one by one) to a new script via the **Add Command** parameter. In order to remove the last added command, click the **Clear Last** button. To clear all the commands, click the **Clear All** button. The **New Script File Name** parameter allows you to set the file name of the new script.

Note: The script file name should end in ".cfg". Otherwise, the **Script Status** parameter will be set to "*Invalid File Name*" and it will not be possible to create the script.

After the commands have been added and the file name has been set, click the **Save** button to create the script. The script will be saved in the directory that has been selected on the **Script Execution** page (**Script Directory** parameter).

### Licensing Page

This page contains the **Chassis Serial Number**, **Chassis Based Licensing Table**, and **Slot Based Licensing Table**. Click the **Refresh** button to update the content of the tables.

The following page buttons are also available:

- **Apply License - Slot Based**: Allows you to configure/apply a slot-based license. To do so, enter the parameters License Type, Slot Number, License Key, and Channel Count, and click Apply. The **Apply License Status** will indicate whether the operation succeeded or failed.
- **Apply License - Chassis Based**: Allows you to configure/apply a chassis-based license. To do so, enter the parameters License Type, DOCSIS Type, License Key, Channel Count, and Spare Channel Count, and click Apply. The **Apply License Status** will indicate whether the operation succeeded or failed.
- **Chassis Based Per Slot Licensing**: Displays the Chassis Based Per Slot Licensing Table.

## Usage (Range 2.0.0.x and 2.0.1.x)

### General Page

This page contains general information about the device. Via page buttons, you can access more information, in the CPU Table and Memory Table.

### Interfaces Page

This page contains information on the interfaces of the Arris E6000 device.

The **Interface Table** shows information for each interface, such as the Description, Type, MTU, Speed, Physical Address, status information, information about errors and discarded packets, and interface utilization.

The page shows the **Number of Displayed Interfaces** based on how many interfaces are currently being displayed in the table.

The **Interface Selection** page button displays the Interface Selection Table, which controls which interfaces are displayed in the Interface Table:

- You can use the **Description Filter** and **Type Filter** parameters to filter the interfaces and enable or disable interfaces being displayed.
- In the **Interface Selection Table**, you can use the toggle button in the **Displayed** column to indicate whether an entry in the table should be enabled or disabled.
- You can also select interfaces/rows and enable/disable using the right-click menu of the table.

### QAM Interfaces Page (only in 2.0.0.x)

This page contains the **Video Downstream Channels** table, with information about the characteristics of the channels, such as the frequency, the used modulation and the power (in dBm).

This page only contains the interfaces selected on the **Interface Selection** subpage of the Interfaces page.

### Video QAM Interfaces Page (only in 2.0.1.x)

This page contains the **Video Downstream Channels** table, with information about the characteristics of the channels, such as the frequency, the used modulation and the power (in dBm).

### NonVideo QAM Interfaces Page (only in 2.0.1.x)

This page is very similar to the **Video QAM Interfaces** page, except that the table only contains channels of **non-video QAMs**.

### Physical Interfaces Page

This page displays card status information in the **Card Status** table. This table allows you to configure the Card Name, contains information about the Type and Sub Type of each card, displays Card Temperature information, allows you to configure the administrator status, and also contains information about the primary state of the card (Pr State), which can be *In Service (IS)* or *Out Of Service (OOS)*.

### Service Groups Page

This page contains a table with information about the Connectors, Slots, Bit Rates and Maximum Bandwidth for each service group. The Total Programs count and Current Programs count columns are added to the table in version 2.0.0.9 of the connector.

### Virtual Edge Page

This page displays information about the virtual edges present on the Arris E6000 device. The **Virtual Edge** table contains information about each virtual edge, such as the Admin Status, the Operational Status, and packet counters for Dropped Packets, Blocked Packets, and Fragmented Packets. It also includes information regarding the bit rates, the total maximum bandwidth per virtual edge, and the corresponding usage percentage (Bit Rate, Total Max Bandwidth, and Utilization, respectively).

Several page buttons are available at the bottom of the page:

- **UDP Ports**: Displays information regarding the UDP ports through a mapping table (VE UDP Ports Mapping) of the virtual edges. Also displays an additional mapping table (VE UDP Blocked Port Mapping) with the IP addresses of the virtual edges (VE IP Addr) and the highest and lowest port numbers, representing the range of UDP ports to be blocked.
- **Input Ports**: Displays a table with basic input port mapping information, such as the input port number used by the ERM (ERM Input Port), the data plane address for the Virtual Edge (VE IP Addr), and the IP address type (IP Addr Type).
- **Bandwidth**: Displays a table that shows the bandwidth of the NSI links belonging to each virtual edge (to report to an ERM).

### RF Ports Page

This page contains the RF Port Table, which displays a counter for interfaces that are down, as well as the administrator status per RF port. Like previous tables, this table displays bit rates, the total maximum bandwidth, and the usage percentage per RF port (Bit Rate, Total Max Bandwidth, and Utilization). The table also displays information regarding the number of DTV subscribers and contains a column where you can set a customizable description for the RF port (Custom Description). The Total Programs and Current Programs count columns are added to the table in version 2.0.0.9 of the connector.

### UDP IP Streams Page

This page contains the UDP IP Streams table, which displays the current incoming transport streams that are to be forwarded to an active QAM channel. Entries of this table contain a reference to the QAM Channel Name, information on the Stream Status, the ID of the Video Streams, and a UDP Packet Counter.

Note that this table is not polled using a timer. To poll the table, click the **Poll UPD IP Table** button.

### QAM Streams Page

This page contains two tables, the QAM Streams table and the QAM Streams Status table, which both use the QAM Channel Name as an identifier.

- The **QAM Streams** table contains information regarding the MPEG transport stream identifier (MPEG TS ID), the index of the outgoing transport stream (Out TS ID), the retransmission interval for PAT and PMT tables (PAT Interval and PMT Interval), the associated service groups and virtual edges of each QAM Channel (Service Group Name and VE Name), etc. This table also contains four columns that are filled in by another element: HFC-Segment, QAM VOD Cluster, DTV Subscribers, and HFC-Segment Group.
- The **QAM Streams Status** table contains information regarding the total number of unique PAT tables that have been generated per QAM channel (Total PATs Tx), as well as the current, the maximum, and the total number of programs transmitted (Current Programs Tx, Peak Programs Tx, and Total Programs Tx). Information related to the requested and the peak bandwidth is also displayed.

### CAS Page

This page contains the following tables:

- The **ECMG Streams** table, with all the ECMG streams per ECMG channel.
- The **ECMG Channels** table, with all the ECMG TCP connections, the administrator status, the address type (Addr Type), and the ECMG remote address (Remote IP Addr).
- The **ECMG Channel Status** table, with operational state information and several counters for in and out messages.

A **Channel ID Count** page button displays the number of Channel IDs currently present in the ECMG Streams Table.

### EIS Page

This page contains the following tables:

- The **SCS Connections** table, which specifies the server address to be used by an EIS to be able to communicate with a virtual edge.
- The **SuperCas** table, which describes all the ECMG vendors.
- The **EIS SCSs Stats** table, which specifies the statistics for an EIS TCP connection for a virtual edge.
- The **EIS Specifications** table, which specifies common characteristics of an EIS.
- The **ERM Ports Mapping** table, which maps the ERM output port numbers of the QAM interfaces that come from session-based virtual edges.

### Video Streams Page

This page contains the following tables:

- The **Video Streams** table, which stores basic information on all transport streams of the Arris E6000 device.
- The **Video Streams Programs** table, which stores basic information per program in each transport stream known to the device.

Note that the Video Streams Programs table is not polled using a timer. To poll the table, click the **Poll Video Streams Table** button.

### Elementary Streams Page

This page displays a table with basic information for each elementary stream, including the Program Number, the MPEG PID per elementary stream, the type of elementary stream (ES Type), and counters for continuity errors, descriptors, and MPEG frames (TSPs Count).

### Active Programs Mapping Page

This page displays a table with the active program mappings for transport streams, containing with the incoming program value (In Program ID), QAM Channel Name, and outgoing program value (Out Program).

### Active PIDs Mapping Page

This page displays a table with the active PID mappings for transport streams.

### Static SCG Programs Encryption

This page displays Static SCG Programs Encryption Table, which contains the following parameters: TSID, ECM PID, and Delivery State.

### Video Control Page

This page contains several parameters that allow you to define **default values** to be used throughout this connector. You can for example define default values for PAT Transmission Interval, PMT Transmission Interval, Max Number of Programs, and Unicast Timeout Interval.

### Jitter Buffering Page

This page displays a table that contains status information about the dejitter buffers per program. Entries in this table only persist for the lifetime of the active programs.

## Usage (Range 3.0.0.x)

### General Page

This page contains general information about the device.

### Interfaces Page

This page contains information on the interfaces of the Arris E6000 device.

The **Interface Table** shows information for each interface, such as the Description, Type, MTU, Speed, Physical Address, status information, information about errors and discarded packets, and interface utilization.

The page shows the **Number of Displayed Interfaces** based on how many interfaces are currently being displayed in the table.

The **Interface Selection** page button displays the Interface Selection Table, which controls which interfaces are displayed in the Interface Table:

- You can use the **Description Filter** and **Type Filter** parameters to filter the interfaces and enable or disable interfaces being displayed.
- In the **Interface Selection Table**, you can use the toggle button in the **Displayed** column to indicate whether an entry in the table should be enabled or disabled.

### QAM Streams Page

This page contains two tables, the QAM Streams table and the QAM Streams Status table, which both use the QAM Channel Name as an identifier.

- The **QAM Streams** table contains information regarding the MPEG transport stream identifier (MPEG TS ID), the index of the outgoing transport stream (Out TS ID), the retransmission interval for PAT and PMT tables (PAT Interval and PMT Interval), the associated service groups and virtual edges of each QAM Channel (Service Group Name and VE Name), etc. This table also contains four columns that are filled in by another element: HFC-Segment, QAM VOD Cluster, DTV Subscribers, and HFC-Segment Group.
- The **QAM Streams Status** table contains information regarding the total number of unique PAT tables that have been generated per QAM channel (Total PATs Tx), as well as the current, the maximum, and the total number of programs transmitted (Current Programs Tx, Peak Programs Tx and Total Programs Tx). Information related to the requested and the peak bandwidth is also displayed.

### QAM Interfaces Page

This page contains the **Video Downstream Channels** table, with information about the characteristics of the channels, such as the frequency, the used modulation, and the power (in dBm).

This page only contains the interfaces selected on the **Interface Selection** subpage of the Interfaces page.

### RF Ports Page

This page contains the RF Port Table, which displays a counter for interfaces that are down, as well as the administrator status per RF port. This table displays bit rates, the total maximum bandwidth, and the usage percentage per RF port (Bit Rate, Total Max Bandwidth, and Utilization). The table also displays information regarding the number of DTV subscribers and contains a column where you can set a customizable description for the RF port (Custom Description). The Total Programs and Current Programs count columns are added to the table in recent versions of the connector.
