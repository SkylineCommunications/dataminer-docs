---
uid: DMAVisio
---

# DMAVisio

| Item | Format | Description |
|--|--|--|
| DataMinerID | Integer | The ID of the DataMiner Agent. |
| ID | Integer | The ID of the element, service or view. |
| Page | Integer | The index number of the Visio page. |
| PNG | String | The base64-encoded PNG image. |
| Width | Integer | The width of the PNG image (in pixels). |
| Height | Integer | The height of the PNG image (in pixels). |
| Regions | Array of [DMAVisioRegion](xref:DMAVisioRegion) | The regions in the Visio page. |
| Error | String | If the requested Visio page could not be retrieved, this field will contain the error message. |
| Pages | Array of [DMAVisioPage](xref:DMAVisioPage) | All pages in the Visio file. |
| LastChangeUTC | Long integer | The time when the object was last changed, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
