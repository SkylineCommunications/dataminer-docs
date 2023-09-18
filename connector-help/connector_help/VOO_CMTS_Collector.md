---
uid: Connector_help_VOO_CMTS_Collector
---

# VOO CMTS Collector

The **VOO CMTS Collector** is a combination of a smart-serial connector, SNMPv2 and serial connector.

## About

This connector is used to collect data from the CMTS devices at VOO. This data is polled by using SNMP and IPDR commands and is sent to the relevant **CPE Manager** and **MTA Collector.** In other words, the connector is used as a control center to parse and distribute information from approximately 60 000 **CPEs**.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) and a smart-serial connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*
- **Device address**: Not needed.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *CADMIUM*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The port of the connected device. By default, this is *4737*.
- **Bus address**: The **Collector Name** should be filled in here. By default, this is *DMA-COL-01*.

**SSH CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: Default is 22.

## Usage

### General

This page contains general information related to the device. In addition, you can extract a **Debug File** with all the **MAC Adresses and Channels** for each **CPE**. The **IPDR Templates and Sessions** are also displayed and can be requested.

Another important parameter on this page is **IPDR Data Timeout.** This parameter defines after how much time the connection is considered to be lost. The value of **Seconds Since Last Data** is compared with this value.

### Logging

This page contains the **Logging Table**, which consists of all **IPDR Administrator Error/Log Messages.**
