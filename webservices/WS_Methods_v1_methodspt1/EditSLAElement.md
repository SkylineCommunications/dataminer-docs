---
uid: EditSLAElement
---

# EditSLAElement

Use this method to edit a specified SLA element.

Available from DataMiner 9.0.5 onwards.

## Input

| Item          | Format                      | Description                                                                               |
|---------------|-----------------------------|-------------------------------------------------------------------------------------------|
| Connection    | String                      | The connection string. See [ConnectApp](xref:ConnectApp) .                                  |
| DmaID         | Integer                     | The DataMiner Agent ID.                                                                   |
| ElementID     | Integer                     | The ID of the SLA element.                                                                |
| ViewIDs       | Array of Integer            | The IDs of the views in which the element should be created.                              |
| Configuration | DMASLAElementCon­figuration | See [DMASLAElementConfiguration](xref:DMASLAElementConfiguration). |

## Output

None.

