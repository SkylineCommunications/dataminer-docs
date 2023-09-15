---
uid: Connector_help_Double_D_Electronics_DDA282
---

# Double D Electronics DDA282

This connector monitors the activity of a **Double D Electronics DDA282** redundancy controller.

The DDA282 is a general purpose controller, primarily intended for 2+1 switching systems using coaxial or waveguide switches, and includes automatic redundancy facilities.

## About

This connector uses serial communication with the device. It makes use of the "Printable ASCII" communication protocol.

It displays information from the device and allows the user to control the switch configuration.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | DDA282 V1.16                |

## Installation and configuration

### Creation

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device.

## Usage

### General

This page displays information about the **Software Version**, the **Device Name**, the **Maximum of Switches Supported** and the number of **Main Chains Supported**.

On this page, you can define the **Control Mode** (*Remote* or *Local*) and the **Global Device Mode** (*Auto* or *Manual*).

In addition, you can also view the state of the **Alarms** and the **Chains connections**, and there is a button to **Acknowledge** the alarms.

### Chains

Among others, this page displays the **Connection**, the **Alarm Inputs**, a **Low Power Alarm**, an **Auxiliary Input Alarm** and the **Muted** state of the chains supported by the device.

### Switches

This page displays information about the **Status**, the **Position**, the **Locked** state and the **Alarm** of the different switches of the device.

The page also allows you to change the **Position** of the switches.
