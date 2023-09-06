---
uid: Connector_help_TestTree_StreamProbe
---

# TestTree StreamProbe

The **TestTree StreamProbe** driver uses **JSON** and **SNMP** to communicate with the probe. JSON is used to monitor the status of the probe, streams, programs and alarms of the **TestTree StreamProbe MPEG-2 Monitor**. SNMP is used by the device to send traps about alarms.

## About

The **TestTree StreamProbe** is an **MPEG-2 Monitoring** device. It is used to monitor probes, transport streams and its individual components (programs and PIDs). This driver allows the user to monitor the TestTree StreamProbe via DataMiner.

| **Range**            | **Key Features**                                                       | **Based on**                       | **System Impact** |
|----------------------|------------------------------------------------------------------------|------------------------------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version**Automatic Removal Delay** - \[see Usage -\> General\] | 1.0.0.24 (AJIMI TSAFT Live driver) | \-                |

### Product Info

Style: Heading 3 Accent 1

**This subsection can only be omitted for a virtual driver**

In this subsection, insert a table with two columns. In the table, list the firmware versions that are fully compatible with the driver, together with the driver ranges. If multiple firmware versions are compatible with one driver range, add them in the same row, but on different lines. See the following example:

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 5.0.6i-a               |

## Installation and configuration

### Creation

This driver uses an **HTTP** connection (for the JSON commands) and needs the following user information:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.11.12.13.*
- **IP port**: The port of the destination, e.g. *80.*
- **Bus address**: This field can be used to bypass the proxy, if the value *bypassproxy* is filled in (filled in by default)*.*

This driver also uses a Simple Network Management Protocol (**SNMP**) connection (for traps) and needs the following user information:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address***:* The probe ID for this device (used by the commands), e.g. *1.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

This page contains general status information about the probe, such as the **Probe Name**, **Software Version**, **Total CPU Load**, **Probe Status**, **Total Bitrate**, etc.

On the General page there is a '**Automatic Removal Delay**' parameter. Automatic Removal Delay is the amount of time that streams, programs and PIDs will remain in the tables after they are unavailable for a certain delay. This is needed to make sure a table never keeps growing endlessly and will prevent any memory issue. When enabled, this will also remove qualified PIDs.

### Streams

This page contains information about the streams found by the probe. It displays the **Transport Stream Table**, which contains information about the streams, such as the **Bitrate**, **Stream Name, Status**, etc. There is also a **Stream Filter** column, which allows you to give a particular name to a stream. This index is then used in the **Stream** **Index**, which is a composed index, and is further used as a basis for other composed indexes on other pages.

To keep missing streams from being displayed in the **Transport Stream Table** (and in the **Stream ETR Table**), you can enable the **Automatically Remove Missing Streams** parameter. If you do so, any streams that are missing (cf. **Str. Status** column) will no longer be displayed in the stream tables.

It's also possible to remove 1 missing stream from both stream tables. To do so, select the missing stream in the **Remove Missing Stream** drop-down list. Note that this stream will then only be removed from the tables until the next polling cycle. To permanently delete a stream from the streams managed by the probe, select the stream in the **Remove Stream** parameter.

### ETR

This page contains some more refined information about the streams found by the probe. It displays the **Stream ETR Table**, which contains information about the streams, such as the **PAT Repetition Interval**, number of **Sync Byte Errors**, etc. The page also displays some columns that are filled in when a trap occurs or when the **Alarm table** has entries for this particular alarm. The composed index on this page is the same as that on the **Streams** Page.

### Program Status

This page contains information about the programs found by the probe. It displays the **Program Status Table**, which contains information about the programs, such as the **Service Name**, the **Service Description**, the type of **Service** (Digital Radio or Digital TV), etc. It also contains a **Service Filter**, which is used as part of the composed index and used on other pages as well. It also contains a few columns that are filled in when a trap occurs or when the **Alarm table** has entries for this particular alarm.

Programs (either missing or active) can be removed from the programs tables (**Program Status Table** and **Programs QOE Table**) in the same manner as streams are removed from their respective tables. If **Automatically Remove Missing Programs** is enabled, then all programs that are missing (cf. **Serv. Stat.** column) will be removed from both programs tables. The **Remove Missing Program** parameter is also similar to its stream equivalent, as it will only delete the selected missing program from the programs tables until the next polling cycle. The **Remove Program** parameter can be used to delete a program from the probe permanently.

### PID Status

This page contains information about the PIDs found by the probe. It displays the **PIDs Status Table**, which contains information about the PID settings, such as the **PID Number**, the **PID Coding**, etc. It also contains some columns that are filled in when a trap occurs or when the **Alarm table** has entries for this particular alarm. The composed index on this page is based on that on the **Programs** **Page**.

If **Automatically Remove Missing PIDs** is enabled, then all PIDs that are missing will be removed from the PIDs Status Table. The **Remove Missing PID** parameter can be used to delete the selected missing PID from the PIDs Status Table until the next polling cycle.

### Programs QOE

This page contains some more refined information about the programs found by the probe. It displays the **Programs QOE Table**, which contains information about the **Video** and **Audio** settings, for up to 4 PIDs per program. Columns include **Video Coding Type**, **Video Loss Alarm Status**, **Audio 1-4 Silent**, etc. The **Programs QOE** page also contains some columns that are filled in when a trap occurs or when the **Alarm** **table** has entries for this particular alarm. The composed index on this page is the same as that on the **Programs** **Page**.

The parameters to delete programs are the same on this page as on the **Program Status** **Page** and can thus also be used to delete programs from both program tables.

### RF

This page contains information about **Configuration** and **Status RF** table, such as **Symbol Rate**, **Bandwidth**, **Frequency**, **Code Rate**, **Stream ID** etc.

### Alarms

This page contains information about the alarms found by the probe, either when the alarms are polled from the device or when a trap occurs. It displays information such as the **Channel Name**, the **Program ID**, **Stream ID**, the **Alarm Description**, the **Alarm Severity**, etc. The composed index on this page is based on that on the **Programs Page**, and is the same as on the **PIDs Status Page**.

### Overview

This page displays a **tree view** of for the entire device. The tree contains a branch for every stream. If a stream is selected, the programs, PIDs and alarms that apply to this stream will be displayed in a table. The stream branch can be opened to display the programs that use this stream. These programs can then also be opened to display the related PIDs. The last leaf of the branch contains the alarms that apply to the selected PID.

### Web Interface

This page can be used to access the web interface of the ****TestTree StreamProbe****. Note that the web interface of this device needs to be accessible from the client PC for DataMiner to be able to display it.

## Notes

Only users with **security level '1'** will be able to remove streams, programs or PIDs. It's also impossible for other users to automatically remove missing streams, programs or PIDs from the respective tables.
