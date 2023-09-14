---
uid: Connector_help_Double_D_Electronics_DDA219-C333E
---

# Double D Electronics DDA219-C333E

The connector monitors the activity of the **Double D Electronics DDA219-C333E** controller.

## About

The connector has a serial communication to the **Double D Electronics DDA219-C333E** and allows the end user to control and monitor the switch configuration.

In addition to the previous, the connector uses two timers: one polling every 10 seconds that retrieves general information from the device and its switches and one that polls every hour for slowly varying information.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | DDA219 V1.15                |

## Installation and configuration

### Creation

Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600.*
  - **Databits**: Databits specified in the manual of the device, e.g. *7.*
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1.*
  - **Parity**: Parity specified in the manual of the device, e.g. *No.*
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No.*

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device.

## Usage

### General Page

On the general page, the user can observe some general information from the device on the left such as the **Software Version;** the **Device** **Name**; the **Maximum** **Number of Supported Switches** and the **Maximum Number of Supported Chains**.

In addition to the previous, the user can define the device's mode (**Global Device Mode**) and its respective **Control Mode**.

At the right of the page the user can observe if there's any existing alarms regarding: **Active Alarms; Unacknowledged Alarms; PSU 1** and **PSU 2 Alarm.**

Also the **Status of Switch 1** can be viewed on this page and the user can configure the **Selected Input** to X-Pol High band, X-Pol Low band, Y-Pol High band or Y-Pol Low band.
