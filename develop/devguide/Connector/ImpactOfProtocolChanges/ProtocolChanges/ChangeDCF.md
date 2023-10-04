---
uid: ChangeDCF
---

# Change DCF

Changes to DCF is considered a major change and as such a major change is required in the version numbering.

This includes adding DCF in a protocol where previously no DCF was available or making changes to existing DCF interfaces.

## Impact

### Adding DCF to an existing Protocol

DCF can add a lot of additional load to a system and it may introduce new issues and bugs for a technology (DCF) the customer may not actually be using.

*DIS MCC*

| Full ID | Error message | Description   |
|---------|---------------|---------------|
| 16.2.1  | DcfAdded      | DCF was added |

### Changing DCFs

When changing the name or type of an existing DCF Interface (ParameterGroups) or removing a DCF ParameterGroups, there is going to be an impact on the customer's system

- **Interface Name Change**: DataMiner modules using the name as filtering will most likely no longer work. There is the possibility that the connection names (they normally start with the interface name) are not updated, as such, QActions that request the connection by name might result in inconsistent data.
- **Interface Type Change**: Connections are from input to output. By changing the type of an interface, it might result in the fact that the compiler detecting an invalid connection that for instance is going from an output to an output. These invalid connections might result in odd and unexpected behavior and inconsistent data infecting the system.
- **Interface Removal**: Removing an interface will result in the loss of the related connection.

DIS MCC

| Full ID | Error message | Description |
|---------|---------------|-------------|
| 16.3.3 | DcfParameterGroupNameChanged | DCF Group name for ParameterGroup '{groupId}' was changed from '{oldName}' into '{newName}'. |
| 16.4.1 | DcfParameterGroupTypeChanged | DCF Group type for ParameterGroup '{groupId}' was changed from '{oldType}' into '{newType}'. |
| 16.5.1 | DcfParameterGroupRemoved     | ParameterGroup '{groupId}' was removed. |

## Workarounds

### Adding DCF to an existing protocol

Actions to be taken:

- QAction logic for DCF should be disabled by default.

Advised method:

- Add a toggle button to the protocol. (default "Disabled")
- For QAction logic:

  - Add a *Condition* tag to either QAction/Trigger/Action or group running the DCF code (if it only runs DCF code)
  - Add if conditions inside C# code that disable the DCF logic

- A workaround to disable Interfaces **should not** be made unless absolutely necessary.

  - A software task was created to disable DCF interfaces, please see [task 62899](https://collaboration.dataminer.services/task/62899)

### DCF interface changes

Actions to be taken:

- DCF data needs to be cleared: DCF mapping parameters, etc.
- The use case of the DCF needs to be checked - Which is in general the correct DCF implementation that can be used as the standard for the customers.
