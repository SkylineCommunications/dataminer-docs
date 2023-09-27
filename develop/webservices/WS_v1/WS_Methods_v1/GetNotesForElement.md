---
uid: GetNotesForElement
---

# GetNotesForElement

Use this method to retrieve the notes for a particular element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| elementID  | Integer | The element ID.                                                                  |

## Output

| Item | Format | Description |
|--|--|--|
| GetNotesForElementResult | Array of [DMANote](xref:DMANote) | The notes for the specified element. |
