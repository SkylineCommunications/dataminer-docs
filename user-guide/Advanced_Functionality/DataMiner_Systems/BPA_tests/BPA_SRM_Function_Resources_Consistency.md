---
uid: BPA_SRM_Function_Resources_Consistency
---

# SRM Function Resources Consistency

This BPA test (also known as *CheckDveInconsistency*) checks for any inconsistencies between the resource objects and the [Generic DVE table] entries on the main element as well as other possible configuration issues:

- It checks for any inconsistencies in the DVE tables: states, names, linked resources, and elements.
- It checks for duplicate names or IDs and other possible configuration issues.

It shows the global errors and the errors and warnings per element, listing the errors and warnings separately.

This BPA test is included in the SRM Framework from version 1.2.26 onwards<!-- RN 33541 -->. You can [run it in System Center](xref:Running_BPA_tests) on the *Agents > BPA* tab.

> [!NOTE]
> The BPA can take over 30 seconds to run, depending on the scale of the system.

## Metadata

- Name: SRM Function Resources Consistency
- Description: Detects any inconsistencies between the resource objects and the [Generic DVE table] entries on the main element as well as other configuration issues.
- Author: Skyline Communications
- Default schedule: Daily

## Results

### Success

`Test succeeded: No inconsistent function resource configurations detected in the system.`

No inconsistencies have been detected in the system.

### Error

Global errors:

- `Function definition ID '{FunctionDefinitionId}' is not unique.`<br>`It was found in the active function files of the following protocols: {Protocols}.`

Element errors:

- `[Generic DVE Table] entry {PK} is configured with resource ID '{ResourceID}', which was not found in Resource Manager.`
- `[Generic DVE Table] entry {PK} is configured with a blank resource ID, so no matching resource could be found in Resource Manager.`
- `[Generic DVE Table] entry {PK} is configured with the element name - function name combination '{Name}.{Name}', which is already used as the element name of element '{DataMinerID}/{ElementID}'.`
- `[Generic DVE Table] entries [{PKs}] are configured with a duplicate DVE Name '{Name}'.`
- `The function name '{Name}' of resource '{Name}' ({GUID}) with [Generic DVE Table] primary key [{PK}] is already used by one or more other function resources on the same parent element, with [Generic DVE Table] primary key(s) [{PKs}].`
- `Resource '{Name}' ({GUID}) has no primary key while it should have one.`
- `Resource '{Name}' ({GUID}) with [Generic DVE Table] primary key '{PK}' could not be found in the [Generic DVE table].`
- `The [Generic DVE Table] was empty, but the following resources refer to this element: Resource '{Name}' ({GUID}).`
- `Could not find main element referenced by the following resources: {Names}.`
- `The element ID is not unique.`
- `Resource '{Name}' ({GUID}):`
  - `[Generic DVE Table] entry {PK} - [DVE Name] has value '{Name}', which is different from the linked resource function name '{Name}'.`
  - `[Generic DVE Table] entry {PK} - [DVE Element] has the value '{Value}', which is different from the linked resource DVE Element '{DataMinerID}/{ElementID}'.`
  - `[Generic DVE Table] entry {PK} - [DVE State] has the value 'Enabled', but [DVE Element] '{DataMinerID}/{ElementID}' was not found in the DataMiner System even though it should be.`
  - `[Generic DVE Table] entry {PK} - [DVE State] has the value 'Disabled', but [DVE Element] '{DataMinerID}/{ElementID}' is present in the DataMiner System even though it shouldn't be.`
  - `[Generic DVE Table] entry {PK} - [DVE function GUID] has the value '{GUID}', which is different from the linked resource function GUID '{GUID}'.`
  - `[Generic DVE Table] entry {PK} - [DVE Link to Resource Manager] has the value '{Value}', which is different from the linked resource ID '{GUID}'.`
  - `[Generic DVE Table] entry {PK} - The active function files for the protocol were switched, but [DVE function GUID] still matches the GUID of the function in a previous active function file ('{GUID}') instead of the current active function file.`

### Warning

Global warnings:

- `Could not retrieve all elements.`

Element warnings:

- `Could not check resources of this element because the state is set to stopped.`
- `No Linker table entry found for resource(s): {Names & PKs} .`
- `The element ID is not unique.`

### Not Executed

These are the messages that can appear when the test fails to execute for unexpected reasons, and it cannot provide a conclusive report because of this:

`Could not execute test ([message])` (on unexpected exceptions).

In the message above, the exception message is included (e.g. "Access Denied"). The test result details contain the full exception text, if available.

## Impact when issues detected

- Impact: "Operation of the DataMiner System and SRM could be affected by this problem."
- Action: "Try to update the resources to resolve the inconsistencies."

## Limitations

- Needs the SRM framework.
- Needs an SRM license.
- Resource Manager needs to be initialized.
