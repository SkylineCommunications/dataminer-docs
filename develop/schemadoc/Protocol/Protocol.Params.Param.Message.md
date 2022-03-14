---
uid: Protocol.Params.Param.Message
---

# Message element

Specifies a message to be displayed when users change the parameter on the user interface.

## Type

string

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

Can be used to display a comment when users change the parameter on the user interface. This makes a popup window appear with the specified message and Yes/No buttons asking for confirmation.

Usually, this text will appear as a pop-up warning when a potentially dangerous setting has to be changed.

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

![alt text](~/develop/schemadoc/Protocol/images/confirmationMessageBox.png "Confirmation message box")
