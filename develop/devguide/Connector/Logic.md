---
metadata_version: 1
uid: Logic
description: "Describe the DataMiner connector development topic Logic, including its purpose, behavior, implementation guidance, and relevant constraints."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# Logic

A protocol defines different components such as parameters, groups, triggers, and actions.

These are the most frequently used components in a protocol:

- <xref:LogicParameters>
- <xref:LogicGroups>
- <xref:LogicTimers>
- <xref:LogicTriggers>
- <xref:LogicActions>
- <xref:LogicQActions>
- <xref:LogicConditions>

> [!NOTE]
> A component always has an ID. This ID must be unique for all components of a given type. Some restrictions apply to the possible ID values that can be used (See <xref:ReservedIDs>). Additionally, a component may have a name and a description, which also must be unique for a given type.

## See also

DataMiner Protocol Markup Language:

- [Protocol.Params](xref:Protocol.Params)
- [Protocol.Groups](xref:Protocol.Groups)
- [Protocol.Timers](xref:Protocol.Timers)
- [Protocol.Triggers](xref:Protocol.Triggers)
- [Protocol.Actions](xref:Protocol.Actions)
- [Protocol.QActions](xref:Protocol.QActions)

Connector best practices:

- [Logic](xref:Operation_duration)
- [Timers](xref:ConnectorBestPracticesTimers)
- [QActions](xref:Functionality)
