---
uid: DOM_history
---

# DOM history

The DOM manager tracks the history of all changes done to the field values of a DOM instance.

When a DOM instance is created or updated, a new `HistoryChange` object will be stored containing the created, updated, or deleted values. When a DOM instance is deleted, all history data is automatically deleted.

> [!NOTE]
> If for some reason the history storage is not working correctly, the CRUD operations for DOM instances will still continue to work, but the history will no longer be tracked. If this happens, an error will be logged for every failed history save. The notice will only be generated every hour to prevent an excessive number of notices.

## Changes to the field values

### DomFieldValueChange

A change to a field value is stored in a `DomFieldValueChange` object, which has the following properties:

| Property | Type | Explanation |
|--|--|--|
| FieldDescriptorId | FieldDescriptorID | The ID of the field descriptor. |
| CrudType | CrudType | Determines whether this change is a create, update, or delete action. |
| ValueBefore | IValueWrapper | Value before the change (will be null when *CrudType* is set to "Create"). |
| ValueAfter | IValueWrapper | Value after the change (will be null when *CrudType* is set to "Delete"). |

### DomSectionChange

The `DomSectionChange` object bundles `DomFieldValueChange` objects together for a section. It has the following properties:

| Property | Type | Explanation |
|--|--|--|
| SectionId | SectionID | The ID of the section. |
| FieldValueChanges | `List<DomFieldValueChange>` | A list of the `DomFieldValueChange` objects. |

## Changes to the status

Each time the status is changed, a `DomInstanceStatusChange` is saved, which has the following properties:

| Property | Type | Explanation |
|--|--|--|
| StatusIdBefore | string | The ID of the status before the change. |
| StatusIdAfter | string | The ID of the status after the change. |

## HistoryChange

All the `DomSectionChange` and `DomInstanceStatusChange` objects for a DOM instance are saved to the database in a `HistoryChange` object.

This is stored in a separate Elasticsearch index for each module (named `chistory_dominstance_{moduleId}`). A `HistoryChange` also contains the extra information of where, when, and by whom a change was initiated.

| Property | Type | Filterable | Explanation |
|--|--|--|--|
| ID | Guid | Yes | Unique ID for this specific `HistoryChange`. |
| SubjectId | IDMAObjectRef | Yes | The ID of the DOM instance. |
| Time | DateTime | Yes | The time when the change was initiated. |
| FullUsername | string | Yes | The user who initiated this change. |
| DmaId | int | Yes | The ID of the DMA on which the change was initiated. |
| Changes | `IReadOnlyList<IChangeDescription>` | No | A list of changes (requires a cast to one of the change types). |
