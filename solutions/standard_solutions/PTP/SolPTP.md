---
uid: SolPTP
---

# About DataMiner PTP

## The DataMiner PTP app

The DataMiner PTP app allows **efficient 360° real-time monitoring of a PTP stack**. It provides an overview of all PTP nodes and their roles, constantly monitors important PTP metrics and statistics of PTP devices, such as grandmaster clocks, boundary clocks, and PTP slave devices, and allows you to identify any change in the PTP environment. You can also create multiple PTP domains, easily add PTP nodes to one of them, and get separate monitoring views on the different domains.

Unfamiliar with PTP? Refer to [About PTP](#about-ptp) below.

> [!TIP]
> See also:
>
> - [Product Sheet](https://skyline.be/downloads/SLC_ProductSheet_PTP.pdf)
> - Blog post: [Managing multiple PTP domains with the DataMiner PTP app](https://community.dataminer.services/managing-multiple-ptp-domains-with-the-dataminer-ptp-app/)
> - Use case: [Multiple PTP domains](https://community.dataminer.services/use-case/multiple-ptp-domains/)
> - Use case: [DataMiner PTP app example](https://community.dataminer.services/use-case/dataminer-ptp-app/)
> - Use case: [DataMiner PTP integration](https://community.dataminer.services/use-case/dataminer-ptp-app-2/)
> - [DataMiner Precision Time Protocol (PTP) app](https://community.dataminer.services/video/dataminer-precision-time-protocol-ptp-app/) ![Video](~/user-guide/images/video_Duo.png)

## Underlying technology: DataMiner Mediation

Based on the DataMiner Mediation functionality, any PTP-aware node can be added to the PTP app easily. DataMiner Mediation maps vendor-specific PTP MIB files, API calls, naming conventions, and metrics into an IEEE1588-2 compatible data model. This allows the PTP app to provide a uniform look and feel for the PTP environment, even if different vendors expose the same metric in different ways (e.g. with a different name or with a different type of value).

> [!TIP]
> For a list of all supported connectors, refer to [Standard DataMiner PTP Device](https://docs.dataminer.services/connector/doc/Standard_DataMiner_PTP_Device.html).

## Out-of-the-box deployment

The DataMiner PTP app:

- Comes with a [deployment wizard](xref:Installing_the_DataMiner_PTP_app) that allows easy configuration of your PTP domain(s).
- Includes a predefined set of [alarm templates](xref:About_alarm_templates) and [trend templates](xref:About_trend_templates) that can be quickly adapted to a specific PTP environment.
- Uses the DataMiner Connectivity Framework (DCF) to visualize how the PTP devices are connected. The DCF information can be specified manually or retrieved automatically using [DataMiner IDP](xref:SolIDP).

## Supported KPIs

Below you can find an overview of the KPIs supported for the different types of PTP devices in the DataMiner PTP app.

> [!NOTE]
> The PTP app can only support these metrics for a specific device if the device manufacturer exposes them in an API.

### Grandmaster

PTP General:

- Clock ID
- GM Name
- Profile
- Domain
- Clock Source
- Communication Mode
- Delay Mechanism
- Step Mode
- PTP State

PTP BMCA:

- Priority 1
- Clock Class
- Clock Accuracy
- Clock Variance
- Priority 2

PTP Message Rates:

- Announcement Message Rate
- Sync Message Rate
- Delay Request Message Rate
- Delay Response Message Rate
- Announce Receipt Timeout Rate

PTP Time Properties:

- Current UTC Offset
- UTC Offset Valid
- Leap 59
- Leap 61
- Time Tracing
- Frequency Tracing
- TimeScale

### Boundary clock

PTP Source:

- IP Address
- GM Clock ID / Name
- GM Priority 1
- GM Clock Class / Accuracy / Variance
- GM Priority 2
- Parent Clock ID / Name
- Port Number
- Parent Stats
- Observed Parent Clock Variance
- Observed Parent Phase Change Rate

PTP Local Clock:

- Clock ID
- Domain
- Steps Removed
- Offset
- Mean Path Delay
- Skew
- Step Mode
- PTP Ports
- Priority 1
- Clock Class / Accuracy / Variance
- Priority 2

PTP Time Properties:

- Clock Source
- Current UTC Offset
- UTC Offset Valid
- Leap 59
- Leap 61
- Time Tracable
- Frequency Tracable
- TimeScale

PTP Interfaces:

- State (master/slave/passive/disabled/etc.)
- Transport Protocol
- Delay Mechanism
- Delay Request Interval
- Announce Receipt Timeout
- Admin State
- PTP Role
- Sync Test
- Sync Interval
- PTP Mode
- Announce Messages Sent
- Announce Messages Received
- Sync Messages Sent
- Sync Messages Received
- Follow Up Messages Sent
- Follow Up Messages Received
- Delay Request Messages Sent
- Delay Request Messages Received
- Delay Response Messages Sent
- Delay Response Messages Received
- Peer Delay Request Messages Sent
- Peer Delay Request Messages Received
- Peer Delay Response Messages Sent
- Peer Delay Response Messages Received
- Peer Delay Response Follow Up Messages Sent
- Peer Delay Response Follow Up Messages Received

### Slave device

- Domain
- GM Clock ID
- GM Clock Name
- Slave Only
- Lock Status
- Offset

## About PTP

PTP (Precision Time Protocol) is the de facto protocol used by broadcasters, media network operators, and service providers to synchronize device clocks in complex media networks to achieve accurately synchronized video, audio and metadata streams.

PTP node provisioning, monitoring, and performance management both for every single node and for the network on the whole are of key importance to maintain a robust, resilient and reliable clock distribution throughout the network over time.

A PTP domain is a network or a portion of a network within which PTP operates, i.e. a network within which all of the clocks are in sync.

![PTP domains](~/user-guide/images/PTP_domain.png)

The PTP standard specifies different clock types. Ordinary clocks have a single PTP port, can be grandmaster-capable, or can be slave-only. Boundary clocks have multiple PTP ports and synchronize network segments. Transparent clocks eliminate the effects of varying forwarding delays in the overall accuracy.

![PTP clock types](~/user-guide/images/PTP_clock_types.png)

Different PTP profile and PTP message types are used.

![PTP clock types](~/user-guide/images/PTP_Profile_and_Message_types.png)

SMPTE 2059-1 defines the epoch time as 1st of January 1970 at 0 hours, 0 minutes, and 0 seconds TAI.

![PTP epoch time](~/user-guide/images/PTP_epoch_time.png)<!-- This image still needs to be corrected -->

The BMCA (Best Master Clock Algorithm) is one of the PTP core techniques, which is used by the clock synchronization system based on IEEE1588 to choose the system master clock and to ensure the slave clocks are synchronized according to it.

![BMCA](~/user-guide/images/PTP_BMCA.png)

> [!TIP]
> See also:
>
> - Blog post: [How does clock synchronization work?](https://community.dataminer.services/how-does-clock-synchronization-work/)
> - Blog post: [PTP Monitoring – a must, not an option](https://community.dataminer.services/ptp-monitoring-a-must-not-an-option/)
> - [PTP introduction video](https://community.dataminer.services/video/nab-2019-ptp-management-and-media-flow-monitoring/) ![Video](~/user-guide/images/video_Duo.png)

### More information

Interested in some more in-depth information about PTP? Check out the (external) links below.

- Mellanox - PTP design guide: [IEEE 1588 Precision Time Protocol (PTP) for Mellanox Onyx Switches](https://network.nvidia.com/files/doc-2020/ieee-1588-precision-time-protocol-design-guide.pdf)
- EBU Technical Review: [Using PTP for Time & Frequency in Broadcast Applications – Part 1: Introduction](https://tech.ebu.ch/publications/using-ptp-for-time--frequency-in-broadcast-applications--part-1-introduction)
- Ravenna: PTP in WAN Applications: [PTP in WAN Applications & Update on PTP v2.1 - YouTube](https://www.youtube.com/watch?v=p09sO1dp05E)
- Endace PTP over WAN White Paper: [IEEE 1588 PTP clock synchronization over a WAN backbone](https://www.endace.com/ptp-timing-whitepaper)
- [IEEE SA Beyond Standards](https://standards.ieee.org/beyond-standards/)
- [IEEE Standard for a Precision Clock Synchronization Protocol for Networked Measurement and Control Systems](https://standards.ieee.org/ieee/1588/6825/)
- [Meinberg PTP blog](https://blog.meinbergglobal.com/?s=ptp)
- Embrionix white paper about PTP: [PTP Within A ST2110 Deployment](https://www.embrionix.com/resource/PTPWithin_ST2110Deployment)
- [IP showcase about PTP in Media Virtualized Environment](http://www.ipshowcase.org/wp-content/uploads/2019/10/1030-PTP-in-Media-Virtualized-Environment.pdf)
- [IP showcase about PTP as the backbone of the SMPTE ST2110 deployment](http://www.ipshowcase.org/wp-content/uploads/2018/11/sarkis-abrahamian-PTP-Backbone-of-ST2110.pdf)
- PTP explained by The Broadcast Bridge: [The New Precision Time Protocol Explained](https://www.thebroadcastbridge.com/content/entry/15384/the-new-precision-time-protocol-explained)
- Introduction to PTP in three parts by The Broadcast Bridge:
  - [PTP Explained - Part 1](https://www.thebroadcastbridge.com/content/entry/14226/ptp-explained-part-1-network-architectures-for-media-focused-ptp-deployment)
  - [PTP Explained - Part 2](https://www.thebroadcastbridge.com/content/entry/14227/ptp-explained-part-2-redundancy-in-media-driven-ptp-networks)
  - [PTP Explained - Part 3](https://www.thebroadcastbridge.com/content/entry/14228/ptp-explained-part-3-operational-supervision-of-ptp-network-services)
- [How a PTP Slave syncs with a PTP Master - YouTube](https://www.youtube.com/watch?v=Forh3XfD_Ec)
- [The New SMPTE Synchronization Standard - YouTube](https://www.youtube.com/watch?v=468120O31Q4)
- [PTP in Virtualized Media Environment - YouTube](https://www.youtube.com/watch?v=LbU7I_wuigo)
