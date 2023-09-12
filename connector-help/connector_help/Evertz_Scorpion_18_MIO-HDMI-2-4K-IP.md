---
uid: Connector_help_Evertz_Scorpion_18_MIO-HDMI-2-4K-IP
---

# Evertz Scorpion 18 MIO-HDMI-2-4K-IP

This driver is used to monitor the Evertz Scorpion 18 MIO-HDMI-2-4K-IP microservice module.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | MIO-HDMI-2-4K-IP       |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: \[The polling IP or URL of the storage system\]

SNMP Settings:

- **Port number**: \[The IP port of the storage system. e.g. *161\]*
- **Get community string**: \[The community string used when reading values from the device
  (default value if not overridden in the connector: *public*).
- **Set community string**: \[The community string used when setting values on the device
  (default value if not overridden in the connector: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

All data available is retrieved using the **SNMP** interface of the Evertz Scorpion 18 MIO-HDMI-2-4K-IP.

The **General** page contains all data related to **System.
**

The **Network Management** page contains tables related to networking, SNMP, MAGNUM and PTP.

The **HDMI IN** and **HDMI OUT** pages contains controls and tables related to EDID, HDR metadata, video and audio.

The **SDI** page contains tables related to control and status of input and output SDI.

The **IP Input** and **IP Output** page contains tables related to video, audio, SDI and ANC.

The **Trunk Port** contains a table to manage trunk data port.
