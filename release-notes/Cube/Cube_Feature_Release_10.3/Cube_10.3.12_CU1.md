---
uid: Cube_Feature_Release_10.3.12_CU1
---

# DataMiner Cube Feature Release 10.3.12 CU1

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.3.12](xref:General_Feature_Release_10.3.12).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.3.12](xref:Web_apps_Feature_Release_10.3.12).

### Fixes

#### Memory leak when closing card showing inline visual overviews [ID 37996]

<!-- MR 10.2.0 [CU21] (not included - SRA)/10.3.0 [CU10] - FR 10.3.12 [CU1] -->

When a card was closed that showed a visual overview with inline visual overviews of other objects, it could occur that subscriptions were left open for those inline visual overview and memory was not freed.
