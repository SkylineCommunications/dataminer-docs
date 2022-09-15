---
uid: EditSLAElement
---

# EditSLAElement

Use this method to edit a specified SLA element.

Available from DataMiner 9.0.5 onwards.

## Input

| Item          | Format                      | Description                                                                               |
|---------------|-----------------------------|-------------------------------------------------------------------------------------------|
| connection    | String                      | The connection string. See [ConnectApp](xref:ConnectApp).                                 |
| dmaID         | Integer                     | The DataMiner Agent ID.                                                                   |
| elementID     | Integer                     | The ID of the SLA element.                                                                |
| viewIDs       | Array of Integer            | The IDs of the views in which the element should be created.                              |
| configuration | DMASLAElementConfiguration | See [DMASLAElementConfiguration](xref:DMASLAElementConfiguration). |

## Output

None.
