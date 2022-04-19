---
uid: Linking_a_shape_to_a_MULTIPLE_SET_command
---

# Linking a shape to a MULTIPLE SET command

Using a shape data field of type **Execute**, you can link a shape to a MULTIPLE SET command.

When you link a shape to a MULTIPLE SET command, that command will be executed each time a user clicks that shape.

> [!NOTE]
>
> - For an example of use, refer to the view "Linking Shapes" on the [Ziine Demo System](xref:ZiineDemoSystem). The example can be found on the Visual page _linking > EXE_.

## Configuring the shape data field

Add a shape data field of type **Execute** to the shape, and set its value to:

```txt
Multiple Set|ViewID|Protocol|ProtocolVersion|ID of write parameter|NewValue|Tooltip|Options|TableRowKey]
```

## Options

In the above-mentioned command, you can use the following option.

- **NoConfirmation**: No confirmation box will appear when users click the shape.

## Example

```txt
Multiple Set||Microsoft Platform|Production|1103|MyNewPassword
```

When users click the shape, a confirmation box will appear asking them whether they want the MULTIPLE SET command to be executed. If they click _Yes_, the command will be executed.
