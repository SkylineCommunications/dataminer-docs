---
uid: Connector_help_NBCU_LEM_Collector
---

# NBCU LEM Collector

The LEM Collector is an endpoint that is created to retrieve extended event data.

## About

### Version Info

| **Range**            | **Key Features**    | **Based on** | **System Impact** |
|----------------------|---------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.    | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Updated to Unicode. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTPS Main Connection

This connector uses an HTTPS connection and requires the following input during element creation:

HTTPS CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

## How to use

On the **General** page of the element, the event table contains the relevant data related to events, including the PID, asset ID, Title, Description, etc.

## Notes

The connector selects the **Manifest Type** of an event using the following possible methods, in the indicated order:

1. YoSpace
1. URL Match
1. Quality Mapping
1. Default

If **YoSpace** data is filled in for the event, then the **Manifest YoSpace** parameter will be used for the **Manifest Type**.

In the Manifest Mapping table, if any of the **asset URLs** match the **URL Match** parameter, then that event will be set to the **URL Match Manifest Type**.

If the **quality** of the **event** is found in the **Manifest Quality Mapping** table, then the event will be set to the **Quality Manifest Type**.

If none of these conditions are met, the **Default Manifest** will be used.
