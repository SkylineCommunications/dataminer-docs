---
uid: Connector_help_Nutanix_Prism
---

# Nutanix Prism

This driver is an HTTPS driver that communicates with the Nutanix Prism through its rest API. This allows you to manage your global Nutanix hyperconverged infrastructure (HCI) from one console.
This HCI combines servers and storage into a distributed infrastructure platform with intelligent software to create flexible building blocks that replace legacy infrastructure consisting of separate servers, storage networks, and storage arrays. More specifically, it combines commodity data center server hardware with locally attached storage devices (spinning disk or flash) and is powered by a distributed software layer to eliminate common pain points associated with legacy infrastructure.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v2.0                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTPS Main Connection

This driver uses an HTTPS connection and requires the following input during element creation:

HTTPS CONNECTION:

- **IP address/host**: [https://\[PollingIp\]](). Note that you must specify the "https://" prefix in the address field, as a different port than 443 is polled. For more information, refer to the [DataMiner Development Library](https://help.dataminer.services/development/#t=DataMinerDevelopmentLibrary_Customer/part1PDG/PDGConnections/HTTPS.htm).
- **IP port**: *9440*
- **Device address**: *BypassProxy*

### Initialization

Configure the **credentials** to log in on the **General** page so that information can be retrieved.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver consists of the following data pages:

- **General**: Allows you to configure the credentials to retrieve information with this driver. Also contains summary information related to storage, VM, hardware and cluster.
- **Health Checks**: Contains a table with health information.
- **VM**: Contains all VM-related information such as VM(s), VM(s) on and off, the Provisioned VCPUs and Total Provisioned Memory. On the **VM Table** subpage, you can find tables with information related to each specific VM and virtual disk.
- **Storage**: Contains storage-related information such as Storage Free and Capacity, as well as cluster-related information such as Cluster-Wide Controller IOPS, Bandwidth and Latency. On the **Storage Tables** subpage, you can find more detailed information about each storage container and cluster.
- **Hardware**: Contains a summary of hardware information, including the total numbers of hosts, disks, HDD, SSD, CPU and memory. On the **Hardware Tables** subpage, you can find detailed information about each host and disk.
- **Alerts**: Lists all alerts and events.
- **Tasks**: Lists all tasks.
