---
uid: DOM_FieldAliases
---

# FieldAliases property

This settings object is a list of `FieldAlias` objects. A `FieldAlias` creates a link between a name/alias and a `FieldDescriptorID`. This way, a client application or web UI can know what a field actually means.

For example, imagine that a [DomInstance](xref:DomInstance) is used to log time punched in by employees. The `DomInstance` would then have fields that represent the start and end time. When a client UI has to display the `DomInstance` on a timeline, it needs to know which `FieldValues` represent the start and stop time. The client UI can then use the `FieldAliases` list to retrieve the `FieldDescriptorIDs` linked to the pre-determined aliases for these two timestamps (e.g. "PunchInTime" and "PunchOutTime").

> [!IMPORTANT]
> This setting can be used from DataMiner 10.2.9/10.3.0 onwards. While the property is already available in earlier versions, the values do not persist in the database prior to DataMiner 10.2.9/10.3.0.
