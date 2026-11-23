---
uid: Protocol.Params.Param.Message
description: "Use the Message element in a DataMiner protocol to show a confirmation message when a user changes a write parameter in the user interface."
---

# Message element

Specifies a message to be displayed when users change the parameter on the user interface.

This has to be specified on the write parameter; it will not have any effect on the read parameter.

<!-- Web app support: RN 33784 -->

## Type

string

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

- Can be used to display a comment when users change the parameter on the user interface. This makes a pop-up window appear with the specified message and Yes/No buttons asking for confirmation. Usually, this text will appear as a pop-up warning when a potentially dangerous setting has to be changed.

## Examples

```xml
<Param id="10">
    ...
    <Message>
        <![CDATA[Restarting the device can cause a temporary outage. Are you sure you want to continue?]]>
    </Message>
...
</Param>
```

![Confirmation message box](~/develop/schemadoc/Protocol/images/confirmationMessageBox.png)
