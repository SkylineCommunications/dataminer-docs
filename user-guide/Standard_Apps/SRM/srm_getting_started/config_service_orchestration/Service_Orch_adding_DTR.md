---
uid: Service_Orch_adding_DTR
---

# Adding DTR (optional)

In some cases, specific information that is set into an applied profile instance of a virtual function could be useful to transfer to another virtual function of the same service definition. This is done with [Data Transfer Rules (DTR)](xref:srm_scripting#data-transfer-rules-dtr).

To configure DTR:

1. Start from the available *SRM_DataTransferRulesTemplate* script to create a first DTR script.

1. Configure the script to process information and set this information on a different virtual function block.

1. In the Services module, add a *Data Transfer Rules Configuration* property to the service definition, which will determine when to trigger and which specific DTR rule to execute:

   1. Select the service definition.

   1. Go to the *properties* tab at the top.

   1. Click *Add* to add a property.

   1. In the *New property* box, specify the property name *Data Transfer Rules Configuration*.

   1. Set the property value to the JSON configuration described under [Data Transfer Rules Configuration](xref:SRM_properties_Booking_Manager#data-transfer-rules-configuration).

> [!TIP]
> For advanced configuration info, see [Service Orchestration Data Transfer Rules configuration](xref:Service_Orchestration_DTR).
