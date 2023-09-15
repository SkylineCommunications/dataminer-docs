---
uid: Connector_help_ETL_Systems_NGM-30
---

# ETL Systems NGM-30

The L-band matrix is used to provide flexibility in the routing of antennas to receivers or modems, also to allow remote routing to satellite signals and to optimize the use of receiving capacity.

This connector uses two interfaces, **SNMP** and **Serial**, to communicate with the **NGM-30** device.

## About

### Version Info

| Range            | Key Features | Based on | System Impact |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x [SLC Main] | Initial version. | -           | -                |

### Product Info

| Range | Supported Firmware |
|-----------|------------------------|
| 1.0.0.x   | 2.15                   |

### System Info

| Range | DCF Integration | Cassandra Compliant | Linked Components | Exported Components |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | -                    | -                      |

## Configuration

### Connections

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

This connector also uses a serial connection and requires the following input during element creation:

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

### Main View

This page contains the device Matrix.

### General

This page displays generic parameters, such as:

- **Version**
- **Number of Inputs**
- **Number of Outputs**
- **Matrix Size**
- **DHCP Status**
- **Module IP Address**

### Status

This pages displays two tables: **Input** **Card** **Status** and **Output Card Status**. These tables displays the monitoring information for each of the RF cards in the module.

### Alarm

This page displays the device status, such as **Temperatures**, **Fan** **Speeds**, and **Communication** **Status**.

### Configuration

This page is used to configure the Matrix size, number of inputs and outputs.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the Web Interface.
