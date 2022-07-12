---
uid: DOM_ModuleSections
---

# ModuleSections

A module section is a `SectionDefinition` that all `DomDefinitions` must make a link to. This can for example be a `SectionDefinition` with a text field for the name of the `DomInstance`.

You can add `SectionDefinitions` to be used as module sections by adding their ID to the `ModuleSections` list.

Once the ID of a `SectionDefinition` is added to this list, it can only be (re-)created, updated, or deleted by users who are allowed to change module settings (i.e. users with the "Module Settings Configuration" permission).

> [!IMPORTANT]
> If a `DomDefinition` uses the status system, these `SectionDefinitions` do not have to be linked, although they can be. When the status system is used, you can make `SectionDefinitions` mandatory using the `ModuleBehaviorDefinition` setting.
