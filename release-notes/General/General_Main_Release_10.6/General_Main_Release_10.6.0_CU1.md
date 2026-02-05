---
uid: General_Main_Release_10.6.0_CU1
---

# General Main Release 10.6.0 CU1 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.6.0 CU1](xref:Cube_Main_Release_10.6.0_CU1).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.6.0 CU1](xref:Web_apps_Main_Release_10.6.0_CU1).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SLManagedScripting will again add a log entry each time it has loaded or failed to load an assembly [ID 44522]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU1] - FR 10.6.3 -->

Since DataMiner version 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9<!-- RN 43690 -->, SLManagedScripting no longer added an entry in the *SLManagedScripting.txt* log file each time it had loaded or failed to load an assembly. From now on, it will again do so.

These log entries will include both the requested version and the actual version of the assembly.

#### Security enhancements [ID 44579]

<!-- 44579: MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

A number of security enhancements have been made.

### Fixes

#### Problem with SLNet when receiving a subscription with a large filter that contained wildcards [ID 44512]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When SLNet received a dynamic table subscription with a very large filter that contained wildcards, up to now, it would throw a stack overflow exception and stop working.

From now on, SLNet subscriptions will now be blocked when they contain a filter that exceeds 140,000 characters.
