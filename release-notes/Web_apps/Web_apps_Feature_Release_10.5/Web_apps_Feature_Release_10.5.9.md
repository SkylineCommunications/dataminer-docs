---
uid: Web_apps_Feature_Release_10.5.9
---

# DataMiner web apps Feature Release 10.5.9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.4.0 [CU18] and 10.5.0 [CU6].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.9](xref:General_Feature_Release_10.5.9).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.9](xref:Cube_Feature_Release_10.5.9).

## Highlights

*No highlights have been selected yet.*

## New features

#### Low-Code Apps: Using script output in the post actions of a 'Launch a script' action [ID 43222]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

The output of an Automation script can now be used in the post actions of a *Launch a script* action.

If a referenced key does not exist in the output, it will by default return an empty string.

Actions will now be numbered hierarchically to allow easier referencing when linking output data. See the example below.

- 1

  - 1.1

    - 1.1.1

  - 1.2

    - 1.2.1
    - 1.2.2

      - 1.2.2.1

- 2

#### Low-Code Apps - 'Launching a script' event: New option to disable 'Script started' information events [ID 43245]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When, in a low-code app, you are configuring a *Launching a script* event, it is now possible to indicate that no *Script started* information event should be generated whenever the Automation script is executed.

1. Click the *Show settings* button.
1. Disable the *Generate an information event when launching the script* setting.

By default, this setting will be enabled.

#### Dashboards app & Low-Code Apps - Maps component: Conditional line coloring [ID 43377]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In the *Layout* pane of the *Maps* component, a *Conditional coloring* option has now been added. This will allow you to highlight lines based on a condition.

## Changes

### Enhancements

#### Interactive Automation scripts: Minimum and Maximum properties of the time components will now be considered to be either local time or UTC time [ID 43014]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In time components like e.g. `DateTimePicker` and `TimePicker`, input can be limited by means of the `Minimum` and `Maximum` properties.

Up to now, when the client machine and the server were located in different timezones, the datetime values in those two properties would not always be consistent. From now on, the values in the `Minimum` and `Maximum` properties will be considered to be either local time or UTC time according to the [DateTimeKind](https://learn.microsoft.com/en-us/dotnet/api/system.datetimekind?view=netframework-4.8), specified using [SpecifyKind](https://learn.microsoft.com/en-us/dotnet/api/system.datetime.specifykind?view=netframework-4.8).

`DateTimeKind` can be set to one of the following values:

| Value | Description |
|-------|-------------|
| Undefined | Minimum and Maximum will be used as is, regardless of the client time zone. (former behavior) |
| Local     | Minimum and Maximum will be considered to be the local time of the server. |
| Utc       | Minimum and Maximum will be considered to be UTC time. |

> [!NOTE]
> If, for the `TimePicker` component, you set the `DateTimeKind` of the `Maximum` value to either "Local" or "Utc", the `Maximum` value may roll over to the next day, causing the hour/minute value of the `Maximum` property to be lower than the hour/minute value of the `Minimum` property. Hence, all values will be invalid.

#### DataMiner landing page: Redesigned app sections [ID 43115] [ID 43226] [ID 43261]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

The app sections on the DataMiner landing page (e.g. `https://myDMA/root/`) have been redesigned.

- In the upper section, you will find the native DataMiner apps like Dashboards, Monitoring, and Cube.
- In the lower section, you will find the apps you downloaded from the DataMiner Catalog as well as the low-code apps you create yourself (in different tabs per category).

  Click *Browse catalog* to open the [DataMiner Catalog](https://catalog.dataminer.services/) or *Create your first app* to create your first low-code app.

#### GQI DxM: Support for asynchronous SLNet messages within ad hoc data sources and custom operators [ID 43231]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

When using the GQI DxM, ad hoc data sources and custom operators will now be able to send SLNet messages asynchronously using `connection.Async.Launch()`.

#### Web Services API will now return a custom error page instead of a standard .NET error page [ID 43250]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When the Web Services API received an invalid request, up to now, it would return a standard .NET error page. From now on, it will return a custom error page instead.

#### Web Services API: NATS request timeout increased to 5 minutes [ID 43268]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

The NATS request timeout has been increased from 1 minute to 5 minutes.

Also, when a timeout occurs, the error added to the web logs will now include the message that timed out.

#### GQI DxM will now include invalid session IDs in HeartbeatResponse or CloseSessionResponse messages [ID 43294]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

When a client (e.g. the Web Services API) sent a `HeartbeatRequest` or a `CloseSessionRequest` with invalid session IDs to the GQI DxM, up to now, the GQI DxM would return an error.

From now on, instead of returning an error, the GQI DxM will return a `HeartbeatResponse` or `CloseSessionResponse` that contains the invalid session IDs. This will allows the client to react accordingly without having to parse any error message.

#### Dashboards app & Low-Code Apps - Timeline component: Group order will now be preserved [ID 43296]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

Up to now, the *Timeline* component would try to preserve as much state as possible when refreshing the data (via an action, a trigger component, a change to the data being fed, etc.). This meant that groups that were already present since the previous query would remain in the same spot, relative to each other. This would also be the case if the order in which the new data was returned was different from that of the previous query.

From now on, the order of the rows will be taken into account when determining the position of the timeline groups. In that way, the groups will be sorted according to the data. The position of the items within a group will not change.

#### GQI DxM: Ad hoc data sources and customer operators can now send SLNet messages defined in all assemblies that are officially supported to communicate with SLNet [ID 43299]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

When using the GQI DxM, SLNet messages can be sent via ad hoc data sources or customer operators. However, up to now, sending an SLNet message that was not defined in `SLNetTypes` could fail because the underlying connection worker process did not have a reference to the assembly in which the message is defined.

From now on, the connection worker process has references to all assemblies that are officially supported to communicate with SLNet (including `SLAnalyticsTypes`). This means that SLNet messages (requests, responses and events) defined in these assemblies can now also be used in ad hoc data sources and customer operators.

#### DataMiner landing page: Redesigned user menu [ID 43303]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

The user menu in the header bar of the DataMiner landing page (e.g. `https://myDMA/root/`) has been redesigned.

#### DataMiner landing page: Theme selection [ID 43332]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

On the DataMiner landing page (e.g. `https://myDMA/root/`), you can now select one of the following themes:

- Light (i.e. the default theme)
- Dark
- System (i.e. the theme set in the browser)

Currently, the theme selector is only available when you add the following argument to the URL of the landing page:

`?showAdvancedSettings=true`

#### DataMiner landing page: DataMiner icon in header bar will now show the name of the DMS instead of the URL of the landing page [ID 43341]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In the header bar of the DataMiner landing page (e.g. `https://myDMA/root/`), the DataMiner icon on the left will now show the name of the DMS* instead of the URL of the landing page.

\**If not applicable, the DataMiner icon will show the name of the DMA instead.*

#### Web apps: Enhanced performance when starting a web app [ID 43364]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

Because of a number of enhancements, overall performance has increased when starting a web app.

For example, information that does not frequently change (e.g. alarm colors) will now be cached in the web API. It will no longer be fetched each time a web app is opened.

#### Web API will no longer send any heartbeats to the GQI DxM to keep invalid GQI sessions alive [ID 43374]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

From now on, when a GQI session is marked as invalid by the GQI DxM, the web API will no longer send any heartbeats to the GQI DxM in order to keep that session alive.

### Fixes

#### Dashboards app & Low-Code Apps - Timeline component: Group label tooltips missing [ID 43242]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When, in a *Timeline* component, you had grouped on multiple columns, only the labels of the bottom-level group would have a tooltip.

From now on, all group labels will have a tooltip.

#### Low-Code Apps: Actions on open panels would stop working when you switched from one page to another [ID 43256]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When you switched from one page to another, up to now, actions on open panels would stop working.

#### Dashboards app & Low-Code Apps - Table component: Run-time error could appear when multiple queries had been configured [ID 43262]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When, in a *Table* component with multiple queries, you rapidly switched between the different queries or generated a PDF, in some cases, the following run-time error could appear instead of the actual table data:

`Cannot read properties of undefined (reading "Value")`

#### Low-Code Apps - Interactive Automation script component: Input box values would not be updated correctly [ID 43282]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When the redesigned UI components were used in an Interactive Automation script component, in some cases, input box values would not be updated correctly, especially when a negative value was changed into a positive value.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Low-Code Apps: Problem when two tables with the same query fed the selected row to the same form [ID 43317]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When two tables with the same query fed the selected row to the same form, up to now, when you had entered some data into the form after selecting a row in the first table, the fields in that form would incorrectly be refetched when you selected either a row in the second table or another DOM definition.

#### Low-Code Apps - Interactive Automation script component: Problem with redesigned `UIBlockType.StaticText` component [ID 43337]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

Since DataMiner versions 10.4.0 [CU16]/10.5.0 [CU4]/10.5.7, the redesigned `UIBlockType.StaticText` component would no longer work when its `Text` property had not been set.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### GQI DxM: Persistent system connection would no longer be able to recover when closed [ID 43343]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

When the app settings of the GQI DxM are changed, in some cases, the persistent system connection will reconnect. However, up to now, the reference to that persistent system connection was not updated in the ConnectionManager, causing any subsequent query requests made by the system user to throw an `Attempted to use a closed connection` error. The GQI DxM would always be able to recover by itself though, as it periodically checked whether the connections in the ConnectionManager were still alive.

As, since DataMiner version 10.5.0 [CU5]/10.5.8 [CU0], this connection check is no longer performed, the ConnectionManager will now automatically clear the reference to the persistent system connection when it detect that it has been closed, and will, when a new query request arrives, either retrieve the new persistent system connection reference or trigger a reconnect if no connection exists yet.

#### Dashboards app: Some changes to a dashboard would no longer be saved after cancelling the generation of a PDF report [ID 43358]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When you cancelled the generation of a PDF report by closing the preview window, and then entered edit mode, up to now, some changes made to the dashboard in question would incorrectly no longer be saved.

#### Dashboards app: Problem when sharing a dashboard [ID 43367]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

In some cases, an NullReference exception could be thrown when you shared a dashboard.
