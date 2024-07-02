---
uid: Web_apps_Feature_Release_10.4.9
---

# DataMiner web apps Feature Release 10.4.9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.4.9](xref:General_Feature_Release_10.4.9).

## Highlights

*No highlights have been selected yet.*

## New features

#### Low-Code Apps: New 'Interactive Automation script' component [ID_39969]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

In low-code apps, you can now use *Interactive Automation script* components.

An *Interactive Automation script* component allows you to launch a preset interactive Automation script (ad hoc, on view, or after an event has occurred) and to display its UI. It also allows you to select a script and launch it, or to abort the script that is being run.

When you launch a new script while another is being run, the new script will start once the other script has finished.

In the settings of the component, you can also opt to have the component either show or hide the name of the script.

> [!NOTE]
>
> - The component cannot be used to launch Automation scripts that are not interactive.
> - The component will not ask for any missing parameters or dummies. It expects them to be filled in either in its settings or via feeds. When input is missing, the script will not be launched and the component will be blank.
> - By default, scripts will time out after 15 minutes. If a script times out, an error will be displayed in the component.

## Changes

### Enhancements

#### Dashboards app & Low-Code Apps: Enhanced retrieval of element/protocol parameters [ID_39954]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

Because of a number of enhancements, from now on, all components that retrieve element/protocol parameters will do so more efficiently.

#### Dashboards app & Low-Code Apps - Time range component: Reset button added [ID_40011]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

The *Time range* feed component now has a *Reset* button. Clicking this button will reset the time range to the default range (i.e. "Today so far").

#### Web API: DOM methods will no longer check whether DOM object GUIDs are empty [ID_40024]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

Up to now, the DOM methods in the web API would check whether a DOM object GUID was empty, and would block the call if this was the case.

As the DOM SLNet API support objects with empty GUIDs, all empty GUID checks have now been removed from the web API.

### Fixes

#### Web apps: Users would not get logged in after pressing ENTER on the authentication page [ID_39961]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When, on a mobile device, you entered your credentials on the authentication page of a DataMiner web app and pressed ENTER, you would incorrectly not be logged in. Instead, the authentication page would simply refresh.

#### Dashboards app & Low-Code Apps: Parameters data set would not include any parameters of type 'Button' when filtered by protocol [ID_39973]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When, in the *Parameters* data set, you filtered by protocol, the parameters list would incorrectly not include any parameters of type "Button".

#### Dashboards app & Low-Code Apps - Timeline component: Regional settings would not be taken into account [ID_39987]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When positioning items, the *Timeline* component would incorrectly not take into account the regional settings (e.g. time zone) specified in the *C:\\Skyline DataMiner\\users\\ClientSettings.json* file.

#### Dashboards app & Low-Code Apps - Ad hoc data sources & custom operators: Timespan metadata would not be converted to the local time zone [ID_40033]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When you link dataminer objects to rows in an ad hoc data source or when you configure a custom operator, you can add timespan data as metadata. Up to now, this timespan metadata would incorrectly not be converted to the local timezone specified in the *C:\\Skyline DataMiner\\users\\ClientSettings.json* file.

> [!TIP]
> See also:
>
> - [Linking rows to DataMiner objects](xref:Ad_hoc_Metadata)
> - [Modifying links to DataMiner objects](xref:CO_Metadata)

#### Dashboards app & Low-Code Apps: Time range component would pass along a reversed time range [ID_40056]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

In some cases, a time range feed component would pass along a reversed time range.
