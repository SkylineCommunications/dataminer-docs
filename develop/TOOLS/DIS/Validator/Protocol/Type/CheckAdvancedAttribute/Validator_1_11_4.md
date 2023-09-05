---  
uid: Validator_1_11_4  
---

# CheckAdvancedAttribute

## EmptyAttribute

### Description

Empty attribute 'Protocol\/Type@advanced'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Protocol    |
| Full Id      | 1.11.4      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

\- When having only one connection for a specific type, the name needs to be of following format, where the second option can (optionally) be used to add more info about the goal of the connection (ex: XXX \= Traps, XXX \= Events, XXX \= Alarms, etc):  
     \- "IP Connection" or "IP Connection \- XXX": for drivers that support TCP and\/or UDP  
     \- "HTTP Connection" or "HTTP Connection \- XXX"  
     \- "SNMP Connection" or "SNMP Connection \- XXX"  
     \- "Serial Connection" or "Serial Connection \- XXX": for drivers that only support the physical serial port (driver connection of type serial but not support TCP nor UDP)  
\- When having more than one connection for a specific type, the name need to be of following format where XXX is used to distinguish them (ex: XXX \= Redundant, XXX \= Redundant 2, XXX \= Backup, XXX \= Traps, XXX \= Events, etc):  
     \- "IP Connection \- XXX"  
     \- "HTTP Connection \- XXX"  
     \- etc
