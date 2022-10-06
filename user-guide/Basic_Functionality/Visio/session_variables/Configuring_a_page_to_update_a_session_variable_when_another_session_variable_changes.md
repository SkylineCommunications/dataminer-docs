---
uid: Configuring_a_page_to_update_a_session_variable_when_another_session_variable_changes
---

# Configuring a page to update a session variable when another session variable changes

From DataMiner 9.5.2 onwards, it is possible to have an open Visual Overview page update a session variable when another session variable changes.

> [!TIP]
> See also: [Linking a shape to a SET command](xref:Linking_a_shape_to_a_SET_command)

## Configuring the shape data field

Add a shape data field of type **Execute** on page level. Set the shape data field to the following value:

```txt
SET|X|Y|Z|SetTrigger=ValueChanged
```

- X: The scope of the session variable that should be updated:

  - *Variable* = Global variable

  - *CardVariable* = Card variable

  - *PageVariable* = Page variable

  - *WorkspaceVariable* = Workspace variable

- Y: The name of the session variable that should be updated.

- Z: The new value of the session variable (which can contain dynamic parts referring to parameters or other session variables).

If more than one session variable should be updated, repeat the value configuration above for each of the session variables, using a dash as separator. For example:

```txt
SET|Variable|VarName1|Value 1|SetTrigger=ValueChanged-SET|Variable|VarName2|Value 2|SetTrigger=ValueChanged-...-SET|Variable|VarNameX|Value X|SetTrigger=ValueChanged
```

If you wish to use a different separator than a dash, add the \[sep:XY\] option at the beginning of the shape data. For example:

```txt
[sep:-*]SET|Variable|VarName1|Value 1|SetTrigger=ValueChanged*SET|Variable|VarName2|Value 2|SetTrigger=ValueChanged*...*SET|Variable|VarNameX|Value X|SetTrigger=ValueChanged
```

> [!TIP]
> See also: [About using separator characters](xref:Linking_a_shape_to_a_SET_command#about-using-separator-characters)

## Option

If you want the set commands in the **Execute** field to be performed each time the card is opened, add a page-level shape data field of type **Options**, and set its value to “ExecuteSetsOnInit”.

```txt
ExecuteSetsOnInit
```

## Example

```txt
Set|Variable|DestVar1|[var:V1]|SetTrigger=ValueChanged
Set|Variable|DestVar2|Values: [var:V3], [var:V4], [var:V5]|SetTrigger=ValueChanged
```
