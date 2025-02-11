---
uid: DMAServiceTemplateMissingData
---

# DMAServiceTemplateMissingData

| Item | Format | Description |
|------|--------|-------------|
| Name                 | String          | The input data name. This is the name that should also be specified in the corresponding *inputData* input of the *CreateServiceByApplyingServiceTemplate* and *ReapplyService* methods. |
| DisplayName          | String          | The input data title. |
| Type                 | String          | The type of input data: "Undefined", "Text", "DropDown", "Hidden", "CheckBox" or "HiddenFromScreen" |
| SelectedValue        | String          | The selected input data value. |
| SelectedDisplayValue | String          | The selected input data value as it is displayed. |
| PossibleValues       | Array of string | If the Type is “DropDown”, this tag contains a list of values that can be selected. |
| InvalidReason        | String          | The reason why the input data is currently invalid. |
