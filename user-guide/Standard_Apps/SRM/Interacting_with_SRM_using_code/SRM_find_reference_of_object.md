---
uid: SRM_find_reference_of_object
---

# Finding the reference of an SRM object

To configure custom Automation scripts so that they can manipulate SRM objects such as service definitions, resources, profiles, etc., you need to know their object reference.

You can find this using the SLNetClientTest tool.

> [!WARNING]
> Always be extremely careful when using SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

To do so:

1. Open the tool. See [Opening the SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool).

1. Connect to the DMA. See [Connecting to a DMA with the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Advanced* > *App* > *SRM Surveyor* to open the SRM Surveyor.

1. Select the object type and click *Select Object Type*.

   For example:

   - A service definition GUID

     ![Example of service definition GUID in SLNetClientTest tool](~/user-guide/images/ServiceDefinitionGUID.png)

   - A node ID

     ![Example of node ID in SLNetClientTest tool](~/user-guide/images/NodeID.png)

   - A resource GUID

     ![Example of resource GUID in SLNetClientTest tool](~/user-guide/images/ResourceGUID.png)

   - A profile definition GUID

     ![Example of profile definition GUID in SLNetClientTest tool](~/user-guide/images/ProfileDefinitionGUID.png)

   - A profile instance GUID

     ![Example of profile instance GUID in SLNetClientTest tool](~/user-guide/images/ProfileInstanceGUID.png)
