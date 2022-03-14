---
uid: GetPagesForElementSorted
---

# GetPagesForElementSorted

Use this method to retrieve a specific number of Data Display pages of a particular element.

> [!NOTE]
> Using this method, you can e.g. request Data Display pages in batches in order to minimize loading time.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ElementID  | Integer | The element ID.                                                                  |
| Index      | Integer | The point from which to start returning Data Display pages.                      |
| Count      | Integer | The number of Data Display pages to be returned.                                 |
| OrderBy    | String  | The field(s) by which to order the Data Display pages (separated by semicolons). |

## Output

| Item | Format | Description |
|--|--|--|
| GetPagesForElement­SortedResult | Array of [DMAElementPage](xref:DMAElementPage) | The requested number of Data Display pages, sorted as specified. |
