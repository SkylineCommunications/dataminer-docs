---
uid: Get_DCF_connections
---

# Get DCF connections

Available from DataMiner 10.2.0/10.1.6 onwards. The *Get DCF connections* data source retrieves a list of the DCF connections in the DataMiner System. For each connection, this includes the source and destination element ID and interface ID, the ID of the connection, any properties on interfaces, any parameters that interfaces are linked to, and an *IsInternal* column that indicates whether the connection is internal or external.

> [!NOTE]
> DCF connections are returned for each active element. As external connections are configured both on the source element and the destination element, each external connection will therefore be listed twice if both elements are active. If both the source element and the destination element of an external connection are stopped, the connection will not be listed. If only the source element or the destination element is stopped, the connection will be listed once.

> [!TIP]
> See also: [DataMiner Connectivity Framework](xref:About_the_DataMiner_Connectivity_Framework)
