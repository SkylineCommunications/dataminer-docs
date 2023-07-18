---
uid: SLNetClientTest_reinitialize_resourcemanager
---

# Reinitializing ResourceManager

From DataMiner 10.3.9/10.4.0 onwards, you can (re)initialize Resource Manager using the SLNetClientTest tool.<!-- RN36811 --> This can be useful if Resource Manager fails to initialize on DataMiner startup, and you want to try to initialize it again without restarting DataMiner.

> [!CAUTION]
> When you reinitialize Resource Manager, it will first be deinitialized and then initialized again. This can cause pending calls to fail, and new calls that are made while Resource Manager is being deinitialized will fail with the *ModuleNotInitialized* error.

> [!NOTE]
> In order to do this, you need the user permission [Modules > System configuration > Tools > Admin tools](xref:DataMiner_user_permissions#modules--system-configuration--tools--admin-tools).

To (re)initialize Resource Manager:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, go to *Apps* > *SRM Surveyor*.

1. At the bottom of the window, click *Reinitialize ResourceManager*.

   Resource Manager will be (re)initialized on the DataMiner Agent you are connected to.
