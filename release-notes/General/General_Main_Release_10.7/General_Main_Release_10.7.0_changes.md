---
uid: General_Main_Release_10.7.0_changes
---

# General Main Release 10.7.0 – Changes (preview)

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Changes

### Enhancements

#### DataMiner Objects Models: DomInstances CRUD helper now supports reading only a selected subset of fields from `DomInstance` objects [ID 43852]

<!-- MR 10.7.0 - FR 10.6.1 -->

The `DomInstances` CRUD helper now supports reading only a selected subset of fields from `DomInstance` objects. This will reduce the amount of data transferred and can significantly improve performance in cases where clients only need a few fields from each instance.

New `Read` and `PreparePaging` overloads will accept a `SelectedFields<DomInstance>` object. To select a field, add the exposer from `DomInstanceExposers` or add the `FieldDescriptorID` to the `SelectedFields<DomInstance>` object.

> [!NOTE]
>
> - The `Id` is always available on a `PartialObject`. You do not need to add the `Id` exposer to `SelectedFields<DomInstance>`.
> - Selecting the `FieldValues` or `FullObject` exposer is not supported and will result in a failed read operation.

The `Read` and `PreparePaging` methods will return a list of `PartialObject<DomInstance, DomInstanceId>`, which provides:

- `ID`: The `DomInstance` ID.
- `GetValue` and `TryGetValue`, which retrieve the value of a selected exposer or a single-value `FieldDescriptorID`.
- `GetValues` and `TryGetValues`, which retrieve a list of values for a selected `FieldDescriptorID` (for fields with multiple values, or when multiple sections are allowed).

When retrieving values, the following behavior will apply:

- **Multiple values**: Use `GetValues<T>`/`TryGetValues<T>` to obtain a `List<T>`. `GetValues<T>` throws `InvalidOperationException` if the values are not of type `T`; `TryGetValues<T>` returns `false` in that case.
- **Single value**: Use `GetValue<T>`/`TryGetValue<T>` for fields with a single value. `GetValue<T>` throws `InvalidOperationException` if the value is not of type `T` or when there are multiple values available for that field descriptor; `TryGetValue<T>` returns `false`.
- **No value**: `GetValue<T>` returns `default(T)` (equivalent to an empty list for list types). `TryGetValue<T>` returns `false`. `GetValues<T>` returns `null`. `TryGetValues<T>` returns `false`.

> [!IMPORTANT]
> A `FieldDescriptor` ID must be unique across section definitions in a DOM module.

### Fixes

#### SLAnalytics would not receive 'swarming complete' notifications for swarmed DVE child elements [ID 43984]

<!-- MR 10.7.0 - FR 10.6.1 -->

Up to now, SLAnalytics would incorrectly not receive any "swarming complete" notifications for swarmed DVE child elements. As a result, alarm focus calculations for DVE child elements would be restarted from scratch instead of being fetched from the database.
