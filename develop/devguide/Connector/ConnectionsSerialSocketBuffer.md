---
uid: ConnectionsSerialSocketBuffer
description: "Learn how DataMiner flushes buffered socket data before each serial command by default, and how late responses could affect reads under legacy behavior."
---

# Socket buffer

By default, before sending each command over a serial connection, DataMiner flushes any data already available in the socket.<!-- RN 26513 -->

## Legacy behavior

Previously, DataMiner typically waited for the configured timeout or stopped reading when it knew all data had arrived, for example when a configured trailer was received. Data arriving after the timeout was not made available to the protocol as a response, but remained in the socket buffer for the next readout.

As a result, a retry could read the late response to the earlier command, or data from a previous command could remain in the buffer when a different command was sent.
