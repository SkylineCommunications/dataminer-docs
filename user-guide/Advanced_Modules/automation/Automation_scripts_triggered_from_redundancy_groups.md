---
uid: Automation_scripts_triggered_from_redundancy_groups
---

# Automation scripts triggered from redundancy groups

From DataMiner 10.1.12 onwards, when an Automation script is triggered as part of a redundancy group action, the script will have the additional parameters listed in the table below.

You can request these from within the Automation script using the *GetScriptParam(\<ID>)* method on the *Engine* object.

| ID | Name | Description |
|----|------|-------------|
| 65007 | \<Redundancy User> | In case of manual switching, this parameter will contain the name of the user who performed the switch. |
| 65008 | \<Redundancy Trigger> | In case of automatic switching, this parameter will contain the ID of the trigger that caused the switch to be performed. To look up the trigger, send a *GetRedundancyGroupByID* or *GetRedundancyGroupByName* message and check the *Triggers* array in the response. |
| 65009 | \<Redundancy Triggering Element> | In case of automatic switching, this parameter will contain the ID of the element that has caused the trigger to be fired. ID format: \<DataMinerID>/\<ElementID> |
| 65010 | \<Redundancy Primary> | This parameter will contain the ID of the primary element involved in the switch. ID format: \<DataMinerID>/\<ElementID> |
| 65011 | \<Redundancy Backup> | This parameter will contain the ID of the backup element involved in the switch. ID format: \<DataMinerID>/\<ElementID> |

> [!TIP]
> See also: [Redundancy groups](xref:RedundancyGroups#redundancy-groups)
