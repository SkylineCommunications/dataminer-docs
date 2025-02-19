---
uid: Protocol.Params.Param.Message
---

# Message element

Specifies a message to be displayed when users change the parameter on the user interface.

This has to be specified on the write parameter; it will not have any effect on the read parameter.

## Type

string

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

- Can be used to display a comment when users change the parameter on the user interface. This makes a pop-up window appear with the specified message and Yes/No buttons asking for confirmation. Usually, this text will appear as a pop-up warning when a potentially dangerous setting has to be changed.
- In the Dashboards and Monitoring apps, this is supported from DataMiner 10.1.0 \[CU18]/10.2.0 \[CU6]/10.2.9 onwards (RN 33784).

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
