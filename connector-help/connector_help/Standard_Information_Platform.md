---
uid: Connector_help_Standard_Information_Platform
---

# Standard Information Platform

## About

This is a base connector for "**Microsoft Platform**" (2.1.0.68), "**Microsoft Platform SNMP**" (1.1.0.15), "**Linux Platform SNMP**" (1.1.0.46) and "**Linux Platform SSH**" (1.0.0.33). Note that the versions are relevant as mediation components refer to particular parameter ids.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | True                    |

## Installation and configuration

### Creation

This connector uses a virtual connection and does not require any input during element creation. In fact, you don't have to create any element because the base protocol will be detected and included into the child protocol options.

## Usage

### Performance

This page has information about the **CPU Load** and the **Available Physical Memory**.

### Storage

This page contains information about the available disks and/or partitions available in the system, such as **total disk space**, **used space** and **free space**.
