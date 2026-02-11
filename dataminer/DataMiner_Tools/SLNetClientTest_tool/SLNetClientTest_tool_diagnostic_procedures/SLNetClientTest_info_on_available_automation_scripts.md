---
uid: SLNetClientTest_info_on_available_automation_scripts
---

# Retrieving information on the available automation scripts

From DataMiner 10.6.2/10.7.0 onwards<!--RN 44209-->, you can retrieve the following information about each automation script available in the DataMiner System:

- The folder containing the script's XML file

- Whether or not the script supports a dedicated log file

To do so:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to the *Build Message* tab of the main window.

1. In the *Message Type* dropdown list, select *GetAvailableAutomationScriptsRequestMessage*.

1. Click *Send Message*.

> [!NOTE]
> The above-mentioned message can only be used on systems with an *Automation* license by users who have the following permissions:
>
> - *Modules > Automation > UI available*
> - *Modules > Automation > Execute*

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
