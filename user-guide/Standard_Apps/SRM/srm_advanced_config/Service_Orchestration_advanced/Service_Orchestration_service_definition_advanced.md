---
uid: Service_Orchestration_service_definition_advanced
---

# Service Orchestration: service definitions configuration

In a [service definition](xref:srm_definitions#service-definition), several fields can be configured to define the behavior of bookings:

- **Node labels**: see [Creating service definitions](xref:Service_Orch_creating_service_definitions).
- **Service definition properties**: see [SRM properties for use with the Booking Manager app](xref:SRM_properties_Booking_Manager).
- **Node and interface properties**: see [SRM properties for use with the Booking Manager app](xref:SRM_properties_Booking_Manager).
- **Orchestration script**: see [Creating LSO scripts](xref:Service_Orch_creating_LSO_scripts)
- **Default profile instances**: see [Service Orchestration profile instances configuration](xref:Service_Orchestration_profile_instances)
- **Visio drawing**: Defined at the top of the *definitions* tab in the Services module; determines which Visio file is assigned to the service associated with the bookings.

Below you can find more information on optional advanced configuration of service definitions.

> [!NOTE]
> For information on the minimum service definition configuration for Service Orchestration, see [Creating service definitions](xref:Service_Orch_creating_service_definitions).

## Hiding a service definition in the Booking Manager app

<!-- RN 21526 -->

It is possible to hide a service definition in the booking UI, so that it is never shown to the user:

1. In the Services module, go to the *definitions* tab.

1. Select the service definition.

1. Go to the *properties* tab at the top.

1. Click *Add* to add a property.

1. In the *New property* box, specify the property name *HideFromWizard*.

1. Set the property value to *true*.

> [!TIP]
> See also: [HideFromWizard](xref:SRM_properties_Booking_Manager#hidefromwizard)

## Enabling reuse of contributing bookings

<!-- RN 28958 -->

If the Service Profiles wizard is used, by default a new contributing resource is always created. If you want to be able to reuse an existing contributing resource, you can configure this in the relevant service definition.

1. In the Services module, go to the *definitions* tab.

1. Select the service definition and the node for which the contributing resource should be reused.

1. In the *properties* pane below the diagram pane, add the property *Reuse Contributing Resource*.

1. Set the property value to *True*.

> [!TIP]
> See also: [Reuse Contributing Resource](xref:SRM_properties_Booking_Manager#reuse-contributing-resource)
