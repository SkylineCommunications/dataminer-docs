---
uid: AutomationDateTimeUpDownOptions_class
---

# AutomationDateTimeUpDownOptions class

Below, you find an overview of all members of the *AutomationDateTimeUpDownOptions* class.

- [AutomationDateTimeUpDownOptions methods](xref:AutomationDateTimeUpDownOptions_methods)

- [AutomationDateTimeUpDownOptions properties](xref:AutomationDateTimeUpDownOptions_properties)

This C# class allows you to create an up-down control to select a date and time in an interactive Automation script.

For example:

```txt
UIBlockDefinition blockDateTimeUpDownDefault = new UIBlockDefinition();
blockDateTimeUpDownDefault.Type = UIBlockType.Time;
AutomationDateTimeUpDownOptions configOptionsDateTimeUpDownDefault = new AutomationDateTimeUpDownOptions();
blockDateTimeUpDownDefault.ConfigOptions = configOptionsDateTimeUpDownDefault;
```

![](../../images/datetimeupdown_example.png)



> [!NOTE]
> If the name of a variable starts with the following prefix, IntelliSense will list the object properties: *dateTimeUpDownConfig\**
>
