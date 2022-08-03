---
uid: DomManagerSecuritySettings
---

# DomManagerSecuritySettings

This settings object contains the `PermissionFlags` for the following four possible actions:

| Name | Description |
|--|--|
| ViewPermission | Permission flag that is checked when reading any of the `DomManager` objects. |
| CreateAndUpdateDomInstancePermission | Permission flag that is checked when creating or updating a `DomInstance` or `DomTemplate`. |
| DeleteDomInstancePermission | Permission flag that is checked when deleting a `DomInstance` or `DomTemplate`. |
| ConfigurePermission | Permission flag that is checked when creating, updating, or deleting `SectionDefinitions` or `DomDefinitions`. |

When a property has the default value "None" assigned, no security flag check will be done for that action.
