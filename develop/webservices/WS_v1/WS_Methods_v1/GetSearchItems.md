---
uid: GetSearchItems
---

# GetSearchItems

Use this method to retrieve views, elements and services based on a search query.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| query      | String | The search query. The syntax of this search query is identical to the syntax used in DataMiner Cube search boxes.<br>For more information, see [Searching in DataMiner Cube](xref:Searching_in_DataMiner_Cube). |
| count      | Integer | The maximum number of items to be returned. |

## Output

| Item | Format | Description |
|--|--|--|
| GetSearchItemsResult | Array of [DMASearchItem](xref:DMASearchItem) | The items that match the search query. |
