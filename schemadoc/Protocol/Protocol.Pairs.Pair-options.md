---
uid: Protocol.Pairs.Pair-options
---

# options attribute

Specifies a number of options, separated by semicolons (”;”).

## Content Type

string

## Parent

[Pair](xref:Protocol.Pairs.Pair)

## Remarks

The following options are supported:

### commBreak

Use this option if the port has to signal a commbreak before sending the command.

- Value: The interval (ms) between the commbreak and the command.
- Default: 5 ms

### connection

If the protocol uses multiple ports, use this option to specify the ID of the port that has to be used for the command/response pair in question.

Examples:

- connection:0 is the default port.
- connection:1 is the first of the non-default ports.

### ignoreTimeout

Use this option to prevent an element from going in timeout because of this command/response pair.

If you specify this option, no matter what response result (timeout/socket error/normal response), the element will not go in timeout.

This option has been introduced for auto-discovery purposes.

### oneByte

Use this option if the command has to be sent byte per byte.

- Value: The interval (ms) between two consecutive bytes.
- Default: 5 ms

### receiveInterval

In some protocols, it is difficult to determine the length of the response in a generic way.

In case of such a protocol, use this option to make sure that the response is not parsed at timeout, but only after a period of time (defined in the protocol) after having received the response.

### retries

Use this option to override the retries specified on element level.

Example:

- If you specify retries:0, then no retries will be done.

## Examples

```xml
<Pair id="1" options="oneByte:x;commBreak:x;connection:x;retries:x;ignoreTimeout; receiveInterval:x">
```
