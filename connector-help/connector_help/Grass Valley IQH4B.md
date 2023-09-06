---
uid: Connector_help_Grass_Valley_IQH4B
---

# Grass Valley IQH4B

The **IQH4B** enclosures offer industry-leading, high-density delivery of modular solutions. With up to 700 W of module power available, it accepts up to 20 modules and has dual-redundant PSUs and in-service replaceable cooling fans. Analog reference signals can be distributed through the enclosures via two connections that can be independently selected by the installed modules. RollCall control and monitoring is included as standard using a gateway control card that has its own module-style rear connector.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                            |
|-----------|---------------------------------------------------|
| 1.0.0.x   | Software Version: 5.38.25Build Number: 0242106059 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Smart-Serial Single Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the destination (default: *2050*).
  - **Bus address**: The bus address of the device, in the format *UU.PP*, where UU is the unit address and PP is the unit port. For example: *01.01*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

A vendor-specific communication protocol (RollCall) is used to retrieve and send data to the device over TCP. As RollCall is a binary protocol, you will not be able to easily trace the communication via Stream Viewer.

To save bandwidth, this connector does not rely on polling to retrieve data from the device. Instead, it relies on unsolicited update messages that the device sends. Only at the creation of the RollCall session will the connector poll all parameters. Because there is a very large number of parameters, it can take a few minutes before all parameters are polled.
