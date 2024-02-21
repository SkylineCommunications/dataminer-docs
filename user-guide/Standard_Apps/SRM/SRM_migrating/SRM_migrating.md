---
uid: SRM_migrating
---

# Migrating an SRM configuration from one DMA to another

It is possible to migrate components of an SRM configuration from one DMA to another. This includes:

- [Virtual function definitions and associated components](xref:SRM_migrating_functions)
- [Profile instances](xref:SRM_migrating_profile_instances)
- [Resources](xref:SRM_migrating_resources)
- [Service definitions](xref:SRM_migrating_service_definitions)

If you migrate several components, it is important that you import them in the order detailed above: first the virtual function definitions, then the profile instances, etc.

> [!TIP]
> If you are looking for information on how to migrate SRM resources and resource pools from the *Resources.xml* file to the indexing database, see [Migrating SRM resources to the indexing database](xref:Resources_migration_to_elastic).

> [!NOTE]
> From version 1.2.24 of the SRM framework onwards, it is also possible to export all artifacts of a Booking Manager application at once, so that these can then be deployed by means of a DataMiner installation package. For detailed information, see [Application packages for SRM projects](xref:SRM_project_config_using_CICD).
