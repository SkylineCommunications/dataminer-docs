---
uid: Cube_Feature_Release_10.4.7
---

# DataMiner Cube Feature Release 10.4.7

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.4.7](xref:General_Feature_Release_10.4.7).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.7](xref:Web_apps_Feature_Release_10.4.7).

## Changes

### Enhancements

#### Update Center: DCP user authentication replaced by Azure B2C authentication [ID 39466]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

When, in the *Update Center* window, you clicked *Check for updates*, up to now, Cube would use DCP user authentication to authenticate you. From now on, Cube will use Azure B2C authentication instead.

#### Visual Overview: Enhanced performance when loading shapes containing ParametersSummary data fields [ID 39477]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

Because of a number of enhancements, overall performance has increased when loading shapes containing *ParametersSummary* data fields.

### Fixes

#### Alarm Console: Undocked alarm card would not indicate which view was selected [ID 39494]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

When you undocked an alarm tab or you opened the *Alarms* tab of a card, it would not be possible to see whether the list view, the statistical view or the reports view was selected. From now on, the selected view will be indicated clearly.

#### Visual Overview: Load time metric could be incorrect when a visual overview page was opened while Cube was still loading [ID 39588]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

When Cube was still loading when a visual overview page was opened, in some cases, the visual overview load time metric would be incorrect. From now on, when Cube is still loading when a visual overview page is opened, the load time metric will be disregarded.

#### Login screen would remain stuck at 'Logging on...' when remote access to DataMiner Cube was disabled in admin.dataminer.services [ID 39590]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

When, in <https://admin.dataminer.services/>, remote access to DataMiner Cube was disabled, Cube's login screen would remain stuck at *Logging on...* indefinitely. From now on, when remote access to DataMiner Cube is disabled, Cube's login screen will show an `APIGateway is unavailable` message instead.

Also, it would no longer be possible to access the *About* window and the logging window by clicking the bottom-right cogwheel button on Cube's login screen. This has now also been fixed.
