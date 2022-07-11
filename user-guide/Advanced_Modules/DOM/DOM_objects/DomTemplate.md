---
uid: DomTemplate
---

# DomTemplate object

A *DomTemplate* object stores aDOM instance with some pre-defined data, so that it can be used as a template. This makes creating very similar DOM instances much easier.

## Properties

The table below lists the properties of the *DomTemplate* object. It also indicates whether a property can be used for filtering using the *DomTemplateExposers*.

| Property | Type | Filterable | Description |
| ID | DomTemplateId | Yes | The ID of the DOM template. |
| Name | string | Yes | The name of the DOM template. |
| TemplateData | DomInstance | No | The DOM instance with pre-defined data that can be used as a template. |

## Requirements

There are currently no specific requirements for CRUD actions on DOM templates.

## Errors

There are currently no specific error data reasons for CRUD actions on DOM templates.

## Security

Security checks are done on CRUD actions when permission flags are configured on the DomManagerSecuritySettings (of the ModuleSettings).

- To read DOM templates, the user needs the permission flag defined by *DomManagerSecuritySettings.ViewPermission*.

- To create or update DOM templates, the user needs the permission flag defined by *DomManagerSecuritySettings.CreateAndUpdateDomInstancePermission*.

- To delete DOM templates, the user needs the permission flag defined by *DomManagerSecuritySettings.DeleteDomInstancePermission*.
