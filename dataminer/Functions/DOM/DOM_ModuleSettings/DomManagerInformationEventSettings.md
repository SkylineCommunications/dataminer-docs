---
uid: DomManagerInformationEventSettings
---

# DomManagerInformationEventSettings

This settings object currently only contains a boolean to enable information events (supported from DataMiner 10.1.3/10.2.0 onwards).

When this is enabled, an information event (on parameter 64646 with name "DOM Manager info") is generated for every create, update, and delete action for a [DomInstance](xref:DomInstance), [DomDefinition](xref:DomDefinition), [DomTemplate](xref:DomTemplate), or [SectionDefinition](xref:DOM_SectionDefinition). By default, this is disabled.

The information event message includes the object name (if it has one), the object ID, the action, and the name of the user doing the action. For example:

```txt
DomDefinition 'PLM_Basic' (f86a8cbc-a8f5-4836-b60d-5f378bf7975a) was added by John Doe - plm
DomInstance '4b425d2b-246f-4a28-bbdd-1c06d3c023e6' was updated by John Doe - plm
```
