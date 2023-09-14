---
uid: Connector_help_Miranda_nVision_Router_Control
---

# Miranda nVision Router Control

This connector allows you to configure routers using the nVision Ethernet protocol.

## About

This connector uses **serial** communication to configure and monitor devices supporting the nVision Ethernet protocol.

### Version Info

| **Range**     | **Description**                                                                                    | **DCF Integration** | **Cassandra Compliant** |
|----------------------|----------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                                                                                   | No                  | Yes                     |
| 1.0.1.x              | Bus address defines level/partition.                                                               | No                  | Yes                     |
| 1.1.0.x              | Adaptation to NP0016 rev E protocol.                                                               | No                  | Yes                     |
| 1.1.1.x              | Support of 2 controller boards. Bigger matrix (up to 288\*576). Impact: Element must be recreated. | Yes                 | Yes                     |
| 1.1.2.x \[obsolete\] | Added Status String. Fixed crosspoint table.                                                       | Yes                 | Yes                     |
| 1.1.3.x \[SLMain\]   | Fixed crosspoint table names.                                                                      | Yes                 | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                                                                                                             |
|------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x          | CRF Version SV0877-18, Boot Version SV0770-01A0 v1.2.0.0, Application version: SV0794-07A v6.2.0.63, FPGA Version: SV0998-04A0 v4.0.0.0                 |
| 1.0.1.x          | CRF Version SV0877-18, Boot Version SV0770-01A0 v1.2.0.0, Application version: SV0794-07A v6.2.0.63, FPGA Version: SV0998-04A0 v4.0.0.0                 |
| 1.1.x.x          | CPLD SV1055-01 BOOT Rom SV1038-05 EM0833ROM Jun 10 2011 11:40:33 Control Card 3.8.0.3306 EM0833 Firmware - October 5, 2015 IOXM-I-001 SV1110-14 Build 0 |

## Installation and configuration

### Creation

#### Serial Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device. In version 1.0.1.1 of this connector, the bus address is used to select a level/partition.

## Usage

### General (version 1.0.0.1)

In version 1.0.0.1 of the connector, the General page contains the parameters that must be configured to obtain the status of a given partition of the router: **Level Number**, **Number of Outputs** and **Starting Output**.

To be able to start the polling, you first need to configure which subset of the router control card's outputs will be polled. You can do so by specifying the **Level Number** (i.e. bus address). The first output that is retrieved can be configured in the **Starting Output** parameter, and the total number of outputs that are retrieved, beginning from the **Starting Output**, can be configured in **Number of Outputs**. For example, if **Level Number** is set to *2*, **Starting Output** to *8* and **Number of Outputs** to *4,* the connector will poll the outputs 8, 9, 10 and 11 of level 2.

The parameter **Admin State** can be set to *Disabled* to prevent configuration of the router device from the connector.

### General (version 1.0.1.1)

In version 1.0.1.1 of the connector, the General page displays the selected level (**Level Number**) and its properties: **Partition Physical Input Start**, **Partition Physical Output Start**, **Partition Input Count**, **Partition Output Count**, **Partition Controller Input Start** and **Partition Controller Output Start**.

The crosspoints table is based on the **Partition Controller Input Start** and **Partition Controller Output Start** values.

An overview of all the partitions defined on the router can be obtained via the **Partitions** page button.

### Status

This page provides an overview of the status of the device. Note that depending on the type of router (e.g. compact router), some parameters may not be available on the device. These parameters will then indicate *NA* (Not Available).

### Partition (version 1.0.0.1)

This page provides an overview of the matrix partitions of the router in the **Router Partition Data Table**.

### Matrix (version 1.0.1.2)

This page displays an overview of the matrix configuration.

### Crosspoints

This page displays an overview of the selected crosspoints (on the General page). In the **Crosspoints Table**, an output can be connected to an input and the LPR state can be changed.

Note that depending on the device type, some commands may not be supported (e.g. on compact routers, the Protected action is not available.).

In case the **Automatic Polling** parameter is set to *Enabled*, the crosspoints table will automatically be polled every 5 minutes.

Manual polling can be triggered by clicking the **Tally Dump** button.

### Alarms

This page displays alarm status information (when available).
