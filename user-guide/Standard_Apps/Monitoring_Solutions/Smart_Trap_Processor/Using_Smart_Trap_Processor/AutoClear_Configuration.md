---
uid: AutoClear_configuration
---

# Auto-Clear Configuration

The configurable parameters available on the auto-clear section are used to determine the maximum number of rows and how long processed traps will remain in the *Processed Messages* table.

![Auto Clear Settings](~/user-guide/images/TrapProcessor_AutoClear.png)

- *Event Cleanup Timer*: Value entered is the interval at which the cleanup logic runs on the event tables. 
- *Maximum Age of Events*: Allows the user to select the maximum age of events before being removed from the tables. The timespan entered is compared to latest timestamp of each row on the event tables to determine if a row is eligible to be removed. 
- *Keep Active*: If enabled, rows that have an event state of “Active” will never be eligible for removal from the event table regardless of how old that Active trap is. 
- *Max Processed Messages*: Maximum number of entries to keep in the Processed Messages table.
- *Max Received Traps*: Max number of entries to keep in the Received Traps table.
