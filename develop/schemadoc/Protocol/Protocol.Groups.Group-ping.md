---
uid: Protocol.Groups.Group-ping
---

# ping attribute

<!-- RN 16626, RN 16633 -->

Specifies whether this is the group to be used when testing the connection in the element wizard.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Group](xref:Protocol.Groups.Group)

## Remarks

When you [create or update an element](xref:Adding_elements), it is possible to first test the connection with the data you entered before creating or updating the element:

- If you click a Test connection button, you will either get a "Connection successful" message or an error message explaining why the test failed.
- If a Test connection button is disabled, hover over it to see the reason why it is disabled.

You can only test connections for which a ping group has been defined in the protocol. When you click Test connection, the ping group for that connection will be executed. If this execution results in a timeout, the connection test will fail.

> [!NOTE]
> Current limitations:
>
> - Only main connections can be tested.
> - Ping groups are not executed when an element is in slow poll mode.

## Examples

```xml
<Group id="6" ping="true">
   <Name>sysUptime</Name>
   <Description>System Uptime</Description>
   <Content>
      <Param>6</Param>
   </Content>
</Group>
```
