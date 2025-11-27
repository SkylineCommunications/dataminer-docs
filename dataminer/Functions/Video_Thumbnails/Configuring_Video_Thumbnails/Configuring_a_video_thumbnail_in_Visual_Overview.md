---
uid: Configuring_a_video_thumbnail_in_Visio
---

# Configuring a video thumbnail for Visual Overview

## Configuring a video thumbnail in Visio

When you are [configuring a drawing in Visio](xref:Getting_started_with_visual_overview), you can link a shape to a video thumbnail as follows:

1. Add a shape data field of type *Link* to the shape.

1. Enter the video URL. For example:

   ```txt
   #https://<DMAIP>/VideoThumbnails/Video.htm?type=HTML5&source=https://videoserver/video.mp4
   ```

   The URL consists of the following main components:

   - `#`: The "#" in front of the URL ensures that the video is displayed in an embedded browser. If you do not add this, the shape is rendered as it is drawn in Visio and clicking it opens your default browser and navigates to the link.

   - `http(s)://<DMAIP>/VideoThumbnails/Video.htm?`: the internal webpage hosted by the DataMiner Agent.

   - URL parameters: These define how the video thumbnail is displayed and played. Some parameters are mandatory (for example, `type=` to indicate the video type and `source=` to specify the video or image source), while others are optional (for example, `loop=` to play a video continuously). For a complete overview, see [Adding parameters to the video URL](xref:Adding_parameters_to_the_video_URL).

1. Save the Visio file.

## Configuring a video thumbnail in DataMiner Cube

Instead of using the Visio desktop app, you can also link a shape to a video thumbnail in DataMiner Cube itself. To do so:

1. Right-click the Visio drawing, and click *Edit Mode*.

1. Select the shape. If necessary, select the *Make All Shapes Selectable* option, and select the shape from the *Selected Shape* selection box.

1. In *Link Shape To*, select "Link".

1. In the *Basic* tab, set *Link Type* to "Video".

1. Choose a video type from the dropdown list.

1. Provide any required information based on the chosen video type. For example, if you choose `Generic Images` as video type, you will need to provide the image source URL and the refresh rate of the image (in milliseconds).

1. Click Save.
