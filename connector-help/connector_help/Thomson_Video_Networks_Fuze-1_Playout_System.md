---
uid: Connector_help_Thomson_Video_Networks_Fuze-1_Playout_System
---

# Thomson Video Networks FUZE-1 Playout System

This connector will be use to monitor FUZE-1 Playout System. FUZE-1 Playout is a completely new approach that integrates the traditional playout functions of a channel in a box (CiaB) with premium-quality encoding and transcoding for broadcast and OTT delivery. Ideal for applications such as ad insertion, branding, disaster recovery, and EAS insertion, FUZE-1 provides a rich playout infrastructure together with the ability to process audio and video either directly in the compressed domain or by going back to baseband and re-encoding.

## About

This connector was designed to work with model **FUZE-1.** It will be possible to monitor the Alarms on this device via **SNMP.**

### Range of the connector

| **Range** | **Description** | **DCF Integration** | **Cassandra Complaint** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Supported firmware version

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 01.05.02                    |

## Installation and configuration

### Creation

Follow the standard procedure for SNMP managed devices. No additional information is required

**SNMP Connection**

- **IP address/host**: The polling IP of the device.

**SNMP Settings**

- **Port number:** The port of the connected device (default: *161*).
- **Get community string:** The community string used when reading values from the device (default value: *public*).
- **Set community string:** The community string used when setting values on the device (default value: *private*).

## Usage

### General

This page contains general information about the device: **Equipment Type**, **Serial Number**, **Software version**, **Agent State**, **Traps Destination Table**.

### Alarms

This page displays two Tables: **Active Traps** and **Closed Traps**.

### Web Page

Displays the web interface of the device.

The client machine has to be able to access the device. If not, it won't be possible to open the web interface.
