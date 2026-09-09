---
uid: SolPTP
description: Explore the DataMiner PTP solution to monitor PTP domains, track grandmaster, boundary, transparent, and follower clocks, and analyze timing stability.
---

# PTP app

The DataMiner PTP solution allows you to monitor a Precision Time Protocol (PTP) infrastructure in real time. It provides a complete overview of all PTP nodes and their roles, constantly monitors critical PTP metrics and synchronization statistics of grandmaster clocks, boundary clocks, transparent clocks, and follower clocks, and allows you to quickly identify any change or degradation in the timing environment.

PTP (Precision Time Protocol, IEEE 1588) is the standard protocol used by broadcasters, media network operators, and service providers to synchronize device clocks across packet-based networks to achieve accurately synchronized video, audio, and metadata streams.

## Architecture and versions

The DataMiner PTP solution has evolved across three generations:

- **From version 2.0.0 onwards**: A dedicated custom DataMiner web application (*PTP Monitor*) accessible via browser at `/public/ptp/`. This version introduces in-connector mediation within the *Skyline PTP* connector (retiring the legacy *Standard DataMiner PTP Device* mediation protocol), provides interactive topology layouts, real-time node comparison, and embedded administrative wizards for domain and role management. For more information, see [The PTP custom app](xref:Overview_of_the_PTP_custom_app).
- **From version 1.2.0 onwards**: A DataMiner low-code app running in the browser, driven by Generic Query Interface (GQI) ad hoc data sources for real-time telemetry. For more information, see [The PTP low-code app](xref:Overview_of_the_PTP_LCA_UI).
- **Prior to version 1.2.0**: A visual overview app integrated directly into DataMiner Cube, utilizing Microsoft Visio designs and automation scripts. For more information, see [The PTP app in DataMiner Cube](xref:Overview_of_the_PTP_app_in_Cube_UI).

## Prerequisites

Depending on the version of the PTP solution you deploy, the following system requirements apply:

### From PTP 2.0.0 onwards

- DataMiner version 10.6.2 or higher
- DataMiner Web version 10.6.3 CU0 or higher
- [DataMiner GQI DxM](xref:GQI_DxM)
- Storage as a Service (STaaS) or Cassandra storage with an indexing database

### Earlier versions

- From PTP 1.2.0 onwards: DataMiner version 10.5.0 [CU11] or 10.6.2 or higher, along with the [DataMiner GQI DxM](xref:GQI_DxM).
- Prior to PTP 1.2.0: Compatible with standard DataMiner Cube installations supporting visual overviews and Automation scripts.

> [!TIP]
> See also: [DataMiner Precision Time Protocol (PTP) App](https://www.youtube.com/watch?v=eamFLwSvtDE) ![Video](~/dataminer/images/video_Duo.png)
