---
uid: DMAServiceConfiguration
---

# DMAServiceConfiguration

| Item | Format | Description |
|--|--|--|
| Name | String | The name of the service. A limit of at most 150 characters applies. |
| Description | String | The description of the service. |
| ServiceDefinitionName | String | The name of the service definition used for this service. |
| ServiceDefinitionVersion | String | The version of the service definition used for this service. |
| ServiceDefinitionAlarmTemplate | String | The alarm template used to monitor the service. |
| ServiceDefinitionTrendTemplate | String | The trend template used to track the service trend data. |
| Triggers | Array of [DMAServiceConfigurationTrigger](xref:DMAServiceConfigurationTrigger) | The triggers that determine whether a child item is included in the service or not. |
| Groups | Array of [DMAServiceConfigurationGroup](xref:DMAServiceConfigurationGroup) | The groups of child items contained within the service. |
| Parameters | Array of [DMAServiceConfigurationParameter](xref:DMAServiceConfigurationParameter) | The child items of the service. |
