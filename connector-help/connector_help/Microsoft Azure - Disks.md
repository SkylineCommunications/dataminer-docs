---
uid: Connector_help_Microsoft_Azure_-_Disks
---

# Microsoft Azure - Disks

Azure Disks are block-level storage volumes that are managed by Azure and used with Azure Virtual Machines. A managed disk is like a physical disk in an on-premises server, but virtualized. With managed disks, all you have to do is specify the disk size and disk type, and provision the disk. Once you provision the disk, Azure handles the rest.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**      |
|-----------|-----------------------------|
| 1.0.0.x   | REST-API version 2018-01-01 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                   | **Exported Components** |
|-----------|---------------------|-------------------------|-------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | [Microsoft Azure Cloud Platform](xref:Connector_help_Microsoft_Azure) | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection. However, it requires no input from the user, as this driver is automatically created by the **Microsoft Azure Cloud Platform**.

## How to use

The driver requires no user input. The metrics that are polled for this resource type element are displayed on the **Metrics** page. The following metrics are monitored:

- Disk Read Bytes/sec
- Disk Read Operations/sec
- Disk Write Bytes/sec
- Disk Write Operations/sec

On the **General** page, you can configure the **Polling Interval** for the metrics. This same page also displays the scope (Subscription and Resource Group) this resource type element belongs to.

## Notes

This driver is intended to be used together with the **Microsoft Azure Cloud Platform** driver. Without this manager driver, the driver will not work, as the authentication to the Azure Cloud Platform is done via the manager driver.

Currently these metrics are in preview on Microsoft Azure and are subject to change before becoming generally available.
