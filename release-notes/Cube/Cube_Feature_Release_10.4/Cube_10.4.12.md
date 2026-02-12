---
uid: Cube_Feature_Release_10.4.12
---

# DataMiner Cube Feature Release 10.4.12

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.4.12](xref:General_Feature_Release_10.4.12).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.12](xref:Web_apps_Feature_Release_10.4.12).

## New features

#### Interactive automation scripts: New option to skip the confirmation window when aborting [ID 40720]

<!-- MR 10.5.0 - FR 10.4.12 -->

DataMiner Cube now supports the new `SkipAbortConfirmation` property that was added to `UIBuilder`. When this property is set to true, the confirmation window will not be displayed when the interactive automation script is aborted. By default, this property will be set to false.

> [!TIP]
> See also: [Interactive automation scripts: New option to skip the confirmation window when aborting [ID 40683]](xref:General_Feature_Release_10.4.12#interactive-automation-scripts-new-option-to-skip-the-confirmation-window-when-aborting-id-40683)

#### Settings: New settings to open view cards and EPM cards undocked [ID 40782]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

In the *User > Card* section of the *Settings* windows, you can now find the following new settings:

| Section | Setting | Description |
|---------|---------|-------------|
| View card | Open EPM cards undocked  | When selected, all EPM cards will be opened undocked.  |
| EPM card  | Open view cards undocked | When selected, all view cards will be opened undocked. |

#### Alarm templates - 'Anomaly alarm settings' window: New option to generate an alarm when a parameter is expected to cross a particular alarm threshold or be outside a set range [ID 40837] [ID 41109]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When, in the alarm template editor, you click the button in the *Analytics* column (formerly called *Anomalies*) for a particular parameter, the *Augmented Operations alarm settings* pop-up window (formerly called *Anomaly alarm settings*) will open. This window will allow you to select one of the preset options or configure the anomaly alarm settings according to your preference.

Now, at the bottom of this *Augmented Operations alarm settings* pop-up window, to which a scrollbar has now been added, you will also be able to specify that an alarm of a certain severity should be generated when the proactive cap detection feature expects that the value of the parameter will soon cross a particular alarm threshold or be outside a set range.

> [!NOTE]
> The above-mentioned button in the *Analytics* column can be labelled *Smart*, *Disabled* or *Customized*:
>
> - The button will be labelled *Smart* when anomaly monitoring is set to "Smart" and proactive cap detection has at least one threshold configured.
> - The button will be labelled *Disabled* when anomaly monitoring is set to "All disabled" and no threshold are configured for proactive cap detection.
> - In all other cases, the button will be labelled *Customized*.

> [!IMPORTANT]
> This feature will only work when connected to a DataMiner Agent running at least main release 10.5.0 or feature release 10.4.12.

#### Specifying a different layout for each of the four Cube sides [ID 40887]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

On each of the four Cube sides, it is now possible to specify a different layout.

#### Settings: New computer setting to clear the Edge WebView2 cache [ID 41026]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

In the *Computer > Advanced* section of the *Settings* windows, you can now find the following new settings:

| Setting | Description |
|---------|-------------|
| Clear browser cache on sign-out | When selected, the Edge WebView2 browser cache will be cleared on sign-out, ensuring that the SAML authentication window appears the next time you log on. |
| Clear cache now | When clicked, the Edge WebView2 browser cache will be cleared immediately. |

## Changes

### Enhancements

#### Cube will now only retrieve DCF interface data when required [ID 40728]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

Up to now, DataMiner Cube would by default retrieve all DCF interface data at startup. From now on, it will only retrieve the DCF interface data when required.

#### System Center - Logging: 'Resource Manager Scheduler' log file now available in DataMiner tab [ID 40899]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

In the *Logging* section of *System Center*, the following log file can now also be consulted in the *DataMiner* tab:

- Resource Manager Scheduler

#### Label "Show Agent alarms" now translated [ID 40868]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

If you view the Cube UI in one of the supported languages other than English, the label "Show Agent alarms" will now be translated to the selected language.

This label is used in the *Agent alarms* section of the *System Center > Agents > Manage* page.

#### Router Control: Link added to 'Dynamic table filter syntax' page in dataminer.docs [ID 40959]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

In the Router Control module, it is possible to add a matrix represented by two table parameters, i.e. an input and an output table, instead of a matrix parameter. To do so, in the *Add matrix* dialog box, a specific filter syntax needs to be used in the *Advanced configuration* section. In that section, you can now find a link to the [Dynamic table filter syntax](xref:Dynamic_table_filter_syntax) page in dataminer.docs.

#### System Center - Users/Groups: Read-only names of domain groups and cloud groups will no longer be validated [ID 40987]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

As names of domain groups and cloud groups are read-only, from now on, these will no longer be validated.

### Fixes

#### Problem when a large number of objects were added to, updated in or removed from a view [ID 40791]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

In some cases, the Cube UI could start to behave erratically when a large number of objects were added to, updated in or removed from a view.

#### Visual Overview - Resource Manager component: SelectedPool variable could get set incorrectly when selecting a booking on a resource band [ID 40845]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When, in a *Resource Manager* component, you selected a booking on a resource band of which the resource was filtered by ID, the *SelectedPool* variable could get set incorrectly.

#### License expiration window: Title and text included the incorrectly spelled word "licence" [ID 40894]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When a license has expired, a notification window will appear when you open DataMiner Cube.

Up to now, both the title and the text of that notification window would include the incorrectly spelled word "licence". This word has now been changed to "license".

#### Desktop app start window: Message 'Did you mean ...?' would incorrectly be displayed when you entered the name of a non-existing DMS [ID 40896]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When, in the start window of the Cube desktop app, you clicked the '+' button and entered the name of a non-existing DataMiner System in the *Host* box, up to now, two messages would appear:

- "Not a DataMiner Agent", and
- "Did you mean", followed by the exact name you entered.

This last message will no longer be displayed.

#### Trending: Viewport of trend graph would incorrectly jump to the last day [ID 40931]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When you opened a trend graph, in some rare cases, its viewport would incorrectly jump to the last day.

#### No longer possible to open web apps from within Cube [ID 40951]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

In some cases, when you used Cube to connect to the DataMiner Agent running on the same machine with *Connecting type* set to "Auto", due to a hostname resolution issue, it was no longer possible to open web apps like Monitoring or Dashboards from within Cube. Also, the name of the DataMiner System would no longer be displayed in the Cube header.

#### Visual Overview: Problem when loading AlarmSummary shapes [ID 40962]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

Up to now, when a visual overview contained a large number of *AlarmSummary* shapes, in some cases, Cube could become unresponsive due to the shapes being loaded sequentially. From now on, *AlarmSummary* shapes will be loaded asynchronously.

#### System Center: Problem when opening the 'Permissions > Views' tab of a user group [ID 40969]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When, in *System Center*, you opened the *Permissions > Views* tab of a particular user group, in some cases, Cube could become unresponsive when that tab contained a large amount of items.

#### Elements: 'Force unlock element' would incorrectly appear instead of 'Unlock element' after locking an element [ID 40994]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When you locked an element by clicking *Lock element* in the hamburger menu of the element card, in some cases, the *Force unlock element* command would incorrectly appear instead of the *Unlock element* command.

#### Alarm Console - Behavioral anomaly detection: Problem when selecting 'Improve alarm template' after giving a downward trend change a 'thumbs up' [ID 41006]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When you gave a downward trend change a "thumbs up" and then selected *Improve alarm template*, the pop-up window that appeared would incorrectly not show the button needed to switch between the proposed configuration and the current configuration for downward trend changes.

#### Not possible to make corrections to corrupt anomaly alarm templates [ID 41007]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

Up to now, it would incorrectly not be possible to make corrections to corrupt anomaly alarm templates in DataMiner Cube. This has now been made possible.

#### Visual Overview: Problem when updating path data [ID 41027]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When shape data of type *Path* was updated in such a way that it affected the constraints, up to now, the constraints would not be updated correctly. In some situations, this would result in paths not being visible.

From now on, the constraints will always follow those of the active path.

#### Alarm Console: Not all base alarms would be moved to the active alarms tab when a correlation alarm was cleared [ID 41071]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When a correlated alarm was cleared before all its base alarms were cleared, in some rare cases, those base alarms would incorrectly not be moved to the active alarms tab.

#### Cards: Problem when opening a view card [ID 41082]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When you tried to open a view card, in some rare cases, the card could remain empty, showing a "Loading" message.

#### Alarm Console: Manually created incident would not appear in newly-created active alarms tab [ID 41087]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When, in the Alarm Console, you created a manual incident, and you then added a new active alarms tab, the incident you created would incorrectly not appear in the newly-created active alarms tab.

#### Parameter-specific alarm template editor would incorrectly overwrite an existing template [ID 41120]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When you double-click a parameter in Data Display and go to the *Templates* tab, or when you right-click an alarm and select *Change > Alarm range*, a parameter-specific template editor will open. Up to now, in some cases, that editor would incorrectly overwrite an existing template when a new template had to be created.

#### Visual Overview: Problem when viewing a visual overview with an AlarmSummary shape while correlation updates were being processed [ID 41124]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When a large number of correlation updates were being processed while you were viewing a visual overview with an *AlarmSummary* shape, in some cases, an exception could be thrown.
