---
uid: GetNotesForElement
---

# GetNotesForElement

Use this method to retrieve the notes for a particular element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ElementID  | Integer | The element ID.                                                                  |

## Output

| Item | Format | Description |
|--|--|--|
| GetNotesForElement­Result | Array of [DMANote](xref:DMANote) | The notes for the specified element. |
