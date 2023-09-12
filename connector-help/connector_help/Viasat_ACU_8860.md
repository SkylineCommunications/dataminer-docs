---
uid: Connector_help_Viasat_ACU_8860
---

# Viasat ACU 8860

The Viasat ACU 8860 DataMiner connector will interface with Antenna Control Units using a serial interface, so that you can use DataMiner to monitor and control the position of your antenna. The Model 8860 Antenna Tracking Controller (ATC) gives you control of your antenna system over four axes of motion: azimuth, elevation, and two motorized feeds.

The ATC usually serves as the host serial device that provides an operator control panel containing a display and keypad. It also processes the beacon or carrier level inputs and commands the Antenna Position Controller (APC) Model 8861A/8862 for tracking motion. The APC controls the positioning of the antenna, and reports position and faults to the ATC. Operators can manually position the antenna, or select from up to 60 satellite locations stored in memory for automatic antenna pointing.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | TBD                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### Serial Connection - Main

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: 9200
  - **Databits**: 8
  - **Stopbits**: 1
  - **Parity**: No
  - **FlowControl**: No
  - **Bus address**: Between 1 and 63.

- Interface connection:

- **IP address/host**: TBD
  - **IP port**: TBD

### Initialization

TBD

### Redundancy

No redundancy is defined in the connector.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

TBD
