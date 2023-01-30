---
uid: DMAServiceParams
---

# DMAServiceParams

| Item | Format | Description |
|--|--|--|
| IsService | Boolean | Indicates whether the service child is a service. |
| ElementSelection | DMAElementSelectionMethod | Determines whether the service child is fixed or templated, and how this is configured.<br> - For a fixed service child, *DMAFixedElementSelectionMethod* is used, which consists of the *DataMinerID* and *elementID* fields (both integers).<br> - For a templated service child, *DMATemplatedElementSelectionMethod* is used, which consists of 3 booleans (*allowReuse*, *OptionalElement*, *IncludeAllMatches*) and template filters. These *DMATemplateFilter* objects consist of a *Protocol* (string), *Version* (string) and *Mask* (*DMASTMaskString*) field. The *DMASTMaskString* consists of a template string and an array of placeholders, as well as an additional *Isregex* boolean, indicating whether a regular expression is used, and a *regexOptions* enum (*None*, *IgnoreCase*, *forceFullLine*). |
| ParameterFilters | Array of DMAServiceParamFilter | The filters determining when parameters are included in the service child, if any. <br> A filter consists of 3 fields:<br> - *IsPrimaryKey* (Boolean): Determines whether the primary or the display key is used.<br> - *ParameterID* (integer): The ID of the parameter.<br> - *Filter* (*DMASTMaskString*): A filter consisting of a template string and an array of placeholders, as well as an additional *Isregex* boolean, indicating whether a regular expression is used, and a *regexOptions* enum (*None*, *IgnoreCase*, *forceFullLine*). |
| IncludedCapped | String | The maximum severity for the service child when it is included: *Critical*, *Major*, *Minor*, *Warning* or *Normal*. |
| NotUsedCapped | String | The maximum severity for the service child when it is not used: *Critical*, *Major*, *Minor*, *Warning* or *Normal*. |
| GroupID | Integer | The ID of the group the service child is in, if any. |
| Alias | Array | The alias of the service child, which is created using a [DMASTString](xref:DMASTString). |
| Description | String | The description of the service child. |
