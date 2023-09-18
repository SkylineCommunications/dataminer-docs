---
uid: Connector_help_Generic_Docsis_CPE_Manager
---

# Generic Docsis CPE Manager

This connector aggregates and displays information from CM and CMTS. This connector can be used as a BE or FE CPE Manager.

## About

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

## Installation and configuration

### Creation

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### network topology

In this page it's possible to see the network topology. A diagram is presented according to KPIs selected from the drop-down lists available in the page.

There is also general information available regarding the CMTS and CM selected from the drop-down list.

- In the **Diagram** tab is the diagram of the network topology, this is built by selecting values from the drop-down lists. The network topology presented has the following structure: Network -\> Region -\>POP-\>CMTS-\> CMTS Blade -\> CMTS Port -\> Node -\> CM.
- In the **DS QAM** and **US QAM** tabs there's information about the QAM channels associated with the CM selected.
- In the **DS OFDM** and **US OFDM** tabs there's information about the US/DS 3.1 channels associated with the CM selected.

### service topology

In this page it's possible to see the service topology. A diagram is presented according to KPIs selected from the drop-down lists available in the page.

There is also general information available regarding the CM selected from the drop-down list.

- In the **Diagram** tab is the diagram of the service topology, this is built by selecting values from the drop-down lists. The service topology presented has the following structure: Service Provider-\> Service Region-\>Service Headend-\>DS/US Service Group-\> Service Group -\> Subscriber -\> CM.
- In the **DS QAM** and **US QAM** tabs there's information about the QAM channels associated with the CM selected.
- In the **DS OFDM** and **US OFDM** tabs there's information about the US/DS 3.1 channels associated with the CM selected.

### configuration

In this page is where the general configurations are done as well as the aggregation of the information from the CMTS and CM by pressing **Provision.**

In the **CPE Manager Type** it's possible to select the type of CPE (BE or FE).

- In the **general** tab one can define the directory where the necessary files are. This directory is defined and is the same in for the following: **Provisioning Location**, **Frontend Share Location** and **Backend Share Location** (only defined if the element is a BE).
