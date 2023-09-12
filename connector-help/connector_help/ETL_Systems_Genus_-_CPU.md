---
uid: Connector_help_ETL_Systems_Genus_-_CPU
---

# ETL Systems Genus - CPU

This module displays information about the ETL Systems Genus CPU.

## About

This driver is exported by the parent driver [ETL Systems Genus](xref:Connector_help_ETL_Systems_Genus).

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | e530 1v9 6/8/2020      |

## How to use

The element created with this driver consists of the following data pages:

- **General**: Displays system information such as the **Summary Alarm** and the **Operation Time**. The following control features are also available: **Clear Alarm**, **Reboot** and **ETL Discovery**.
- **IP Settings**: Allows you to configure settings, such as enabling or disabling **DHCP** and defining the **IP** **Address**.
- **TCP/IP Port**: Allows you to enable or disable the TCP/IP **State**, and define the **Data Port** and the **Timeout**.
