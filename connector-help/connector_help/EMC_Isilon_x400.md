---
uid: Connector_help_EMC_Isilon_x400
---

# EMC Isilon x400

The **EMC Isilon** scale-out NAS storage platform combines modular hardware with unified software to harness unstructured data and receive traps.

## About

This connector provides centralized monitoring and administration to manage the following features:

- A symmetrical cluster that runs a distributed file system.

- Scale-out nodes that add capacity and performance.

- Storage options that manage files, block data, and tiering.

- Flexible data protection and high availability.

- Software modules that control costs and optimize resources.

- Traps being received from

- Group state traps.
  - File system traps.
  - Smart quota traps.
  - Snapshot traps.
  - SyncIQ traps.
  - Software traps.
  - Avscan traps.
  - Net Proto traps.
  - Networking traps.
  - Hardware traps.
  - System disk traps.
  - Sensor traps.
  - Storage transport traps.
  - Cloud pools traps.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial range.  | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 7.2.1.2                     |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

### Configuration

No settings need to be configured for the element to work.

## Usage

### Status page

This is the main page, which contains a status overview of the cluster, node and hardware components.

It displays the **Cluster Status**, the **Node Status**, and several tables:

- Chassis Table
- Disk Table
- Fan Table
- Temperature Table
- Power Table
- Trap Table

### Performance page

This page displays the key performance indicators of the nodes and of the entire cluster.

It displays the **Cluster Performance**, **Node Performance** and **Node Performance Table**.

### Performance Component

On this page, you can see the **CPU Performance** and **Disk Performance**.

### Configuration page

This page contains the EMC Isilon licensable software that supports different product attributes, as well as the quota management tool. It contains the **Licenses**, **Quota**, and **SNMP Engine OIDs** (management SNMP) .

### Snapshots

This page contains the Isilon data cluster protection module, called **Snapshots**.

### Traps page

This page contains the **traps** table, displaying the traps that are received by the **trap receiver**. There is a **Delete Trap** button for each trap and a **Delete All** button to delete all received traps.

### Web Interface

On this page, you can access the NAS storage plaform via the EMC Isilon web interface. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
