---
uid: Connector_help_Zamil_Industries_HVAC_AC
---

# Zamil Industries HVAC AC

This connector monitors parameters of a remote control and monitoring system through the HVAC PLC.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Modbus Communication

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600* (default: *9600*).
  - **Databits**: Databits specified in the manual of the device, e.g. *7* (default: *8*).
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1* (default: *1*).
  - **Parity**: Parity specified in the manual of the device, e.g. *No* (default: *even*).
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No*.

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Bus address**: The bus address of the device. This is also the slave ID of the monitored device. Make sure this is filled in, as it is used to determine which device the connector should communicate with.

## How to use

On the General page, the connector displays parameters for AC-1 and AC-2 units as well as the temperature and health of the device.
