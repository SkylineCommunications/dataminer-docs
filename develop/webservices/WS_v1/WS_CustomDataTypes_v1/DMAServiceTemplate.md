---
uid: DMAServiceTemplate
---

# DMAServiceTemplate

| Item | Format | Description |
|--|--|--|
| Name | String | The name of the service template. |
| Description | String | The description of the service template. |
| KeepCopiesOnReApply | Boolean | Determines whether copies of the services are kept when the service template is reapplied. |
| RcaChainDefinition | Array of DMARcaChain | The different items in the RCA chain for the generated services: *FirstValue* and *SecondValue* (specified as integers). |
| Definition.AutoExecuteOnElementAdd | Boolean | Determines whether the service template is automatically applied when a new element is added in the DMS. |
| Definition.CreateSLA | Boolean | Determines whether an SLA is created for the services generated with the service template. |
| Definition.RequireConfirmation | Boolean | Determines whether the user has to confirm before the service template is applied. |
| Definition.GlobalConditions | Array of DMAServiceTemplateGlobalCondition | Array of conditions, each consisting of a type (*None*, *Equals*, *WildCard* or *ContainsRow*) and two values. These conditions determine when elements can be combined in a service. They can for instance specify that part of the element names must be equal to a specific value. |
| Definition.PreRequiredData | Array of [DMAServiceTemplateRequiredData](xref:DMAServiceTemplateRequiredData) | Extra information used in the service template to create services. This information is required before elements are assigned (e.g. data used to limit elements according to a user-specified condition). |
| Definition.RequiredData | Array of [DMAServiceTemplateRequiredData](xref:DMAServiceTemplateRequiredData) | Extra information used in the service template to create services. |
| Definition.AdvancedRequestOrder | String | The custom order in which child elements and input data should be selected when the service is generated, if any. For more information, refer to the DataMiner User Guide. |
| Definition.AutoGenerateName | [DMASTString](xref:DMASTString) | The template for the name of the generated services. |
| Definition.GenerateDescription | [DMASTString](xref:DMASTString) | The template for the description of the generated services. |
| Groups | Array of [DMAServiceInfoGroupDefinition](xref:DMAServiceInfoGroupDefinition) | Arrays defining different groups of child elements for generated services. |
| ExcludeTriggers | Array of DMAServiceInfoTriggerCombination | The triggers determining whether the service child is excluded. These *DMATriggerCombination* objects consists of the following fields:<br> - *TriggerID*: The ID of the trigger.<br> - *CombinationType*: A combination type such as "And", "Not", etc. |
| IncludeTriggers | Array of DMAServiceInfoTriggerCombination | The triggers determining whether the service child is included. These *DMATriggerCombination* objects consists of the following fields:<br> - *TriggerID*: The ID of the trigger.<br> - *CombinationType*: A combination type such as "And", "Not", etc. |
| NotUsedTriggers | Array of DMAServiceInfoTriggerCombination | The triggers determining whether the service child is used. These *DMATriggerCombination* objects consists of the following fields:<br> - *TriggerID*: The ID of the trigger.<br> - *CombinationType*: A combination type such as "And", "Not", etc. |
| Triggers | Array of [DMAServiceTemplateConfigurationTrigger](xref:DMAServiceTemplateConfigurationTrigger) | The different triggers used in the service template, for instance to determine whether a service child is excluded. The triggers listed in this array are referred to by ID in the different trigger combinations. |
| ServiceElementInfo.AlarmTemplate | String | The alarm template used for the generated services. |
| ServiceElementInfo.ProtocolTemplate | String | The service protocol used for the generated services. |
| ServiceElementInfo.ProtocolVersion | String | The service protocol version used for the generated services. |
| ServiceElementInfo.TrendTemplate | String | The trend template used for the generated services. |
| ServiceParams | Array of [DMAServiceParams](xref:DMAServiceParams) | The child elements of the generated services. |
| VisioInfo.DefaultPage | Integer | The default page of the Visio drawing used for the generated services. |
| VisioInfo.Name.Template | String | The template for the name of the Visio drawing used for the generated services. Placeholders in this template are in the format {0}, {1}, etc. and refer to the placeholders in the next field. See [DMASTString](xref:DMASTString). |
| VisioInfo.Name.Placeholders | Array of DMASTPlaceholder | The placeholders used in the template, e.g. *\[data:Data Item Name\]* or *\[element:1:title\]*. See [DMASTString](xref:DMASTString). |
