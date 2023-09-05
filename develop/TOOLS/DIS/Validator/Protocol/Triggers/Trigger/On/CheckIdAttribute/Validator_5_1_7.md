---  
uid: Validator_5_1_7  
---

# CheckIdAttribute

## LeadingZeros

### Description

Invalid use of leading zeros on 'On@id' attribute. Trigger ID '{triggerId}'. Current value '{attributeValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Trigger     |
| Full Id      | 5.1.7       |
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
