---
uid: Version_editor
---

# Version editor

If you click *Version Editor* in the file tab header when editing a protocol XML file, the XML editor you are working in will be turned into a dedicated protocol version editor. This editor will allow you to manage the information in the Protocol.Version and Protocol.VersionHistory elements in a more user-friendly way.

![Version editor](~/develop/images/DIS_VersionHistoryEditor.png)

If you want to save the changes you made and return to the XML editor, click *Apply Changes*. If you want to discard the changes you made, click *Cancel*.

## Current version

In this tab, you can specify the general properties of the current (minor) version (version number, author, date, etc.), a list of all features, changes and fixes in this version, and a list of references.

If you click *Go to this version in All Versions tree*, the *All Versions* tab will open and the current version will be selected in the version tree.

### Features, changes and fixes

To add a new item to the list of features, changes and fixes, do the following:

1. On the right, above the list, click *Add*,
1. Set *Type* to "Fix", "Change" or "New Feature", and
1. Enter the necessary information in the *Content* box.

To remove an item

- Click the *Remove* button.

### References

In the references list at the bottom of the tab, it is possible to add two types of references.

- Task references, i.e. references to DataMiner Collaboration tasks, and
- Generic references, i.e. references to other information (e.g. a ticket in a third-party ticketing system).

To add a reference to a DataMiner Collaboration task, do the following:

1. On the right, above the list, click *Add*.
1. In the *Type* column, select "Task Id".
1. In the *Reference* column, add the (numeric) ID of the Collaboration task.

To add a generic reference, do the following:

1. On the right, above the list, click Add.
1. In the *Type* column, select "Reference".
1. In the *Reference* column, add the ID, address, etc. of the information to which you want to refer.
1. In the *Reference type* column, add the type of information to which you referred in the *Reference* column. For example, if *Reference* contains an ID of a Jira ticket, you could set *Reference type* to "Jira".

To go to the information referred to by a reference

- Click the *Link* button.

To remove a reference

- Click the *Remove* button.

> [!NOTE]
> In the *Interface* tab of the *DIS Settings* window, you can define the URL format of the two types of references in the following fields:
> - Task URL String Format
> - Reference URL String Format
>
> In both values, you can use the "{ref}" placeholder. When, in the version editor, you click the link button of a particular reference, that placeholder will then be replaced by the contents of the Reference column.
>
> See also: [Interface](xref:DIS_settings#interface)

## Current range

In this tab, you can find an overview of all versions in the current range.

Clicking a version number will open the *All Versions* tab to allow you to edit the information stored for that particular version.

## All versions

In this tab, you can find an overview of all versions of the current protocol.

- In the tree structure on the left, you can add and delete branches representing branch versions, system versions, major versions and minor versions by right-clicking a node and selecting the appropriate menu command. On the bottom of the pane, you can also find a button to add a minor version.
- In the edit pane on the right, you can edit the properties of the version selected on the left.

    - To a branch version, you can add a list of branch features.
    - To a system version, you can add a list of system requirements.
    - To a major version, you can add a list of major changes.
    - To a minor version, you can add a list of features, changes and fixes, and a list of references. See also [Current version](#current-version).

> [!NOTE]
> - All four parts of a version number (branch, system, major and minor) are editable anywhere in the tree. When you update a version number, all child items will be updated accordingly and recursively.
> - When you select a version that is not the current version, you can click the *Set this version as current button* to make that version the current version. Also, in the version tree on the left, you can right-click a version and select *Set as current version*. The current version and all its parent versions will be marked in bold.
> - When you create a new version, the *Based On* field will now automatically be populated when possible.
> - When you add a minor version, this new version will automatically inherit all data from the current version and become itself the new current version.
