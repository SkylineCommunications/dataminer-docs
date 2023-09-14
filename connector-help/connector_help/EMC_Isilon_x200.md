---
uid: Connector_help_EMC_Isilon_x200
---

# EMC Isilon x200

The **EMC Isilon x200**, powered by the OneFS operating system, uses a versatile but simple scale-out storage architecture to allow rapid access to massive amounts of data, while reducing cost and complexity.

This connector was designed to make the current statistics provided by the device available in an element.

## About

This connector makes use of **HTTP** commands to retrieve information about the current statistics. The information is retrieved using the Isilon **OneFS API Reference**.

Data is polled at 15-second intervals. The **Session Cookie** will be renewed automatically after the **Session Timeout Absolute** has expired.

For more information, refer to <https://store.emc.com/us/Product-Family/ISILON-PRODUCTS/EMC-Isilon-X210/p/EMC-Isilon-X210>.

### Version Info

| **Range** | **Description**                                                         | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                                                        | No                  | Yes                     |
| 1.0.1.x          | Based on 1.0.0.4. Uses dynamic IP for redundancy.                       | No                  | Yes                     |
| 2.0.0.x          | Based on 1.0.0.4. Adds a second HTTP connection, for manual redundancy. | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**    |
|------------------|--------------------------------|
| 1.0.0.x          | B_7_2_0_061R (Cluster version) |
| 1.0.1.x          | B_7_2_0_061R (Cluster version) |
| 2.0.0.x          | B_7_2_0_061R (Cluster version) |

## Installation and configuration

### Creation

#### HTTP main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. By default, *8080*.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

#### HTTP secondary connection

In branch 2.0.0.x, this connector uses a secondary HTTP connection, which requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. By default, *8080*.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

### Configuration of credentials

In order to start a new cookie session between DataMiner and the OneFS system, you must set the **OneFS User Name** and **Password** on the **General** page.

**Note:** If you need a **CSRF Authentication Cookie**, please **enable this option**, otherwise you will **not be able to poll information** from the device.

## Usage

### General

On this page, the **OneFS User Name**/**Password** must be set.

Below this, information is displayed about the currently established session. In branch 2.0.0.x, there is not only information on the currently established session, but also on the connectivity of the two HTTP connections.

With the buttons on the right-hand side of the page, you can enable or disable polling of a certain group of keys. In branch 2.0.0.x, these **polling** controls are on the left.

### Cluster

This page displays general information about the cluster, along with the **Cluster Health** status and the number of critical alarms on the nodes.

### Cluster CPU

On this page, you can find statistics related to the **cluster CPU usage**.

### Cluster Disk

This page displays statistics related to the activity on the cluster disk.

### Cluster Ifs

This page displays statistics related to the /ifs file system.

### Cluster Protocol

This page displays performance statistics for protocols, totaled for this cluster per operation.

### Cluster Net

This page displays statistics related to external and internal interfaces in the cluster.

### Cluster Nodes

This page displays information about the state of the nodes in the cluster.

### Cluster Dedupe

This page displays statistics on the **Isilon's SmartDedupe** data deduplication option.

### Node Tree

This page shows all the information from the node-related pages in a **tree control**.

### Node

This is the main page for the nodes. It displays general state information for the 3 nodes available in the cluster.

### Node CPU

This page displays statistics related to the CPU usage of each of the nodes.

### Node Memory

This page displays statistics related to the memory usage of each of the nodes.

### Node Disk

This page contains statistics related to the disk usage of each of the nodes.

There are also several page buttons that lead to subpages with more information on access, available space and speed of the disk.

### Node Ifs

This page displays detailed statistics on the node's /ifs file system.

### Node Ifs Cache

This page displays detailed statistics on the node's /ifs cache file system.

### Node Ifs Heat

This page displays detailed statistics on the node's /ifs heat file system operations.

### Node Protocol

This page displays performance statistics per protocol for each of the available protocols.

### Node Interfaces

This page contains statistics related to the internal and external interfaces of the nodes.

### Node Interfaces Performance

This page displays statistics related to the performance of the interfaces.

### Node Client Stats

This page displays the number of simultaneously active/connected clients using a specific protocol, as well as detailed statistics on the protocols.

### Node Filesystem

This page contains statistics related to the capacity of the /root, /var and /var/crash file system.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

In order to properly parse the information coming from the device, you need to have .Net Framework 4.5 installed.
