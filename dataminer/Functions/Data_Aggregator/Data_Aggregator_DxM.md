---
uid: Data_Aggregator_DxM
---

# Data Aggregator

The Data Aggregator module is available as a DxM ([DataMiner Extension Module](xref:DataMinerExtensionModules)) that can be used to schedule GQI queries to run periodically at fixed times, dates, or intervals. It can connect to multiple DataMiner Systems and combine the results of the GQI queries executed per DMS into one result. This result can then be exported to a CSV file or made available over a WebSocket connection.

This DxM is included in DataMiner upgrade packages from DataMiner 10.5.9/10.6.0 onwards<!--RN 43334-->. However, the DxM will only be upgraded if an older version is found on the DMA. If no older version is found, it will not be installed.

- [Installation and setup](xref:Data_Aggregator_install_setup)

- [Settings overview](xref:Data_Aggregator_settings)

- [Configuring GQI queries](xref:Data_Aggregator_queries)

> [!IMPORTANT]
>
> - As no authentication is required to use Data Aggregator (including its REST API and WebSocket interface), in principle anyone could access it. To restrict access, use a firewall.
> - When upgrading the Data Aggregator module from version 2.x.x to 3.0.0 or higher, and if your prior installation included configured GQI queries, a one-time migration process using a [Data Aggregator Migrator](xref:Data_Aggregator_Migrators#upgrading-from-version-2xx) is necessary.
> - When enabling the GQI DxM on the Data Aggregator, and if your prior installation included configured GQI queries, a one-time migration process using a [Data Aggregator Migrator](xref:Data_Aggregator_Migrators#enabling-gqi-dxm) is necessary.
