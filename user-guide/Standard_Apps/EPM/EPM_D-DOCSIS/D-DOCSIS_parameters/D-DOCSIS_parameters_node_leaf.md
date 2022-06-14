---
uid: D-DOCSIS_parameters_node_leaf
---

# D-DOCSIS parameters – Node Leaf

This page contains an overview of the Node Leaf parameters available in the D-DOCSIS branch of the EPM Solution.

## KPIs & KQIs

- **Number IF Down**: Calculated. The number of interfaces that were once known to be up to DataMiner, but which are currently down.

  Calculated by counting the number of qualifying DCF interfaces with Operational Status equal to "Down".

- **Number IF Over-Utilized**: Calculated. The number of interfaces that are over-utilized according to the utilization threshold configuration.

  Calculated by counting the number of DCF interfaces above the utilization threshold.

- **Number IF with Errors**: Calculated. The number of interfaces with 1 or more errors (In/Out).

  Calculated by counting the number of DCF interfaces with errors.

  - Input Errors OID: 1.3.6.1.2.1.2.2.1.14.
  - Output Errors OID: 1.3.6.1.2.1.2.2.1.20.

- **Number RPD Connected (RPDs Served)**: Calculated. The total number of RPDs related to the node leaf as found in the Node Leaf Relations table.

  Only unique relations are counted, which means that the calculation does not take into account two connections for the same RPD.

  The connections are based on the LLDP Remote Connections table, OID 1.0.8802.1.1.2.1.4.1.

- **Percentage RPD Offline (% RPDs Offline)**: Calculated. The percentage of connected RPDs of which the status is equal to "Offline".

  The status is found in the RPD table.

  The RPD Status is retrieved from the Smart Phy API using the call "v1/smartphycache/rpd/details/active/1".

- **CPU Utilization**: Direct value. The CPU utilization percentage of the flexible PIC concentrator.

  MIB OID 1.3.6.1.4.1.2636.3.1.13.1.8.*.

- **Memory Utilization**: Direct value. The percentage of kernel memory used for this subject.

  MIB OID 1.3.6.1.4.1.2636.3.1.13.1.11.*.

- **Temperature**: Direct value. The temperature sensors values.

  Retrieved from the Sensors/Operation Overview table. MIB OID 1.3.6.1.4.1.2636.3.1.13.

- **BGP Status: Calculated**. The global status of the Border Gateway Protocol (BGP) interfaces:

  - *Fail*: At least one entry in the State column (BGP M2 Peers table) is empty.
  - *OK*: All entries in the State column (BGP M2 Peers table) are populated.

  BGP M2 Peers table OID: 1.3.6.1.4.1.2636.5.1.1.2.1.1.

- **ISIS Neighbors Status**: Calculated. The global status of the Intermediate System to Intermediate System Protocol (ISIS) Neighbors interfaces. Possible values:

  - *Fail*: At least one entry in the State column (ISIS Neighbors table) has a value other than "Enabled".
  - *OK*: All entries in the State column (ISIS Neighbors table) are equal to "Enabled".

  OIDs:

  - ISIS Adjacency table OID: 1.3.6.1.2.1.138.1.6.1.
  - ISIS State OID: 1.3.6.1.2.1.138.1.6.1.1.2.

- **PIM Neighbors Status**: Calculated. The global status of the Protocol-Independent Multicast (PIM) Neighbors interfaces:

  - *Fail*: No neighbors are found, which means that the PIM Neighbors table will be empty.
  - *OK*: At least one neighbor is found in the PIM Neighbors table.

  Retrieved using the call "show pim neighbors | no-more".

- **MLD Status**: Calculated. The global status of the Multicast Listener Discovery (MLD) Neighbors:

  - *Fail*: No neighbors are found, which means that the MLD Neighbors table will be empty
  - *OK*: At least one neighbor is found in the MLD Neighbors table.

  Retrieved using the call "show mld group | no-more".

- **Last Updated**: Calculated. The last time the CLI was updated.

  This is updated to the current time after the CLI finishes polling.

- **Status**: Calculated. Indication of whether the protocol is actively polling the CLI interface.

  This is updated to the current status of CLI polling.

## System parameters

- **Name**: Direct value. The DataMiner element name.

  Retrieved from OID 1.3.6.1.2.1.1.5.

- **Hub**: Direct value. The name of the physical location (also known as "Site") of the entity.

  Retrieved from the custom property *Location Name*.

- **Market**: Direct value. The region where the entity is physically located.

  Retrieved from the custom property *Location Region*.

- **System Description**: Direct value. The system description of the entity (also known as "Software Description" or "Software Version").

  Requires trending for integration with IDP.

  SNMP MIB: 1.3.6.1.2.1.1.1.0.

- **Uptime**: Direct value. The time since the network management part of the system was last re-initialized.

  MIB OID: 1.3.6.1.2.1.1.3.0.

- **Entity Type**: Direct value. The entity type (also known as device type).

  Retrieved from the associated *ENTITY TYPE* custom property.

- **Serial Number**: Direct value. The entity serial number.

  MIB OID: 1.3.6.1.4.1.2636.3.1.13.
- **Model**: Direct value. The device model.

  MIB OID: 1.3.6.1.2.1.1.2.0.

- **IP**: Direct value. The IP address of the device.

  Retrieved from the element configuration.

- **City**: Direct value. The city of the system location.

  Retrieved from the custom property *Location City*.

- **Site**: Direct value. The site of the system location.

  Retrieved from the custom property *Location Site*.

- **Last Config Change**: Direct value. The date and time when the configuration was last changed.

  MIB OID: 1.3.6.1.4.1.2636.3.18.1.3.0.

- **Software Version**: Direct value. The system software version.

  MIB OID: 1.3.6.1.2.1.25.6.3.1.2.2.

- **Sensors**: Direct value. The entity sensors information.

  SNMP OID: 1.3.6.1.4.1.2636.3.1.13.

- **Interfaces**: Direct value. The entity interfaces details.

  SNMP OID: 1.3.6.1.2.1.2.2.

- **ARP**: Direct value. The entity address resolution protocol (ARP) details.

  SNMP OID: 1.3.6.1.2.1.4.22.

- **LLDP**: Direct value. The entity Link Layer Discovery Protocol details.

  SNMP OID: 1.0.8802.1.1.2.1.4.1.

- **Inventory**: Direct value. The entity inventory details.

  Retrieved using the call "show chassis hardware | no-more".

- **IPv4**: Direct value. The entity IPv4 statistics.

  SNMP MIB: 1.3.6.1.2.1.4.x.x.

- **IPv6**: Direct value. The entity IPv6 statistics.

  SNMP MIB: 1.3.6.1.4.1.2636.3.11.1.1.x.x.

- **OPTIC**: Direct value. The entity optics details.

  Retrieved using the call "show interfaces diagnostics optics | no-more".

- **STATS**: Calculated. The interface statistics.

  This is a combination of the ifTable (SNMP OID 1.3.6.1.2.1.2.2) and ifXTable (SNMP OID 1.3.6.1.2.1.31.1.1) filtered to bandwidths larger than 10000 Mbps.

- **LLDP**: Direct value. The remote LLDP connections.

  SNMP OID: 1.0.8802.1.1.2.1.4.1.

## Data layer parameters

- **Temperature**: Master Running Engine Temperature.

  SNMP data retrieved from PID 104, OID 1.3.6.1.4.1.2636.3.1.13.1.7.

- **BGP Status**: The status of the BGP communication.

  SNMP data retrieved from PID 34003, OID 1.3.6.1.4.1.2636.5.1.1.2.1.1.1.2.

- **ISIS Status**: The status of the ISIS communication.

  SNMP data retrieved from PID 33802, OID 1.3.6.1.2.1.138.1.6.1.1.2.

- **PIM Status**: The status of the PIM interfaces.

  Retrieved using the call "show pim neighbors | no-more".

- **MLD Status**: The status of the MLD interface.

  Retrieved using the call "show mld group | no-more".

- **Name**: The node leaf name.

- **Uptime**: The time since the network management part of the system was last re-initialized.

  MIB OID: 1.3.6.1.2.1.1.3.0.

- **Device Type**: Displays the device type (node leaf).

- **Serial Number**: The vendor-specific serial number of the physical entity.

  MIB OID: 1.3.6.1.4.1.2636.3.1.8.1.7.

- **Model**: Displays the device model.

  MIB OID: 1.3.6.1.2.1.1.2.0.

- **IP**: The IP address of the device.

- **City**: The city name of the system location.

  MIB OID: 1.3.6.1.2.1.1.6.0.

- **Site**: The site name of the system location.

  MIB OID: 1.3.6.1.2.1.1.6.0.

- **Last Config Change**: The date and time when the configuration was last changed.

  MIB OID: 1.3.6.1.4.1.2636.3.18.1.3.0.

- **Software Version**: The system software version.

  MIB OID: 1.3.6.1.2.1.25.6.3.1.2.2.

- **Operating Table Instance**

- **Display Key (IDX)**

- **Part Description**

- **Part State**: The current part state.

  MIB OID: 1.3.6.1.4.1.2636.3.1.13.1.6.

- **Temp.**: The current operating temperature.

  MIB OID: 1.3.6.1.4.1.2636.3.1.13.1.7.

- **CPU**: The percentage of the CPU being utilized.

  MIB OID: 1.3.6.1.4.1.2636.3.1.13.1.8.

- **Buffer Size**: The buffer pool utilization percentage.

  MIB OID: 1.3.6.1.4.1.2636.3.1.13.1.11.

- **Serial Number**: The vendor-specific serial number of the entity.

  MIB OID: 1.3.6.1.4.1.2636.3.1.8.1.7.

- **Revision**: The operating table revision.

  MIB OID: 1.3.6.1.4.1.2636.3.1.8.1.8.

- **Part Number**: The part number.

  MIB OID: 1.3.6.1.4.1.2636.3.1.8.1.10.

- **Container**: The operating table container.

  MIB OID: 1.3.6.1.4.1.2636.3.1.12.1.8.

- **Container State**: The current state of the container.

  MIB OID: 1.3.6.1.4.1.2636.3.1.12.1.6.

- **FRU State**: The field replaceable unit state.

  MIB OID: 1.3.6.1.4.1.2636.3.1.15.1.8.

- **FRU Type**: The field replaceable unit type.

  MIB OID: 1.3.6.1.4.1.2636.3.1.15.1.6.

- **FRU Offline Reason**: The field replaceable unit offline reason.

  MIB OID: 1.3.6.1.4.1.2636.3.1.15.1.10.

- **DRAM Size**: The dynamic random access memory size.

  MIB OID: 1.3.6.1.4.1.2636.3.1.13.1.10.

- **Monitoring**: Operating table monitoring information.

  Retrieves user input (Monitoring/Not Monitoring).

- **State**: The state of a row.

- **Descr (IDX)**: The interface description.

  MIB OID: 1.3.6.1.2.1.2.2.1.2.

- **Alias**: Alias name for the interface as specified by a network manager.

  MIB OID: 1.3.6.1.2.1.31.1.1.1.18.

- **Admin State**: The desired state of the interface.

  MIB OID: 1.3.6.1.2.1.2.2.1.7.

- **Operator State**: The state as assigned by the operator. The testing state indicates that no operational packets can be passed.

  MIB OID: 1.3.6.1.2.1.2.2.1.8.

- **Util Percentage IN**: The percentage of the total bandwidth that is being used by the input.

- **Util Percentage OUT**: The percentage of the total bandwidth that is being used by the output.

- **Util Percentage Total**: The amount of the total bandwidth used.

- **Utilization**: Sum of the IN and OUT bitrate of this interface.

- **Bitrate IN**: The number of kbits per second (kbps), delivered by this (sub-)layer to its next higher (sub-)layer.

  MIB OID: 1.3.6.1.4.1.2636.3.3.1.1.7

- **Bitrate OUT**: The number of kbits per second (kbps), delivered by this (sub-)layer to its next lower (sub-)layer.

  MIB OID: 1.3.6.1.4.1.2636.3.3.1.1.8.

- **Errors Total**: The sum of the errors in and out of the system.

- **FEC Uncorrected Error Rate**: The rate of the FEC uncorrected errors of the system.

- **Frame Errors IN**: The number of input packets that were misaligned.

  MIB OID: 1.3.6.1.4.1.2636.3.3.1.1.10.

- **L2 Mismatch Timeouts**: The number of malformed or short packets that cause the incoming packet handler to discard the frame as unreadable.

  MIB OID: 1.3.6.1.4.1.2636.3.3.1.1.19.

- **Collisions OUT**: The number of output collisions detected on this interface.

  MIB OID: 1.3.6.1.4.1.2636.3.3.1.1.25.

- **Protocol Error**: The number of packets received via the interface that were discarded because of an unknown or unsupported protocol.

  MIB OID: 1.3.6.1.2.1.2.2.1.15.

- **Speed**: An estimate of the interface's current bandwidth.

  MIB OID: 1.3.6.1.2.1.31.1.1.1.15.

- **Name**: The interface name.

  SNMP data retrieved from PID 202, MIB OID 1.3.6.1.2.1.2.2.1.2.

- **Physical Address**: The media-dependent physical address.

  MIB OID: 1.3.6.1.2.1.4.22.1.2.

- **IP Address**

- **Type**: The type of mapping.

  MIB OID: 1.3.6.1.2.1.4.22.1.4.

- **Local Interface Description**: The Link Layer Discovery Protocol interface description.

  SNMP data retrieved from PID 33308, MIB OID 1.0.8802.1.1.2.1.4.1.1.10.

- **Remote Interface Description**: The value used to identify the port component associated with the remote system.

  MIB OID: 1.0.8802.1.1.2.1.4.1.1.7.

- **Remote System Name**: The value used to identify the system name of the remote system.

  MIB OID: 1.0.8802.1.1.2.1.4.1.1.9.

- **Remote System Description**: The value used to identify the system description of the remote system.

  MIB OID: 1.0.8802.1.1.2.1.4.1.1.10.

- **Name (IDX)**: The inventory item name.

  Retrieved using the call "show chassis hardware | no-more".

- **Description**: The description of the inventory item.

  Retrieved using the call "show chassis hardware | no-more".

- **Operational Status**: The operational status.

  Retrieved using the call "show chassis hardware | no-more".

- **Manufacturer Name**: The manufacturer of the item.

  Retrieved using the call "show chassis hardware | no-more".

- **Serial Number**: The inventory item serial number.

  Retrieved using the call "show chassis hardware | no-more".

- **Part Number**: The part number of the inventory item.

  Retrieved using the call "show chassis hardware | no-more".

- **Number of Ports**: The number of ports.

  Retrieved using the call "show chassis hardware | no-more".

- **Function**: Calculated. The element CIN function as specified in the associated custom property.

  Retrieved from the *CIN FUNCTION* custom property.

- **Node Leaf**: Calculated. Table displaying all CIN (Converged Interconnect Network) entities operating as node leaves, which means they should be directly connected to at least one CCAP core.

  The table displays all CIN entities with Function equal to "Node Leaf".

- **Node Leaf Relations**: Calculated. Table displaying all known CIN relations from the perspective of the core leaves.

  The source in the table lists all known core leaves, and the destinations list all connections/relations within the CIN.

  The relations are learned via LLDP or similar protocol.

- **Destination Hop**: Incremental counter of the known relations from the given source to destinations of the same function.

  Note that multiple connections (interfaces) between a source and a destination are counted as a single hop as the hop count is only affected by the existence of at least one connection between the source and the given destination. For example, if a source is known to be connected to 10 destinations with function "CCAP Core", then there will be 10 incremental hops for the source.

- **CIN Interface**: Calculated. CIN-facing interfaces to be used by EPM towards CIN entities relations and KPI reporting.

  These are the CIN-facing interfaces as provisioned through EPM.

- **Utilization Status**: Calculated. The utilization status of the interface (retrieved from the CIN Interface table), which can be *OK* or *Overutilized*.

  This status is based on the utilization threshold set for each entity type.

- **Connection Status**: Calculated. The connection status (OK/Unreachable) according to ping result.

  The ping is performed against the IP address reported in the CIN Overview table. The frequency of the ping is determined by the virtual interval.

- **BGP**: Information on the Border Gateway Protocol (BGP) interfaces.

  MIB OID: 1.3.6.1.4.1.2636.5.1.1.2.1.1.

- **PIM**: Information on the Protocol-Independent Multicast (PIM) Neighbors interfaces.

  Retrieved using the call "show pim neighbors | no-more".
