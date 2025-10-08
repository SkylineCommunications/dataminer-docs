---
uid: Cube_Feature_Release_10.5.4
---

# DataMiner Cube Feature Release 10.5.4

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.4.0 [CU13] and 10.5.0 [CU1].

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.4](xref:General_Feature_Release_10.5.4).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.4](xref:Web_apps_Feature_Release_10.5.4).

## Highlights

- [Elements can now be configured to run in isolation mode [ID 41758]](#elements-can-now-be-configured-to-run-in-isolation-mode-id-41758)
- [Legacy InterClient feature has been removed [ID 42263]](#legacy-interclient-feature-has-been-removed-id-42263)

## New features

#### DataMiner Cube desktop app: Splash screen [ID 41680]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

At start-up, the DataMiner Cube desktop app will now show a splash screen when the URL does not include any arguments except possibly `/Hostname` and `/Display`.

#### Elements can now be configured to run in isolation mode [ID 41758]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When you are editing an element, you can now indicate that it should run in isolation mode, i.e. in its own SLProtocol and SLScripting process.

To do so, go to *Advanced element settings*, and select the *Run in isolation mode* option.

When, in either the *protocol.xml* file or the *DataMiner.xml* file, the element in question is forced to run in isolation mode, the *Run in isolation mode* option will already be selected. In that case, clearing the option will not be possible.

For more information about running elements in isolation mode, see [Elements can now be configured to run in isolation mode [ID 41757]](xref:General_Feature_Release_10.5.4#elements-can-now-be-configured-to-run-in-isolation-mode-id-41757).

#### Interactive Automation scripts: UI components 'Calendar' and 'Time' can now retrieve the time zone and date/time settings of the Cube session [ID 42110]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When UI components of type *Calendar* or *Time* are used in interactive Automation scripts, up to now, the entered date and time would be formatted depending on the platform and the configured settings. From now on, when an interactive Automation script is being run within DataMiner Cube, the UI components of type *Calendar* and *Time* will be able to return the time zone of the client and the time and date as entered by the user.

For more information, see [Interactive Automation scripts: UI components 'Calendar' and 'Time' can now retrieve the time zone and date/time settings of the client [ID 42064]](xref:General_Feature_Release_10.5.4#interactive-automation-scripts-ui-components-calendar-and-time-can-now-retrieve-the-time-zone-and-datetime-settings-of-the-client-id-42064)

## Changes

### Breaking changes

#### Legacy InterClient feature has been removed [ID 42263]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

The legacy *InterClient* feature has now been removed from DataMiner Cube.

> [!IMPORTANT]
> Existing Automation scripts or connectors that are currently still using InterClient calls will no longer work. They should be updated as soon as possible.

### Enhancements

#### System Center: Credentials library is now fully aware of all supported SNMPv3 authentication and encryption algorithms [ID 41945]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->
<!-- Reverted by RN 42136 and reinstated by RN 42153 -->

Up to now, the credentials library would only be aware of a subset of all SNMPv3 authentication and encryption algorithms. Because of a number of enhancements, it will now be fully aware of all supported algorithms.

Throughout the Cube UI, in selection boxes listing these SNMPv3 authentication and encryption algorithms, the algorithms will now be sorted by strength (ascending). Also, wherever a *Security level and protocol* setting has to specified for an SNMPv3 connection (e.g. when configuring an SNMPv3 element), that setting will now by default be set to "AuthPriv".

#### System Center: Not possible to configure offloads when swarming is enabled [ID 41953]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When swarming is enabled, it is currently not possible to offload data. In the *Database* section of *System Center*, it has therefore been made impossible to configure offloads on systems with swarming enabled.

#### System Center: A warning icon will now be displayed when you specify a TTL value above a fixed limit [ID 41981]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When, in *System settings > Time to live*, you enter TTL values for trend data, a warning icon will now be displayed when you enter a value above a fixed limit. See the table below.

| Type of data       | Time window size | Maximum TTL    |
|--------------------|------------------|----------------|
| Real-time trending | 3 hours          | 6 days 6 hours |
| Minute trending    | 4 days           | 200 days       |
| Hour trending      | 14 days          | 700 days       |
| Day trending       | 30 days          | 1500 days      |

If you enter a TTL value that exceeds the maximum value, at the bottom of the *DMS DEFAULTS* section, you will be able to click the *More information about recommended TTL limits* link. This will open a page on docs.dataminer.services where you can find more information on [Cassandra TWCS](xref:Specifying_TTL_overrides#cassandra-twcs).

#### Alarm Console: Suggestion events generated by Relational anomaly detection will now be listed in the 'Suggestion events' tab and the 'Relational anomalies' tab [ID 42050]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

Up to now, the suggestion events generated by the *Relational anomaly detection* feature were listed in the *Active alarms* tab. From now on, they will instead be listed in both the *Suggestion events* tab and the *Relational anomalies* tab.

Note that these suggestion events are not editable. Clearing one of them will clear the suggestion event as well as all its base events.

#### Visual Overview: Background page loading times will no longer be logged [ID 42215]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

Up to now, when you closed a card in which a Visio page was used a background page, an SPI entry containing the loading time of the background page would be logged in the *SLClient.txt* log file. From now on, background page loading times will no longer be logged.

#### A number of UI text strings have been made more translation-friendly [ID 42285]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

In the Cube UI, the following text strings have been adjusted to allow a more natural translation to other languages:

- In the right-click menu of the Surveyor, and in the menu and confirmation boxes that allow you to select a new alarm template or trend template:

  - `<No monitoring>`
  - `<New alarm template>`
  - `<No trending>`
  - `<New trend template>`

- The title of the dialog box that allows you to add an element to a service or to a group of a service:

  - `Add element to service xxx`

#### System Center - Database: No longer possible to migrate the general database to Cassandra [ID 42305]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

As Cassandra on Windows OS and Cassandra Single are no longer supported, it is no longer possible to migrate the general database to Cassandra. Hence, the *Cassandra preparation/migration* button, found in the bottom-left corner of the *Database* section, has been removed.

See also: [Third-party software support lifecycle](xref:Software_support_life_cycles#third-party-software-support-lifecycle)

#### Visual Overview: An element or service referenced by a service but not included in it will now always be hidden [ID 42644]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.4 [CU0] -->

Up to now, when an element or service was referenced by a service but not included in it, a shape linked to that element or service would only be hidden when it was referenced by a wildcard (* or ?). From now on, when an element or service is referenced by a service but not included in it, it will always be hidden, regardless of how it is referenced.

> [!NOTE]
> The new behavior can be disabled by using the *elementoptions: IgnoreDynamicInclude* shape data. See [Adding options to shapes linked to elements or services](xref:Adding_options_to_shapes_linked_to_elements_or_services#options).

### Fixes

#### Visual Overview: Problem when updating element shapes that are linked to service elements via aliases [ID 41730]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

Elements that are part of a service can be given an alias within that service context. Element data within a visual overview can then contain such an element alias to make sure a particular shape is linked to the element referred to by the alias.

Up to now, when a service containing different elements was updated, and those elements had aliases that were used in element shapes, those shapes would not get updated because they would incorrectly be linked to the actual elements instead of the aliases.

From now on, when services are updated, element shapes will reflect the element to which the alias in the shape data refers to at the time of the update.

#### Visual Overview: Shapes displaying the name of a service or a view would not be updated when the name was changed [ID 41769]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

Up to now, when the name of a service or a view was updated, shapes displaying that name would incorrectly not be updated.

From now on, shapes that display the name of an object using an asterisk in the shape text and a shape data field of type *Info* set to "NAME" will automatically be updated when the name of that object changes, as will any [Name], [this service] and [this view] placeholders.

#### Spectrum analysis: Problem when trying to open the trace recording of a history alarm [ID 42062]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When you right-clicked a history alarm in the Alarm Console and selected *Show alarm trace recording*, in some cases, the trend graph of the parameter in question would incorrectly be opened instead of the trace recording.

#### Problem when closing an element card [ID 42063]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

In some cases, an exception could be thrown when you closed an element card.

#### Problem when requesting information about file changes [ID 42076]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When DataMiner Cube asked the DataMiner Agent to which it was connected when a particular file had been last changed, in some cases, the file could not be found due to a casing issue.

#### DataMiner Cube desktop app: Configuration files would incorrectly be updated when the app was closed [ID 42101]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When you closed the DataMiner Cube desktop app, the configuration files would incorrectly be updated.

#### Documents: Not possible to open documents of which the URI contained special characters [ID 42138]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

In the *Documents* module, up to now, it would incorrectly not be possible to open a document of which the URI contained special characters like "#" or spaces.

#### Alarm Console: Problem when Cube received a CorrelationDetailsEventMessage without ever receiving the associated correlated alarm [ID 42152]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When DataMiner Cube received a `CorrelationDetailsEventMessage` without ever receiving the associated correlated alarm, up to now, an exception could be thrown.

#### Data display: Parameter values containing curly braces could not be displayed in the right-click menu of a table [ID 42160]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When the right-click menu of a table in e.g. an element card displayed values of dependency parameters, in some cases, parameter values containing curly braces (e.g. "{test one}") would incorrectly not be displayed.

Example of how a right-click menu displaying dependency parameters can be configured in a *protocol.xml* file:

```xml
<Discreet options="table:singleselection" dependencyValues="301[value:301];302[value:302];303:[value:303]">
```

#### Trending: Trend graph legend would show the same current value for all parameters [ID 42184]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When, in a trend graph showing trend data of two parameters, the value of the first parameter changed, the trend graph legend would incorrectly show the same current value for both parameters until the value of the second parameter also changed.

#### Alarm Console: Placeholders in alarm filters would not get resolved when those filters contained brackets [ID 42214]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

Up to now, when placeholders (e.g. `[thisusername]`) were used in alarm filters made up of different segments enclosed in brackets (e.g. [...] OR [...]), the placeholders in the first segment would not get resolved.

#### DataMiner Cube desktop app: Problem when using both the '/Modify' and the '/Silent 'command-line arguments [ID 42267]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When you started the DataMiner Cube desktop app with both the `/Modify` and the  `/Silent` command-line arguments, the app would incorrectly not start in *Modify* mode.
