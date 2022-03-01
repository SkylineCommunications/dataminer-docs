---
uid: GetVisioPagesForView
---

# GetVisioPagesForView

Use this method to retrieve a list of the pages of the Visio file linked to a particular view.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| ViewID     | Integer | The view ID.                                                                     |

## Output

| Item                        | Format                                                                               | Description                                               |
|-----------------------------|--------------------------------------------------------------------------------------|-----------------------------------------------------------|
| GetVisioPagesForView­Result | Array of DMAVisioPage (see [DMAVisioPage](xref:DMAVisioPage)) | A list of the pages of the Visio file linked to the view. |

