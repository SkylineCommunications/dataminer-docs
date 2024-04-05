---
uid: EpmIntegrationTrainingPackage
---

# Installation
The package is available in the catalog and can be deployed into your system if it is cloud-connected, or it can be downloaded and executed on one of the agents in your cluster.

The package can be installed on a single agent, if more are present then, the package will utilize at most 3 agents to create a Frontend element, two Backend elements, and three collectors, distributing them across the agents as follows:

- [Agent 1] - **EPM Availability FE**

* [Agent 2] - **EPM Availability BE 1**

    - **EPM Availability Collector 1**
    - **EPM Availability Collector 2**
    
- [Agent 3] - **EPM Availability BE 2**
    - **EPM Availability Collector 3**

# About

The EPM Integration Training package provides you with all the necessary components to understand, navigate, and get hands-on with an EPM solution.

- [Introduction](xref:EpmIntegrationTrainingIntroduction)
- [Connectors](xref:EpmIntegrationTrainingConnectors)
- [Other Options](xref:EpmIntegrationTrainingOtherOptions)