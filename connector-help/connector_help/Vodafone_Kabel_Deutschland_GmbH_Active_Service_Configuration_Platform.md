---
uid: Connector_help_Vodafone_Kabel_Deutschland_GmbH_Active_Service_Configuration_Platform
---

# Vodafone Kabel Deutschland GmbH Active Service Configuration Platform

The Vodafone Deutschland GmbH Active Service Configuration Platform connector collects all active service configurations from every enhanced service protocol present in the DataMiner System. The entries are indicated by their use case (Pre-encoding, Satellite Downlink, IP GW, etc.).

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \- [Vodafone Kabel Deutschland GmbH IP GW Service](xref:Connector_help_Vodafone_Kabel_Deutschland_GmbH_IP_GW_Service) <br>- [Vodafone Kabel Deutschland GmbH SAT DL GW Service](xref:Connector_help_Vodafone_Kabel_Deutschland_GmbH_SAT_DL_Service) <br>- [Vodafone Kabel Deutschland GmbH Pre-Encoding Service](xref:Connector_help_Vodafone_Kabel_Deutschland_GmbH_Pre-Encoding_Service) <br>- [Vodafone Kabel Deutschland GmbH IP PEER DS Service](xref:Connector_help_Vodafone_Kabel_Deutschland_GmbH_IP_PEER_DS_Service) <br>- [Vodafone Kabel Deutschland GmbH IP PEER OS Service](xref:Connector_help_Vodafone_Kabel_Deutschland_GmbH_IP_PEER_OS_Service) <br>- [Vodafone Kabel Deutschland GmbH Qbit Radio Service](xref:Connector_help_Vodafone_Kabel_Deutschland_GmbH_Qbit_Radio_Service) <br>- [Vodafone Kabel Deutschland GmbH TAG Radio Service](xref:Connector_help_Vodafone_Kabel_Deutschland_GmbH_TAG_Radio_Service) <br>- [Vodafone Kabel Deutschland GmbH KEVAG Service](xref:Connector_help_Vodafone_Kabel_Deutschland_GmbH_KEVAG_Service) | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

You can find all the information you need to monitor on the General data page.

On the **Configuration** page of this connector, you can configure the discovery and heartbeat intervals. The **discovery interval** determines how frequently the connector will search for new enhanced services. The **heartbeat interval** determines how frequently the connector will collect the data from the enhanced services.
