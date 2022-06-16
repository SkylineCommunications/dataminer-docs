---
uid: D-DOCSIS_parameters_core_leaf
---

# D-DOCSIS parameters – Core Leaf

This page contains an overview of the Core Leaf parameters available in the D-DOCSIS branch of the EPM Solution.

## KPIs & KQIs

- **Number IF Down**: Calculated. The number of interfaces that were once known to be up to DataMiner, but which are currently down.

  Calculated by counting the number of qualifying DCF Interfaces with Operational Status equal to Down.

  - Interface table OID: 1.3.6.1.2.1.2.2.
  - Operational Status OID: 1.3.6.1.2.1.2.2.1.8.

- **Number IF Over-Utilized**: Calculated. The number of interfaces that are over-utilized according to the utilization threshold configuration.

  Calculated by counting the number of DCF interfaces above the utilization threshold.

  - In utilization calculated from In octets OID 1.3.6.1.2.1.2.2.1.10.
  - Out utilization calculated from out octets OID 1.3.6.1.2.1.2.2.1.16.
  - The total utilization is the average of the in and out utilization.

- **Number IF with Errors**: Calculated. The number of interfaces with 1 or more errors (In/Out).

  Calculated by counting the number of DCF interfaces with errors.

  - Input Errors OID: 1.3.6.1.2.1.2.2.1.14.
  - Output Errors OID: 1.3.6.1.2.1.2.2.1.20.

- **Number CCAP Unreachable**: Calculated. The number of CCAP cores that are unreachable to the core leaf.

  The calculation is based on the implicated IF interfaces operational statuses, which can be UP (Unreachable) or Down (Reachable). A CCAP is considered unreachable if there is not at least one pair of interfaces with Operation Status equal to UP allowing for a connection between the core leaf and the CCAP.

  - Interface table OID: 1.3.6.1.2.1.2.2.
  - Operational Status OID: 1.3.6.1.2.1.2.2.1.8.

- **Redundancy**: Calculated. The redundancy configuration of the entity.

  Calculated by retrieving the redundancy value (MIB OID: 1.3.6.1.4.1.2636.3.1.14.1.7) of the first entry in the Redundancy table (MIB OID: 1.3.6.1.4.1.2636.3.1.14).

- **CPU Utilization**: Direct value. The CPU utilization percentage of the flexible PIC concentrator.

  MIB OID: 1.3.6.1.4.1.2636.3.1.13.1.8.*.

- **Memory Utilization**: Direct value. The percentage of kernel memory used for this subject.

  MIB OID: 1.3.6.1.4.1.2636.3.1.13.1.11.*.

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

  MIB OID: 1.3.6.1.2.1.1.3.0

- **Entity Type**: Direct value. The entity type (also known as device type).

  Retrieved from the associated *ENTITY TYPE* custom property.

- **Serial Number**: Direct value. The entity serial number.

  MIB OID: 1.3.6.1.4.1.2636.3.1.13.

- **Model**: Direct value. The device model.

  MIB OID 1.3.6.1.2.1.1.2.0.

- **IP**: Direct value. The IP address of the device.

  Retrieved from the element configuration.

- **City**: Direct value. The city of the system location.

  Retrieved from the custom property *Location City*.

- **Site**: Direct value. The site of the system location.

  Retrieved from the custom property *Location Site*.

- **Last Config Change**: Direct value. The date and time when the configuration was last changed.

  MIB OID 1.3.6.1.4.1.2636.3.18.1.3.0.

- **Software Version**: Direct value. The system software version.

  MIB OID 1.3.6.1.2.1.25.6.3.1.2.2.

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

- **Part State**: The current part state.

  MIB OID 1.3.6.1.4.1.2636.3.1.13.1.6.

- **Name**: The interface name.

  SNMP data retrieved from PID 202, MIB OID 1.3.6.1.2.1.2.2.1.2.

- **Local Interface Description**: The Link Layer Discovery Protocol Interface Description.

  SNMP data retrieved from PID 33308, MIB OID 1.0.8802.1.1.2.1.4.1.1.10.

- **Remote Interface Description**: The value used to identify the port component associated with the remote system.

  MIB OID 1.0.8802.1.1.2.1.4.1.1.7.

- **Remote System Name**: The value used to identify the system name of the remote system.

  MIB OID 1.0.8802.1.1.2.1.4.1.1.9.

- **Remote System Description**: The system description of the remote system.

  MIB OID 1.0.8802.1.1.2.1.4.1.1.10.

- **Name (IDX)**:The inventory item name.

  Retrieved using the call "show chassis hardware | no-more".

- **Function**: Calculated. The element CIN function as specified in the associated custom property.

  Retrieved from the *CIN FUNCTION* custom property.

- **Core Leaf**: Calculated. Table displaying all CIN (Converged Interconnect Network) entities operating as core leaves, which means they should be directly connected to at least one CCAP core.

  The table displays all CIN entities with Function equal to "Core Leaf".

- **Core Leaf Relations**: Calculated. Table displaying all known CIN relations from the perspective of the core leaves.

  The source in the table lists all known core leaves, and the destinations all connections/relations within the CIN.

  The relations are learned via LLDP or similar protocol.

- **Destination Hop**: Calculated. Incremental counter of the known relations from the given source to destinations of the same function.

  Note that multiple connections (interfaces) between a source and a destination are counted as a single hop as the hop count is only affected by the existence of at least one connection between the source and the given destination. For example, if a source is known to be connected to 10 destinations with function "CCAP Core", then there will be 10 incremental hops for the source.

- **CIN Interface**: Calculated. CIN-facing interfaces to be used by EPM towards CIN entities relations and KPI reporting.

  These are the CIN-facing interfaces as provisioned through EPM.

- **Source IF Operational Status**: Calculated. The operational status of core leaf interfaces connected to other CIN entities.

- **Destination IF Operational Status**: Calculated. The operational status of external interfaces connected to the core leaf.

- **Utilization Status**: Calculated. The utilization status of the interface (retrieved from the CIN Interface table), which can be *OK* or *Overutilized*.

  This status is based on the utilization threshold set for each entity type.

- **Connection Status**: Calculated. The connection status (OK/Unreachable) according to ping result.

  The ping is performed against the IP address reported in the CIN Overview table. The frequency of the ping is determined by the virtual interval.

- **BGP**: Information on the Border Gateway Protocol (BGP) interfaces.

  MIB OID: 1.3.6.1.4.1.2636.5.1.1.2.1.1.

- **ISIS**: Information on the Intermediate System to Intermediate System Protocol (ISIS) Neighbors interfaces.

  MIB OID: 1.3.6.1.2.1.138.1.6.1.

- **PIM**: Information on the Protocol-Independent Multicast (PIM) Neighbors interfaces.

  Retrieved using the call "show pim neighbors | no-more".
