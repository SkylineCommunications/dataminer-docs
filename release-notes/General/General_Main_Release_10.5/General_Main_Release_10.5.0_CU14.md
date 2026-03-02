---
uid: General_Main_Release_10.5.0_CU14
---

# General Main Release 10.5.0 CU14 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU14](xref:Cube_Main_Release_10.5.0_CU14).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU14](xref:Web_apps_Main_Release_10.5.0_CU14).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Changes

### Enhancements

*No enhancements have been added yet.*

#### Problem when a component in a dashboard or low-code app was unable to retrieve data from a remote DataMiner Agent [ID 44848]

<!-- MR 10.5.0 [CU14]/10.6.0 [CU2] - FR 10.6.4 -->

Up to now, when a component in a dashboard or low-code app was unable to retrieve data from a remote DataMiner Agent (for example because that Agent was unavailable), an error would be thrown inside the UI of that dashboard or low-code app.

From now on, when a component in a dashboard or low-code app is not able to retrieve data from a remote DataMiner Agent, a "Nothing to show" message will appear in that component instead.
