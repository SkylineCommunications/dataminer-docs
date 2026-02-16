---
uid: LogicTimers
---

# Timers

A timer defines which groups should be executed, as well as the time interval between consecutive executions.

A protocol typically defines multiple timers. For example, consider a protocol that is responsible for monitoring a device. Critical device parameters (e.g., parameters holding an alarm status) will need to be polled more frequently than less critical parameters (e.g., device firmware version). Therefore, the protocol will typically contain a timer that polls critical parameters frequently (e.g., every 10 seconds) and another timer that polls less critical parameters less frequently (e.g., every hour).

The execution of the groups defined as the content of the timer must not take more time than the specified time interval of the timer.

Note that when a timer adds groups to the group execution queue at a specified time interval (e.g., 10 seconds), this does not mean the groups are actually executed every 10 seconds. The exact moment when a group is executed depends on other groups present on the group execution queue that need to be processed first.

Every timer defined in the protocol introduces an additional timer thread in the SLProtocol process. (For more information, see [Timer threads](xref:InnerWorkingsSLProtocol#timer-threads).)

For more information on how to define a timer in a protocol, see [Protocol.Timers.Timer](xref:Protocol.Timers.Timer).
