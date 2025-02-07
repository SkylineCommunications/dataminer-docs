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

#### Dashboards/Low-Code Apps: Reordering the columns in a Select operator by dragging and dropping [ID 42122]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

In a *Select* operator of a GQI query, you can now reorder the columns by dragging and dropping them.

### Fixes

#### Low-Code Apps: Certain actions would incorrectly not use the event information passed to them [ID 41979]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When the following actions were executed, up to now, they would incorrectly not use the event information that was passed to them.

- *Set viewport* action on a *Line & area chart* component with parameter data
- *Set value* action on a *Time range* component
- *Set value* action on a *Numeric input* component

#### Dashboards/Low-Code Apps - Table component: Problem when loading data from a partial table [ID 42107]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

In some cases, when new data from a partial table was being loaded into a *Table* component, the loading would get stuck.

#### Dashboards/Low-Code Apps - Grid component: Scroll bars would appear even though all items could be displayed [ID 42108]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

In some cases, scroll bars would appear on a *Grid* component, even though there was sufficient screen real estate to display all items.

#### Dashboards/Low-Code Apps: Letter descenders would incorrectly be cut off in Components data set [ID 42118]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When, while configuring a component, you opened the *Components* data set on the *Data* pane, all portions of letters that extended below the font's baseline (i.e. the descenders of letters like e.g. g, j, q, p, and y) would incorrectly be cut off.

#### Dashboards/Low-Code Apps - Parameter table component: Clicking the info icon of the 'Parameter table filters' section would not open the correct help page [ID 42123]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When, while configuring a *Parameter table* component, you opened the *Parameter table filters*\* section on the *Data* pane and clicked the information icon on the right, the main page of [docs.dataminer.services](xref:docs_dataminer_services) would incorrectly be opened. From now on, the correct page, i.e. [Dynamic table filter syntax](xref:Dynamic_table_filter_syntax), will be opened instead.

\**The *Parameter table filters* section is only available if you add the `showAdvancedSettings=true` option to the URL of the dashboard or the low-code app.*

#### Dashboards/Low-Code Apps: Problem when deleting an operator from a flow [ID 42125]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When you wanted to delete an operator in the flow editor, up to now, you incorrectly had to delete it twice before it got removed from the flow.
