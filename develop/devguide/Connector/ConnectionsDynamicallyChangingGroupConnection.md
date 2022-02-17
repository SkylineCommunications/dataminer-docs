---
uid: ConnectionsDynamicallyChangingGroupConnection
---

# Dynamically changing a connection of a group

It is possible to dynamically select the connection to be used for a group using the connectionPID attribute.

The value of the parameter the connectionPID attribute refers to is the 0-based connection index number of the connection to be used.

In the example below, parameter 2 contains the ID of the connection that needs to be used to execute HTTP session 1.

```xml
<Group id="1" connectionPID="2">
  <Content>
     <Session>1</Session>
  </Content>
</Group>
```

> [!NOTE]
> For HTTP connections, it is not yet possible to use this feature in combination with the "dynamic ip" option like for serial connections.

## See also

DataMiner Protocol Markup Language:

- [Protocol.Groups.Group@connectionPID](xref:Protocol.Groups.Group-connectionPID)
