---
uid: setsockopt_failed_for_SO_KEEPALIVE
---

# setsockopt failed for SO_KEEPALIVE

## Symptom

In the SLErrors and SLPort log files, you come across the following error message:

```txt
setsockopt failed for SO_KEEPALIVE
```

## Cause

An error occurred while setting a KeepAlive option.

## More information

By default, the KeepAlive option of smart IP client sockets is set to the following values:

- timeout time: 10 s

- interval: 1 s

This means, that every second a KeepAlive probe is sent to the socket to check if the connection is still alive. If the timeout time has passed without one successful keepalive probe, all the applications are notified that the socket is disconnected.
