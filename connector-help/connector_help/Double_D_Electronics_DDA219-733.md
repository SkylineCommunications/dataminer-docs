---
uid: Connector_help_Double_D_Electronics_DDA219-733
---

# Double D Electronics DDA219-733

This driver monitors the activity of a **Double D Electronics DDA219-733** switch controller. It uses serial communication and makes use of the "Printable ASCII" communication protocol. You can both check information from the device in the driver and control the switch configuration.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device (default: *7*).
  - **Stopbits**: Stopbits specified in the manual of the device (default: *1*).
  - **Parity**: Parity specified in the manual of the device (default: *Even*).
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

### General

This page displays information about the **Software Version**, the **Device Name**, the **Maximum of Switches Supported** and the number of **Main Chains Supported**.

It also allows you to set the **Control Mode** (*Remote* or *Local*) and the **Global Device Mode** (*Auto* or *Manual*).

In addition, you can view the state of the **Alarms** and the **Chains connections**, and there is a button to **Acknowledge** the alarms.

The **Chain Status** subpage displays the **Connection**, the **Alarm Inputs**, a **Low Power Alarm**, an **Auxiliary Input Alarm** and the **Muted** state of the chains supported by the device.

### Switches

This page displays information about the **Status**, the **Position**, the **Locked** state and the **Alarm** of the different switches of the device.

On the subpages, you can change the **Position** of the switches.
