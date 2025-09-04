---
uid: DOM_security
---

# Security

By default, all DOM configuration and instance data can be read by any authenticated DataMiner user. A single dedicated permission flag controls who can change core configuration. From DataMiner 10.5.10/10.6.0 onwards<!--RN43589--> you can additionally restrict access to specific DOM instances via the *link security* feature.

## Overview

| Action | Prior to 10.5.10/10.6.0 | From 10.5.10/10.6.0 onwards |
|--|--|--|
| Read `ModuleSettings` and DOM configuration objects* | Any authenticated user | Any authenticated user |
| Create / update / delete `ModuleSettings` | Users with the *Module settings* permission flag | Users with the *Module settings* permission flag |
| Create / update / delete DOM configuration objects* | Any authenticated user | Users with the *Module settings* permission flag |
| Create / update / delete `DomTemplate` objects | Any authenticated user | Users with the *Module settings* permission flag |
| Read `DomInstance` objects | Any authenticated user | Any authenticated user OR restricted by link security |
| Create / update / delete `DomInstance` objects | Any authenticated user | Any authenticated user OR restricted by link security |

*DOM configuration objects: [SectionDefinition](xref:DOM_SectionDefinition), [DomDefinition](xref:DomDefinition), and [DomBehaviorDefinition](xref:DomBehaviorDefinition).

> [!NOTE]
> Link security only applies when you explicitly configure it. If no links are defined, instance access remains open to all authenticated users.

## Module settings permission flag

DOM has one dedicated permission flag exposed in DataMiner Cube: **Module settings**.

Location in Cube:

> Modules > System configuration > Object Manager > Module settings

In code, this corresponds to the enum value `PermissionFlags.ModuleSettingsConfiguration` (291) in `Skyline.DataMiner.Net.PermissionFlags`.

This flag secures the following actions:

| Action | Since DataMiner version |
|--|--|
| Creating, updating, or deleting `ModuleSettings` | 10.1.5/10.2.0 <!--RN29097--> |
| Creating, updating, or deleting a *Module* `SectionDefinition` | 10.1.2/10.2.0 <!--RN28460--> |
| Creating, updating, or deleting a *Module* `DomBehaviorDefinition` | 10.1.11/10.2.0 <!--RN30443--> |
| Reinitializing a DOM manager | 10.3.9/10.4.0 <!--RN36412--> |
| Triggering a midnight sync for a DOM manager | 10.3.9/10.4.0 <!--RN36412--> |
| Creating, updating, or deleting `SectionDefinition` objects | 10.5.10/10.6.0 <!--RN43589--> |
| Creating, updating, or deleting `DomDefinition` objects | 10.5.10/10.6.0 <!--RN43589--> |
| Creating, updating, or deleting `DomBehaviorDefinition` objects | 10.5.10/10.6.0 <!--RN43589--> |
| Creating, updating, or deleting `DomTemplate` objects | 10.5.10/10.6.0 <!--RN43589--> |

> [!TIP]
> If you want to delegate day‑to‑day instance management (CRUD on `DomInstance` objects) to a broader user base while protecting the model itself, only grant the *Module settings* permission to a restricted administrator group.

## Link security

From DataMiner 10.5.10/10.6.0 onwards you can configure *link security* to restrict access to DOM instances. You define links between DataMiner user groups and a DOM object. Currently, only links to a `DomDefinition` are supported. A link determines which groups can access the `DomInstance` objects that belong to that definition.

When link security is enabled and a link is created for a `DomDefinition`:

- Only users belonging to at least one linked group can read or modify its `DomInstance` objects.
- Configuration objects (`DomDefinition`, `SectionDefinition`, `DomBehaviorDefinition`, etc.) remain governed by the *Module settings* permission flag, independent of link security.

For configuration steps and more info, see [Link security settings](xref:DOM_SecuritySettings#linksecuritysettings).
