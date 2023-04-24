---
uid: Cube_Main_Release_10.3.0_CU3
---

# DataMiner Cube Main Release 10.3.0 CU3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Main Release 10.3.0 CU3](xref:General_Main_Release_10.3.0_CU3).

### Enhancements

#### System Center: Enhancements made to Database > Offload section [ID_36037]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In *System Center*, a few enhancements have been made to the *Database > Offload* section:

- When you set *Type* to "Database", select *Trend data* in the *Offloads* section, and set the frequency under *Enable data offload* to "permanently", the time indication (e.g "starting every day at") will no longer be shown.

- When you set *Type* to "Database" and select *Parameter value* in the *Offloads* section, from now on, you will no longer be able to set the frequency under *Enable snapshot offload* to "permanently".

  > [!IMPORTANT]
  > If, before upgrading to this DataMiner version, *Parameter value* was selected and the frequency was set to "permanently", *Parameter value* will no longer be selected after upgrading. As a result, no snapshot will be offloaded until you reconfigure the snapshot offload settings.

### Fixes

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
