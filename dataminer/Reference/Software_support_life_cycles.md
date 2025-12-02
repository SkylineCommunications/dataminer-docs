---
uid: Software_support_life_cycles
keywords: support life cycle, product life cycle, product lifecycle
description: Keep track of the current support lifecycle for DataMiner versions, DataMiner functionality, and third-party software.
---

# Software support lifecycles

## DataMiner support lifecycle policy

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

> [!NOTE]
> For information about functionality in soft launch that is retired, refer to [Overview of soft-launch options](xref:Overview_of_Soft_Launch_Options).

### End of Engineering

The following features currently have the "End of Engineering" status. They will no longer be updated but are currently still supported.

| Item | Details | Future status |
|------|---------|---------------|
| [Atlassian Crowd authentication](xref:Configuring_Atlassian_Crowd_settings#authenticating-dataminer-users-against-an-atlassian-crowd-server) | This type of authentication will be deprecated. | End of Life to be confirmed. |
| Connectors: Display columns in tables | The [displayColumn attribute](xref:Protocol.Params.Param.ArrayOptions-displayColumn) should no longer be used in tables. | End of Life to be confirmed. |
| Connectors: [dllName option in QAction options attribute](xref:Protocol.QActions.QAction-options#dllnamenamedll) | This option is superfluous and should no longer be used. | End of Support as of DataMiner 10.7.x (Q4 2026). <br>End of Life as of DataMiner 10.8.x (Q4 2027). |
| Legacy reservations | The legacy type of reservation used prior to DataMiner 9.5.3/9.6.0 (RN 15180) is obsolete and should no longer be used. | End of Life to be confirmed. |
| Logger tables of type DirectConnection with a primary key |See [Defining a logger table of type DirectConnection with a primary key](xref:AdvancedLoggerTablesDefiningDirectConnectionTable). | End of Support as of DataMiner 10.7.x (Q4 2026). <br>End of Life as of DataMiner 10.8.x (Q4 2027). |
| Pivot table and Group components | End of Engineering as of DataMiner 10.6.x. These components are being retired in the Dashboards app and Low-Code Apps. | End of Support as of DataMiner 10.7.x (Q4 2026).<br>End of Life as of DataMiner 10.8.x (Q4 2027). |
| [Radius authentication](xref:Configuring_RADIUS_settings) | This type of authentication is deprecated and has inherent flaws. We recommend using a different type of authentication instead. | End of Support as of DataMiner 10.7.x (Q4 2026). <br>End of Life as of DataMiner 10.8.x (Q4 2027). |

### End of Support

The following features currently have the "End of Support" status. They will no longer be updated and are no longer supported.

| Item | Details | Future status |
|------|---------|---------------|
| Asset Manager | End of Support as of DataMiner 10.6.x. Module is being retired. | End of Life to be confirmed. |
| Logger tables with autoincrement option | See [autoincrement](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-type#autoincrement). | End of Life as of DataMiner 10.8.x (Q4 2027). |
| Legacy Reporter & Dashboards | Module is being retired and replaced with the new DataMiner Dashboards app. | End of Life as of DataMiner 10.7.x (Q4 2026). |
| Query executor | Tool is being retired. | End of Life as of DataMiner 10.7.x (Q4 2026). |
| [SLScripting as a service](xref:Configuration_of_DataMiner_processes#running-slscripting-as-a-service) | This configuration is obsolete and should not be used. | End of Life as of DataMiner 10.7.x (Q4 2026). |
| Use of JScript in QActions | C# should be used instead. JScript in QActions cannot be used on Windows Server 2025. | End of Life as of DataMiner 10.7.x (Q4 2026). |
| Use of VBScript in QActions | C# should be used instead. | End of Life as of DataMiner 10.7.x (Q4 2026). |

### End of Life

The following features currently have the "End of Life" status. They are no longer available in current DataMiner versions.

| Item | Details |
|------|---------|
| Annotations | From DataMiner 10.3.x onwards, Annotations should no longer be used. From DataMiner 10.6.x onwards, this feature is no longer available. |
| Child bookings | End of Life as of DataMiner 10.5.x. Child bookings have been retired, as the same functionality is supported with contributing bookings |
| Jobs app | End of Life as of DataMiner 10.5.x. |
| Legacy Correlation Engine | End of Life as of DataMiner 10.5.x. This only applies to the legacy System Display Correlation engine |
| OPC communication | OPC communication should no longer be used in DataMiner connectors. Instead, QActions should be used, for example like in the [Generic OPC Data Access](https://catalog.dataminer.services/details/f2642ea9-9eaa-42f3-880e-816470b06a61) connector. |
| Recurring bookings | End of Life as of DataMiner 10.5.x. Recurring bookings have been retired. Instead, we suggest duplicating the previous occurrence of the booking. |
| Ticketing app | End of Life as of DataMiner 10.6.x. Skyline is researching a replacement for this module. |
| Web Services API v0 | From DataMiner 10.1.5 onwards, version 0 of the DataMiner Web Services API is disabled. Users will be required to port any reliant applications to use Web Services API v1. |
| XML storage of SRM resources and profiles | From DataMiner 10.4.0/10.4.1 onwards, SRM resources and profiles must be stored in the indexing database instead of in XML. |

## Third-party software support lifecycle

> [!NOTE]
> For all supported DataMiner versions, we support all Windows versions that Microsoft currently supports.

### End of Engineering

The following features currently have the "End of Engineering" status. They will no longer be updated but are currently still supported.

| Item | Details | Future status |
|------|---------|---------------|
|Support for Cassandra Single | Support will end for setups where each DMA has its own Cassandra database. Instead we recommend switching to [STaaS](xref:STaaS). Though this is not recommended, you can also use [dedicated clustered storage](xref:Dedicated_clustered_storage) instead. | End of support as of DataMiner 10.7.x (Q4 2026). |
| Support for Elasticsearch 6.8 | As Elastic no longer supports Elasticsearch 6.8 (or lower), support for this will also end in DataMiner. We highly recommend switching to [STaaS](xref:STaaS). Though this is not recommended, you can also use [OpenSearch](xref:OpenSearch_database) instead. | End of support as of DataMiner 10.7.x (Q4 2026). |

### End of Support

The following features currently have the "End of Support" status. They will no longer be updated and are no longer supported.

| Item | Details | Future status |
|------|---------|---------------|
| Support for Cassandra database on Windows OS | Cassandra no longer supports Windows as its operating system from version 4.x onwards. Consequently, from DataMiner 10.4.x onwards, Cassandra databases on Windows up to Cassandra version 3.11 are no longer supported. We recommend moving to a Linux system, using [Ubuntu LTS](https://catalog.dataminer.services/details/c6285161-e8c7-4be3-a8b3-20259b20815b). | End of life to be confirmed. |
| Support for Cassandra versions prior to 4.x |Cassandra versions older than Cassandra 4.x are no longer supported on any operating system.| End of Life as of DataMiner 10.7.x (Q4 2026).|
| Support for MySQL as local database | End of Support as of DataMiner 10.6.x. Existing features will work, but some new features will require [Storage as a Service](xref:STaaS) (recommended) or [dedicated clustered storage](xref:Dedicated_clustered_storage). | End of Life to be confirmed. |
| Two-site redundant indexing clusters | This setup should no longer be used. For optimal redundancy, we recommend switching to [Storage as a Service](xref:STaaS). | End of Life as of DataMiner 10.7.x (Q4 2026).|

### End of Life

The following features currently have the "End of Life" status. They are no longer available in current DataMiner versions.

| Item | Details |
|------|---------|
| Support for Amazon Keyspaces Service, Azure Managed Instance for Apache Cassandra Service, and Amazon OpenSearch Service | End of Life as of DataMiner 10.5.x. Support for this feature ended with DataMiner 10.3.0 [CU8]/10.3.11. We recommend switching to [Storage as a Service](xref:STaaS). Note that, though not recommended, using a self-managed OpenSearch database remains supported. |
| Support for DataMiner Cube running in Internet Explorer/Edge in IE compatibility mode (XBAP) | End of Life as of DataMiner 10.3.x. |
| Support for MSSQL as local database | End of Life as of DataMiner 10.3.x. We recommend switching to [Storage as a Service](xref:STaaS). |
| Support for Visual Studio 2015 | End of Life as of DIS 2.35. DIS will no longer be compatible with this Visual Studio version. |
| Support for Visual Studio 2017 | End of Life as of DIS 2.41. DIS will no longer be compatible with this Visual Studio version. |
| Support for Visual Studio 2019 | End of Life as of DIS 3.0. DIS will no longer be compatible with this Visual Studio version. |
