---
uid: Web_apps_Feature_Release_10.5.4
---

# DataMiner web apps Feature Release 10.5.4 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.4](xref:General_Feature_Release_10.5.4).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.4](xref:Cube_Feature_Release_10.5.4).

## Highlights

*No highlights have been selected yet.*

## New features

*No features have been added yet.*

## Changes

### Enhancements

#### Low-Code Apps - Interactive Automation scripts: Redesigned UI component 'Dropdown' [ID 41838]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

The UI component `UIBlockType.Dropdown` has been redesigned.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Low-Code Apps - Interactive Automation scripts: Redesigned UI component 'CheckBox' [ID 41891]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

The UI component `UIBlockType.CheckBox` has been redesigned.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Low-Code Apps - Interactive Automation scripts: Redesigned UI component 'PasswordBox' [ID 42007]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

The UI component `UIBlockType.PasswordBox` has been redesigned.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Low-Code Apps: Enhanced URL data support [ID 42031]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

Up to now, low-code apps would only support using URL data to pass default values to components. For example, to select a particular default value in a dropdown box. From now on, low-code apps will also be able to consume data passed via their URL using either the JSON syntax or the legacy syntax. For example, you will now be able to use an element specified in the URL to filter a GQI query.

For more information regarding the above-mentioned JSON syntax and legacy syntax, see [Specifying data input in a dashboard URL](xref:Specifying_data_input_in_a_dashboard_URL).

> [!NOTE]
> Contrary to dashboards, low-code apps will not push data to the URL. In other words, the URL will not change when data is selected in a component.

#### Dashboards/Low-Code Apps - Column & bar chart component: Settings now have new default values [ID 42106]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

The following settings of a *Column & bar chart* component now have new default values:

| Setting | Old default | New default |
|---------|-------------|-------------|
| Chart layout      | Relative per variable | Absolute      |
| Chart orientation | Left to right         | Bottom to top |

Existing components will not be affected.

### Fixes

#### Low-Code Apps: Certain actions would incorrectly not use the event information passed to them [ID 41979]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When the following actions were executed, up to now, they would incorrectly not use the event information that was passed to them.

- *Set viewport* action on a *Line & area chart* component with parameter data
- *Set value* action on a *Time range* component
- *Set value* action on a *Numeric input* component
