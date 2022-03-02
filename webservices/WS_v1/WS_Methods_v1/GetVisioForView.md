---
uid: GetVisioForView
---

# GetVisioForView

Use this method to retrieve a specific page of the Visio file linked to a particular view as an image of a specified size.

The page is returned as an interactive image containing clickable regions linked to a certain action, and scrollable child regions. If you want the page to be returned as a static image, then use GetVisioThumbnailForView instead (see [GetVisioThumbnailForView](xref:GetVisioThumbnailForView) ).

All images are in PNG format, and are base64 encoded.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ViewID     | Integer | The view ID.                                                                     |
| Width      | Integer | The width of the image to be returned.                                           |
| Height     | Integer | The height of the image to be returned.                                          |
| Page       | Integer | The page of the Visio file to be returned.                                       |

## Output

| Item | Format | Description |
|--|--|--|
| GetVisioForViewResult | [DMAVisio](xref:DMAVisio) | The Visio file linked to the specified view, returned as an interactive image. |
