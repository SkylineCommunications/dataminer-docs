---
uid: SLNetClientTest_reinitialize_resourcemanager
---

# Reinitializing ResourceManager

> [!CAUTION]
> When reinitializing, ResourceManager will be deinitialized before being initialized. Pending calls might fail because of this. And new calls during the period ResourceManager is deinitialized will fail with the *ModuleNotInitialized* error.

From DataMiner 10.3.9/10.4.0 onwards, you can (re)initialize ResourceManager using the SLNet Client Test Tool.<!-- RN36811 -->
This can be useful if ResourceManager failed to initialize on DataMiner startup, and you want to retry initializing without restarting DataMiner.

> [!NOTE]
> You require the *'System configuration > Tools > Admin tools'* permission flag in order to do this.

To do this, follow the following steps:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, go to *Apps* > *SRM Surveyor*.

1. On the bottom, a *Reinitialize ResourceManager* button is available, if you press it, the ResourceManager on the DataMiner agent you are connected to, will be (re)initialized.
