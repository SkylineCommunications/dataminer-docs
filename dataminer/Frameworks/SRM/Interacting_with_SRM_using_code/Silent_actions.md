---
uid: Silent_actions
---

# Silent actions

Multiple "silent actions" are possible in scripts, allowing the scripts to interact with bookings without any user interaction. This section lists the most common use cases. Adjusting bookings in ways that are not described here is not supported and could have a severe impact on the stability of SRM. However, if a specific feature you need is not described here, you can submit a feature request to Skyline Communications to evaluate whether this could be added.

- [Silently creating a booking](xref:SRM_creating_booking_silently)

- [Silently editing a pending booking](xref:SRM_editing_pending_booking_silently)

- [Silently assigning resource, profile and parameter values](xref:SRM_assigning_resource_profile_parameter_value_silently)

- [Silently adding properties to an existing booking](xref:SRM_adding_properties_to_booking_silently)

- [Silently applying booking lifecycle transitions](xref:SRM_apply_LS_transition_silently)

- [Silently applying service state transitions](xref:SRM_apply_service_state_transitions_silently)

- [Silently updating the timing of a booking](xref:SRM_update_timing_booking_silently)

- [Silently extending the timing of a booking](xref:SRM_extend_timing_booking_silently)

- [Silently renaming a booking](xref:SRM_rename_booking_silently)

- [Silently adding an extra resource and potentially creating a new service definition](xref:SRM_adding_extra_resource_silently)

- [Silently removing a resource and node from a booking and potentially creating a new service definition](xref:SRM_removing_resource_and_node_silently)

- [Silently creating or editing many bookings using caching](xref:SRM_creating_editing_many_bookings_with_caching)

- [Silently applying a profile to an unmapped resource or resource not part of a booking](xref:SRM_apply_profile_to_unmatched_resource)

> [!NOTE]
> Since [Feature release 2.0.1](xref:SRM_2.0.1) of the SRM framework, the [SRM Dev Pack](https://www.nuget.org/packages/Skyline.DataMiner.Core.SRM) is available, which allows you to easily add the required dependencies to develop these scripts. For details on how to install the NuGet on new or existing scripts, see [SRM scripting using the SRM Dev Pack](xref:srm_scripting_devpack).
