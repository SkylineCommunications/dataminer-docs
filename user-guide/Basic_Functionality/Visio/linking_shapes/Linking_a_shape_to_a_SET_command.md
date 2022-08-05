---
uid: Linking_a_shape_to_a_SET_command
---

# Linking a shape to a SET command

Using a shape data field of type **Execute**, you can link a shape to a SET command.

When you link a shape to a SET command, that command will be executed each time a user clicks that shape.

> [!NOTE]
>
> - A shape linked to a SET command will not be displayed if the element to which it is linked cannot be found.
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[linking > EXE]* page.

## Configuring the shape data field

Add a shape data field of type **Execute** to the shape, and set its value to:

```txt
Set|DmaID/ElementID|ID of write parameter:TableRowKey|NewValue|Options
```

> [!NOTE]
>
> - In the syntax above, ":TableRowKey" is optional.
> - Table rows can be referenced either by primary key or by display key.

## Example

```txt
Set|17/22954|1103|MyNewPassword
```

When users click the shape, a confirmation box will appear asking them whether they want the SET command to be executed. If they click *Yes*, the command will be executed.

## Options

In the above-mentioned command, you can use the following options.

- **NoConfirmation**: If you add the option "NoConfirmation", no confirmation box will appear when users click the shape.

- **ConfirmationMessage**: Use this option to specify a custom SET confirmation message that will be displayed when the shape is clicked.

  Example:

  ```txt
  Set|234/20|101|2|ConfirmationMessage=My custom message.
  ```

- **SetTrigger=ValueChanged**: Use this option to update parameters or session variables when a specific value changes. See [Configuring a page to update parameters on session variable changes](xref:Configuring_a_page_to_update_parameters_on_session_variable_changes) or [Configuring a page to update a session variable when another session variable changes](xref:Configuring_a_page_to_update_a_session_variable_when_another_session_variable_changes).

- **SetTrigger=Event**: Available from DataMiner 10.0.3 onwards. Use this option to update parameters or session variables when an event occurs on the open Visual Overview page.

    For example, if the configuration below is used with an embedded Router Control component, every time the event is triggered in the component, the set command will be executed with the label of the clicked matrix. Clicking the same input or output multiple times will each time cause the set command to be executed.

    | Shape data field | Value                                                      |
    | ---------------- | ---------------------------------------------------------- |
    | Execute          | Set\|1/1\|350\|\[Event:IOClicked,Label\]\|SetTrigger=Event |

    > [!NOTE]
    >
    > - If "SetTrigger=ValueChanged" is used instead of "SetTrigger=Event" in the example above, clicking the same input or output multiple times causes the set command to be executed only once.
    > - All set commands with a "SetTrigger=Event" option will be triggered when an event occurs, even those that do not contain an \[Event:\] placeholder.

## About using separator characters

If you use the option mentioned above, the character that is used to separate the different parts of the SET command cannot be used in the ConfirmationMessage text.

If you want to use e.g. a pipe character in the ConfirmationMessage text, you have to change the separator character by adding a \[sep:XY\] option in front of the entire SET command, where "X" is the default separator, and "Y" is the separator that is being used instead:

```txt
[sep:|;]Set;234/20;101;2;ConfirmationMessage=Message with a |.
```

> [!NOTE]
> This \[sep:XY\] option can be used in most shape data.

Note that, if you add a \[sep:XY\] option in front of the entire SET command, you can only replace the pipe character (i.e. the default separator) by another character. If, in the \[sep:XY\] option, the first separator is not a pipe character, and the second separator is not a valid replacement, the shape will not be visible. If, for instance, you specify the following, the shape will not be visible:

```txt
[sep:;*]Set|234/20|101|2|ConfirmationMessage=Message.
```

Note also that commas cannot be used to separate different parts of a SET command. In certain cases, e.g. when a SET command refers to an Automation script, commas have to be used to separate the necessary script options. If, however, you do want to use commas in the ConfirmationMessage text, then you can add a \[sep:XY\] option in front of the ConfirmationMessage option:

```txt
Set|234/20|101|2|[sep:,*]ConfirmationMessage=Hi, this is correct.
```
