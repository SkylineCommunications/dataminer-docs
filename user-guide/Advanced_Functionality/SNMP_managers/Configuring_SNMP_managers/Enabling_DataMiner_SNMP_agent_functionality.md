---
uid: Enabling_DataMiner_SNMP_agent_functionality
---

# Enabling DataMiner SNMP agent functionality

By default, the DataMiner SNMP agent functionality is disabled, so that polling of active alarms and general DataMiner information is not possible.

To enable this functionality:

1. Stop the DataMiner software.

1. Open the file `C:\Skyline Dataminer\DataMiner.xml`.

1. Set the *enableDataMinerAgentPolling* attribute of the *\<SNMP>* tag to "true".

   ```xml
   <DataMiner>
     ...
     <SNMP enableDataMinerAgentPolling="true" />
     ...
   </DataMiner>
   ```

1. Save the file.

1. Restart the DataMiner software.
