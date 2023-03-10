---
uid: Web_apps_Main_Release_10.3.0_CU2
---

# DataMiner web apps Main Release 10.3.0 CU2 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Main Release 10.3.0 CU2](xref:General_Main_Release_10.3.0_CU2).

### Enhancements

#### Monitoring app: Elements, services and views opened by clicking a Visio shape will open in the same tab instead of a new tab [ID_35781]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

In the *Monitoring* app, from now on, elements, services and views opened by clicking a Visio shape will open in the same tab instead of a new tab.

### Fixes

#### Dashboards app: Sticky component menus would no longer be fully visible after you had changed the number of dashboard columns [ID_35702]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.4 -->

Sticky component menus would no longer be fully visible after you had changed the number of dashboard columns.

#### Dashboards app & low-code apps: GQI components would incorrectly not clear their query row feed when refetching data [ID_35767]

<!-- MR 10.3.0 [CU2] - FR 10.3.4 -->

GQI components would incorrectly not clear their query row feed when refetching data.

#### Dashboards app & Low-code apps: Duplicated component would not have the size as the original [ID_35804]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When you duplicated a component, the size of the duplicate would incorrectly be limited to 30 rows. From now on, when you duplicate a component, the duplicate will have the same size as the original.

#### Dashboards app & Low-code apps: Parts of a component that had the focus would not get blurred when another component was selected [ID_35851]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When a part of a component (e.g. its title) had the focus, and you selected another component, the part of the first component that had the focus would incorrect keep the focus.

From now on, when a part of a component (e.g. its title) has the focus, and you selected another component, the part of the first component that had the focus will get blurred.
