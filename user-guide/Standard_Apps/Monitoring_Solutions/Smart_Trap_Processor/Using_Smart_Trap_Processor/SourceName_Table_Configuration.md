---
uid: SourceName_table_configuration
---

# Source Name Table Configuration

The names defined in the *Source Names* table determine the value that is used for the *Source Name* parameter on the *Processed Messages* table. This could be useful as it gives each event row on the *Processed Messages* table a description of which device or system the trap pertains to. For example, if the traps processed on a particular row correspond to a temperature alarm in Rack #1 of the datacenter, the source name defined could be “Temp Sensor – Rack #1”.

The source name definition can also utilize binding placeholders rather than a hard coded string so that the displayed source name is dynamic based on the processed trap. In most cases, this should be set to something that will always match between the raised and cleared event states. 

> [!NOTE]
> This table is not required for traps to be processed properly. This table is most applicable if a single trap processor element is being used to process traps pertaining to more than one device.

![Trap Processor Source Name Table](~/user-guide/images/TrapProcessor_SourceNameTable.png)

- *Priority*: Defines a priority for the source name rule. The received trap wil be processed by the first matching source name rule.
- *IP Address*: IP Address that will be used to match with the received traps. This needs to match at least one of the IP addreses defined in the standalone “Trap IP Sources” parameter.
- *Source Name*: The value/format entered will be used to determine what is displayed on on the Source Name parameter for each row on the Processed Messages table.

    > [!NOTE]
    > The value entered can be a hardcoded string or can utilize the following place holders:
    > - Binding n: $n

- *Binding 1-20 Filter*: Wildcard filters can be defined for any of the data present in a trap’s bindings. Each binding has its own filter (binding 1-20). If a filter is specified, traps will only be processed by the rule if the information in the binding matches the filter. 

    > [!NOTE]
    > the filters are case sensitive and the following wildcard functionality is available:
    > - value*, *value, *value*, value?, ?value, ?value?

- *Delete*: When pressed, the rule will be deleted.
- *Duplicate*: When pressed, the rule will be duplicated wth a different priority. 
