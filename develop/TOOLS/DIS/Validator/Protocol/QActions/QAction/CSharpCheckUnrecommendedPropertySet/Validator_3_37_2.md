---  
uid: Validator_3_37_2  
---

# CSharpCheckUnrecommendedPropertySet

## UnrecommendedThreadCurrentThreadCurrentCulture

### Description

Setting property 'Thread.CurrentThread.CurrentCulture' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.37.2      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

As the threads that execute QAction code are part of a thread pool, changing a setting on a thread in a QAction can affect other QActions of other connectors.
