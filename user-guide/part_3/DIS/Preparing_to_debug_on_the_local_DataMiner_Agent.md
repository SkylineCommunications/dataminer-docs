---
uid: Preparing_to_debug_on_the_local_DataMiner_Agent
---

## Preparing to debug on the local DataMiner Agent

Proceed as follows if you want to debug a QAction or an Automation script located on the DataMiner Agent that is running on your local computer.

1. Run Visual Studio as an Administrator.

2. If you are using Visual Studio 2015, go to *Tools \> Options \> Debugging*, and select the *Use Managed Compatibility Mode* option.

3. Make sure that, in the *DMA* tab of the *DIS Settings* window, you have added your local DataMiner Agent with the correct user account and you have not selected its *Enable remote debugging* option.

    See [DMA](DIS_settings.md#dma)

You are now ready to start debugging. See [Debugging a QAction](Debugging_a_QAction.md) or [Debugging an Automation script](Debugging_an_Automation_script.md).
