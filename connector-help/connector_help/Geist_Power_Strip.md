---
uid: Connector_help_Geist_Power_Strip
---

# Geist Power Strip

The Geist Upgradeable PDU incorporates an Interchangeable Monitoring Device (IMD) in a robust PDU design. The hot-swappable IMD can be changed out in a few simple steps, without interrupting power to critical servers.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

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

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device (default: *ByPassProxy*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the following data pages:

- **General**: Displays general information about the product. This includes the **Device Name**, **Version**, **Friendly Name**, **MAC Address**, **URL**, **Device Count** and **Temperature Units**.

- **Power Strip**: Displays information about the power strip module, including the following information:

- **Availability**: Indicates whether the module is *available*, *unavailable* or *partially available*.
  - **Power**
  - **Total Energy**
  - **PDU Phase** table: Contains **Voltage**, **Current** and **Power** information.
  - **PDU Breaker** table: Displays the **Current**, **Current Max/Min** and **Current Peak**.

- **Debug**: Can be used for debugging purposes. Includes a **Ping** functionality that pings the device and shows the **Ping Result**.

For a video introduction, see <https://web.microsoftstream.com/video/c88488ea-37b0-4084-aa7d-1f6b2c88689e>.
