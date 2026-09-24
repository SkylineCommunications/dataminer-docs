---
metadata_version: 1
uid: Protocol.Pairs.Pair.Content.Response
description: "Learn how to use the Response element to identify an expected response for a command and response pair in a DataMiner connector protocol."
---

# Response element

Specifies the ID of an expected response.

## Type

unsignedInt

## Parent

[Content](xref:Protocol.Pairs.Pair.Content)

## Remarks

> [!NOTE]
> By default, the number of retries in case of an invalid response is set to 3. This setting can be changed when adding or editing the device in DataMiner Cube.

## Examples

```xml
<Response>3</Response>
```
