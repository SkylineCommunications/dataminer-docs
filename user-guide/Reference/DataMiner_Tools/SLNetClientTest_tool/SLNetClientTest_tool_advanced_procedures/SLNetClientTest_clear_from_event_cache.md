---
uid: SLNetClientTest_clear_from_event_cache
---

# Clearing alarms from the SLNet event cache

In case RTE alarms remain present in the SLNet alarm event cache, you can use the procedure below to clear these without having to restart the DMA.

To do:

1. In DataMiner Cube, get the alarm ID of the alarm you want to clear.

   You can do so by [making sure the Alarm ID column is displayed in the Alarm Console](xref:ChangingTheAlarmConsoleLayout#adding-or-removing-columns) and then copying the ID from there.

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to the *Build Message* tab.

1. In the *Message Type* drop-down list, select *GetAlarmDetailsMessage*.

1. Next to the *Int 32[] Array* for *AlarmIDs*, click the ... button.

1. Click *Add*, fill in the alarm ID you retrieved earlier, and click *OK*.

   ![Getting the alarm details](~/user-guide/images/SLNetClientTest_GetAlarmDetails.png)<br>
   *Example of getting the alarm details in DataMiner 10.3.3*

1. Click *Send Message*.

1. In the *Properties* tab, select the latest message, and then select the *Grid* tab on the right.

1. Copy the value next to *CacheKey*.

1. In the menu at the top, select *Advanced* > *Clear From* > *Event Cache*.

1. In the pop-up window, make sure *Message Type* is set to *AlarmEventMessage* and *Execute on Multiple Agents* is selected.

1. Paste the value you have copied in the *Cache Key Start* box, and click *GO*.

   ![Clearing alarms from the event cache](~/user-guide/images/SLNetClientTest_ClearAlarmFromEventCache.png)<br>
   *Example of clearing an alarm from the event cache in DataMiner 10.3.3*

1. If you are still logged in to DataMiner Cube, log out and log in again to see the change.

1. If the alarm is still showing in a DataMiner web app (e.g. Dashboards or Monitoring), restart IIS on the DMA you are connected to, to clear the alarm from the cache.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
