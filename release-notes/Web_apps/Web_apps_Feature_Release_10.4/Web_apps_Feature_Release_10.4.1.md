---
uid: Web_apps_Feature_Release_10.4.1
---

# DataMiner web apps Feature Release 10.4.1

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.4.1](xref:General_Feature_Release_10.4.1).

## Highlights

- [Dashboards app & Low-Code Apps: New Grid and Timeline components [ID_33276] [ID_33287] [ID_34761] [ID_34948] [ID_37269] [ID_37699] [ID_37812]](#dashboards-app--low-code-apps-new-grid-and-timeline-components-id_33276-id_33287-id_34761-id_34948-id_37269-id_37699-id_37812)
- [Dashboards app & Low-Code Apps - Table component: Customizing the appearance of a column [ID_37522]](#dashboards-app--low-code-apps---table-component-customizing-the-appearance-of-a-column-id_37522)
- [Low-Code Apps: Duplicating low-code apps [ID_37698] [ID_37724]](#low-code-apps-duplicating-low-code-apps-id_37698-id_37724)
- [Dashboards app & Low-Code Apps: Duplicating GQI queries [ID_37739]](#dashboards-app--low-code-apps-duplicating-gqi-queries-id_37739)
- [Dashboards app & Low-Code Apps: Configuring custom operators [ID_37840]](#dashboards-app--low-code-apps-configuring-custom-operators-id_37840)

## New features

#### Dashboards app & Low-Code Apps: New Grid and Timeline components [ID_33276] [ID_33287] [ID_34761] [ID_34948] [ID_37269] [ID_37699] [ID_37812]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

Two new components are now available:

- the *Grid* component, which allows you to visualize and manage data as a grid, and
- the *Timeline* component, which allows you to visualize scheduled tasks and events on a timeline.

To both components, add a data feed and, optionally, a filter feed.

In additional to the normal layout options, you can use the Template Editor to fully customize these components as to appearance and behavior.

> [!NOTE]
>
> - The *Grid* component supports real-time row updates. This feature can be enabled by selecting the *Data retrieval > Update data* option.
> - The number of items that can be displayed in a grid component is limited to 1000.
> - If the number of items to be displayed exceeds the number of cells displayed in the component, navigation buttons are available to navigate through the data.
> - When the scaling of the cells is set to a fixed size and there are too many columns and/or rows to show them at once in the component, in read mode, it is possible to scroll through them with a scrollbar that becomes visible when you hover over the component.

#### Dashboards app & Low-Code Apps - Table component: Customizing the appearance of a column [ID_37522]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

When editing a table component, you can now find a *Column appearance* section in the *Layout* tab. This section allows you to customize the appearance of a column.

To change the appearance of a column using presets, in the *Column appearance* section, do the following:

1. In the selection box, select the column of which you want to change the appearance.
1. Click the preview to expand a list of available presets.
1. Select the preset that you want to be applied to the column.

   Available presets:

   - *Left*: Align the content to the left.
   - *Center*: Align the content in the center.
   - *Right*: Align the content to the right.
   - *Icon*: Display an icon instead of text.
   - *Link*: Make the text appear as a link.
   - *Background*: Add a background color to the cell.

   To tweak the preset you selected, click the ellipsis button (*...*) and select *Edit preset*. This will open the template editor, which will allow you to fully customize the column appearance.

> [!NOTE]
>
> - To resize the columns of a table, drag the edges of the column headers, and to change the order of the columns, drag the column headers to a different position. To change the default column width, use the template editor.
> - When you add a table component to a low-code app, the template editor will also allow you to configure actions that will be executed when a shape in a column is clicked or when a row is double-clicked.
> - In the *Parameter table* component, the default column alignment is now "Left" instead of "Center".
> - The default alignment of GQI table columns is now "Left" for columns of type string and "Right" for columns of type numeric or date.

#### Interactive Automation scripts: Certain components can now be visualized as read-only in web environments [ID_37659]

<!-- MR 10.5.0 - FR 10.4.1 -->

*UIBlockDefinition* now has an *IsReadOnly* option, which is set to false by default. When set to true, and when the interactive Automation script is executed in a web environment, the following UI components will now be displayed read-only:

- Calendar
- Checkbox
- CheckboxList
- Dropdown
- Numeric
- RadiobuttonList
- TextBox
- Time
- Treeview

> [!NOTE]
>
> - Although read-only HTML components look as if they are read-write, users will not be able to change their value.
> - When a component has its *IsEnabled* option set to false and its *IsReadOnly* option set to true, it will be considered disabled. Except for components of UIBlockType *Treeview*. These will behave as enabled and read-only.
> - When an interactive Automation script is executed in DataMiner Cube, the *IsReadOnly* option will be ignored.

#### Low-Code Apps: Duplicating low-code apps [ID_37698] [ID_37724]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

There are now two ways to duplicate a low-code app:

- **On the landing page of a DataMiner Agent:**

  1. Hover over the application that you want to duplicate. An ellipsis ("...") button will appear.

  1. Click the ellipsis ("...") button to open the context menu.

  1. Select *Duplicate*.

  The most recently published app version will now be duplicated. If the app has not yet been published, its draft version will be duplicated instead.

  The newly created duplicate will be assigned a unique name and will automatically be opened in a new browser tab. On the root page, this new app will be added to the list if the *Show draft applications* option is enabled.

- **On the Application page:**

  1. Open the app version you want to duplicate:

     - To duplicate the most recently published version of the app, open the app.

     - To duplicate the current draft version of an app, open the app and go to edit mode.

     - To duplicate a different version:

       1. In the top-right corner, click the user icon and select *Versions*.

       1. Select the desired version.

  1. In the top-right corner, click the user icon, and select *Duplicate* in the user menu.

     The current draft version will be copied and the newly created app will automatically be opened in a new browser tab.

  > [!NOTE]
  > You are only allowed to duplicate an older version of an app if you have permission to edit the app in question.

#### Dashboards app & Low-Code Apps: 'Text input' and 'Numeric input' components can now be fed data from other components and from the URL [ID_37736]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

*Text input* and *Numeric input* components can now be fed data from other components as well as from the URL.

To feed a component from the URL, you need to link the component to the URL feed of the correct type, and use the query parameters of the dashboard or app. See the following example:

`?data={"feed": {"strings": ["data for url feed"], "numbers": [1]}}`

#### Dashboards app & Low-Code Apps: Duplicating GQI queries [ID_37739]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

It is now possible to duplicate a GQI query:

1. In the *Data* tab, open the *Queries* section, and click the ellipsis ("...") button of the GQI query that you want to duplicate.
1. In the context menu, select *Duplicate*.

#### Low-Code Apps: New Edit and Delete commands in app context menu of Root page [ID_37830]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

When, on the Root page of a DataMiner Agent, you hover over an application and click the ellipsis ("...") button, the context menu will now include an *Edit* command as well as a *Delete* command.

#### Dashboards app & Low-Code Apps: Configuring custom operators [ID_37840]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

In the query builder, it is now possible to configure custom operators without having to first enable the *GenericInterface* soft-launch option.

On [docs.dataminer.services](xref:docs_dataminer_services), you can find a number of examples showing you how to work with custom operators:

- [Creating a minus operator](xref:Creating_Minus_Operator)
- [Building a GQI custom operator that calculates a duration](xref:Creating_Duration_Operator)
- [Optimizing your custom operator](xref:Custom_Operator_Tutorial)

## Changes

### Enhancements

#### Dashboards app: Selection box data for 'All available data' tab will no longer automatically be retrieved when you enter edit mode [ID_37706]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

Up to now, as soon as you entered edit mode, the client would send a number of requests in order to retrieve all data needed to populate the selection boxes on the *All available data* tab.

From now on, the client will only send a request the moment you open a particular selection box on the *All available data* tab.

#### Dashboards app: User and user group information will no longer automatically be retrieved when you enter edit mode [ID_37727]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

Up to now, as soon as you entered edit mode, a number of API calls were executed in order to retrieve user and user group information.

From now on, those API calls will only be executed the moment you open the *Settings* tab on the right.

#### Dashboards app & Low-Code Apps: Enhanced About box [ID_37757]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

A number of enhancements have been made to the About box.

#### Dashboards app & Low-Code Apps - State component: Alignment setting will now always be displayed [ID_37918]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

Up to now, the *State* component's *Alignment* setting would only be displayed when the *Design* setting was not set to "Auto Size". From now on, the *Alignment* setting will always be displayed.

### Fixes

#### Low-Code Apps: Panels would not stack in the correct order [ID_37696]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

Panels would not stack in the correct order. From now on, they will stack in the order in which they were opened, and panels opening as pop-up windows will always stack on top of the left/right panels.

#### Low-Code Apps: Initials would be displayed instead of user icon in edit mode [ID_37700]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

In edit mode, the user's initials would be displayed instead of the user icon.

> [!NOTE]
> In all DataMiner web apps, the user's initials will be displayed until the user icon has been retrieved.

#### Web APIs: Changes made to a user's access level would not be applied immediately [ID_37730]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

When the access level of a user was changed, up to now, that change would not immediately get applied to existing Web API connections.

#### Dashboards app - Clock component: DataMiner time would be displayed instead of local time (and vice versa) [ID_37750]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

When, in the settings of a *Clock* component, you had specified that it had to display the current DataMiner time (i.e. the time of the DataMiner server to which you are connected), the component would incorrectly display the local time (i.e. the DataMiner client time), and vice versa.

#### Dashboards app & Low-Code Apps: Problems with certain component settings [ID_37829]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

A number of component settings no longer worked.

| Component | Problem |
|-----------|---------|
| Alarm table | Time span, window size, window refresh and group by would no longer work. |
| Button      | Custom success message would always be hidden. |
| Clock       | Time zone selection box would be disabled. |
| Timeline    | Highlighting the time range via feed did not disable the time range selection. |
| Trigger     | Time description and timer refresh would always be hidden. |
| Web         | Text area would always be hidden. URL input would be hidden depending on the type. |

#### Dashboards app & Low-Code Apps: Problem when a 'Line & area chart' component was linked to a query [ID_37863]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

When, in the Dashboards app or a low-code app, a *Line & area chart* component was linked to a query, in some cases, the entire app could become unresponsive.

#### Dashboards app - Table component: Header options would not be initialized correctly after an error message had been displayed [ID_37869]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

After the table component had displayed an error message, the header options would not be initialized correctly.

For example, it would incorrectly be possible to select *Export to CSV* even when the table component displayed an error.

#### Low-Code Apps: Newly added themes seemed to disappear [ID_37871]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

Newly added themes seemed to disappear when opening the theme editor or when switching to another page. This was due to newly added themes not being correctly added to the theme cache.

#### Web Services API: Problem with GetServicesForFilter method [ID_37901]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

In some cases, the filter passed to the *GetServicesForFilter* method would not get deserialized correctly, causing an exception to be thrown.

#### Dashboards app & Low-Code Apps: Problem when opening the query data set [ID_37920]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

When, during a session, you opened the query data set for the first time, a run-time error would be thrown when there were no queries.

#### Dashboards app - Parameter table component: Filter could incorrectly be duplicated [ID_37928]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

It would incorrectly be possible to duplicate the filter of a *Parameter table* component. The *Duplicate* option has now been removed.

#### Dashboards app & Low-Code Apps: Problem when editing the property of a feed linked to a query row [ID_37947]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

When you tried to edit the property of a feed linked to a query row, the input box would incorrectly not display the existing value.

#### Dashboards app & Low-Code Apps - Node edge graph component: Problem when filtering and analytical coloring [ID_37982]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

In some cases, the node edge graph component would not apply filtering and/or analytical coloring correctly when the data contained parameters and the graph was filtered using a query filter.

#### Dashboards app & Low-Code Apps: Problem when opening the DOM Definitions or DOM Instances datasets on a system without Elasticsearch/OpenSearch [ID_37997]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

When the *DOM Definitions* or *DOM Instances* datasets were opened on a system that did not have Elasticsearch or OpenSearch installed, an error would be thrown.
