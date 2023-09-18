---
uid: Connector_help_Norkring_AS_Bricknet
---

# Norkring AS Bricknet

This is a virtual connector that reads data from a VC4 IMS element, filtering according to the defined filters.

## About

This connector supports the Bricknet View Visio drawings

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Linked connectors

| **Name** | **Range** |
|-----------------|-----------|
| VC4 IMS         | 1.0.0.x   |

## Installation and configuration

### Creation

This connector uses a **virtual** connection and does not require any input during element creation.

## Usage

### General Page

This page contains parameters that can be used to configure the element behavior.

- **IMS Sync Period:** Defines the sync period, in hours.
- **Force Sync:** Pressing this button will sync immediately.
- **Filter Table:** In this table, you can add the desired filters. All actions in this table are done via the context menu.

### Nodes Page

This page displays a table with the filtered data from the **Nodes Table**.

### Sites Page

This page displays a table with the filtered data from the **Sites Table**.

### Circuits Page

This page displays a table with the filtered data from the **Circuits Table**.
