---
uid: Web_apps_Feature_Release_10.6.2_CU1
---

# DataMiner web apps Feature Release 10.6.2 CU1

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.5.0 [CU11].

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.2](xref:General_Feature_Release_10.6.2).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.2](xref:Cube_Feature_Release_10.6.2).

## Changes

### Fixes

#### GQI DxM and Web DcM could stop working during startup [ID 44642]

<!-- MR TBD - FR 10.6.2 [CU1] -->

In some rare cases, the GQI DxM and the Web DcM could stop working during startup.

#### Web module of which only the revision number was different would incorrectly be installed alongside the existing version [ID 44690]

<!-- MR 10.5.0 [CU11] / 10.6.0 [CU1] - FR 10.6.2 [CU1] -->

When you installed a newer version of a DataMiner web module (i.e. a DcM or DxM module) of which only the revision number (*Major.Minor.Build.Revision*) was different from the version that was installed, up to now, the installer would incorrectly install the new version alongside the existing version.

From now on, when you install a newer version of a DataMiner web module of which only the revision number is different from the version that is installed, the installer will first uninstall the existing version, and will then install the new version. That way, only a single version of a DataMiner web module will be installed at any given time.
