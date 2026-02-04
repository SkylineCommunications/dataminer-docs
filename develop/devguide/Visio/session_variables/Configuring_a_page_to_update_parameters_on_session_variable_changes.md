---
uid: Configuring_a_page_to_update_parameters_on_session_variable_changes
---

# Configuring a page to update parameters on session variable changes

It is possible to have parameters updated on an open Visual Overview page when a session variable changes.

> [!TIP]
> See also: [Linking a shape to a SET command](xref:Linking_a_shape_to_a_SET_command)

## Configuring the shape data field

On page level, add a shape data field of type **Execute**, and for each parameter add a component as follows, separating the different components by a dash.

```txt
Set|Element|Parameter|Value|SetTrigger=ValueChanged
```

- Element: DMA ID/Element ID, or name of the element.

- Parameter: ID or description of the parameter.

- Value: the new value of the parameter (which must contain at least one reference to a session variable)

Placeholders can be used anywhere in the shape data value. As a consequence, you need to make sure the new value does not contain any dashes, as those would be considered separators. However, if the use of a dash is required (e.g. when using a GUID), you can use a *\[sep:xy\]* prefix in the shape data to change the separator.

> [!NOTE]
> To avoid problems with dynamic values (such as element and view names or properties), we highly recommend changing the default separators. Ideally, you should use separators that are exceptional or combine multiple characters, so that they definitely will not occur in the dynamic values, such as `§`, `@`, or `ùµ`, or [forbidden characters](xref:Forbidden_characters) such as `?`. For example:
>
> ```txt
> [sep:-$][sep:|@]SET@CardVariable@myElem@[Property:ViewProperty]@SetTrigger=ValueChanged$[sep:|@]SET@CardVariable@IP@[RegexMatch:[sep:,#](?:\d{1,3}\.){3}\d{1,3}(?=[^|]*$)#[param:[cardvar:myElem],1002]]@SetTrigger=ValueChanged
> ```

## Option

If you want the set commands in the **Execute** field to be performed each time the card is opened, add a page-level shape data field of type **Options**, and set its value to “ExecuteSetsOnInit”.

```txt
ExecuteSetsOnInit
```
