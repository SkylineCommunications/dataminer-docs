---
uid: Protocol.SystemOptions.RunInSeparateInstance
---

# RunInSeparateInstance element

Allows you to flag a protocol as requiring a separate SLProtocol and SLScripting instance due to memory load.

This feature was introduced in DataMiner 10.2.7 (RN 33358).

# Type

bool

## Parent

[SystemOptions](xref:Protocol.SystemOptions)

## Remarks

This feature extends on RN32742, which was introduced in 10.2.5, where elements could be run separately by referencing the protocol in the DataMiner.xml: [Configuration of DataMiner processes](xref:Configuration_of_DataMiner_processes)

The intention behind this option is to flag protocols that require a lot of memory in SLScripting and SLProtocol, or that are prone to crash SLScripting and need to be isolated until they have been made stable.

## Examples

```xml
<RunInSeparateInstance>true</RunInSeparateInstance>
```
