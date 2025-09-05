---
uid: General_Main_Release_10.4.0_CU20
---

# General Main Release 10.4.0 CU20 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.4.0 CU20](xref:Cube_Main_Release_10.4.0_CU20).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.4.0 CU20](xref:Web_apps_Main_Release_10.4.0_CU20).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### STaaS: Enhanced exception logging [ID 43626]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

A number of enhancements have been made with regard to the logging of exception messages on STaaS systems.

### Fixes

#### Visual Overview in web apps: Problem when reading the load balancing configuration [ID 43660]

<!-- MR 10.4.0 [CU20]/10.5.0 [CU8] - FR 10.5.11 -->

In some cases, it would not be possible to read the load balancing configuration for visual overviews in web apps. As a result, the visual overview module would not be able to start up when load balancing was enabled.
