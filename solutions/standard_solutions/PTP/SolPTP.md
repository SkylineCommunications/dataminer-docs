---
uid: SolPTP
description: "Monitor PTP domains, track grandmaster, boundary, transparent, and follower clocks, and analyze timing stability, using DataMiner PTP."
---

# PTP

DataMiner PTP allows you to monitor a Precision Time Protocol (PTP) infrastructure in real time. It provides a complete overview of all PTP nodes and their roles, constantly monitors critical PTP metrics and synchronization statistics of grandmaster clocks, boundary clocks, transparent clocks, and follower clocks, and allows you to quickly identify any change or degradation in the timing environment.

PTP (Precision Time Protocol, IEEE 1588) is the standard protocol used by broadcasters, media network operators, and service providers to synchronize device clocks across packet-based networks to achieve accurately synchronized video, audio, and metadata streams.

> [!TIP]
> See also: [DataMiner Precision Time Protocol (PTP) App](https://www.youtube.com/watch?v=eamFLwSvtDE) ![Video](~/dataminer/images/video_Duo.png)

## Versions and architecture

DataMiner PTP has evolved across three generations:

- **From version 2.0.0 onwards**, a [dedicated custom PTP app](xref:Overview_of_the_PTP_custom_app) (*PTP Monitor*) is available, accessible via browser. This version introduces in-connector mediation within the *Skyline PTP* connector (retiring the legacy *Standard DataMiner PTP Device* mediation protocol) and provides interactive topology layouts, real-time node comparison, and embedded administrative wizards for domain and role management.

- **Version 1.2.0** provides a [PTP low-code app](xref:Overview_of_the_PTP_LCA_UI) running in your browser, driven by Generic Query Interface (GQI) ad hoc data sources for real-time telemetry.

- **Older versions** use a [Visual Overview PTP app](xref:Overview_of_the_PTP_app_in_Cube_UI) integrated directly in DataMiner Cube, utilizing Microsoft Visio designs and automation scripts.
