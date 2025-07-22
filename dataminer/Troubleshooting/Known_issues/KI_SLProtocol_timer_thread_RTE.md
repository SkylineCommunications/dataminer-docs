---
uid: KI_SLProtocol_timer_thread_RTE
---

# SLProtocol timer thread run-time error

## Affected versions

- DataMiner Main Release versions prior to 10.2.0 [CU10]
- DataMiner Feature Release versions prior to 10.3.1

## Cause

If a protocol with a timer of 1 day or more was combined with the use of the *Timer base* parameter, an integer overflow could occur.

- In x86 versions of SLProtocol, this caused a run-time error to be detected after a default time of 5 minutes, while polling was resumed after a pseudo-random time of approximately 10 days. As such, the run-time error was reset approximately every 10 days.

- In x64 versions of SLProtocol, this could cause the timer to become inaccurate. However, no run-time errors occurred.

## Fix

Upgrade to DataMiner 10.2.0 [CU10] or 10.3.1.

## Workaround

Reduce the timer time in the protocol so that it is less than 1 day.

## Issue description

If a protocol was used containing a timer of 1 day or more, x86 versions of SLProtocol could throw a run-time error. This error would get reset approximately every 10 days.
