---
uid: UIComponentsMatrixSettingCrosspoints
---

# Setting crosspoints

The parameter value of the write parameter when a crosspoint is set is of the following format: input discrete value, output discrete value, 0 (removed) or 1.

To obtain compatibility with Automation scripts, a special routine has to be followed.

When a set is done on the matrix write parameter, the crosspoint values that need to be set are stored into a buffer as a pipe-separated string. Values will be taken from that buffer one by one, and a flag is used to indicate if a set is being performed. So when a set is done by the write parameter and the flag indicates that there is no set operation being performed, the code used to take one crosspoint from the buffer needs to be triggered by adjusting the flag.

When taking a crosspoint from the buffer, the buffer needs to be adjusted and a command or SNMP set needs to be composed.

Once the command or SNMP set is executed, the flag needs to be changed again so that the next crosspoint can be taken from the buffer.

Summary:

- QAction 1: Triggers on write of matrix, process the data to put it into a buffer parameter in a certain format. Set flag to true if it is false (false indicates a set is being executed).
- QAction 2: Triggers on a flag parameter to take one crosspoint from the buffer, send it to a command and set flag to false.
- Group is executed with command to perform the setting.
- Trigger after group to put the flag back to true (back to step 2 until buffer is empty).

> [!NOTE]
> When implementing crosspoint sets via a serial connection using the "makeCommandByProtocol" communication option, the usage of a buffer is not needed. The commands can be constructed and added to the group execution queue immediately. For more information, see makeCommandByProtocol.
