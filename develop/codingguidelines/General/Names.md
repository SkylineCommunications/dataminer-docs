---
uid: ConnectorBestPracticesNames
---

# Names

## Unique and meaningful

A protocol consists of different items such as parameters, actions, QActions, etc. Every item has a name that is used for internal reference in e.g., SLProtocol or DIS. Protocol item names must be unique per item type and must be meaningful.

## Parameters

- Parameter names must be well-chosen, describing the value that the parameter will hold. Note that this is also important to improve the readability of code in Quick Actions:

  - The *Parameter* class (Skyline.DataMiner.Scripting) generates constant fields for parameters defined in a protocol. The name of a field corresponds to the name of the parameter, excluding spaces and symbols.
  - The *SLProtocolExt* interface generates properties for parameters defined in a protocol. The name of a property corresponds to the name of the parameter, excluding spaces and symbols.

- Reserved names

  Reserved names must not be used as parameter names or parameter descriptions. Refer to <xref:ConnectorBestPracticesReservedParameterNames> for an overview of reserved names.

## Actions and QActions

A meaningful name must be chosen for QActions or Actions, indicating the functionality that is executed. The name of an action should contain a verb (e.g., CheckMaximumDuration, InitiateImageTransfer, etc.).

## Groups

The name of a group must clearly describe its content.

## Triggers

The name of a trigger must reflect what it is triggering on (e.g., On Poll Counter Change).

## Elements

Names of DataMiner elements must be unique, and the following restrictions apply when an element is created by a protocol QAction or as a DVE:

- No leading and/or trailing spaces.
- No empty names.
- Disallowed characters: \\ ; / : \* ? " \< > \| ; °
- No duplicate names: an element must be unique in the DMS.
