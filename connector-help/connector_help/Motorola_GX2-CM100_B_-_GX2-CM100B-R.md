---
uid: Connector_help_Motorola_GX2-CM100_B_-_GX2-CM100B-R
---

# Motorola GX2-CM100 B - GX2-CM100B-R

The **Motorola GX2-CM100 B - GX2-CM100B-R** connector is an SNMP-based connector used to monitor and configure the **Motorola GX2-CM100B-R**.

## About

This connector provides a monitoring interface for the **Motorola GX2-CM100B-R** module.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 2.0.1.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 2.0.1.x          | P                           |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the parent connector [Motorola GX2-CM100 B](xref:Connector_help_Motorola_GX2-CM100_B), from version 2.0.1.1 onwards.

## Usage

### General

This page displays general information about the card, including the **Unit Name**, **Module Type**, **Firmware** and **Hardware** **Version**, **IP Address** and **Physical Address**.

The page also contains two page buttons:

- **Downloads**: Displays the parameters **Downloaded Slots**, **Auto Download Reset**, **Download Filename**, **Switch Firmware Bank** and **Download State**.
- **Security**: Displays the parameters **Mode**, **Factory Password**, **Operator Password**, **Read Only Password**, **Remote Only Password**, **Local Only Password**.

### Controller

This page displays the current **Temperature**, the **Digital Mode**, the **Digital Reset Slot**, the **Shelf Identifier** and the **Reset Alarm** parameter.

### Alarms

This page contains all **Status** parameters.

### AMC

This page displays the **Controller** **AMC Table** and the parameter **Auto Quick Swap Interval**.

### Diagnostic

This page displays the parameters **LED Test Pattern**, **Fan Test Mode**, **Relay Test Mode**, **Relay Control**, **Slot Poll Mode**, **Boot Count**, **Object Table Data**, **Reset System Time**, **Alarm Slot** and **Controller Diagnostic Table**. The latter contains a column that allows you to reset both the **success** and the **failure** values.

### Factory

This page displays **CRC Parameters**, **Flash Banks** and **Flash Counters**.

### Network

This page contains all the parameters related to IP addresses, the **TFTP Server** and the **Shelf Serial Number**.

It includes two page buttons:

- **ISDN**: Displays the **Mode**, **Modem IP Address**, **Trap Timeout**, **Ping Timeout** and **Backoff Timer**.
- **Traps**: Displays the **Trap Destination IP Addresses**.

### Traps History

This page displays both the **Trap History** and the **Trap Receiver** table.

### Web Interface

This page displays the webpage of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
