---
uid: Cube_Feature_Release_10.3.6
---

# DataMiner Cube Feature Release 10.3.6

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.6](xref:General_Feature_Release_10.3.6).

## New features

#### Trending: Managing trend patterns in the 'Pattern Overview' window [ID_35694] [ID_36114]

<!-- 35694: MR 10.4.0 - FR 10.3.5 -->
<!-- 36114: MR 10.4.0 - FR 10.3.6 -->
<!-- Both released in MR 10.4.0 - FR 10.3.6 -->

When you right-click a trend graph and select *Trend patterns...*, the *Pattern Overview* window will now appear.

By default, this window will only list the existing patterns that apply to the trend graph you have opened. If you select the *Show all patterns* option, it will list all patterns found in the DataMiner System.

- To update the properties of an existing pattern, select it in the list on the left, update its properties, and click *OK* or *Apply*.

  Apart from changing its name and description, you can also indicate whether you want the pattern to be detected continuously in the background.

- To delete a pattern, click the recycle bin icon next to its name in the list on the left.

When you select a trend pattern from the list on the left, a thumbnail preview of the pattern will be displayed, together with the name of the element and parameter associated with the pattern.

> [!NOTE]
> Currently, this *Pattern Overview* window only supports single-variate patterns. Support for multi-variate patterns will be added in a later release.

## Changes

### Enhancements

#### System Center: Overhaul of LDAP settings [ID_35782]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.6 -->

In *System Center > System settings > LDAP*, you can configure a number of LDAP settings. These settings have had an overhaul.

- In the *General* tab, from now on, you will only be able to set *Authentication type* to either "Anonymous" or "Simple".

  > [!NOTE]
  > When you set *Authentication type* to "Anonymous", the *User name* and *Password* fields will now be disabled. When both fields contain a value, *Authentication type* will by default be set to "Simple".

- In this section, it is now also possible to configure the *nonDomainLDAP* setting. Up to now, this setting could only be configured in the *DataMiner.xml* file.

- When you update LDAP settings, a warning will now appear to notify you that these settings will only be changed on the DataMiner Agent to which you are connected. Changes made to LDAP settings will not be synchronized among the agents in the cluster.

Also, a number of issues have been fixed. Up to now, the value entered in *Use fully qualified domain name (FQDN)* would not be saved to the *DataMiner.xml* file, an incorrect default value would be entered in the *User class name* field, and the value entered in the *Password* field would get lost when the LDAP settings were updated without changing the password.

#### DataMiner Cube desktop app: Unused Cube versions will now automatically be removed [ID_35795]

<!-- MR 10.4.0 - FR 10.3.6 -->

From now on, Cube versions that meet the following conditions will be removed automatically:

- Not marked as the active version for a certain DataMiner Agent.
- Not downloaded recently.
- Not used recently.

#### Trending - Parameter relationships: Light bulb icon is now always displayed in top-right corner of trend graph and has one of three states [ID_35868] [ID_36157] [ID_36199]

<!-- MR 10.4.0 - FR 10.3.6 Also see Fixes-->

In the top-right corner of a trend graph, a light bulb icon was previously only displayed if DataMiner found relations for the parameters shown in the trend graph. From now on, this icon will always be visible, regardless of whether related parameters have been found and whether all necessary requirements for the parameter relationship feature are met. The light bulb icon can now have one of three states:

- Related parameters have been found.
- No related parameters have been found.
- The requirements have not been met.

When related parameters have been found, the light bulb icon will "light up" in an accent color to provide a visual indication of its state.

If any of the mandatory requirements for the parameter relationship feature have not been met, clicking the light bulb icon in the top-right corner of the trend graph will show a message that indicates the requirements are not met.

If any of the optional requirements for the parameter relationship feature have not been met, clicking the light bulb icon in the top-right corner of the trend graph will show a message that advises to unlock all capabilities of this feature.

Both messages are clickable and link to the relevant section of the DataMiner documentation.

#### System Center: Enhancements made to Database > Offload section [ID_36037]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In *System Center*, a few enhancements have been made to the *Database > Offload* section:

- When you set *Type* to "Database", select *Trend data* in the *Offloads* section, and set the frequency under *Enable data offload* to "permanently", the time indication (e.g "starting every day at") will no longer be shown.

- When you set *Type* to "Database" and select *Parameter value* in the *Offloads* section, from now on, you will no longer be able to set the frequency under *Enable snapshot offload* to "permanently".

  > [!IMPORTANT]
  > If, before upgrading to this DataMiner version, *Parameter value* was selected and the frequency was set to "permanently", *Parameter value* will no longer be selected after upgrading. As a result, no snapshot will be offloaded until you reconfigure the snapshot offload settings.

#### Visual Overview: Browser shapes will no longer be reloaded when their URL only had a fragment change [ID_36044] [ID_36104]

<!-- MR 10.4.0 - FR 10.3.6 -->

Up to now, a browser shape would always be reloaded whenever its URL was changed. From now on, this will no longer be the case when the URL only had a fragment change.

Examples:

- When `#https://company.be/#/app/Map` changes to `#https://company.be/#/app/Map#urlfragment`, the browser shape will not be reloaded because the URL only had its fragment changed.

- When `#https://company.be/#/app/Map` changes to `#https://company.be/#/app/Map?embed=true#urlfragment`, the browser shape will be reloaded because the URL not only had its fragment changed but also its query parameter.

#### Alarm Console: Enhanced performance when loading active alarms [ID_36144]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

Because of a number of enhancements, overall performance has increased when loading active alarms.

#### System Center - Database: Warning when a DataMiner Agent in the cluster is offline [ID_36184]

<!-- MR 10.4.0 - FR 10.3.6 -->

In the *Database* section of *System Center*, a warning will now appear whenever a DataMiner Agent in the cluster is offline.

Also, when you click *Save* after changing any of the settings in this *Database* section, a popup message will now appear, saying that the Agents need to be restarted for the changes to take effect.

> [!IMPORTANT]
> No warning will appear to point out that the backup Agent in a Failover setup is offline.

### Fixes

#### Trending - Parameter relationships: Light bulb icon would not appear if ModelHost DxM stopped working [ID_35868]

<!-- MR 10.4.0 - FR 10.3.6 Also see enhancements -->

The light bulb icon would not be displayed in the top-right corner of a trend graph if the ModelHost DxM stopped working after Cube had already been started.

#### Problem when connecting to a DataMiner Agent using gRPC [ID_35950]

<!-- MR 10.4.0 - FR 10.3.6 -->

In some cases, DataMiner Cube would fail to connect to a DataMiner Agent using gRPC, especially when a large number of clients were connecting to that same agent.

#### Renaming an Automation script would cause its actions to be loaded twice in the UI [ID_35964]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When, in DataMiner Cube, you renamed an Automation script with at least one action, in some rare cases, those actions could incorrectly get loaded twice in the UI.

Also, when the name of a script folder ended with a slash or a backslash character, up to now, an empty folder would incorrectly be added. This has now been fixed.

#### EPM: KPI histogram would incorrectly not be shown [ID_36004]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When, in a topology chain, you opened a KPI window and clicked the histogram icon, in some cases, the histogram window would be empty.

#### DataMiner Cube - EPM: Navigation issues [ID_36089]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When you opened an EPM card by clicking an alarm in the Alarm Console or switched between two EPM cards while the *Topology* pane was open in the sidebar, the topology filters would incorrectly not be updated.

Also, when, on a system where the *Topology* pane was open when you connected to it, you opened a new card or selected an open card, the topology filters would incorrectly not be updated until you navigated away from the *Topology* pane and back.

#### DataMiner Cube - Alarm Console: Filtered history tab would incorrectly not show information events [ID_36105]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When you added a filtered history tab that had to show active alarms, masked alarms and information events, no information events would be shown.

#### Warning message could appear while a list view was loading its data [ID_36120]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When Cube lost its connection to the DataMiner Agent while a list view was loading its data, in some cases, a warning message could appear, saying that the list view did not have permission to read service definitions.

#### Visual Overview - DataMiner Connectivity Framework: Active path would incorrectly not be highlighted [ID_36204]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When a visual overview had been configured to highlight the active path, in some rare cases, the active path would incorrectly not be highlighted.

#### Visual Overview: Problem when using placeholders in shape data fields of type 'ChildrenFilter' [ID_36227]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

Up to now, using placeholders in shape data fields of type *ChildrenFilter* could, in some cases, cause incorrect filtering behavior. From now on, when placeholders are used in shape data fields of type *ChildrenFilter*, filtering will be applied correctly.

#### DataMiner Cube was no longer able to download the CefSharp package [ID_36243]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

DataMiner Cube was no longer be able to download the CefSharp package from an agent.

#### DataMiner Cube - Alarm Console: First underscore would incorrectly be omitted from element, service and view names in 'Open' submenu [ID_36266]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When you right-click an alarm and hover over *Open*, the submenu that appears will list the names of the elements, the services and the views associated with that alarm. Up to now, when those names contained underscores, the first underscore would incorrectly be omitted.
