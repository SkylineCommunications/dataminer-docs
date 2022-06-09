---
uid: D-DOCSIS_parameters_spine
---

# D-DOCSIS parameters – Spine

This page contains an overview of the Spine parameters available in the D-DOCSIS branch of the EPM Solution.

## KPIs & KQIs

- **Redundancy Current Role**: Direct value. The active role of the CPU node.

  Retrieved using the call "show redundancy".

- **Number IF Down**: Calculated. The number of interfaces that were once known to be up to DataMiner, but which are currently down.

  Calculated by counting the number of qualifying DCF Interfaces with Operational Status equal to "Down".

- **Number IF Over-Utilized**: Calculated. The number of interfaces that are over-utilized according to the utilization threshold configuration.

  Calculated by counting the number of DCF interfaces above the utilization threshold.

  - Interface table OID: 1.3.6.1.2.1.2.2.
  - In Octets (used for utilization calculation): 1.3.6.1.2.1.2.2.1.10.
  - Out Octets (used for utilization calculation): 1.3.6.1.2.1.2.2.1.16.

- **Number IF with Errors**: Calculated. The number of interfaces with 1 or more errors (In/Out).

  Calculated by counting the number of DCF interfaces with errors.

  - Interface table OID: 1.3.6.1.2.1.2.2.
  - In errors OID: 1.3.6.1.2.1.2.2.1.14.
  - Out errors OID: 1.3.6.1.2.1.2.2.1.20.

- **CPU Utilization**: Direct value. A 1-minute exponentially-decayed moving average of the CPU busy percentage.

  MIB OID: 1.3.6.1.4.1.9.2.1.57.0.

- **Memory Utilization**: Calculated. The average memory utilization.

  Calculated based on the Memory Used and Memory Free parameters from the SNMP Memory Pool table (MIB OID: 1.3.6.1.4.1.9.9.221.1.1.1).

- **Temperature**: Calculated. The temperature value for reported device parts.

  Retrieved from the sensors table, only exposing the temperature value.

  Temperature value OID: 1.3.6.1.4.1.9.9.91.1.1.1.1.1.

- **BGP IPv6 Unicast Status**: Calculated. The global status of the Border Gateway Protocol (BGP) IPv6 Unicast interfaces.

  - *Fail*: At least one entry in the State PfxRcd column is found to be empty.
  - *OK*: All entries in the State PfxRcd column are a number or a string.

  Retrieved using the call "show bgp ipv6 unicast sum".

- **BGP IPv6 Multicast Status**: Calculated. The global status of the Border Gateway Protocol (BGP) IPv6 Multicast interfaces.

  - *Fail*: At least one entry in the State PfxRcd column is found to be empty.
  - *OK*: All entries in the State PfxRcd column are a number or a string.

  Retrieved using the call "show bgp ipv6 multicast sum".

- **ISIS Neighbors Status**: Calculated. The global status of the Intermediate System to Intermediate System Protocol (ISIS) Neighbors interfaces.

  - *Fail*: At least one entry in the State column has a value other than "Up".
  - *OK*: All entries in the State column have the value "Up".

  Retrieved using the call "show isis neighbors".

- **PIM Neighbors Status**: Calculated. The global status of the Protocol-Independent Multicast (PIM) Neighbors interfaces.

  - *Fail*: No neighbors are found.
  - *OK*: At least one neighbor is found.

  Retrieved using the call "show pim neighbor".

- **Last Updated**: Calculated. The last time the CLI was updated.

  This is updated to the current time after the CLI finishes polling.

- **Status**: Calculated. Indication of whether the protocol is actively polling the CLI interface.

  This is updated to the current status of CLI polling.

## System parameters

- **Name**: Direct value. The DataMiner element name.

  This is the first part of the sysName (1.3.6.1.2.1.1.5.0).

- **Uptime**: Direct value. The entity uptime.

  MIB OID: 1.3.6.1.6.3.10.2.1.3.0.

- **Entity Type (Device Type)**: Direct value. The entity type (also known as device type).

  Retrieved from the custom property *ENTITY TYPE*.

- **Serial Number**: Direct value. The serial number of the entity.

  Retrieved from the *Chassis* row in Entity Physical table (MIB OID: 1.3.6.1.2.1.47.1.1.1.1.11).

- **IP Address**: Direct value. The element polling IP address(es).

  This parameter lists unique occurrences of IP address(es) specified in the element settings. In case there is more than one IP address, a comma is used as separator.

- **City**: Direct value. The city of the physical location of the entity.

  Retrieved from the custom property *Location City*, which is set by IDP when the element is created.

- **Site**: Direct value. The site of the physical location of the entity.

  Retrieved from the custom property *Location Site*, which is set by IDP when the element is created.

- **Hub**: Direct value. The name of the physical location (also known as "Site") of the entity.

  Retrieved from the custom property *Location Name*, which is set by IDP when the element is created.

- **Market**: Direct value. The region where the entity is physically located.

  Retrieved from the custom property *Location Region*, which is set by IDP when the element is created.

- **System Description**: Direct value. The entity software description (also known as "Software Description" or "Software Version").

  SNMP OID: 1.3.6.1.2.1.1.1.0.

- **Configuration Compliance**: Direct value. The entity configuration compliance status.

  Retrieved using HTTP endpoint na.dev.cox.com/soap > List Device.

- **Sensors**: Direct value. The entity sensors information.

  SNMP OID: 1.3.6.1.4.1.9.9.91.1.1.1

- **Interfaces**: Direct value. The entity interfaces details.

  SNMP OID: 1.3.6.1.2.1.2.2.

- **ARP**: Direct value. The entity address resolution protocol (ARP) details.

  SNMP OID: 1.3.6.1.2.1.4.22.

- **LLDP**: Direct value. The entity Link Layer Discovery Protocol details.

  SNMP OID: 1.0.8802.1.1.2.1.4.1.

- **Inventory**: Direct value. The entity inventory details.

  Retrieved using the call "show inventory".

- **IPv4**: Direct value. The entity IPv4 statistics.

  SNMP MIB: 1.3.6.1.2.1.4.31.3.

- **IPv6**: Direct value. The entity IPv6 statistics.

  SNMP MIB: 1.3.6.1.2.1.4.31.3.

- **STATS**: Calculated. The interface statistics.

  This is a combination of the ifTable (SNMP OID 1.3.6.1.2.1.2.2) and ifXTable (SNMP OID 1.3.6.1.2.1.31.1.1) filtered to bandwidths larger than 10000 Mbps.

- **LLDP**: Direct value. The remote LLDP connections.

  SNMP OID: 1.0.8802.1.1.2.1.4.1.

- **OPTICS**: Direct value. The entity optics details.

  Retrieved using the call "show controller optics \<opticsIndex>".

## Data layer parameters

- **Optics Details Table**: The optics details retrieved from the command line interface.

  Retrieved using the call "show controller optics \<opticsIndex>".

- **Optics \[IDX] (Optics Details Table)**: The optics name.

  Retrieved using the call "show controller optics \<opticsIndex>".

- **Controller State (Optics Details Table)**: The controller state.

  Retrieved using the call "show controller optics \<opticsIndex>".

- **Transport Admin State (Optics Details Table)**: The transport admin state.

  Retrieved using the call "show controller optics \<opticsIndex>".

- **Laser State (Optics Details Table)**: The laser state.

  Retrieved using the call "show controller optics \<opticsIndex>".

- **LED State (Optics Details Table)**: The LED state.

  Retrieved using the call "show controller optics \<opticsIndex>".

- **FEC State (Optics Details Table)**: The FEC state.

  Retrieved using the call "show controller optics \<opticsIndex>".

- **Optics Type (Optics Details Table)**: The optics type.

  Retrieved using the call "show controller optics \<opticsIndex>".

- **Wavelength (Optics Details Table)**: The optics wavelength.

  Retrieved using the call "show controller optics \<opticsIndex>".

- **Detected Alarms (Optics Details Table)**: The detected alarm details.

  Retrieved using the call "show controller optics \<opticsIndex>".

- **LOS/LOL/Fault Status (Optics Details Table)**: The LOS/LOL/Fault Status description.

  Retrieved using the call "show controller optics \<opticsIndex>".

- **Performance Monitoring (Optics Details Table)**: The state of performance monitoring.

  Retrieved using the call "show controller optics \<opticsIndex>".

- **Serial Number (Optics Details Table)**: The optics serial number.

  Retrieved using the call "show controller optics \<opticsIndex>".

- **BGP IPv6 Unicast Table**: BGP IPv6 unicast information.

  Retrieved using the call "show bgp ipv6 unicast sum".

- **Neighbors (IPV6 Unicast Table)**: Retrieved using the call "show bgp ipv6 unicast sum".

- **SPK (IPV6 Unicast Table)**: Retrieved using the call "show bgp ipv6 unicast sum".

- **AS (IPV6 Unicast Table)**: Retrieved using the call "show bgp ipv6 unicast sum".

- **Message Received (IPV6 Unicast Table)**: Retrieved using the call "show bgp ipv6 unicast sum".

- **Message Sent (IPV6 Unicast Table)**: Retrieved using the call "show bgp ipv6 unicast sum".

- **Table Version (IPV6 Unicast Table)**: Retrieved using the call "show bgp ipv6 unicast sum".

- **InQ (IPV6 Unicast Table)**: Retrieved using the call "show bgp ipv6 unicast sum".

- **OutQ (IPV6 Unicast Table)**: Retrieved using the call "show bgp ipv6 unicast sum".

- **Up Down (IPV6 Unicast Table)**: Retrieved using the call "show bgp ipv6 unicast sum".

- **State PfxRcd (IPV6 Unicast Table)**: Retrieved using the call "show bgp ipv6 unicast sum".

- **BGP IPv6 Unicast Information**: Information on the BGP IPv6 Unicast table. Retrieved using the call "show bgp ipv6 unicast sum".

- **BGP IPv6 Multicast Table**: BGP IPv6 multicast information.

  Retrieved using the call "show bgp ipv6 multicast sum".

- **Neighbors (IPV6 Multicast Table)**: Retrieved using the call "show bgp ipv6 multicast sum".

- **SPK (IPV6 Multicast Table)**: Retrieved using the call "show bgp ipv6 multicast sum".

- **AS (IPV6 Multicast Table)**: Retrieved using the call "show bgp ipv6 multicast sum".

- **Message Received (IPV6 Multicast Table)**: Retrieved using the call "show bgp ipv6 multicast sum".

- **Message Sent (IPV6 Multicast Table)**: Retrieved using the call "show bgp ipv6 multicast sum".

- **Table Version (IPV6 Multicast Table)**: Retrieved using the call "show bgp ipv6 multicast sum".

- **InQ (IPV6 Multicast Table)**: Retrieved using the call "show bgp ipv6 multicast sum".

- **OutQ (IPV6 Multicast Table)**: Retrieved using the call "show bgp ipv6 multicast sum".

- **Up Down (IPV6 Multicast Table)**: Retrieved using the call "show bgp ipv6 multicast sum".

- **State PfxRcd (IPV6 Multicast Table)**: Retrieved using the call "show bgp ipv6 multicast sum".

- **BGP IPv6 Multicast Information**: Retrieved using the call "show bgp ipv6 multicast sum".

- **ISIS Neighbors Table**: Retrieved using the call "show isis neighbors".

- **System ID (ISIS Neighbors Table)**: Retrieved using the call "show isis neighbors".

- **Interface (ISIS Neighbors Table)**: Retrieved using the call "show isis neighbors".

- **SNPA (ISIS Neighbors Table)**: Retrieved using the call "show isis neighbors".

- **State (ISIS Neighbors Table)**: Retrieved using the call "show isis neighbors".

- **Holdtime (ISIS Neighbors Table)**: Retrieved using the call "show isis neighbors".

- **Type (ISIS Neighbors Table)**: Retrieved using the call "show isis neighbors".

- **IETF-NSF (ISIS Neighbors Table)**: Retrieved using the call "show isis neighbors".

- **ISIS Neighbors Information**: Information on the ISIS Neighbors table.

  Retrieved using the call "show isis neighbors".

- **PIM Neighbors Table**: Retrieved using the call "show pim neighbor".

- **Neighbor Address (PIM Neighbors Table)**: Retrieved using the call "show pim neighbor".

- **Interface (PIM Neighbors Table)**: Retrieved using the call "show pim neighbor".

- **Uptime (PIM Neighbors Table)**: Retrieved using the call "show pim neighbor".

- **Expires (PIM Neighbors Table)**: Retrieved using the call "show pim neighbor".

- **DR PRI (PIM Neighbors Table)**: Retrieved using the call "show pim neighbor".

- **Flags (PIM Neighbors Table)**: Retrieved using the call "show pim neighbor".

- **PIM Neighbors Information**: Retrieved using the call "show pim neighbor".

- **Inventory Table**: Retrieved using the call "show inventory".

- **Name (Inventory Table)**: Retrieved using the call "show inventory".

- **Description (Inventory Table)**: Retrieved using the call "show inventory".

- **Part Number (Inventory Table)**: PID. Retrieved using the call "show inventory".

- **Manufacturer Name (Inventory Table)**: VID. Retrieved using the call "show inventory".

- **Serial Number (Inventory Table)**: Retrieved using the call "show inventory".

- **Operational Status (Inventory Table)**: OID: 1.3.6.1.2.1.131.1.1.1.3.

- **Vendor Equipment Type (Inventory Table)**: Retrieved using the call "show inventory".

- **Inventory Port Count (Inventory Table)**: Number of ports. Retrieved using the call "show inventory".

- **Inline Power Capable (Inventory Table)**: Retrieved using the call "show inventory".

- **Redundancy Current Role Details**: The details of the active role.

  Retrieved using the call "show redundancy".

- **Interface Input Drops**: The number of incoming dropped packets.

  Retrieved using the call "sh interfaces tenGigE \<Interface Name> | sh interfaces hundred \<Interface Name>".

- **Interface CLI Input Errors**: The number of incoming errors from the CLI.

  Retrieved using the call "sh interfaces tenGigE \<Interface Name> | sh interfaces hundred \<Interface Name>".

- **Function**: Calculated. The element CIN function.

  Retrieved from the *CIN FUNCTION* custom property, which is set by IDP when the element is created.

- **Connection Status**: Calculated. The connection status (OK/Unreachable) according to ping result.

  The ping is performed against the IP address reported in the CIN Overview table. The frequency of the ping is determined by the virtual interval.

- **Model**: The device model. MIB OID 1.3.6.1.2.1.1.2.0.
