---
uid: Service_Orchestration_DTR
---

# Service Orchestration: Data Transfer Rules configuration

[Data Transfer Rules](xref:srm_scripting#data-transfer-rules-dtr) are implemented using custom Automation scripts.

## Configuring regular Data Transfer Rules

When you have added a DTR as described under [Adding DTR](xref:Service_Orch_adding_DTR), you should set the *Data Transfer Rules Configuration* property of the service definition to a JSON configuration described under [Data Transfer Rules Configuration](xref:SRM_properties_Booking_Manager#data-transfer-rules-configuration).

Below you can find an example of such a configuration for regular Data Transfer Rules:

```json
{
  "Script": "SRM_DTR_SatelliteReception",
  "Triggers": [
    {
      "NodeLabel": "Satellite",
      "TriggerType": "ProfileInstance"
    },
    {
      "InterfaceId": 1,
      "NodeLabel": "Demodulator",
      "TriggerType": "ProfileInstance"
    },
    {
      "NodeLabel": "Demodulator",
      "TriggerType": "Parameter",
      "ParameterName": "Modulation"
    },
    {
      "NodeLabel": " Demodulator ",
      "TriggerType": "Resource",
    }
  ]
}
```

In this example:

- **Script**: The name of the script.

- **NodeLabel**: The label of the node in the service definition triggering the script.

- **TriggerType**: The type of trigger of the script. The following values are supported: *ProfileInstance*<!-- RN 27352 -->, *Parameter*, or *Resource*.

- **InterfaceId**: Optional. The ID of the interface triggering the script. Only applicable when *TriggerType* is *Parameter* or *ProfileInstance*.

- **ParameterName**: The name of the parameter triggering the rule. Only applicable when *TriggerType* is *Parameter*.

The class modeling the rules is *Skyline.DataMiner.Library.Solutions.SRM.Model.DataTransferRules.DataTransferRulesConfiguration*.

## Configuring service profile Data Transfer Rules

<!-- RN 29069 -->

To create a service profile Data Transfer Rule:

1. Create a service profile DTR script based on the example script delivered with the framework (*SRM_ServiceProfileDataTransferTemplate*).

1. In the Services module add a *Service Profile Data Transfer Configuration* property to the service definition:

   1. Select the service definition.

   1. Go to the *properties* tab at the top.

   1. Click *Add* to add a property.

   1. In the *New property* box, specify the property name *Service Profile Data Transfer Configuration*.

1. Set the property value to a JSON string referencing the script. For example:

   ```json
   {"Script":"SRM_ServiceProfileDataTransfer_Preencoding"}
   ```

> [!NOTE]
> When the selected service profile definition/instance does not refer to one or more nodes of the service definition, the *GetUnmappedFunction* method must be used to access data from those nodes (i.e. the selected resources). <!-- RN 30630 -->
