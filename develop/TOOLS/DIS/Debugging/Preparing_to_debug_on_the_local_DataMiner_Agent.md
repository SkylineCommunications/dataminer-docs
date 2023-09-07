---
uid: Preparing_to_debug_on_the_local_DataMiner_Agent
---

# Preparing to debug on the local DataMiner Agent

Proceed as follows if you want to debug a QAction or an Automation script located on the DataMiner Agent that is running on your local computer.

1. Run Visual Studio as an Administrator.
1. If you are using Visual Studio 2015, go to *Tools \> Options \> Debugging*, and select the *Use Managed Compatibility Mode* option.
1. Make sure that, in the *DMA* tab of the *DIS Settings* window, you have added your local DataMiner Agent with the correct user account and you have not selected its *Enable remote debugging* option.

    See [DMA](xref:DIS_settings#dma)

You are now ready to start debugging. See [Debugging a connector](xref:Debugging_a_connector) or [Debugging an Automation script](xref:Debugging_an_Automation_script).
