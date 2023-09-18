---
uid: Connector_help_Digigram_IQOYA_XLINK
---

# Digigram IQOYA XLINK

IQOYA X/LINK is a 1U-rack streamlined IP audio codec designed for **live remote broadcasting** and **program distribution** over IP. It is a perfect fit for delivering a stereo source (or two mono sources) over IP networks for **STL** and **SSL** link, **DVB** audio, **WEB radio**, and also full-duplex **live remote broadcasts**.

## About

### Version Info

| **Range**            | **Key Features**                                                           | **Based on** | **System Impact**                                                                          |
|----------------------|----------------------------------------------------------------------------|--------------|--------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version                                                            | \-           | \-                                                                                         |
| 1.0.1.x              | \- Fixed Table Display keys - Fixed Discreet Priority (Receivers Priority) | 1.0.0.1      | Updates may be needed for filters, Automation scripts, visual overviews, reports, web API. |
| 1.0.2.x \[SLC Main\] | Set Multicast address via HTTP                                             | 1.0.1.1      | New HTTP connection must be configured for existing elements.                              |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 03.03b006              |
| 1.0.1.x   | 03.03b006              |
| 1.0.2.x   | 03.05e001              |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### HTTP Connection (1.0.2.x onwards)

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: 443.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element has the following data pages:

- **General**: Displays general system parameters such as the **Serial Number**, **Firmware Version** and **Device Name**.
  The **Network** subpage displays information about the **Ethernet Interfaces** and the **VLAN Interfaces**.
- **Encoder**: Contains **Encoder Programs** information.
  The **Service 1** subpage displays information about the service 1 available in the device.
- **Decoder**: Displays information about the **Decoder Programs**.
  The **Receivers Priority** subpage displays information about the receivers. It allows you to filter the receiver priorities for the program index 1.

From range **1.0.1.x** onwards, additional pages are available that make the connector more similar to the web interface: the **Receive**, **Send** and **Audio** pages.

The **Display All "*Table Name*"** toggle buttons allow you to select if unused table entries should be hidden. If this toggle button is disabled, only the active table entries are displayed.

From range **1.0.2.x** onwards, an **Receive** configuration page is available, containing the HTTP authentication parameters and a toggle button to enable/disable the Multicast HTTP set.
