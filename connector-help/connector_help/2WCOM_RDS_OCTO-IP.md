---
uid: Connector_help_2WCOM_RDS_OCTO-IP
---

# 2WCOM RDS OCTO-IP

The **2WCOM RDS OCTO-IP** is an RDS Data Multiplexing Solution for RDS Networks. The device supports SNMP alarming for fast signaling of network problems.

For more detailed information about the device, consult the following website: <http://www.2wcom.com/en/products/rds-solutions/rds-octo-ip-serverrouter.html>.

## About

This device is capable of sending SNMP traps. Those traps are sent in case of system failures and are also sent as a heartbeat. The connector interprets these traps in order to determine the status of the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

On this page, you can find information about the received **traps**, i.e. the message and the last time the trap was received.

There is also a **Configuration** page button, which allows you to set:

- The input ports number to match the information sent in the trap from each input.
- **Clears Alarm after**, to set the time after which the alarm is cleared.
- **Keepalive Time**, which works as a heartbeat from the device. If no trap is sent within the configured timespan, an alarm is raised.
- The time intervals for the encoder alarms to be cleared.

The **Alarms** page button displays the state of the input streams and RDS data, the service start/stop and the output queue.

### Traps Log

On this page, the received traps are logged in a table. You can change how many traps are displayed via the **Settings** page button.

### Service Status

On this page, you can start and stop a service in a Microsoft Server.
To do so, first click **Refresh Servers** and select a Microsoft Server from the list **Microsoft Servers**. Then click **Refresh Services** to update the list of services, and select the service from the **Server Services**. To poll the status of the service, set the **Poll Service Status** parameter to *Enabled*. Stop or start the service by clicking the **Start/Stop Service** parameter. Use the **Service Log** page button if necessary.

In addition, on this page you can also retrieve information about the status of two OCTO-IP devices working in redundancy. To do so, set the **Element ID Redundant OCTO-IP** number.

### Encoder

On this page, you can find information about the received **traps** for the Encoder, i.e. the message, the state, and the last time the trap was received.
