---
uid: config_resource_orchestration
---

# Additional configuration for Resource Orchestration

## Booking Manager configuration

Before you can start using Resource Orchestration, you need to configure the Booking Manager app to use the correct booking context:

1. Open the Booking Manager app.
1. Click the hamburger button in the top-left corner and select *Show card side panel*.
1. In the card side panel, click *DATA*. This will open the *General* data page.
1. In the *Application Setup* section of the *General* data page, set the parameter *Booking Application Context* parameter to *Resource Orchestration*.

## Default wizard included in the SRM framework

When you install the SRM framework, an Automation script is included that can be used as the default wizard to orchestrate a resource.

### Required input parameters

The wizard is an interactive Automation script called *SRM_ResourceManagement*. As of SRM version 1.2.27, the input parameters accept the following fields in JSON format:

- *ResourceIds*: The GUID of the resources, separated by commas.
- *BookingManagerElement*: The name of a Booking Manager element. This is used to generate log files in the directory specified in that element.
- *ReservationId*: Optional. Used to edit the booking.
- *Timing*: Optional. The timing of the booking.
- *TimeRange*: Optional. The proposed time of the booking to be created (in string format). This is a semicolon-separated list of start and stop time in binary format, as provided by Cube when a time range is selected on the timeline component.

For example: `{"BookingManagerElement":"Resource Orchestration","ReservationId":"00000000-0000-0000-0000-000000000000","ResourceIds":"e489a83d-182b-45c7-a981-615c253525b2","Timing":{"EffectiveStart":"2022-09-07T16:18:24.1242596+02:00","PreRoll":"00:00:00","StartDate":"2022-09-07T16:18:24.1242596+02:00","EffectiveEnd":"2022-09-07T17:25:27.9282596+02:00","EndDate":"2022-09-07T17:25:27.9282596+02:00","PostRoll":"00:00:00","IsSilent":false}}`

> [!NOTE]
> For an up-to-date definition of the input argument, import *SLSRMLibrary.dll* and check the class *Skyline.DataMiner.Library.Solutions.SRM.Model.ResourceManagement.InputData*.

### Running the wizard

When a user runs the wizard, they will first need to specify the name and timing for the booking.

![Step 1 of the resource orchestration wizard](~/user-guide/images/ResourceOrchestrationWizardStep1.png)

In the next step of the wizard, they need to select a profile instance, and they can optionally also select a target service state.

![Step 2 of the resource orchestration wizard](~/user-guide/images/ResourceOrchestrationWizardStep2.png)

After they click *Confirm*, the booking will be created.

## Creating a custom front end for the wizard

The wizard can be launched from Visual Overview or from a low-code app.

A typical use case is to make use of the Resource Manager component in Visual Overview, showing resource bands on the Y-axis. This is done in the same way as for [Resource Scheduling](xref:config_resource_scheduling#creating-a-custom-front-end-for-the-resource-scheduling-wizard).
