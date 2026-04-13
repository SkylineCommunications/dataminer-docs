---
uid: Protocol.Threads.Thread
---

# Thread element

Defines an additional thread.

## Parent

[Threads](xref:Protocol.Threads)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[connection](xref:Protocol.Threads.Thread-connection)|[TypeCommaSeparatedNumbers](xref:Protocol-TypeCommaSeparatedNumbers)|Yes|Specifies the connection ID, or a comma-separated list of different connection IDs.|
|[id](xref:Protocol.Threads.Thread-id)|[TypeNonLeadingZeroUnsignedInt](xref:Protocol-TypeNonLeadingZeroUnsignedInt)|No|Specifies a unique ID that can be used as a target for group execution.|
|[name](xref:Protocol.Threads.Thread-name)|[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)|No|Specifies a name for the thread.|

## Remarks

When you create an additional thread, you have to link it to a certain connection. This can be an actual connection or a virtual connection. Any group for that connection is then executed on that particular thread.

Each new thread will have its own group execution queue and runtime error thread registration.

The main protocol queue is always active.

Starting from DataMiner 10.4.9 (RN 38887), you can create different threads for the same connection by giving the thread an ID. Optionally, you can also give it a name, but this is currently only used for logging purposes. For now, creating multiple threads for the same connection is **only supported for HTTP and SNMP connections**. If you try to configure this for a different kind of connection, the thread will not be created, and an entry will be added in the element logging to explain why.

> [!NOTE]
> If you want to use a thread definition with an ID, all thread definitions will need to have an ID. Combining thread definitions with and without ID is not supported.

## Examples

In the following example, the second serial connection will use a different thread because it is linked to connection 1:

```xml
<Type advanced="serial">serial</Type>
<Threads>
  <Thread connection="1" />
</Threads>
```

The threads created by connections 1002 to 1004 are virtual (i.e., not linked to a real connection). They can be used if a group has to be executed in a different thread. It is advised to use larger ID (e.g., from 1000 onwards). This way, problems will be avoided if real connections are added afterwards.

```xml
<Type advanced="serial">serial</Type>
<Threads>
  <Thread connection="1" />
  <Thread connection="1002" />
  <Thread connection="1003" />
  <Thread connection="1004" />
</Threads>
```

To link a group to a thread, set the connection attribute to the connection ID of the thread. In the following example, group 600 will be executed on the thread with connection ID 1004.

```xml
<Group id="600" connection="1004">
  <Content>
     <Pair>600</Pair>
  </Content>
</Group>
```

In the following example, two threads will be created for the same HTTP connection.

```xml
<Threads>
  <Thread id="1" name="HTTP Polling Thread" connection="0"/>
  <Thread id="2" name="HTTP Control Thread" connection="0"/>
</Threads>
```

All polling requests can be executed on the *HTTP Polling Thread*, and simultaneously all control requests can be executed on the *HTTP Control Thread*. This way, control requests can be sent out as soon as they are triggered, instead of having to wait for a polling request to complete.

> [!NOTE]
> When multiple threads are used, it is important that each poll group has the [connection](xref:Protocol.Groups.Group-connection) attribute defined to indicate which connection/thread to use. This prevents unexpected behavior in SLPort when the same group is executed on different threads in a similar time frame.
