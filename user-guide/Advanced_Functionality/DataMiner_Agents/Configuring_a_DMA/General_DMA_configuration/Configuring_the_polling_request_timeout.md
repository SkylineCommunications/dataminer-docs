---
uid: Configuring_the_polling_request_timeout
---

# Configuring the polling request timeout

By default, the DMA polling request timeout is set to 60 seconds. If necessary, it can be changed both server-side and client-side.

DMA polling should not be confused with device polling. It enables DMAs to send notifications to other DMAs in the DataMiner System or to client applications.

## Server-side

In the *MaintenanceSettings.xml* file of a DMA, you can add a *\<DefaultPollingRequestTimeout>* tag in the *\<SLNet>* section.

This setting will apply to all new inter-DMA connections set up from that DMA.

> [!TIP]
> See also: [Configuring SLNet settings in MaintenanceSettings.xml](xref:Configuration_of_DataMiner_processes#configuring-slnet-settings-in-maintenancesettingsxml)

## Client-side

On a DataMiner client machine, you can set the client’s polling request timeout by creating an environment variable named *SLNETTYPES* and setting its value to “pollingTimeout=xxx” (xxx being an amount of seconds).
