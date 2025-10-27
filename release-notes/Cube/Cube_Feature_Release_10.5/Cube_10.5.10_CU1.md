---
uid: Cube_Feature_Release_10.5.10_CU1
---

# DataMiner Cube Feature Release 10.5.10 CU1

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.4.0 [CU20] and 10.5.0 [CU8].

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.10](xref:General_Feature_Release_10.5.10).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.10](xref:Web_apps_Feature_Release_10.5.10).

### Fixes

#### Trend graphs would incorrectly show a flatline when client and DMA used different time zones [ID 43757]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.10 [CU1] -->

When the client's time zone was ahead of the DMA's time zone, up to now, trend graphs would incorrectly show a flatline for the hours covered by the time zone difference. That flatline would typically start at now minus 24 hours and continue for the duration of the time zone offset.
