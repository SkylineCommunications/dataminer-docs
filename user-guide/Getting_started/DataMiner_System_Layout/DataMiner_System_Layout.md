---
uid: GeneralLayout
---

# DataMiner System layout

A DataMiner System (DMS) is a cluster of one or more TCP/IP interconnected DataMiner Agents (DMA).

As to software, all DataMiner Agents in a DMS are identical. Each DMA is also a fully functional DataMiner System by itself, offering all the features and capabilities of DataMiner.  Therefore, the smallest and most simple version of a DataMiner System is a single DMA.  Multiple DMAs are typically deployed to create a DMS, with the number of DMAs defined by the overall processing capacity required and potentially certain architectural considerations or preferences.

In a DMS, there is no central server and there are no dedicated client terminals. DataMiner users can simply log on to any of the DMAs in the cluster and will perceive the DMS as a single entity.

## DataMiner Agents

A DataMiner Agent (DMA) is a physical or virtual compute instance running the DataMiner Agent software on top of a Microsoft Windows operating system (see [DataMiner Compute Requirements](https://community.dataminer.services/dataminer-compute-requirements/)).  A DMA is often also commonly referred to as a DataMiner Node.

The DataMiner Agent software is essentially a collection of services of which the names all start with “SL” (e.g. SLNet, SLProtocol, SLLog, etc.).

> [!NOTE]
> By default, on DataMiner Agents running Windows 2008 Server or Windows Vista (or higher), the startup type of the DataMiner services is set to "Automatic (Delayed Start)". This means that DataMiner waits until all Windows services are up and running before launching its own services.

## DataMiner clients

DataMiner client applications need to connect to only one DMA in the DMS, and that can be any of the DMAs in the DMS (i.e. all DMAs in a DMS are equivalent). Through that "single point of contact", they then have access to all information in the entire DMS.  The only constraint a user could potentially experience in terms of accessing certain information is the one defined by the DataMiner Security.  In other words, the DataMiner client can access the DataMiner System by connecting to any DMA, and it will get a consolidated view of the entire managed operation and all its managed objects across all DMAs in the DMS.

## DataMiner database

For storage of data, DataMiner comes fully integrated with industry standard data storage solutions.  The General Database refers to the mandatory storage solution that is required for a fully operational DataMiner System.  The Offload Database refers to an optional second data storage solution that can be added to a DataMiner System, for purpose of exporting the data and making it available for third party software applications.  The General Database is used by the DataMiner System to store and retrieve data from, and that is done in the most efficient manner and hence relying on references and IDs (hence making it less readable for a third party software application without intimate knowledge about the data structures used by DataMiner).  The General Database is therefore considered to be exclusively used by the DataMiner System, and the DataMiner System also includes all the logic required to keep that General Database in good health and optimal performance (i.e. the General Database is intended to be zero maintenance and requires no Database Admin).  When the DataMiner System is configured to offload its data also in the Offload Database, it will translate all the data also to more human readable data (e.g. element ID references are replaced by element names), making it easier to digest by third party applications.  A DataMiner System will only write data into the Offload Database, but will not read from it, nor will the DataMiner System perform maintenance of that database.

On each of the DataMiner Agents, you will find a general or "local" database. Prior to DataMiner 9.0, this is by default a MySQL database. From DataMiner 9.0 onwards, a Cassandra database is used by default. However, an MSSQL database is also supported.

Optionally, the data stored in a general database can be automatically offloaded to an offload or "central" database installed on a dedicated database server. This is especially useful when you intend to use that data for heavy-duty reporting or billing purposes.

## DataMiner Probes

A DataMiner Probe (DMP) provides standalone intelligent network management functionality, and typically reports to a central system. It has limited capabilities compared to a full DataMiner Agent, and typically, but not necessarily, runs on a small-form-factor compute instance in remote and unmanned locations where communication channels often have capacity constraints and/or intermittent availability.

DMPs can support a multitude of applications, and are typically installed in e.g. remote VSAT terminals, satellite hubs, terrestrial transmitter sites, small network nodes, cellular network base centers, etc.

## DMA peripherals

In some network setups, special third-party interfacing hardware called "DMA peripherals" are used to connect a DMA to third-party devices. Typically, the intelligence is embedded in the DMA, while the peripherals themselves are used for medium interfacing and conversion.

Frequently used peripherals include:

- Serial Gateway (RS232 and/or RS485 ports)
- IO Gateway (analog and digital IOs)
- HMS Gateway (RF ports, HMS compliant)
- GPIB Gateway (IEEE-488 ports)
- ...

> [!NOTE]
> When interfacing with IO gateways through DataMiner Protocols, the following guidelines should be taken into account.
> - All analog and digital IOs must be listed in a normalized way so that they reflect the actual voltage/status.
> - Create a virtual protocol that contains the parameters to be included in the virtual element.
> - Specify the necessary multiplication and offset factors in order to deal with parameter units (e.g. 0.1 V/oC)
> - Virtual protocol design is independent of the IO Gateway being used.
