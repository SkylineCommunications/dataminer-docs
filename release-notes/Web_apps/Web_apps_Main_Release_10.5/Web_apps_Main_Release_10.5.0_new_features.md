---
uid: Web_apps_Main_Release_10.5.0_new_features
---

# DataMiner web apps Main Release 10.5.0 – New features – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Highlights

## New features

#### Interactive Automation scripts: Certain components can now be visualized as read-only in web environments [ID_37659]

<!-- MR 10.5.0 - FR 10.4.1 -->

*UIBlockDefinition* now has an *IsReadOnly* option, which is set to false by default. When set to true, and when the interactive Automation script is executed in a web environment, the following UI components will now be displayed read-only:

- Calendar
- Checkbox
- CheckboxList
- Dropdown
- Numeric
- RadiobuttonList
- TextBox
- Time
- Treeview

> [!NOTE]
>
> - Although read-only HTML components look as if they are read-write, users will not be able to change their value.
> - When a component has its *IsEnabled* option set to false and its *IsReadOnly* option set to true, it will be considered disabled. Except for components of UIBlockType *Treeview*. These will behave as enabled and read-only.
> - When an interactive Automation script is executed in DataMiner Cube, the *IsReadOnly* option will be ignored.
