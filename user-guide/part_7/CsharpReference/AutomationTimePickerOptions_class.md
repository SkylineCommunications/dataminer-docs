---
uid: AutomationTimePickerOptions_class
---

# AutomationTimePickerOptions class

Below, you find an overview of all members of the *AutomationDateTimeUpDownOptions* class.

- [AutomationTimePickerOptions methods](xref:AutomationTimePickerOptions_methods)

- [AutomationTimePickerOptions properties](xref:AutomationTimePickerOptions_properties)

This C# class allows you to create a time picker control in an interactive Automation script.

For example:

```txt
UIBlockDefinition blockTimePickerDefault = new UIBlockDefinition();
blockTimePickerDefault.Type = UIBlockType.Time;
AutomationTimePickerOptions configOptionsTimePickerDefault = new AutomationTimePickerOptions();
blockTimePickerDefault.ConfigOptions = configOptionsTimePickerDefault;
```

![](../../images/timepicker_example.png)



> [!NOTE]
> If the name of a variable starts with the following prefix, IntelliSense will list the object properties: *timePickerConfig\**
>
