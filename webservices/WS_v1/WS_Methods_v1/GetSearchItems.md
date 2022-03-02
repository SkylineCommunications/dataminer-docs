---
uid: GetSearchItems
---

# GetSearchItems

Use this method to retrieve views, elements and services based on a search query.

## Input

| Item       | Format  | Description                                                                                                                                                               |
|------------|---------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) .                                                                                          |
| Query      | String  | The search query.<br> The syntax of this search query is identical to the syntax used in DataMiner Cube search boxes. For more information, see the DataMiner User Guide. |
| Count      | Integer | The maximum number of items to be returned.                                                                                                                               |

## Output

| Item                 | Format                                                                                  | Description                            |
|----------------------|-----------------------------------------------------------------------------------------|----------------------------------------|
| GetSearchItemsResult | Array of DMASearchItem (see [DMASearchItem](xref:DMASearchItem)) | The items that match the search query. |

