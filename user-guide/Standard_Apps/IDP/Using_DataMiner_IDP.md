---
uid: Using_DataMiner_IDP
---

# Using DataMiner IDP

Before you start using DataMiner IDP, you need to **make sure elements are added to the managed inventory** of DataMiner IDP. There are currently three options to start managing elements with DataMiner IDP:

- **Use discovery and provisioning to detect equipment in the network.** This can be done via [Inventory > Discovered](xref:IDP_Inventory_tab#discovered) in the IDP app. After the equipment has been discovered, it can be provisioned (elements are created) in DataMiner. The elements will automatically be managed by DataMiner IDP. This workflow is typically used for equipment that is not yet monitored by DataMiner.

- **Add existing elements to the managed inventory.** This workflow is typically used for equipment that is already monitored by DataMiner. This can be done via [Inventory > Unmanaged](xref:IDP_Inventory_tab#unmanaged) in the IDP app.

- **Import equipment from a third-party inventory system.** This workflow is typically used with OSS/BSS integrations. It involves using a specific connector to integrate with the inventory. When the connector detects changes in the inventory, it generates tokens for Process Automation processes with IDP functions. These processes can provision elements, perform configuration backups, assign elements to racks, and more. The same principle applies when [using an IS-04 registry to provision elements](xref:Using_your_IS04_registry_to_provision_DataMiner_with_IDP).

Regardless of which workflow is used to build the managed inventory, DataMiner IDP needs to have **CI Types** to be able to work with the elements in the managed inventory. A Configuration Item Type (CI Type) defines the behavior of elements in network implementation workflows as part of DataMiner IDP. This includes how to discover the device, provision an element, and perform software management, configuration management, and more. A CI Type can be unique for a specific protocol or common for multiple element types, such as a product family.

Different mechanisms are available to add CI Types to DataMiner IDP (see [CI Types](xref:CI_Types)):

- Generate CI Types from the protocols in the DMS.

- Create a new CI Type.

- Duplicate an existing CI Type.

- Import a CI Type from another system.
