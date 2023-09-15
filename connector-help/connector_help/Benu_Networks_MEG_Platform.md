---
uid: Connector_help_Benu_Networks_MEG_Platform
---

# Benu Networks MEG Platform

This is an SNMP-based protocol for the Benu Networks MEG Platform. Benu Networks Mobile Edge Gateway (MEG) is a platform that runs Benu's operating system and applications such as the Wi-Fi Access Gateway (WAG) and 3G/4G mobile offload and interworking. The WAG is deployed in the operator edge or core network to aggregate service tunnels from customer premise equipment (CPE), such as cable modems or xDSL modems with integral Wi-Fi access points. Layer 2 tunnels (such as softGRE) are terminated on the WAG, which provides intelligent IP subscriber management and L3 anchoring for all Wi-Fi sessions.

## About

This connector was designed to work with Benu's MEG-400 platform. You can monitor the platform with it and receive numerous statistics about the platform and the WAG. **SNMP Get** commands are used to read information from the device. **SNMP Set** commands are used to write information to the device. The connector also receives unsolicited messages from the device via **SNMP** **Traps**.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | BW-2.2.4.3                  |

## Installation and configuration

### Creation

#### Main connection

This connector uses a Simple Network Management Protocol (**SNMP**) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

Once created, the element can be used immediately. There are 16 pages available in the connector.

It is important to note that many of the tables show historical statistics information from the last 24 hours. Each 60-minute interval is represented as a row in the tables.

### General

This page displays general information regarding the device, e.g. **System Description**, **System Up Time**, etc.

The **Interfaces** button provides access to additional information about the different interfaces of the device. For each interface, some information is available, such as the **IF Speed**, **IF Physical Address**, **IF Operational Status** and statistics of the **inbound**/**outbound** **packets**.

### Chassis

This page contains important information about the chassis itself, e.g. the **Chassis Type**, **Chassis Hw Version**, **Chassis Number of Slots**, etc.

### Card

This page displays information about the cards installed in the platform and the interfaces available in each card, e.g. the **Card Type**, **Card Operational Status**, etc.

### Sensor

This page displays value readings and other information from the sensors in the platform measuring **Temperature**, **Voltage**, **Current**, etc.

### Fan

This page displays the status of the fans.

### Events

This page provides a consolidated view of the traps sent by the MEG. Each trap informs of a particular event that occurred in the platform itself or in the WAG application.

With the **Auto Clear** page button, you can configure under which circumstances the traps will be deleted automatically. You can also define the maximum number of traps per table and the maximum duration for which the traps can stay in the tables.

The following tables are available:

- The **Chassis Power Events Table**: Receives all traps of type **benuChassisPowerFailure**.
- The **Host Tasks Events Table**: Receives all traps of type **bSWTaskDied** and **bSWTaskRestartLimitReached**.
- The **Radius Servers Events Table**: Receives all traps of type **bRadiusAuthServerMarkedDead, bRadiusAuthServerMarkedAlive, bRadiusAccountingServerMarkedDead** and **bRadiusAccountingServerMarkedAlive**.

Note: Traps from a real device will only be received if the **Test Mode** is *Disabled*.

### Host Performance

This page displays general information about the performance of the system, such as the **Average CPU Utilization**. You can also access more detailed information through the **Tasks** button on a per task basis, e.g **Task Name**, **Task Process ID**, **Task Average CPU Usage**, etc.

### Subscribers

This page displays information about the subscribers connected to the system, such as the **Number Current Subscribers**, **Number Authenticated Subscribers**, and **Number Unauthenticated Subscribers**. The page also displays page buttons that provide detailed **Statistics** and information on the **Policies** applied for the different types of subscribers.

### Tunnels

This page displays the number of GRE tunnels configured in the WAG, along with detailed **Statistics** about those tunnels.

### Radius Server

This page displays detailed measurements related to the operation of the Radius server, in the **Radius Server Authentication**, **Radius Server Accounting**, **Radius Client CoA**, and **Radius Statistics** tables.

### AAA Groups

This page displays detailed measurements about the AAA Groups, in the **AAA Group Authentication**, **AAA Group Accounting**, and **AAA Group CoA** tables.

### Dhcp Server

This page displays numerous statistics about the DHCP server, active clients and subnets.

### Ipv4/Ipv6 Address Pools

These two pages display statistical information about the IPv4/IPv6 address pools configured in the system.

### Cgnat Auth/Unauth Subscribers

These two pages display statistical information about the **CGNAT Authenticated/Unauthenticated Subscribers** profiles.
