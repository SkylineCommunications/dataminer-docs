---
uid: Connector_help_Ziggo_IPVPN_CPE_Manager
---

# Ziggo IPVPN CPE Manager

The **Ziggo IPVPN CPE Manager** connector provides a CPE manager interface that shows where a cable modem is located in the topology diagram.

## About

This connector is part of a larger setup and works together with the **Ziggo IPVPN Collector**, **Ziggo IPVPN Provisioning**, **Skyline IAM DB** and **Skyline IAM DB Provision** connectors. There is also a MySQL setup needed with stored procedures.

The connector can be used to view cable modem data from the **Ziggo IPVPN Collector** element, to check where the modem resides in one of the physical topologies (HFC, Fiber or DSL), and also to see the modem in the logical topology of the customer of the host.

As this is a virtual connector, no data traffic will be displayed in the Stream Viewer.

### Version Info

| **Range**     | **Description**                                                                | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                                               | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | Primary and Secondary BGP Peer parameters are now called BGP Neighbor 1 and 2. | No                  | Yes                     |

## Installation and configuration

### Creation

The element using this connector is automatically created by the **Skyline IAM DB Provision** parent connector.

## Usage

The data pages for this connector are not accessible to operators, only the visual overview pages containing the CPE Manager interface are.

In the CPE Manager interface, one of the filters can be filled in, which will show the requested info in a topology diagram.
