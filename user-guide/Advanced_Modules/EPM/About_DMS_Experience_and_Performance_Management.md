---
uid: About_DMS_Experience_and_Performance_Management
---

# About DataMiner Experience and Performance Management

## EPM elements

An EPM element (formerly known as CPE Manager) is created like any other DataMiner element, on a standard DMA with capacity license. However, unlike a regular element, it can control and monitor a large number of objects. Its specific properties depend on the protocol that is assigned to it during element creation.

Many different EPM protocols exist, and often these are custom-made to match particular situations. EPM elements have a dedicated user interface, which is determined by the element protocol. As such, the user interface can be different for each EPM element.

## EPM architecture

EPM uses the following protocols:

- **EPM Manager** protocol: Used for one front-end (FE) element and multiple back-end (BE) elements.

- **EPM Collector** protocol(s): Used to poll all the lowest-level information and inform the FE of the topology relationships.

A typical EPM architecture consists of the following elements:

- **Front-end** element:

  - In charge of provisioning and assigning unique keys to all topology entities.
  - Only sets tables with higher-level topology entities.
  - In charge of aggregation at the higher level.
  - Merges remaining topology information from all BE elements.
  - Ideally should be on its own DMA with few or no other elements.

- **Back-end** element:

  - Contains the rest of the topology information.
  - In charge of aggregating the remaining levels.
  - In typical EPM installations, only one BE element is needed per DMA. They are the managers of the entire DMA.

- **Collector** elements:

  - Poll device KPI information.
  - As many collector elements per DMA as needed.
