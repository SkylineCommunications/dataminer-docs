---
uid: Connector_help_Ericsson_Redbee_EPG
---

# Ericsson Redbee EPG

This connector is used to visualize information from an **Ericsson Redbee Electronic Program Guide (EPG)**.

## 1. About

The purpose of this connector is to visualize the scheduling of programs for different TV channels. For each program, miscellaneous information is available: **Start Time**, **Duration**, **Title**, **Synopsis**, etc. This timeline can be viewed in the DataMiner Resource Manager or it can be displayed using a Visio drawing.

The connector also checks for gaps between successive programs.

To construct the program guide, the information is extracted from XML files that are retrieved from an FTP server or from a shared folder. These files are also called EPG or TVA files.

### 1.1 Ranges of the connector

| **Range**     | **Description**                            | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version                            | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | Recreation of element Impact: loss of data | No                  | Yes                     |

## 2. Installation and Configuration

### 2.1 Creation

This connector requires **WinSCPnet.dll**. This DLL must be placed in the folder "*\Skyline DataMiner\Files\\*". A restart of the DMA may be required.

#### Virtual Connection

The Ericsson Redbee EPG connector uses a virtual connection and does not require any input during element creation.

## 3. Usage

This connector contains the pages detailed in the sections below.

### 3.1 General

The General page consists of the four different sections listed below.

#### 3.1.1 Server

This section of the page focuses on establishing a connection with the server where the EPG XML files containing the program information are located. In order to retrieve these files, only FTP and SMB connections are supported.

The following settings must be configured:

- **Server Address:** The IP address or URL of the directory on the server where the EPG XML files are stored.
  Note: For FTP, "ftp://" must be added to the beginning of the address. For SMB, the address must start with "\\". For example:

- <ftp://11.12.13.14/path/to/epg/files>
  - [\\path\to\epg\files](file://///path/to/epg/files)

- **Username**: An account that has at least read access to the specified directory must be used.

- **Password**: The corresponding password of the account.

The **Server Status** indicates if there are connection issues with the server. Because the connector does not keep the connection alive, a healthy connection will often switch between **Ok** and **Connecting**.

The **Error Message** provides more information in case something went wrong while connecting to the server.

The connection can be tested using the **Connect button.** This will force a search for new XML files on the location specified in the **Server Address**.

#### 3.1.2 Stagis

This section focuses on the connection with the Stagis server. This server contains Stagis IMI XML files. These add another identifier to the program called the Stagis IMI. Programs that do not have a Stagis IMI will fail on a live broadcast.

The following setting must be configured:

- **Stagis IMI FTP Address**: The IP address or URL of the directory on the server where the Stagis IMI XML files are stored. For example: <ftp://11.12.13.14/path/to/stagis/imi/files>.
- **Stagis IMI Backup Address**: A second location where the Stagis files can be found. The connector will automatically switch to this server when it is unable to access the main server.
- **Stagis Status**: The connection status with the Stagis server. If the connector is using the backup server, the status will be **Backup**.
- **Stagis IMI Forward Limit** and **Stagis IMI Backward Limit**: Only programs that have a start and end time within this time window will be updated with the Stagis IMI.

The **Stagis Status** indicates if there are connection issues with the server. Note that the connector does not keep the connection alive, so a healthy connection will often switch between *Ok* and *Connecting*. When the main server is not available, the backup server will be used. In this case, the Stagis status will display **Backup**.

The **Error Message** provides more information in case something went wrong while connecting to server.

#### 3.1.3 Offload

The EPG/TVA XML files that are downloaded using the connection specified in the Server section can also be offloaded. This can be useful to debug in case something went wrong.

The following settings can be configured:

- **Offload Directory**: This is the directory the files are offloaded to.
- **Offload Enabled button**: With this button, you can enable or disable the file offload.

#### 3.1.4 EPG

This section focuses on how the EPG/TVA XML files are processed.

The following settings can be configured:

- **Enable Asset Polling**: Enables or disables the polling for new XML files on the EPG/TVA server.
  If this is disabled, no new programs will be added and the timeline with existing programs will not receive updates.
- **Amount of Files to Process at Once**: The maximum number of files that will be downloaded before they are processed.
- **Gap Resolution**: Determines how big the distance between two programs must be before it is recognized as a gap.
  If the difference between the end of a program and the beginning of the next program is higher than or equal to this parameter, a gap will be detected. If the resolution is 0, the start time of the new program and the end time of the finished program must be exactly the same.
- **Keep locations for**: Determines for how many days entries in the **Program Location Table** are kept in the database.
- **EPG Backward Limit** and **EPG Forward Limit**: These parameters determine the time range of the EPG timeline.
- **Status**: Indicates what the connector is currently is doing. Examples of Status values can be "Idle", "Processing Files", "Adding Resources", "Deleting Content", etc.

The **FTP File Index** contains the name of the last processed file.

The **Amount of New Files** parameter shows how many new files have been found on the server. These files will soon be processed.

The connector is capable of handling updates to the **start time** and **end time** of a program. A program can even be removed from the timeline. Thanks to this, the schedule can be changed without problems. While the schedule is updating, it is possible that temporary gaps will be created. To prevent alarms being created for these gaps, the **Gap Alarm Threshold** parameter is used. This parameter determines when a gap will be recognized as problematic. The value represents the number of hours before airing.

### 3.2 TVA Monitoring

This page provides feedback about the processing of the EPG/TVA XML files.

The **TVA Files Monitoring Table** displays how many files have been successfully processed during each timer interval, which is every 15 minutes. If no files were downloaded during a timer interval, no row is added. The table only keeps the information of the last 24 hours.

The parameter **TVA Files Downloaded** counts how many files have been downloaded during the period specified by the parameter **TVA Monitoring Period**.

The **Last Processed File Timestamp** indicates when a file was last successfully processed. This timestamp is extracted from the file name, e.g. *20150530170117upc\_.xml*.

The **TVA Files Issues** table lists all the files that were not successfully processed, e.g. because of a parsing error. The content of those files will be ignored. You can manually acknowledge a file by setting **TVA Error Status** to *Acknowledge*. Acknowledged files will be deleted after the number of days specified by the parameter **Keep Acknowledged Files for ...**.

### 3.3 Channels

On this page, the **Service Information Table** lists all the services/channels.

- **Service ID**: Numeric identifier of the channel.
- **Name**: Name of the channel.
- **Broadcast Setting**: Allows you to enter the names of programs, in order to mark these as **not broadcasting**. Wildcards can be used.
- **Broadcast Start Time**: The beginning of the broadcast window.
- **Broadcast Duration**: The duration of the broadcast window.
- **Update**: Reports if there are pending updates for the timeline. The connector will automatically do these updates.
- **Monitoring**: Enables or disables the monitoring of the channel. Channels that are monitored will **appear in the timeline** and will also be **checked for gaps**.
- **Stagis IMI Verification**: Enables or disables the check for missing Stagis IMI on the channel.
- **Creation Delta**: This is the smallest or most negative **program creation delta** value (see explanation **Program Location Table**).
- **Delivered Delta**: This is the smallest or most negative **program delivered delta** value (see explanation **Program Location Table**).
- **Delta Threshold**: Determines when a program is considered to be created or delivered late.
  A program is **considered late** when the **Creation Delta** is **larger than** the **Delta Threshold**.
- **Number of Late Creation**: This is the number of programs that were create late according to the **Delta Threshold**.
- **Number of Late Delivery**: This is the number of programs that were delivered late according to the **Delta Threshold**.

The **Update Bookings** button forces the connector to push all program changes of channels that require an update to the timeline.

The **Reload Stagis IMI** button forces the connector to check the Stagis server and update the Stagis IMI of the programs.

The four **color** parameters at the bottom of the page are used to change the color of the programs and gaps on the timeline. The **Off-Air Color** will be applied when a program is out of the **broadcast window**.

### 3.4 Channel Overview

This page provides an overview of the channels and their programs in a tree view. The tree view contains a list of all channels. Selecting a channel will display more information about it. Programs and gaps associated with the channel will also be listed.

### 3.5 Gaps

On this page, the **Gap Table** lists all the gaps found on the timeline. A gap is created when the end time and start time of subsequent programs are too far apart. A gap can have one of the following two statuses: ***Gap*** or ***Looming Gap***. A looming gap is a gap that is further away from airing than the **Gap Alarm Threshold**. A regular gap will be within the **Gap Alarm Threshold**. A looming gap will most likely be fixed before airing, but a regular gap will probably need intervention of an operator because it is too close to airing.

### 3.6 Overlap

On this page, the **Overlap Table** shows which program updates have caused a gap in the timeline. An entry in the table contains the **Name**, **Crid** and **Timestamps** of both the program that was overwritten and the new program.

### 3.7 Programs

This page contains the **Program Location Table**, which lists all the programs that are currently in the connector.

- **Location ID**: Identifier of the program. This identifier is created from the Redbee CRID and IMI.
- **Service ID**: Numeric identifier of the channel.
- **Name**: Name of the program.
- **Start Time UTC**: Start time of the program in UTC.
- **End Time UTC**: End time of the program in UTC.
- **Start Time Local**: Start time of the program in local time.
- **End Time Local**: End time of the program in local time.
- **Duration**: Indicates how long the program will be playing.
- **Blackout**: Indicates whether the program is blacked out.
- **Broadcasting Status**: Indicates whether the program will be or was broadcast.
- **GUID**: Identifier of the program on the timeline. If the value equals *N/A*, then the program is not listed on the timeline.
- **Stagis IMI**: The Stagis IMI identifier of the program.
- **Creation Delta**: The time **difference between** the time that the entry was **first created** and the **start time** of the program.
  Negative values indicate that it was created before the start of the program. Positive values indicate that it was created after the program started.
- **Delivered Delta**: The time **difference between** the time the entry was **last updated** and the **start time** of the program.
  Negative values indicate that it was last updated before the start of the program. Positive values indicate that it was last updated after the program started.
- **Registered**: The timestamp when the program was processed by the connector.

This table can contain multiple entries for the same TV program/episode. This is because the program can air on multiple channels and at multiple times.

### 3.8 Program Information

On this page, the **Program Information Table** displays information about the programs available in the EPG: **Title**, **Synopsis**, etc.

Only the CRID is used as identifier here. This is because the CRID identifies a single program/episode.

### 3.9 Number of Blackouts

This page contains a table that keeps a two-week history of the number of blacked out programs per channel.

### 3.10 Blackout Percentages

This page contains a table that keeps a two-week history of the percentage of blacked out programs per channel.

### 3.11 Stagis Delta

This page contains two tables that list programs with missing Stagis IMI identifiers.

The table at the top of the page lists the number of programs per channel that have a missing Stagis IMI.

Below this, the **Unavailable Stagis IMI** table lists all programs that have a missing Stagis IMI identifier.

The **Delta** column of the **Unavailable Stagis IMI** table shows the time difference in minutes between the start of the program and the detection of the missing Stagis IMI.

### 3.12 Stagis Delta Overview

This page shows the same information as the **Stagis Delta** page, except here the information is displayed in a tree view.

### 3.13 Configuration

This page is used in order to reset parts of the connector. It is also used to configure the logging of additional information messages for debugging purposes.

The **Reload All EPG Files** button will clear all tables except for the **Service Information Table** and clear the timeline. The data will be rebuilt immediately using the files that are available on the server, but **this can take a while**. This button must be used with caution.

The **Reload All Reservations** button will only clear the timeline. It will be rebuilt immediately using the data stored in the **Program Location**, **Program Information** and **Gap** tables.
