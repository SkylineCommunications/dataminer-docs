---
uid: Web_apps_Main_Release_10.3.0_CU2
---

# DataMiner web apps Main Release 10.3.0 CU2

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Main Release 10.3.0 CU2](xref:General_Main_Release_10.3.0_CU2).

### Enhancements

#### Monitoring app: Elements, services and views opened by clicking a Visio shape will open in the same tab instead of a new tab [ID_35781]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

In the *Monitoring* app, from now on, elements, services and views opened by clicking a Visio shape will open in the same tab instead of a new tab.

#### Web apps - Query builder: Query node options with only a single value will no longer be displayed in a selection box [ID_35865]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

In the query builder, from now on, when a query node option only has a single value, that option will no longer be displayed in a selection box.

For example, up to now, when you selected the *Get elements* data source, followed by the *Aggregate* operator, the method selection box would display "Get the". This will no longer be the case.

#### GQI data sources that require an Elasticsearch database will now use GetInfoMessage(InfoType.Database) to check whether Elasticsearch is available [ID_35907]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

Up to now, GQI data sources that require an Elasticsearch database used the `DatabaseStateRequest<ElasticsearchState>` message to check whether Elasticsearch was available. From now on, they will use the `GetInfoMessage(InfoType.Database)` message instead.

#### Web apps: Enhanced error handling when executing an interactive Automation script by clicking a DOM button [ID_35909]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

Overall error handling has been improved when executing an interactive Automation script by clicking a DOM button in a web app.

#### Security enhancements [ID_35965]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

A number of security enhancements have been made.

### Fixes

#### Dashboards app: Sticky component menus would no longer be fully visible after you had changed the number of dashboard columns [ID_35702]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.4 -->

Sticky component menus would no longer be fully visible after you had changed the number of dashboard columns.

#### Dashboards app & Low-Code Apps: GQI components would incorrectly not clear their query row feed when refetching data [ID_35767]

<!-- MR 10.3.0 [CU2] - FR 10.3.4 -->

GQI components would incorrectly not clear their query row feed when refetching data.

#### Dashboards app & Low-Code Apps - GQI components: Problem when executing an empty query [ID_35803]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When GQI components tried to execute an empty query, up to now, they would keep on showing a "loading" indicator. From now on, an appropriate message will be displayed instead.

#### Dashboards app & Low-Code Apps: Duplicated component would not have the size as the original [ID_35804]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When you duplicated a component, the size of the duplicate would incorrectly be limited to 30 rows. From now on, when you duplicate a component, the duplicate will have the same size as the original.

#### Dashboards app & Low-Code Apps - GQI components: Open sessions would not be closed when a new query was triggered [ID_35824]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU2] - FR 10.3.5 -->

When a GQI component still had a session open when a new query was triggered, in some cases, the open session would incorrectly not be closed.

#### Dashboards app: Problem when using the search box on a mobile device [ID_35825]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When the *Dashboards* app was opened on a mobile device, an error could occur when you entered something in the search box.

#### Dashboards app & Low-Code Apps - Form component: Problems with multiple-selection drop-down boxes [ID_35829]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When a form component contained multiple-selection drop-down boxes, it would load too slowly due to the drop-down box change detection being triggered over and over again. From now on, form components containing multiple-selection drop-down boxes will load considerably quicker.

Also, when a multiple-selection drop-down field of a DOM instance was added to a form component, the current values preloaded into the field as placeholders would incorrectly not get removed once the data was loaded, causing the drop-down field to contain duplicate values.

#### Dashboards app: A table component could appear to be empty when you rapidly switched between visualizations [ID_35831]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

In some cases, a table component could appear to be empty when you rapidly switched between visualizations.

Also, an error could be thrown when you tried to add an invalid query to a component.

#### Dashboards app & Low-Code Apps: Problem with 'Share' button and subheader items on mobile devices [ID_35839]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When you opened a dashboard or a low-code app on a mobile device, the *Share* button would not be available and the subheader items would not be hidden correctly.

#### Web apps: Problem when opening a visual overview [ID_35841]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

When you opened a visual overview in a web app, in some cases, the web app could become unresponsive.

#### Dashboards app & Low-Code Apps: Text boxes in the Layout tab would not update when you selected another component [ID_35851]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When, in the *Layout* tab, a text box (e.g. the box containing the title of the selected component) had the focus, and you selected another component, the text box in the *Layout* tab would incorrectly still contain the value of the previously selected component.

#### Dashboards app & Low-Code Apps - Table component: A collapsed group would incorrectly expand when new data was loaded into the table [ID_35856]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When, in a table component, the data was grouped by two different parameters, in some cases, a collapsed group would incorrectly expand when new data was loaded into the table.

#### Dashboards app: Multiple parameter feeds would incorrectly have their 'group by' reset when a PDF was generated [ID_35866]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

When you generated a PDF of a dashboard that contained multiple parameter feeds, a multiple parameter feed with a "group by" applied would incorrectly have that "group by" reset to the value that was configured in its settings.

#### Web apps: Certain icons would incorrectly not be displayed [ID_35877]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

In web apps, certain icons would incorrectly not be displayed.

#### Dashboards app & Low-Code Apps - Table component: Initial grouping would incorrectly be considered a modification [ID_35882]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

In a table component, the initial grouping would incorrectly be considered a modification. As a result, the *Restore initial view* button would appear in the component header. When you then clicked that button, the grouping would be removed.

From now on, the initial grouping will no longer be considered a modification. When you modify the table by sorting, filtering, grouping or re-ordering data and then click the *Restore initial view* button, the initial grouping will now be restored.

#### Dashboards app & Low-Code Apps - Table component: Issues with 'Loading' indicator [ID_35894]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

A number of issues with regard to the "Loading" indicator have been fixed.

#### Dashboards app & Low-Code Apps - GQI: Queries linked to feeds would not always apply feed changes [ID_35903]

<!-- MR 10.3.0 [CU2] - FR 10.3.4 [CU0] -->

In some cases, a query that was linked to feeds would not apply the feed changes in the visualizations unless it was opened in edit mode.

#### Dashboards app & Low-Code Apps - GQI components: Problems when a GQI request failed [ID_35904]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When a GQI request failed, some GQI components would show either an unrelated error or no error at all, while other GQI components would show a correct error but incorrect data.

#### Dashboards app & Low-Code Apps: Performance could decrease when State components had their Design option set to 'Auto size' [ID_35905]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

Up to now, overall performance of a dashboard or a low-code app could decrease when it contained *State* components of which the *Design* option was set to "Auto size". A number of enhancements have now been made to prevent performance from decreasing in this case.

#### Web apps: Login button would incorrectly be disabled on Edge and Chrome [ID_35906]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

Up to now, in some cases, the login button would incorrectly be disabled when you opened a web app in Microsoft Edge or Google Chrome.

#### Monitoring app - Visual Overview: Clicking a region that opened an element, service or view card would incorrectly cause the Monitoring app to reload [ID_35908]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When, in the Monitoring app, you clicked a region in a visual overview that opened an element, service or view card, up to now, the entire Monitoring app would reload. From now on, when you click a region in a visual overview that opens an element, service or view card, the card in question will open but the Monitoring app will no longer be reloaded.

#### Dashboards app & Low-Code Apps - Clock components: Clock time would not update when set to server time [ID_35912]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When a clock component (analog or digital) was set to use server time, the clock time would not update.

#### Low-Code Apps: Problem when selecting an action with multiple components after having selected an action with a single component [ID_35947]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When you first selected an action with a single component, which was selected automatically, and then selected an action with multiple components, up to now, both the action selection box and the component selection box would incorrectly be cleared.

#### Low-Code Apps: Page names and panel names could incorrectly be empty [ID_35960]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

Up to now, page names and panel names could incorrectly be empty. From now on, this will no longer be allowed.

#### Dashboards app & Low-Code Apps: Filter box of visualizations panel would not reset [ID_36000]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When you reloaded the editor, by clicking the *Refresh* button while editing a dashboard or by switching pages while editing a low-code app, or when you switched to edit mode after previewing or publishing a low-code app, the filter box of the visualizations panel would incorrectly not be reset.

#### Dashboards apps & Low-Code Apps: Components would incorrectly make their own data available as feeds [ID_36008]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

Up to now, components would incorrectly make their own data available as feeds.

#### Dashboards app & Low-Code Apps - Table component: 'Restore initial view' button would incorrectly remain visible when switching to an empty query [ID_36010]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When, in a table component, you switched from a non-empty query to an empty query, the *Restore initial view* button would incorrectly remain visible in the component header.
