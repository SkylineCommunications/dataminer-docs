# What is EPM?

**EPM** stands for Experience and Performance Management. These solutions poll large amounts of data and display all relevant information in one manager.

EPM architecture allows to calculate aggregated KPI data from the lowest level through each level in the Topology and maintain relations to figure out the highest level affecting the issue.

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
