---
uid: InnerWorkingsChangeBasedEventHandling
---

# Change-based event handling

A commonly used type of trigger is one that triggers on a change of a parameter value. Such a trigger will behave similarly to QActions, which are also triggered by parameter change events. When a parameter holds a value, and the parameter is set to the same value again, a parameter change event may or may not occur depending on where the new value comes from.

- **QAction sets**: The trigger will always go off, even if the value that is set equals the current value.
- **Protocol constructs** (e.g. a copy action, polling of an SNMP parameter, parameter part of a serial response, parameter part of an HTTP response, etc): The trigger will not go off. This is because in this case DataMiner assumes that it is unnecessary to trigger on this same value again, and it therefore chooses to save resources for efficiency reasons.

However, in some cases it is important that the trigger goes off again when the same value is received again. In these cases, actions of type "clear" must be used. Such an action will cause the specified parameter to be erased in memory, allowing an incoming value to always be accepted as a new value (even if this value equals the previous value). To clear a parameter on the user interface, an action of type "clear on display" should be used. The result of this action will be that the value of this parameter is visualized as "Not initialized" on the user interface.
