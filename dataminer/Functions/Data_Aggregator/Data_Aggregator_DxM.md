---
uid: Data_Aggregator_DxM
description: "Learn how Data Aggregator runs scheduled GQI queries across DataMiner Systems and exports the combined results."
---

# Data Aggregator

The Data Aggregator module is available as a DxM ([DataMiner Extension Module](xref:DataMinerExtensionModules)) that can be used to schedule GQI queries to run periodically at fixed times, dates, or intervals. It can connect to multiple DataMiner Systems and combine the results of the GQI queries executed per DMS into one result. This result can then be exported to a CSV file or made available over a WebSocket connection.

- [Installation and setup](xref:Data_Aggregator_install_setup)

- [Settings overview](xref:Data_Aggregator_settings)

- [Configuring GQI queries](xref:Data_Aggregator_queries)

> [!IMPORTANT]
> As no authentication is required to use Data Aggregator (including its REST API and WebSocket interface), in principle anyone could access it. To restrict access, use a firewall.
