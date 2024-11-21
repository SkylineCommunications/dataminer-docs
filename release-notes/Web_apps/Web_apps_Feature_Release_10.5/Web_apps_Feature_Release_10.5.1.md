---
uid: Web_apps_Feature_Release_10.5.1
---

# DataMiner web apps Feature Release 10.5.1 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.5.1](xref:General_Feature_Release_10.5.1).

## Highlights

*No highlights have been selected yet.*

## New features

#### Low-Code Apps: New 'Set variable' action [ID 41253]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

It is now possible to configure *Set variable* actions.

This type of action will allow users to set the current value of any variable that is not read-only to either a static value or a value available elsewhere in the low-code app.

> [!NOTE]
> Variables of type *Table* can only be set to a static value.

#### Low-Code Apps: New 'Add row' and 'Clear table' actions [ID 41324]

<!-- MR 10.4.0 [CU10] - FR 10.5.1 -->

It is now possible to configure the following actions:

| Action | Function |
|--------|----------|
| Add row     | Adds a row to a variable of type *Table*. |
| Clear table | Clears all rows defined in a variable of type *Table*. |

#### Dashboards/Low-Code Apps - Numeric input/Search input/Text input components : Default value [ID 41401]

<!-- MR 10.4.0 [CU10] - FR 10.5.1 -->

The *Numeric input*, *Search input* and *Text input* components now allow you to specify a default value.

To do so, in edit mode, select the component, go to *Settings > General > Default value*, and enter a value.

## Changes

### Enhancements

#### Dashboards app: Enhanced performance [ID 41148]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

Because of a number of enhancements with regard to file operations, overall performance has increased when working with the Dashboards app.

#### Low-Code Apps - Interactive Automation scripts: Redesigned UI components 'TextBox' and 'StaticText' [ID 41188]

<!-- MR 10.4.0 [CU10] - FR 10.5.1 -->

The following UI components have been redesigned:

- `UIBlockType.StaticText`
- `UIBlockType.TextBox`

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new *StaticText* and *TextBox* components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Dashboards/Low-Code Apps: Pickers have been made more consistent [ID 41251]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When you create a variable of type *DOM instance*, you will now have to click *Apply* or *Cancel* after selecting a DOM instance.

In addition, the *Link to* data pickers have now been made more consistent. The *Apply* button has been renamed to *Link*, and will only be clickable when a valid link has been configured. Also, when you edit a link, an *Unlink* button will allow you to remove the link.

#### Web apps: Users will be redirected to the login screen when the connection cannot be restored [ID 41334]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

From now on, when the WebSocket is able to reconnect but the connection itself cannot be restored, users will be redirected to the login screen.

#### Dashboards app & Low-Code Apps: New setting to enable or disable zooming in/out using CTRL+Scroll [ID 41387]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

Since feature version 10.4.9, the following components allow you to zoom in and out using CTRL+Scroll. From now on, this behavior can be enabled or disabled in the *Layout* tab (in the *Node edge graph* and *Service definition* components) or the *Settings* tab (in the other components).

- Line & area chart
- Node edge graph
- Service definition
- Maps
- Visual Overview
- Timeline

By default, this option is disabled, meaning that you do not need to press CTRL when zooming in or out.

### Fixes

#### Dashboards/Low-Code Apps: Labels of lazy-loaded data would incorrectly not be displayed in edit mode [ID 41189]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When you were editing a dashboard or a page or a panel of a low-code app, the labels of lazy-loaded data would incorrectly not be displayed.

#### Legacy Reporter would leak memory when requesting history alarms [ID 41247]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

Up to now, the legacy Reporter (SLASPConnection) would leak memory on every DataMiner Agent in the DMS when requesting history alarms.

#### Dashboards/Low-Code Apps - Alarm table component: Time filter would be disregarded when fetching history alarms [ID 41249]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When an *Alarm table* component was configured to retrieve history alarms, it would incorrectly always retrieve all history alarms from the database, regardless of what was specified in the time filter.

#### Dashboards/Low-Code Apps: Line & area chart component would incorrectly remain empty until it was resized [ID 41278]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

In some cases, a *Line & area chart* component would incorrectly remain empty until it was resized.

#### Low-Code Apps: Problem when multiple users would continually refresh a page with a number of queries [ID 41316]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When multiple users would open a page containing a number of queries and then continually refreshed the page within a time frame of 5 minutes, in some cases, the following GQI exception could be thrown:

`Maximum amount of concurrent sessions`

To prevent this exception from being thrown, the above-mentioned time frame has now been reduced to 1 minute.

#### Dashboards app: Not possible to generate a PDF report based on a dashboard containing empty components [ID 41317]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

Up to now, it would incorrectly not be possible to generate a PDF report based on a dashboard that contained empty components.

#### Dashboards app - Button component: No pop-up message would appear when clicking a button linked to a parameter for which a warning message had been configured [ID 41344]

<!-- MR 10.4.0 [CU10] - FR 10.5.1 -->

When you clicked the button of a *Button* component linked to a button parameter for which a warning message had been configured in the *protocol.xml* file, no pop-up message would appear.

For more information on how to configure a warning message to be displayed when users change a parameter value, see [Message element](xref:Protocol.Params.Param.Message).

> [!IMPORTANT]
> In the Dashboards app, the *Button* component is available in soft launch, if the soft-launch option *ReportsAndDashboardsButton* is enabled.

#### Dashboards app: Variables and flows eligible to be dropped as data, filter or group would incorrectly not be highlighted in the 'Data' pane [ID 41367]

<!-- MR 10.4.0 [CU10] - FR 10.5.1 -->

When, while editing a dashboard, you clicked a component's *Data*, *Filter* or *Group* button, variables and flows eligible to be dropped as data, filter or group would incorrectly not be highlighted in the *Data* pane.
