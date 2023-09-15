---
uid: Connector_help_Eutelsat_Data_Collector
---

# Eutelsat Data Collector

The **Eutelsat Data Collector** is a custom-made connector for Eutelsat that allows to monitor the Eutelsat DMA cluster.

## About

The **Eutelsat** Data Collector is a connector that was tailor-made for monitoring Eutelsat DMA cluster. This connector collects data from the external cluster through the DataMiner Web API and displays the alarm state of the DataMiner Views and Services.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | DataMiner Web API V1        |

## Configuration

### Connections

#### HTTP Main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: 127.0.0.1
- **IP port**: 80
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Configuration of Agents

You can add/delete DataMiner Agents by right-clicking the **DataMiner Agents Table** and selecting the add/delete option in the context menu. For each new DataMiner Agent, you will need to enter the IP address of the Agent and a textual description.

## Usage

### General

The **General** page contains the **DataMiner Agents** table. This table displays the current status of each agent, including the following parameters: **IP Address**, **Administration State**, **Login State**, **Last Login Timestamp**, **Retrieve State**, **Last Retrieve Timestamp** and **Last Error Message**.

The protocol will try to reach the first DMA in the table with **Administration State = Enabled**, if this agent does not reply or returns an error message, the protocol will pass to the next agent. If all agents in the table are not available or reply with an error message, the element and all alarm states in **Services** and **Views** tables go to **Timeout**.

The **General** page also contains the **Configuration** page button. When clicked the configuration options are displayed in a popup window. Using the the configuration popup window the user can enter the **Login** credentials for the DataMiner Cluster, the name of the **Parent View**, the **Profondeur** of the views tree polling and the **Synchronization Time** interval.

### Views

The **Views** page contains the **Views** table. This table displays the current status of each polled view, including the following parameters: **ID**, **Name**, **Alarm State**, **Last Update Timestamp** and **Level**. The **Refresh All** button forces the re-polling of all the views.

### Services

The **Services** page contains the **Services** table. This table displays the current status of each polled service, including the following parameters: **ID**, **Name**, **Service State** and **Last Update Timestamp**. The **Refresh All** button forces the re-polling of all the services.
