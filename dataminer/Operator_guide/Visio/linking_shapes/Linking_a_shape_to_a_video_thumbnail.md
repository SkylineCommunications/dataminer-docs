---
uid: Linking_a_shape_to_a_video_thumbnail
---

# Linking a shape to a video thumbnail

Using a shape data field of type **Link**, you can link a shape to a video thumbnail.

When you link a shape to a video thumbnail, the video feed from the video server channel specified in the shape data field will appear inside the shape.

> [!TIP]
>
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[linking > THUMBNAIL]* page.
> - See also: [Making a shape display an image](xref:Making_a_shape_display_an_image)

- To display video feeds from **Selenio MCP1 and MCP3** platforms, the Selenio modules need to have at least firmware version 6.1.

## Configuring the shape data field

Add a shape data field of type **Link** to the shape, and configure one of the following values, depending on your setup:

```txt
#https://<DMAIP>/VideoThumbnails/Video.htm?VideoServerParameters
#http://<DMAIP>/VideoThumbnails/Video.htm?VideoServerParameters
```

For more information on how to configure the shape data field, see [Configuring a video thumbnail for Visual Overview](xref:Configuring_a_video_thumbnail_in_Visio).
