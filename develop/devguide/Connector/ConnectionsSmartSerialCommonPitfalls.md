---
uid: ConnectionsSmartSerialCommonPitfalls
---

# Common pitfalls

This section describes common pitfalls when using smart-serial connections.

## Serial in combination with smart serial

Serial and smart-serial connections should never be combined to connect to **the same port of a device** (i.e. using the same IP address and port). If you do combine these, the device will not know that the unsolicited messages should be sent via the smart-serial connection.

To be able to combine handling unsolicited messages and command-response pairs, only a smart-serial connection should be set up that handles both types of messages.

## Handling both unsolicited messages and command-response pairs

When handling both unsolicited messages and command-response pairs on the same connection, it is important to be aware of when unsolicited messages can enter. If these can enter simultaneously with a response that belongs to a command, the pair tag should only contain the command (no response). To receive the response, handle it as if it is an unsolicited message, and then determine if it is your expected response or an actual unsolicited message.

This is necessary because it is possible that the unsolicited message enters just after the command is sent, which will cause the response tag to try and match this unsolicited message instead of the actual response.
