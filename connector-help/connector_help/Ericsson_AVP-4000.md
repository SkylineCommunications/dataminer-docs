---
uid: Connector_help_Ericsson_AVP-4000
---

# Ericsson AVP-4000

The **Ericsson AVP-4000** connector is an HTTP connector that is used to monitor the **Advanced Video Processor** configuration.

## About

With this **HTTP** **Advanced Video Processor** connector, you can monitor and change the configuration where possible and even restore the configuration if necessary.

Range 2.0.0.x contains the most important or requested parameters, but not every parameter is implemented. Parameters found in the newest firmware version are added to the implemented tables.

### Version Info

| **Range** | **Description**                                                     | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version (deprecated)                                        | No                  | Yes                     |
| 2.0.0.x          | Revised version (based on the AVP-2000 3.0.0.3)                     | Yes                 | Yes                     |
| 2.0.1.x          | Version with **support of DVEs**. (DVEs created based on card info) | Yes                 | Yes                     |
| 3.0.0.x          | Revised version (based on 2.0.0.x)                                  | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Prior to 10.13.3.0.0        |
| 2.0.0.x          | 10.13.3.0.0                 |
| 3.0.0.x          | 10.13.3.0.0                 |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

- **IP address/host**: The polling IP of the device.
- **Port**: The IP port of the device, by default *80.*
- **Bus Address:** If a proxy server must be bypassed, specify *BypassProxy.*

#### SNMP Secondary Connection \[version 2.0.0.x\]

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Set community string**: The community string used when reading values from the device, by default *public.*
- **Set community string**: The community string used when setting values on the device, by default *private.*

## Usage (range 2.0.0.x)

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

      - **Subnode: Teletext**

        - **Subnode: Teletext Pages**

    - Subnode: **Audio Input**

    - Subnode: **Audio Encode**

    - Subnode: **Output Transport Streams**

      - Extra tab: **Destinations**

      - Subnode: **Output Services**

        - Subnode: **Output Components**

### Device

This page contains a table for the cards available in the device and a table for temperature measurements.

### SNMP

This page contains the SNMP settings, the SNMP trap settings and a table with the SNMP **Trap Destinations**.

### Backup Configurations

After configuring the **Directory** and **File Name** parameters, the configuration can be retrieved from or set on the device.

### Output TS Tree

This tree view contains information regarding the output transport streams and is structured as follows:

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

This page contains tables with input settings of the cards and their transport streams:

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

This page contains the tables with physical interfaces used in the network tree:

- **Port Groups**
- **Ethernet Ports**
- **ASI Output Ports**
- **ASI Input Ports**

### Queue

On this page, the **Poll Queue** table contains the fragments and other commands to keep track of communication. The flow of the communication is explained in the "Notes" section below. To decide which fragments need to be polled separately to reduce the device's response delay, there is a threshold that can be set, i.e. the **Fragment Separation Threshold Load**. The **Fragment Load (Queue)** holds the current load of each fragment, and needs to be below the threshold in order to be combined with other fragments into a single request.

It is possible to enqueue a single fragment using the **Enqueue** button, or to trigger a **Force Refresh** using the button below the table.

The **Write Comm** page button opens the **Write Communication** subpage, which displays parameters used internally for the HTTP communication. These can be of use when troubleshooting issues when performing sets.

- The **Parameter Sets Buffer** contains an XML with all the sets in the queue.
- **Set Data Request** is the message sent to the device to perform one or more sets.
- **Set Data Response** is the response message of the device.

### Web Interface

This page opens the web interface of the device. Note that the client machine has to be able to access the device. Otherwise, it will not be possible to open the web interface.

## Notes

#### Polling

Ericsson advises a polling scheme where the active alarms are polled every 6 seconds and a parameter request is made with at least a 15-second interval. This results in the following sequence:

1. Startup - poll parameters
1. Poll alarms
1. Poll alarms
1. Poll parameters
1. ...

However, since the entire data XML is quite large and causes a lot of delay and load for the device, it is split into sections. Every parameter cycle, the queue is checked for sections that are waiting to be polled. Those that are larger than the threshold will be polled separately, smaller ones will be combined. The items waiting in the queue will have a counter to indicate their wait time, giving them a higher priority over time.

#### Keys

The polled XML file does not provide a unique identifier that is persistent when the XML changes. Because of this, the Xpath is considered to be the unique identifier. It is translated into a 10-digit key that serves as the PK in tables. If an object is removed from a list, it is possible that the IDs of sibling objects shift.
