---  
uid: Validator_3_37_1  
---

# CSharpCheckUnrecommendedPropertySet

## UnrecommendedCultureInfoDefaultThreadCurrentCulture

### Description

Setting property 'CultureInfo.DefaultThreadCurrentCulture' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.37.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Changing application domain settings should not be performed as QActions from other connectors might be impacted by this change.
