---
uid: Web_apps_Feature_Release_10.5.3
---

# DataMiner web apps Feature Release 10.5.3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.3](xref:General_Feature_Release_10.5.3).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.3](xref:Cube_Feature_Release_10.5.3).

## Highlights

*No highlights have been selected yet.*

## New features

#### Dashboards/Low-Code Apps: Support for variables of type Boolean [ID 41845]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When editing a dashboard or a low-code app, you can now also create variables of type Boolean.

Also, boolean values can now be passed in the URL of a dashboard. See the following example of a query parameter:

`?data={"components": [{"cid":1, "select": {"booleans": ["true"]}}]}`

## Changes

### Enhancements

#### DataMiner root page: Links to deprecated DataMiner XBAP and legacy Reports & Dashboards app have now been removed [ID 41844]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When, on the root page of a DataMiner Agent (i.e. `https://myDMA/root/tools`), you click the user icon and then select *Tools*, a *Tools* page will open.

Up to now, this page would still contain links to the XBAP version of DataMiner Cube and to the legacy *Reports & Dashboards* app. As both are now deprecated, the links to both those apps as well as the *Clean DataMiner Cube XBAP Cache* link have now been removed.

### Fixes

#### Dashboards/Low-Code Apps - Timeline component: Problem with custom timezones [ID 41839]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When using a custom timezone, in some cases, that timezone would not be applied correctly in action configurations or when linking to certain components.

#### Dashboards/Low-Code Apps - State component: Scale of text would not be updated when the value of the linked parameter changed [ID 41843]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When a *State* component was linked to a parameter, and the size of that component was set to "Auto", up to now, the scale of the text would not be updated when the value of the parameter changed. In some cases, this would render the text unreadable.
