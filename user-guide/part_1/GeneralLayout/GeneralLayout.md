# DataMiner System layout

A DataMiner System (DMS) is a cluster of interconnected DataMiner Agents.

As to software, all DataMiner Agents in a DMS are identical. Each of them is a fully functional monitoring system.

In a DMS, there is no central server and there are no dedicated client terminals. DataMiner users can log on to any of the DMAs in the cluster and will perceive the DMS as a single entity.

### DataMiner Agents

A DataMiner Agent (DMA) is a piece of industry-standard computing hardware running the DataMiner Agent software on top of a Microsoft Windows operating system (see [DataMiner Compute Requirements](https://community.dataminer.services/dataminer-compute-requirements/)).

The DataMiner Agent software is essentially a collection of services of which the names all start with “SL” (e.g. SLNet, SLProtocol, SLLog, etc.).

> [!NOTE]
> By default, on DataMiner Agents running Windows 2008 Server or Windows Vista (or higher), the startup type of the DataMiner services is set to “Automatic (Delayed Start)”. This means that DataMiner waits until all Windows services are up and running before launching its own services.

### DataMiner clients

DataMiner client applications connect to only one DMA in the DMS (their so-called primary DMA). Through that “single point of contact”, they then have access to all information in the DMS.

### DataMiner databases

On each of the DataMiner Agents, you will find a general or “local” database. Prior to DataMiner 9.0, this is by default a MySQL database. From DataMiner 9.0 onwards, a Cassandra database is used by default. However, an MSSQL database is also supported.

Optionally, the data stored in a general database can be automatically offloaded to an offload or “central” database installed on a dedicated database server. This is especially useful when you intend to use that data for heavy-duty reporting or billing purposes.

### Dual LAN architecture

Typically, every DataMiner Agent is equipped with a dual Ethernet interface card.

#### Primary port

|             |                                                                                    |
|-------------|------------------------------------------------------------------------------------|
| Connection: | Connected to the corporate IP network                                              |
| Purpose:    | Communicating with clients (web browsers, SNMP Managers, telnet applications, ...) |
| Data:       | Processed data (e.g. alarms, real-time data, reports, ...)                         |

#### Secondary port

|             |                                                                       |
|-------------|-----------------------------------------------------------------------|
| Connection: | Connected to the “acquisition LAN” (i.e. the dedicated DataMiner LAN) |
| Purpose:    | Collecting information from the Elements                              |
| Data:       | Raw data                                                              |

### DataMiner Probes

A DataMiner Probe (DMP) provides standalone intelligent network management functionality, and typically reports to a central system. It has limited capabilities compared to a full DataMiner Agent, and typically, but not necessarily, runs on a small-form-factor computer in remote and unmanned locations where communication channels often have capacity constraints and/or intermittent availability.

DMPs can support a multitude of applications, and are typically installed in e.g. remote VSAT terminals, satellite hubs, terrestrial transmitter sites, small network nodes, cellular network base centers, etc.

### DMA peripherals

In some network setups, special interfacing tools called “DMA peripherals” are used to connect a DMA to third-party devices. Typically, the intelligence is embedded in the DMA, while the peripherals themselves are used for medium interfacing and conversion.

Frequently used peripherals include:

- Serial Gateway (RS232 and/or RS485 ports)

- IO Gateway (analog and digital IOs)

- HMS Gateway (RF ports, HMS compliant)

- GPIB Gateway (IEEE-488 ports)

- ...

> [!NOTE]
> When interfacing with IO gateways through DataMiner Protocols, the following guidelines should be taken into account.
> -  All analog and digital IOs must be listed in a normalized way so that they reflect the actual voltage/status.
> -  Create a virtual protocol that contains the parameters to be included in the virtual element.
> -  Specify the necessary multiplication and offset factors in order to deal with parameter units (e.g. 0.1 V/oC)
> -  Virtual protocol design is independent of the IO Gateway being used.

 
