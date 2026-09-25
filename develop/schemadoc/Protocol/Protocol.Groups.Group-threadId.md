---
metadata_version: 1
uid: Protocol.Groups.Group-threadId
description: "Learn how the threadId attribute selects the protocol thread that executes a group in a DataMiner connector protocol."
---

# threadId attribute

Specifies the ID of the thread that should execute the group.

## Content Type

int

## Parent

[Group](xref:Protocol.Groups.Group)

## Remarks

If you try to execute a group on a thread that does not exist, the group will be executed on the main protocol thread.

As a specific thread can have multiple connections linked to it, you will also need to specify the [connection](xref:Protocol.Groups.Group-connection). If this is omitted, the thread will use the main connection with ID 0.

*Feature introduced in DataMiner 10.4.9/10.5.0 (RN 38887).*
