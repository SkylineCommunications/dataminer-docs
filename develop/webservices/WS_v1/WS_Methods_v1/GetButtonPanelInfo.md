---
uid: GetButtonPanelInfo
---

# GetButtonPanelInfo

Use this method to retrieve the parameter IDs of the parameters containing information on a button panel.

## Input

| Item        | Format  | Description                                            |
|-------------|---------|--------------------------------------------------------|
| connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp).   |
| dmaID       | Integer | The DMA ID of the button panel element.                |
| elementID   | Integer | The ID of the button panel element.                    |
| parameterID | Integer | The parameter containing the button panel information. |

## Output

| Item | Format | Description |
|--|--|--|
| GetButtonPanelInfoResult | [DMAButtonPanelInfo](xref:DMAButtonPanelInfo) | The parameter IDs of the parameters containing the button panel information. |
