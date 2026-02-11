---
uid: Web_apps_Feature_Release_10.4.5
---

# DataMiner web apps Feature Release 10.4.5

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.4.5](xref:General_Feature_Release_10.4.5).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.5](xref:Cube_Feature_Release_10.4.5).

## Highlights

- [Dashboards app & Low-Code Apps - Node edge graph component: New features & enhanced performance [ID 38974]](#dashboards-app--low-code-apps---node-edge-graph-component-new-features--enhanced-performance-id-38974)
- [Dashboards app & Low-Code Apps: Client metric logging [ID 39000]](#dashboards-app--low-code-apps-client-metric-logging-id-39000)
- [Low-Code Apps - Timeline component: Interactive timeline events and component actions [ID 39254]](#low-code-apps---timeline-component-interactive-timeline-events-and-component-actions-id-39254)

## Breaking changes

#### Low-Code Apps: Parameters of a script action linked to an empty feed will now be filled with an empty array [ID 39027]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, when a script parameter of a *Launch a script* action was linked to a feed, that parameters would be set to null when the feed was empty.

From now on, linking a script parameter to an empty feed will fill it with an empty array instead. The dialog to manually enter a parameter will no longer be shown when the action is launched. This change can break existing implementations when it is not handled by the script.

## New features

#### Dashboards app & Low-Code Apps - Node edge graph component: New features & enhanced performance [ID 38974]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->
<!-- For fixes in RN 38974, see Fixes section below -->

A number of new features have been added to the node edge graph component:

- In low-code apps, a new node edge graph action can now be used: *Clear the data*. When executed, this action will clear the feed status of the node edge graph in question.
- Similar to other GQI components, a node edge graph is now able to recover selections (coming from the URL or when navigating between pages in low-code apps).
- You can now force edge labels to become fully visible by pressing *Ctrl+Space*.

Also, because of a number of enhancements, overall node edge graph performance has increased.

#### Dashboards app & Low-Code Apps: Web component and Text component can now be linked to a feed [ID 38993]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Both a web component and a text component can now be linked to a feed.

In case of a web component:

- When *Type* is set to "Custom HTML", the feed syntax can be inserted in the HTML code.
- When *Type* is set to "Webpage", the feed syntax can be inserted in the URL.

In case of a text component, the feed syntax can be inserted in the text.

> [!TIP]
> For more information on feeds, see [Component data](xref:Component_Data).

> [!NOTE]
>
> - When linking a feed to either a web component or a text component in a dashboard, *Source name* needs to be omitted.
> - Limitations:
>  
>   - When you set a web component to "Custom HTML", the *HTML* box is limited to 100,000 characters. HTML syntax highlighting will be disabled from 15,000 characters onwards.
>   - When you set a web component to "Webpage", the *URL* box is limited to 2,000 characters.
>   - The text box of a text component is limited to 200,000 characters.

#### Dashboards app & Low-Code Apps: Client metric logging [ID 39000]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

In the `C:\Skyline DataMiner\Logging\Web` folder, apart from Web API logging, you can now also find client metric logging.

Client metric logging is employed to record different performance and issue indicators of clients connecting to Dashboards and Low-Code Apps. These logs encompass everything from unexpected errors to the load time of a dashboard or low-code app page. This logging data is stored in the `Client` subfolder of the web logs.

> [!TIP]
> For more information, see [Dashboards and Low-Code Apps logging](xref:Dashboards_and_Low_Code_Apps_Logging).

#### Low-Code Apps - Timeline component: Interactive timeline events and component actions [ID 39254]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When setting up a Timeline component, you can now configure actions to be performed when certain events occur in the component.

##### Events

The following events are supported:

| Event | Action that triggers the event |
|---|---|
| Range select | Selecting a section of the timeline using the right mouse button. |
| Item resize  | Extending or shrinking an item on the timeline. |
| Item move    | Changing the time slot of an item on the timeline. |
| Group change | Moving an item on the timeline to another group. |

> [!NOTE]
>
> - The above-mentioned events can only be triggered when they have actions configured. For example, an item will only be resized when at least one action has been configured for the *Item resize* event.
> - While the *Range select* event is timeline-based, other events can have a different configuration for each query on the timeline. For example, if there are multiple queries on the timeline, and you move an item belonging to a certain query, the timeline will look at the configuration of actions for the *On move* event of that specific query to decide what actions to execute.

> [!TIP]
> When interacting with the timeline, you can now use the following keys:
>
> - *ESCAPE*: When you click this key while interacting with an item on the timeline, you will cancel the interaction and move the item back to its original place.
> - *SHIFT*: When you keep this key pressed while moving an item on the timeline, the movement will be more precise.
> - *CONTROL*: When you move an item horizontally, a larger movement is needed to also make it move vertically (and vice versa). If you want to override this default behavior and move the item with precision, both vertically and horizontally, then keep this key pressed.

##### Actions

When a Timeline component is used in a low-code app, it is now also possible to configure the following component actions:

| Action | Function |
|--------|----------|
| Fetch the data | Fetches the data for the component.<br>This action was already available as from Dataminer 10.2.10/10.3.0 for all components using query data as input. |
| Highlight time range | Highlights a range on the timeline component.<br>The highlighted section will expose a feed in the form of a *Timespan* object. If multiple sections are highlighted, the feed will contain an array of *Timespan* objects. |
| Clear highlights | Clears all highlights set by *Highlight time range* actions.<br>Prior to DataMiner 10.4.5, highlights could already be configured using the *Highlight range* setting. This setting is still available and can be used in combination with highlights set by actions. Its behavior remains the same: a highlight set by the *Highlight range* setting will not expose a feed and it will not be cleared by the *Clear highlight* action. |
| Set viewport | Sets the viewport of the timeline to a certain time range. |

> [!NOTE]
>
> - Before, it was already possible to [link the value of certain inputs to a feed](xref:LowCodeApps_event_config). From now on, you will be able to link these values to information provided by the event in a similar way. All timeline events expose information relevant to the event in question. The following information is provided for each event:
>
>   - *Range select*: Provides a *from* and a *to* property, both of type *Timespan*.
>   - *Item resize*: Provides an old and a new *Timespan* pair, indicating the start and the end of the item before and after the resize event. it also provides information about the resized item in the form of a *Query row* object.
>   - *Item move*: Provides the same information as the *Item resize* event.
>   - *Group change*: Provides information about the current state of the item and the new state, both as *Query row* objects.
>
> - The existing line & area chart component action *Set timespan* has now been renamed *Set viewport* in order to be consistent with the *Set viewport* action described above.

## Changes

### Enhancements

#### Web apps - DataMiner Object Models: Enhanced behavior of DOMInstanceFieldDescriptor and DomInstanceValueFieldDescriptor fields on DOM forms when not all possible values have been retrieved yet [ID 38719]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

A number of enhancements have been made with regard to the way in which `DOMInstanceFieldDescriptor` and `DomInstanceValueFieldDescriptor` fields are displayed on DOM forms when not all possible values have been retrieved yet.

Up to now, as long as not all values of a dropdown box had been retrieved, its label and its border would be highlighted in orange as a warning. From now on, this will only occur when the dropbox box in question has the focus.

#### Dashboards app & Low-Code Apps - Query filter component: Enhanced button coloring [ID 38754]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, the buttons in the query filter component would be barely visible when the color of the app was similar to the background color of the theme. From now on, the buttons in the query filter component will always have the text color of the theme.

#### Dashboards app & Low-Code Apps: Grouping of GQI event messages [ID 38959]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

From now on, GQI event messages sent by the same GQI session within a time frame of 100 ms will be grouped into one single message.

#### Dashboards app & Low-Code Apps: Template editor will now inherit the background color of the component [ID 38996]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

From now on, the template editor will inherit the background color of the component. This will enhance overall visibility regardless of the chosen theme.

#### Web apps: Enhanced performance when starting up [ID 38999]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when starting up a DataMiner web app.

#### Landing page - Other apps: No longer possible to right-click apps on mobile devices [ID 39036]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When you open the landing page of a DataMiner Agent (e.g. `https://myDMA/root/`) on a mobile device, it will no longer be possible to open the context menu of apps listed in the *Other apps* section.

#### Web apps - Authentication: Enhanced multi-domain support [ID 39061]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Multi-domain support has been enhanced.

Up to now, on systems with multiple domain controllers, in some cases, users would not be able to log in to a web app with the user name that was known to the system, listed at the bottom of the *Sign in* box. The latter was linked to another domain than the one linked to the user name with which they were logged in.

#### Legacy Reporter: Clearer message in case of an 'out of memory' error [ID 39089]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When an "out of memory" error was thrown in the legacy Reporter, up to now, an "Unspecified error: 12" message would be displayed. From now on, when an "out of memory" error is thrown, a clearer, more informative message will be displayed instead.

### Fixes

#### Mobile Visual Overview: Problem when trying to open a popup linked to a single-page visual overview of another object [ID 38793]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When, in a visual overview opened on a mobile device, you tried to open a popup linked to a single-page visual overview of another object, the popup would incorrectly refuse to open.

#### Dashboards app & Low-Code Apps - Stepper component: Problem when two states were able to transition to each other [ID 38820]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When a stepper component has to display states of a DOM definition for which no DOM history records are being saved, it relies on the states and transitions within the DOM behavior definition to build the steps.

Up to now, when two states were able to transition to each other, an infinite loop would occur, causing the browser to become unresponsive.

#### Dashboards app & Low-Code Apps - Dropdown component: Filter would no longer be applied after losing the focus [ID 38834]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When a dropdown component with a filter applied lost the focus, the moment it had the focus again, the filter would no longer be applied.

#### Dashboards app & Low-Code Apps - Interactive Automation scripts: Values would not get updated when the focus changed [ID 38838]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When, in an interactive Automation script run from a dashboard or a low-code app, you had changed a value, that value would incorrectly not get updated when the focus changed.

#### Dashboards app: Problem with Dropdown components on shared dashboards [ID 38953]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When, on a shared dashboard, a dropdown component had a time range or service definition filter applied, it would not be possible to use that component.

#### Dashboards app & Low-Code Apps - Node edge graph component: Issues fixed [ID 38974]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->
<!-- For new features & enhancements in RN 38974, see New features section above -->

A number of issues related to Node edge graph component have been solved:

- When a node edge graph was linked to the query filter, in some cases, the filter would not be applied correctly for nodes/edges that were not visible in the view. Panning towards those nodes/edges would then show them as hidden/visible while they should be visible/hidden.
- Up to now, a node edge graph would incorrectly reset its viewport when the query or filter had changed.
- In some cases, the edge coloring/highlighting would incorrectly not be applied for parameters with very small numeric values.

#### Web apps: Context menu would not close when scrolling on a mobile device [ID 38992]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When, on a mobile device, you scrolled while a context menu was open, that context menu would incorrectly not close.

#### Dashboards app & Low-Code Apps - Timeline component & Time range component: Problem when the default range was set to '... so far' [ID 39056]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When you had set the default range of a timeline component or a *Time range* component to "This week so far", "This month so far" or "This year so far", in some cases, the default range would incorrectly revert to "Today so far" when the configuration of the component was saved.

Also, in some cases, a timeline component or a *Time range* component would not get visually updated when the default range was set to a different value.

#### Dashboards app: Tables in PDF files would incorrectly get added a scroll bar [ID 39059]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Tables in PDF files would incorrectly get added a scrollbar.

#### Dashboards app & Low-Code Apps: Focus order of buttons in popup windows would be incorrect [ID 39080]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

In some cases, the focus order of buttons in popup windows would be incorrect. From now on, when a popup window contains an action button, it will get the focus. If no action button is present, then the first non-danger button will get the focus.

> [!NOTE]
> Danger buttons will never get the focus.

#### Dashboards app & Low-Code Apps: Protocol versions of mediation protocols would incorrectly not be production versions [ID 39094]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When, in the *DATA* pane, you opened the *PARAMETERS* section, set the *From* box to "Protocol", and opened the *Protocol* box, the protocol versions of mediation protocols would incorrectly not be the production versions that were actually used.

#### Web apps: Disconnection message would not disappear after the WebSocket connection had been restored [ID 39095]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When a web app loses its WebSocket connection, a `Connection has been interrupted` message is displayed in the app's subheader. In some cases, that message would incorrectly not disappear once the WebSocket connection was restored.

From now on, a message will also be displayed in the app's subheader when not all messages received when the app was disconnected could be recovered. That same message will ask the user to refresh the app.

#### Dashboards app & Low-Code Apps - Time range component: Custom time zone would not be used when selecting 'Now' in the time picker [ID 39171]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, when you had set a custom time zone for web apps, that time zone would incorrectly not be used when you selected *Now* in the time picker of a *Time range* component.

> [!TIP]
> See also: [Setting the default time zone for DataMiner web apps](xref:ClientSettings_json#setting-the-default-time-zone-for-dataminer-web-apps)

#### Dashboards app & Low-Code Apps - Table, Grid, Timeline & Maps components: Template previews would not show the background color of the component [ID 39183]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

In the *Template Editor*, up to now, template previews would not show the background color of the component. As this could lead to confusion when previewing templates without background shapes, all previews will now have the same background color as the component in which they will be used.

> [!NOTE]
> At present, the maps component is only available in preview, if the soft-launch option *ReportsAndDashboardsGQIMaps* is enabled. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

#### Dashboards app: Not possible to duplicate a dashboard with the same name to another folder [ID 39190]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, you were not allowed to duplicate a dashboard with the same name to a different folder. From now on, you will be allowed to do so.

#### Dashboards app & Low-Code Apps: 'Select a visualization' button would not be displayed [ID 39194]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When, in edit mode, you clicked a component or hovered the mouse pointer over it, the *Select a visualization* button would incorrectly not be displayed when you dragged query row data from the feed section onto the dashboard or the low-code panel you were editing.

#### Dashboards app: Popup window would not open immediately when you selected 'Create dashboard', 'Duplicate dashboard' or 'Settings' [ID 39223]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, when you right-clicked a dashboard in the left pane, and selected *Create dashboard*, *Duplicate dashboard* or *Settings*, the corresponding popup window would not open immediately. From now on, it will open straight away.

#### Web apps - Color picker: Moving the color slider would not be possible when the color was set to RGB 0/0/0 [ID 39227]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When you opened the color picker and the color was set to a grey color (i.e. RGB 0/0/0), it would not be possible to select another color by moving the color slider.

#### Low-Code Apps: Refreshing an app would cause it to redirect the user to the root page instead of the authentication page [ID 39231]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When you refreshed a low-code app while the connection was lost, the app would incorrectly redirect you to the root page (e.g. `https://myDma/root/`) instead of the app's authentication page.

#### Low-Code Apps: Draft version of an app could incorrectly be opened via the URL of the published version [ID 39242]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, it would incorrectly be possible to open a draft version of a low-code app via the URL of the published version, even when that draft version had not yet been published.

From now on, for example, it will be possible to navigate to `https://{MYDMA}/app/draft/{APPID}/Page?v=4`, but no longer to `https://{MYDMA}/app/{APPID}/Page?v=4`.

#### Low-Code Apps: Feeds would incorrectly not be reset when you previewed a low-code app [ID 39276]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, when you previewed a low-code app, all feeds would incorrectly not be reset. From now on, all feeds will be properly reset when you preview a low-code app.

#### Dashboards app - Timeline component: The content of a template could go out of the bounds of the timeline item [ID 39389]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 [CU0] -->

In a timeline component, in some cases, the content of a template could go out of the bounds of the timeline item. From now on, the template content will be cropped so that it stays without the bounds of the timeline item.

#### Problem when trying to log in to a web app [ID 39397]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 [CU0] -->

When users tried to log in to a web app, in some cases, an `Object reference not set to an instance of an object` error could be thrown.
