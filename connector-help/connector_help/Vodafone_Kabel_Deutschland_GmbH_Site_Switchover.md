---
uid: Connector_help_Vodafone_Kabel_Deutschland_GmbH_Site_Switchover
---

# Vodafone Kabel Deutschland GmbH Site Switchover

This is a dedicated connector intended to monitor and retrieve KPIs related to the active downlink streams. It currently supports the following use cases: Satellite Downlink, Pre-Encoding and IP Gateway.

## About

### Version Info

| **Range**            | **Key Features**                             | **Based on** | **System Impact** |
|----------------------|----------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Satellite Downlink, Pre-Encoding, IP Gateway | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**    |
|-----------|---------------------------|
| 1.0.0.x   | CISCO DCM 1.0.3.47 and up |

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Redundancy

There is no redundancy defined.

## How to use

The **General page** displays the **DCM Devices Table**, which lists all DCM devices that are being polled. You can perform several actions on this table via its right-click menu.
