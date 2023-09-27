---
uid: GetVisioThumbnailForService
---

# GetVisioThumbnailForService

Use this method to retrieve a specific page of the Visio file linked to a particular service as an image of a specified dimension.

The page is returned as a static image. If you want the page to be returned as an interactive image containing clickable regions linked to a certain action, and scrollable child regions, then use GetVisioForService instead (see [GetVisioForService](xref:GetVisioForService)).

All images are in PNG format, and are base64 encoded.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| serviceID  | Integer | The service ID.                                                                  |
| width      | Integer | The width of the image to be returned.                                           |
| height     | Integer | The height of the image to be returned.                                          |
| page       | Integer | The page of the Visio file to be returned.                                       |

## Output

| Item | Format | Description |
|--|--|--|
| GetVisioThumbnailForServiceResult | [DMAVisio](xref:DMAVisio) | The Visio file linked to the specified service, returned as a static image. |
