---
uid: CreateNoteForElement
---

# CreateNoteForElement

Use this method to create a note for a specific element.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection string. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The ID of the element to which the note should be added. |
| note | DMANoteNew | Array consisting of:<br> - String Summary<br> - String Description<br> - Long TimeExpiresUTC (“0” if the note does not expire, otherwise the number of milliseconds since midnight January 1, 1970 GMT) |

## Output

| Item                        | Format  | Description         |
|-----------------------------|---------|---------------------|
| CreateNoteForElementResult | Integer | The ID of the note. |
