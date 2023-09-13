---
uid: Connector_help_Spectrum_Technologies_Watchdog_2000_Series
---

# Spectrum Technologies Watchdog 2000 Series

The WatchDog 2000 Series Mini Stations are typically used when multiple sensor measurements are required for temperature, soil moisture, crop canopy light, or leaf wetness data. These stations feature:

- NEMA-4 type IP66 enclosure and weatherproof connectors.
- Built-in data logger stores measurements in fail-safe, non-volatile memory.
- Customization with 1-4 plug-in sensors

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                        |
|-----------|-----------------------------------------------|
| 1.0.0.x   | WatchDog 2000 Series (2400, 2425, 2450, 2475) |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Telnet (Serial)

This connector uses a Telnet (serial) connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: default: *4001*

### Initialization

No additional configuration of parameters is necessary in a newly created element.

### Redundancy

There is no redundancy defined.

## How to use

Once you have created the element polling the correct serial gateway (using port 4001), the General page will display all weather metrics.
