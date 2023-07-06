---
uid: Web_apps_Feature_Release_10.3.9
---

# DataMiner web apps Feature Release 10.3.9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.9](xref:General_Feature_Release_10.3.9).

## Highlights

#### Dashboards app & Low-Code Apps: Button panel visualization now officially released [ID_36775]

<!-- MR 10.4.0 - FR 10.3.9 -->

The button panel visualization has now officially been released. This component will display a button panel with buttons representing the rows of a table parameter. Using an element with a custom button panel protocol, you can configure what kind of buttons are displayed and how the buttons are displayed.

The following types of buttons can be configured:

- Simple buttons used only to set parameters.
- HTML buttons.
- Rotate buttons, resembling a control dial, used to decrement or increment the value of a particular parameter. The buttons can be used by dragging and dropping with the mouse, by using the arrow keys on the keyboard, or by sliding on a mobile device.

For more information, see [Button panel](xref:DashboardButtonPanel).

## Other features

#### GQI: Ad hoc data sources can now include columns of type GQITimeSpanColumn [ID_36717]

<!-- MR 10.4.0 - FR 10.3.9 -->

Ad hoc data sources can now include columns of type `GQITimeSpanColumn`. These columns can contain a time span and can have operators applied to them.

## Changes

### Enhancements

#### Dashboards app: Enhanced mechanism to update the list of dashboards in the navigation pane [ID_36604]

<!-- MR 10.4.0 - FR 10.3.9 -->

Up to now, the list of dashboards displayed in the navigation pane on the left would be updated every 5 seconds via a polling mechanism. From now on, whenever that list is changed, all connected clients will receive an event that will update the list.

#### Monitoring app: A new type of text area boxes will now be used on parameter pages [ID_36693]

<!-- MR 10.4.0 - FR 10.3.9 -->

In the *Monitoring* app, a new type of text area boxes will now be used on parameter pages.

#### Dashboards app - GQI: Version column added to 'Get trend data patterns' and 'Get trend data pattern events' data sources [ID_36754]

<!-- MR 10.4.0 - FR 10.3.9 -->
<!-- Not added to MR 10.4.0  -->

The *Get trend data patterns* and *Get trend data pattern events* data sources now have a *Version* column containing the pattern version.

Each time the time range of a pattern gets updated, a new pattern record is created with a new pattern version.

### Fixes

#### Dashboards app: Black boxes on top of first or last field of selection boxes on small screens [ID_36738]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When you reduced the screen size to the point at which the navigation pane got hidden, a black box would incorrectly appear on top of the first or last field of a selection box.

#### Dashboards app & Low-Code Apps: Table component would show skeleton loading when refetching data with external column filters applied [ID_36743]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

A table component would show skeleton loading when it refetched data with external column filters applied. From now on, a table component will only show skeleton loading during the initial fetch.

#### Low-Code Apps: Creating an app with an existing name would incorrectly be possible [ID_36744]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

Up to now, it would incorrectly be possible to create a low-code app with a name that was identical to that of an existing app.

From now on, when you try to create an app with a name that is identical to that of an existing app, an error will be thrown.

#### Dashboards app: 'UpdateDashboard' call was sent twice when deleting a component [ID_36766]

<!-- MR 10.4.0 - FR 10.3.9 -->

When you deleted a component from a dashboard, an `UpdateDashboard` call would incorrectly be sent twice.

#### Dashboards app: Problem when clicking 'Start with a blank dashboard' [ID_36798]

<!-- MR 10.4.0 - FR 10.3.9 -->

When you clicked *Start with a blank dashboard* twice in rapid succession, two pop-up windows would open.
