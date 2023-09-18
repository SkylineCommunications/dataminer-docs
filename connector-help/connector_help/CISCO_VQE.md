---
uid: Connector_help_CISCO_VQE
---

# CISCO VQE

CISCO Visual Quality Experience (VQE) offers service providers a set of technologies and products associated with the delivery of IPTV video services.

## About

SSH is used to retrieve an overview of all channels. The connector also monitors various counters with SNMP.

### Version Info

| **Range** | **Description**  | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version  | No                  | Yes                     |
| 1.0.1.x          | Range for SNMPv3 | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | Unknown                     |

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

#### Serial SSH connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device, by default *22*.

### Configuration of SSH

Configure the SSH settings (**General** page \> **SSH Settings...**) to activate the SSH communication.

## Usage

### General

This page displays general system information (SNMP).

Via the **Config Parent** page button, you can add/delete **Belgacom Audience Data Collector** elements to/from the **Parent Table**. The following information is forwarded towards these parent elements: **Number of Channels**, **Active Channels**, **Inactive Channels** and **Total RTCP Receivers**.

### VQE Channels

This page displays detailed information for each channel, in the **Channel Overview Table**.

For every channel, a separate SSH request is sent to retrieve the detailed information, so it can take some time before the Channel Overview Table is fully loaded. Obsolete entries are deleted after the polling of all channels is done.

The **Channel Overview Table** contains the parameters **Num Continuity Counter Errors Total** and **Continuity Counter Errors** **Rate** (calculated value).

### VQE Counters

This page displays statistics regarding the communication.

### Channel Configuration

This page contains settings for each channel, in the **Channel Config Table**.
