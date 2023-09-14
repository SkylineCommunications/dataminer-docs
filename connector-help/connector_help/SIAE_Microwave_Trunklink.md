---
uid: Connector_help_SIAE_Microwave_Trunklink
---

# SIAE Microwave Trunklink

The **SIAE Microwave Trunklink** series provides Native IP and Native SDH connections. It is designed as a solution for a wide range of applications in access networks and backbone areas.

## About

This connector connects to the device and allows you to configure and monitor all features available in its MIB.

### Version Info

| **Range** | **Description**               | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version               | No                  | Yes                     |
| 1.0.1.x          | Lite polling, DCF integration | Yes                 | Yes                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *NMS5UX*.
- **Set community string**: The community string used when setting values on the device, by default *NMS5UX*.

## Usage

### Condition

This page contains parameters that allow you to monitor the condition of each of the features of the device.

### Control

This page contains parameters that allow you to control certain settings of the device, such as the **NE Time**.

### Provisioning

On this page, you can set all the features related to the preparation of the device to deliver its services to the network.

### Performance

This page displays information on the performance of the device.

### Traps

On this page, traps sent by the device are displayed in the **Trap Table** and in the **Notification History Table**.

### Web Interface

This page provides access to the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **1.0.0.x** connector range of the **SIAE Microwave TrunkLink** protocol supports the usage of DCF from version **1.0.1.1** onwards, and can only be used on a DMA with **9.0 CU5** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

Fixed interfaces

Physical fixed interfaces:

- **Gesw1**: has 4 interfaces (**Gesw1-1, Gesw1-2, Gesw1-3, Gesw1-4**) of the type (**inout**).
- **Gesw2**: has 4 interfaces (**Gesw2-1, Gesw2-2, Gesw2-3, Gesw2-4**) of the type (**inout**).

#### Dynamic Interfaces

Virtual dynamic interfaces:

- **GbE**: For all GbE cards that are available in the **Inventory Table** on the **Hardware Inventory Page**, an interface is made. All these interfaces are of type **inout**.
- **STM-1-in**: For all STM-1 cards that are available in the **Inventory Table** on the **Hardware Inventory Page**, an interface is made. All these interfaces are of type **in**.
- **STM-1-out:** For all STM-1 cards that are available in the **Inventory Table** on the **Hardware Inventory Page**, an interface is made. All these interfaces are of type **out.**

### Connections

#### Internal Connections

- All **GbE** interfaces are connected to the **4** interfaces of the corresponding **Gesw** Card. (E.g. if **Gp1 P** is a GbE card, the interface **GbE 1** is created and connected to **Gesw1-1, Gesw1-2, Gesw1-3, Gesw1-4.**)
- Every **STM-1-in** interface is connected to the corresponding **STM-1-out** interface**.**
