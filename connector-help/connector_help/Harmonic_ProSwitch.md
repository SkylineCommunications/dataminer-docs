---
uid: Connector_help_Harmonic_ProSwitch
---

# Harmonic ProSwitch

**Harmonic ProSwitch** is a compact, stand-alone system for applications requiring fast, dense and reliable 2:1 MPEG-2 transport strem redundancy switching for when downtime is not an option,
offering up to eight 2:1 IP switches or four 2:1 ASI switches in 1-RU.

This connector uses a SNMP connection to monitor the **Harmonic ProSwitch**.

## About

### Version Info

| **Range**            | **Key Features**             | **Based on** | **System Impact**       |
|----------------------|------------------------------|--------------|-------------------------|
| 1.0.0.x              | Initial version              | \-           | \-                      |
| 1.0.1.x \[SLC Main\] | Added support for SNMP cards | 1.0.0.x      | Layout has been changed |



### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | PSW_01.10.00.283_GA    |
| 1.0.1.x   | PSW_01.10.00.283_GA    |



### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |



## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. (default: *161*)

SNMP Settings:

- **Get community string**: The community string used when reading values from the device. (default: *public*)
- **Set community string**: The community string used when setting values on the device. (default: *private*)

### Initialization

No extra configurations are needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.
