---
metadata_version: 1
uid: Protocol.HTTP.Session-ignoreTimeout
description: "Reference the DataMiner connector protocol schema entry for ignoreTimeout attribute, including its documented structure, attributes, values, and constrain."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# ignoreTimeout attribute

<!-- RN 12542 -->

If the HTTP connection should ignore timeout for this session, set this attribute to *true*.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Session](xref:Protocol.HTTP.Session)

## Remarks

Default value: false

When this attribute is set to true, a timeout alarm will not be generated for this session. Note, however, that the trigger after timeout will still go off.

This behavior is similar to the serial pair [ignoreTimeout](xref:Protocol.Pairs.Pair-options#ignoretimeout) option.

## Examples

```xml
<Session id="6" ignoreTimeout="true">
   <Connection id="1">
      <Request verb="GET" url="/403">
      </Request>
      <Response statusCode="100">
         <Content pid="200"></Content>
      </Response>
   </Connection>
</Session>
```
