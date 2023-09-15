---
uid: Connector_help_Motorola_GX2-CM100B-R
---

# Motorola GX2-CM100B-R

The **Motorola GX2-CM100B-R** connector is an SNMP-based connector used to monitor and configure the **Motorola GX2-CM100B-R.**

## About

This connector provides a monitoring interface for the **Motorola GX2-CM100B-R** chassis.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |
| 2.0.0.x          | DVE focused     | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 2.0.0.x          | D                           |

## Usage

### General

This page displays general information about the card. **Unit Name**, **Module Type**, **Firmware** and **Hardware** version, **IP Address** and **Physical Address** are some of the parameters that can be found here.

In addition, there are two page buttons:

- **Downloads:** Opens a page with the parameters **Downloaded Slots**, **Auto Download Reset**, **Download Filename**, **Switch Firmware Bank** and **Download State**.
- **Security:** Opens a page with the parameters **Mode**, **Factory Password**, **Operator Password**, **Read Only Password**, **Remote Only Password**, **Local Only Password**.

### Controller

This page displays the **Temperature**, **Digital Mode**, **Digital Reset Slot**, **Shelf Identifier** and **Reset Alarm** parameters.

### Alarms

This page contains all **Status** parameters.

### AMC

This page displays the **Controller** **AMC Table** and **Auto Quick Swap Interval**.

### Diagnostic

This page contains the parameters **LED Test Pattern**, **Fan Test Mode**, **Relay Test Mode**, **Relay Control**, **Slot Poll Mode**, **Boot Count**, **Object Table Data**, **Reset System Time** and **Alarm Slot**.

It also contains the **Controller Diagnostic Table**, which includes a column where you can reset both the **success** and **failure** values.

### Factory

This page displays **CRC Parameters**, **Flash Banks** and **Flash Counters**.

### Network

This page contains all parameters related to IP Addresses, TFTP Server and Shelf Serial Number.

It includes two page buttons:

- **ISDN**: Opens a page with the **Mode**, **Modem IP Address**, **Trap Timeout**, **Ping Timeout** and **Backoff Timer**.
- **Traps**: Opens a page with the **Trap Destination IP Addresses**.

### Traps History

This page displays both the **Trap History** and the **Trap Receiver** table.

### Web Interface

This page displays the webpage of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
