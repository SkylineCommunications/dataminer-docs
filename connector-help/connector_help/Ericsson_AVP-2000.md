---
uid: Connector_help_Ericsson_AVP-2000
---

# Ericsson AVP-2000

The **Ericsson AVP-2000** connector is an HTTP connector that is used to monitor the **Advanced Video Processor** configuration.

## About

With this **HTTP** **Advanced Video Processor** connector, you can monitor and change the configuration where possible and even restore the configuration if necessary.

Range 3.0.0.x contains the most important or requested parameters and displays them in an orderly fashion. This does mean that not every parameter is implemented. Parameters found in the newest firmware version are added to the implemented tables.

### Version Info

<table>
<colgroup>
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Description</strong></td>
<td><strong>DCF Integration</strong></td>
<td><strong>Cassandra Compliant</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x</td>
<td>Initial version</td>
<td>No</td>
<td>Yes</td>
</tr>
<tr class="odd">
<td>2.0.0.x</td>
<td><p>The connector was made for version 10.13.3.0.0 (xmlVersion attribute on the XML config file of the device). Contains the config XML as one large tree view. Focuses on the following cards:</p>
<ul>
<li>CE-x Analogue</li>
<li>CE-x Encoder</li>
</ul></td>
<td>No</td>
<td>Yes</td>
</tr>
<tr class="even">
<td>3.0.0.x</td>
<td>The default range. Polling and parameters have been completely redesigned based on knowledge from previous ranges.</td>
<td>No</td>
<td>Yes</td>
</tr>
<tr class="odd">
<td>3.1.0.x</td>
<td>Started from 3.0.0.4; supports new firmware.</td>
<td>No</td>
<td>Yes</td>
</tr>
<tr class="even">
<td>3.1.1.1</td>
<td>Added DCF; only external connections implemented.</td>
<td>Partial</td>
<td>Yes</td>
</tr>
</tbody>
</table>

### Product Info

| **Range** | **Device Firmware Version**        |
|------------------|------------------------------------|
| 1.0.0.x          | Prior to 10.13.3.0.0               |
| 2.0.0.x          | 10.13.3.0.0                        |
| 3.0.0.x          | 10.3.0.0.0 10.10.1.0.0 10.13.3.0.0 |
| 3.1.0.x          | 10.30.4.0.0                        |

## Installation and configuration

### Creation

*HTTP main connection:*

This connector uses an HTTP connection and requires the following input during element creation:

- **IP address/host**: The polling IP of the device.
- **Port**: The IP port of the device, by default *80.*
- **Bus Address:** If a proxy server must be bypassed, specify *BypassProxy*.

## Usage range 2.0.0.x

### Alarm Naming

Alarms on tables are named "\[ \[KEY\] \] \[UFNAME\]", where:

- \[KEY\] is the key of the table (first column) or **XXX : Key** column.
  The key refers to exactly one tag in the config file. The XPath to this tag can be retrieved from the **Keys In Use** table on the page **Driver (Internal)**.
- \[UFNAME\] is the value of the **XXX : UF Name** column.

Example: *\[22354\] SNMP*

There are two exceptions to this rule.

1. The **Alarm Table (AT)**.

   Here the naming is formatted as "\[ \[ALARMID\] \] \[UFNAME\] (\[SOURCE\]: \[TYPE\])", where

   - \[ALARMID\] is the value of column **AT - Alarm ID.**

   - \[UFNAME\] is the value of column **AT : UF Name.**

   - \[SOURCE\] is the value of column **AT - Source Text.**

   - \[TYPE\] is the value of column **AT - Alarm Type.**

   Example: *\[411\] Data Interface Group 3-4: Data Network Lost (Base Unit: output)*

1. The **License Table (LT)**.

   Here the naming is formatted as "\[ \[FEATUREID\] \] \[CODE\] (\[DESCRIPTION\])", where

   - \[FEATUREID\] is the value of column **LT - Feature ID.**
   - \[CODE\] is the value of column **LT - Code.**
   - \[DESCRIPTION\] is the value of column **LT - Description.**

   Example: *\[22\] CE/SWO/3D (This enables 3D operation.)*

### Device Tree Page

This page contains a tree view that shows all parameters.
The tree view follows the structure of the config file and is similar to the Advanced Setup of the web interface ("Device Configuration" \> "Advanced Setup").

### Alarms Page

This page provides an overview of all alarms.
Note that this includes all possible alarms, and not only the active alarms.

When an entire row is grayed out, it means that the alarm cannot currently occur.
Other alarms can occur, but are only active if the column **AT - Active** contains the value *true.*

To display only active alarms, specify the filter below:

> *"AT : Visible":yes "AT - Active":true*

Note that it is also possible to only trigger alarms on active parameters by using conditional monitoring.
To do so, use:

> *Is**Alarm Table (AT).AT : Visible**ValueNot equal to**Yes***
> *Or**Alarm Table (AT).AT - Active**ValueNot equal to**true***

### Licenses Page

This page contains a table with all known license types. It contains the **Code**, **Description**, number **Available** and how many are **In use**.

### Configurations Page

On this page, you can upload or download a configuration file.

To do so:

1. Configure the folder where the config should be located and indicate the name of the config file.

1. Specify whether the management IP configuration should be included in the download.

1. Click the **Upload** or **Download** button.

   This will result in an update of the **Upload Status** and **Download Status** parameters.

### Table Data Page

This page contains the tables with all the parameters in the tree view, parsed from the device config file.

### Driver (Internal) Page

This page contains parameters that are required by DataMiner or are necessary to validate the correct functioning of the connector.

It contains:

- A parameter **HTTP Status Code**, which indicates the status code of the last message (or response) sent to the device.
  This should be *200 OK*. Other values may indicate a problem.
- A table that maps all the keys used in the tables on **Table Data** to an XPath that selects exactly one node in the configuration file.
  This is used internally to make sure that the keys of the rows do not change every time the device is polled. This is a requirement for the correct functioning of trending and alarm monitoring.
  However, note that there inevitably remains a small chance that this does become corrupted if parameters are deleted from the config file.
- A page button **HTTP Comm.** that shows commands and responses from messages sent to/from the device. This is only used for debugging purposes.
- A page button **Junction Tables**, containing information required for the tree view control in order to link different tables to one parent node. This information is normally not of use for the user.

### Web Interface Page

This page opens the web interface of the device.

Note that the client machine has to be able to access the device. Otherwise, it will not be possible to open the web interface.

## Usage range 3.0.0.x

#### Polling

Ericsson advises a polling scheme where the active alarms are polled every 6 seconds and a parameter request is made with at least a 15 seconds interval. This results in the following sequence:

1. Startup - Poll parameters
1. Poll alarms
1. Poll alarms
1. Poll parameters
1. ...

However, since the entire data XML is quite large and causes a lot of delay and load for the device, we split it into sections. Every parameter cycle, the queue is checked for sections that are waiting to be polled. Those that are larger than the threshold will be polled separately, smaller ones will be combined. The items waiting in the queue will have a counter to indicate their wait time, giving them a higher priority over time.

#### Keys

The polled XML file does not provide a unique identifier that is persistent when the XML changes. Because of this, the Xpath is considered to be the unique identifier. It is translated into a 10-digit key that serves as the PK in tables. If an object is removed from a list, it is possible that the IDs of sibling objects shift.

### Alarms

This page contains the **Current Alarms** table, which contains only active alarms and is updated whenever the alarms are polled (2 out of every 3 cycles).

### Device Tree

This page displays a tree view with the card information, the input settings and all the transport streams. Note that the transport streams also have their own table because some are linked to port groups and not to a card.

- Root: **Device Cards**

  - Extra tab: **Temperatures**

  - Subnode: In-between table to consolidate the sibling tables

    - Subnode: **Input Transport Streams**

      - Subnode: **Input Services**

        - Subnode: **Input components**

    - Subnode: **Input Components**

    - Subnode: **Video Encode**

    - Subnode: **Video Input**

      - Subnode: **Teletext**

        - Subnode: **Teletext Pages**

    - Subnode: **Audio Input**

    - Subnode: **Audio Encode**

    - Subnode: **Output Transport Streams**

      - Extra tab: **Destinations**

      - Subnode: **Output Services**

        - Subnode: **Output Components**

### Device

This page contains a table for the cards available in the device and a table for temperature measurements.

It also contains a **Configuration** page button, which can be used to configure a port to be used on the Web Interface page.

### SNMP

This page contains the SNMP settings, the SNMP trap settings and a table with the SNMP **Trap Destinations**.

### Backup Configurations

After you configure the **Directory** and **File Name** parameters, the configuration can be retrieved from or set on the device.

The **Stored Configurations** subpage allows you to **Save**, **Load** or **Delete** configurations stored in the device internal memory.

### Output TS Tree

This tree view contains the information of output transport streams and is structured as follows:

- Root: **Output Transport Streams**

  - Extra tab: **Destinations**

  - Subnode: **Output Services**

    - Subnode: **Output Components**

### Output Tables

This page contains the tables used in the Output TS Tree:

- **Output Transport Streams**
- **Destinations**
- **Output Services**
- **Output components**

### Input TS Tree

This tree view shows the input transport streams and their components and is structured as follows:

- Root: **Input Transport Streams**

  - Subnode: **Input Services**

    - Subnode: **Input Components**

### Input Tables

This page displays the tables used in the Input TS Tree:

- **Input Transport Streams**
- **Input Services**
- **Input components**

### Video Properties

These tables are part of the input settings of the cards and their transport streams.

- **Teletext**
- **Teletext Pages**
- **Video Encode**
- **Video Inputs**

### Audio Properties

This page displays the audio input settings of the cards:

- **Audio Inputs**
- **Audio Encode**

### Network Tree

This tree view shows the network setup, using the following structure:

- Root: **Port Groups**

- Extra tab: **Output Transport Streams**

  - Extra tab: **Input Transport Streams**

  - Subnode: **Ethernet Ports**

  - Subnode: **ASI Input Ports**

  - Subnode: **ASI Output Ports**

### Physical Ports Configuration

This page contains the tables with physical interfaces used in the network tree.

- **Port Groups**
- **Ethernet Ports**
- **ASI Output Ports**
- **ASI Input Ports**

### Queue

The **Poll Queue** table contains the fragments and other commands to keep track of communication. The flow of the communication is explained in the introduction of this "Usage" section. To decide which fragments need to be polled separately to reduce the device's response delay, there is a threshold that can be set: **Fragment Separation Threshold Load**. The **Fragment Load (Queue)** holds the current load of each fragment, and needs to be below the threshold in order to be combined with other fragments into a single request.

It is possible to enqueue a single fragment using the **Enqueue** button or hit **Force Refresh** below the table.

**Write Comm...** opens the **Write Communication** pop-up page.

### Write Communication

This page displays some of the parameters used internally for the HTTP communication. These can be of use to troubleshoot issues when performing sets.

- The **Parameter Sets Buffer** contains an XML with all the sets in the queue.
- **Set Data Request** is the message sent to the device to perform one or more sets.
- **Set Data Response** is the response message of the device.

### Web Interface

This page opens the web interface of the device.

Note that the client machine has to be able to access the device. Otherwise, it will not be possible to open the web interface.
