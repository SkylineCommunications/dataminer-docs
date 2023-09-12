---
uid: Connector_help_Bridge_Technologies_VB440
---

# Bridge Technologies VB440

This connector allows you to monitor and control **Bridge Technologies VB440 Series** devices.

It uses the **EII API (Enterprise Information Integration)** provided by the vendor for regular polling of the probes over **HTTP**, as well as **SNMP traps** in order to get quick alarm updates.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 6.0.3                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default value: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

#### SNMP Traps Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

Once the element has been created in DataMiner, the **Element Configuration** page allows you to configure different aspects of the element behavior:

- Configuring credentials for **HTTP Authentication** (if HTTP authentication is enabled on the probe).
- Configuring how to handle probe alarms.
- Enable more verbose logging if needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The **Streams** page contains tables regarding grouped stream data, while more detailed statistical information can be found on the **Media Window** page.

Various alarm and threshold information can be found on and under the **Alarms** page.
