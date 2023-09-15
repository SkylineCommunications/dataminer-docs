---
uid: Connector_help_Sencore_AG_4400
---

# Sencore AG 4400

The Sencore AG 4400 connector can be used to view real-time parameters from the device and to configure parameters of the device.

## About

The connector needs an SNMP connection to retrieve data from the device and to perform sets on it.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.3.3.BR443.r12615          |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### Input Selection

On this page, you can configure the input selection. There are two tables:

- **Input Source**
- **ASI Input**

### Inputs

This page contains three tables with different input protocols:

- **MPEG/IP**
- **DVB-S2**
- **VSB**

### Biss

This page contains three tables that are related to Biss:

- **Biss Interface**
- **Biss Selected Service**
- **Biss Ts**

### Cam

This page contains three tables that allow you to configure Cam:

- **Camslot**
- **Cam Selected Pid**
- **Camopt**

### Service

On this page, you can find a lot of parameters that are related to services: **AFD**, **Descriptor**, **Teletext**, **VPS**, etc.

There are also three page buttons:

- **Service Lock...**
- **PID Lock...**
- **SI Services...**

### Video

This page displays the video **statuses**, general parameters, **aspect ratio** and **overlay**.

### Audio

This page contains one table:

- **Audiosrv Table**

### Genlock

This page contains three groups of parameters:

- **Genlock**: general parameters, such as **Reference Type**, **Output Format Locked**, etc.
- **SD Genlock**
- **HD Genlock**

### Basebound Outputs

This page also displays three groups of parameters:

- **HD SDI**
- **SD SDI**
- **Composite**

### Baseband Outputs Audio

This page displays three tables:

- **SDI Audio**
- **Analog Audio**
- **Digital Audio**

### Transport Stream Outputs

This page contains one table:

- Mpegiptx Table

### Admin

This page contains general configuration parameters, as well as two page buttons:

- **License...**
- **Admin Streams...**

### Reporting

This page contains two tables:

- **Alarm Logging**
- **Event Logging**

There are also two page buttons:

- **System Conditions...**
- **System Events...**

### About

This page displays the **Unit Serial Num** parameter and the **Options** table.

### Webpage

On this page, you can access the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
