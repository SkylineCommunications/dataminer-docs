---  
uid: Validator_2_50_4  
---

# CheckOptionsAttribute

## UntrimmedConfirmOption

### Description

Untrimmed option 'confirm' in attribute 'Discreet@options' for context\-menu item '{contextMenuItem}' in Param with ID '{pid}'. Current value '{untrimmedValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.50.4      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

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
