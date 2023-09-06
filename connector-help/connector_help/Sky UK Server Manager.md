---
uid: Connector_help_Sky_UK_Server_Manager
---

# Sky UK Server Manager

This is an enhanced service protocol that can be used to monitor subscribed elements. It gathers and updates all alarms from the elements in a single alarm table.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

This protocol is intended to be used for services. When you create a service, in the advanced options section, select it as the service protocol. Then select the necessary elements and parameters, as described in the [DataMiner Help](https://help.dataminer.services/dataminer/#t=DataMinerUserGuide/part_2/services/Adding_a_service.htm).

The following default protocols and parameters need to be included:

| **Protocol**          | **Description**                                                                                                |
|-----------------------|----------------------------------------------------------------------------------------------------------------|
| Linux Platform SNMP   | Total Processor LoadPhysical Memory UsageTotal Physical MemoryStorage TableTask Manager\[Element Alarm State\] |
| Generic Trap Receiver | Traps                                                                                                          |
| plunk Enterprise      | \[Element Alarm State\]                                                                                        |

### Initialization

No extra configurations are needed.

### Redundancy

There is no redundancy defined.

## How to use

The following pages are available:

- **General**: Shows a status overview of the elements included in the service. Also contains the DMA and Service update status.
- **Alarms**: Shows the alarm information that is built/updated based on the workflow.
- **Servers**: Shows memory and CPU information for the subscribed Linux servers. You can configure memory and CPU thresholds, above which the workflow will generate warning and critical alarms.
- **Subscriptions**: Contains the subscription information of the subscribed parameters.
- **App**: Lists the apps/processes running on the subscribed Linux servers.
- **Mounts**: Lists the mount points available on the subscribed Linux servers.
- **Config**: Allows you to configure the names and different threshold values for the desired mounts and apps. The mount point that defines whether a server is active or not is configured in the Desired Mounts table. Via the **VCS Config** page button, you can configure the VCS filters used for the filtering of the VCS traps.
- **VCS**: Displays the list and status of the Splunk elements, as well as traps information. Click the Delete button in the Traps table to remove an entry from the Traps Table of the corresponding VCS element.
