---
uid: Connector_help_Eutelsat_NLES
---

# Eutelsat NLES

This connector is used to send a serial message to the **NLES station**. To compose the message, the connector retrieves KPIs from the Eutelsat DMS and computes status parameters. Those status parameters are concatenated to form the serial message.

The message is sent every 10 minutes as well as every time a KPI change is detected.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.

## How to Use

This connector consists of the following pages:

- **General**: Displays the current value of the status parameters. The last command sent to the NLES station is also displayed (in ASCII and in hexadecimal format).
- **Configuration**: The Configuration table lists the 4 devices available in the NLES system (C-BAND ACU, L-BAND LNA, C-BAND HPA-A***,*** and C-BAND HPA-B). You can associate an element with each NLES device.
