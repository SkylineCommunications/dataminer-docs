---
uid: Connector_help_Kathrein_VGP90xx_Manager
---

# Kathrein VGP90xx Manager

This SNMP connector allows monitoring and management of multiple Kathrein VGP90xx devices. It takes in a .csv file and creates Dynamic Virtual Elements for each device found in the file.

## About

This manager connector allows the user to import a .csv file containing the IP addresses of various Kathrein VGP90xx devices. After the import, the connector will create a Dynamic Virtual Element for each device and start polling cycles. Each device that can be accessed by DataMiner is polled and the information is presented in the corresponding DVE. If the manager cannot communicate with a device, its virtual element is put in a timeout state to indicate this.

The user can configure the devices through their virtual elements.

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Settings:

- **Port number**: The default port number to connect with the devices.

  The default value is *161*. You can override this field per device by adding the port in the IP address column of the .csv import file.

- **Get community string:** The community string in order to read from the device. The default value is *public*.

  Note: This must be the same for all elements.

- **Set community string**: The community string in order to set to the device. The default value is *private.*

  Note: this must be the same for all elements.

Note: It is not necessary to supply an IP address for the SNMP connection, since these addresses must be defined for each element in the .csv file.

### Initialization

In order for the connector to start polling devices, they have to be imported through a .csv file. This is done on the **Management** page, using the following steps:

1. Click the **Import...** button on the **Management** page.

1. Make sure the **Manager Name** is set to the same value as in the .csv file.

   This name is used to select only some rows in the import file, so that the same file can be used for all managers.

1. In the **Import File** path, select the file to import from the drop-down menu, or fill in the full path to the file.

   The drop-down menu contains all .csv files in the protocol document folder (prefixed with "\[P\] ") and all the files in the element protocol folder (prefixed with "\[E\] ".

1. Click the **Import** button to read the file and create the elements.

1. Check the **Import File State** and **Import File Error** fields to see if the import was successful, or else why it failed.

### The CSV File

There are a few rules that the .csv file must comply with and some things that the creator should be aware of:

- The file does not need to end with ".csv", even though this is advisable. However, the content should be formatted as a .csv file.
- The first two lines are mostly ignored by the parser.
- Editing a single record is not possible; you always need to upload the data for all elements in the manager. The best way to do this is by editing the element's CurrentConfig.csv file and then parsing this file again.

#### The first line

The first line of the document is only used to determine the separator used. In some regions the default is a comma while in other regions the default is a semicolon. As such, the parser will count both the number of commas and semicolons on the first line and select the most frequently used character. This will then become the separator character to parse the rest of the file.

Note: It is recommended to add titles on this line.

#### The second line

The second line is completely ignored by the parser, in order to allow comments in the file. So be careful not to add a device here.

#### All other lines

All the other lines in the file are considered possible data lines. They are split in columns using the detected separator character from the first line and comply with the following syntax:

> *\[ID\];\[IP\];\[Manager\];\[Virtual Element Name\];\[View Name(s)\]*

The following table provides more information on the different columns:

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Parameter</strong></td>
<td><strong>Description</strong></td>
</tr>
<tr class="even">
<td><strong>ID</strong> <em>(optional)</em></td>
<td><p>A number identifying the device. This number must be unique per manager. It becomes the index in the <strong>Management Table</strong> on the <strong>Management</strong> page.</p>
<p>If empty, the line will always create a new element, of which the ID will be dynamically assigned by the manager.</p>
<p>If the manager already contains a record with this ID, then that element will be updated (instead of deleted and recreated, possibly with another element ID).</p></td>
</tr>
<tr class="odd">
<td><strong>IP</strong> <em>(required)</em></td>
<td><p>The IP address of the Kathrein VGP device. Can be either IPv4, IPv6 or a name that can be resolved by the DNS server.</p>
<p>It is also possible to add a port number. If you do not do so, the default port will be used that was specified in the element's port settings during creation or editing.</p>
<p>Examples:</p>
<p>"<em>10.1.23.251</em>" or "<em>10.2.44.245:161</em>" or "<em>fdda:5cc1:23:4::1f</em>" or "<em>[1e:223:10::234]:161</em>" or "<em>vgp.katherein.bru</em>" or "<em>vgp.kat.bru:161</em>"</p></td>
</tr>
<tr class="even">
<td><strong>Manager</strong> <em>(required)</em></td>
<td><p>The name of the manager that should poll the device. This column may not be empty. If it is, the entire row will be ignored. The content of the line will only be parsed if the manager's name matches the <strong>Manager Name</strong> parameter.</p>
<p>This makes it possible to add the data for all elements on all managers in one file, and let the manager filter out its own elements. Note that the <strong>Manager Name</strong> by default is the name of the (manager) element.</p></td>
</tr>
<tr class="odd">
<td><strong>Virtual Element Name</strong> <em>(required)</em></td>
<td><p>The name of the DVE that is created for this record. This name must be unique in the DMS.</p>
<p>During the import, the manager will check if the name is unique within its own list of elements, but not if no other element exists with this name in the DMS. If the name already exists, it will either be changed by the manager or by DataMiner to make it unique. (This can be done by adding a number to the name, or any other method in the feature. )</p></td>
</tr>
<tr class="even">
<td><strong>View Name(s)</strong> <em>(optional)</em></td>
<td><p>The name or names of the view(s) where the element should be added. It is possible to separate several views with a pipe character ("|") or with a semicolon (";"). If you use a semicolon, and the file is not created in Excel but in a text editor such as Notepad, add quotes ('"') around the value.</p>
<p>If no view name is specified, the element will be added to the same view as the manager.</p></td>
</tr>
</tbody>
</table>

Note: If a field is optional, this means that the column does not need to contain any data, not that all other columns shift one position to the left.

#### Comments

It is possible to add empty lines or comments to the .csv file. To do so, make sure that the content of the third column (**Manager**) is empty or contains no text that is exactly the same as the manager name of any of the elements. Comments can also be added to columns after those used (/parsed) by the manager.

## Usage

### Management (main element)

This page shows the name of the manager, which is also used to filter records from the .csv file when importing elements. The default value is the name of the element.

There is also a Management table, which displays all the imported elements.
The table contains:

- The **Management Index**, which should be used to update the record. This row is hidden but can be made visible.

- The **Polling IP Address**: This can be an IPv4, an IPv6, or a name, which will be resolved to an IP address every time the device is polled.

  Optionally, it can also contain the port number that should be used for SNMP communication. The default port number is defined during element creation or editing (usually *161*).

- The **Manager Name:** This row is hidden but can be made visible. The row usually contains the same value as the **Manager Name** at the top of the page (unless this is changed after importing).

- The **DVE element name:** This name must be unique. If not, it will be made unique by the manager.

- The **View Name**(s) to which the DVE should be added. This is a semicolon (";") separated list. If no view names are available, the elements will be added to the same view as the manager.

- The **DVE Virtual Element ID:** Format is *\[DMA\]/\[EID\].*

- The **Polling Status**.: This column can contain three possible values:

  - *Enabled*: The device is polled and before each poll, the connector checks if the IP address of the device can be resolved. If it cannot be resolved, the DVE of the device will be put into timeout, the **Poll Status** will be set to *Stopped (Error),* and the **Timeout State Device** will be set to *DNS Error* to indicate that there is a DNS error.
  - *Disabled*: The device will not be polled. Its values and timeout state remain unchanged. No DNS checks are performed in this state. This value remains the same after an element restart but is discarded after a file import.
  - *Stopped (Error)*: The device is not polled but there will be regular checks (every hour) to see if the address remains unknown to the DNS server. When it can be resolved, polling will continue.

- The **Timeout State Device:** Indicates whether a timeout error occurred during the last poll. Note that the timeout state will not change when the element is disabled or set to *Stopped (Error)*.

- **Last Fast Polling:** Timestamp (UTC) containing the date and time when the parameters of the fast poll group were last refreshed. This row is hidden but can be made visible.

- **Last Slow Polling:** Timestamp (UTC) containing the date and time when the parameters of the slow poll group were last refreshed. This row is hidden but can be made visible.

- **Last Config Polling**: Timestamp (UTC) containing the date and time when the parameters of the config poll group were last refreshed. This row is hidden but can be made visible.

- The last column contains a button that can be used to schedule a **Priority Refresh** of all the device's parameters. This can be useful if an operator is working on the device and wants an up-to-date image.

Note that it is only possible to perform sets on a device that has the status *Enabled*.

Below the management table, there is an **Import** button, which opens a page to import or export (back up) the configuration of the manager.

### Modem (main element)

This page contains the **Downstream** and **Upstream Channels** tables as well as the **Signal Quality** and **Cm Status** tables. These tables contain entries for all the managed devices, and they are exported to the virtual elements. As such, to view the information related to one particular DVE, it is advisable to examine these tables on the element itself, as there only entries related to that device will be shown.

### Import Elements (main element)

On this page, it is possible to:

- Set the name of the manager (which is used to filter rows in the imported .csv file).
- Select a file to import, using the **Import File Path** parameter.
- (Re-)Import the data in the selected file, using the **Import** button.
- Check the import status, via the **Import File State** parameter, and see more details in the **Import File Error** field.
- Take a backup using the **Backup** button.

#### About file selection

The **Import File Path** parameter has a drop-down list containing all .csv files in the element's protocol document folder or the element document folder. Those files are prefixed with a "*\[P\]* " and an *"\[E\]* " respectively. Any other file can also be selected but requires the full path instead of just the file name.

Note:

- Protocol Document Folder = *C:\Skyline DataMiner\Documents\\ProtocolName\]*
- Element Document Folder = *C:\Skyline DataMiner\Documents\\ProtocolName\]\\ElementName\]*

#### About the import

Importing a .csv-file is a 2-step process: **first** the Import File Path has to be set and the **Import** button has to be pressed. This will import the selected file and check for changes. All the changes will be put into the **Management Import Table**. The **second** step is to check if the changes in the Management Import Table are correct. Then the **Confirm Import** button can be pressed which will import the changes present in the Import Table to the Main Management Table.

When you import a file, the system will set the status in the **Import File State** parameter and more details in the **Import File Error** field. Note that the name of the latter may be misleading because the field can contain information even if no errors occurred. In fact, this field will contain a summary of the import and/or a list of problems. It can for example mention how many elements were updated, deleted, or newly created.

Immediately after the **Confirm Import**, the system will automatically back up the new state to a file called *Current Config.csv* in the element document folder. To make changes to the **Management Table**, you can edit this file, save it, and then import the "*\[E\] Current Config.csv*" file.

#### About the backup

When you click the **Backup** button, a new .csv file is created containing all elements and settings in the **Management Table.** The file is saved with the name "*BACKUP YYYY-MM-DD_HH-mm-ss.scv*" in the element document folder.

There should also always be a file named "\[E\]: CurrentConfig.csv". Parsing this file should never cause any changes to the system. It contains exactly the same information as would be generated by a backup but is generated automatically after parsing a file. This means that every manager element that has been configured should have such a file.

Note that the backup file and the current config file only contain data about one manager. Though it is possible to manually create a file with data for all managers, this file cannot be created by the connector.

### General (virtual element)

This page contains general information about the device. It also allows you to ping the device.

### Pilots (virtual element)

This page lists information and settings related to the device's pilots.

### Forward (virtual element)

This page displays information related to the device's forwarding.

### Return (virtual element)

This page lists information and settings related to the device's return.

### Modem (virtual element)

This page lists information and settings related to the modem.

### Power Supply (virtual element)

This page displays information related to the power supply.

### Administration (virtual element)

This page contains information about the device that is administrator-related, such as the **Serial Number**.
