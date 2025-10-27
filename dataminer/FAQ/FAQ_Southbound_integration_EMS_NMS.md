---
uid: FAQ_Southbound_integration_EMS_NMS
---

# What is the recommended method for southbound integration of an EMS/NMS?

The standard and recommended method for southbound integration of an EMS/NMS is that DataMiner interfaces and interacts with all the underlying devices of the said EMS/NMS directly. This provides the only and best guarantee that any end-to-end workflows can be successfully implemented, across any vendor and technology boundaries, and that all current and future requirements can be met.

Using this method, individual DataMiner connectors will be used per underlying data source (device, system, software application, etc.), but an EMS/NMS connector could also be required in scenarios where the said EMS/NMS itself has e.g. certain calculated OIDs to share that are not available through direct data source integrations. Here, each data source integrated will be created as one dedicated managed object within DataMiner.

As opposed to the recommended method above, a monolithic integration is when DataMiner integrates with an external EMS/NMS and represents the polled data within one single managed object in DataMiner. Here, all functionalities (monitoring & control) allowed through the EMS/NMS northbound interface (NBI) will be reflected in DataMiner within a single table or similar representation. Only a single alarm template and a single trend template will be available for all managed OIDs within. In a monolithic integration, an alarm to any one of the OIDs from the EMS/NMS's underlying devices will result in a higher-level alarm of the one single managed object.

A more advanced option of the latter is DataMiner Virtual Element (DVE) creation through EMS/NMS integration. However, it depends on the capabilities of the MIB/API of said EMS/NMS whether DVE creation can be supported. In this case, DataMiner could use a replicated integration, where we use the EMS/NMS northbound interface to retrieve all the details of the underlying devices, and use that to recreate each of the individual device again in the DataMiner Surveyor. This method allows the separation of elements and monitoring within the Surveyor as opposed to one single managed object when integrated via monolithic integration.
