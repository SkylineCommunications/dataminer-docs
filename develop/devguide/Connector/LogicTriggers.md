---
uid: LogicTriggers
---

# Triggers

Triggers are another important concept in protocols. A trigger defines what happens when it is activated, and how it is activated (e.g., on a parameter value change). Defining when a trigger is activated is optional, as a trigger can also be forced to execute, e.g., from a Quick Action (using the CheckTrigger method of the SLProtocol interface), by another trigger, or because it is part of a group being executed.

For an overview of what can activate a trigger, see [Protocol.Triggers.Trigger.Time](xref:Protocol.Triggers.Trigger.Time).

When activated, a trigger can:

- Either execute one (or multiple) action(s). This is the most common scenario.
- Or trigger another (or multiple) trigger(s).

![DPML Triggers](~/develop/images/Protocol_Explained_-_Triggers.svg)

![DPML Triggers (continued)](~/develop/images/Protocol_Explained_-_Triggers_2.svg)

> [!NOTE]
>
> - For more information on how to define a trigger in a protocol, see [Protocol.Triggers.Trigger](xref:Protocol.Triggers.Trigger).
> - An example protocol "SLC SDF After Group Trigger" is available in the [Protocol Development Guide Companion Files](https://community.dataminer.services/documentation/protocol-development-guide-companion-files/).

## See also

DataMiner Class Library:

- [SLProtocol.CheckTrigger(System.Int32)](xref:Skyline.DataMiner.Scripting.SLProtocol.CheckTrigger(System.Int32)) method
