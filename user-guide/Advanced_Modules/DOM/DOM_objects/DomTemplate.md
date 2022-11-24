---
uid: DomTemplate
---

# DomTemplate object

A `DomTemplate` object stores a `DomInstance` with some pre-defined data, so that it can be used as a template. This makes creating very similar `DomInstances` much easier.

## Properties

The table below lists the properties of the `DomTemplate` object. It also indicates whether a property can be used for filtering using the `DomTemplateExposers`. Note that [the ITrackBase properties](../DOM_objects.md#itrackbase-properties) are also available on this type.

| Property | Type | Filterable | Description |
|--|--|--|--|
| ID | DomTemplateId | Yes | The ID of the `DomTemplate`. |
| Name | string | Yes | The name of the `DomTemplate`. |
| TemplateData | DomInstance | No | The `DomInstance` with pre-defined data that can be used as a template. |

## Requirements

There are currently no specific requirements for CRUD actions on `DomTemplates`.

## Errors

There are currently no specific error data reasons for CRUD actions on `DomTemplates`.

