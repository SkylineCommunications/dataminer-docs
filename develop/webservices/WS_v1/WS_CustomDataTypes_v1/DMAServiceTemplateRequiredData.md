---
uid: DMAServiceTemplateRequiredData
---

# DMAServiceTemplateRequiredData

| Name | Format | Description |
|--|--|--|
| Name | String | The name of the required data |
| RequiredData | DMAServTemplateRequiredData | The *DMAServTemplateRequiredData* object can represent the following things:<br> - *DMAServiceTemplateRequiredInputData*: See [DMAServiceTemplateRequiredInputData](xref:DMAServiceTemplateRequiredInputData).<br> - *DMAServiceTemplateRequiredSLA*, which consists of a [DMASTString](xref:DMASTString).<br> - *DMAServiceTemplateRequiredGeneratedService*, which consists of a [DMASTString](xref:DMASTString).<br> - DMAServiceTemplateRequiredDestView, which can be either:<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;- A fixed view, *DMADestViewFixed*, determined by *ViewID* (int).<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;- A templated view, *DMADestViewByName*, determined by a [DMASTString](xref:DMASTString).<br> - DMAServiceTemplateRequiredSpecialInputData, consisting of:<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;- *Title* (string): The title specified for the input data.<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;- *InputData*: See [DMAServiceTemplateRequiredInputData](xref:DMAServiceTemplateRequiredInputData) |
