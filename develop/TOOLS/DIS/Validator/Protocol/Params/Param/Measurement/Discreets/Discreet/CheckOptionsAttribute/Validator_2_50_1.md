---  
uid: Validator_2_50_1  
---

# CheckOptionsAttribute

## MisconfiguredConfirmOptions

### Description

Misconfigured 'confirm' option(s) in 'Discreet@options' for ContextMenu. Param ID '{pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.50.1      |
| Severity     | BubbleUp    |
| Certainty    | Uncertain   |
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
