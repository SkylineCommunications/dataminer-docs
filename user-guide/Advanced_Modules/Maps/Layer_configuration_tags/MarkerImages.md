---
uid: MarkerImages
---

# MarkerImages

In the *\<MarkerImages>* tag, add a *\<MarkerImage>* tag for every marker image you intend to use in this layer.

## Attributes

Define each image by means of the following attributes.

### id

In this mandatory attribute, specify the unique ID of the image.

In layers of sourceType “table”, this ID can be used in conjunction with the *\<MarkerSelectionPID>* tag to dynamically select a marker image based on the contents of a specific table cell.

### url

In this mandatory attribute, specify the path to the marker image file.

Enter either an absolute path (starting with *http://*) or a path relative to *C:\\Skyline DataMiner\\Webpages\\Maps\\*

> [!NOTE]
> To generate images dynamically, it is possible to use placeholders in the URL, which should then be specified in the *\<MarkerDetails>* tag. See [MarkerDetails](xref:MarkerDetails).

### width

In this mandatory attribute, specify the width (in pixels) of the marker image.

If an image has to be selected from an image strip, this has to be the width of one single image in the strip. See the *single* attribute below.

### height

In this mandatory attribute, specify the height (in pixels) of the marker image.

### anchor

In this optional attribute, you can specify the point of the image that has to be on top of the map location it has to mark.

Default anchor: Bottom middle of the marker image

Example: If the marker image is 32 pixels wide and 32 pixels high, specifying “0,32” in the *anchor* attribute will cause the lower left corner of the image to be anchored to the map location.

### single

With this optional attribute, you can specify whether or not the marker image is a single image or a so-called image strip containing a separate image for every alarm severity.

> [!NOTE]
> An image strip must contain nine images that each represent one of the following alarm severities: Normal, Warning, Minor, Major, Critical, Undefined, Timeout, Masked, Initial (in that precise order!)

### shadowUrl, shadowWidth, shadowHeight, shadowAnchor

These optional attributes were used to respectively specify the path to a shadow image file, specify its width, specify its height, and specify the point of the shadow image that has to be on top of the map location it has to mark.

> [!NOTE]
> Marker shadows are no longer supported since version 3.14 of the Google Maps JavaScript API. Existing shadow marker definitions are now ignored.

### shapeType

If, in the *shape* attribute below, you have defined a clickable area on top of the marker image, then, in this optional *shapeType* attribute, specify the geometric form of that clickable area:

- circle,

- poly (i.e. polygon), or

- rect (i.e. rectangle)

By default, no shape is defined.

### shape

In this optional attribute, you can define a clickable area on top of the marker image using the W3C’s AREA coords specification.

For more information, see [http://www.w3.org/TR/REC-html40/struct/objects.html#adef-coords](http://www.w3.org/TR/REC-md40/struct/objects.html#adef-coords)

This shape attribute has to contain an array of integers that specify the pixel position of the clickable area relative to the top-left corner of the marker image. The coordinates to be specified depend on the kind of geometric form you specified in the *shapeType* attribute.

- circle: shape has to contain “x1,y1,r” where x1,y2 are the coordinates of the center of the circle, and r is the radius of the circle.

- poly: shape has to contain “x1,y1,x2,y2,...,xn,yn” where each x,y pair contains the coordinates of one vertex of the polygon.

- rect: shape has to contain “x1,y1,x2,y2” where x1,y1 are the coordinates of the upper-left corner of the rectangle and x2,y2 are the coordinates of the lower-right coordinates of the rectangle.

## Example

```xml
<MarkerImages>
  <MarkerImage
    id="flags"
    url="images/icons/flag.png"
    width="20"
    height="32"
    anchor="0,32"
    single="false"
    shadowUrl="images/icons/flag_shadow.png"
    shadowWidth="37"
    shadowHeight="32"
    shadowAnchor="0,32"
    shapeType="poly"
    shape="1,1,1,20,18,20,18,1" />
</MarkerImages>
```
