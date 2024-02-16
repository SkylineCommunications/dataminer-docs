---
uid: ChangeDCF
---

# Change DCF

Changes to DCF are considered a major change, and as such a major change is required in the version numbering.

This includes adding DCF support to a protocol where this was previously not available or making changes to existing DCF interfaces.

## Impact

### Adding DCF support to an existing protocol

DCF can add a lot of additional load to a system, and it may introduce new issues while it might not actually be used.

*DIS MCC*

| Full ID | Error message | Description   |
|---------|---------------|---------------|
| 16.2.1  | DcfAdded      | DCF was added |

### Changing the DCF implementation

When the name or type of an existing DCF interface (ParameterGroups) is changed or a DCF interface (ParameterGroups) is removed, this will have an impact on the system of the user:

- **Interface name change**: DataMiner modules that filter by interface name will most likely no longer work correctly. There is the possibility that the connection names (which normally start with the interface name) are not updated. As such, QActions that request the connection by name might result in inconsistent data.
- **Interface type change**: Connections are made from input to output. Changing the type of an interface might for instance result in the compiler detecting an invalid connection that is going from an output to an output. These invalid connections might result in odd and unexpected behavior and inconsistent data in the system.
- **Interface removal**: Removing an interface will result in the loss of the related connection.

*DIS MCC*

| Full ID | Error message                | Description                                                                                  |
|---------|------------------------------|----------------------------------------------------------------------------------------------|
| 16.3.3  | DcfParameterGroupNameChanged | DCF Group name for ParameterGroup '{groupId}' was changed from '{oldName}' into '{newName}'. |
| 16.4.1  | DcfParameterGroupTypeChanged | DCF Group type for ParameterGroup '{groupId}' was changed from '{oldType}' into '{newType}'. |
| 16.5.1  | DcfParameterGroupRemoved     | ParameterGroup '{groupId}' was removed.                                                      |

## Workarounds

### Adding DCF to an existing protocol

Actions to be taken:

- QAction logic for DCF should be disabled by default.

Advised method:

- Add a toggle button to the protocol (default "Disabled").

- For QAction logic:

  - Add a *Condition* tag to either the QAction/Trigger/Action or the group running the DCF code (if it only runs DCF code).

  - Add if-conditions inside C# code that disable the DCF logic.

- Do not use a workaround to disable interfaces unless absolutely necessary.

  - A software task was created to make it possible to disable DCF interfaces ([task 62899](https://collaboration.dataminer.services/task/62899)).

### DCF interface changes

Actions to be taken:

- DCF data needs to be cleared: DCF mapping parameters, etc.
- The DCF use case needs to be checked. Usually, this is the standard DCF implementation.
