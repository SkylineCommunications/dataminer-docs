---
uid: GeneralLayout
---

# DataMiner System layout

A DataMiner System (DMS) is a cluster of one or more TCP/IP interconnected DataMiner Agents (DMAs).

As to software, all DataMiner Agents in a DMS are identical. Each DMA is also a fully functional DataMiner System by itself, offering all the features and capabilities of DataMiner. This means that the smallest and simplest version of a DataMiner System is a single DMA. Typically, multiple DMAs are deployed to create a DMS, with the number of DMAs depending on the required overall processing capacity and potentially also on certain architectural considerations or preferences.

In a DMS, there is no central server, and there are no dedicated client terminals. When DataMiner users log on to any of the DMAs in the cluster, they will perceive the DMS as a single entity.

## DataMiner Agents

A DataMiner Agent (DMA) is a physical or virtual compute instance running the DataMiner Agent software on top of a Microsoft Windows operating system (see [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements)). A DMA is often also referred to as a DataMiner Node.

The DataMiner Agent software is essentially a collection of services, of which most names start with “SL” (for example, SLNet, SLProtocol, SLLog, etc.).

> [!TIP]
> See also: [Installing a DataMiner Agent](xref:Installing_a_DataMiner_Agent)

## DataMiner clients

DataMiner client applications only need to connect to one DMA in the DMS, and this can be any of the DMAs. All DMAs in the DMS have an equivalent status. Through this "single point of contact", users have access to all information in the entire DMS. The only constraints a user can potentially experience in terms of accessing certain information are defined by the DataMiner security configuration.

In other words, a DataMiner client can access the DataMiner System by connecting to any DMA, and it will get a consolidated view of the entire managed operation and all its managed objects across all DMAs in the DMS.

> [!TIP]
> See also: [Client apps](xref:Client_apps)

## DataMiner database

For essential **system data storage**, a DataMiner System can either make use of [Storage as a Service (STaaS)](xref:STaaS), in which case all the complexity and scaling of the databases is taken care of by Skyline, or you can choose to host the storage databases yourself. To store and retrieve data, the DataMiner System relies on references and IDs. This makes the database less readable for a third-party software application without intimate knowledge of the data structures used by DataMiner. The system data storage is therefore considered to be exclusively used by the DataMiner System.

The **offload database** is an optional second data storage solution that can be added to a DataMiner System for the purpose of exporting the data and making it available for third-party software applications. When the DataMiner System is configured to also offload its data to the offload database, it will translate the data to more human-readable data (for example, element ID references are replaced with element names), so that it is easier for third-party applications to digest. A DataMiner System will only write data to the offload database but will not read from it. The DataMiner System will also not perform maintenance of the offload database.

## dataminer.services

dataminer.services is a cloud platform hosted by Skyline that provides various services. While it is not mandatory for a DataMiner System to be connected to this platform, the connection is required to have access to some DataMiner features.

The most full use of dataminer.services is [DataMiner as a Service](xref:Creating_a_DMS_in_the_cloud), where the entire DataMiner System is hosted by Skyline in the cloud. It is also possible to only have the system data storage hosted by Skyline with [Storage as a Service](xref:STaaS). But even if you host a DataMiner System entirely on your own compute instances, being connected to dataminer.services provides a host of additional features, including dashboard sharing and ChatOps.

For an overview of all dataminer.services functionality, refer to [dataminer.services](xref:Overview_dataminer_services).

## DataMiner Probes

A DataMiner Probe (DMP) provides standalone intelligent network management functionality, and typically reports to a central system. It has limited capabilities compared to a full DataMiner Agent, and typically, but not necessarily, runs on a small-form-factor compute instance in remote and unmanned locations where communication channels often have capacity constraints and/or intermittent availability.

DMPs can support a multitude of applications and are typically installed in for example remote VSAT terminals, satellite hubs, terrestrial transmitter sites, small network nodes, cellular network base stations, etc.

## DMA peripherals

In some network setups, special third-party interfacing hardware called "DMA peripherals" is used to connect a DMA to third-party devices. Typically, the intelligence is embedded in the DMA, while the peripherals are used for medium interfacing and conversion.

Frequently used peripherals include:

- Serial Gateway (RS232 and/or RS485 ports)
- IO Gateway (analog and digital IOs)
- HMS Gateway (RF ports, HMS compliant)
- GPIB Gateway (IEEE-488 ports)
- ...

> [!NOTE]
> When interfacing with IO gateways through DataMiner Protocols, the following guidelines should be taken into account.
>
> - All analog and digital IOs must be listed in a normalized way so that they reflect the actual voltage/status.
> - Create a virtual protocol that contains the parameters to be included in the virtual element.
> - Specify the necessary multiplication and offset factors in order to deal with parameter units (e.g., 0.1 V/oC)
> - Virtual protocol design is independent of the IO Gateway being used.
