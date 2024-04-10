---
uid: About_DMS_Experience_and_Performance_Management
---

# About DataMiner Experience and Performance Management

### EPM elements

An EPM element (formerly known as CPE Manager) is created like any other DataMiner element, on a standard DMA with capacity license. However, unlike a regular element, it can control and monitor a large number of objects. Its specific properties depend on the protocol that is assigned to it during element creation.

Many different EPM protocols exist, and often these are custom-made to match particular situations. EPM elements have a dedicated user interface, which is determined by the element protocol. As such, the user interface can be different for each EPM element.

## EPM Architecture

**EPM Manager Driver**: Used for one FE (Frontend) element and multiple BE (Backend) elements.

**EPM Collector Driver(s)**: Used to poll all the lowest level information and let FE know of the Topology relationships.

### Element Responsibilities

**Frontend**
-	In charge of provisioning and assigning unique keys to all topology entities.
-	Only sets tables with higher level topology entities.
-	In charge of aggregations at the higher level.
-	Merges remaining topology information from all BE elements.
-	Ideally should be on it’s own DMA with little to no other elements.

**Backend**
-	Contains the rest of the topology information.
-	In charge of aggregating the remaining levels.
-	In typical EPM installations, only one BE element is needed per DMA. They are the managers of the entire DMA.

**Collectors**
-	Poll device KPI information.
-	As many Collector elements per DMA as needed.
