---
uid: Protocol.Groups.Group-connectionPID
---

# connectionPID attribute

Specifies the ID of the parameter that holds the number of the connection to use.

## Content Type

unsignedInt

## Parent

[Group](xref:Protocol.Groups.Group)

## Remarks

> [!NOTE]
> The parameter that is referred to by this attribute must have Interprete/Type set to "string".

Via this attribute, it is possible to dynamically select an HTTP connection by referring to the connection by means of a parameter ID. This way it is possible to switch connection at runtime.

In the following example, parameter 2 contains the ID of the connection that needs to be used. Depending on the value, HTTP session 1 will be executed via that specific connection:

```xml
<Group id="1" connectionPID="2">
    <Content>
        <Session>1</Session>
    </Content>
</Group>
```
