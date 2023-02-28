---
uid: CloudPackages
---

# DataMiner Cloud Packs

DataMiner Cloud Packs are packages that include the necessary DataMiner Extension Modules (DxMs) to enable dataminer.services capabilities.

At the moment, there are two different types of Cloud Packs: packages for DMAs with internet connectivity, and packages for DMAs without internet connectivity. Depending on the type of Cloud Pack, different DataMiner Extension Modules will be installed on the DMA.

> [!TIP]
> See also: [DataMiner Extension Modules](xref:DataMinerExtensionModules)

## Types of Cloud Packs

### For DMAs with internet connectivity

This is the standard DataMiner Cloud Pack that can be downloaded from [DataMiner Dojo](https://community.dataminer.services/downloads/). It includes all DxMs needed to use the DataMiner Cloud Services.

If you install this package on a DMA with internet connectivity in your DMS, you will be able to benefit from all features provided by dataminer.services.

### For DMAs without internet connectivity

> [!IMPORTANT]
> This pack is not yet available.

This Cloud Pack will contain the DxMs that do not need internet functionality to operate.

Included modules:

- [CoreGateway](xref:DataMinerExtensionModules#coregateway)
- [FieldControl](xref:DataMinerExtensionModules#fieldcontrol)
- [Orchestrator](xref:DataMinerExtensionModules#orchestrator)
- [SupportAssistant](xref:DataMinerExtensionModules#supportassistant)

> [!NOTE]
> You will always need to install the standard DataMiner Cloud Pack on at least one DMA with internet connectivity before you can use the features provided by dataminer.services.
