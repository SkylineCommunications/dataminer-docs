---
uid: Connector_help_Pro-Bel_Cygnus
---

# Pro-Bel Cygnus

This driver allows to monitor and configure the the Pro-Bel Cygnus routing system.

## About

This driver allows to monitor and configure the Pro-Bel Cygnus routing system, using smart-serial communication. The driver has two smart-serial connections which are set up as redundant polling.

### Ranges of the driver

In this subsection, insert a table with four columns, listing the different ranges of the driver. In the second column, add a short description for each range that explains why it was changed. The two narrower columns on the right must indicate whether the range features DCF integration and whether it is Cassandra compliant.

In the following example, the initial version had the range 1.0.0.x. A new firmware version was no longer compatible with the initial driver version, so a new range was created: 1.1.0.x. Based on this firmware, a branch (custom version) was made: 2.1.0.x. That version also got new firmware that was no longer compatible with previous versions: 2.2.0.x.

| **Driver Range** | **Description**      | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version      | No                  | Yes                     |
| 2.0.0.x          | Smart Serial version | No                  | Yes                     |

### Supported firmware versions

Style: Heading 3 Accent 1

In this subsection, insert a table with two columns, and set the column widths to 50 percent. In the table, list the firmware versions that are fully compatible with the driver, together with the driver ranges. If multiple firmware versions are compatible with one driver range, add them in the same row, but on different lines. See the following example:

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | ?                           |
| 2.0.0.x          | ?                           |

## Installation and configuration

### Creation

#### Serial connection - Main

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: 38400
  - **Databits**: 8
  - **Stopbits**: 1
  - **Parity**: Even
  - **FlowControl**: *No*

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: 1

#### Serial connection - Secondary

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: 38400
  - **Databits**: 8
  - **Stopbits**: 1
  - **Parity**: Even
  - **FlowControl**: *No*

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: 1

## Usage

### Matrix

This page gives an overview of the current matrix configuration. The number of inputs and outputs can be configured in the **Number of Inputs** and **Number of Outputs** parameters, respectively.

The Output Table gives an overview of which input is connected to which output.

### MON Overview

The **Set MON Name** parameter can be used to add an entry to the **MON Overview** table. Once an entry has been added to the **MON Overview** table, the **Output Table** will be polled.

### Advanced

This page allows to set advanced switching using the **Advanced Switching** parameter.

### Matrix Status

On this page an overview is given of the crosspoints (**Crosspoints**), the crosspoints buffer (**Crosspoints Buffer**), and status information (**Status Information** and **Communication Status**).
