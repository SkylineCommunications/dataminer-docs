---
uid: DOM_ModuleSections
---

# ModuleSections

A module section is a [SectionDefinition](xref:DOM_SectionDefinition) that all [DomDefinitions](xref:DomDefinition) must make a link to.

You can add `SectionDefinitions` to be used as module sections by adding their ID to the `ModuleSections` list.

Once the ID of a `SectionDefinition` is added to this list, it can only be (re-)created, updated, or deleted by users who are allowed to change module settings (i.e. users with the [Module Settings](xref:DataMiner_user_permissions#modules--system-configuration--object-manager--module-settings) permission.

> [!IMPORTANT]
> If a `DomDefinition` uses the status system, these `SectionDefinitions` do not have to be linked, although they can be. When the status system is used, you can make `SectionDefinitions` mandatory using the `ModuleBehaviorDefinition` setting.
