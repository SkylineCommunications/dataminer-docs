---
uid: Connector_help_Mitec_Antenna_Switch_Control_Unit
---

# Mitec Antenna Switch Control Unit

The 216945-001MD Antenna Switch Control Unit is a microcontroller-based unit designed to monitor and control switching/combining system waveguide switches.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 216945-001MD           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial connection - Main

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: 9600 (default)
  - **Databits**: 7 (default)
  - **Stopbits**: 1 (default)
  - **Parity**: Even (default)
  - **FlowControl**: No (default)

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: 8013 (default)
  - **Bus address**: 30 (default)

## How to use

The **Status** page displays the switch positions. You can change the switch position (position 1/position 2) by clicking the **Set SW X Position** button for the corresponding switch.
