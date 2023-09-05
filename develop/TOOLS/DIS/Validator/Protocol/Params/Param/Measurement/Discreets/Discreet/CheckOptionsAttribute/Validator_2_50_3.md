---  
uid: Validator_2_50_3  
---

# CheckOptionsAttribute

## EmptyConfirmOption

### Description

Empty option 'confirm' in attribute 'Discreet@options' for context\-menu item '{contextMenuItem}'. Param ID {pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.50.3      |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Example code

```xml
<Discreet options="confirm:The selected item(s) will be deleted permanently.">
    <Display>Delete selected row(s)</Display>
    <Value>delete</Value>
</Discreet>
```

### Details

A context menu action executing a critical action should have a confirmation message.  
This can be done by adding the confirm option via the 'Discreet@options' attribute.
