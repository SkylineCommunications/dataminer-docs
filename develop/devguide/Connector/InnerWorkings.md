---
uid: InnerWorkings
description: To have a good understanding of the inner workings of a protocol, it is important to have a deeper understanding of some of the DataMiner processes.
---

# Inner workings

A DataMiner Agent hosts a number of separate but interacting processes. In order to have a good understanding of the inner workings of a protocol, it is important to have a deeper understanding of some of these processes. Discussing all the processes in a DataMiner Agent is out of the scope of this section. Therefore, only processes that are closely related to protocol execution are considered here.

> [!NOTE]
> For a complete overview of all processes running in a DataMiner Agent, refer to [DataMiner processes](xref:DataMiner_processes).

The following diagram gives an overview of the processes running in a DataMiner Agent.

![DataMiner process overview](~/develop/images/ProcessOverview.svg)

The <xref:InnerWorkingsSLDataMiner> process is the central process of a DataMiner Agent (DMA). It is responsible for starting, stopping and configuring elements, services and redundancy groups, and manages all traffic from and to those items. SLDataMiner also performs database offloads toward the offload database (if one exists). This process is not aware of any other DMAs in the DataMiner System (DMS).

The <xref:InnerWorkingsSLProtocol> process executes the logic defined in a DataMiner protocol of the active elements on the DataMiner Agent. By default, several SLProtocol processes (5 prior to DataMiner 10.4.12/10.5.0, and 10 in later versions) run simultaneously, and the elements of the DataMiner Agent are distributed across them at startup.

The <xref:InnerWorkingsSLScripting> process is responsible for executing Quick Actions defined in the protocol when requested by the SLProtocol process (i.e. when triggered to execute).

A protocol typically contains many parameters. Some parameters are used for internal protocol logic, while others hold values that are of interest to the user and that are therefore displayed. The <xref:InnerWorkingsSLElement> process keeps track of parameters that have to be shown to the user and creates alarms. The SLProtocol process will push all parameters with RTDisplay set to true to the SLElement process. RTDisplay needs to be set to true for parameters that are positioned on a page or that need to be available for Automation scripts, Visio drawings, or other elements (running on another DMA).

Often, a protocol is specifically designed to monitor and communicate with a device. A device typically supports one or more protocols (e.g. SNMP, proprietary serial communication protocol, etc.). The **SLSNMPManager** process controls all communication from and to devices running SNMP agents. The **SLPort** process controls all communication from and to devices connected to either a serial port or an IP port.

A DataMiner System typically consists of multiple DataMiner Agents. Some protocols implement logic to retrieve data from another element, possibly running on another DMA. The **SLNet** process controls all communication among DataMiner Agents, and between DataMiner Agents and their clients. The **SLDMS** process takes care of file synchronization within the DataMiner System, triggers connections, etc. The SLDMS process initiates communication with other DMAs in the DMS. The communication itself, however, is managed by SLNet.

The **SLWatchdog** process monitors all other DataMiner processes and takes action when a DataMiner process has disappeared from the list of running processes, or when an anomaly has been detected in a DataMiner process. It also keeps track of a number of key performance indicators.
