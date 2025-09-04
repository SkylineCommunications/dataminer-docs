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
| 10.6.0  | 19 Nov 2027           | **23 Feb 2029**     | *22 Feb 2030*           |
| 10.5.0  | 20 Nov 2026           | **25 Feb 2028**     | *23 Feb 2029*           |
| 10.4.0  | 21 Nov 2025           | **26 Feb 2027**     | *25 Feb 2028*           |
| 10.3.0  | 15 Nov 2024           | **27 Feb 2026**     | *26 Feb 2027*           |
| 10.2.0  | 24 Nov 2023           | **28 Feb 2025**     | *27 Feb 2026*           |

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
| Legacy Correlation Engine | End of Engineering | Module is being retired. Note that this only applies to the legacy System Display Correlation engine | End of Life as of DataMiner version 10.5.x (Q4 2024). |
| Jobs app | End of Engineering | Module is being retired. | End of Life as of DataMiner version 10.5.x (Q4 2024). |
| Child bookings | End of Engineering | Child bookings are being retired, as the same functionality is supported with contributing bookings | End of Life as of DataMiner version 10.5.x (Q4 2024). |
| Recurring bookings | End of Engineering | Recurring bookings are being retired. Instead, we suggest duplicating the previous occurrence of the booking. | End of Life as of DataMiner version 10.5.x (Q4 2024). |
| Asset Manager | End of Engineering | Module is being retired. | End of Support as of DataMiner version 10.6.x (Q4 2025). |
| Pivot table and Group components | End of Engineering | These components are being retired in the Dashboards app and Low-Code Apps. | End of Support as of DataMiner version 10.6.x (Q4 2025). |
| Ticketing app | End of Engineering | Skyline is researching a replacement for this module. | End of Life as of DataMiner version 10.6.x (Q4 2025). |
| Logger tables of type DirectConnection with a primary key | End of Engineering | See [Defining a logger table of type DirectConnection with a primary key](xref:AdvancedLoggerTablesDefiningDirectConnectionTable). | End of Support as of DataMiner version 10.7.x (Q4 2026). <br>End of Life as of DataMiner 10.8.x (Q4 2027). |
| [Radius authentication](xref:Configuring_RADIUS_settings) | End of Engineering | This type of authentication is deprecated and has inherent flaws. We recommend using a different type of authentication instead. | End of Support as of DataMiner version 10.7.x (Q4 2026). <br>End of Life as of DataMiner 10.8.x (Q4 2027). |
| Connectors: [dllName option in QAction options attribute](xref:Protocol.QActions.QAction-options#dllnamenamedll) | End of Engineering | This option is superfluous and should no longer be used. | End of Support as of DataMiner version 10.7.x (Q4 2026). <br>End of Life as of DataMiner 10.8.x (Q4 2027). |
| [Atlassian Crowd authentication](xref:Configuring_Atlassian_Crowd_settings#authenticating-dataminer-users-against-an-atlassian-crowd-server) | End of Engineering | This type of authentication will be deprecated. | End of Life to be confirmed. |
| Connectors: Display columns in tables | End of Engineering | The [displayColumn attribute](xref:Protocol.Params.Param.ArrayOptions-displayColumn) should no longer be used in tables. | End of Life to be confirmed. |
| Legacy reservations | End of Engineering | The legacy type of reservation used prior to DataMiner 9.5.3/9.6.0 (RN 15180) is obsolete and should no longer be used. | End of Life to be confirmed. |
| Legacy Reporter & Dashboards | End of Support | Module is being retired and replaced with the new DataMiner Dashboards app. | End of Life as of DataMiner version 10.6.x (Q4 2025). |
| [SLScripting as a service](xref:Configuration_of_DataMiner_processes#running-slscripting-as-a-service) | End of Support | This configuration is obsolete and should not be used. | End of Life as of DataMiner version 10.7.x (Q4 2026). |
| Query executor | End of Support | Tool is being retired. | End of Life as of DataMiner version 10.7.x (Q4 2026). |
| Use of JScript in QActions | End of Support | C# should be used instead. JScript in QActions cannot be used on Windows Server 2025. | End of Life as of DataMiner version 10.7.x (Q4 2026). |
| Use of VBScript in QActions | End of Support | C# should be used instead. | End of Life as of DataMiner version 10.7.x (Q4 2026). |
| Logger tables with autoincrement option | End of Support | See [autoincrement](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-type#autoincrement). | End of Life as of DataMiner version 10.8.x (Q4 2027). |
| Annotations | End of Life | From DataMiner version 10.3.x (Q4 2022) onwards, Annotations should no longer be used. | End of Life. |
| OPC communication | End of Life | OPC communication should no longer be used in DataMiner connectors. Instead, QActions should be used, for example like in the [Generic OPC Data Access](https://catalog.dataminer.services/details/f2642ea9-9eaa-42f3-880e-816470b06a61) connector. | End of Life. |
| Web Services API v0 | End of Life. | From DataMiner version 10.1.5 onwards, version 0 of the DataMiner Web Services API is disabled. Users will be required to port any reliant applications to use Web Services API v1. | End of Life. |
| XML storage of SRM resources and profiles | End of Life | From DataMiner 10.4.0/10.4.1 onwards, SRM resources and profiles must be stored in the indexing database instead of in XML. | End of Life. |

Status overview:

- **End of Engineering**: Feature will no longer be updated, but will still be supported.
- **End of Support**: Feature will no longer be updated and no longer be supported.
- **End of Life**: Feature or compatibility will be removed.

> [!NOTE]
> For information about functionality in soft launch that is retired, refer to [Overview of soft-launch options](xref:Overview_of_Soft_Launch_Options).

## Third-party software support life cycle

| Item | Current status | Detail | Future status |
|---------|---------|---------|---------|
| Support for MySQL as local database | End of Engineering | Existing features will work, but some new features will require [Storage as a Service](xref:STaaS) (recommended) or [dedicated clustered storage](xref:Dedicated_clustered_storage). | End of Support as of DataMiner 10.6.x (Q4 2025). |
| Support for Cassandra Single | End of Engineering | Support will end for setups where each DMA has its own Cassandra database. Instead we recommend switching to [STaaS](xref:STaaS). Though this is not recommended, you can also use [dedicated clustered storage](xref:Dedicated_clustered_storage) instead. | End of support as of DataMiner 10.7.x (Q4 2026). |
| Support for Elasticsearch 6.8 | End of Engineering | As Elastic no longer supports Elasticsearch 6.8 (or lower), support for this will also end in DataMiner. We highly recommend switching to [STaaS](xref:STaaS). Though this is not recommended, you can also use [OpenSearch](xref:OpenSearch_database) instead. | End of support as of DataMiner 10.7.x (SQ4 2026). |
| Support for Amazon Keyspaces Service, Azure Managed Instance for Apache Cassandra Service, and Amazon OpenSearch Service | End of Support as of DataMiner 10.3.0 [CU8]/10.3.11 | Feature will no longer be supported. We recommend switching to [Storage as a Service](xref:STaaS). Note that, though not recommended, using a self-managed OpenSearch database remains supported. | End of Life as of DataMiner 10.5.x (G4 2024). |
| Support for Cassandra versions prior to 4.x | End of Support | Cassandra versions older than Cassandra 4.x are no longer supported on any operating system.| End of Life as of DataMiner version 10.7.x (Q4 2026).|
| Two-site redundant indexing clusters | End of Support | This setup should no longer be used. For optimal redundancy, we recommend switching to [Storage as a Service](xref:STaaS). | End of Life as of DataMiner version 10.7.x (Q4 2026).|
| Support for Cassandra database on Windows OS | End of Support as of Cassandra 4.x | Cassandra no longer supports Windows as its operating system from version 4.x onwards. Consequently, from DataMiner 10.4.x onwards, Cassandra databases on Windows up to Cassandra version 3.11 are no longer supported. We recommend moving to a Linux system, using [Ubuntu LTS](https://catalog.dataminer.services/details/c6285161-e8c7-4be3-a8b3-20259b20815b). | |
| Support for MSSQL as local database | End of Life as of DataMiner 10.3.x (Q4 2022) | Feature will no longer be supported. We recommend switching to [Storage as a Service](xref:STaaS). | End of Life as of DataMiner version 10.3.x (Q4 2022). |
| Support for DataMiner Cube running in Internet Explorer/Edge in IE compatibility mode (XBAP) | End of Life | Existing features will work, but some new features will only be supported in the DataMiner Cube desktop app. | End of Life as of DataMiner version 10.3.x (Q4 2022). |
| Support for Visual Studio 2015 | End of Life as of DIS 2.35 | DIS will no longer be compatible with this Visual Studio version. |   |
| Support for Visual Studio 2017 | End of Life as of DIS 2.41 | DIS will no longer be compatible with this Visual Studio version. |   |
| Support for Visual Studio 2019 | End of Life as of DIS 3.0 | DIS will no longer be compatible with this Visual Studio version. |   |

Status overview:

- **End of Engineering**: Feature will no longer be updated, but will still be supported.
- **End of Support**: Feature will no longer be updated and no longer be supported.
- **End of Life**: Feature or compatibility will be removed.

> [!NOTE]
> For all supported DataMiner versions, we support all Windows versions that Microsoft currently supports.
