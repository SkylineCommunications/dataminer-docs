---
metadata_version: 1
uid: Protocol.Groups.Group.Content.Session-connection
description: "Reference the DataMiner connector protocol schema entry for connection attribute, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# connection attribute

<!-- RN 9928 -->

If you want to execute only a specific connection within a certain session, then use the connection attribute to specify the connection.

## Content Type

unsignedInt

## Parent

[Session](xref:Protocol.Groups.Group.Content.Session)

## Examples

```xml
<Group id="8">
   <Content>
       <Session connection="1">8</Session>
   </Content>
</Group>
```
