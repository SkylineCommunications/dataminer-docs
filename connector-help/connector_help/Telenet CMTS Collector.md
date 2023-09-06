---
uid: Connector_help_Telenet_CMTS_Collector
---

# Telenet CMTS Collector

The **Telenet CMTS Collector** is part of the Telenet EPM (CPE) setup. At present, the CMTS will be polled to retrieve the MER and UFEC values of the active upstream OFDMA channels. These values will be offloaded into CSV files and will also be displayed in the **Telenet CPE Manager** elements. As these values are requested from proprietary OIDs of a CASA C100G MIB, this is the only CMTS that is currently supported. However, expansion to other CMTS types or other OIDs is possible in the future.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | CASA C100G             |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | Telenet CPE Manager   | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default: *private*. (Note that currently no sets on the device will happen, which makes this setting irrelevant.)

### Initialization

When the element is initialized, no additional configuration is needed to get the polling active. All you need to do is enable the offload when necessary. You can also fine-tune the settings on the **Configuration** page.

## How to Use

SNMP will be used to get the values; however, only the US OFDMA Channels table will be visible in Stream Viewer. Because of the large size of the other tables, these need to be requested filtered, and this is done through an alternative way for which no communication is shown in Stream Viewer.

The **General** page gives an overview of the **US OFDMA Interfaces** in the table. Only those interfaces will be taken into account for the other measurements that have both the **Admin** and **Operational Status** set to *Up*.

The actual measurement results are shown on the **Minislots** page.

Various settings can be changed on the **Configuration** page. The **Minislot Measurements Poll Period** allows you to configure how often the MER and UFEC have to be polled. Similar configuration is available for the **Frequency Map Poll Period**; however, as these values are quite static, it can be polled at a lower speed. Do note that even if the polling of the frequency map is disabled, polling will still be executed when the minislots polling is enabled and new interfaces are available. This is because the minislot measurements rely on the frequency map info.

The **MER** and **UFEC** can also be offloaded when the configured absolute **Delta Threshold** values are breached, or once per day at the configured **Slow Offload Time**. You can also disable the offload functionality.

The offload files will be placed under the *Ofdma_Mer* subfolder of the configured **Offload Directory**. New file names will get an incremental number that will wrap when the configured **Data Offload Maximum Backup** is reached. This ensures all disk space does not get occupied when the files do not get processed.

## Notes

The generated offload file has the following fields:

*Timestamp CMTS_Name Slot Port Channel Node Description Profile_Number Minislot_Number Frequency Modulation MER UFEC_Delta*

When an US OFDMA goes down, it will offload a line with "-1" values from the Profile_Number field onwards.
