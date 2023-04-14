---
uid: Cube_Feature_Release_10.3.6
---

# DataMiner Cube Feature Release 10.3.6 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.6](xref:General_Feature_Release_10.3.6).

## Highlights

*No highlights have been selected for this release yet*

## Other features

*No other features have been added to this release yet.*

## Changes

### Enhancements

#### System Center: Overhaul of LDAP settings [ID_35782]

<!-- MR 10.4.0 - FR 10.3.6 -->

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

#### System Center: Enhancements made to Database > Offload section [ID_36037]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In *System Center*, a few enhancements have been made to the *Database > Offload* section:

- When you set *Type* to "Database", select *Trend data* in the *Offloads* section, and set the frequency under *Enable data offload* to "permanently", the time indication (e.g "starting every day at") will no longer be shown.

- When you set *Type* to "Database" and select *Parameter value* in the *Offloads* section, from now on, you will no longer be able to set the frequency under *Enable snapshot offload* to "permanently".

  > [!IMPORTANT]
  > If, before upgrading to this DataMiner version, *Parameter value* was selected and the frequency was set to "permanently", *Parameter value* will no longer be selected after upgrading. As a result, no snapshot will be offloaded until you reconfigure the snapshot offload settings.

#### Visual Overview: Enhanced URL handling [ID_36044]

<!-- MR 10.4.0 - FR 10.3.6 -->

A number of enhancements have been made with regard to URL handling within Visual Overview.

### Fixes

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

Also, when, on a system where the *Topology* pane was open when you connected to it, you opened a new card or selected an open card, the topology filters would incorrectly not be updated until you navigated to the *Topology* pane and back.

#### DataMiner Cube - Alarm Console: Filtered history tab would incorrectly not show information events [ID_36105]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When you added a filtered history tab that had to show active alarms, masked alarms and information events, no information events would be shown.
