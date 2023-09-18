---
uid: Connector_help_Prodys_Prontonet
---

# Prodys Prontonet

This is an SNMP protocol for the Prodys Prontonet device. ProntoNet is a multi-network audio codec, with a wide range of compression algorithms.

The protocol is designed to retrieve information and receive traps.

## About

The connector needs an SNMP connection to retrieve information from the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: e.g. *10.253.116.62*
- **Device address**: not required

SNMP settings:

- **Port number**: *161*
- **Get community string**: *public*
- **Set community string**: *private*

## Usage

### Status

This page contains general parameters related to the device, such as **Name**, **Serial Number**, **Backup Status**, **Net Type**, **Temperature**, **Fan Speed**, **Main** and **Backup Voltage**, **5 V** and **3.3 V** **Voltage** and **Vumeter**.

There are two tables, one containing the **Alarm History** and the other showing the **Line Status**, **Line Connection** and **Line Remote Number**.

At the bottom of the page, a button provides access to the **Streaming** table, which displays information related to the **Rx Buffer**, **Jitter**, **Lost Packets**, **Disordered Packets** and **Recovered Packets**.

### Encoder - Decoder

This page contains a table for the encoder and a table for the decoder, both showing the **Algorithm**, **Mpeg Layer**, **Aac Mode**, **Frequency**, **Bitrate**, **Bits Per Sample**, **Law**, **Crc State**, **Aux Data State** and **Decoder Status**.
