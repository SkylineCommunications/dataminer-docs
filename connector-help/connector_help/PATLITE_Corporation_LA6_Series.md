---
uid: Connector_help_PATLITE_Corporation_LA6_Series
---

# PATLITE Corporation LA6 Series

The LA6 Series signal tower can operate in Smart Mode or Signal Tower Mode. It can control the LED and buzzer like a standard tower. In Smart Mode, various displays can be shown, such as a slow flashing rate, simulating that of a firefly, and a display that can be used as a level meter.

The PATLITE Corporation LA6 Series connector uses HTTP polling to retrieve information such as the mode, the Units table, Smart Mode parameters, etc.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.0                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the data pages described below.

- **General**: Displays the **Mode** (which can be *Signal Tower Mode* or *Smart Mode*), **LED Unit Firmware Version**, **LAN Unit** **Firmware Version** and **MAC Address.**
- **Units**: Contains the Units table, displaying the **Status** and **Colors** for the units.
- **Smart Mode**: If the system is running in *Smart Mode*, the **Group Number** parameter on this page will display a value other than *Disabled*. The page also contains the **Mute** and **Stop** options, and displays the **Pattern Number**.
- **Debug**: Used for debugging purposes. To use this, specify the **Connection URL** (e.g. "*api/control?clear=1*"), and click the **Get Dynamic Request** button. The results will be displayed at the top of the page.
