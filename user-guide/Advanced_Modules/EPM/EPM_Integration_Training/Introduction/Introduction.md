---
uid: EpmIntegrationTrainingIntroduction
---

# Introduction

The EPM Integration Training package provides you with all the necessary components to understand, navigate, and get hands-on with an EPM solution.

## Installation

If your DataMiner System is connected to dataminer.services, you can deploy the package directly from the DataMiner Catalog. Otherwise, you can download it from the Catalog and execute it on one of the DMAs in your cluster.

You can install the package on a single DMA. If more DMAs are present in the cluster, the package will utilize at most three DMAs to create a front-end element, two back-end elements, and three collectors, distributing them across the DMAs as follows:

- Agent 1:

  - **EPM Availability Front End**

- Agent 2:

  - **EPM Availability Back-End 1**
  - **EPM Availability Collector 1**
  - **EPM Availability Collector 2**

- Agent 3:

  - **EPM Availability Back-End 2**
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

## Table structure

The front end has minimal information in its local tables. It retrieves all the DMS information via View tables.

|            | Frontend Local Table | Frontend View Table | Backend Local Table |
|------------|----------------------|---------------------|---------------------|
| Network    | PK,FK,KPIs           | PK,FK,KPIs          | Empty               |
| Region     | PK,FK                | PK,FK,KPIs          | PK,FK,KPIs          |
| Sub-Region | Empty                | PK,FK,KPIs          | PK,FK,KPIs          |
| Hub        | Empty                | PK,FK,KPIs          | PK,FK,KPIs          |
| Station    | Empty                | PK,FK,KPIs          | PK,FK,KPIs          |
| Endpoint   | Empty                | PK,FK               | PK,FK               |
