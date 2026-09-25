---
metadata_version: 1
uid: Protocol.HTTP.Session.Connection-ignoreTimeout
description: "Learn how the ignoreTimeout attribute prevents timeout alarms for one connection in an HTTP session in a DataMiner connector protocol."
---

# ignoreTimeout attribute

<!-- RN 10543 -->

If the HTTP connection should ignore timeout, set this attribute to *true*.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Connection](xref:Protocol.HTTP.Session.Connection)

## Remarks

This works in a similar way as the serial pair [ignoreTimeout](xref:Protocol.Pairs.Pair-options#ignoretimeout) option.

Default value: false.
