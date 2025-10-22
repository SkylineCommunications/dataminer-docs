---
uid: DOM_security
---

# Security

By default, all DOM configuration and instance data can be read by any authenticated DataMiner user. A [single dedicated user permission](#module-settings-user-permission) controls who can change core configuration. From DataMiner 10.5.10/10.6.0 onwards<!--RN43589-->, you can also restrict access to specific DOM instances via the [link security](#link-security) feature. A [dedicated app to configure definition-level security](xref:DOM_security_ui) is available from DataMiner 10.5.11/10.6.0 onwards.

## Overview

| Action | Prior to 10.5.10/10.6.0 | From 10.5.10/10.6.0 onwards |
|--|--|--|
| Reading `ModuleSettings` | Any authenticated user | Any authenticated user |
| Creating, updating, or deleting `ModuleSettings` | Users with the *Module settings* permission | Users with the *Module settings* permission |
| Reading DOM configuration objects* | Any authenticated user | Any authenticated user |
| Creating, updating, or deleting DOM configuration objects* | Any authenticated user | Users with the *Module settings* permission |
| Reading `DomTemplate` objects | Any authenticated user | Any authenticated user |
| Creating, updating, or deleting `DomTemplate` objects | Any authenticated user | Users with the *Module settings* permission |
| Reading `DomInstance` objects | Any authenticated user | Any authenticated user OR restricted by link security |
| Creating, updating, or deleting `DomInstance` objects | Any authenticated user | Any authenticated user OR restricted by link security |

\* DOM configuration objects: [SectionDefinition](xref:DOM_SectionDefinition), [DomDefinition](xref:DomDefinition), and [DomBehaviorDefinition](xref:DomBehaviorDefinition).

> [!NOTE]
> Link security only applies when you explicitly configure it. If no links are defined, instance access remains open to all authenticated users.

## Module settings user permission

DOM has one dedicated user permission that can be configured in DataMiner Cube: [Module settings](xref:DataMiner_user_permissions#modules--system-configuration--object-manager--module-settings).

In code, this corresponds to the enum value `PermissionFlags.ModuleSettingsConfiguration` (291) in `Skyline.DataMiner.Net.PermissionFlags`.

This user permission secures the following actions:

| Action | Since DataMiner version |
|--|--|
| Creating, updating, or deleting `ModuleSettings` | 10.1.5/10.2.0 <!--RN29097--> |
| Creating, updating, or deleting a module `SectionDefinition` | 10.1.2/10.2.0 <!--RN28460--> |
| Creating, updating, or deleting a module `DomBehaviorDefinition` | 10.1.11/10.2.0 <!--RN30443--> |
| Reinitializing a DOM manager | 10.3.9/10.4.0 <!--RN36412--> |
| Triggering a midnight sync for a DOM manager | 10.3.9/10.4.0 <!--RN36412--> |
| Creating, updating, or deleting `SectionDefinition` objects | 10.5.10/10.6.0 <!--RN43589--> |
| Creating, updating, or deleting `DomDefinition` objects | 10.5.10/10.6.0 <!--RN43589--> |
| Creating, updating, or deleting `DomBehaviorDefinition` objects | 10.5.10/10.6.0 <!--RN43589--> |
| Creating, updating, or deleting `DomTemplate` objects | 10.5.10/10.6.0 <!--RN43589--> |

> [!TIP]
> If you want to delegate day‑to‑day instance management (CRUD on `DomInstance` objects) to a broader user base while protecting the model itself, only grant the *Module settings* permission to a restricted administrator group.

## Link security

From DataMiner 10.5.10/10.6.0 onwards, you can configure link security to restrict access to DOM instances. You define links between DataMiner user groups and a DOM object. Currently, only links to a `DomDefinition` are supported. A link determines which groups can access the `DomInstance` objects that belong to that definition.

When link security is enabled and a link is created for a `DomDefinition`:

- Only users belonging to at least one linked group can read or modify its `DomInstance` objects.
- Configuration objects (`DomDefinition`, `SectionDefinition`, `DomBehaviorDefinition`, etc.) remain governed by the *Module settings* permission, independent of link security.

For configuration steps and more info, see [Link security settings](xref:DOM_SecuritySettings#linksecuritysettings).
