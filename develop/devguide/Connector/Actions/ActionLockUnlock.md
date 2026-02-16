---
uid: LogicActionLockUnlock
---

# lock/unlock

This action must be executed on protocol.

These actions are used to make sure that a device does not interfere with another device when executing certain groups.

A “lock” action usually precedes an “open” action, while an “unlock” action usually follows a “close” action.

With serial communication, the lock/unlock functionality is sometimes required when multiple commands must be sent to a device that are considered an atomic operation (e.g., initialize session, send request, end session).

Once an element has acquired a lock, performing another lock operation on the connection from the same element has no impact. Only one unlock action is needed to release the lock again (SNMP, serial and GPIB).

When, for example with serial communication, a lock was taken and a timeout occurs, nothing will happen. The lock will only be freed when the element is stopped or when an unlock action is executed.

For SNMP connections, locking is based on the polling IP and is performed in the SLSNMPManager process. It will block the PollingThread, so all sets and gets from other elements connected to that IP are blocked (including snmpset).

For serial connections, locking is based on the IP and port and is performed within the SLPort process (by locking the SendThread).

> [!NOTE]
>
> - Lock/unlock is currently not supported with redundant polling.
> - Sets and gets performed via a QAction will not be locked.
> - Suppose you have a serial connection and a "serial single" connection connecting to the same IP:port as the serial connection. In this case, the serial single connection will not be blocked when a lock is taken on the serial connection as "serial single" introduces a dedicated socket.

## Attributes

### Type@nr

(optional): Specifies the connection. Default: 0.

## Examples

```xml
<Action id="21">
  <Name>lock the port</Name>
  <On>protocol</On>
  <Type>lock</Type>
</Action>
```
