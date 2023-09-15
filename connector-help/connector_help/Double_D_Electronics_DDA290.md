---
uid: Connector_help_Double_D_Electronics_DDA290
---

# Double D Electronics DDA290

This connector monitors the activity of a **Double D Electronics DDA290** redundancy controller.

The DDA290 is a general purpose switching and redundancy controller (including LNA/LNB controllers) providing a graphical user interface. The controller can support up to 7 waveguide/coaxial switches and three HPAs, optionally configured in a 1+1 or 1+2 redundant configuration.

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
| 1.0.0.x          | DDA290 V1.24 dev 6          |

## Installation and configuration

### Creation

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual and the web interface of the device. Default: *9600.*
  - **Databits**: Databits specified in the manual and the web interface of the device. Default: *7.*
  - **Stopbits**: Stopbits specified in the manual and the web interface of the device. Default: *1.*
  - **Parity**: Parity specified in the manual and the web interface. Default: Even*.*
  - **FlowControl**: FlowControl specified in the manual and the web interface of the device. Default: *No.*

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. Default: *4005*.
  - **Bus address**: The bus address of the device. Default: *A*.

## Usage

### General

This page displays information about the **Software Version**, the **Device Name**, the **Maximum of Switches Supported** and the number of **Main Chains Supported**.

On this page, you can define the **Control Mode** (*Remote* or *Local*) and the **Global Device Mode** (*Auto* or *Manual*).

In addition, you can also view the state of the **Alarms** and the **Chains connections**, and there is a button to **Acknowledge** the alarms.

### Chains

Among others, this page displays the **Connection**, the **Alarm Summary**, the **Input** **Alarm**, a **Low Power Alarm**, an **Auxiliary Input Alarm** and the **Muted** state of the chains supported (up to 2 + 1 standby) by the device.

### Switches

This page displays information about the **Position**, the **Locked** state and the **Alarm** of the different switches (up to 2) of the device.

The page also allows you to change the **Position** of the switches.

### Web Interface Page

This page, when using an interface connection, displays the web interface of the device. The client machine has to be able to access the device. If not, it will not be possible to open the web interface.
