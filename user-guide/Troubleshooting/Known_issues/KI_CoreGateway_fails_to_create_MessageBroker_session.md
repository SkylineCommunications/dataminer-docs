---
uid: KI_CoreGateway_fails_to_create_MessageBroker_session
---

# CoreGateway fails to create MessageBroker session

## Affected versions

CoreGateway 2.14.6

## Cause

CoreGateway version 2.14.6 fails to create a MessageBroker session, causing it to be unable to receive requests from other modules.

## Workaround

1. Manually uninstall the CoreGateway module.
1. Install version 2.14.5 of the module.

## Fix

No fix is available yet.

## Issue description

After upgrading to CoreGateway version 2.14.6, it becomes impossible to log in to the system. In the log file in `C:\ProgramData\Skyline Communications\DataMiner CoreGateway\Logs`, there are many entries saying "Could not create a message broker session yet... Retrying in 5 seconds...[MessageBrokerWrapper.MessageBrokerWrapper]".
