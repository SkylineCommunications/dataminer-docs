---
uid: Service_Orch_creating_service_definitions
---

# Creating service definitions

To move from a single function to a full service workflow, you need one or more [service definitions](xref:srm_definitions#service-definition).

You can create service definitions in the [Services module](xref:SRM_Services_definitions):

1. On the *definitions* tab of the Services module, click the *Add definition* button.

1. In the [configuration tab](xref:SRM_Services_definitions#configuration-tab) of the main page, drag the necessary virtual functions to the diagram pane and connect them.

1. Define a label for each of the virtual functions, so that they can be uniquely identified in case multiple instances of the same virtual functions are used within the same service definition. To do so, select the virtual function in the diagram and specify the label in the pane below.

1. Add a *Virtual Platform* property to the service definition and set its value to the [virtual platform](xref:srm_instantiations#virtual-platform) name.

> [!TIP]
> To check if everything is configured correctly, you can now create a test booking. Try to create a booking using the Booking Manager app, and check if the available resources are correctly filtered and added.
