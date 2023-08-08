---
uid: DOM_history
---

# DOM history

From DataMiner 10.1.3/10.2.0 onwards, The DOM manager tracks the history of all changes done to the `FieldValues` of a [DomInstance](xref:DomInstance).

When a `DomInstance` is created or updated, a new `HistoryChange` object will be stored containing the created, updated, or deleted values. When a `DomInstance` is deleted, all history data is automatically deleted.

Prior to DataMiner version 10.3.9/10.4.0<!-- RN 36785 -->, this is done synchronously during `DomInstance` calls. This can cause these calls to take longer than expected. In case of a `DomInstance` delete, this delay could add up when there have been a lot of updates for that instance. From DataMiner 10.3.9/10.4.0 onwards, all DOM managers will by default execute the history actions asynchronously in the background. This prevents this delay on the `DomInstance` calls and thus improves their performance. However, note that it may still take a while for delete actions to be completed in the background.

> [!NOTE]
>
> - When designing a DOM manager, consider disabling the DOM history if these records are not required. This reduces the load on the database and reduces the amount of storage required. See [Disabling the history or changing the storage behavior](#disabling-the-history-or-changing-the-storage-behavior).
> - If for some reason the history storage is not working correctly, the CRUD operations for DOM instances will still continue to work, but the history will no longer be tracked. If this happens, an error will be logged for every failed history save. A notice in the Alarm Console will only be generated every hour to prevent an excessive number of notices.

## Disabling the history or changing the storage behavior

From DataMiner 10.3.9/10.4.0 onwards, you can override the default asynchronous save and delete behavior of the DOM instance history by setting the *DomInstanceHistoryStorageBehavior* option in the `ModuleSettings`. With this option, you can force the history to be saved synchronously, or you can disable history saving completely. For more information, see [DomInstanceHistorySettings](xref:DOM_DomInstanceHistorySettings).

## Changes to the field values

### DomFieldValueChange

A change to a field value is stored in a `DomFieldValueChange` object, which has the following properties:

| Property | Type | Description |
|--|--|--|
| FieldDescriptorId | FieldDescriptorID | The ID of the `FieldDescriptor`. |
| CrudType | CrudType | Determines whether this change is a create, update, or delete action. |
| ValueBefore | IValueWrapper | Value before the change (will be null when *CrudType* is set to "Create"). |
| ValueAfter | IValueWrapper | Value after the change (will be null when *CrudType* is set to "Delete"). |

### DomSectionChange

The `DomSectionChange` object bundles `DomFieldValueChange` objects together for a `Section`. It has the following properties:

| Property | Type | Description |
|--|--|--|
| SectionId | SectionID | The ID of the `Section`. |
| FieldValueChanges | `List<DomFieldValueChange>` | A list of the `DomFieldValueChange` objects. |

## Changes to the status

Each time the status is changed, a `DomInstanceStatusChange` is saved, which has the following properties:

| Property | Type | Description |
|--|--|--|
| StatusIdBefore | string | The ID of the status before the change. |
| StatusIdAfter | string | The ID of the status after the change. |

## HistoryChange

All the `DomSectionChange` and `DomInstanceStatusChange` objects for a DOM instance are saved to the database in a `HistoryChange` object (see [DOM data storage](xref:DOM_data_storage)).

A `HistoryChange` also contains the extra information of where, when, and by whom a change was initiated.

| Property | Type | Filterable | Description |
|--|--|--|--|
| ID | Guid | Yes | Unique ID for this specific `HistoryChange`. |
| SubjectId | IDMAObjectRef | Yes | The ID of the `DomInstance`. |
| Time | DateTime | Yes | The time when the change was initiated. |
| FullUsername | string | Yes | The user who initiated this change. |
| DmaId | int | Yes | The ID of the DMA on which the change was initiated. |
| Changes | `IReadOnlyList<IChangeDescription>` | No | A list of changes (requires a cast to one of the change types). |

You can retrieve `HistoryChange` objects using the `DomHelper` class. You can filter them using `HistoryChangeExposers`.

> [!NOTE]
> It is only possible to read `HistoryChange` items. Creating, updating, or deleting is reserved for the internal API.

Example:

```csharp
// Get all history for a specific DomInstance
var filter = HistoryChangeExposers.SubjectID.Equal(domInstance.ID.ToFileFriendlyString());
var allHistory = domHelper.DomInstanceHistory.Read(filter);

// Cast the changes
var singleHistory = allHistory.First();
var sectionChanges = singleHistory.Changes.OfType<DomSectionChange>();
var statusChanges = singleHistory.Changes.OfType<DomInstanceStatusChange>();
```
