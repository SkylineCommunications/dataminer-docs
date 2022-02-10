---
uid: Timer_speed_restrictions
---

# Timer speed restrictions

- The speed of timers must be carefully chosen. For example, suppose a timer triggers every 10 seconds and initiates an operation that requires 20 seconds to complete. This can have a negative impact on performance (SLScripting, SLProtocol). The timer interval must be set to a value allowing every group included in the timer to complete before the timer triggers again. This can be verified with SLNet Client Pendingcalls and the element logging. Note also that a timer interval cannot exceed 24 hours, since a thread in SLWatchdog cannot be registered for longer than that.

- The set timer time must not exceed 24 days.
