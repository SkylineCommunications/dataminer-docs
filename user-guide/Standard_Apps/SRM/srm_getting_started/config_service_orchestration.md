---
uid: config_service_orchestration
---

# Additional configuration for Service Orchestration

## Creating service definitions

To move from a single function to a full service workflow, you need one or more [service definitions](xref:srm_definitions#service-definition).

You can create service definitions in the [Services module](xref:SRM_Services_definitions):

1. On the *definitions* tab of the Services module, click the *Add definition* button.

1. In the [configuration tab](xref:SRM_Services_definitions#configuration-tab) of the main page, drag the necessary virtual functions to the diagram pane and connect them.

1. Define a label for each of the virtual functions, so that they can be uniquely identified in case multiple instances of the same virtual functions are used within the same service definition. To do so, select the virtual function in the diagram and specify the label in the pane below.

1. Add a *Virtual Platform* property to the service definition and set its value to the [virtual platform](xref:srm_instantiations#virtual-platform) name.

> [!TIP]
> To check if everything is configured correctly, you can now create a test booking. Try to create a booking using the Booking Manager app, and check if the available resources are correctly filtered and added.

## Creating LSO scripts

To set up Service Orchestration, you will also need a [Life cycle Service Orchestration (LSO) script](xref:srm_scripting#life-cycle-service-orchestration-lso-script) linked to each service definition.

1. Start from the available *SRM_LSOTemplate* script to create a first LSO script.

1. Develop the script to execute the Profile-Load Scripts either sequentially or in parallel.

1. To determine when the script is executed, in the Services module, configure actions for the service definition in the [Actions tab](xref:SRM_Services_definitions#actions-tab).

   - The *Name* column for each action will determine at which stages in the service life cycle the LSO script is executed (e.g. START, STANDBY, PAUSE, STOP).

   - In the *Script* column, specify the name of the LSO script.

You have now set up basic Service Orchestration: the LSO script will be executed at the booking stages you linked it to. This script will call the specified Profile-Load Scripts and start configuring the virtual functions.

> [!TIP]
> To test this setup, create a booking and select the timing, the resources and the profile instances for the virtual functions of the service definition. Check how the LSO script is called and verify that the booking is executed.

## Adding DTR (optional)

In some cases, specific information that is set into an applied profile instance of a virtual function could be useful to transfer to another virtual function of the same service definition. This is done with [Data Transfer Rules (DTR)](xref:srm_scripting#data-transfer-rules-dtr).

To configure DTR:

1. Start from the available *SRM_DTRTemplate* script to create a first DTR script.

1. Configure the script to process information and set this information on a different virtual function block.

1. In the Services module, add a [Data Transfer Rules Configuration](xref:SRM_properties_Booking_Manager#data-transfer-rules-configuration) property to the service definition and set its value to a JSON configuration describing when to trigger and which specific DTR rule to execute.
