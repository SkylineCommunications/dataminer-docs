---
uid: Connector_help_CEFD_NetVue_Service_Group
---

# CEFD NetVue Service Group

This is a virtual driver used in NetVue. It is used to create an element representing the root level where the configuration is added.

## About

The driver contains information related to the current configuration of the NetVue system: existing VMSs, networks, satellites and service areas. It also allows the addition and configuration of those elements.

### Ranges of the driver

| **Driver Range**     | **Description**                                                                                                            | **DCF Integration** | **Cassandra Compliant** |
|----------------------|----------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                                                                                                           | No                  | Yes                     |
| 1.1.0.x \[SLC Main\] | Service Area name for Heights changed.ViperSat Overview and Service Area Overview tables now sorted by name instead of ID. | No                  | Yes                     |
| 1.1.1.x              | Based on 1.1.0.7.Method of filling in the BWM Overview table updated. New VMS architecture.                                | No                  | Yes                     |

## Installation and configuration

### Creation

The element using this driver is created by the driver CEFD NetVue Provisioning, by means of an Automation script. In the script, you will need to fill in the name of the element.

This is a virtual driver, which does not require any further configuration to function correctly.

## Usage

### Config

This page contains the **Service Group ID** and the Tables **ViperSat OverView** and **Service Area OverView**.

### Monitoring

This page contains the tables **Service Area View Outbound** and **Service View Area Inbound**, allowing you to monitor this information.

### Maps

This page contains information used to generate maps. It contains the tables **Hub Overview**, **Remote Overview** and **Circuit**, as well as a page button to the **Mapping** subpage.

### Mapping

This page contains the tables **Hub Overview Indexes**, **Remotes Indexes** and **Map Indexes**.
