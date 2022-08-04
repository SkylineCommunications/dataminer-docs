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

> [!NOTE]
> When a property has the default value "None" assigned, no security flag check will be done for that action.

For example, a DOM manager can be configured with Planned Maintenance permissions as follows:

```csharp
var settings = new ModuleSettings("plm")
{
    DomManagerSettings = new DomManagerSettings()
    {
        SecuritySettings = new DomManagerSecuritySettings()
        {
            ViewPermission = PermissionFlags.PlmViewAll,
            CreateAndUpdateDomInstancePermission = PermissionFlags.PlmCreateUpdateDomInstances,
            DeleteDomInstancePermission = PermissionFlags.PlmDeleteDomInstances,
            ConfigurePermission = PermissionFlags.PlmConfiguration
        }
    }
};
```
