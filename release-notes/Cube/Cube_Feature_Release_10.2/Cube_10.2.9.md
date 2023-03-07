---
uid: Cube_Feature_Release_10.2.9
---

# DataMiner Cube Feature Release 10.2.9

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.2.9](xref:General_Feature_Release_10.2.9).

## Highlights

#### Trending: Prediction type selection has now moved to the context menu [ID_33861]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

In a trend graph, up to now, a drop-down list in the top-right corner allowed you to select one of the available trend prediction types or "Auto". This drop-down list has now been removed. Instead, you can now right-click the graph and select one of the available trend prediction types or "Auto" from the context menu.

#### Tab layout: Closing a card tab by clicking it with the middle mouse button [ID_33883]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When the card layout is set to "tab layout", you can now close a card tab by clicking it with the middle mouse button.

#### Password box with strength indicator and peek button [ID_33937]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Password boxes in Cube will now indicate the password strength (common, very weak, weak, good, strong, very strong) based on a scoring algorithm and a dictionary of default and well-known passwords. They will also have a peek button that allows you to temporarily reveal the password you have entered.

These new password boxes can be found in the following locations:

- Cube login screen (peek only)
- Data Display: parameters of type password (e.g. the password box of a Microsoft Platform element)
- Edit port settings of an SNMPv3 element
- System Center > Agents > Add
- System Center > Database
- System Center > Users/groups > Add new user... (peek only)
- System Center > System Settings > Credentials Library
- System Center > System Settings > LDAP
- Interactive Automation scripts (`UIBlock` of type "PasswordBox")

> [!NOTE]
>
> - If a value received from the server has been automatically entered in a password box, the strength indicator and peek button will not be available until you enter a completely new password.
> - If the value received from the server is a fixed 8-asterisk-long placeholder instead of an actual password, you will not be able to modify it. You will be forced to replace the entire value.

#### New 'Light' theme & new links in the Apps list [ID_33944]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

A new theme has been added to DataMiner Cube: "Light".

Also, the Apps list now contains links to the Catalog, the Admin app, and custom web apps.

#### Visual Overview - Conditional shape manipulation: Using statistics in the condition when the shape is linked to an EPM object [ID_34026]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When applying conditional shape manipulation actions to a shape, up to now, it was only possible to use statistics in the condition if the shape was linked to an element, a service or a view. From now on, you can also use statistics in the condition when the shape is linked to an EPM object.

Example in which both the SystemName and the SystemType are linked:

```txt
<A>-A|SystemType= Cable;SystemName=SF Cable1|#TotalAlarms|>0
```

Supported statistics:

- #TotalAlarms
- #CriticalAlarms
- #MajorAlarms
- #MinorAlarms
- #WarningAlarms
- #NormalAlarms
- #TimeoutAlarms
- #NoticeAlarms
- #ErrorAlarms

Supported operators:

- =
- !=
- \>
- \>=
- \<
- \<=

## Other new features

#### Alarm Console - Incident tracking: Some types of alarms can now be manually added to incidents even when they do not contain any focus data [ID_33771] [ID_33803]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Up to now, alarms that did not contain any focus information were not allowed to be the base alarm of an incident. From now on, alarms that do not contain any focus data can be manually added to an incident, provided they are not one of the following types of alarms:

- correlation alarms
- clearable alarms
- information events
- suggestion events
- other incidents

#### Browser callbacks can now open EPM objects via SystemName or SystemType [ID_33963]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When an embedded web page is displayed in Cube, it is possible to make a callback from the web page into Cube and, for example, open an element, service, view or CPE card.

The existing JavaScript web browser callbacks for browser shapes in Visual Overview have now been extended to allow opening an EPM card in Cube via an object's SystemName or SystemType using the following method:

```txt
NavigateCPEByName(string systemType, string systemName);
```

Example in HTML:

```html
<a href='javascript:window.external.NavigateCPEByName("Region","California");'>Open Region California</a>
```

## Changes

### Enhancements

#### Alarm Console: Time of history sets will now always be converted to the local time zone [ID_33849]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

From now on, the time of history sets will always be converted to the local time zone.

#### Data Display: More separator replacement options when specifying a SystemName containing colons in an EPM object link [ID_33857]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Since DataMiner version 10.2.3, there is a new way of adding links to EPM objects in a Data Display table. When, in a protocol, you configure a cell button as shown below, the table cell will display the SystemType and SystemName defined in the EPM object. Clicking the link will open a new card for that object.

Example:

```xml
<Measurement>
    <Type>button</Type>
    <Discreets>
        <Discreet>
            <Display>{linkedItemName}</Display>
            <Value type="open">{pid:530}</Value>
        </Discreet>
    </Discreets>
</Measurement>
```

The discreet value can contain the SystemType and SystemName of the object, or a reference like "{pid:530}".

If you know the type of the EPM object, you can add a type prefix (epm or view), followed by an equal sign and (a reference to) the identifier, and if you want to specify the page to be selected by default, you can add a suffix to the identifier in the `<Value>` tag containing the root page name and the page name, separated by a colon.

If the SystemName contains colons (e.g. a MAC address), you can replace the default separator (i.e. colon) by another one (e.g. a pipe character) by placing a `[sep:XY]` prefix in front of the system name. See the following example:

```xml
<Value type="open">{EPM=[sep::|]CPE/00:01:08:01:08:01|DATA|CPE Frequencies}</Value>
```

From now on, you can specify a second custom separator to also replace the existing separator inside the SystemType and/or SystemName. Since the default separator between the SystemType and the SystemName is "/", this would mean that neither the systemType nor the SystemName would be allowed to contain that character ("/").

In the following example, a second `[sep:XY]` is used to replace the "/" inside the SystemType ("CPE/CPE") with another character ("$").

```xml
<Value type="open">{EPM=[sep::|][sep:/$]CPE/CPE$00:01:08:01:08:01|DATA|CPE Frequencies}</Value>
```

In short,

- the first `[sep:XY]` will replace the separator between the arguments, and
- the second `[sep:XY]` will replace the separator inside the SystemType and/or SystemName.

> [!NOTE]
> If you want to replace the separator inside the name, you must specify both the first `[sep:XY]` and the second `[sep:XY]`, even if there are no arguments.

#### Alarm Console - Proactive cap detection: Reduction of false positive matches [ID_33871]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When trend data is often getting close to the low or high value of a data range, this data range value will no longer be considered as a critical data boundary. This will reduce the number of false positive matches.

#### Automation app: Casing of a script name can now be changed [ID_33988]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

In the Automation app, it is now possible to change the casing of a script name.

Also, if you change the casing of a script name that was selected, it will remain selected.

#### Alarm Console: A run-time error will now appear when the Resource Manager failed to initialize [ID_34024]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

From now on, the following run-time error will appear in the Alarm Console when the Resource Manager failed to initialized.

```txt
An unexpected exception has occurred while initializing Resource Manager. Please check the SLResourceManager logging for more information.
```

#### Start window enhancements [ID_34033]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

A number of enhancements have been made to the DataMiner Cube start window:

- When you hover over a cluster tile, a tooltip will now appear, showing the cluster name, the cluster alias, the hostname of the agent and the last-known server version (if any). The latter will be updated when you connect to the cluster in question and when an update occurs in the background.

    > [!NOTE]
    > Cluster tiles will no longer display the hostname of the agent if it is identical to the cluster alias.

- When using the search box to filter the tiles, the last-known server version will now also be checked. This will allow users to search for clusters with a specific server version.

- When you check for updates (by clicking the cogwheel icon in the bottom-right corner and selecting *Check for updates*), the last-known server version will now be taken into account to avoid having to contact every configured cluster. If a DataMiner Agent has been upgraded since the last background update, the new client version will be downloaded from the agent the first time you connect to it or from the cloud during the next background update (if that version is newer that the current version).

    > [!NOTE]
    >
    > - If you hold the SHIFT key when clicking *Check for updates*, a full update will start. Depending on the number of clusters in your configuration, this can take some time.
    > - An update triggered by the *Update DataMiner Cube_ [userID]* task in Windows Task Scheduler will always be a full update.

- When the start window application is downloaded from a DataMiner Agent, the cluster is automatically configured. Up to now, if it was possible to reach the agent via HTTPS within 2 seconds, the cluster was configured as "HTTPS only". However, in some cases, 2 seconds was too short, resulting in HTTPS agents being configured as "HTTP or HTTPS". From now on, the start window application will wait up to 5 seconds.

- When you add a new cluster, it will now always be added to the group containing the currently selected cluster.

- The maximum size of the daily log file has been increased from 1 MB to 100 MB.

### Fixes

#### DataMiner Cube - Profiles app: Selected list items not visible on the UI would incorrectly not be validated after being edited [ID_33753]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When, in the *Profiles* app, you edited a profile definition, a profile instance, a profile parameter or a service definition, the change would incorrectly not be validated if the item in question was not visible in the list.

#### DataMiner Cube - Profiles app: No validation errors were displayed when no discrete values had been added yet for a profile parameter of type discrete [ID_33756]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When an error occurred while configuring a profile parameter of type "discrete", up to now, that error would not be displayed on the UI when no discrete values had been added yet.

#### Resources app: Warning messages were incorrectly shown in the footer when resource manager configuration requests returned error trace data [ID_33780]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When you open the *Resources* app, a warning will be shown in the footer when error trace data was found when fetching resource manager data from the server. Up to now, such a warning would incorrectly also be shown when resource manager configuration requests returned error trace data.

#### Alarm Console: Problem when performing a right-click command on two or more alarm groups [ID_33783]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->
<!-- Not added to 10.3.0 -->

When you selected two or more alarm groups, and selected *Clear alarm*, *Take ownership*, *Release ownership* or *Add comment* from the right-click menu, the operation would fail.

#### Resources app: Updating a session variable in a Resource Manager component would incorrectly cause that same session variable to be updated in the Occupancy tab of the Resources app [ID_33800]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When a session variable (e.g. YAxisResources) was updated in an embedded Resource Manager component, in some cases, that same session variable would also incorrectly be updated in the *Occupancy* tab of the Resources app.

#### Alarm Console would incorrectly keep loading while the tickets linked to the alarms were being loaded [ID_33847]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you open DataMiner Cube, it will load the alarms and try to link the existing tickets to them so it can show the ticket information in the Alarm Console.

While this process was ongoing, in some rare cases, the Alarm Console would incorrectly keep on loading.

#### Alarm Console: Problem when loading [ID_33860]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, an exception could be thrown while the Alarm Console was loading.

#### Alarm Console: Cube could become unresponsive when a large number of alarms were being added and removed in an alarm tab of type 'sliding window' [ID_33870]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When, in an alarm tab of type "sliding window", a large number of alarms were being added and removed, in some cases, DataMiner Cube could become unresponsive.

#### System Center: Element counter on Agents > Status tab would not be set to 0 when removing all elements from a DMA [ID_33885]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you go to *System Center > Agents > Status*, the *Elements* column shows you how many elements are being hosted by each agent in the DMS.

When, on a particular agent, you removed all elements, the number of elements of that agent would incorrectly not be set to 0. Instead, it would be set to the last-known number of elements on that agent before the element were removed.

#### Spectrum analysis: Recording icon would no longer be displayed while making a spectrum recording [ID_33904]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

While making a spectrum recording, in some cases, the recording icon would no longer be displayed.

#### Visual Overview: Wait cursor would still be displayed after the scripts had already finished [ID_33911]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When, in Visual Overview, you clicked a shape that executed two Automation scripts, the cursor would incorrectly still be displayed as a wait cursor after the two scripts had already finished.

#### Spectrum analysis: Issues when playing a spectrum recording [ID_33918]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a spectrum recording was being played, the following issues could occur:

- The *Forward* and *Backward* buttons would not work after starting and pausing the recording.
- When you adapted the speed of the recording, the new speed would incorrectly only be applied to the next frame and not to the current frame.
- When the recording was being played, the slider could incorrectly not be used.

#### Problems when exporting tables with an IncludedPids option or with a ClientSideRowFilter [ID_33934]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, tables that had the *IncludedPids* option defined would have their data exported to a CSV file incorrectly.

Also, when a table to which a ClientSideRowFilter was applied was exported to a CSV file, up to now, that filter would not be taken into account.

#### Spectrum analysis: Maximum, minimum and average trace would disappear after skipping backward when playing a spectrum recording [ID_33942]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you play a spectrum recording, you can pause the playback and use controls to skip forward or backward. In some cases, after skipping backward, the maximum, minimum and average trace would incorrectly disappear.

#### DataMiner Cube start window: Problems when selecting a specific Cube version to connect with [ID_33958]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->
<!-- Not added to 10.3.0 -->

When, in the DataMiner Cube start window, you indicated that you wanted to connect to an agent/cluster using a specific Cube version (by selecting *Connect using* in the right-click menu), the default Cube version would incorrectly be used instead.

Also, if the list of available versions contained more than 10 versions, the version provided by the server would incorrectly no longer be listed.

#### Alarm Console: Column list not shown when hovering over the 'Add/Remove column' menu command [ID_33967]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you right-clicked a column header in an alarm tab and hovered over the *Add/Remove column* command, in some cases, the column list would incorrectly not be shown if, previously, you had right-clicked the header of the focus column or a header of an action column.

#### Data Display : Update of parameter unit would not be reflected in the UI when the element card was open [ID_34007]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When an element card was open on the DATA page, and a parameter on that page had its unit changed (e.g. via an Automation script), that change would incorrectly not be reflected in the UI. To see the new unit, you had to close the element card and re-open it.

#### Problem when the Cube starter window software tried to download a DataMiner Cube for a DataMiner Agent v10.0.0 [ID_34009]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->
<!-- Not added to 10.3.0 -->

When the Cube starter window software tried to download a DataMiner Cube for a DataMiner Agent v10.0.0, the following error message would be displayed:

```txt
Something went wrong: Error downloading ClickOnce version: Error downloading manifest file from uri ...
```

#### Problem with validation of properties and actions in service definitions [ID_34023]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When properties or actions of a service definition were configured, it could occur that validation did not happen correctly so that an incorrect configuration could be saved, resulting in exceptions in the server logging and problems in Cube.

The validation will now ensure that no empty names or property names that are incompatible with Elasticsearch can be saved. If there is an error in a service definition, the *Modified* label will change color. Hovering the mouse pointer over the entry with the label will show the first error in the service definition.

#### Connected DMA removed from cluster instead of selected DMA in System Center [ID_34035]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In System Center, when you clicked the *Leave cluster* button on the *Agents* page, this removed the DMA you were connected to from the cluster instead of the selected DMA.

#### EPM: Incorrect alarm color shown for EPM shapes in Visual Overview [ID_34039]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Up to now, to resolve the monitoring state of EPM shapes displayed in Visual Overview, the source table of the EPM front end was used, which could cause an incorrect alarm color to be shown for such shapes. Now, the source table of the back end is used instead, as this is the table the monitoring is applied to.

#### Scheduled task corrupted after it was edited [ID_34084]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When an existing scheduled task that was configured to be executed multiple times per day was edited, it could occur that the task was corrupted and could no longer be executed.

#### No alarms shown with alarm filter on property value filtering the alarms before they entered Cube [ID_34090]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

If an alarm filter that filtered on a property value was used to filter the alarms before they entered Cube, it could occur that no alarms were shown, even if there were alarms matching the filter.

#### Spectrum recording icon not shown while recording [ID_34097]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a spectrum recording is started, an icon should be shown to the right below the trace to indicate that a recording is being created. However, when the mouse pointer was moved outside the trace area, it could occur that this icon was no longer shown.

#### Visual Overview: Non-linked shape without LinkOptions shape data field not displayed [ID_34102]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

If a shape was not linked to a DataMiner object and did not have a *LinkOptions* shape data field, it could occur that the shape was not displayed in Visual Overview.

#### Visual Overview: SurveyorSearchText variable continued to show cleared search input [ID_34114]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.9 -->

When the text in the Cube advanced search box was selected with Ctrl+A and then deleted, it could occur that the advanced search input was not cleared correctly, so that it continued to be shown by the *SurveyorSearchText* variable in Visual Overview.

#### Navigation issue in visual overview with several tab pages and shapes linked to EPM object [ID_34122]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In a visual overview with several tab pages and shapes linked to an EPM object, if you clicked a shape that opened an EPM object, then clicked the Back button, and then clicked a shape to navigate to another tab page in the same visual overview, this did not work.

#### 'Clear all' button not available for EPM topology chain [ID_34133]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you make a selection in an EPM topology chain, a *Clear all* button becomes available, which allows you to clear the selection again. However, in some cases, this button disappeared again. This was specifically the case when you opened a card of a certain level in the chain, closed this card, and then opened another card from the chain, other than the previous card.

#### Visual Overview: Connection highlight based on connection property not updated automatically [ID_34139]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.9 -->

When a connection in Visual Overview was highlighted based on a connection property, and the connection property changed, it could occur that the highlight style was not automatically applied to the connection line, but only after the user triggered a redraw, for example by clicking the highlight.

#### Workspace with EPM view card showed incorrect page when loaded [ID_34163]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you loaded a workspace containing the card of a view linked to EPM, it could occur that the card did not show the page saved in the workspace but instead the default "Visual" page.
