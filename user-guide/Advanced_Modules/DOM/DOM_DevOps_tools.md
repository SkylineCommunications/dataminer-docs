---
uid: DOM_DevOps_tools
---

# DOM DevOps tools

The DOM DevOps tools allow you to create and update DOM models in a more graphical way instead of doing so via code. They allow you to quickly model DOM objects even if you do not have a profound knowledge of the different objects and how they are structured in the background.

> [!CAUTION]
> These tools have been created by developers for developers. We have made them available in case this could be useful, but they are currently by no means complete tools.

> [!NOTE]
> These tools are available via the DataMiner Catalog. See [DOM DevOps tools installation](xref:DOM_DevOps_installation).

The [**DOM Designer**](xref:DOM_Designer) allows you to quickly and easily set up an entire new module with a definition from scratch. However, it only supports a limited set of editing actions:

- Adding fields
- Changing the behavior of fields in a certain state
- Adding buttons
- Adding states if no instances exist of the DOM model

To edit modules and definitions or to set up complex modules with multiple definitions reusing sections, you should use the [**DOM Editor**](xref:DOM_Editor) instead. For example:

- Changing the name of a field
- Deleting a field
- Reusing sections across different definitions in the same module
- Naming a DOM instance

  > [!NOTE]
  > If you use the DOM Designer tool with the Excel file, it will automatically pick the value of the first field as the instance name.
