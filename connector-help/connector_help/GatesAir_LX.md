---
uid: Connector_help_GatesAir_LX
---

# GatesAir LX

The GatesAir LX connector can be used to monitor and control the **GatesAir** **Flexiva** **LX** series.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |
| 1.0.1.x              | MIB tree updated | 1.0.0.1      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |
| 1.0.1.x   | 1.0.9                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

This connector not only allows you to monitor the Gates Air LX but also allows additional configuration.

One of the important settings can be found on the **Alarms** page. Thresholds can be configured for each alarm in collaboration with the **Type** and **(analog out) source** parameters. The alarm status will indicate **Fail** or **OK** depending on whether the configured **threshold values** are exceeded or not. You can not only configure the thresholds, but also enable **email** **notifications** or configure a **delay**, so that an alarm is only generated after a threshold has been exceeded for a specific time.

Note that this **alarm** **configuration** is set on the GatesAir LX itself and the alarm monitoring functionality in **DataMiner** can be used as well.
