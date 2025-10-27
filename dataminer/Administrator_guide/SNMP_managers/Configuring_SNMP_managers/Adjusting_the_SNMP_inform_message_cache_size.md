---
uid: Adjusting_the_SNMP_inform_message_cache_size
---

# Adjusting the SNMP inform message cache size

To handle situations where inform messages are sent out again while they have already been acknowledged by DataMiner, from DataMiner 10.2.0/10.1.4 onwards, DataMiner by default keeps the latest 20 inform messages per SNMP entity in a cache, so that it can check whether an incoming inform message has already been processed, and discard it if it has.

In the *DataMiner.xml* file, you can customize how many inform messages are stored in the cache. To do so:

1. Stop the DataMiner software.

1. Open the file `C:\Skyline Dataminer\DataMiner.xml`.

1. Set the *informCacheSize* attribute of the *SNMP* tag to the number of inform messages that should be stored. For example:

   ```xml
   <DataMiner>
    ...
    <SNMP informCacheSize="25" />
    ...
   </DataMiner>
   ```

1. Save the file.

1. Restart the DataMiner software.

> [!NOTE]
>
> - If you set *informCacheSize* to 0, the cache will be disabled.
> - Only inform messages are stored in this cache, not traps.
> - When an inform message is discarded, this is logged in *SLSNMPManager.txt* on information level 3.
