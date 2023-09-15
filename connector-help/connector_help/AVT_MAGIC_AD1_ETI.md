---
uid: Connector_help_AVT_MAGIC_AD1_ETI
---

# AVT MAGIC AD1 ETI

With this connector, you can gather and view information from the device **AVT MAGIC AD1 ETI**.

## About

This connector uses SNMP to monitor the **AVT MAGIC AD1 ETI** device.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.64.31.16*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general information about the device, such as the **System Description**, **Up Time**, **Firmware Version** and **System Temperature**.

### ETI Monitoring Page

This page displays information regarding the ETI status. This informations is divided in two tables, the **Sub-Channel Table** and the **Service Table**.

### Alarms Page

On this page, you can find the **System Alarm Table** and **Application Alarm Table**, which display the system alarms and application alarms respectively.

### LAN Interfaces Page

This page displays a table with the LAN interfaces of the device.
