---
uid: Connector_help_ETL_Systems_23235
---

# ETL Systems 23235

The Model 23235 L band switch operates with signals in the L band range of frequencies from 50-2150MHz and is designed to provide automatic MAIN/STANDBY switching functions typically for 2:1 redundancy switching.

The ETL Systems 23235 connector allows for configuration of the switching functionality and monitoring of the power supply status and temperature.

## About

### Version Info

| Range            | Key Features | Based on | System Impact |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x [SLC Main] | Initial version. | -           | -                |

### Product Info

| Range | Supported Firmware |
|-----------|------------------------|
| 1.0.0.x   | V1.0 e396         |

### System Info

| Range | DCF Integration | Cassandra Compliant | Linked Components | Exported Components |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | -                    | -                      |

## Configuration

### Connections

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General Page

This page displays **Temperature** of the device, the **Configuration** and the **Power Supply Status** tables.

The **Configuration** table **** allows for configuration of the **Boot Mode, Operating Mode, Online Path,** and **Standby Latch.**

### RF Limits Page

Two tables containing information for the device RF limits are displayed on this page: the **RF Limits** table and the **Limits Status** table.

Both of these tables contain information for the main and standby RF signals.

### IP Settings Page

The **IP Settings** table on this page allows the user to configure the device **DHCP** and **IP,** or the **NET BIOS Name**.

### Trap Receivers Page

The trap receivers of the device are displayed and configurable in the **Trap Receivers** table displayed on this page.

### Web Interface Page

This page displays the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
