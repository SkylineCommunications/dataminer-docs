---
uid: AdvancedMultiThreading
---

# Multi-threading

For each element, a main protocol execution thread is created in the SLProtocol process (see Inner workings). In a protocol, it is possible to specify that additional threads should be created. This can be useful, for example, to separate time-critical actions from the polling of a device.

An extra thread in a driver is linked to a connection. This can be a real connection (e.g. SNMP, serial, etc.) or a virtual connection (for non-polling related functionality, e.g. implementing cleanup). The new thread has its own group execution queue and RTE registration.

> [!NOTE]
> When a new thread is specified for a virtual connection, a connection ID of 1001 or higher is used.

The following example defines an HTTP connection (the main connection) and a serial connection.

```xml
<Type relativeTimers="true" advanced="serial:mySerialConnection">http</Type>
```

Next to the main execution thread (which is always created and active), a number of additional threads are defined. The thread with connection ID 1 will correspond with the serial connection. The other threads (with ID >1000) are threads used to execute logic that is not related to connections defined in the Type tag.

```xml
<Threads>
   <Thread connection="1" /> <!-- 2nd Device connection = serial. -->
   <Thread connection="1001" /> <!-- Internal 1. -->
   <Thread connection="1002" /> <!-- Internal 2. -->
</Threads>
```

The connection attribute can be used to specify which thread should execute the group.

```xml
<Group id="1" connection="0">
   <Name>Get XML File</Name>
   <Description>Get XML File</Description>
   <Content>…</Content>
</Group>
<Group id="2" connection="1">
   <Name>Serial-Get A</Name>
   <Description>Serial-Get A</Description>
   <Type>poll</Type>
   <Content>…</Content>
</Group>
<Group id="3" connection="1001">
   <Name>InternalThread1</Name>
   <Description>InternalThread1</Description>
   <Type>poll action</Type>
   <Content>…</Content>
</Group>
<Group id="4" connection="1002">
   <Name>InternalThread2</Name>
   <Description>InternalThread2</Description>
   <Type>poll action</Type>
   <Content>…</Content>
</Group>
<Group id="5" connection="1002">
   <Name>InternalThread2-2</Name>
   <Description>InternalThread2-2</Description>
   <Type>poll action</Type>
   <Content>…</Content>
</Group>
```

The connection attribute contains the connection ID or a comma-separated list of different connection IDs.

## See also

DataMiner Protocol Markup Language:

- [Protocol.Threads](xref:Protocol.Threads)
