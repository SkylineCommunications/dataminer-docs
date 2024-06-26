---
uid: Configuring_a_page_to_update_parameters_on_session_variable_changes
---

# Configuring a page to update parameters on session variable changes

It is possible to have parameters updated on an open Visual Overview page when a session variable changes.

> [!TIP]
> See also:
> [Linking a shape to a SET command](xref:Linking_a_shape_to_a_SET_command)

## Configuring the shape data field

On page level, add a shape data field of type **Execute**, and for each parameter add a component as follows, separating the different components by a dash.

```txt
Set|Element|Parameter|Value|SetTrigger=ValueChanged
```

- Element: DMA ID/Element ID, or name of the element.

- Parameter: ID or description of the parameter.

- Value: the new value of the parameter (which must contain at least one reference to a session variable)

> [!NOTE]
> Placeholders can be used anywhere in the shape data value. As a consequence, you need to make sure the new value does not contain any dashes, as those would be considered separators. However, if the use of a dash is required (e.g. when using a GUID), you can use a *\[sep:xy\]* prefix in the shape data to change the separator.

## Option

If you want the set commands in the **Execute** field to be performed each time the card is opened, add a page-level shape data field of type **Options**, and set its value to “ExecuteSetsOnInit”.

```txt
ExecuteSetsOnInit
```

## Example

```txt
Set|218/652|1201|Session:[var:GuidVar]: ListSelection=[var:Chain],
Data =[var:LoadTime]|SetTrigger=ValueChanged-
Set|218/652|1203|[var:Chain]|SetTrigger=ValueChanged-
Set|218/652|1205|[var:LoadTime]|SetTrigger=ValueChanged
```
