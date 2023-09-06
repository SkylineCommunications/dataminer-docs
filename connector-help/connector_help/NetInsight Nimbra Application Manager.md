---
uid: Connector_help_NetInsight_Nimbra_Application_Manager
---

# NetInsight Nimbra Application Manager

The Netinsight Nimbra Application Manager is the manager connector for the [Netinsight Nimbra](xref:Connector_help_NetInsight_Nimbra) connector. It serves as a place where all important KPIs for the network are collected.

Besides showing the status for each node, it also aggregates the information to give you more insight into the network.

## About

### Version Info

| **Range**            | **Corresponding NetInsight Nimbra Version** | **Based on** | **System Impact** |
|----------------------|---------------------------------------------|--------------|-------------------|
| 1.0.0.x \[Obsolete\] | 3.0.0.x \[Obsolete\]                        | \-           | \-                |
| 1.0.1.x \[Obsolete\] | 3.0.1.x \[Obsolete\]                        | \-           | \-                |
| 2.0.0.x \[Obsolete   | 4.0.0.x \[Obsolete\]                        | \-           | \-                |
| 2.0.1.x \[Obsolete\] | 4.1.0.x \[Obsolete\]                        | \-           | \-                |
| 2.0.2.x \[SLC Main\] | 4.1.1.x \[SLC Main\]                        | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Gx 4.6-Gx 4.7          |
| 1.0.1.x   | Gx 4.6-Gx 4.7          |
| 2.0.0.x   | Gx 4.6-Gx 4.7          |
| 2.0.1.x   | Gx 4.6-Gx 5.6          |
| 2.0.2.x   | Gx 4.6-Gx 5.6          |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 2.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |
| 2.0.2.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

Make sure **only one NetInsight Nimbra Application Manager element** is configured in the system.

Once the manager element has been activated, it will broadcast its presence to all nodes. The nodes will respond with their information. After a while, you should see all NetInsight Nimbra nodes that are available in the network. The NetInsight Nimbra Application Manager is then ready to be used.

## How to use

The manager will automatically detect new nodes in the network. It also detects services and hitless services that are configured in the network, so that it can give a full overview of the activity in the network.

If NetInsight Nimbra nodes are set up with a location, the Nimbra manager can give you a location-based usage overview.The same applies for services: you can link each service to a specific customer so that you also can get a customer-based usage overview.

## Notes

Make sure to use the correct version combination (see version info table). Older NetInsight Nimbra nodes will not be able to connect to newer manager versions.
