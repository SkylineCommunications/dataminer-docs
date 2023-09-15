---
uid: Connector_help_Honeywell_Notifier_NF3000
---

# Honeywell Notifier NF3000

This connector monitors the **Honeywell Notifier NF3000** and reports any alarms that happen. It also displays information about the panels, zones and devices.

## About

The connector collects data via a **smart-serial** connection. This way, in addition to the normal polling, events sent by the device can also be processed in the connector.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                                   |
|------------------|-------------------------------------------------------------------------------|
| 1.0.0.x          | 7.5+ (4.3+ is likely to also be compatible, but this has not been tested yet) |

## Installation and configuration

### Creation

#### Smart Serial connection

This connector uses a smart-serial connection and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600.*

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

## Usage

### General

This page displays basic device information such as the **Number of Loops**, **Panel Number**, **Operation Mode**, etc.

### Panels

This page contains the **Panel Table**. If a Master/Slave configuration is used, you can find all the basic information in this table.

### Zones

For each panel, this page will list the zones in the **Zone Table**. This table also includes information on how many **Sensors** and **Modules** there are.

### Devices

On this page, you can find the **Device Table** with the alarm states, the **Device Details Table** and the **Device Errors Table**.

### Events

This page displays the **Event Table.** If a problem occurs on the device, an event will be sent. This event is processed by the connector and displayed in this table.

To make sure the table does not grow endlessly, cleanup settings can be configured via the **Cleanup Settings** page button below the table.

### Communication

This page displays the communication state of device. If the connector cannot reach the device, the **Timeout Status** will be set to *Timeout*.

Below this, you can configure how much **Timeout Time** is needed between the **Number of Retries**.
