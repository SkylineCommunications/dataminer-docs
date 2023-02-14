---
uid: Cube_Main_Release_10.3.0_CU1
---

# DataMiner Cube Main Release 10.3.0 CU1 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Main Release 10.3.0 CU1](xref:General_Main_Release_10.3.0_CU1).

### Enhancements

#### SLAnalytics: Number of 'GetParameterMessages' requests has been optimized [ID_34936]

<!-- MR 10.3.0 [CU1] - FR 10.3.1 -->

The number of *GetParameterMessages* sent by SLAnalytics in order to check whether a trended table parameter is still active has been optimized.

### Fixes

#### Trending: Pattern matching tags could incorrectly be defined for discrete or string parameters [ID_35368]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1]  - FR 10.3.3 -->

Pattern matching does not support discrete or string parameters. However, up to now, when viewing a trend graph that showed trend information for either a discrete or a string parameter, it would incorrectly be possible to define tags for pattern matching. From now on, this will no longer be possible.

#### Problem with SLElement when stopping an EPM element [ID_35439]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1]  - FR 10.3.3 -->

When an EPM element was stopped, in some rare cases, an error could occur in SLElement.
