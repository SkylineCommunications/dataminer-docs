---
uid: Protocol.Responses.Response
---

# Response element

Specifies a response that DataMiner can expect after having sent a specific command to the device.

## Parent

[Responses](xref:Protocol.Responses)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.Responses.Response-id)|[TypeNonLeadingZeroUnsignedInt](xref:Protocol-TypeNonLeadingZeroUnsignedInt)|Yes|Specifies the unique response ID.|
|[options](xref:Protocol.Responses.Response-options)|string||Defines a number of options.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Content](xref:Protocol.Responses.Response.Content)||Specifies the consecutive parameters that together form the response that is expected from the device.|
|&nbsp;&nbsp;[Description](xref:Protocol.Responses.Response.Description)|[0, 1]|Specifies a textual description of the response.|
|&nbsp;&nbsp;[Name](xref:Protocol.Responses.Response.Name)||Specifies the name of the response.|

## Remarks

Similar to a command, a response is a collection of parameters that describe the message that the data source is expected to send back to DataMiner after having received a command.

When it receives a response from the data source, DataMiner will compare that response to the response definition specified in the Protocol.Responses.Response tag. If the response does not match the definition, DataMiner will send the command again. The log files of the element will contain detailed information about this. If the response still does not match, DataMiner will send the command for the third and last time. If, at that point, no valid response has been received, DataMiner will skip the command, and move to the next one.

By default, the number of retries in case of an invalid response is set to 3. You can change this setting when adding or editing the element in DataMiner Cube.
