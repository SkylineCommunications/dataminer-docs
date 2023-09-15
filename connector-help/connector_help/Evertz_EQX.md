---
uid: Connector_help_Evertz_EQX
---

# Evertz EQX

The purpose of this SNMP connector is to monitor the Evertz EQX video router and its supported cards. It is a manager connector that allows polling of all the cards available on the router, and it creates virtual child elements.

## About

The Evertz EQX video router can hold up to 74 different cards (which can be of different types). For each supported card type, a Dynamic Virtual Element will automatically be created, which contains information for that card. The user can decide whether to enable or disable the polling of each card. This can be done on the main element, which also contains information about the status of all the inserted cards.

Currently supported card types:

- EQX-G-OP18
- EQX-G-IP18
- EQX-XPTG-576x288
- EQX Monitor HD

Based on the type of card, different tables and parameters are available in the child element.

### Version Info

| **Range**            | **Description**                                                | **DCF Integration** | **Cassandra Compliant** |
|----------------------|----------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[Obsolete\] | Initial version                                                | Yes                 | No                      |
| 2.0.0.x \[Obsolete\] | Yes                                                            | No                  |                         |
| 2.0.1.x \[Obsolete\] | Yes                                                            | No                  |                         |
| 3.0.0.x \[SLC Main\] | Stripped version with new firmware. Serial connection removed. | Yes                 | No                      |

## Configuration

### Connections

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values from the device. The default value is *private*.
- **Number of retries**: 0

#### Serial QUARTZ connection (Not available in range 3.0.0.x)

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

#### Serial BROADCAST connection (Not available in range 3.0.0.x)

This connector uses a smart-serial connection and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

## Usage (1.0.0.x, 2.0.0.x, and 2.0.1.x)

### General

This page displays the **Frame Controller Card Table**.

This table contains information about all the inserted cards on the video router. This information includes the **Card Type**, **Card Address** (IP address, used for polling), **Card Status**, **Card Departure Count**, and **Card Production ID**.

Virtual elements will be created for all the supported card types, based on the **Card Production ID**. You can decide for each card whether it should be polled or not. However, note that only supported cards that have a **Card Status** with value *Communicating* will be polled. Enabling polling for an unavailable card on the frame controller will not have any effect until the card has the correct status.

### Redundant Connections

This page displays the **SNMP Connections Table** and the **Serial Connections Table**.

These tables contain all the connections for the SNMP, serial, and smart-serial connections that can be initialized for the device. The first connection of every table is the connection that is initiated upon element creation. This will always be the first connection to be used when a new element is created. Via the right-click menu of the table, you can create or delete connections. The new setup will be shown in the corresponding table. It is also possible to edit existing connections to specify new values.

The **SNMP Connections Table** contains a unique **Connection**, user-defined **Name**, indication of the **Polling State**, **IP** address, **Port** number, **Get Community String**, **Set Community String**, a **Rank** (which indicates the order in which the connection will automatically be selected), and finally a **Force** button (which allows you to select a particular connection).

The **Serial Connections Table** contains a unique **Connection**, user-defined **Name**, indication of the **Polling State**, **IP** address, **Port** number, **Broadcast Port** number, a **Rank** (which indicates the order in which the connection will automatically be selected), and finally a **Force** button (which allows you to select a particular connection).

### DVE

On this page, there is a table for each supported **Card Type** with DVE child element entries. Virtual child elements will be created automatically for supported available cards, but you have to delete these manually by clicking the **Delete** button in the table row.

### Supported Cards

This page contains specific information for each card type. For the **Output 18G Cards**, the following page buttons are available: **OP18 Management**, **OP18 Flink Status**, **OP18 Avm**, and **OP18 Monitoring**.

Similar information is provided for the **Input 18G Cards**. For the **Monitor HD Cards** and **Crosspoint G Cards**, there are page buttons for **Management**, **Flink Status**, and **Monitoring**.

### I/O Table

On this page, the following tables display information on the matrix:

- **Input Table:** Contains an **Index**, a **Label** connected to the matrix, the option to enable an **Input**, a **Locked** value that shows if the input is locked and not accessible, and also a **Notes** section.
- **Output Table:** Contains an **Index**, a **Label** connected to the matrix, the option to enable an **Output**, a **Locked** value that shows if the output is locked and not accessible, a **Notes** section, and a **Connected Input** to indicate to which input the output is connected.

### Matrix

This page contains a matrix that can be used to connect inputs and outputs. You can resize or disable this matrix using the parameters on the **Matrix Configuration** page.

### Matrix Configuration

This page allows you to make configuration changes to the matrix on the **Matrix** page. With the **Number of Inputs** and **Number of Outputs** parameters, you can change the composition of the matrix. The **Matrix Displayed** toggle button allows you to disable the matrix.

If you change these configuration parameters and want an immediate update of the matrix crosspoints and source/destination labels, click the **Refresh** button.

### Frame Controller

On this page, there is a table for each fan, indicating the **Status**, **Temperature**, and **Speed** of that fan. The page also displays the activity of **Q-Link** and **F-Link** (primary and secondary) and the corresponding errors.

## Usage (3.0.0.x)

### General

This page displays general information about the system, such as the **Description**, **Uptime**, **Name**, **Location**, and **Contact** person.

It also contains general software and hardware information, such as the **Card** **Name**, **Creation** **Date**, **Software** **Revision**, **Release** **Number**, **Firmware** **Location**, **Board** **Serial** **Number**, **Board** **Name**, **Board** **Revision**, and **Hardware** **Build** **Number**.

You can also find **System** **Control** parameters here, with information regarding **Frame** **Controller** **Description**, whether the **Frame** **Controller** has been configured, the **Q-link** **Activity**, **Primary** and **Secondary** **F-Linkactivity**, the **Q-Link** **Errors**, the **Quartz** **Errors**, and the **Primary** and **Secondary** **F-Link Errors**.

### Cards

This page displays the **Frame Controller Card Table**.

This table contains information about all the inserted cards on the video router. This information includes the **Card Type**, **Card Address** (IP address, used for polling), **Card Status**, **Card Departure Count**, and **Card Production ID**.

### Fan

This page displays the **Fan Table**.

This table contains information about all of the fans within the chassis. This information includes the **Fan Status**, **Fan** **Temperature**, and **Fan Speed**.

### Timing Plane

This page displays the **Timing** **Plane** **Table**.

This table contains information about all of the timing planes. This information includes the **Timing Plane Reference**, **Timing Plane Switch** **Point**, the **Timing Plane Offset**, and the **Timing Plane Status**.

### Faults

This page displays the **Faults Table**.

This table contains information about all of the faults present on the device. This information includes the **Fault Name**, the **Fault Send Trap State**, and the **Fault Status**.

## DataMiner Connectivity Framework

The **1.0.0.x** range of this connector supports the usage of DCF and can only be used on a DMA with **9.0.3** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

Connectivity for all exported connectors is managed by this connector.

#### Dynamic Interfaces

- **InputTable** is the physical dynamic interface created with the interface type **in**.
- **OutputTable** is the physical dynamic interface created with the interface type **out**.
