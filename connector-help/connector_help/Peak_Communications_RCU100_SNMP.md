---
uid: Connector_help_Peak_Communications_RCU100_SNMP
---

# Peak Communications RCU100 SNMP

The **Peak Communications RCU100 SNMP** connector can be used to display and configure information of the Peak Communications RCU100 SNMP switches.

## About

An **SNMP** connection is used in order to retrieve and configure the information of the device.

In addition, the connector offers several possibilities for **alarm monitoring** and **trending** of the supported Peak switches.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 4.99                        |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: The device address.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general information about the device, such as the **System Name**, **System Description**, **Remote Status** and **OS Version**.

### Network

On this page, you can view and configure network parameters. The page also contains quick information about the **Ethernet Setup**.

Page buttons provide access to the following subpages:

- **IP Tables Page**: Contains the **IP Route Table**, which shows routing protocol information, and the **IP Net To Media Table**.
- **IP Extender Page**

### Redundancy

This page shows the **Redundancy Mode** used, the **Status** of the device and also the **Attenuator**.

### Peak RCU100 Module

This page displays an overview of the **Unit A** and **Unit B** status, the **Band** used and the **Alarm Status**.

### Faults Module

This page contains the **Faults Table**, which displays alarms and complete information about the origin of faults.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
