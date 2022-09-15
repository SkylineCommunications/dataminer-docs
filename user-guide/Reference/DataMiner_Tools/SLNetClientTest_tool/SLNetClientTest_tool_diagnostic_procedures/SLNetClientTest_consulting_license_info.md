---
uid: SLNetClientTest_consulting_license_info
---

# Consulting license information for a DMA

> [!NOTE]
> To view license information regarding third-party software, go to *http(s)://**\[DMA name or IP\]**/Licenses* (available from DataMiner 9.5.14 onwards).

After you have [connected to a DMA with the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool), do the following to get a list of all the applications the DMA is licensed for, the license verification method, and the license expiration date:

- In the *Info* menu, select *A -M* > *Licenses*.

  In the *Properties* tab of the main window, a new message will appear. You can double-click the message to read the details in a separate window, or select the message and read the details in the *Text* pane on the right.

To get an overview of the number of elements monitored with license counters, do the following

- In the *Info* menu, select *A -M* > *ActivatedLicenseCounters*.

  In the *Properties* tab of the main window, a new message will appear. You can double-click the message to read the details in a separate window, or select the message and read the details in the *Text* pane on the right.

  > [!NOTE]
  > To know the total number allowed by the license, in the list of applications a DMA is licensed for, look for keys with a number at the end, e.g. ELEMENTS500, SPECTRUMELEMENTS10, PROTOCOLMICROSOFTPLATFORM:5. The number indicates the total allowed license counters.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
