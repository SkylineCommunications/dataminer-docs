---
uid: EpmIntegrationTrainingIntroduction
---

# Introduction
The EPM Integration Training package provides you with all the necessary components to understand, navigate, and get hands-on with an EPM solution.

## Installation
The package is available in the catalog and can be deployed into your system if it is cloud-connected, or it can be downloaded and executed on one of the agents in your cluster.

The package can be installed on a single agent, if more are present then, the package will utilize at most 3 agents to create a Frontend element, two Backend elements, and three Collectors, distributing them across the agents as follows:

- [Agent 1] - **EPM Availability FE**

- [Agent 2] - **EPM Availability BE 1**
    - **EPM Availability Collector 1**
    - **EPM Availability Collector 2**

- [Agent 3] - **EPM Availability BE 2**
    - **EPM Availability Collector 3**

## Which components are installed and deployed on my system?

### Connectors

- Skyline EPM Integration Training Manager
- Skyline EPM Integration Training Collector

### Web Apps

 - Dashboards
    - Device Overview
    - Device Grid Overview
- EPM Integration Training

### Visio

- Skyline EPM Integration Training.vsdx

### Table Structure

The Frontend has minimal information in its local tables. It retrieves all the DMS information via View tables.

|  | Frontend Local Table | Frontend View Table | Backend Local Table |
| --- | --- | --- | --- |
| Network |	PK,FK,KPI's	| PK,FK,KPI's |	Empty |
| Region |	PK,FK	| PK,FK,KPI's |	PK,FK,KPI's |
| Sub-Region |	Empty	| PK,FK,KPI's |	PK,FK,KPI's |
| Hub |	Empty	| PK,FK,KPI's |	PK,FK,KPI's |
| Station |	Empty	| PK,FK,KPI's |	PK,FK,KPI's |
| Endpoint |	Empty	| PK,FK |	PK,FK |
