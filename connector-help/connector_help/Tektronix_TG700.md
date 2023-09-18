---
uid: Connector_help_Tektronix_TG700
---

# Tektronix TG700

This connector monitors the nodes in the system and polls all the supported modules.

## About

The connector schedules all polling so that no polling happens at the same time. Users can delete any removed module manually or select to have it removed automatically. If a response times out, the card will go in timeout. By changing the View Name indicated in the element, you can have the created DVEs added in a different parent view. Finally, there is a Control Center page, which can be used to send a query or set a parameter.

### Version Info

| **Range** | **Description**         | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------|---------------------|-------------------------|
| 1.0.0.x          | Virtual version         | No                  | No                      |
| 1.0.1.x          | Serial connection added | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 5.6                         |
| 1.0.1.x          | 5.6                         |

### Exported connectors

| **Exported Connector**                                                      | **Description**        |
|----------------------------------------------------------------------------|------------------------|
| [Tektronix TG700 - GPS7](xref:Connector_help_Tektronix_TG700_-_GPS7) | GPS module             |
| [Tektronix TG700 - SDI7](xref:Connector_help_Tektronix_TG700_-_SDI7) | Video generator module |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device.
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

## Usage

### General

This table displays the **Nodes Table**, which lists the **Name**, **Port**, and **State** of each of the nodes.

### GPS

This page displays the **GPS Table**, which allows you to manually remove a card, change the **View Name** or check the **Overall Severity**.

The page also allows you to enable or disable **Auto Deletion**, and contains a button that can be used to **Remove All Cards** from the table.

### SDI

This page contains the **SDI Table**, which allows you to manually remove a module and change the **View Name**.

### Chassis

This page displays the **Value Tables** of all the supported DVEs. These tables are the raw version of the parameters available in the created DVEs.

### Control Center

On the left side of this page, you can send a query or set a value. To do so:

1. Select the **Current Module** where the query or set should be applied.

1. To send a query, add the **Command** (without a colon at the beginning; optionally concatenating multiple queries).

   To set a value, fill in the **Set Value** parameter.

1. Click the **Send Command** button. The response will be displayed below.

The right side of the page contains buttons with **common commands** for general control of the system. However, be careful when you use these commands, as these can cause a complete timeout of the system.
