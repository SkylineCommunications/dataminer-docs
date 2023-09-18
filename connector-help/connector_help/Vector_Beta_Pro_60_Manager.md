---
uid: Connector_help_Vector_Beta_Pro_60_Manager
---

# Vector Beta Pro 60 Manager

This is an SNMP connector that polls several **Vector Beta Pro 60** devices and another device (Modem) just in front of them. The connector can be configured using a simple .csv file.

## About

The connector can be configured to poll several devices. For every device, it will poll some parameters and show them in a separate dynamic virtual element. The parameters for all devices are polled in a sequential manner. This means that if one device goes into timeout, all devices must wait until all parameters have timed out before the parameters of the next device are polled.

The parameters are divided into three groups: a fast, a medium and a slow group:

- The fast group is polled every time the timer ticks, i.e. every 10 seconds. This value is hard-coded in the connector, and may change depending on the connector version. However, it is possible to alter the tick speed by overriding the **Timer Base** parameter (on the **General Parameters** page).
- The medium and slow poll group are polled respectively every 30 seconds and every 12 hours. These values are hard coded in the connector and changing the timer base will have no effect on them, except if you make the timer so slow that it ticks less than the defined time. The reason is that the groups are polled whenever their **Last Poll Time** is more than 30 seconds or 12 hours ago compared to the current time. This check is performed during the fast poll loop, so there is no separate timer for the medium or slow group.

The connector in fact polls two separate devices, which is why two IP addresses must be provided. However, these are considered to be one and the same device, so all parameters are shown on the same DVE.

## Installation and Configuration

### Creating an element

To create an element with this connector:

1. Add a new element and select the **Vector Beta Pro 60 Manager** protocol.
1. Define a unique name and optionally add a description.
1. Optionally enter an IP address and port. The address will in fact be ignored by the connector, since there will be many devices. However, the port can be used to define a default port. Note that you can override the port settings for each device.
1. Preferably, set the retries to zero and select a short timeout time, so that the connector does not get stuck for too long if one device fails to respond.

### Configuring the element

Once the element has been created, it is necessary to configure the devices that need to be polled. This is done by uploading a .csv file to the DMA and telling the connector to parse the content of this file. It is important to know that this .csv file could be the same for all elements of the protocol. This means that there must be a way to filter records from the .csv and only keep a small subset. This is done by assigning a name to the element. Once the name of the manager is defined, a file can be parsed to add, update or remove elements from the manager.

To configure the element:

1. Go to the **Setup** page.
1. Set the parameter **Manager Name** with a valid name. Valid names are not empty and contain no commas or semicolons (',' or ';'). In the .csv file, there will be a column where the name of the target manager is supplied.
1. Go to page **Documents** and upload a new .csv file. This can be added to either the root folder or a sub folder with the name of the element.
1. Go back to the **Setup** page and click the **Refresh** button. A list will be shown containing all found .csv files. Select one.
1. Finally, click the **Parse** button next to the **Refresh** button. This will read the entire .csv file and create, delete or update the devices polled by the manager.

Note: Below the **Parse** button, there is an output field where the element shows some information about the last executed action. It is advisable to read this after parsing a file, in order to verify if the action has been performed successfully. In addition, the **Managed Devices** table should also be verified.

### Selecting a file

On the **Setup** page, there is a parameter **Selected Import File** which can be used to configure the connector. The file can be selected from a drop-down list where all ".csv" files are listed in the protocol's root documentation folder, or in the element's root documentation folder. The files found under the protocol root folder start with "*\[P\]:*", the files found in the element folder start with "*\[E\]:*".

Even though only files with the extension ".csv" from the two mentioned folders are shown, other files can also be selected. However, they have to be on the DMA where the element is running. To select such a file, specify the full path instead of selecting a drop-down item, e.g. *C:\Temp\MyFile.txt.*

### The CSV File

It is important to know that editing a single record is not possible; you always need to upload the data for all elements in the manager. The best way to do this is by editing the element's *CurrentConfig.csv* file and then parsing this file again.

There are a few rules that the .csv file must comply with and some things that the creator should be aware of:

- The file does not need to end with ".csv", even though this is advisable. However, the content should be formatted as a .csv file.
- The first two lines are mostly ignored by the parser.
- The other lines should have the format *\[ID\];\[NAME\];\[MANAGER\];\[IP\];\[IP_MODEM\];\[VIEWS\]*.

#### Example of a .csv file

> ID;Name;Manager;IP;IP Modem;Views
> Example file -\> contains data for two managers named "Main Manager" and "Simulation"
>
>
> 1;Brugge;Main Manager;10.0.58.1;10.0.58.2;; Will generate a new element named "Brugge" in the manager with name "Main Manager" and in the same view of the main manager.
> 2;Brugge;Main Manager;10.1.42.1;10.1.42.2;; Will generate a new element named "Brugge (2)" in the manager with the name "Main Manager" and in the same view of the main manager.
> 3;Brugge;Main Manager;10.1.42.3;10.1.42.4;; Will generate a new element named "Brugge (3)"
> ;Diksmuide;Main Manager;10.1.42.5;10.1.42.6;; Will generate a new element named "Diksmuide" every time the CSV is parsed by the main manager.
> (This also means that trending information will be lost and masked alarms will be "unmasked".)
>
> 1;Lab01;Simulation;10.0.1.10;10.0.1.11;Lab; Will generate a new element named "Lab01" in the manager with name "Simulation", the DVE element will be added to the view "Lab"
> 2;Lab02;Simulation;10.0.1.10;10.0.1.11;Lab\|Test; Will generate a new element named "Lab02" ...
> 2;Lab03;Simulation;10.0.1.10;10.0.1.11;Lab\|Test; Will be ignored, because there is already a record for the manager "Simulation" and ID "2".
>
> Note: the headers on the first line are ignored by the connector, so you cannot change the order of the data (columns) in the csv file.
> Note: you can add comments on the first line if the separator char occurs more than the comma or semi column char.
> Note: you can add comments on the second line without any restrictions
> Note: you can add comments on all other lines in unused columns
> Note: even this line would be considered a comment because there is no data in the third column. Which means that no "Manager" is selected.
> Note: even this line would be considered a comment if there is no manager named "third col" because that's the value in the third column: ;second column;third column

#### The first Line

The first line of the document is only used to determine the separator used. In some regions the default is a comma while in other regions the default is a semicolon. As such, the parser will count both the number of commas and semicolons on the first line and select the most frequently used character. This will then become the separator character to parse the rest of the file.

Note: It is recommended to add titles on this line.

#### The second line

The second line is completely ignored by the parser, in order to allow comments in the file. So be careful not to add a device here.

#### All other lines

All the other lines in the file are considered possible data lines. They are split in columns using the detected separator character from the first line and comply with the following syntax:

> *\[ID\];\[NAME\];\[MANAGER\];\[IP\];\[IP_MODEM\];\[VIEWS\]*

The following table provides more information on the different columns:

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="header">
<th><strong>Column</strong></th>
<th><strong>Description</strong></th>
</tr>
&#10;<tr class="odd">
<td><p><strong>ID</strong></p></td>
<td><p>A number identifying the device. This must be unique per manager.</p>
<p>If empty, the line will always create a new element when parsing the file.</p>
<p>If a number and not already available in the manager, a new element will be created, otherwise the element with that ID will be updated.</p></td>
</tr>
<tr class="even">
<td><strong>NAME</strong></td>
<td><p>The name of the element. This name will be used to create the DVE element (prefixed with the manager's name.) The alarms will also contain this name. The name must be unique. If it is not, the connector will make it unique by adding a number to the name.</p></td>
</tr>
<tr class="odd">
<td><strong>MANAGER</strong></td>
<td><p>The name of the manager that should poll the device. This column may not be empty. If it is, the entire row will be ignored.</p>
<p>Only if the manager's name matches the <strong>Manager Name</strong> parameter of the <strong>Vector Beta Pro 60 Manager</strong> element, the contents of the line will be parsed by that manager.</p></td>
</tr>
<tr class="even">
<td><strong>IP</strong></td>
<td><p>The IP address of the Vector Beta Pro 60 element. Optionally, you can specify the port by adding a colon and the port number after the IP address. If you do not do so, the default port will be used that was specified in the element's port settings when creating or editing the device.</p>
<p>Example: "10.1.23.5" or "10.1.23.5:5422"</p></td>
</tr>
<tr class="odd">
<td><strong>IP_MODEM</strong></td>
<td><p>The IP address of the modem linked to the Vector Beta Pro 60. Uses the same formatting as in the IP column.</p></td>
</tr>
<tr class="even">
<td><strong>VIEW</strong></td>
<td><p>The name or names of the view(s) to which the element should be added. Separate different views using a '|'. If you leave this column empty, the DVE will be created in the same view as the manager.</p>
<p>Example: "Belgium|Europe|Koen VDB"</p></td>
</tr>
</tbody>
</table>

#### Comments

It is possible to add empty lines or comments to the .csv file. To do so, make sure that the content of the third column (Manager) is empty or contains no text that is exactly the same as the manager name of one of the elements.

## Usage

### The Device Manager

One of the most important tables in the protocol is the **Device Manager**. This table can be found on the **Device Manager** page and shows all the elements created and polled by the manager.

A brief description of the available parameters:

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="header">
<th><strong>Parameter</strong></th>
<th><strong>Description</strong></th>
</tr>
&#10;<tr class="odd">
<td><strong>Index</strong></td>
<td><p>A unique ID identifying the element in the manager.</p>
<p>If an ID is specified in the .csv file, that ID will be used. If the ID already exists in the table when parsing the .csv file, that row/element will be updated. Otherwise a new row/element will be created.</p>
<p>If the .csv file does not contain an ID field, a new row/element will be created for the record and it will automatically be assigned a unique ID. Note that if no ID is assigned in the .csv file and that file is parsed twice, one row will be deleted and another row will be created with a different ID. This has an impact on the trending: the available trending will be lost.</p></td>
</tr>
<tr class="even">
<td><strong>Name</strong></td>
<td><p>A user defined name for the element. The name must be unique for this manager. If not, the connector will generate a unique name by adding a number to the name.</p>
<p>Example: two elements with name "Brugge" would become: "Brugge" and "Brugge (2)".</p></td>
</tr>
<tr class="odd">
<td><strong>View(s)</strong></td>
<td><p>The name of the view or views to which the generated DVE should be added. If nothing is specified in this column, the DVE will be added to the same view as the manager.</p></td>
</tr>
<tr class="even">
<td><strong>IP 1</strong></td>
<td><p>The IP address of the Vector Beta Pro 60 device being polled.</p></td>
</tr>
<tr class="odd">
<td><strong>IP Modem</strong></td>
<td><p>The IP address of the modem linked to the Vector Beta Pro device.</p></td>
</tr>
<tr class="even">
<td><strong>Element ID</strong></td>
<td><p>The element ID of the generated DVE.</p>
<p>(Formatted as "[DMA ID]/[EID]")</p></td>
</tr>
<tr class="odd">
<td><strong>Timeout</strong></td>
<td><p>This indicates if during the last polling interval of the device (Vector Beta Pro 60) at least one parameter timed out.</p>
<p>Note that the DVE will be set in timeout if either the device or the modem is in timeout.</p></td>
</tr>
<tr class="even">
<td><strong>Timeout Modem</strong></td>
<td><p>Indicates if during the last polling cycle of the modem at least one parameter timed out.</p></td>
</tr>
<tr class="odd">
<td><strong>Last Poll "Fast" Group</strong></td>
<td><p>The UTC date and time when the last fast poll cycle was executed.</p></td>
</tr>
<tr class="even">
<td><strong>Last Poll "Medium" Group</strong></td>
<td><p>The UTC date and time when the last medium poll cycle was executed.</p></td>
</tr>
<tr class="odd">
<td><strong>Last Poll "Slow" Group</strong></td>
<td><p>The UTC date and time when the last slow poll cycle was executed.</p></td>
</tr>
<tr class="even">
<td><strong>Polling Status</strong></td>
<td><p>Indicates if the device and modem are polled. Polling can be disabled and enabled by the user or automatically stopped by the connector if the DNS cannot translate the server name to an IP address.</p></td>
</tr>
</tbody>
</table>

### Backup & Current Settings

You can take a backup of the current settings by clicking the **Backup** button on the **Setup** page. Clicking this button will generate a .csv file in the element's Documents folder, which will also be available in the drop-down list of the **Selected File** parameter.

The .csv file will contain a list of all elements polled by the manager, i.e. the ID, Name, Manager's Name, Views and IP Addresses. The name of the backup file will be "BACKUP \[UTC DATE AND TIME\].csv".

There should also always be a file named "\[E\]: CurrentConfig.csv". Parsing this file should never cause any changes to the system. It contains exactly the same information as would be generated by a backup, but is generated automatically after parsing a file. This means that every manager element that has been configured should have such a file.

These files can be used to create a "master" file containing all info for all managers on the DataMiner. To do so, simply find all "CurrentConfig.csv" files in all subdirectories of the protocol root folder and copy all but the first two lines to a new file (which should start with the first two lines of one of the .csv files.) The protocol's root folder should be: *C:\Skyline DataMiner\Documents\Vector Beta Pro 60 Manager\\*

Note: this can be used to get the actual IDs generated by the connector for each element if they were configured using an empty ID field.

## Pages & Content

### Managed Devices

This page contains a list of all the devices polled by the element, along with status information, including IP addresses, timeouts, when each group of each element was last polled, etc.

#### Note about DNS errors

It is possible to supply the name of the server instead of an IP address. In that case the connector will try to translate the name to an IP address just before polling. This will be repeated in every poll cycle, so the IPs can be dynamic. However, it is possible that the name cannot be resolved by the DNS server. In that case, the DVE will be set in timeout and the polling for both the Vector Beta Pro device and the modem will be stopped.
This is indicated by the *Stopped (Error)* value in the **MD -** **Polling Status** parameter. The source of the problem will also be indicated by the value *DNS Error* in the **Timeout** and/or **Timeout Modem** columns, depending on which name(s) could not be resolved.

Once every hour the connector will re-evaluate, or retry, the names, so that polling can automatically be resumed if the problem is solved. The user can force a retry by manually setting the **Polling Status** to *Enabled*. It is also possible to set a *Stopped (Error)* record to *Disabled,* in which case polling will not be resumed until this is explicitly set to *Enabled* again by the user.

### Setup

To make changes to the managed devices, you must use this page. Here you can find the parameters to select a file, parse the file, take a backup and view the result of the last action that was executed.

### Exported Parameters

This page contains all 'single' parameters that are being polled for all devices in a table view. Each line represents a DVE. All the parameters of the DVE are also visible as single parameters in the DVE interface. However, there they are grouped and positioned on several pages.

This table can be used as an overview to easily compare several elements.

### Modem

This page currently contains four tables, all linked to the modem - hence the name of the page. For each table on the DVE element, there is a master table where all records for all elements are shown. This can be used as an overview to easily compare several elements.
