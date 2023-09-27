---
uid: DMAServiceTemplateConfigurationTrigger
---

# DMAServiceTemplateConfigurationTrigger

| Item | Format | Description |
|--|--|--|
| TableIndex | [DMASTString](xref:DMASTString) | The table index of the parameter used in the trigger. This is in *DMASTString* format but will usually consist of empty placeholders and a regular string as the template. |
| ParameterNameForTemplate | [DMASTString](xref:DMASTString) | The name of the parameter used in the trigger. This is used in case the parameter is not specified by ID, so that the parameter name can change dynamically. |
| Delay | Integer | The delay before the trigger is activated (in ms), if any. |
| DataMinerID | Integer | The DataMiner ID of the object used in the trigger. |
| ElementID | Integer | The ID of the element used in the trigger. |
| ParameterID | Integer | The ID of the parameter used in the trigger. |
| Type | String | The type of event functioning as trigger: *Alarm* (for an alarm state), *ElementState* (for an element alarm state) or *Parameter* (for a parameter value). |
| Value | [DMASTString](xref:DMASTString) | In case a condition is used for the trigger, this indicates that value specified in the condition. For conditions of type *Alarm* or *ElementState*, this is a severity, which means it will be a *DMASTString* without placeholders. For conditions of type *Parameter*, it can be a regular *DMASTString* with placeholders. |
| ValueCondition | String | In case a condition is used for the trigger, this indicates the first part of the condition: *\<*, *\<=*, *==*, *\<\>*, *\>=*, *\>* or *exists row* (in case the condition is of type *Parameter value*). |
