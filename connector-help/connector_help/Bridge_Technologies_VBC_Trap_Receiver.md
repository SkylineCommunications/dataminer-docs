---
uid: Connector_help_Bridge_Technologies_VBC_Trap_Receiver
---

# Bridge Technologies VBC Trap Receiver

The **VBC Trap Receiver** connector integrates the **VideoBRIDGE Controller (VBC)** through an SNMP trap methodology. At startup, the VBC Trap Receiver connector performs a hard synchronization with the VBC and requests all current alarms, which will be sent via SNMP traps. From that moment onward, the connector will receive and filter the SNMP traps of the VBC, generating and clearing alarms accordingly. To ensure the consistency of alarms, a periodic hard synchronization will be performed.

## About

### Version Info

| **Range**             | **Key Features**                                                                     | **Based on** | **System Impact**                              |
|-----------------------|--------------------------------------------------------------------------------------|--------------|------------------------------------------------|
| 1.0.0.x \[Obsolete\]  | Initial version.                                                                     | \-           | \-                                             |
| 1.0.1.x \[Obsolete\]  | Probe filtering added for traps aggregation.                                         | 1.0.0.3      | Page renamed.                                  |
| 1.0.2..x \[SLC Main\] | HTTP connection added to support Bridge Technologies External Integration Interface. | 1.0.1.4      | New connection added to element configuration. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 6.0.0-8                |
| 1.0.1.x   | 6.0.0-8                |
| 1.0.2.x   | 6.0.0-8                |

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

#### HTTP Secondary Connection

This connector uses the Bridge Technologies External Integration Interface over HTTP to get additional information from the VBC.

- **IP address/host**: The polling IP or URL of the destination, e.g. *http://10.24.4.138.*
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element has the following data pages:

- **General**: Displays the current VBC alarms in a table. Also displays the last physical synchronization date and time and offers a button for manual hard synchronization.

- **License**: Shows the expiration date and the remaining duration of the active license.

- **Sites and Probes:** Allows you to enable/disable the sites and/or probes that should be considered for the aggregation of traps.

- **Service Inhibition:** Allows you to create filters for the services that should be considered for the aggregation of traps. These filters can contain wildcards.

- **Aggregated Traps:** Aggregates traps by service with a summary listing the errors by site.

- **Counters:** Displays event counters by type.
