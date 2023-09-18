---
uid: Connector_help_OIV_SLA_Corrections
---

# OIV SLA Corrections

This is a custom connector for OiV that will perform calculations and automatically apply corrections and add outages to SLA elements in their DMS.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

## How to use

On the **General** page, you can find the **SLA Table**, displaying all the SLAs that are being actively corrected by the connector, as well as the **Total SLAs Outages/Violations**. You can select different locations for each SLA. These locations are defined in the **Location** page.

The General page also contains a page button to the **SLA Configuration** subpage, where a table shows all the SLA elements in the DMS. Here you can enable or disable corrections for each SLA.

The Locations page contains the **Locations** table, where different locations can be **added** and **configured**. You can configure the **Category**, **Time Span Profile**, and **Time Spans factor** for each location.

On the Configuration page, you can check the time of the **Last Correction**, configure the **Correction Frequency** and the **Batch** (number of SLA elements to be corrected in one go), and add/configure the time spans in the **Time Spans** table.
