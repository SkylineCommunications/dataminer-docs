---
uid: GetButtonPanelInfo
---

# GetButtonPanelInfo

Use this method to retrieve the parameter IDs of the parameters containing information on a button panel. Available from DataMiner 9.6.11 onwards.

## Input

| Item        | Format  | Description                                            |
|-------------|---------|--------------------------------------------------------|
| Connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp).   |
| DmaID       | Integer | The DMA ID of the button panel element.                |
| ElementID   | Integer | The ID of the button panel element.                    |
| ParameterID | Integer | The parameter containing the button panel information. |

## Output

| Item | Format | Description |
|--|--|--|
| GetButtonPanelInfo­Result | [DMAButtonPanelInfo](xref:DMAButtonPanelInfo) | The parameter IDs of the parameters containing the button panel information. |
