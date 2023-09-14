---
uid: Connector_help_Symmetricom_4370A
---

# Symmetricom 4370A

The Symmetricom 4370A connector can be used to monitor and control the Symmetricom 4370A master time generator.

The connector polls data from the Symmetricom 4370A via SNMP. It also handles traps, by parsing a trap for the OID of the parameter that causes the trap and repolling the parameter for an updated value.

## About

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0                         |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device, by default 161.
- **Get community string**: The community string used when reading values from the device (default: public).
- **Set community string**: The community string used when setting values on the device (default: private).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the data pages detailed below.

### General

This page contains general information about the device such as its Serial Number, EUID, Manual Rev, Temperature and more.

The page also contains a page button that opens a page with power supply information.

### Power Supply

This page contains critical information about each power supply the device has, e.g. Type, Serial Number and Status.

### Slot

This page contains two tables, a Slot Table and Error Module Table. The Slot Table contains important information about the different slots of the device such as Module Type, Errors, and Latched Errors. The Error Module Table contains the errors that have occurred on the device.

### Reference Clock

This page contains a table with important information about the reference clock of the device, such as Reference Clock Locked and Reference Clock Status.

### GPS

This page contains several tables with information about the GPS component of the device:

- The **GPS Configuration Table** is used to configure important GPS parameters such as the Position Mode, Latitude DMS, and Longitude DMS.
- The **GPS Instance Table** is similar to the GPS Configuration Table and allows you to view and configure other important GPS parameters such as the Model, Type, and Antenna Mask.
- The **GPS Channel Table** contains information about the different GPS channels, such as PRN and Strength.

### Input

This page contains two tables with information about the input component of the device:

- The **Input Configuration Table** allows you to configure important input parameters such as Fiber Alarm, Holdover Time and Preferred Input.
- The **Input Instance Table** shows important information about the input module such as Fiber Status, Peer GPS Status, and Current Input.
