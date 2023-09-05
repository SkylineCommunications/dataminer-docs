---  
uid: Validator_5_1_2  
---

# CheckIdAttribute

## ExcessiveAttribute

### Description

Excessive 'id' Attribute in tag 'On' with value '{onTagValue}'. Trigger ID '{triggerId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Trigger     |
| Full Id      | 5.1.2       |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

When triggering on:  
  \- parameter  
  \- command  
  \- response  
  \- pair  
  \- group  
  \- timer  
  \- session  
A 'Trigger\/On@id' attribute is expected and should have one of the following values:  
  \- 'each': in this case, the protocol should have at least one item of the type mentioned in the 'Trigger\/On' tag.  
  \- The ID of an item of the type mentioned in the 'Trigger\/On' tag.  
When triggering on:  
  \- protocol  
  \- communication  
No 'Trigger\/On@id' attribute is expected.
