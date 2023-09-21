---
uid: Cube_Main_Release_10.3.0_CU5
---

# DataMiner Cube Main Release 10.3.0 CU5

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Main Release 10.3.0 CU5](xref:General_Main_Release_10.3.0_CU5).

### Enhancements

#### Visual Overview: External connectivity updates for dynamically positioned shapes will now be applied in real time [ID_36333]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

Up to now, external connectivity updates for dynamically positioned shapes would not be applied in real time. To see the changes, you had to close the visual overview and open it again. From now on, any external connectivity updates for dynamically positioned shapes will immediately be visible.

#### Visual Overview: TextWrapping should now default to the correct value "Wrap" [ID_36363]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

When a shape did not have a *TextStyle* shape data field, up to now, the *TextWrapping* option would automatically be set to "WrapWithOverflow". From now on, when a shape does not have a *TextStyle* shape data field, the *TextWrapping* option will automatically be set to "Wrap" instead.

Also, because of a number of enhancements, overall performance has increased when rendering shapes without a *TextStyle* shape data field.

#### DataMiner Cube - Alarm Console: Enhanced retrieval of history alarms [ID_36653]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

Up to now, when you requested the alarms of a certain time span, Cube would always send two requests to the server: one for the alarms and one for the information/suggestion events. However, in many cases, this was not necessary. From now on, Cube will only send the requests that are necessary.

### Fixes

#### Visual Overview: Problem with element or view scope of Children shapes [ID_36354]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

In some cases, when a placeholder was used in the *Element* or *View* shape data field of a *Children* shape, the scope would not be updated when changes were made to the placeholder.

From now on, the scope will be updated correctly whenever changes are made to the placeholder in the *Element* or *View* shape data field.

#### Workspaces: Problem opening cards that showed a visual overview [ID_36438]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When you opened a workspace in which one or more cards showed a page with a visual overview, in some cases, the visual overview would be empty.

#### System Center: Problem with 'Show agent alarms' link [ID_36463]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When you selected an agent in the *Agents* section of *System Center*, in some cases, the alarm numbers shown in the *Show agent alarms* link would not be correct.

Also, when you clicked that *Show agent alarms* link, the alarm tab listing the alarms of the selected agent would incorrectly be empty.

#### Alarm Console: Problem when opening a history tab [ID_36603]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

When, in the Alarm Console, you opened a history tab on a system with a large number of masked alarms and a number of active correlation rules, that history tab would load rather slowly and would be missing some alarms.

#### Trending: Problem when exporting real-time trend data to a CSV file [ID_36630]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

When you exported more than a week's worth of real-time trend data to a CSV file, only the trend data of the last week (i.e. "week to date") would be exported.

#### Settings: Suggestion tab added to a group setting would not show any suggestion alarms [ID_36666]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When, in the *Settings* window, you added a suggestion tab to a group setting for the Alarm Console, users who were a member of that group would see the suggestion tab, but it would not show any suggestion alarms.

#### Problem when removing DCF connections [ID_36676]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When you removed a connection between an active element and an element that was stopped/paused, the connection would be removed from the active element but not from the stopped/paused element. When you started that element again and tried to remove the connection, the action would fail.

#### DataMiner Cube - Alarm Console: Problem with alarm tabs of type 'sliding window' [ID_36687]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When you opened an alarm tab of type "sliding window", the history alarms matching the sliding window would be retrieved from the server but DataMiner Cube would incorrectly not show them.
