---
uid: SLNetClientTest_clear_from_event_cache
---

# Clear Alarm from SLNet Event Cache

Below procedure avoids DMA restart in the case RTE alarms stayed present in the SLNet alarm event cache.

To do:

1. Get the Alarm ID from the alarm card. 

   ![Get alarm id](~/images/Contrib_AlarmId.png)

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Get the alarm details in order to find the cache key. 
   
   ![Get alarm details](~/images/Contrib_GetAlarmDetails.png)

1. With the cache key, open the *Clear From Event Cache* tool, in the *Advanced* menu, select *Clear From.* and then select *Event Cache*, to clear the alarm in all the DMAs. 

   ![Get alarm details](~/images/Contrib_ClearAlarmFromEventCache.png)

1. After execute the command, If you're logged in, you will need to logoff and re-login first before seeing any change.

> [!NOTE]
> From DataMiner 10.0.0 CU15/10.1.0 CU4/10.1.7 onwards, if DataMiner fails to automatically detect the SLNet target port (via port 80 or 443), the connection attempt will continue on the default port 8004. To skip this auto-detection and immediately use the default port 8004, you can set the connection string to *auto://nodetect*. This can for instance be useful in case port 80 is blocked between the DMAs.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.