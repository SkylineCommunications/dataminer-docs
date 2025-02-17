---
uid: Software_support_life_cycles
keywords: support lifecycle, product lifecycle
description: Keep track of the current support life cycle for DataMiner versions, DataMiner functionality, and third-party software.
---

# Software support life cycles

## DataMiner support life cycle policy

If you are following the **Feature Release** track, you always need to **upgrade to the latest version** to get the latest security updates. If you do not want to upgrade to a new Feature Release version but do want to get the latest security updates, you will need to switch to the Main Release track instead.

For the **Main Release** track, the following support is available:

| Version | Regular updates until | Supported until     | *Limited support until* |
|---------|-----------------------|---------------------|-------------------------|
| 10.5.0  | 20 Nov 2026           | **25 Feb 2028**     | *23 Feb 2029*           |
| 10.4.0  | 21 Nov 2025           | **26 Feb 2027**     | *25 Feb 2028*           |
| 10.3.0  | 15 Nov 2024           | **27 Feb 2026**     | *26 Feb 2027*           |
| 10.2.0  | 24 Nov 2023           | **28 Feb 2025**     | *27 Feb 2026*           |
| 10.1.0  | 18 Nov 2022           | **23 Feb 2024**     | *28 Feb 2025*           |

Older versions are no longer supported.

Legend:

- **Regular updates**: Monthly cumulative updates containing fixes and security updates.
- **Supported**: Security updates and critical bug fixes only (as required).
- **Limited support**: Online technical help without software updates for fixes, security updates, or features.

> [!NOTE]
> For security updates with third-party dependencies that are only compatible with a later version of DataMiner, it will be necessary to upgrade to this later version.

> [!TIP]
> See also [DataMiner Main Release vs. Feature Release](xref:DataMiner_MR_vs_FR).

## DataMiner functionality evolution and retirement

Important announcements about the latest changes to DataMiner core functionality and behavior.

| Item | <div style="width: 150px;">Current status</div> | Detail | Future status |
|---------|---------|---------|---------|
| Use of VBScript in QActions | End of Support | | End of Life to be confirmed |
| Asset Manager | End of Engineering | Module is being retired. | End of Life to be confirmed |
| Pivot table and Group components | End of Engineering | These components are being retired in the Dashboards app and Low-Code Apps. | End of Life to be confirmed |
| Ticketing app | End of Engineering | Skyline is researching a replacement for this module. | End of Life as of DataMiner version 10.6.x (Q4 2025) |
| Legacy Correlation Engine | End of Engineering | Module is being retired. Note that this only applies to the legacy System Display Correlation engine | End of Life as of DataMiner version 10.5.x (Q4 2024) |
| Jobs app | End of Engineering | Module is being retired. | End of Life as of DataMiner version 10.5.x (Q4 2024) |
| Child bookings | End of Engineering | Child bookings are being retired, as the same functionality is supported with contributing bookings | End of Life as of DataMiner version 10.5.x (Q4 2024) |
| Recurring bookings | End of Engineering | Recurring bookings are being retired. Instead, we suggest duplicating the previous occurrence of the booking. | End of Life as of DataMiner version 10.5.x (Q4 2024) |
| Legacy Reporter & Dashboards | End of Support | Module is being retired and replaced with the new DataMiner Dashboards app. | End of Life as of DataMiner version 10.6.x (Q4 2025) |
| Annotations | End of Life | From DataMiner version 10.3.x (Q4 2022) onwards, Annotations should no longer be used. | End of Life |
| Web Services API v0 | End of Life | From DataMiner version 10.1.5 onwards, version 0 of the DataMiner Web Services API is disabled. Users will be required to port any reliant applications to use Web Services API v1. | End of Life |
| XML storage of SRM resources and profiles | End of Life | From DataMiner 10.4.0/10.4.1 onwards, SRM resources and profiles must be stored in the indexing database instead of in XML. | End of Life |

Status overview:

- **End of Engineering**: Feature will no longer be updated, but will still be supported.
- **End of Support**: Feature will no longer be updated and no longer be supported.
- **End of Life**: Feature or compatibility will be removed.

> [!NOTE]
> For information about functionality in soft launch that is retired, refer to [Overview of soft-launch options](xref:Overview_of_Soft_Launch_Options).

## Third-party software support life cycle

| Item | Current status | Detail | Future status |
|---------|---------|---------|---------|
| Support for Cassandra Single | End of Engineering | Support will end for setups where each DMA has its own Cassandra database. Instead we recommend switching to [STaaS](xref:STaaS). Though this is not recommended, you can also use [dedicated clustered storage](xref:Dedicated_clustered_storage) instead. | End of Life to be confirmed |
| Support for Elasticsearch 6.8 | End of Engineering | As Elastic no longer supports Elasticsearch 6.8, support for this will also end in DataMiner. We highly recommend switching to [STaaS](xref:STaaS). Though this is not recommended, you can also use [OpenSearch](xref:OpenSearch_database) instead. | End of Life to be confirmed |
| Support for MySQL as local database | End of Support as of DataMiner 10.3 (Q4 2022) | Existing features will work, but some new features will require [Storage as a Service](xref:STaaS) (recommended) or [dedicated clustered storage](xref:Dedicated_clustered_storage). | End of Life to be confirmed. |
| Support for Amazon Keyspaces Service, Azure Managed Instance for Apache Cassandra Service, and Amazon OpenSearch Service | End of Support as of DataMiner 10.3.0 [CU8]/10.3.11 | Feature will no longer be supported. We recommend switching to [Storage as a Service](xref:STaaS). Note that, though not recommended, using a self-managed OpenSearch database remains supported. | End of Life as of DataMiner 10.5 (G4 2024)  |
| Support for MSSQL as local database | End of Life as of DataMiner 10.3 (Q4 2022) | Feature will no longer be supported. We recommend switching to [Storage as a Service](xref:STaaS). | End of Life as of DataMiner version 10.3.x (Q4 2022) |
| Support for DataMiner Cube running in Internet Explorer/Edge in IE compatibility mode (XBAP) | End of Life | Existing features will work, but some new features will only be supported in the DataMiner Cube desktop app. | End of Life as of DataMiner version 10.3.x (Q4 2022) |
| Support for Cassandra database on Windows OS | End of Support as of Cassandra 4.x (Q3 2021) | Cassandra no longer supports Windows as its operating system from version 4.x onwards. Consequently, from DataMiner 10.4.x onwards, Cassandra databases on Windows up to Cassandra version 3.11 are no longer supported. We recommend moving to a Linux system, using [Ubuntu LTS](https://catalog.dataminer.services/details/package/5621). | |
| Support for Visual Studio 2015 | End of Life as of DIS 2.35 | DIS will no longer be compatible with this Visual Studio version. |   |
| Support for Visual Studio 2017 | End of Life as of DIS 2.41 | DIS will no longer be compatible with this Visual Studio version. |   |
| Support for Visual Studio 2019 | End of Life as of DIS 3.0 | DIS will no longer be compatible with this Visual Studio version. |   |

Status overview:

- **End of Engineering**: Feature will no longer be updated, but will still be supported.
- **End of Support**: Feature will no longer be updated and no longer be supported.
- **End of Life**: Feature or compatibility will be removed.

> [!NOTE]
> For all supported DataMiner versions, we support all Windows versions that Microsoft currently supports.
