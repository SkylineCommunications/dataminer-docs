---
uid: Protocol.SystemOptions.RunInSeparateInstance
description: "Learn how RunInSeparateInstance configures a protocol so that every element using it runs in its own SLProtocol and SLScripting instances."
---

# RunInSeparateInstance element

Allows you to flag a protocol as requiring a separate SLProtocol and SLScripting instance because of memory load. <!-- RN 33358 -->

> [!NOTE]
> From DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4 onwards<!--RN 41758-->, you can configure a specific element to run in its own SLProtocol and SLScripting process using the [*Run in isolation mode* option](xref:Adding_elements#adding-elements-in-isolation-mode). This allows you to isolate individual elements without affecting all elements using the same protocol.

## Type

Boolean

## Parent

[SystemOptions](xref:Protocol.SystemOptions)

## Remarks

- Alternatively, you can run elements separately by referencing the protocol in *DataMiner.xml*. See [Configuring separate SLProtocol and SLScripting instances for a specific protocol](xref:Configuration_of_DataMiner_processes#configuring-separate-slprotocol-and-slscripting-instances-for-a-specific-protocol).

- This option can be used to flag protocols that require a lot of memory in SLScripting and SLProtocol or protocols that cause SLScripting issues and need to be isolated until they have been made stable.

## Example

```xml
<RunInSeparateInstance>true</RunInSeparateInstance>
```
