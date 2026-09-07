---
uid: Cube_Feature_Release_10.6.5_CU1
---

# DataMiner Cube Feature Release 10.6.5 CU1

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.6.0 [CU3].

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.5](xref:General_Feature_Release_10.6.5).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.5](xref:Web_apps_Feature_Release_10.6.5).

## Changes

### Fixes

#### Visual Overview: Problems occurring since changes to UI themes were made in Feature Version 10.6.4 [ID 45283]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.5 [CU1] -->

Since changes were made to the Cube UI themes in Feature Version 10.6.4, a number of theme-related issues could occur:

- When you used the `#FFFFFF=ThemeBackground` option, the background color would incorrectly be dark gray instead of white.
- When a visual overview contained tabs, it was difficult to determine which tab was the active one.
- Certain images added to the visual overview would not be visible.
