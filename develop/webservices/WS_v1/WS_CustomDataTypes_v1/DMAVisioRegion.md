---
uid: DMAVisioRegion
---

# DMAVisioRegion

| Item | Format | Description |
|--|--|--|
| RegionID | Integer | The ID of the region. |
| xCoord | Integer | The X coordinate of the top-left corner of the region (number of pixels measured from the left). |
| yCoord | Integer | The Y coordinate of the top-left corner of the region (number of pixels measured from the left). |
| Width | Integer | The width of the region (in pixels). |
| Height | Integer | The height of the region (in pixels). |
| Shape | String | The shape of the region: “rect” (= rectangle), “circle”, “poly” (= polygon), etc. Note: At present, only “rect” is supported. |
| ContentType | String | The type of content: “Action”, “Url”, “Scroll”, “ParameterControl” or “SetVarControl”. |
| Type | String | The type of region: “NavigateView”, “NavigateElement”, “NavigateService”, “Url”, “Scroll”, “ParameterControl” or “SetVarControl”. |
| ExtraData | Array of [DMAGenericProperty](xref:DMAGenericProperty) | Additional data. Examples:<br> -  If *Type* is “NavigateElement”, *ExtraData* will contain the DataMiner ID and the Element ID. <br> -  If *Type* is “SetVarControl”, *ExtraData* will contain extra values and filters. |
| Actions | Array of [DMAVisioRegionAction](xref:DMAVisioRegionAction) | The actions in the region. |
| ChildRegions | Array of DMAVisioRegion | The child regions in the region. |
| ActionSequence | Array of [DMAVisioRegionAction](xref:DMAVisioRegionAction) | The actions in the region in the order in which they should occur. |
| ScrollRegionPNG | String | The base64-encoded PNG image (only if *Type* or *ContentType* is “Scroll”). |
| ScrollRegionPNGWidth | Integer | The width in pixels of the image in *ScrollRegionPNG* (only if *Type* or *ContentType* is “Scroll”). |
| ScrollRegionPNGHeight | Integer | The height in pixels of the image in *ScrollRegionPNG* (only if *Type* or *ContentType* is “Scroll”). |
