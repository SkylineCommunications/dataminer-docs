---
uid: Connector_help_NBCU_Ad_Monitoring_Manifests
---

# NBCU Ad Monitoring Manifests

This connector retrieves data from a MediaTailor device, which contains manifests to provision when an event is live. The connector also contains a direct relation with the NBCU Event Manager APP protocol, which sends data for retrieval from the MediaTailor device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**  | **Exported Components** |
|-----------|---------------------|-------------------------|------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | NBCU Event Manager APP | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTPS connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

To be able to use the element, configure the **Event Manager Element** parameter on the **General** page. Fill in this parameter in the following format: **DMAID/ElementID/ParameterID**. The default ParameterID value is 999.

## How to use

The element using this driver will receive data from the **Event Manager** element. It can automatically execute a request depending on the **DomainUrl, RequestUrl** and **JsonData** column values. It will receive the **ManifestUrl** value and update the **TimeRequested** column. In case a request cannot be executed automatically, you can force the execution by clicking the **Refresh** button in each row.

To do a **manual request**, add a new row with the **Add Row** button, fill in the columns (DomainUrl, RequestUrl and JSONBody are mandatory), and click the **Refresh** button.
