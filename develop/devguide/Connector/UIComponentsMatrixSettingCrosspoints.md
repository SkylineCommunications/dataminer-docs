---
uid: UIComponentsMatrixSettingCrosspoints
---

# Setting crosspoints

The parameter value of the write parameter when a crosspoint is set is of the following format: input discrete value, output discrete value, 0 (removed) or 1.

To obtain compatibility with automation scripts, a special routine has to be followed.

When a set is done on the matrix write parameter, the crosspoint values that need to be set are stored into a buffer as a pipe-separated string. Values will be taken from that buffer one by one, and a flag is used to indicate if a set is being performed. So when a set is done by the write parameter and the flag indicates that there is no set operation being performed, the code used to take one crosspoint from the buffer needs to be triggered via a set on the flag parameter.

When taking a crosspoint from the buffer, the buffer needs to be adjusted and a command or SNMP set needs to be composed.

Once the command or SNMP set is executed, the flag needs to be changed again so that the next crosspoint can be taken from the buffer.

Summary:

1. QAction 1: This QAction triggers on the matrix write parameter and processes the data to put it into a buffer parameter in a certain format. After it is added to the buffer, check if the parameter that indicates whether a set is currently busy has the state *busy*. If the current state is *not busy*, set the parameter to *not busy* to trigger the QAction that will perform the set.

   While it may seem odd to set the parameter to *not busy* even though the state is currently *not busy*, this is needed to trigger the QAction that will perform the set. That QAction will then set the flag to *busy*.

1. QAction 2: Triggers on the flag parameter. If the flag parameter indicates *not busy*, take one crosspoint from the buffer, set the flag parameter to *busy* and set the command parameters.

1. A group is executed (via a trigger that triggers on a change of the command parameter), which contains the command to perform the set.

1. A trigger that triggers after this group is executed to put the flag back to *not busy* (back to step 2 until buffer is empty).

> [!NOTE]
> When implementing crosspoint sets via a serial connection using the [makeCommandByProtocol](xref:Protocol.Type-communicationOptions#makecommandbyprotocol) communication option, the usage of a buffer is not needed. The commands can be constructed and added to the group execution queue immediately.
