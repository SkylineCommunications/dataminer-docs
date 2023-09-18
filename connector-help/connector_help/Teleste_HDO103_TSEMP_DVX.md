---
uid: Connector_help_Teleste_HDO103_TSEMP_DVX
---

# Teleste HDO103 TSEMP DVX

The HDO103 is an RF measurement switch. This switch module has two inputs with RF wideband detectors and one output.

## About

This connector is used to control and monitor the HDO103 module using the DVX bus.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  -**IP address/host**: The polling IP of the Moxa connected to the DVX bus, e.g. *10.11.12.13.*
  - **IP port**: The port of the local TCP connection used by the Moxa, e.g. *4001.*
  - **Bus address**: The bus address of the connected device, in the format *X.Y* (where X = Rack Number, Y = Slot Number).

## Usage

### General

On this page, you can find general information and statistical information (uptime, temperature, etc.) on the module.

Click the **Alarm Limits** page button to view or configure the analog and discrete alarm limits.

### Switch

This page displays the **Input 1** and **Input 2 Measured RF Power**, together with their **Power Reference**, which can be set with the **Store As Reference** button.

You can also configure the **Routing Mode** and **Status Switch** on this page.

Click the **Normalized Values** page button to configure the normalized value of the RF parameters. With the **Normalize** button, you can copy the current values to the normalized RF parameters.
