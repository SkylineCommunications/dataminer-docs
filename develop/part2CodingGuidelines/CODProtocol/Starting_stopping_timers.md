---
uid: Starting_stopping_timers
---

# Starting/stopping timers

- The use of conditions must always be favored over starting, stopping and restarting timers, but a condition on a group is favored over a condition on a timer, since the timer performs a regular check on that condition to see if it becomes true. In case an action is used to start or stop a timer, a timer that is already started must not be started again, as this could lead to issues.
