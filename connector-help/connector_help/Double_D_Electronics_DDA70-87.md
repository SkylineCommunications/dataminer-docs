---
uid: Connector_help_Double_D_Electronics_DDA70-87
---

# Double D Electronics DDA70-87

This driver can be used to display and configure information of the **Double D Electronics DDA70-87** WG Switch.

## About

This protocol uses a serial connection to monitor and control the **Double D Electronics DDA70-87**.

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V2.65f 18.07.05        |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

This driver uses a serial connection and needs the following user information:

#### Serial Connection - Main

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, default 9600. Range from: 1200, to: 115200.
  - **Databits**: Databits specified in the manual of the device, default *7*.
  - **Stopbits**: Stopbits specified in the manual of the device, default *1*.
  - **Parity**: Parity specified in the manual of the device, default *even*.
  - **FlowControl**: FlowControl specified in the manual of the device, default *No*.

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device.

## How to Use

### General Page

This page contains generic device information, such as the **Software Version**, **Device Name** and **General Alarms**.

When commands are sent to the device, the response status (error/ok) is displayed on this page. The button **Acknowledge** can be used to clear this status.

### Switches Page

On this page, you can monitor and configure the status and positions of the switches.

### Chains Page

On this page, you can see the status of the chains on the device.
