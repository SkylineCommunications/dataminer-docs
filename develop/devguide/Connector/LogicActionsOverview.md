---
uid: LogicActionsOverview
---

# Actions overview

|Name | Description | On | Related Actions
|--- |--- |--- |--- |
|[add to execute](xref:LogicActionAddToExecute)|Adds a group to the end of the queue, after timers.|group|execute one|
|[aggregate](xref:LogicActionAggregate)|Aggregates data from one table into another.|parameter||
|[append](xref:LogicActionAppend)|Adds data to a parameter.|parameter||
|[append data](xref:LogicActionAppendData)|Adds raw data to a parameter.|parameter||
|[change length](xref:LogicActionChangeLength)|Changes the length of the parameter to the number of bytes found.|parameter||
|[clear](xref:LogicActionClear)|Erases data from the parameter in memory or removes the response from memory.|parameter, response||
|[clear length info](xref:LogicActionClearLengthInfo)|Clears the length info.|response||
|[clear on display](xref:LogicActionClearOnDisplay)|Erases the displayed value of a parameter.|parameter||
|[close](xref:LogicActionClose)|Closes the port (serial).|protocol||
|[copy](xref:LogicActionCopy)|Copies a value to another parameter.|parameter||
|[copy reverse](xref:LogicActionCopyReverse)|Copies the reverse value to another parameter.|parameter||
|[crc](xref:LogicActionCrc)|Calculates the CRC of the CRC parameter or response.|command, response||
|[execute](xref:LogicActionExecute)|Adds a group to the end of the queue, but before timers.|group|execute one now|
|[execute next](xref:LogicActionExecuteNext)|Adds a group to the start of the queue, after the one that is currently being executed.|group|execute one top|
|[execute one](xref:LogicActionExecuteOne)|Adds a group to the end of the queue, after timers, if not already present in the queue.|group|add to execute|
|[execute one now](xref:LogicActionExecuteOneNow)|Adds a group to the end of the queue, but before timers, if not already present in the queue.|group|execute|
|[execute one top](xref:LogicActionExecuteOneTop)|Adds a group to the start of the queue, after the one that is currently being executed, if not already present in the queue.|group|execute next|
|[force execute](xref:LogicActionForceExecute)|Forces a group to be executed as soon as possible, interrupting the flow of ongoing groups, if any.|group||
|[go](xref:LogicActionGo)|Runs the last known write.|parameter||
|[increment](xref:LogicActionIncrement)|Increments the parameter value.|parameter||
|[length](xref:LogicActionLength)|Calculates the length of the length parameter or response.|command, response||
|[lock/unlock](xref:LogicActionLockUnlock)|Locks or unlocks a specific port.|protocol||
|[make](xref:LogicActionMake)|Makes the command with the current parameter values.|command||
|[merge](xref:LogicActionMerge)|Aggregates data from tables across protocols.|protocol||
|[multiply](xref:LogicActionMultiply)|Multiplies the parameter value.|parameter||
|[normalize](xref:LogicActionNormalize)|Sets as the parameter’s normal value.|parameter||
|[open](xref:LogicActionOpen)|Opens the port (serial).|protocol||
|[pow](xref:LogicActionPow)|Raises the parameter to the power.|parameter||
|[priority lock/priority unlock](xref:LogicActionPriorityLockUnlock)|Same as lock/unlock but with priority.|protocol||
|[read](xref:LogicActionRead)|Reads the parameter or response.|parameter, response||
|[read file](xref:LogicActionReadFile)|Reads a file from a directory.|protocol||
|[read stuffing](xref:LogicActionReadStuffing)|Removes redundant characters.|response||
|[replace](xref:LogicActionReplace)|Replaces a parameter with another or replaces a parameter by another.|command, response||
|[replace data](xref:LogicActionReplaceData)|Replaces specific bytes by other bytes in a command or parameter or replaces specific bytes by other bytes.|command, parameter, response||
|[reschedule](xref:LogicActionReschedule)|Reschedules a timer.|timer||
|[restart timer](xref:LogicActionRestartTimer)|Stops and starts a timer (groups removed from queue).|timer||
|[reverse](xref:LogicActionReverse)|Takes the reverse of the parameter.|parameter||
|[run actions](xref:LogicActionRunActions)|Triggers a parameter that triggers a QAction.|parameter||
|[save](xref:LogicActionSave)|Saves the parameter.|parameter||
|[set](xref:LogicActionSet)|Sets multiple SNMP parameters or performs an SNMP set.|group, parameter||
|[set and get with wait](xref:LogicActionSetAndGetWithWait)|Performs an SNMP set and get, and waits until it is executed on the device.|parameter||
|[set info](xref:LogicActionSetInfo)|Dynamically changes sequence and scale.|parameter||
|[set next](xref:LogicActionSetNext)|Sets the time to wait before the next pair is executed.|pair||
|[set with wait](xref:LogicActionSetWithWait)|Performs an SNMP set and waits until it is executed on the device.|group, parameter||
|[sleep](xref:LogicActionSleep)|Pauses execution of the thread that executes this action.|protocol||
|[start](xref:LogicActionStart)|Starts a timer.|timer||
|[stop](xref:LogicActionStop)|Stops a timer.|timer||
|[stop current group](xref:LogicActionStopCurrentGroup)|Stop execution of a group containing pairs.|protocol||
|[stuffing](xref:LogicActionStuffing)|Performs stuffing on command or response.|command, response||
|[swap column](xref:LogicActionSwapColumn)|Moves data from one column to another.|protocol||
|[timeout](xref:LogicActionTimeout)|Overrules the default timeout.|pair||
|[wmi](xref:LogicActionWmi)|Executes a WMI script.|protocol||
