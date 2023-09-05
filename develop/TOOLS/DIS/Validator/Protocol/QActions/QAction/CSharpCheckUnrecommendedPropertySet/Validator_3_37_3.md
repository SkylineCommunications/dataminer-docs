---  
uid: Validator_3_37_3  
---

# CSharpCheckUnrecommendedPropertySet

## UnrecommendedThreadCurrentThreadCurrentUICulture

### Description

Setting property 'Thread.CurrentThread.CurrentUICulture' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.37.3      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

As the threads that execute QAction code are part of a thread pool, changing a setting on a thread in a QAction can affect other QActions of other connectors.
