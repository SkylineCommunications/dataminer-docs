---
uid: Connector_help_Supermicro_SuperDoctor_5
---

# Supermicro SuperDoctor 5

The **Supermicro SuperDoctor 5** connector is an SNMP-based connector that can be used to monitor and configure the **Supermicro SuperDoctor 5 Monitoring Platform**.

## About

This connector provides a monitoring and configuration interface for the **Supermicro SuperDoctor 5 Monitoring Platform**.

The Supermicro SuperDoctor 5 Monitoring Platform can be used to monitor the system health and availability of hardware of target nodes in data centers in real time and provide alerts to administrators.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.1c                        |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general information on the SuperDoctor 5, including **SuperDoctor**, **Baseboard**, **BIOS** and **Operating System** parameters.

### Health Info

This page displays a table listing the different **Monitor Devices** installed in the **Supermicro SuperDoctor 5 Monitoring Platform**.

A monitor device can be **Fan**, **Voltage**, **Current**, **Power**, **Temperature** or **Status**. Measurement values are shown for each device.

Measurement **high limits** can be configured for **Temperature,** **Voltage, Current** and **Power** devices only. Measurement **low limits** can be configured for **Fan,** **Voltage, Power** and **Current** devices only. The **divisor** can be configured for **Fan** devices only.

With a toggle button, you can set the monitoring state of each device to ***Monitored*** or ***Not Monitored***.

The parameter **Status Summary** shows the all-in-one status of the system.

### Performance

This page displays the **CPU** and **Memory** tables and associated parameters.

### Disk Info

This page displays the **Disk** table and associated parameters.

### RAID

This page displays the **RAID** tables, including **Adapter**, **BBU**, **Virtual Devices** and **Physical Devices**. Each table can be enabled or disabled with the corresponding toggle button.

### Logs

This page displays the **Log** tables, including **CECC**, **UECC**, **Post** and **CPU**. Each table can be enabled or disabled with the corresponding toggle button.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
