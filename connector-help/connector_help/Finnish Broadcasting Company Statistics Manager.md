---
uid: Connector_help_Finnish_Broadcasting_Company_Statistics_Manager
---

# Finnish Broadcasting Company Statistics Manager

The Finnish Broadcasting Company Statistics Manager driver retrieves and calculates statistics of the YLE booking system (jobs, bookings, tickets, etc.).

## About

### Version Info

| **Range**            | **Key Features**               | **Based on** | **System Impact** |
|----------------------|--------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Real-time and daily statistics | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The **General** page displays all statistics that are retrieved by this driver. These statistics can be visualized in a dashboard for monitoring purposes.

There are two different kinds of statistics:

- Real-time statistics: updated every hour
- Daily statistics: updated once per day

On the **Configuration** page, you can configure the interval at which the different statistics are refreshed.

This allows statistics that take a longer time to load to be updated more slowly than statistics that can be refreshed quickly. The default update interval is 60 minutes.
