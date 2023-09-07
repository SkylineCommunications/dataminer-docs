---
uid: config_resource_automation
---

# Additional configuration for Resource Automation

## Default wizard included in the SRM framework

<!-- RN 30227 -->

When you install the SRM framework, an Automation script is included that can be used as the default wizard to apply a profile to a resource.

### Required input parameters

The wizard is an interactive Automation script called *SRM_ApplyProfileToResource*. As of SRM version 1.2.27, the input parameters accept the following fields in JSON format:

- *ResourceId*: The GUID of the resource that will be used by the wizard.
- *BookingManagerName*: Optional. The name of a Booking Manager element. This is used to generate log files in the directory specified in that element.
- *ReservationId*: Optional. The GUID of a booking, in case the profile instance needs to be applied in the context of a booking. This is only valid for bookings that are currently active.

For example: `{"ResourceId":" 25405e6e-3f96-4801-bc76-2dc1dae18358"}`

> [!NOTE]
>
> - For an up-to-date definition of the input argument, import *SLSRMLibrary.dll* and check the class *Skyline.DataMiner.Library.Solutions.SRM.Model.ApplyProfileToResource.InputData*.
> - In case both the *ReservationId* and the *BookingManagerName* input parameter are specified, the booking action log will be extended with records related to the execution of the Profile-Load Script. If only the *BookingManagerName* input parameter is specified, a separate action log file will be generated (`Resource_<Resource_Guid>_<Date Time>.html`).<!-- RN 32100 -->

### Running the wizard

The script allows you to select the full configuration for the resource. You can select a profile for the resource as well as for the interfaces. You can apply a state transition by selecting a profile instance that has state profiles configured, selecting the *State Transition* checkbox, and selecting the corresponding state in a drop-down box. To combine profiles and state profile data, you should select the *Full Config* checkbox, which only becomes available if *State Transition* is selected.

![SRM_ApplyProfileToResource wizard](~/user-guide/images/srm_applyprofiletoresource.png)

After that, click *Apply* to apply the selected configuration to the resource.

In case the resource is part of an active booking, the script will list any conflicts, and you can then decide to cancel or confirm the changes.

> [!NOTE]
> In case the *ReservationId* input parameter is specified, you will get different options than detailed above. You will be able to apply a profile selected during booking creation, apply a specific state profile instance, or both.<!-- RN 31531 -->

## Creating a custom front end for the wizard

The wizard can be launched from Visual Overview or from a low-code app.

A typical use case is to make use of the Resource Manager component in Visual Overview, showing resource bands on the Y-axis:

1. Embed a Resource Manager component in your Visio drawing, and use the *YAxisResources* variable to define the resources that will be listed on the Y-axis. See [Embedding a Resource Manager component](xref:Embedding_a_Resource_Manager_component).

   When a user selects a resource band on the timeline, the *SelectedResource* variable will be populated with the GUID of the resource.

1. Add a shape to the Visio drawing that executes the *SRM_ApplyProfileToResource* script, using the expected JSON as the input argument. See [Linking a shape to an Automation script](xref:Linking_a_shape_to_an_Automation_script).

   Use a variable placeholder in the JSON to reference the selected resource. For example:

   `script:SRM_ApplyProfileToResource||Input Data={"ResourceId":"[cardvar:SelectedResource]"}|||NoConfirmation,CloseWhenFinished`
