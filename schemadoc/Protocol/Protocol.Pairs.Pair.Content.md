---
uid: Protocol.Pairs.Pair.Content
---

# Content element

Associates a command with its expected response(s).

## Parent

[Pair](xref:Protocol.Pairs.Pair)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***Sequence***|||
|&nbsp;&nbsp;[Command](xref:Protocol.Pairs.Pair.Content.Command)||Specifies the ID of the command that will be sent when the pair is executed.|
|&nbsp;&nbsp;[Response](xref:Protocol.Pairs.Pair.Content.Response)|[0, *]|Specifies the ID of an expected response.|
|&nbsp;&nbsp;[ResponseOnBadCommand](xref:Protocol.Pairs.Pair.Content.ResponseOnBadCommand)|[0, *]|Defines an error messages coming from the device.|

## Remarks

You can specify only one command. The number of responses, however, can vary.

- If no response is expected, then specify the command, but no response.
- If only one single response is expected, then specify the command and the expected response.
- If multiple responses are expected, then specify the command and all expected responses.

The number of responses to be defined in this tag can vary from none to several, depending on the device.

When DataMiner receives a response from the device after having sent a command, it will try to match the response to one of the responses defined in this tag. If several responses have been defined, it will check them top down.

- If a match is found, DataMiner will move on to the next command/response pair.
- If no match is found, DataMiner will send the command again. In the device’s element card, users will be notified that an error has occurred. The log files of the device will contain more detailed information. If the new response still does not match one of the defined responses, DataMiner will send the command for the third and last time. If, at that point, no valid response has been received, DataMiner will skip the command, and move to the next command/response pair.
