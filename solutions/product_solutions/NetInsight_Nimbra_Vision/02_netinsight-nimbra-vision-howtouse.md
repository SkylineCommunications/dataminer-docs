---
uid: netinsight-nimbra-vision-howtouse
---

# Using the NetInsight Nimbra Vision App

The DataMiner Nimbra Vision solution provides comprehensive monitoring and orchestration of Nimbra Nodes from a single pane of glass. This seamless end-to-end monitoring and orchestration is made possible through its integration with the Nimbra Vision platform. The app has multiple pages and panels, which are presented below.

## Scheduled services

Provides a easy way to user to monitor and manage scheduled circuit/services in Nimbra network. The list of circuit are displayed in a table and timeline view. From the table, users can also open a node edge view to provide a user friendly way to visualize the end-to-end network connections.

The page header offers quick access to schedule *J2K* and *E-Line* services. A *Plan Circuit* button is also available in the top-right corner. The button opens a window where you can select the preferred service type, capacity, interfaces, start time, and end time.

![Nimbra Services](~/solutions/images/netinsight-nimbra-vision-scheduled.png)

### Ad hoc services

To connect or disconnect interfaces, you can create or decommission services of the supported types, respectively.

The solution currently supports the E-Line and J2K service types.

The *connect* option immediately triggers the start of the circuit, which then runs indefinitely.

JXS and SRT services are currently being implemented and will be supported in an upcoming version.

![J2K Adhoc service](~/solutions/images/netinsight-nimbra-vision-adhocpanel.png)

## Monitoring

On this page, you get an overview of the Nimbra nodes orchestrated by Nimbra Vision, allowing them to easily monitor the state of interfaces on these nodes and track any active alarms.

![Monitoring](~/solutions/images/netinsight-nimbra-vision-monitoring.png)

## Nimbra interfaces

Here you can inspect the network interfaces of the Nimbra nodes, identifying their status as well as current and historical transmission rates.

![Nimbra Interfaces](~/solutions/images/netinsight-nimbra-vision-interfaces.png)

## Network overview

This page offers an overview of Nimbra's network topology.

![Network Topology](~/solutions/images/netinsight-nimbra-vision-networktopology.png)
