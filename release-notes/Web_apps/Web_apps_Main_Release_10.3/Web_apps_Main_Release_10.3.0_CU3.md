---
uid: Web_apps_Main_Release_10.3.0_CU3
---

# DataMiner web apps Main Release 10.3.0 CU3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Main Release 10.3.0 CU3](xref:General_Main_Release_10.3.0_CU3).

### Enhancements

*No enhancements have been added to this release yet.*

### Fixes

#### Dashboards app: Problem when trying to open a shared dashboard [ID_35271]

<!-- MR 10.3.0 [CU3] - FR 10.3.3 -->

When users tried to open a shared dashboard, in some cases, they would unexpectedly be presented with a login screen because of a permission issue.

Workaround: Recreate the faulty shared dashboard.

#### Dashboards app: Problem when an extra GetParameterTable call without ValueFilters was sent after sharing a dashboard with a state, ring or gauge component [ID_35844]

<!-- MR 10.3.0 [CU3] - FR 10.3.5 -->

When a dashboard with a state, ring or gauge component was shared, in some cases, an error could be thrown when an extra `GetParameterTable` call without `ValueFilters` was sent.

#### Dashboards app: Problem when selecting a parameter in a parameter feed component of a shared dashboard [ID_35863]

<!-- MR 10.3.0 [CU3] - FR 10.3.5 -->

When you selected a parameter in a parameter feed component of a shared dashboard, in some cases, an error could occur.
