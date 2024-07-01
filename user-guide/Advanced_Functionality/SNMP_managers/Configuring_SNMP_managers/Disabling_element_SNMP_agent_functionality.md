---
uid: Disabling_element_SNMP_agent_functionality
---

# Disabling element SNMP agent functionality

Up to DataMiner 9.5.14, it is possible to disable the SNMP agent function of all elements on a DMA on system level.

To do so:

1. Stop the DataMiner software.

1. Open the file *C:\\Skyline DataMiner\\DataMiner.xml*.

1. Set the *disableAgent* attribute of the *\<SNMP>* tag to “true”.

   ```xml
   <DataMiner>
     ...
     <SNMP disableAgent="true" />
     ...
   </DataMiner>
   ```

1. Save the file.

1. Restart the DataMiner software.

> [!NOTE]
>
> - If you disable the SNMP agent function of all elements on a DataMiner Agent, third-party applications that poll DataMiner over SNMP will no longer receive responses from DataMiner, not even from elements of which the SNMP agent option is enabled on their virtual IP address.
> - This feature is no longer available from DataMiner 9.5.14 onwards.
