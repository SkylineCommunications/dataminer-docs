---
uid: Web_apps_Feature_Release_10.5.8
---

# DataMiner web apps Feature Release 10.5.8

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.4.0 [CU17] and 10.5.0 [CU5].

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.8](xref:General_Feature_Release_10.5.8).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.8](xref:Cube_Feature_Release_10.5.8).

## New features

#### Interactive Automation scripts: Filtering values in a redesigned UI component Dropdown [ID 42845]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

To prevent dropdown boxes in interactive Automation scripts from getting loaded with too much data, it is now possible to filter the data that is loaded into a dropdown box.

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

#### Low-Code Apps: Trigger component can now be controlled via actions [ID 43184]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

In a low-code app, a trigger component can now be controlled via the following actions:

| Action | Description |
|--------|-------------|
| Trigger  | This action will cause the trigger to go off.<br>When *Trigger timer* is enabled, the timer will not be affected. |
| Pause    | When *Trigger timer* is enabled, this action will pause the timer.<br>In the phrase "was triggered X seconds ago", the elapsed time will keep on going. |
| Continue | When *Trigger timer* is enabled and the timer is currently paused, this action will cause the timer to resume. |
| Reset    | When *Trigger timer* is enabled, this action will resets the timer, keeping its paused/running state intact.<br>In the phrase "was triggered X seconds ago", the elapsed time will not be reset. |

## Changes

### Enhancements

#### Low-Code Apps - Interactive Automation scripts: Color support for redesigned UI components [ID 42781]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

From now on, the redesigned UI components used in interactive Automation scripts will inherit the default accent color and the default page theme color of the low-code app, as well as any custom accent color that has been specified on component level.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### DataMiner landing page: Redesigned header bar [ID 43024]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

The header bar of the DataMiner landing page (e.g. `https://myDMA/root/`) has been redesigned.

- On the left, the DataMiner icon now also shows the URL of the landing page.
- On the right, next to the user icon, you can now find a cogwheel icon. Clicking that icon will open the *System home settings* window, which contains a setting that allows you to show or hide draft applications.

#### Dashboards app & Low-Code Apps: Automatically saved component settings will only get saved when in edit mode [ID 43029]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

Up to now, certain component settings would automatically get saved in a dashboard or low-code app, even when you were not in edit mode.

From now on, these automatically saved component settings will only get saved in a dashboard or low-code code when you are in edit mode.

#### GQI DxM: Enhanced installation [ID 43063]

<!-- MR 10.5.0 [CU5] - FR 10.5.8 -->

A number of enhancements have been made to the installation procedure of the GQI DxM.

For example, during the installation, the following notice will no longer appear: `Could not stop the following processes (60s): DataMiner GQI`.

#### Web apps: Email address of Skyline support has been changed to <support@dataminer.services> [ID 43093]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

In all DataMiner web apps, the email address of Skyline support has been changed from <techsupport@skyline.be> to <support@dataminer.services>.

#### Dashboards app & Low-Code Apps - Template editor: Color picker now allows you to configure the current color [ID 43113]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

In the template editor, for all types of layers, the color picker now allow you to configure the current color, i.e. the font color of the component.

#### Dashboards app & Low-Code Apps - Timeline component: Minor visual enhancements [ID 43129]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

A number of minor visual enhancements have been made to the timeline component:

- The timeline's segment lines have been made a bit less transparent, and should now stand out more. Also, the background shading of the timeline groups has been removed.

- The template previews in the *Item Templates* section of the *Layout* pane will now scale to fit into the available screen real estate. Also, they will now better reflect the component color.

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

When, in a line & area chart component, you had changed the name of the Y axis, up to now, that name change would incorrectly only be propagated to other Y axis settings after you had moved the mouse pointer. From now on, the change will get propagated immediately.

#### Low-Code Apps: Components used in a low-code app could cause a user's web browser to leak memory [ID 42955]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

In some cases, components used in a low-code app could cause a user's web browser to leak memory.

#### GQI: GQI DxM and SLHelper could leak memory [ID 43028]

<!-- MR 10.5.0 [CU5] - FR 10.5.8 -->

In some cases, both GQI DxM and SLHelper could leak memory, especially when executing GQI queries with GQI extensions (i.e. ad hoc data source or custom operators) that throw exceptions from their lifecycle methods.

See also: [GQI DxM - Lifecycle: OnDestroy method would incorrectly be called when an error occurred in the OnInit method [ID 43186]](#gqi-dxm---lifecycle-ondestroy-method-would-incorrectly-be-called-when-an-error-occurred-in-the-oninit-method-id-43186)

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

When a query was processed by the GQI DxM, the result set of the query would contain incorrect column statistics for boolean columns, causing those columns to not be filterable in query filter components.

#### GQI DxM: Problem when setting up an SLNet connection for a GQI query to be executed without user context [ID 43128]

<!-- MR 10.5.0 [CU5] - FR 10.5.8 -->

When the GQI DxM had to set up an SLNet connection within an ad hoc data source for a GQI query to be executed without user context, up to now, the following error would be thrown:

`Cannot clone non-authenticated or non-regular connections.`

From now on, when such an SLNet connection has to be set up, the GQI DxM will set up a system connection with Administrator privileges.

#### Dashboards app & Low-Code Apps - Timeline component: Timeline items would incorrectly shift when you clicked 'Lock timeline to now' [ID 43130]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When, in the timeline component, you clicked *Lock timeline to now*, the default timezone configured in the `C:\Skyline DataMiner\users\ClientSettings.json` file would incorrectly not be taken into account, causing the timeline items to shift to UTC time.

The same issue would occur when you double-clicked the left mouse button while holding the CTRL key pressed.

#### GQI: Deserialization issue when querying DOM instances via the GQI DxM [ID 43132]

<!-- MR 10.5.0 [CU5] - FR 10.5.8 -->

When querying DOM instances with service definition fields via the GQI DxM, up to now, the `ServiceDefinitionFieldDescriptor` would not deserialize correctly coming from SLNet, causing an exception to be thrown in GQI.

#### Dashboards app & Low-Code Apps: Problem when adding a DOM module to a component [ID 43142]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When a DOM module was added to a component, in some cases, that component would incorrectly get stuck in a loading state.

#### Low-Code Apps: 'Fetch the data' action would incorrectly reuse a cached query session instead of opening a new one [ID 43152]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

In some cases, the *Fetch the data* action would incorrectly reuse a cached query session instead of opening a new one.

#### Dashboards app & Low-Code Apps - State, Node edge graph, Maps & Grid components: Problem with initial selection of table data [ID 43155]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When a state, node edge graph, maps or grid component was configured to visualize table data, the following issues could occur when the component was loaded:

- Data selection instructions in the URL would not be applied.
- If supported by the component, any option to select the first item by default would not be applied
- The current selection would not be preserved when the data was refetched.

From now on, whether the above-mentioned components are configured to visualize query data or table data, data selection will occur as follows:

1. Apply the data selection instructions in the URL (if any).
1. If no data selection instructions could be found in the URL, select the first item if such an option is supported and enabled.
1. Preserve the current selection when the data is refetched.

#### GQI DxM - Lifecycle: OnDestroy method would incorrectly be called when an error occurred in the OnInit method [ID 43186]

<!-- MR 10.5.0 [CU5] - FR 10.5.8 -->

Up to now, when an error occurred in the `OnInit` lifecycle method, the `OnDestroy` lifecycle method would still be called to clean up resources.

From now on, when something goes wrong in the `OnInit` lifecycle method, the `OnDestroy` lifecycle method will no longer be called.

#### Dashboards app & Low-Code Apps - GQI: Problem when a query was refetched [ID 43195]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When a query was refetched immediately after the data had been loaded, in some cases, the dashboard or low-code app could become unresponsive.

#### GQI DxM: Admin connection would incorrectly be allowed to expire [ID 43290]

<!-- MR 10.5.0 [CU5] - FR 10.5.8 [CU0] -->

If the GQI DxM is used with an admin connection, its underlying persistent system connection is used to handle any requests or subscriptions towards SLNet.

Up to now, when the admin connection had been idle for at least 1 minute after being used, the underlying system connection would automatically close the admin connection, causing the GQI DxM to unsubscribe from NATS and close all sessions and extension workers.

From now on, the admin connection will no longer expire, and will no longer be automatically closed by the underlying system connection.
