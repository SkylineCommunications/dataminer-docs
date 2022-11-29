---
uid: DOM_Instances_Cleanup
---

# DOM instances cleanup

The DOM module IDs used for Process Automation, which are dynamically created during installation, have a TTL set to 30 days. This means they will automatically get deleted 30 days after the last update.

If required, you can adjust the configuration of the module ID to have a different TTL. See [DOM module settings](xref:DOM_ModuleSettings).

> [!NOTE]
> Setting the TTL to unlimited is not supported. If you do so, the next execution of the configuration script (SRM_Setup) will reset the TTL to 30 days.
