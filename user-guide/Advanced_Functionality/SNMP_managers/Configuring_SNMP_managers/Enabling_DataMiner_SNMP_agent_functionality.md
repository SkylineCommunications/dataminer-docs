---
uid: Enabling_DataMiner_SNMP_agent_functionality
---

# Enabling DataMiner SNMP agent functionality

From DataMiner 9.6.11 onwards, the DataMiner SNMP agent functionality is disabled by default, so that polling of active alarms and general DataMiner information is not possible.

To enable this functionality:

1. Stop the DataMiner software.

2. Open the file *C:\\Skyline DataMiner\\DataMiner.xml*.

3. Set the *enableDataMinerAgentPolling* attribute of the *\<SNMP>* tag to “true”.

    ```xml
    <DataMiner>
      ...
      <SNMP enableDataMinerAgentPolling="true" />
      ...
    </DataMiner>
    ```

4. Save the file.

5. Restart the DataMiner software.

> [!NOTE]
> If a DMA was installed prior to DataMiner 9.6.11 and is upgraded to DataMiner 9.6.11 or higher, this functionality will remain enabled.
