---
uid: GetElementStateByID
---

# GetElementStateByID

Use this method to request the current state of an element (referenced by ID).

Examples of element states: Active, Stopped, etc.

## Input

| Item       | Format  | Description                                   |
|------------|---------|-----------------------------------------------|
| connection | String  | The connection ID. See [Connect](xref:Connect). |
| DMAID      | Integer | The DataMiner Agent ID.                       |
| ElementID  | Integer | The element ID.                               |

## Output

| Item                      | Format | Description                       |
|---------------------------|--------|-----------------------------------|
| GetElementStateByIDResult | String | The current state of the element. |
