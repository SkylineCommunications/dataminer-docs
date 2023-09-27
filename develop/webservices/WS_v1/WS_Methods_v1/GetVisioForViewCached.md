---
uid: GetVisioForViewCached
---

# GetVisioForViewCached

Use this method to retrieve a specific page of the Visio file linked to a particular view as an image of a specified size, added or changed since a particular point in time.

The page is returned as an interactive image containing clickable regions linked to a certain action, and scrollable child regions (which can again have clickable regions).

All images are in PNG format, and are base64 encoded.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewID | Integer | The view ID. |
| width | Integer | The width of the image to be returned. |
| height | Integer | The height of the image to be returned. |
| page | Integer | The page of the Visio file to be returned. |
| cacheDateUTC | Long integer | If you enter a timestamp in UTC format (milliseconds since midnight January 1, 1970 GMT), then the method will only return the requested page if it has been added or changed since that particular point in time. If you enter -1, there will be no date check. |

## Output

| Item | Format | Description |
|--|--|--|
| GetVisioForViewCachedResult | [DMACache](xref:DMACache) | The Visio file linked to the specified view, returned as an image. |
