---
uid: srm_instantiations
---

# SRM instantiations

This section explains the instantiations in the SRM framework, which are actual objects created based on SRM definitions.

## Element

A DataMiner element represents a data source that is monitored by the DataMiner System. An element uses a connector to retrieve information from the data source. Typically, an element is linked to a single physical device or platform.

While a connector defines how to communicate with a data source and which information should be retrieved from the data source, an element using a connector actually retrieves the information. Usually, an element is created for each data source.

For example, an element could be created to represent a cloud-based server. The element will show all KPIs retrieved from that server.

> [!TIP]
> See also: [About elements](xref:About_elements)
