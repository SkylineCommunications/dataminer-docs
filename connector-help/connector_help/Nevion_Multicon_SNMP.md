---
uid: Connector_help_Nevion_Multicon_SNMP
---

# Nevion Multicon SNMP

Multicon GYDA is used to configure the latest range of advanced Flashlink signal processing and distribution cards for such functions as video format conversion and audio embedding.

## About

**SNMP** polling is used to retrieve the device information.

This connector will export different connectors based on the retrieved data. A list can be found in the section "Exported Connectors" below.

### Version Info

| **Range** | **Description**                                                        | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version of SNMP connector                                         | No                  | Yes                     |
| 1.0.1.x          | Changed Alarm Table display key.                                       | No                  | Yes                     |
| 1.0.2.x          | Added support for locking and status parameter in the interface table. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 5.0.4                       |

### Exported connectors

| **Exported Connector**                  | **Description**         |
|----------------------------------------|-------------------------|
| Nevion Multicon SNMP - Multicon        | Multicon module         |
| Nevion Multicon SNMP - RZ3 Transmitter | RZ3 Transmitter modules |
| Nevion Multicon SNMP - PWR             | PWR Modules             |
| Nevion Multicon SNMP - ZGR2 Receiver   | ZGR2 Receiver modules   |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: *161*
- **Get community string**: *public*
- **Set community string**: *private*

## Usage

### Module Types

This page contains the module tables for the available types: **Module Table Type GYDA**, **Module Table Type G3HDEO14**, **Module Table Type** **FLPSU** and **Module Table Type** **G3HDOE14**. These tables show the cards' **Module Status**, **Hardware and Software Version**, etc.

It is possible to remove non-active rows in the module tables, either by means of the **Remove** column or by using the **Delete All Removed** button.

### Level Input-Output

This page contains two tables, the **Level Input Table** and **Level Output Table**.

### Alarms

This page displays the **Alarm table**, which shows all alarms for the device.

### Web Interface

This page displays the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
