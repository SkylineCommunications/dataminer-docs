---
uid: Software_support_life_cycles
---

# Software support life cycles

## DataMiner support life cycle policy

| Version | New features until | Regular updates until | Supported until | Limited support until | Not supported from |
|---------|--------------------|-----------------------|-----------------|-----------------------|--------------------|
| 10.4.x  | 15 Nov 2024        | 21 Nov 2025           | 26 Feb 2027     | 25 Feb 2028           | 25 Feb 2028        |
| 10.3.x  | 17 Nov 2023        | 15 Nov 2024           | 27 Feb 2026     | 26 Feb 2027           | 26 Feb 2027        |
| 10.2.x  | 18 Nov 2022        | 24 Nov 2023           | 28 Feb 2025     | 27 Feb 2026           | 27 Feb 2026        |
| 10.1.x  | -                  | 18 Nov 2022           | 23 Feb 2024     | 28 Feb 2025           | 28 Feb 2025        |
| 10.0.x  | -                  | 17 Dec 2021           | 24 Feb 2023     | 23 Feb 2024           | 23 Feb 2024        |
| 9.6.x   | -                  | -                     | 25 Feb 2022     | 24 Feb 2023           | 24 Feb 2023        |

Legend:

- **New features**: Monthly feature release track with all the latest new features, fixes, and security updates (main release cumulative updates also available without new features as part of main release track).
- **Regular updates**: Monthly cumulative updates containing all fixes and security updates as part of main release track.
- **Supported**: Security updates and critical bug fixes only (as required).
- **Limited support**: Online technical help without software updates for fixes, security updates or features.
- **Not supported**: No more support is available.

> [!TIP]
> See also [DataMiner Main Release vs. Feature Release](xref:DataMiner_MR_vs_FR).

## DataMiner functionality evolution and retirement

Important announcements about the latest changes to DataMiner core functionality and behavior.

| Item | <div style="width: 150px;">Current status</div> | Detail | Future status |
|---------|---------|---------|---------|
| Jobs app | End of Engineering | Module is being retired. | End of Life to be confirmed |
| Ticketing app | End of Engineering | Module is being retired. | End of Life to be confirmed |
| Annotations | End of Life | From DataMiner version 10.3.x (Q4 2022) onwards, Annotations should no longer be used. | End of Life |
| Legacy Reporter & Dashboards | End of Support | Module is being retired and replaced with the new DataMiner Dashboards app. | End of Life as of DataMiner version 10.4.x (Q4 2023) |
|  Web Services API v0 | End of Life | From DataMiner version 10.1.5 onwards, version 0 of the DataMiner Web Services API is disabled. Users will be required to port any reliant applications to use Web Services API v1. | End of Life |

Status overview:

- **End of Engineering**: Feature will no longer be updated, but will still be supported.
- **End of Support**: Feature will no longer be updated and no longer be supported.
- **End of Life**: Feature or compatibility will be removed.

> [!NOTE]
> For information about functionality in soft launch that is retired, refer to [Overview of soft-launch options](xref:Overview_of_Soft_Launch_Options).

## Third-party software support life cycle

| Item | Current status | Detail | Future status |
|---------|---------|---------|---------|
| Support for MSSQL as local database | End of Life as of DataMiner 10.3 (Q4 2022) | Feature will no longer be supported. We recommend moving to Cassandra. | End of Life as of DataMiner version 10.3.x (Q4 2022) |
| Support for MySQL as local database | End of Support as of DataMiner 10.3 (Q4 2022) | Existing features will work, but some new features will require Cassandra or Elasticsearch as necessary. | End of Life as of DataMiner version 10.4.x (Q4 2023) |
| Support for DataMiner Cube running in Internet Explorer/Edge in IE compatibility mode (XBAP) | End of Engineering | Existing features will work, but some new features will only be supported in the DataMiner Cube desktop app. | End of Life as of DataMiner version 10.3.x (Q4 2022) |
| Support for Visual Studio 2015 | End of Life as of DIS 2.35 | DIS will no longer be compatible with this Visual Studio version. |   |

Status overview:

- **End of Engineering**: Feature will no longer be updated, but will still be supported.
- **End of Support**: Feature will no longer be updated and no longer be supported.
- **End of Life**: Feature or compatibility will be removed.
