---
uid: Protocol.SystemOptions.RunInSeparateInstance
---

# RunInSeparateInstance element

Allows you to flag a protocol as requiring a separate SLProtocol and SLScripting instance because of memory load.

## Type

Boolean

## Parent

[SystemOptions](xref:Protocol.SystemOptions)

## Remarks

This feature is introduced in DataMiner 10.2.7 (RN 33358). It extends the functionality of RN 32742, introduced in 10.2.5, which allows you to run elements separately by referencing the protocol in *DataMiner.xml*. See [Configuring separate SLProtocol and SLScripting instances for a specific protocol](xref:Configuration_of_DataMiner_processes#configuring-separate-slprotocol-and-slscripting-instances-for-a-specific-protocol).

This option can be used to flag protocols that require a lot of memory in SLScripting and SLProtocol or protocols that cause SLScripting issues and need to be isolated until they have been made stable.

## Example

```xml
<RunInSeparateInstance>true</RunInSeparateInstance>
```
