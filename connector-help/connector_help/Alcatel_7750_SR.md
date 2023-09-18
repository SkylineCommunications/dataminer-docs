---
uid: Connector_help_Alcatel_7750_SR
---

# Alcatel 7750 SR

The **Alcatel-Lucent 7750 Service Router** is an industry-leading multi-service edge router designed for the concurrent delivery of advanced residential, business and mobile services on a common IP edge platform. The connector uses **SNMPv2** to retrieve the information and configuration settings from the router.

## About

The **Alcatel 7750 SR** protocol is used to control and monitor the services of the Alcatel 7750 SR via **SNMPv2**.

Because the connector is very large, it's possible to **enable or disable polling** on every page. Since version 1.0.0.4 of the connector, you can also enable or disable polling on table level. More information about the different possibilities and the default settings can be found in the "Notes" section at the bottom of this help file.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMPv2) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

**SNMP Settings:**

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used to read from the device. The default value is *public*.
- **Set community string:** The community string used to write to the device. The default value is *private*.

## Usage

This section lists the pages of the Alcatel 7750 SR connector and explains what information is displayed on each of them.

### System page

This page displays all basic information about the device: **System Up Time**, **System CPU Usage**, **System Memory Used**, ...

A lot of the basic information about the system can be found on separate pages, which you can access by clicking the page buttons available on this page.

### BGP page

This page displays all BGP information for the router. The **BGP Peer table** has one entry per BGP peer and contains information about the connections with these peers.

### Hardware Overview

This page displays a tree view with information about the hardware of the Alcatel 7750 SR. This tree view contains the following levels:

- Level 1: **Chassis Table**

- Extra table: **Port Table**
  - Extra table: **Chassis Fan Table**
  - Extra table: **Chassis Power Supply Table**
  - Extra table: **Fabric Table**

- Level 2: **CPM Card Table** and **Card Table**

- Level 3: **MDA Table**

- Level 4: **Port Table**

### Hardware-Chassis page

This page displays tables with information about the hardware of the chassis:

- **Chassis Table:** Contains an entry for each chassis in the system.
- **Chassis Fan Table:** Displays information about the fans in the system.
- **Chassis Power Supply Table:** Displays information about the power supplies in the system.
- **Hardware Table:** Contains an entry for each managed hardware component in the Alcatel-Lucent SROS series system's chassis.

With the **Chassis Types** page button, you can access the **Chassis Type Table**, which contains extra information about the different types of chassis that are supported.

### Hardware-Card page

This page displays tables with information about the cards in the chassis.

- **Card Table:** Contains an entry for each IOM card slot in each chassis in the system.
- **Cpm Card Table:** Contains an entry for each CPM card slot in each chassis in the system.
- **Fabric Table:** Contains an entry for each fabric card slot in each chassis in the system.

With the different page buttons on this page, you can access tables with extra information about the cards in the system, like the **Card Type Table**, **Cpm Flash Table**, ...

### Hardware-MDA page

This page displays the **MDA Table**, which contains an entry for each MDA slot in each card in the system.

With the **MDA Types** page button, you can access the **MDA Types Table**, which contains information about the different MDA slots.

### Hardware-Port page

This page displays the **Port Table**, which contains an entry for each port in each card in the system.

With the page buttons on this page, you can access numerous additional tables with information related to the ports.

### ICMP page

This page displays the following tables with ICMP information:

- **ICMP Statistics Table**: Contains generic system-wide ICMP counters.
- **ICMP Message Statistics Table**: Contains system-wide ICMP counters, sorted per version and per message type.

### Interfaces Overview

This page displays a tree view with information about the interfaces of the Alcatel 7750 SR. This tree view contains the following levels:

- Level 1: **Interface Table**
- Level 2: **IP Address Table**

### Interfaces page

This page displays tables with information about the interfaces in the system:

- **IF Table:** Information for every interface in the system.
- **IF XTable:** Additional information for every interface in the system.
- **IF Stack Table:** Information about the multiple sub-layers of network interfaces, in particular about which sub-layer runs on top of which other sub-layer.

### IP page

This page displays tables with IP information. You can also change some basic IP settings here, like **IP Forwarding**, **IP Default TTL**, ...

The following tables are available:

- **IP Net To Physical Table**: Table used for mapping from IP addresses to physical addresses.
- **IP Address Table**: Addressing information relevant to the interfaces.

More IP tables can be accessed by means of the page buttons on this page.

### IS-IS page

This page displays tables with information for the IS-IS (Intermediate System to Intermediate System) routing protocol:

- **IS-IS System Table:** Contains an entry for each instance of the integrated IS-IS protocol existing in the system.
- **IS-IS Adjacencies Table:** Information about adjacencies to intermediate systems.
- **IS-IS Adjacencies Area Addresses Table:** Contains the set of area addresses of neighboring intermediate systems.
- **IS-IS Adjacencies IP Addresses Table:** Contains the set of IP addresses of neighboring intermediate systems.
- **IS-IS Adjacencies Protocol Supported Table:** Contains the set of protocols supported by neighboring intermediate systems.

The page buttons on this page can be used to access more tables related to the IS-IS protocol.

### LAG page

This page displays tables with link aggregation information for this system:

- **Aggregator Table:** Contains information about every aggregator that is associated with this system.
- **Aggregator Port Table:** Contains link aggregation control configuration information about every aggregation port associated with this system.

### LLDP page

This page displays information about the **Link Layer Discovery Protocol**.

- **LLDP Local Management Address Table:** Contains management address information on the local system known to this agent.

### MPLS LDP page

This page contains MPLS (Multiprotocol Label Switching) Label Distribution Protocol information.

The following tables are available:

- **MPLS LDP Entity Table:** Contains information about the MPLS LDP entities existing on this LSR.
- **MPLS LDP Peer Table:** Contains information about LDP peers.
- **MPLS LDP Hello Adjacency Table:** Contains hello adjacencies for sessions.
- **MPLS LDP Session Table:** Contains sessions between the LDP entities and LDP peers.

### MPLS LSR page

This page contains MPLS (Multiprotocol Label Switching) Label Switch Router information.

The following tables are available:

- **MPLS Interface Conf Table:** Specifies MPLS capability and associated information per interface.
- **MPLS In Segment Table:** Contains a collection of incoming segments to an LSR.
- **MPLS Out Segment Table:** Contains a representation of the outgoing segments from an LSR.
- **MPLS XC Table:** Specifies information for switching between LSP segments.
- **MPLS Traffic Param Table:** Specifies the traffic parameter objects for in and out segments.

### MPLS TE page

This page contains information about MPLS (Multiprotocol Label Switching) Traffic Engineering.

The following tables are available:

- **MPLS Tunnel Table:** Allows new MPLS tunnels to be created between an LSR and a remote endpoint.
- **MPLS Tunnel Hop Table:** Used to indicate the hops for an MPLS tunnel.
- **MPLS Tunnel AR Hop Table:** Used to indicate the hops for an MPLS tunnel for the outgoing direction of the tunnel.

### OSPF page

This page contains OSPF (Open Shortest Path First) version 2 protocol information. Numerous settings related to OSPF can also be changed.

The following tables are available:

- **OSPF Area Table:** Information describing the configured parameters and cumulative statistics of the router's attached areas.
- **OSPF LSDB Table:** Link state advertisements from throughout the areas that the device is attached to.
- **OSPF IF Table:** Describes the interfaces from the viewpoint of OSPF.
- **OSPF IF Metric Table:** Describes the metrics to be advertised for a specified interface at the various types of service.
- **OSPF Neighbours Table:** Describes all non-virtual neighbors in the locality of the OSPF router.
- **OSPF AS-scope LSDB Table:** Contains the AS-scope link state advertisements from throughout the areas that the device is attached to.

### RIP2 page

This page displays information related to RIP2 (Routing Information Protocol).

The following tables are available:

- **RIP2 IF Status Table:** Contains a list of subnets that require separate status monitoring for RIP.
- **RIP2 IF Configuration Table:** Contains a list of subnets that require separate configuration in RIP.
- **RIP2 Peer Table:** Contains a list of RIP peers.

### RMON page

This page displays RMON (Remote Network Monitoring) information.

The following tables are available:

- **Ethernet Statistics Table:** Contains a list of Ethernet statistics.
- **Ethernet Statistics High Capacity Table:** Contains the high capacity RMON extensions.
- **Media Independent Table:** Contains statistics for promiscuous monitoring of any media.

### RSVP page

This page displays RSVP (Resource Reservation Protocol) information.

The following tables are available:

- **RSVP IF Table:** Contains the RSVP-specific attributes of the system's interfaces.
- **RSVP Number Table:** Information describing the neighbors of the RSVP system.

### SNMP page

This page displays basic information about SNMP (Simple Network Management Protocol). It also provides the possibility to enable or disable **SNMP traps**.

### TCP page

This page displays information about the TCP (Transmission Control Protocol) protocol.

The following table is available:

- **TCP Connection Table:** Contains information about existing TCP connections.

### Transmission page

This page displays information about SONET linear APS groups.

The following tables are available:

- **APS Config Table:** Lists the APS groups that have been configured in the system.
- **APS Status Table:** Provides status information about APS groups that have been configured in the system.
- **APS Map Table:** Lists the SONET LTE interfaces in the system.
- **APS Channel Config Table:** Lists the APS channels that have been configured in APS groups.
- **APS Channel Status Table:** Contains information for all SONET LTE interfaces that are included in APS groups.

### VRRP page

This page displays the VRRP (Virtual Router Redundancy Protocol) information.

The following tables are available:

- **VRRP Operations Table** and **VRRP Operations Table 2:** Operations table for a VRRP router, which consists of a sequence of items describing the operational characteristics of a virtual router.
- **VRRP Associated IP Address Table** and **VRRP IP Address Table 2:** Contains addresses associated with this virtual router.
- **VRRP Router Statistics Table** and **VRRP Router Statistics Table 2:** Contains virtual router statistics.

### SAP page

This page contains the **SAP Base Info Table** which displays basic SAP (Service Access Point) information.

### SDP page

This page contains SDP (Service Discovery Protocol) information.

The following tables are available:

- **SDP Info Table:** Contains SDP information.
- **SDP Bind Table:** Contains SDP bind information.

### Services Overview

This page displays a tree view with information about the services of the Alcatel 7750 SR. This tree view contains the following levels:

- Level 1: **SVC Base Info Table**
- Level 2: **SAP Base Info Table** and **SDP Bind Table**

### Services page

This page displays information about the currently configured services.

The following tables are available:

- **Svc Base Info Table:** Contains basic service information.
- **Ies If Table:** Contains IES interface information.

The page buttons on this page provide access to numerous additional tables with more information about the services in the system.

### Services-Cust page

This page displays the customer information for this device.

The following tables are available:

- **Cust Info Table:** Contains customer information.
- **Cust Multi Services Site Table:** Contains information about customers' multi-service sites.

### Conditional Monitoring page

This page is used to import and export files that contain saved values of the monitoring of the table rows.

## Notes

### Polling

As mentioned in the "About" section of this help file, it is possible to enable and disable polling for each individual table (from **version 1.0.0.4** of this connector onwards).

For existing elements (**using versions prior to 1.0.0.4**), the table polling will match the page level polling after (initial) startup. This means that if page polling is enabled, polling for all tables on that page will be enabled as well. Similarly, if page polling is disabled, table polling for all tables on that page will be disabled as well. Once the table polling parameters are initialized, their **configuration will be saved** and a restart of the element will not update their state to the state of the page polling parameter.

When page polling is changed, the tables on that page will inherit the new polling setting from the page. Changing the polling for a table, however, will not have any impact on the page polling or on the polling of any other tables on that page. The following example shows how this works for the **SDP** page in the connector:

The **SDP** page displays two tables: **SDP Info Table** and **SDP Bind Table**. When an element with the Alcatel 7750 SR connector is created, the SDP Polling is disabled on this page and both tables inherit this setting.

- When **SDP Polling** is enabled for this page, the **SDP Info Polling** table and **SDP Bind Polling** table will be enabled as well, and the data for these tables will be retrieved from the device.
- When **SDP Info Polling** is disabled again, the **SDP Info Polling** table will no longer be polled, but the **SDP Bind Table** will still be polled, because enabling or disabling polling on a table has no influence on the page or any other tables.
- When **SDP Polling** is disabled again, the **SDP Bind Table** polling will also be stopped, because it inherits this setting from the **SDP Polling**.
