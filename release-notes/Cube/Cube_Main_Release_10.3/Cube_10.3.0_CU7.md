---
uid: Cube_Main_Release_10.3.0_CU7
---

# DataMiner Cube Main Release 10.3.0 CU7

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Main Release 10.3.0 CU7](xref:General_Main_Release_10.3.0_CU7).

### Fixes

#### Problems when viewing a trend graph of a parameter of type string [ID_36848]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

When you viewed a trend graph of a parameter of type string, the following issues could occur:

- When the trend data switched from real-time trending to average trending while you were panning, in some cases, the graph could flip.
- The Y axis could show empty values.

#### Spectrum monitoring element no longer showed all spectrum monitor parameters [ID_37009]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When you create a spectrum monitor, you can configure custom parameters. These parameters are in fact variables from the spectrum scripts, that are given more user-friendly names.

Normally, when you open a spectrum monitor element, you should be able to view all custom spectrum monitor parameters that have their *Displayed on element card* setting enabled. However, due to an issue, those parameters would no longer all be listed.

#### Visual Overview: Viewport variable also set in code when set by user [ID_37011]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

Up to now, when a user set the *Viewport* variable on a Resource Manager timeline component in Visual Overview, DataMiner set the variable again in the code, which caused the value to change to serialized format. While this did not cause functional changes, it could potentially cause unpredictable behavior, for example in case a condition was configured based on the value of the variable. This will now be prevented.

#### Spectrum Analysis: Preset tab loading indefinitely if no presets defined [ID_37043]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

If no preset was available for a particular spectrum element, it could occur that the *Preset* tab for the spectrum element kept loading indefinitely.
