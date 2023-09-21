---
uid: Web_apps_Main_Release_10.3.0_CU8
---

# DataMiner web apps Main Release 10.3.0 CU8 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Main Release 10.3.0 CU8](xref:General_Main_Release_10.3.0_CU8).

### Enhancements

*No enhancements have been added to this release yet.*

### Fixes

#### Dashboards app/Low-Code Apps: Seconds of multiple clock components would not be in sync [ID_37193]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.10 -->

When you enabled the *Show seconds* option of multiple clock components on the same dashboard or app panel, the seconds would incorrectly not all be in sync.

#### Low-Code Apps: Problem when two State components were fed the same query row data with a column filter applied [ID_37206]

<!-- MR 10.3.0 [CU8] - FR 10.3.10 -->

When two *State* components were fed the same query row data and had a column filter applied, the app would become unresponsive.

#### Dashboards app/Low-Code Apps: Problem when migrating a query containing only a 'start from' node linking to another query with only a 'start from' node [ID_37224]

<!-- MR 10.3.0 [CU8] - FR 10.3.10 -->

Up to now, it would not be possible to migrate a query with only a *start from* node linking to another query with only a *start from* node linking to another query.

#### Dashboards app/Low-Code Apps: Stepper component would apply an incorrect theme color [ID_37263]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

In some cases, the *Stepper* component would not apply the correct theme color.

#### Dashboards app/Low-Code Apps: Problem with custom time zones [ID_37278]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

When a custom time zone was used, in some cases, that time zone would not be processed correctly.

For example, when you set a custom time zone in a *Clock* component, the current time of that custom time zone would not be identical to the current time of the local time zone.

> [!NOTE]
> This problem would mostly occur when using a time zone that no longer observed daylight saving time (e.g. Altai Standard Time).
