---
uid: Connector_help_Axon_Tracs2_Compliance_Recorder
---

# Axon Tracs2 Compliance Recorder

This connector is used for the basic monitoring of the Axon Tracs2 Compliance Recorder.

## About

With this connector, it is possible to monitor the **hard disks**, **channel information** and **connectivity status** of the **Axon Tracs2 Compliance Recorder**. This information is polled via SNMP.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.9.2.r1.588                |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General Page

This page displays the **ID of the recorder** and **status information**, including the following statuses:

- **LTC status**
- **NTP status**
- **Network status**
- **Raid status**

### Hard Disk Slots Page

This page contains the **Hard Disk Table**, which lists all the drives connected to the device, displaying any **problems** as well as the **S.M.A.R.T. health status** of the drives.

### Channels Page

This page contains the **Channel Table**. This table displays all the media channels that are configured in the device.

## Notes

Only basic monitoring can be done with this connector. Advanced features of the device are currently only available via the Axon Tracs2 Compliance Recorder client software.
