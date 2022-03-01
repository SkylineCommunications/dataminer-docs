---
uid: DMAServiceConfiguration
---

# DMAServiceConfiguration

| Item                            | Format                                     | Description                                                                                                                                                       |
|---------------------------------|--------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Name                            | String                                     | The name of the service.<br> A limit of at most 150 characters applies.                                                                                           |
| Description                     | String                                     | The description of the service.                                                                                                                                   |
| ServiceDefinitionName           | String                                     | The name of the service definition used for this service.                                                                                                         |
| ServiceDefinitionVersion        | String                                     | The version of the service definition used for this service.                                                                                                      |
| ServiceDefinitionAlarm­Template | String                                     | The alarm template used to monitor the service.                                                                                                                   |
| ServiceDefinitionTrend­Template | String                                     | The trend template used to track the service trend data.                                                                                                          |
| Triggers                        | Array of DMAService­ConfigurationTrigger   | The triggers that determine whether a child item is included in the service or not. <br> See [DMAServiceConfigurationTrigger](xref:DMAServiceConfigurationTrigger). |
| Groups                          | Array of DMAService­ConfigurationGroup     | The groups of child items contained within the service.<br> See [DMAServiceConfigurationGroup](xref:DMAServiceConfigurationGroup)                                   |
| Parameters                      | Array of DMAService­ConfigurationParameter | The child items of the service. <br> See [DMAServiceConfigurationParameter](xref:DMAServiceConfigurationParameter)                                                  |
