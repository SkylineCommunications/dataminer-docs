---
uid: Connector_help_Verizon_Computer_Associates_Interface
---

# Verizon Computer Associates Interface

The Verizon Computer Associates Interface collects trending data from the collectors on the same DMA. The data is uploaded to a Linux box using SCP.

## About

### Version Info

| **Range**            | **Key Features**                                   | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | \- SLNet GetTrendMessage - SCP                     | \-           | \-                |
| 1.0.1.x              | Data retrieval from central database implemented.  | 1.0.0.1      | \-                |
| 1.0.2.x \[SLC Main\] | Data retrieval from CSV offload files implemented. | 1.0.1.6      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |
| 1.0.1.x   | N/A                    |
| 1.0.2.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

The **Process Overview** table is initialized with static values after the element is created. Two processes, *CA_PERF_DATA* and *CA_SUN_OUTAGE_DATA*, are defined in this version.

### Redundancy

There is no redundancy defined.

## How to use

### Data Subscription table

In the **Data Subscription** table, KPI and config entries are defined. You can add, edit or delete entries via the right-click menu. This data is used to generate both performance_data and sunoutage_data files.

- Enter the Name (i.e. the name displayed in DataMiner), and the connector automatically adds the alias to the Alias column. If the Name does not occur in the pre-configured pairs, the connector will return an empty string.
- Four types exist in the connector: KPI, N/A, Sun Outage, and Config.

  - **KPI**

    | DataMiner name      | Alias (used for the entry points) --\> used by a third-party tool     |
    |---------------------|-----------------------------------------------------------------------|
    | SLA Site Status     | Active Mode                                                           |
    | Temperature         | Temperature                                                           |
    | RTN OTA Traffic     | Upstream OTA Traffic                                                  |
    | SLA Packet Delivery | Packet Loss                                                           |
    | FWD C/N             | Downstream C/N                                                        |
    | FWD OTA Traffic     | Downstream OTA Traffic                                                |
    | SLA Latency         | Latency                                                               |
    | RTN C/N             | Upstream C/N                                                          |

  - ***Config (common for both KPI and SunOutage types)***

    | DataMiner name      | Alias (used for the entry points) --\> used by a third-party tool     |
    |---------------------|-----------------------------------------------------------------------|
    | VCircuit ID         | circuit_id                                                            |
    | Circuit ID          | vsat_circuit_id                                                       |
    | Location Name       | esp_short_name                                                        |
    | ESP Customer Name   | etms_customer_name                                                    |
    | GCH ID              | gchid                                                                 |
    | VRF                 | vrf_name                                                              |
    | Customer Short Name | etms_customer_short_name                                              |
    | DNS Entity Name     | dns_entity_name                                                       |
    | Customer Number     | etms_customer_number                                                  |

    ***Sun Outage***

    | DataMiner name                                                                  | Alias (used for the entry points) --\> used by a third-party tool     |
    |---------------------------------------------------------------------------------|-----------------------------------------------------------------------|
    | Sun Outage Duration                                                             | duration                                                              |
    | Sun Outage Season                                                               | season                                                                |
    | Sun Outage Year *(if start is not present, the connector will add an empty value)* | year                                                                  |
    | Sun Outage Peak                                                                 | peak                                                                  |
    | Sun Outage Start                                                                | start                                                                 |
    | Sun Outage End                                                                  | end                                                                   |

### Process Profile table

The **Process Profile** table contains the settings to connect to the Linux Box: protocol, username, password, endpoint (Linux's IP) and remote path. You can add, edit or delete entries via the right-click menu of the table.

### Process Overview table

The element also contains a **Process Overview** table, where you can change the **profile**. The options in the Profile drop-down list correspond to the entries in the **Name** column of the **Process Profile** table.

The connector handles two processes:

1. **CA_SUN_OUTAGE:** This process is executed every day at 11:00 PM and a file is saved in a Linux box via SCP. The values come from the **subscriptions** (Sun Outage entries) present in the **Data Subscription** table.
1. **CA_PERF_DATA:** This process collects trend data (KPI entries) from the collectors (the last hour). The file is saved in the Linux box via SCP.

### Debug page

On the Debug page, a number of parameters are available that can be of use to troubleshoot issues:

- **Debug**: Determines whether the Debug Information page is displayed.

- **Debug State**: Can be enabled to add extra log messages in the Element Log console. By default, this is disabled.

- **Entity Export/Import Settings:** These settings handle the **export of** **configuration files** and **import of provisioning files**. You can:

  - **Enable/disable** the export and import feature with the **Entity Export** and **Entity Import** toggle button, respectively.

  - Specify the **path** where files will be exported and imported, with the **Entity Export Directory** and **Entity Import Directory** parameters, respectively.

  - Switch between exporting/importing to a **local or remote location** by using the toggle button **Entity Export Directory Type** or **Entity Import Directory Type**, respectively.

    Note that for the remote file handling feature to work, you must enter the credentials for the system in the **System Credentials** section and enter the path to the remote directory in the **Entity Export/Import Directory** parameter. The **path** **must be shared/accessible**.

  - Perform an export or import by clicking the **Apply** button in the relevant section.

## Notes

If the **Data Subscription** table is empty, the file will not be created.

If the **Process Profile** table is empty, the file will not be uploaded to the Linux box.
