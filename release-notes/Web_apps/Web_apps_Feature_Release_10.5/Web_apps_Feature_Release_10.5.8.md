---
uid: Web_apps_Feature_Release_10.5.8
---

# DataMiner web apps Feature Release 10.5.8 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.8](xref:General_Feature_Release_10.5.8).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.8](xref:Cube_Feature_Release_10.5.8).

## Highlights

*No highlights have been selected yet.*

## New features

#### Interactive Automation scripts: Filtering values in a redesigned UI component 'DropDown' [ID 42845]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

To prevent dropdown boxes in interactive Automation scripts to get loaded with too much data, it is now possible to filter the data that is loaded into a dropdown box.

Note that this feature will only work if you use the redesigned `UIBlockType.DropDown` component. To use this redesigned component, add the following argument to the URL of the dashboard or low-code app:

`?useNewIASInputComponents=true`

To enable filtering for `UIBlockType.DropDown` component, in the `UIBlockDefinition`, set the `WantsOnFilter` property to true.

The information returned by a `ShowUI` command (`UIResults`) has been extended with the following methods to get the filter value:

- `WasOnFilter()` will return true if a filter value was entered.

  ```csharp
  bool WasOnFilter(string destVar)
  ```

- `GetFilterString()` will return the filter value that was entered when `WasOnFilter()` was set to true.

  ```csharp
  string GetFilterString(string destVar)
  ```

Example:

```csharp
var dropDownControl = new UIBlockDefinition
{
    Type = UIBlockType.DropDown,
    DestVar = "DropDownVariable",
    // Set WantsOnFilter to true, if changing the filter of this UI block item should trigger an OnFilter event. False, by default.
    WantsOnFilter = true,
};

// ...

// WasOnFilter() will return true if the user entered a filter value.
if (results.WasOnFilter("DropDownVariable"))
{
    // GetString() will return the current value of the control, at the time the filter value was entered.
    var currentValue = results.GetString("DropDownVariable");
    // When WasOnFilter() was true, GetFilterString() will return the filter value that was entered.
    var filterValue = results.GetFilterString("DropDownVariable");
}
```

> [!NOTE]
>
> - This feature will only work in conjunction with DataMiner server version 10.5.8 or newer.
> - While filtering the dropdown box entries, the script's logic is responsible for adding the currently selected entry (if relevant). Otherwise, the dropdown box will consider that value as incorrect and clear itself. Consider only filtering the display value of the entries (case-invariant if possible).
> - Scripts using this feature should not include components of which the variable name (DestVar) contains "_FilterString". Otherwise, the identifier will not be unique.

## Changes

### Enhancements

#### Low-Code Apps - Interactive Automation scripts: Color support for redesigned UI components [ID 42781]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

From now on, the redesigned UI components used in interactive Automation scripts will inherit the default accent color and the default page theme color of the low-code app, as well as any custom accent color that has been specified on component level.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Dashboards app & Low-Code Apps: Automatically saved component settings will only get saved when in edit mode [ID 43029]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

Up to now, certain component settings would automatically get saved in a dashboard or low-code app, even when you were not in edit mode.

From now on, these automatically saved component settings will only get saved in a dashboard or low-code code when you are in edit mode.

#### Web apps: Email address of Skyline support has been changed to <support@dataminer.services> [ID 43093]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

In all DataMiner web apps, the email address of Skyline support has been changed from <techsupport@skyline.be> to <support@dataminer.services>.

#### Dashboards app & Low-Code Apps - Template editor: Color picker now allows you to configure the current color [ID 43113]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

In the template editor, for all types of layers, the color picker now allow you to configure the current color, i.e. the font color of the component.

#### Dashboards app & Low-Code Apps: Border roundness setting will now be set to 5px in the default component themes [ID 43146]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

In the default component themes, the border roundness setting will now be set to 5px.

#### Dashboards app - Dashboard sharing: Message mentioning 'DataMiner Cloud Platform' now mentions 'dataminer.services' instead [ID 43163]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When you tried to share a dashboard while connected to a DataMiner Agent that was not cloud-connected, up to now, the message that appeared would incorrectly still mention the term "DataMiner Cloud Platform". In that message, that term has now been replaced by the term "dataminer.services".

#### Low-Code Apps: 'Discard draft' pop-up window will no longer mention the word 'delete' [ID 43164]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

Up to now, when you clicked *Discard draft*, the pop-up window that appeared would incorrectly mention the word "delete". In that pop-up window, every mention of the word "delete" has now been replaced by the word "discard".

### Fixes

#### Low-Code Apps: It would incorrectly be possible to publish a low-code app while it was still being saved [ID 42680]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

Up to now, it would incorrectly be possible to publish a low-code app while it was still being saved.

From now on, it will only be possible to publish a low-code app when the app has been saved.

#### Low-Code Apps - Interactive Automation scripts: initialValue of UI component 'Time' would not get updated in the UI when the value changed [ID 42878]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When the `UIBlockType.Time` component had a time range configured in the AutomationTimeUpDownOptions property, up to now, the initialValue that was displayed, would incorrectly not get updated when the value changed.

#### Dashboards app & Low-Code Apps - Line & area chart component: Y axis name change would incorrectly only be propagated to other Y axis settings after moving the mouse pointer [ID 42940]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When, in a *Line & area chart* component, you had changed the name of the Y axis, up to now, that name change would incorrectly only be propagated to other Y axis settings after you had moved the mouse pointer. From now on, the change will get propagated immediately.

#### Low-Code Apps: Components used in a low-code app could cause a user's web browser to leak memory [ID 42955]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

In some cases, components used in a low-code app could cause a user's web browser to leak memory.

#### Web Services API: SLHelper would incorrectly be used to process GQI queries when GQI DxM had been enabled in Web.config [ID 43046]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When, in the `C:\Skyline DataMiner\Webpages\API\Web.config` file, you had specified that all GQI-related operations had to be executed by the GQI DxM, in some cases, SLHelper would incorrectly still be used to process GQI queries.

#### Dashboards app & Low-Code Apps: Components could incorrectly get destroyed when you switched to another page [ID 43081]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

Up to now, components could incorrectly get destroyed when you switched to another page of a dashboard.

#### Dashboards app & Low-Code Apps - Timeline & Maps components: Settings would incorrectly get overwritten when a query returned an empty result set [ID 43088]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When a query returned an empty result set without any columns, up to now, the values of the latitude/longitude and dimension settings would incorrectly be overwritten with automatically applied default values.

#### Low-Code Apps: Not possible to edit any app when the app.config.json of a published app did not contain an ID [ID 43106]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When the *app.config.json* file of a published app did not contain an ID, up to now, it would not be possible to edit any of the existing apps.

#### Dashboards app & Low-Code Apps - Query filter component: GQI DxM would pass incorrect column statistics for boolean columns [ID 43127]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When a query was processed by the GQI DxM, the result set of the query would contain incorrect column statistics for boolean columns, causing those columns to not be filterable in *Query filter* components.

#### Dashboards app & Low-Code Apps - Timeline component: Timeline items would incorrectly shift when you clicked 'Lock timeline to now' [ID 43130]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When, in the *Timeline* component, you clicked *Lock timeline to now*, the default timezone configured in the `C:\Skyline DataMiner\users\ClientSettings.json` file would incorrectly not be taken into account, causing the timeline items to shift to UTC time.

The same issue would occur when you double-clicked the left mouse button while holding the CTRL key pressed.

#### Dashboards app & Low-Code Apps: Problem when adding a DOM module to a component [ID 43142]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When a DOM module was added to a component, in some cases, that component would incorrectly get stuck in a loading state.

#### Low-Code Apps: 'Fetch the data' action would incorrectly reuse a cached query session instead of opening a new one [ID 43152]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

In some cases, the *Fetch the data* action would incorrectly reuse a cached query session instead of opening a new one.
