---
uid: Connector_help_Cobham_PRORXB_SNMP
---

# Cobham PRORXB SNMP

This connector uses SNMP in order to communicate with the **Cobham PRORXB**, a Broadcast Receiver/Decoder device.

## About

With this connector, you can monitor the **Cobham PRORXB** receiver/decoder device using SNMP. Generic parameters, receiver parameters and event parameters are displayed.

The bandwidths, lock statuses and power status are polled every 10 seconds. The other parameters are polled every minute.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.150.3.3*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *public*.

## Usage

The connector contains 4 pages.

### General

This page displays general information about the device: **Power Status**, **Serial Number**, **Version Number** and **Temperature**.

### Pro RX

This page contains 7 parameters for each of the two receivers: **Frequency**, **Bandwidth**, **FEC** **Rate**, **Lock** **Status**, **GPS** **Valid**, **GPS** **Latitude** and **GPS** **Longitude**. The bandwidths and lock statuses are polled every 10 seconds, along with the Power Status from the General page. The other parameters of this connector are polled every minute.

### Event

This page displays all the parameters that are related to events, i.e. the **ID**, **Description**, **Type**, **Severity**, **Time**, **Root** **Time**, **Unit** **Name**, **Unit** **Address**, **Node** **Name** and **Node** **Value**.

### Web Interface

On this page, you can view the web interface of the device. However, the client machine has to be able to access the device. Otherwise, it will not be possible to open the web interface.
