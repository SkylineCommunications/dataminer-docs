---
uid: Connector_help_CISCO_AS_Series_Media_Processor
---

# Cisco AS Series Media Processor

This protocol is used in order to monitor the Cisco AS Series platform (formerly known as Inlet Spinnaker). The protocol allows monitoring, scheduling of encoding events and slate insertion.

## About

This connector can be used to monitor the **Cisco AS Series platform**.

Via **SNMP**, a number of monitoring parameters are polled. A **serial** connection is used to send commands to the device over HTTP using the Spinnaker Message Service XML API.

As the device can also send messages (e.g. heartbeat messages and messages indicating system events, such as allocation or start of encoding) a **smart serial** connection is also defined.

As the media processor is typically deployed on a Windows server machine, **WMI** is used to poll server information such as processor usage, memory usage, process info, etc.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

#### Serial connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. This is the device port to which **synchronous** messages must be sent.

#### Smart Serial connection

This connector uses a smart serial connection and requires the following input during element creation:

SMART SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the DataMiner Agent to which the **asynchronous** responses must be sent.
  - **IP port**: The IP port of the device that will listen for the asynchronous responses (typically *8089*).

Note: The current implementation does not process the asynchronous responses.

## Usage

### General

This page displays general information on the platform (**Encoder Name**, **Software Version and Model**).

The **Channels Overview** table provides an overview of the channels along with their status.

On the right-hand side of the page, you can find monitoring parameters such as the **Uptime**, **Total Processor** **Load** and **Physical Memory Usage**.

For more detailed information about the presets, processors, memory, processes, fans and disks, click the corresponding page button.

**Note:** Only information about processes with a name starting with either "Encoding", "Spinnaker" or "Timecode" is polled.

### Presets

This page allows you to retrieve a preset from the device (**Export Preset**) and load a preset onto the device (**Import Preset**).

### Event Scheduling

This page provides an overview of all the scheduled events and the completed scheduled encodings.

To schedule a new event, click the **Schedule Event** page button. The following information is required:

- **Event Start Time**: The time the encoding will start.
- **Event End Time**: The time the encoding will end.
- **Preset:** The encoding preset to use.
- **Channel Selection**: The channel to which this event will be scheduled.
- **Override:** Indicates whether this scheduled event may override other scheduled events.
- **Event Name**: A unique name that identifies this scheduled event.

### Slate Scheduling

This page allows you to schedule a slate insertion.

To import a file containing slate scheduling information, click the **Import** page button.

To schedule a slate insertion, click the **Start** page button and provide the following information:

- **Slate Start Time**: The start time to insert the slate.
- **Slate End Time**: The end time of the slate insertion.
- **Slate Image Path**: Path to the image that will be used as a slate.
- **Slate Channel**: Channel to which this slate insertion applies.

Then press the **Send** button.

To stop a slate insertion, press the **Stop** page button and provide the following details:

- **Stop Slate Time**: The end time of the slate insertion.
- **Stop Slate Channel**: The channel to which the slate stop command applies.

Then press the **Send** button.

You can cancel all slate scheduling operations for a particular channel by selecting the channel in the **Cancel All Slates For Channel** drop-down box.

### Network Interfaces

This page displays an overview of the network interfaces in the network adapter table.

### Alarms

This page displays a number of alarm parameters (related to temperature, power, fan, CPU, disk, etc.).

To obtain more alarm parameters related to inputs, encoding, sources and Ethernet, click the corresponding page buttons.

### Event History

This page displays an overview of recent events in the **User Events Table**. The number of items to keep in the table can be configured through the **Events Max Number** and **Events Max Duration** parameters.

### Security Settings

On this page, the **User Name** and **Password** can be provided that will be used to communicate with the device.

### Web Interface

This page displays the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
