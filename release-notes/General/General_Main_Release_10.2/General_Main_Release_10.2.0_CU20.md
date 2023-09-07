---
uid: General_Main_Release_10.2.0_CU20
---

# General Main Release 10.2.0 CU20 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

*No enhancements have been added to this release yet.*

### Fixes

#### Not all Protocol.Params.Param.Interprete.Others tags would not be read out [ID_36797]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

Not all [Protocol.Params.Param.Interprete.Others](xref:Protocol.Params.Param.Interprete.Others) tags would not be read out, which could lead to unexpected behavior.

#### Dashboards app: 'Loading...' indicator would appear when trying to save a folder of which the name consists of spaces [ID_37046]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU7] - FR 10.3.10 -->

When, in the *Create folder* or *Create dashboard* window, you clicked inside the *Location* box, clicked "+" to add a new folder, entered a series of spaces, and then clicked the checkmark button, a "Loading..." indicator would appear at the top of the window but nothing would happen.

Also, from now on, it is no longer allowed to save a folder with a name containing leading spaces.

#### DataMiner Cube - Alarm Console : Problem when a correlation/incident alarm got cleared [ID_37231]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

On a system with a large number of correlation/incident alarms, in some cases, an error could occur when one of those alarms was cleared. That alarm would then incorrectly remain visible in the Alarm Console.
