---
uid: Connector_help_Tandberg_MX5210
---

# Tandberg MX5210

The Tandberg MX5210 protocol is a compact and cost-effective DVB remultiplexer.

## About

This is an **SNMP** connector that is used to display the status of the different parameters of a **Tandberg MX5210**.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 2.0.0.x          | Initial version | Yes                 | true                    |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 2.0.0.x          | Mib Version 1               |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **IP port**: The IP port of the device, by default *161.*
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General Info

This page contains general status information, such as the **Product Name**, **Hardware Address** and **Router**.

Other displayed parameters are among others **Unit Alarm Status**, **Configuration Changed Alarm**, **Illegal Configuration Alarm**, **Display Unlocked Alarm** and **No Input Board Alarm**.

### Boards

This page contains a table with the **Boardlist Slot Number**, **Board Type**, **Board Hardware** and **Software Version.**

### Ports

This page displays information about **Ports**, such as the **Port Type**, **Port Direction** and **Port Status**.

### Transportstream

This page contains two tables, one for the **Transport Stream Input** and the other for the **Transport Stream Output.**

- The input table shows the **Input** **Total Bitrate**, **Packet Length**, **Effective Bitrate**, **Module Mode**, etc.
- The output table shows the **Output Bitrate**, **Output Packet Length**, **External Clock**, **Output Interface**, **Backplane**, **Effective Bitrate**, etc.

### Streamer Module

On this page, you can configure the **PCR Correction**, **TS Mode**, **Splitting Mode** and **Default Original Network ID**.

There are also twelve page buttons that allow you to retrieve and configure certain properties.

- **Components**: Displays a table with **Component Slotnumber**, **PID**, **Bitrate**, **Language**, **Decoded Type**, **Portnumber** and **Scrambling**.
- **Services**: Displays a table with **Service Slotnumber**, **Service ID**, **Service Name**, **PCR PID**, **PMT PID**, **Original Network ID**, **Service Provider**, **Service Type** and **Service Port Number**.
- **Transport**: Displays a table with **Transport ID**, **Network Name**, **Original Network ID** and **Portnumber**.
- **Service Component**: Displays a table with **Service ID**, **PID**, **Type**, **Portnumber** and **Language**.
- **Backplane PID**: Allows you to configure the **BPTS PID Control**, **Slotnumber**, **Portnumber**, **Number**, **Stream ID** and **PID Status**. A table on the left side shows all current states for the Backplane.
- **Backplane Services**: Allows you to configure the **BPTS Service Control**, **Slotnumber**, **Portnumber**, **ID**, **Stream ID**, **Component Mode**, **Scrambled**, **Descramble** and **Status**. There is also a table on the left side showing the current state for each service.
- **Backplane Stream**: Allows you to configure the **BPTS Stream Control**, **Stream ID**, **Name**, **CBR**, **Filename** and **Status**. There is also a table on the left side showing the current state for each stream.
- **Backplane AS Components**: Allows you to configure the **BPTS AS Components Control**, **Slotnumber**, **Portnumber**, **Service ID**, **PID**, **Service Out PID**, **Remapped PID**, **BPTS ID** and **Status**. A table on the left side shows all current states for the AS Components.
- **Backplane Transport Stream**: Allows you to configure the **TS Control**, **TS Slotnumber**, **TS Portnumber**, **TS Service ID**, **TS Name** and **TS Status**. There is also a table on the left side showing the current state for each transport stream.
- **Backplane Remapping**: Allows you to configure the **Remapping Control**, **PID Slotnumber**, **PID Portnumber**, **PID**, **Remapped PID** and **Status**. There is also a table on the left side showing the current state for each remapping slot number.
- **Outgoing Service**: Allows you to configure the **Outgoing Service Inputslot**, **Inputport**, **Incoming ID**, **Service ID** and **PMT PID**. There is also a table on the left side showing the current state for each output service.
- **Outgoing Transport**: Allows you to configure the **BPTS ID**, **Transport ID** and **Original Network ID**. A table on the left side shows all current states for each Outgoing Transport ID.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
