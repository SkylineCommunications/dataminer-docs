---
uid: Connector_help_British_Telecom_Strobe
---

# British Telecom Strobe

This connector is designed to monitor a custom transport stream monitoring device from British Telecom.

## About

This is a **serial** connector, which communicates with the device via **SSH commands**.

The connector uses a second TCP connection to receive syslog messages. These messages are used as traps, to immediately update the Channels table when there is a status change.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

#### Serial Syslog Connection

This connector uses a serial connection to receive syslog messages and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device, by default *514*.

### Configuration

Before the element will be able to poll data from the device, the **SSH credentials** need to be filled in on the **Configuration page**.

## Usage

### General

The **Heartbeat** parameter on this page indicates how long it has been since the last syslog message with message code 1001 was received. This can be used to monitor if the probe is still processing.

The page also displays the MLX script alarm parameters.

### Channels

This page contains the **Channels table**, listing the following information for each channel: **ID**, **Name**, **Multicast IP**, **Multicast Port**, **Source IP**, **Stan**, **MLX** and **State**. You can change the State of each channel to *Auto*, *On* or *Off*.

The columns in this table are polled via SSH, but are also updated based on the received Syslog messages.

### Configurations

This page contains the **Username** and **Password** parameters, which **must be filled in** for the protocol to successfully log in to the device via **SSH**.

It also contains the **Connection Status** parameter, which show the status *Connected*, *Invalid Response* or *Timeout*, and the **Last Changing State Response**, which shows the last received response after a channel state change.

Note: It takes about 30 seconds to log in to the device. As such, it is normal for the connector to only show information after this time. It also takes around 5 seconds to implement a set and receive the corresponding feedback message.
