---
uid: SourceIPName_table_configuration
---

# Source IP Name Table Configuration

The Source IP Names defined in this table dictate the value displayed on the *Source IP Name* parameter in the *Processed Messages* table. The name chosen should be descriptive of the device or system corresponding to the IP address set on the *Trap IP Sources* parameter. For example, If the source IP set on the processor corresponds to a Compass brand trap management system, the Source IP name entered could be “Compass Manager”.

> [!NOTE]
> This table is not required for traps to be processed properly.

![Trap Processor Source IP Name Table](~/user-guide/images/TrapProcessor_SourceIPNameTable.png)

- *IP Address*: IP Address that will be used to match with the received traps. This needs to match at least one of the IP addresses defined in the standalone “Trap IP Sources” parameter.

- *Source IP Name*: The value/format entered will be used to determine what is displayed on on the Source IP Name parameter for each row on the Processed Messages table.

- *Delete*: When pressed, the rule will be deleted.
