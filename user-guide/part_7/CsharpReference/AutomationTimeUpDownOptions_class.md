# AutomationTimeUpDownOptions class

Below, you find an overview of all members of the *AutomationDateTimeUpDownOptions* class.

- [AutomationDateTimeUpDownOptions methods](AutomationDateTimeUpDownOptions_methods.md)

- [AutomationDateTimeUpDownOptions properties](AutomationDateTimeUpDownOptions_properties.md)

This C# class allows you to create an up-down control to select a time in an interactive Automation script.

For example:

```txt
UIBlockDefinition blockTimeUpDownDefault = new UIBlockDefinition();                            
blockTimeUpDownDefault.Type = UIBlockType.Time;                                                
AutomationTimeUpDownOptions configOptionsTimeUpDownDefault = new AutomationTimeUpDownOptions();
blockTimeUpDownDefault.ConfigOptions = configOptionsTimeUpDownDefault;                         
```

![](../../images/timeupdown_example.png)

 

> [!NOTE]
> If the name of a variable starts with the following prefix, IntelliSense will list the object properties: *timeUpDownConfig\**
>
