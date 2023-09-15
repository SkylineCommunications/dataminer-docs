---
uid: Connector_help_Acterna_RPS_Matrix
---

# Acterna RPS Matrix

This connector monitors the port connection of the switch. It is possible to configure the switching mode (automatic/manual), the number of RPS devices to use and the input (MUX A/MUX B).

## About

The connector will start communicating with the device through a serial connection, once the number of ports to be used is defined. It is possible to set a port to start with for automatic and manual mode.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |
| 1.1.0.x          | No              | Yes                 |                         |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.1.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device. This can only be set to *8*.
  - **Stopbits**: Stopbits specified in the manual of the device, by default *1*.
  - **Parity**: Parity specified in the manual of the device, by default *no*.
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device. (Range: 32 - 1.)

## Usage

### Main View

This page contains an overview of the switch behavior.

### Port Settings

On this page, you can among others configure the **Switch Mode** and the **ports** to be used in the switching. You can also **import a CSV or XML** file with the ports information.

### Automatic Switching - Manual Switching

On these pages, you can configure the automatic or manual switching, and select the appropriate port depending on the type of switching.

Note that the **Current Port**, **Last Automatic Switch** and **Last Manual Switch** parameters are also available on the **Main View** page.
