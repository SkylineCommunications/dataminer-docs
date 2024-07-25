---
uid: GetProtocolsForView
---

# GetProtocolsForView

Use this method to retrieve all protocols for the specified view.

## Input

| Item            | Format  | Description                                                   |
|-----------------|---------|---------------------------------------------------------------|
| connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp).         |
| viewID          | Integer | The view ID.                                                  |
| includeSubViews | Boolean | Indicates whether protocols from subviews should be included. |

## Output

| Item | Format | Description |
|--|--|--|
| GetProtocolsForViewResult | Array of [DMAGenericProperty](xref:DMAGenericProperty) | The protocols of the specified view. |
