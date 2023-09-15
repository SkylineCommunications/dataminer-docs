---
uid: Connector_help_Rohde_Schwarz_NetCCU_DTT_Remodulator
---

# Rohde Schwarz NetCCU DTT Remodulator

This connector is developed for devices such as the **Rohde Schwarz NetCCU DTT** **Remodulator**. It polls several SNMP parameters and displays them on different pages.

## About

The SNMP parameters are polled using three timers, and displayed on several pages.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.20.0                      |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP address/host**: The polling IP of the device, e.g. *10.145.1.12*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### General Page

This page displays status parameters of the device, such as the **Software Version**, **Hardware Version**, **Power** **Supply**, etc.

The **LITE** **Protocol** option can be enabled in order to keep polling to a minimum, so that only important parameters (indicated as "LITE" below) are polled.

The page also contains page buttons to open the following subpages:

- **Traps Configuration**
- **Software Update**
- **NTP Server**
- **Device Info**

### DVB Receiver Page

This page contains status parameters of the DVB receiver, such as the **Software Version**, **Hardware Version**, **Input Mode**, etc.

The page also contains a page button to open the **Events Receiver Table** **(LITE)** subpage.

### DVB Receiver - Input 1 Page

This page contains information related to the first input of the DVB receiver, such as the **Input Level (LITE)**, **Input Center Frequency (LITE)**, **BER**, etc.

### DVB Receiver - Input 2 Page

This page contains information related to the second input of the DVB receiver, such as the **Input Level (LITE)**, **Input Center Frequency (LITE)**, **BER**, etc.

### Transmitter Page

This page displays the transmitter **Frequency (LITE)** and the **TX Forwarded Power (LITE)**.

The page also contains a page button to open the **Transmitter Events** **(LITE)** subpage.

### Exciter Status Page

This page contains the **Exciter Status Table** and **Exciter Input Table**.

### Exciter Settings Page

This page contains general settings for the exciter.

## DataMiner Connectivity Framework

From version **1.0.0.4** of this connector onwards, the usage of DCF is supported and the connector can only be used on a DMA with **8.5.8.5** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **Input 1** of type **in**
- **Input 2** of type **in**
- **Output** of type **out**

### Connections

DCF only works if **LITE** polling is disabled.

#### Internal Connections

- If the **selected input** is **Input 1** (depending on the **Exciter Input Table**), an internal connection is created between **Input 1** and the **output** with the following properties:
  - **Status** connection property of type **generic** with value **Up**.
- If the **selected input** is **Input 2** (depending on the **Exciter Input Table**), an internal connection is created between **Input 2** and the **output** with the following properties:
  - **Status** connection property of type **generic** with value **Up**.
