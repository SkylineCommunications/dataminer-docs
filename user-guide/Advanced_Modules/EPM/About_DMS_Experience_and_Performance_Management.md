---
uid: About_DMS_Experience_and_Performance_Management
---

# About DataMiner Experience and Performance Management

### EPM elements

An EPM element (formerly known as CPE Manager) is created like any other DataMiner element, on a standard DMA with capacity license. However, unlike a regular element, it can control and monitor a large number of objects. Its specific properties depend on the protocol that is assigned to it during element creation.

Many different EPM protocols exist, and often these are custom-made to match particular situations. EPM elements have a dedicated user interface, which is determined by the element protocol. As such, the user interface can be different for each EPM element.

### Architecture

A typical architecture for a DMS used for Experience and Performance Management consists of:

- A front-end DMA with an EPM element:

  - Provides the user interface users connect to for Experience and Performance Management.

  - Responsible for aggregation of higher level data.

  - Responsible for provisioning, i.e. provides a reference of all objects and their topology, the link between the objects.

  - Responsible for interaction with other systems.

- Several back-end DMAs:

  - Responsible for aggregation of lower level data.

  - Several collector elements can be created per DMA and per type of individual object.

  - Each collector element polls a group of objects, with a refresh period depending on the number of objects.
