---
uid: Connector_help_Verizon_Workflow_Manager
---

# Verizon Workflow Manager

The Verizon Workflow Manager protocol is used to handle workflows and data exchange processes between the different DataMiner modules present in the Verizon DMS. These modules include elements, protocols, and the Correlation, Automation and Profile Manager apps.

## About

As this is a virtual connector, **no data traffic** will be shown **in the Stream Viewer**.

#### Profile Manager Integration

The first workflow carried out by the protocol deals with collector elements and the Profile Manager app. This workflow performs data updates and synchronization between the collectors' SLA and fault settings.

There are two workflows to exchange data between the collectors and the Profile Manager app:

- **OnUpdate**: Used by the collectors to request updated data from Profile Manager.
- **OnChange**: Used to add/remove/edit data from the collectors in Profile Manager.

Once a workflow is triggered by a collector element, it generates a sequence of actions (information event ---\> Correlation rule ---\> Automation script) that results in an update or change of data. The Correlation engine picks up the info event and passes it to the Automation engine. Automation performs the validation of the data in the information event, and based on the DMA ID of the source collector, it sends such info to the corresponding Workflow Manager element (there should be one manager per DMA). In case there is no such manager on the DMA, the request is sent to the first available manager in the DMS.

#### ETMS Integration

The Correlation engine will listen for and capture information events coming from the collector elements and execute an Automation script. After the Automation engine receives the info message from the Correlation engine, it will select the Workflow Manager element that will continue with the ticketing workflow based on the DMA ID of the collector that triggered the info event in the first place. If no WM element is found that has the same DMA ID as the collector, Automation will send the info message to any active WM element within the DMS. Once a Workflow Manager element has received an event from the Automation engine, this element performs a series of diagnostic activities, which are part of the overall ticketing workflow:

- PLM Interrogation
- Sun Outage Interrogation
- Weather Underground Interrogation
- Network Connectivity Interrogation
- Temperature Interrogation
- KPI Interrogation

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

This connector uses a **virtual** connection and does not require any input during element creation.

## Usage

### VerSat OnUpdate

This page contains parameters related to the status of **OnUpdate** events, such as **Thread State**, **Last Successful Update** and **Last Successful Thread Datetime**.

### VerSat OnUpdate

This page contains parameters related to the status of **OnChange** events, such as **Thread State**, **Last Successful Update** and **Last Successful Thread Datetime**.

### VerSat OnTicketing

This page contains the **Ticketing Overview** parameters and the **Diagnostics** table. This table displays the progress of each interrogation process. Via the **Auto-Delete** feature, old entries can be removed from the table after a specified time.

A **Configuration** subpage for each interrogation process can be accessed via a page button. Depending on the interrogation process, different configuration options are available.
