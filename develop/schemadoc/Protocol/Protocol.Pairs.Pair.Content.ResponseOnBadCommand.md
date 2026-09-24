---
metadata_version: 1
uid: Protocol.Pairs.Pair.Content.ResponseOnBadCommand
description: "Learn how to use the ResponseOnBadCommand element to match a known error response and avoid retrying the command in a DataMiner connector protocol."
---

# ResponseOnBadCommand element

Defines an error messages coming from the data source.

## Type

unsignedInt

## Parent

[Content](xref:Protocol.Pairs.Pair.Content)

## Remarks

If the data source is able to return an error message, and if the structure of that error message is known, then you can create a response that matches that error message, and include that response in the command/response pair as a ResponseOnBadCommand.

Note that the command will not be executed again as the received response matched one of the defined responses. Also, the information received from the data source in the error message can be used to inform users about the error that occurred.

## Examples

```xml
<ResponseOnBadCommand>4</ResponseOnBadCommand>
```
