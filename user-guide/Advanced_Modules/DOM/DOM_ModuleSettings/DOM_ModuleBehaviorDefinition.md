---
uid: DOM_ModuleBehaviorDefinition
---

# ModuleBehaviorDefinition

This property contains the ID of the [DomBehaviorDefinition](xref:DomBehaviorDefinition) that contains all the configuration that MUST be used in this module.

That `DomBehaviorDefinition` can then be considered to be the parent definition for the whole module. Each [DomDefinition](xref:DomDefinition) will either have to be linked to this ID or to another `DomBehaviorDefinition` that has this ID as its parent.

This way you can for example force all `DomInstances` in the module to use the same statuses, transitions, etc. For more information, see [DomBehaviorDefinition](xref:DomBehaviorDefinition) and [DOM status system](xref:DOM_status_system).
