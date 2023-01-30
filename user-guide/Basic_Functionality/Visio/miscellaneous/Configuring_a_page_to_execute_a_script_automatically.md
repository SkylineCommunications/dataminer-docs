---
uid: Configuring_a_page_to_execute_a_script_automatically
---

# Configuring a page to execute a script automatically

From DataMiner 10.1.1/10.2.0 onwards, it is possible to have a script executed automatically either when a specific value changes or when a specific event occurs on the page.

## Configuring a page to execute a script when a specific value changes

On page level, add a shape data field of type **Execute**, and specify a value in the following format:

```txt
Script:ScriptName|DummyName=ElementName or DmaID/ElementID;...| ParameterName1=[var:myVar];ParameterName2=#ValueFile;...| MemoryName=MemoryFileName;...|ToolTip|Options|Trigger=ValueChanged
```

> [!NOTE]
> Instead of `Trigger=ValueChanged`, you can also specify `SetTrigger=ValueChanged`.

For more information about this syntax, see [Linking a shape to an Automation script](xref:Linking_a_shape_to_an_Automation_script)

If a value changes that affects any of the input specified in this syntax (e.g. a dummy or parameter), the script will be triggered.

## Configuring a page to execute a script when an event occurs on the page

On page level, add a shape data field of type **Execute**, and specify a value in the following format:

```txt
Script:ScriptName|DummyName=ElementName or DmaID/ElementID;...| ParameterName1=[var:myVar];ParameterName2=#ValueFile;...| MemoryName=MemoryFileName;...|ToolTip|Options|Trigger=Event
```

> [!NOTE]
> Instead of `Trigger=Event`, you can also specify `SetTrigger=Event`.

For more information about this syntax, see [Linking a shape to an Automation script](xref:Linking_a_shape_to_an_Automation_script)

For example, with the configuration below, double-clicking a node in an embedded service definition will trigger an Automation script that takes the node ID as a parameter.

| Shape data field | Value                                                                                                            |
| ---------------- | ---------------------------------------------------------------------------------------------------------------- |
| Execute          | Script:\<myScript>\|Parameters:IDParam=\[event:NodeDoubleClicked,ID\]\|Options:\<possibleOptions>\|Trigger=Event |

> [!TIP]
> See also: [\[Event:...\]](xref:Placeholders_for_variables_in_shape_data_values#event)
