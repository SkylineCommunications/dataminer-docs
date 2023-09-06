---
uid: Connector_help_Cisco_DCNM
---

# Cisco DCNM

Cisco Data Center Network Manager (DCNM) is a management system for the Cisco Programmable Fabric. In addition to provisioning, monitoring and troubleshooting the data center network infrastructure, the Cisco DCNM provides a comprehensive feature set that meets the routing, switching and storage administration needs of the data center. It streamlines the provisioning for the Programmable Fabric and monitors the SAN and LAN components.

## About

The **Cisco DCNM** monitors and displays the connections between the switches, modules, licenses, interfaces and flows of the device.

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                       | **Based on** | **System Impact**                                  |
|----------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|----------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                                                                                                                                                       | \-           | \-                                                 |
| 1.0.1.x \[Obsolete\] | Fix for SLElement leak by fixing display keys: - RTP Flows - RTP Error History - RTP Packet Drop History - RTP Active Flows - RTP Switch Corrections - RTP Error Flows - Host Policies | 1.0.0.4      | Existing trend data will be lost for these tables. |
| 1.0.2.x \[SLC main\] | Changed primary key for the following tables: - Active Flow Status - Inactive Flow Status - Sender Only Flow Status - Receiver Only Flow Status                                        | 1.0.1.4      | Existing alarm/trend data will be lost             |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 11.0(1)                |
| 1.0.1.x   | 11.0(1)                |
| 1.0.2.x   | 11.5(1)                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP main connection:

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination, by default *443*.

### Configuration of HTTP Authentication

The credentials of the device must be entered on the **General** page and then applied using the **Apply** button. This will generate a logon token that will be used for all future requests, or until the credentials are changed.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The element created with this connector consists of the data pages detailed below.

### General

The **Username** and **Password** must be provided on this page. Every time the credentials have changed, you must press the **Apply** button to request a new authentication token.

### Inventory

This page displays a tree view of the inventory, showing a hierarchy of switches with their appropriate interfaces, modules and licenses.

The separate tables with the information on the **Switches**, **Modules**, **Licenses** and **Discovered Hosts** can be accessed via the page buttons at the bottom of the page.

### Flows

On this page, you can view and configure the general flow information in the **Flow Alias**, **Flow Policy** and **Flow Policy Multicast Ranges** tables.

You can access the tables with the status of the **Active**, **Inactive**, **Sender Only** and **Receiver Only** flows via the page buttons at the bottom of the page.

Note: Via the right-click menu, you can add or delete rows in the **Flow Alias**, **Flow Policy** and **Flow Policy Multicast Ranges** tables.

## Notes

**Warning**: Because of a change from version 1.0.0.3 onwards, the SLElement load will increase considerably, for example up to 1 Gb. The load depends on the number of records in the tables PTP Switch Corrections, RTP Error History and RTP Packet Drop History.
