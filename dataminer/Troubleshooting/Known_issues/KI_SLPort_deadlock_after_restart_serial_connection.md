---
uid: KI_SLPort_deadlock_after_restart_serial_connection
---

# SLPort deadlock when element with serial connection is restarted

## Affected versions

- DataMiner Main Release versions 10.1.0 [CU17] to 10.2.0 [CU11]/10.3.0.0 - 12752.
- DataMiner Feature Release versions 10.2.8 to 10.3.3.

## Cause

When a serial connection was disconnected, it could occur that a new connection was started before the previous disconnection was complete. As a result of this, a deadlock could occur in SLPort or SLPort could even stop working.

## Fix

Install DataMiner 10.2.0 [CU12], 10.3.0.0 - 12790, or 10.3.3 [CU1]. <!-- RN 35773 -->

## Workaround

Instead of restarting an element with a serial connection, stop the element and then restart it after sufficient time, when you are sure all polling has stopped (e.g. one minute).

## Issue description

When an element using a serial connection was restarted, the SLPort process could stop working correctly, which could result in a run-time error. If this run-time error occurred, DataMiner needed to be restarted.
