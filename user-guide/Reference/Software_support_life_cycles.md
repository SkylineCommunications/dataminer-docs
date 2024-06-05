---
uid: Software_support_life_cycles
---

# Software support life cycles

## DataMiner support life cycle policy

### Main Release track

| Version | Regular updates until | Supported until | Limited support until | Not supported from |
|---------|-----------------------|-----------------|-----------------------|--------------------|
| 10.4.0  | 21 Nov 2025           | 26 Feb 2027     | 25 Feb 2028           | 25 Feb 2028        |
| 10.3.0  | 15 Nov 2024           | 27 Feb 2026     | 26 Feb 2027           | 26 Feb 2027        |
| 10.2.0  | 24 Nov 2023           | 28 Feb 2025     | 27 Feb 2026           | 27 Feb 2026        |
| 10.1.0  | 18 Nov 2022           | 23 Feb 2024     | 28 Feb 2025           | 28 Feb 2025        |
| 10.0.0  | 17 Dec 2021           | 24 Feb 2023     | 23 Feb 2024           | 23 Feb 2024        |
| 9.6.0   | -                     | 25 Feb 2022     | 24 Feb 2023           | 24 Feb 2023        |

For the Main Release track, different support levels are maintained for the different versions:

- **Regular updates**: Monthly cumulative updates containing fixes and security updates.
- **Supported**: Security updates and critical bug fixes only (as required).
- **Limited support**: Online technical help without software updates for fixes, security updates, or features.
- **Not supported**: No more support is available.

> [!NOTE]
>
> - For security updates with third-party dependencies that are only compatible with a later version of DataMiner, it will be necessary to upgrade to this later version.
> - For the oldest supported version (currently 10.2.0), security updates will be published only when and as necessary. There will be no regular updates.

> [!TIP]
> See also [DataMiner Main Release vs. Feature Release](xref:DataMiner_MR_vs_FR).

### Feature Release track

| Version | Supported until |
|---------|-----------------|
| 10.4.x  | 15 Nov 2024     |

For the Feature Release track, monthly upgrades are released with all the latest new features, fixes, and security updates. Only the latest Feature Release version is supported.

> [!NOTE]
> If you are following the Feature Release track, you always need to upgrade to the latest version to get the latest security updates. If you do not want to upgrade to a new Feature Release version but do want to get the latest security updates, you will need to switch to the Main Release track instead.

> [!TIP]
> See also [DataMiner Main Release vs. Feature Release](xref:DataMiner_MR_vs_FR).

## DataMiner functionality evolution and retirement

Important announcements about the latest changes to DataMiner core functionality and behavior.

| Item | <div style="width: 150px;">Current status</div> | Detail | Future status |
|---------|---------|---------|---------|
| Asset Manager | End of Engineering | Module is being retired. | End of Life to be confirmed |
| Legacy Correlation Engine | End of Engineering | Module is being retired. Note that this only applies to the legacy System Display Correlation engine | End of Life as of DataMiner version 10.5.x (Q4 2024) |
| Jobs app | End of Engineering | Module is being retired. | End of Life as of DataMiner version 10.5.x (Q4 2024) |
| Ticketing app | End of Engineering | Skyline is researching a replacement for this module. | End of Life to be confirmed |
| Annotations | End of Life | From DataMiner version 10.3.x (Q4 2022) onwards, Annotations should no longer be used. | End of Life |
| Legacy Reporter & Dashboards | End of Support | Module is being retired and replaced with the new DataMiner Dashboards app. | End of Life as of DataMiner version 10.4.x (Q4 2023) |
|  Web Services API v0 | End of Life | From DataMiner version 10.1.5 onwards, version 0 of the DataMiner Web Services API is disabled. Users will be required to port any reliant applications to use Web Services API v1. | End of Life |
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
| Support for MSSQL as local database | End of Life as of DataMiner 10.3 (Q4 2022) | Feature will no longer be supported. We recommend moving to Storage as a Service or Cassandra. | End of Life as of DataMiner version 10.3.x (Q4 2022) |
| Support for MySQL as local database | End of Support as of DataMiner 10.3 (Q4 2022) | Existing features will work, but some new features will require Storage as a Service or Cassandra and OpenSearch/Elasticsearch. | End of Life to be confirmed. |
| Support for Cassandra database on Windows OS | End of Support as of Cassandra 4.x (Q3 2021) | Cassandra no longer supports Windows as its operating system from version 4.x onwards. Up to DataMiner 10.4.x, support is provided for Cassandra databases on Windows up to Cassandra version 3.11. We recommend moving to a Linux system, using [Ubuntu LTS](https://catalog.dataminer.services/details/package/5621). | |
| Support for Amazon Keyspaces Service, Azure Managed Instance for Apache Cassandra Service, and Amazon OpenSearch Service | End of Support as of DataMiner 10.3.0 [CU8]/10.3.11 | Feature will no longer be supported. We recommend moving to Storage as a Service. Note that using a self-hosted OpenSearch database remains supported. |   |
| Support for DataMiner Cube running in Internet Explorer/Edge in IE compatibility mode (XBAP) | End of Engineering | Existing features will work, but some new features will only be supported in the DataMiner Cube desktop app. | End of Life as of DataMiner version 10.3.x (Q4 2022) |
| Support for Visual Studio 2015 | End of Life as of DIS 2.35 | DIS will no longer be compatible with this Visual Studio version. |   |
| Support for Visual Studio 2017 | End of Life as of DIS 2.41 | DIS will no longer be compatible with this Visual Studio version. |   |
| Support for Visual Studio 2019 | End of Life as of DIS 3.0 | DIS will no longer be compatible with this Visual Studio version. |   |

Status overview:

- **End of Engineering**: Feature will no longer be updated, but will still be supported.
- **End of Support**: Feature will no longer be updated and no longer be supported.
- **End of Life**: Feature or compatibility will be removed.

> [!NOTE]
> For all supported DataMiner versions, we support all Windows versions that Microsoft currently supports.
