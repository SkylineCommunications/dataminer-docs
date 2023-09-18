---
uid: Connector_help_Telenor_InHome_Status
---

# Telenor InHome Status

This connector is used to process the incoming messages from EKOM HUB.

The incoming messages are being forwarded by an Automation script that is specifically designed to relay them from the DataMiner API deployment feature.

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

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                    | **Exported Components** |
|-----------|---------------------|-------------------------|------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | TLRN-AS-InHomeStatus (Automation script) | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

## How to Use

On the **General** page, you will find a Log table that displays all the received incoming messages. You can also verify the status of the communication with the EKOM HUB.
