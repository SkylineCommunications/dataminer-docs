---
uid: Web_apps_Main_Release_10.3.0_CU3
---

# DataMiner web apps Main Release 10.3.0 CU3

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Main Release 10.3.0 CU3](xref:General_Main_Release_10.3.0_CU3).

### Enhancements

#### Dashboards app & Low-Code Apps - Table component: Enhanced visibility of rows that are selected or hovered over in dark mode [ID_35993]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.5 -->

When a dashboard or a low-code app is in dark mode, from now on, there will be a higher color contrast between rows that are selected or hovered over and rows that are not.

#### Dashboards app & Low-Code Apps: Web component now supports hyperlinks with a target attribute [ID_36159]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

A web component now supports hyperlinks with a target attribute.

Example: `<a href="http://www.skyline.be" target="_blank">Skyline Communications</a>`

### Fixes

#### Dashboards app: Problem when trying to open a shared dashboard [ID_35271]

<!-- MR 10.3.0 [CU3] - FR 10.3.3 -->

When users tried to open a shared dashboard, in some cases, they would unexpectedly be presented with a login screen because of a permission issue.

Workaround: Recreate the faulty shared dashboard.

#### Dashboards app: Problem with width of PDF reports [ID_35531]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU3] - FR 10.3.4 -->

When a PDF report was generated via Automation or Scheduler, in some cases, its width would be set incorrectly.

Also, in some cases, the left and right padding of PDF reports generated via Automation, Scheduler and the Dashboards app itself would be missing.

#### Interactive Automation scripts: Problems with datetime component [ID_35682]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When an interactive Automation script was launched from a web app, the following issues could occur. These were all related to the datetime web component (*UIBlockType.Time*):

- When you clicked a date in the datetime picker, a changed value would already be returned to the script. From now on, the selected datetime value will not be returned to the script until you close the picker (either by double-clicking or by clicking *Done*).

- The datetime value that was returned to the script when the component lost focus could be incorrect.

- The focus loss detection would not always be accurate.

#### Dashboards app: Problem when an extra GetParameterTable call without ValueFilters was sent after sharing a dashboard with a state, ring or gauge component [ID_35844]

<!-- MR 10.3.0 [CU3] - FR 10.3.5 -->

When a dashboard with a state, ring or gauge component was shared, in some cases, an error could be thrown when an extra `GetParameterTable` call without `ValueFilters` was sent.

#### Dashboards app: Problem when selecting a parameter in a parameter feed component of a shared dashboard [ID_35863]

<!-- MR 10.3.0 [CU3] - FR 10.3.5 -->

When you selected a parameter in a parameter feed component of a shared dashboard, in some cases, an error could occur.

#### Dashboards app & Low-Code Apps - Table component: Selection issues [ID_35968]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When a GQI table was configured to feed the selected rows to another component, the following issues could occur:

- When you selected a row above a row that had been selected earlier, that row would not get fed.

- When you tried to select multiple rows using SHIFT+Click, this would not work when you selected the rows bottom to top.

- When you selected a single row that was already selected as part of a multiple select, the feed would not be updated.

- When you exported the selected rows to a CSV file, the CSV file would incorrectly contain all rows instead of only the ones you had selected.

#### Dashboards app & Low-Code Apps - Table component: Minimum pagesize would be used when exporting to a CSV file [ID_36012]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When exporting data from a table component to a CSV file, the minimum pagesize would be used. From now, the largest possible pagesize is used when exporting data from a table component to a CSV file.

#### Dashboards app & Low-Code Apps: Component title could be made too large [ID_36021]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In a custom component theme, for some fonts, the font size of the title could be set to a value higher than 36px, causing the component title to be larger than its container. Also, in some cases, the font size could incorrectly be set to 0px.

From now on, font sizes will have to be set to a value between 1px and 36px.

#### Dashboards app: Error when opening a shared dashboard containing a 'Line & area chart' component, a 'State' component, a 'Gauge' component or a 'Ring' component [ID_36022]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

An error could occur when you opened a shared dashboard that contained a *Line & area chart* component, a *State* component, a *Gauge* component or a *Ring* component.

#### Dashboards app: Retry button of table component would incorrectly be displayed in PDF file [ID_36026]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When you generated a PDF of a dashboard that contained a table component showing a *Retry* button (because of an error in the table), then that *Retry* button would incorrectly also be displayed in the PDF file.

#### Dashboards app & Low-Code Apps: GQI query nodes without options would incorrectly be expanded [ID_36064]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

In some cases, GQI query nodes without options would incorrectly be expanded.

#### Dashboards app: Problem when a 'State' component was fed a parameter value by a drop-down component in a shared dashboard [ID_36075]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

In a shared dashboard, an error could occur when a *State* component was fed a parameter value by a drop-down component.

#### Dashboards app & Low-Code Apps: GQI table component could throw 'Paged table session not found' error [ID_36101]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

In some cases, a GQI table component could thrown the following error:

```txt
Error trapped: Paged table session not found
```

From now on, a table session will immediately be closed after the last page has been fetched. This will prevent the above-mentioned error from being thrown.

#### Dashboards app: Error when opening a shared dashboard containing a 'Parameter Page' component [ID_36103]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

An error could occur when you opened a shared dashboard that contained a *Parameter Page* component.

#### Low-Code Apps: Problem when updating header titles [ID_36116]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When, while editing a low-code app with more than one header bar option, you selected another header bar option, the label of the previously selected header bar option would incorrectly still be displayed in the side panel.

#### Dashboards app & Low-Code Apps: Problem when searching elements of which the name contained special characters [ID_36128]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When, while editing a dashboard, you opened the *ELEMENTS* section in the *DATA* tab, and entered an element name containing special characters in the search box, the result set would always be empty, even if elements with that name existed.

#### Dashboards app & Low-Code Apps: Popup panel showing a PDF preview would incorrectly have a scroll bar [ID_36131]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In some cases, the popup panel showing the PDF preview of a dashboard would incorrectly have a scroll bar.

From now on, a popup panel showing a PDF preview will take the full screen height and will only allow its contents to scroll.

#### Dashboards app: Problem when pressing an arrow key in the 'Create dashboard' window [ID_36146]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In the *Create dashboard* window, pressing an arrow key while one of the text boxes had the focus would incorrectly cause the *OK* or *Cancel* button to become selected.

#### GQI: Web services API would not be able to correctly translate a server query to a web query [ID_36173]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.5 [CU0] -->

In some cases, the web services API would not be able to correctly translate a server query to a web query.

#### Dashboards app: Problem when sharing a dashboard that contained an alarm table component [ID_36178]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When you shared a dashboard that contained an alarm table component, in some cases, a `Not Authorized` error could be thrown.

#### Dashboards app: Order of parameters in State component of shared dashboard was incorrect [ID_36206]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When you viewed a shared dashboard that contained a *State* component, in some cases, the order of the parameters in that *State* component would be incorrectly.
