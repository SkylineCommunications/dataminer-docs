---
uid: Connector_help_Vodafone_Kabel_Deutschland_GmbH_TS_Bitrate_Optimization_APP
---

# Vodafone Kabel Deutschland GmbH TS Bitrate Optimization APP

This connector can be used to manipulate the TS bitrate of output streams on the CISCO DCM.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Corbaloc IIOP 1.1      |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

No connection needs to be configured during element creation.

Once the element has been created, on the **General** page, fill in the CISCO DCM **IIOP credentials**, and specify the necessary devices in the **Devices Table**.

## How to use

This connector is deployed as an app. This means that you can easily access it in Cube with the Apps button in the sidebar.

The connector will poll all devices configured in the **Devices Table** (on the General page). All data will be parsed, and the Streams Table (on the Streams page) will be populated will all CBR output streams.

For each output stream, the max bitrate will be shown, and an optimal bitrate will be calculated based on the **configuration settings**:

- Bitrate Delta Setting \[Value\]: Calculates the optimal bitrate by adding a fixed (Mbps) value to the maximum bitrate.
- Bitrate Delta Setting \[Percentage\]: Calculates the optimal bitrate by adding a percentage to the maximum bitrate.

The **Streams** table provides several options to manipulate the output stream bitrates, using buttons on the row level or using the context menu.
