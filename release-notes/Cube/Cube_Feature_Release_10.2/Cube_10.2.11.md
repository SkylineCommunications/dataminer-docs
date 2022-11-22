---
uid: Cube_Feature_Release_10.2.11
---

# DataMiner Cube Feature Release 10.2.11

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.2.11](xref:General_Feature_Release_10.2.11).

## New features

#### Visual Overview: Retrieving the contributing booking ID of a resource [ID_34306]

<!-- MR 10.3.0 - FR 10.2.11 -->

In Visual Overview, it is now possible to retrieve the contributing booking ID of a resource.

- By specifying the *ContributingBooking* property in the `[Resource:]` placeholder.

    Example: `[Resource:[pagevar:IDOfSelection], ContributingBooking]`

- By specifying the following in a shape that is linked to an element and that has "UseResource=true" set in its *Options* shape data field.

    - A shape data field of type *Info* set to "Contributing Booking" and an asterisk character ("*") in the shape text:

        Example:
        
        | Shape data field | Value |
        |------------------|-------|
        | Element | [pagevar:idofselection] |
        | Options | UseResource=true |
        | Info | Contributing Booking |

        Shape text: `Contributing booking: *`

        ***OR***

    - A `[Contributing Booking]` placeholder in the shape text:

        Example:
        
        | Shape data field | Value |
        |------------------|-------|
        | Element | [pagevar:idofselection] |
        | Options | UseResource=true |

        Shape text: `Contributing booking: [Contributing Booking]`

#### DataMiner Cube - Resources app: Removing resources from all pools [ID_34311]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When you move one or more resources from a pool to the *(uncategorized)* pool, a confirmation box will now appear to warn you that, if you click *Yes*, the resources in question will be removed from all pools.

#### DataMiner Cube - Visual Overview: Enhanced shape positioning [ID_34356]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Because of a number of enhancements, overall performance has increased when setting the X and Y position of a shape.

#### DataMiner Cube - System Center: New DataMiner log file 'SLRADIUS.txt' [ID_34396]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 [CU0] -->

In the *Logging* section of *System Center*, you can now also consult the *SLRADIUS.txt* log file.

#### Visual Overview: Shape data items of type 'NavigatePage' can now have values that include dynamic placeholders [ID_34442]

<!-- MR 10.3.0 - FR 10.2.11 -->

Shape data items of type *NavigatePage* can now have values that include dynamic placeholders referring to session variables, parameters, etc.

#### Visual Overview: New OverridePageName option [ID_34476]

<!-- MR 10.3.0 - FR 10.2.11 -->

From now on, you can override a Visio page name by specifying an "OverridePageName=*NewPageName*" option in a page-level shape data field of type *Options*. When you do so, the page in question will be handled as if its name were *NewPageName*.

> [!NOTE]
>
> - Always use the actual page name when referring to a particular page in options like e.g. *VdxPage*, *NavigatePage*, *InlineVdx*, etc. Using a page override when referring to a page will not work.
> - This feature allows you to define duplicate page names. When you do so, take into account that components that display Visio page names may then also display those duplicate page names.
> - Visio files used in web apps do not support the OverridePageName option.

#### Visual Overview: Shape data items of type 'ParametersSummary' can now have values that include dynamic placeholders referring to session variables [ID_34483]

<!-- MR 10.3.0 - FR 10.2.11 -->

Shape data items of type *ParametersSummary* can now have values that include dynamic placeholders referring to session variables.

## Changes

### Enhancements

#### DataMiner Cube - Service & Resource Management: Function resource icons are now centered in service definition diagrams [ID_34249]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

In service definition diagrams, function resource icons are now centered.

#### Trending - Behavioral anomaly detection: Enhanced flatline detection [ID_34319]

<!-- MR 10.3.0 - FR 10.2.11 -->
<!-- Not added to 10.3.0 -->

A number of enhancements have been made with regard to the detection of change points of type "flatline".

#### DataMiner Cube - Visual Overview: Service context of a linked shape will only be determined when the service context has been specified [ID_34340]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When a shape was linked to an element that was not part of a service, up to now, an attempt would be made to determine the service context even when no service context had been specified. From now on, the service context will only be determined when the service context has been specified in the shape.

#### DataMiner Cube - Visual Overview: Enhanced performance when sorting dynamically positioned shapes [ID_34351]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Because of a number of enhancements, overall performance has increased when sorting dynamically positioned shapes.

#### Trending - Behavioral anomaly detection: Enhanced analysis of anomalous change points [ID_34376]

<!-- MR 10.3.0 - FR 10.2.11 -->

When you enabled alarm monitoring for a specific type of anomaly in an alarm template, since DataMiner feature version 10.2.6, it was assumed that you wished to be alerted to all behavioral changes of that type.

From now on, an automatic anomaly significance check will be performed. Per trended parameter, this check will filter out behavioral changes that cannot be considered anomalous with respect to the history of behavioral changes of the parameter in question. Behavioral changes similar to changes that have occurred regularly or frequently in the historical behavior of a parameter will not be labelled anomalous and will therefore not cause an alarm to be generated when anomaly monitoring is enabled for the parameter and anomaly type in question.

#### DataMiner Cube - Visual Overview: Caching of user settings in order to enhanced performance [ID_34383]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

In Visual Overview, the current value of the following user settings will now be cached in order to enhance performance:

- *Open element cards undocked* (*Settings* window)
- *AlarmSettings.Blinking* (*MaintenanceSettings.xml* file)

#### DataMiner Cube - Visual Overview: Enhanced performance when determining whether a shape is clickable [ID_34386]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

A number of enhancements have been made to the procedure called to determine whether a shape is clickable.

#### Visual Overview: Enhanced performance when drawing connection lines [ID_34409]

<!-- MR 10.3.0 - FR 10.2.11 -->

Because of a number of enhancements, overall performance has increased when drawing connection lines on a visual overview.

#### Alarm Console: Enhanced clearing of behavioral anomaly alarms [ID_34427]

<!-- MR 10.3.0 - FR 10.2.11 -->

Suggestion events and alarm events will now automatically be cleared sooner than 2 hours after their creation or last update when a new behavioral change is detected that ends the previous anomalous behavioral change.

For example, when an alarm was created for an anomalous level increase at 1 PM, and a behavioral change point is detected at 2 PM when the level drops again, then the alarm created at 1 PM will be closed at 2 PM.

#### Trending - Behavioral anomaly detection: Suggestion events will only be created for the most significant changes [ID_34513]

<!-- MR 10.3.0 - FR 10.2.11 -->

Prior to DataMiner 10.2.11/10.3.0, suggestion events are created for all anomalous behavioral changes that do not have alarm monitoring enabled. From DataMiner 10.2.11/10.3.0 onwards, they are only created for the most significant changes. There is also a maximum of 500 suggestion events related to behavioral anomaly detection at the same time.

### Fixes

#### DataMiner Cube - Visual Overview: Problem with conditional shape manipulation actions 'Show' and 'Hide' [ID_34108]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When, in a particular shape, you had specified a *Show* or *Hide* action with a condition, the shape would incorrectly always be visible, whether the condition was true or false.

#### DataMiner Cube - Trending: Y axis would incorrectly show other values when the trend graph showed a constant exception value [ID_34242]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When you opened a trend graph that only showed a constant exception value, the Y axis would incorrectly not only show the exception value but also a number of other values. In cases like this, from now on, the Y axis will only show the exception value.

#### DataMiner Cube - Trending: Y-axis values did not take into account the number of decimals configured in the protocol.xml file [ID_34269]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When you opened a trend graph, the Y-axis values would incorrectly not take into account the number of decimals configured in the *protocol.xml* file for the parameters in question.

#### DataMiner Cube - Alarm Console: Negative counters in the footer bar [ID_34318]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

On systems with active correlation rules, in some rare cases, the counters in the footer bar of the Alarm Console could show negative numbers.

#### DataMiner Cube - EPM: Not possible to add a second parameter to a trend graph of an EPM object [ID_34323]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When you opened a trend graph of an EPM object, it would not be possible to add a second parameter. After you had added a new parameter, the drop-down box would incorrectly only contain the current parameter.

#### DataMiner Cube - Booking app: Booking updates would cause the UI to flicker [ID_34349]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

When one of the listed bookings was updated, all bookings would incorrectly be re-rendered, causing the UI to flicker.

#### DataMiner Cube - Spectrum analysis: Preset would not be loaded when clicking 'View buffer' [ID_34357]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When, in a Spectrum card, you clicked *View buffer*, the preset contained inside the buffer would incorrectly not be loaded. As a result, incorrect threshold values would be displayed.

#### DataMiner Cube - Visual Overview: Problem when receiving a DCF connection line update [ID_34375]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

An error could occur when the client received a DCF connection line update.

#### DataMiner Cube - Visual Overview: Problem when the Parameter shape data field of a range slider control contained a dynamic placeholder referring to a session variable [ID_34389]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When the shape data field *Parameter* of a range slider control contained a dynamic placeholder referring to a session variable, it would no longer be possible to move the slider when the value of the session variable changed from valid to invalid or vice versa.

#### DataMiner Cube - Visual Overview: Fix multiple script executions on page shape data change [ID_34412]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When, on page level, you had configured a data field of type *Execute* containing multiple *Set* actions with placeholders as well as a *Script* action, the script would incorrectly get executed multiple times when the page was opened.

#### DataMiner Cube - Alarm Console: Problem when loading an alarm tab with hyperlink columns [ID_34420]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

In some cases, DataMiner Cube could become unresponsive when loading an alarm tab with hyperlink columns, especially when that alarm tab contained a large number of alarms.

#### DataMiner Cube: EPM diagrams would incorrectly get mixed up when selecting a formerly selected field in an EPM filter box [ID_34431]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When, in an EPM filter box, you selected a field, selected another field, and then selected the first field again, in some cases, the diagrams linked to those two fields would incorrectly get mixed up.

#### DataMiner Cube - Alarm Console : Problem when loading an alarm tab [ID_34539]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

When a new alarm tab with a large number of correlated alarms was being loaded, in some cases, an exception could be thrown and the alarm tab would keep on loading.
