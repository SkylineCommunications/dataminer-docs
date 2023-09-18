---
uid: Connector_help_TDC_OLT_CM_Collector
---

# TDC OLT CM Collector

This connector will poll info from cable modems (CMs) and Huawei MA5800-MA5633 (OLT) via SNMP.

## About

This connector uses SNMP on the standard DOCSIS MIBs to collect info from CMs and OLT.

The CM data is polled multithreaded and the OLT data is polled with three threads (multipleGetBulk). This is different from the Generic DOCSIS Cable Modem Collector where all data is polled multithreaded.

This data should be aggregated and displayed by a CPE Manager. The data is not intended to be consulted directly by an operator, so the data pages of the element will not be accessible.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**        |
|------------------|------------------------------------|
| 1.0.0.x          | DOCSIS 2.0, DOCSIS 3.0, DOCSIS 3.1 |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection to connect to the CMs and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: 127.0.0.1 (random)

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. Default value: *public*.
- **Set community string**: The community string used when setting values on the device. Currently no sets are done from the connector. Default value: *private*.

#### SNMP CMTS connection

This connector uses a Simple Network Management Protocol (SNMP) connection to connect to the CMTS and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: 127.0.0.1 (random)

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. Default value: *public*.
- **Set community string**: The community string used when setting values on the device. Currently no sets are done from the connector. Default value: **private*.*

### Configuration of Provisioning

After the collector element has been created, all configuration should be done via the CPE Manager element.

### Configuration of Offload

The following parameters can be set via **multiple set** in order to configure the offload mechanism:

- **CM Offload State**: Enables or disables the offload mechanism. Default value: *Disabled.*

- **CM Offload Directory**: The root directory where the CM offload files will be stored.

  - The directory can be a shared folder, where the credentials can be set using the **PNM Share Username** and **PNM Share Password** parameters.
  - A folder will be created per OLT with its name - the **OLT Name** is retrieved via **full provisioning** (see important note below).
  - Default value: *\\80.62.121.234\c\$\Skyline_Data\CM Offload\\*

- **Cleanup State**: Enables or disables the file cleanup mechanism.

  - If enabled, all files in the **CM Offload Directory** that are older than the age defined in the **File Age Threshold** parameter will be deleted.
  - This parameter is automatically enabled when the **CM Offload State** is also enabled.
  - Default value: *Disabled.*

- **File Age Threshold**: Determines for how long files are stored in the **CM Offload Directory** before they are deleted to free up space.

  - Range between *8 hours* and *1 year*, with 8-hour increments.
  - Default value: *2 weeks*

- **CM Config String**: All the column parameters that should be offloaded for the **CM** table, except the data related to **CM QAM DS Channels**.

  - Multiple columns are allowed, using a comma (",") as separator.
  - The primary key will always be offloaded as the first column.

- **CM QAM DS Channels Config String**: All the column parameters related to **CM QAM DS Channels** that should be offloaded for the **CM** table.

  - Multiple columns are allowed, using a comma (",") as separator.

  - The primary key will always be offloaded as the first column.

  - The columns related to **CM QAM DS Channels** data are:

    - CM QAM DS Avg Rx Power
    - CM QAM DS Avg Rx MER
    - CM QAM DS Sum Codewords
    - CM QAM DS Sum Corrected Codewords
    - CM QAM DS Sum Uncorrected Codewords

- **CM QAM US Channels Config String**: All the column parameters that should be offloaded for the **CM QAM US Channels** table.

  - Multiple columns are allowed, using a comma (",") as separator.
  - The primary key will always be offloaded as the first column.

- **CM OFDM DS Channels Config String**: All the column parameters that should be offloaded for the **CM OFDM DS Channels** table.

  - Multiple columns are allowed, using a comma (",") as separator.
  - The primary key will always be offloaded as the first column.

- **CM OFDMA US Channels Config String**: All the column parameters that should be offloaded for the **CM OFDMA US Channels** table.

  - Multiple columns are allowed, using a comma (",") as separator.
  - The primary key will always be offloaded as the first column.

Important note: The collector element needs to retrieve its **OLT Name** from the IAM database, so the offload files are stored in the correct folder structure. The retrieval is done via **full provisioning**.

## Usage

The data pages of this element are not intended to be accessed by operators. As such, there are no parameters available that can be configured on these pages.

All monitoring and configuration should be done through a CPE Manager element.

### AMP Chain Import

The **BE Managers** have the possibility to export AMP Chain data to be further ingested by the **CM Collectors** (*TDC OLT CM Collector*). This data is useful to map the CM's channels to amplifiers (on dashboards, for example).

If **CM AMP Chain Import State** is *enabled*, the **CM Collector** will search for the newest file in the **CM AMP Chain Import Folder**, during the full provisioning and once 35 minutes after the startup of the element. The collector will not search in the backup folder. The result status is displayed by the **CM AMP Chain Import Status** parameter.

The data will be added to the **AMP Chain** column of all 4 channel tables (**CM QAM DS Channels**, **CM QAM US Channels**, **CM OFDM DS Channels** and **CM OFDMA US Channels**).
