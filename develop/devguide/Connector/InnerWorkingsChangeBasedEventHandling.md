---
uid: InnerWorkingsChangeBasedEventHandling
---

# Change-based event handling

A commonly used type of trigger is one that triggers on a change of a parameter value. When a parameter holds a value and the parameter is set to the same value again via a protocol construct such as a copy action, the trigger will not trigger. This is because in this case DataMiner assumes that it is unnecessary to trigger on this same value again.

However, in some cases it is important that the trigger triggers again when the same value is received again. In these cases, actions of type "clear" must be used. This action will cause the specified parameter to be erased in memory, allowing an incoming value to always be accepted as a new value (even if this value equals the previous value). To clear a parameter on the user interface, an action of type "clear on display" should be used. The result of this action will be that the value of this parameter is visualized as "Not initialized" on the user interface.

In case a parameter is set via a QAction, however, the trigger will always trigger, even if the value that is set equals the current value.
