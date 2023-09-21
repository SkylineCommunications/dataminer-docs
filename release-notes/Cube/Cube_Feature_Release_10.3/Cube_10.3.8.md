---
uid: Cube_Feature_Release_10.3.8
---

# DataMiner Cube Feature Release 10.3.8

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.8](xref:General_Feature_Release_10.3.8).

## Highlights

#### Visual Overview: New BookingData component [ID_33215] [ID_36489]

<!-- MR 10.4.0 - FR 10.3.8 -->

You can now create a special *BookingData* shape and make it display all data associated with a particular booking.

To do so, create a shape with the following shape data fields:

|Shape data field | Value |
|-------------|---------------|
| Component   | `BookingData` |
| Reservation | The ID of the booking<br>Example: `[pagevar:SRMRESERVATIONS_IDOfSelection]` |

A *BookingData* shape will show the following information:

- On the left-hand side, you will find a list of resources used by the booking.

  For every resource, this list shows the following information:
  
  - the resource name
  - an icon indicating the function of the resource
  - an icon indicating whether the resource is linked to a service definition node
  - the node label or, if no node label is defined, the name of the function definition

- On the right-hand side, you see the profile data of the node or node interface you selected in the list on the left:

  - the profile instance (if applicable), and
  - the profile parameter values that will be used (note that these values can be overridden on several levels).
  
  > [!NOTE]
  > Priority of profile parameter value overrides:
  >
  > 1. Values defined in the parameter overrides (stored in the booking)
  > 1. Values defined in the profile instance
  > 1. Values defined in the profile definition

To be able to use the *BookingData* component, you will need

- a system with an Elasticsearch database
- a service manager license
- a resource manager license
- the following user permissions:

  - Modules > Bookings > UI Available
  - Modules > Functions > UI Available
  - Modules > Profiles > UI Available
  - Modules > Resources > UI Available
  - Modules > Services > UI Available

#### Trending - Pattern matching: Multivariate trend data patterns [ID_35010] [ID_35301] [ID_36327] [ID_36454] [ID_36628] [ID_36731]

<!-- MR 10.4.0 - FR 10.3.8 -->

Up to now, DataMiner was able to recognize patterns in trend graphs showing trend information for one single parameter. From now on, it is also capable of recognizing patterns in trend graphs showing trend information for multiple parameters.

When you open a trend graph showing trend information for multiple parameters, you can now define a so-called *multivariate trend pattern*.

As with single-parameter patterns (i.e. univariate patterns), a number of options can be specified:

- If you want the patterns to be available for other DataMiner functionality, e.g. to generate suggestion events or via the Generic Query Interface in dashboards or low-code apps, select *Continuously detect patterns in the background*.

- If you want the patterns to be detected for all elements using the protocol instead of the current element only, next to *Apply to*, click the element name and select the protocol instead.

If you are viewing a trend graph that shows trend information for multiple parameters in which multivariate patterns were detected, these will be highlighted in orange when you hover the mouse pointer over the button representing a pattern, or if the option *Expand tags* is selected in the right-click menu. Also, a special icon will indicate that this is a pattern that combines trend information from different parameters. If you click that icon, all trend graphs of all parameters that are part of the pattern will be loaded.

#### Trending: Time-scoped relations [ID_36434]

<!-- MR 10.4.0 - FR 10.3.8 -->

A light bulb icon will now be displayed when you select a time range on the trend graph of a parameter. If you want to know which other parameters are related to this parameter, based purely on the behavior during the selected time range, then you can click this icon to add or view related parameters. Even if multiple curves are displayed on the same trend graph, the light bulb always shows relations with one specific parameter, whose name is mentioned in the light bulb tooltip.

You can for instance use this in case a parameter (e.g. the total available memory of a server) behaves oddly during a particular time range (e.g. a downward spike), in order to find out if other parameters of the same device also showed unusual behavior during the same time range.

For more information, see [Adding time-scoped related parameters to a trend graph](xref:Adding_time_scoped_related_parameters_to_a_trend_graph).

> [!NOTE]
> Currently, the feature only proposes parameters from the same DataMiner element.

## Other new features

#### Open element cards will immediately show any changes made with regard to parameters [ID_36286]

<!-- MR 10.4.0 - FR 10.3.8 -->

When an element card is open, each time a new parameter is added to the element or an existing parameter is updated, the change will be applied in real time. You will no longer need to close the card and open it again to see the changes.

## Changes

### Enhancements

#### Visual Overview: External connectivity updates for dynamically positioned shapes will now be applied in real time [ID_36333]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

Up to now, external connectivity updates for dynamically positioned shapes would not be applied in real time. To see the changes, you had to close the visual overview and open it again. From now on, any external connectivity updates for dynamically positioned shapes will immediately be visible.

#### Visual Overview: TextWrapping should now default to the correct value "Wrap" [ID_36363]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

When a shape did not have a *TextStyle* shape data field, up to now, the *TextWrapping* option would automatically be set to "WrapWithOverflow". From now on, when a shape does not have a *TextStyle* shape data field, the *TextWrapping* option will automatically be set to "Wrap" instead.

Also, because of a number of enhancements, overall performance has increased when rendering shapes without a *TextStyle* shape data field.

#### Visual Overview: Subtract placeholder now also supports numerics [ID_36636]

<!-- MR 10.4.0 - FR 10.3.8 -->

Up to now, the subtract placeholder could be used to calculate datetime and time span values by subtracting one or more values from a specified value. From now on, this placeholder also supports numerics. Just like with datetime values and time spans, you can subtract consecutive numbers from the first number.

Examples:

- Subtracting one number from another: `[Subtract:10,3]`

- Subtracting multiple numbers from the first number: `[Subtract:10.1,3.3,2.6]`

#### DataMiner Cube - Alarm Console: Enhanced retrieval of history alarms [ID_36653]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

Up to now, when you requested the alarms of a certain time span, Cube would always send two requests to the server: one for the alarms and one for the information/suggestion events. However, in many cases, this was not necessary. From now on, Cube will only send the requests that are necessary.

### Fixes

#### Visual Overview: Problem with element or view scope of Children shapes [ID_36354]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

In some cases, when a placeholder was used in the *Element* or *View* shape data field of a *Children* shape, the scope would not be updated when changes were made to the placeholder.

From now on, the scope will be updated correctly whenever changes are made to the placeholder in the *Element* or *View* shape data field.

#### ListView column configuration data could incorrectly get replaced by default values on the Cube client [ID_36420]

<!-- MR 10.4.0 - FR 10.3.8 -->

When you opened a Cube session and connected to a DataMiner System running a version from 9.6.3 onwards that had an SRM license, in some cases, the ListView column configuration data fetched from the server could incorrectly get replaced by default values on the Cube client.

#### DataMiner Cube desktop app: False positive warnings involving a number of DLL files [ID_36424]

<!-- MR 10.4.0 - FR 10.3.8 -->

The log file of the DataMiner Cube desktop app would report false positive warnings involving a number of DLL files.

#### Workspaces: Problem opening cards that showed a visual overview [ID_36438]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When you opened a workspace in which one or more cards showed a page with a visual overview, in some cases, the visual overview would be empty.

#### System Center: Problem with 'Show agent alarms' link [ID_36463]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When you selected an agent in the *Agents* section of *System Center*, in some cases, the alarm numbers shown in the *Show agent alarms* link would not be correct.

Also, when you clicked that *Show agent alarms* link, the alarm tab listing the alarms of the selected agent would incorrectly be empty.

#### Trending: Related parameters returned by the DMA would incorrectly be empty [ID_36511]

<!-- MR 10.4.0 - FR 10.3.8 -->

When you opened a trend graph containing related parameters, in some cases, the related parameters returned by the DataMiner Agent would incorrectly be empty.

#### Visual Overview: Problem when using '[property:]' placeholders in shape data fields of type 'Element' and 'View' [ID_36553]

<!-- MR 10.4.0 - FR 10.3.8 -->

Up to now, when a property was updated, `[property:]` placeholders in shape data fields of type *Element* or *View* would not always get resolved correctly. The only way to ensure a `[property:]` placeholder was resolved correctly after a property update was to close the card and open it again.

Processing of property updates has now been improved. `[property:]` placeholders will now be resolved correctly without having to close the card and open it again.

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
