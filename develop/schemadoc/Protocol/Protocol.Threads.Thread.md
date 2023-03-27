---
uid: Protocol.Threads.Thread
---

# Thread element

Defines an additional thread.

## Parent

[Threads](xref:Protocol.Threads)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[connection](xref:Protocol.Threads.Thread-connection)|[TypeSemicolonSeparatedNumbers](xref:Protocol-TypeSemicolonSeparatedNumbers)|Yes|Specifies the connection ID, or a comma-separated list of different connection IDs.|

## Remarks

When you create an additional thread, you have to link it to a certain connection. This can be an actual connection or a virtual connection. Any group for that connection is then executed on that particular thread.

Each new thread will have its own group execution queue and runtime error thread registration.

The main protocol queue is always active.

## Examples

In the following example, the second serial connection will use a different thread because it is linked to connection 1:


```xml
<Type advanced="serial">serial</Type>
<Threads>
  <Thread connection="1" />
</Threads>
```

In the following example, the second serial connection will use a different thread because it is linked to connection 1.

The threads created by connections 1002 to 1004 are virtual (i.e. not linked to a real connection). They can be used if a group has to be executed in a different thread. It is advised to use larger ID (e.g. from 1000 onwards). This way, problems will be avoided if real connections are added afterwards.


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

> [!NOTE]
> When multiple threads are used, it is important that each poll group has the [connection](xref:Protocol.Groups.Group-connection) attribute defined to indicate which connection/thread to use. This prevents unexpected behavior in SLPort when the same group is executed on different threads in a similar time frame.
