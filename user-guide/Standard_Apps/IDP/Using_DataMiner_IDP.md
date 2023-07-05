---
uid: Using_DataMiner_IDP
---

# Using DataMiner IDP

Before using DataMiner IDP, it's required that elements are added to the managed inventory of DataMiner IDP.
There are currently three options to start managing elements with DataMiner IDP:

1. **Use discovery and provisioning to detect equipment in the network.** After the equipment has been discovered, it can be provisioned (elements are created) in DataMiner. The elements will automatically be managed by DataMiner IDP. This workflow is typically used for equipment which is not yet monitored by DataMiner.
2. **Add existing elements to the managed inventory.** This workflow is typically used for equipment which is already monitored by DataMiner. This can be done via [Inventory > Unmanaged](xref:IDP_Inventory_tab)
3. **Import equipment from an 3rd party inventory system.** This workflow is typically used with OSS/BSS integrations.

Independently of which workflow is used to build the managed inventory, DataMiner IDP needs to have CI Types to be able to work with the elements in the managed inventory.

> [!NOTE]
> A Configuration Item Type (CI Type) defines of the behavior of elements in network implementation workflows as part of DataMiner IDP. This includes how to discover the device, provision an element, and perform software management, configuration management and more. A CI Type can be unique for a specific protocol or common for multiple element types, such as a product family

Different mechanisms are available to add CI Types to DataMiner IDP (see [CI Types](xref:CI_Types))

1. Generate CI Types from the connectors on the DMS.
2. Create a new CI Type.
3. Duplicate an existing CI Type.
4. Import a CI Type from another system.

This section details how to use the DataMiner IDP.

- [DataMiner IDP components](xref:DataMiner_IDP_components)

- [Overview of the IDP app UI](xref:Overview_of_the_IDP_app_UI)
