---
uid: GetPagesForServiceSorted
---

# GetPagesForServiceSorted

Use this method to retrieve a specific number of Data Display pages of a particular service.

> [!NOTE]
> Using this method, you can e.g. request Data Display pages in batches in order to minimize loading time.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| serviceID  | Integer | The service ID.                                                                  |
| index      | Integer | The point from which to start returning Data Display pages.                      |
| count      | Integer | The number of Data Display pages to be returned.                                 |
| orderBy    | String  | The field(s) by which to order the Data Display pages (separated by semicolons). |

## Output

| Item | Format | Description |
|--|--|--|
| GetPagesForServiceSortedResult | Array of [DMAElementPage](xref:DMAElementPage) | The requested number of Data Display pages, sorted as specified. |
