---
uid: KI_port_exhaustion_because_of_NATS_reconnect_attempts
---

# Port exhaustion because of NATS reconnection attempts

## Affected versions

Any version of DataMiner.

## Cause

When a DataMiner process connects to NATS and then gets disconnected, it enters a reconnect loop (which has no timeout) where it will attempt to reconnect. During this loop, it can occur that the NATS.Client library leaks handles, which can lead to so-called port exhaustion.

## Workaround

There are several ways to recover from this issue:

- Reboot the server.
- Stop the DataMiner DxMs, start the NAS and NATS services, and then restart the DataMiner DxMs.
- Restart both the separate DxMs and DataMiner in general.
- Use the workaround mentioned under method 3 on the [Troubleshoot port exhaustion issues](https://learn.microsoft.com/en-us/troubleshoot/windows-client/networking/tcp-ip-port-exhaustion-troubleshooting#method-3) page.

## Fix

Install DataMiner 10.4.6/10.5.0<!--RN 38809-->.

## Description

NATS is unable to start up. In the `C:\Skyline DataMiner\NATS\nats-streaming-server\nats-server.log` log file, you may find the following error:

```txt
STREAM: Failed to start: dial tcp 127.0.0.1:4222: bind: An operation on a socket could not be performed because the system lacked sufficient buffer space or because a queue was full.
```

Following method 3 detailed on the [Troubleshoot port exhaustion issues](https://learn.microsoft.com/en-us/troubleshoot/windows-client/networking/tcp-ip-port-exhaustion-troubleshooting#method-3) page reveals that port exhaustion has occurred.
