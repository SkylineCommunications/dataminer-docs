---
uid: SRM_migrating
---

# Migrating an SRM configuration from one DMA to another

It is possible to migrate components of an SRM configuration from one DMA to another. You can migrate separate components or migrate the complete configuration of a Booking Manager:

- [Virtual function definitions and associated components](xref:SRM_migrating_functions)
- [Profile instances](xref:SRM_migrating_profile_instances)
- [Resources](xref:SRM_migrating_resources)
- [Service definitions](xref:SRM_migrating_service_definitions)
- [Complete Booking Manager configuration](xref:SRM_migrating_booking_manager_full_configuration)

If you migrate several components, it is important that you import them in the order detailed above: first the virtual function definitions, then the profile instances, etc.

> [!TIP]
> If you are looking for information on how to migrate SRM resources and resource pools from the *Resources.xml* file to the indexing database, see [Migrating SRM resources to the indexing database](xref:Resources_migration_to_elastic).
