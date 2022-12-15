---
uid: DataMiner_processes
---

# DataMiner processes

A DataMiner Agent hosts a number of separate but interacting processes.

## Graphical overview of the processes running on a DataMiner Agent

The following overview clearly shows how the DataMiner Agent software is a collection of separate but interacting processes.

### Overview of the DataMiner Agent processes

![DataMiner Agent process overview](~/user-guide/images/slprocess_overview.jpg)

> [!TIP]
> See also:
>
> - [Main DMA software components](#main-dma-software-components)
> - [Auxiliary DMA software components](#auxiliary-dma-software-components)

## Main DMA software components

Below, you can find more information on the main DataMiner processes.

For information on the auxiliary processes, see [Auxiliary DMA software components](#auxiliary-dma-software-components)

### SLDataMiner

The central process of a DataMiner Agent.

- Starts, stops and configures elements, services, redundancy groups, and manages all traffic from and to those items.

- Performs database offloads toward the offload database (if one exists).

> [!NOTE]
> This process is not aware of any other DMAs in the DataMiner System.

### SLDataGateway

This process calculates the average trending information.

If a Cassandra database is installed, this process also handles the following:

- All communication with Cassandra (communication with legacy databases happens via SLElement).

- The building of time traces, used for heat maps.

- Transfer of data to the SLAnalytics process.

### SLDMS

Takes care of file synchronization within the DataMiner System, triggers connections, etc.

Initiates communication with other DMAs in the DMS. The communication itself, however, is managed by SLNet.

### SLElement

Keeps track of parameter values that have to be shown to the user and creates alarms.

On compatible systems, SLElement is run as a 64-bit process. However, it can still be run as a 32-bit process if it is registered as such with a batch file from the Tools directory.

> [!NOTE]
> This process is only aware of parameters that are being monitored and parameters that have to be displayed on the user interface.

### SLLog

Manages all interaction with the different log files found in the DataMiner System.

### SLNet

Controls all communication among DataMiner Agents, and between DataMiner Agents and their clients.

> [!TIP]
> See also: [Configuring SLNet settings in MaintenanceSettings.xml](xref:Configuration_of_DataMiner_processes#configuring-slnet-settings-in-maintenancesettingsxml)

> [!NOTE]
> Data for trend data queries is cached in the SLNet process after it has been received from SLDataGateway and before it is processed further. In the SLNetClientTest tool, several options are available related to the trend cache. However, note that this is an advanced system administration tool that should be used with extreme care. See [Configuring trend caching](xref:SLNetClientTest_configuring_trend_caching).

### SLPort

Controls all communication from and to devices connected to either a serial port or an IP port.

Types of communication controlled by this process include serial, smart-serial, GPIB and OPC.

> [!NOTE]
> Multiple SLPort processes can run simultaneously. See [Setting the number of simultaneously running SLPort processes](xref:Configuration_of_DataMiner_processes#setting-the-number-of-simultaneously-running-slport-processes).

### SLProtocol

Executes the instructions specified in DataMiner protocols.

> [!NOTE]
> Multiple SLProtocol processes can run simultaneously. See [Setting the number of simultaneously running SLProtocol processes](xref:Configuration_of_DataMiner_processes#setting-the-number-of-simultaneously-running-slprotocol-processes).

### SLSNMPManager

Controls all communication from and to SNMP devices acting as SNMP agents.

> [!TIP]
> See also: [Interaction between SNMP manager and SNMP agent](xref:Interaction_between_SNMP_manager_and_SNMP_agent)

### SLWatchdog

Monitors all other DataMiner processes and takes action

- when a DataMiner process has disappeared from the list of running processes, or

- when an anomaly has been detected in a DataMiner processes.

It also keeps track of a number of key performance indicators.

> [!TIP]
> See also:
>
> - [SLWatchdog](xref:Configuration_of_DataMiner_processes#slwatchdog)
> - [MaintenanceSettings.xml](xref:MaintenanceSettings_xml)

## Auxiliary DMA software components

Below, you can find more information on the auxiliary DataMiner processes.

For information on the main processes, see [Main DMA software components](#main-dma-software-components).

### SLAnalytics

This process only starts on a DMA that uses a Cassandra database. It supports advanced artificial intelligence functions in DataMiner, such as trend forecasting, anomaly detection, and alarm focus calculation.

> [!NOTE]
> Prior to DataMiner 9.5.5, it is possible to configure when prediction models are backed up, in the file *SLAnalytics.config*. However, from DataMiner 9.5.5 onwards, prediction models are no longer backed up, but instead retrieved from a cache and re-computed in case they are not available in the cache. For more information, see [SLAnalytics.config](xref:SLAnalytics_config#slanalyticsconfig).

### SLASPConnection

The DMS Reporter process.

> [!TIP]
> See also: [DMS Reporter](xref:reporter)

> [!NOTE]
>
> - Timeline data that are received from SLDataGateway or directly from a MySQL database are cached in the SLASPConnection process. Some caching options can be configured in *MaintenanceSettings.xml*. See [MaintenanceSettings.xml](xref:MaintenanceSettings_xml).
> - You can also find more information and settings for timeline caching at *http(s)://\[DmaIp\]/Reports/Tools.asp*:
>   - The page displays timeline cache statistics and list contents.
>   - The expiration time, grace time and maximum number of records can be set here, but only for the current session. These settings can be permanently changed in *MaintenanceSettings.xml*.
>   - Timeline caching and timeline cache verbose logging can be enabled and disabled on this page, or directly in *MaintenanceSettings.xml*.

### SLAutomation

The DataMiner Automation process.

> [!NOTE]
> C# code in Automation scripts is processed by SLAutomation, whereas C# code in protocol QActions is processed by SLScripting.

> [!TIP]
> See also: [DataMiner Automation](xref:automation)

### SLBrain

The DataMiner Correlation process.

> [!TIP]
> See also: [DataMiner Correlation](xref:correlation)

### SLGSMGateway

The DataMiner Mobile Gateway process.

Sends and receives SMS messages (i.e. text messages).

> [!TIP]
> See also: [DataMiner Mobile Gateway](xref:MobileGateway)

### SLHelper

A helper process that is called upon by other processes to perform actions such as

- converting a Microsoft Visio drawing to an image file (e.g. to allow Visio drawings to be rendered in web apps),

- converting documents (e.g. reports) to PDF format,

- etc.

### SLNetComService

Translates so-called managed code (as used by e.g. SLNet) to native code (as used by e.g. SLDataMiner) and vice versa.

### SLScheduler

A helper process that is called upon when the Windows Task Scheduler orders that a scheduled task has to be performed.

### SLScripting

Processes QActions when asked to by SLProtocol.

> [!NOTE]
> C# code in Automation scripts is processed by SLAutomation, whereas C# code in protocol QActions is processed by SLScripting.

### SLSNMPAgent

Communicates with third-party applications acting as SNMP managers (e.g. HP OpenView, IBM NetCool, etc.).

Also sends all outgoing email notifications.

> [!TIP]
> See also: [Interaction between SNMP manager and SNMP agent](xref:Interaction_between_SNMP_manager_and_SNMP_agent)

### SLSpectrum

The DataMiner Spectrum Analysis process.

Also manages the time slots assigned to each of the clients that want to use a particular spectrum analyzer.

> [!TIP]
> See also: [DataMiner Spectrum Analysis](xref:SpectrumAnalysis)

### SLTaskBarUtility

The DataMiner system tray utility that allows you to easily start, stop, backup, restore and upgrade a DMA.

### SLXML

Manages all interaction with the different XML files found in the DataMiner System.
