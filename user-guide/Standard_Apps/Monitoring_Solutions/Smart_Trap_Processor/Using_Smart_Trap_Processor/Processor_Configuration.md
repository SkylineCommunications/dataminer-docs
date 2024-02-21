---
uid: Processor_configuration
---

# Trap Processor Configuration

Configuration of each processor element present in the system can be performed from either Cube or the unified low code application. All configurations described in the following sections apply regardless of which interface is being used. On the *Processor Configuration* page, you will find all of the essential configuration tables for the selected Processor element running on the DataMiner system.  

Before defining rules for how traps are processed, you must first specify an IP address for which traps will be sent from to be received by the DataMiner agent hosting the processor element.

![Smart Trap Processor IP Sources](~/user-guide/images/TrapProcessor_IPSources.png)

- *Trap IP Sources*: Specify the IP address corresponding to the source of SNMP traps being sent to the DataMiner system. 
    - Example: This could be the IP address of an SNMP manager which aggregates traps for many devices or could be the IP address corresponding to a singe device.

After a Trap source IP is entered, proceed to the rest of the processing configurations available on the [Rules table](xref:Rules_table_configuration), [Source Name table](xref:SourceName_table_configuration), [Source IP Name table](xref:SourceIPName_table_configuration), and [Auto-Clear section](xref:AutoClear_configuration).
