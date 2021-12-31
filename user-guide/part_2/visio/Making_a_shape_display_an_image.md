## Making a shape display an image

Using a shape data field of type **Link**, you can make a shape display an image located on a web server or a DMA.

The following image formats are supported: .png, .jpg, .bmp, and .emf.

> [!TIP]
> See also:
> [Linking a shape to a video thumbnail](Linking_a_shape_to_a_video_thumbnail.md)

### In DataMiner Cube

1. Right-click the Visio drawing, and click *Edit Mode*.

2. Select the shape. If necessary, select the *Make All Shapes Selectable* option, and select the shape from the *Selected Shape* selection box.

3. In *Link Shape To*, select “Link”.

4. In the *Basic* tab:

    1. Set *Link Type* to “Video”.

    2. Set *Video Type* to “Generic Images”.

    3. In *Image Source*, enter the URL of the image (e.g. “http://IpAddress/Folder/Picture.png”).

        > [!NOTE]
        > -  Both HTTP and HTTPS are supported.
        > -  If you want the shape to display an image on a DataMiner Agent, see [Displaying images located on a DataMiner Agent](#displaying-images-located-on-a-dataminer-agent).

    4. In *Refresh rate*, specify how frequently you want the image to be refreshed (in milliseconds).

5. Click Save.

### In Visio

1. Right-click the Visio drawing, and click *Edit In Visio*.

2. Add a shape data field of type **Link** to the shape, and set its value to e.g.:

    ```txt
    #http://DmaIpAddress/VideoThumbnails/Video.htm?type=Generic Images&source=http://IpAddress/Folder/Picture.png&refresh=5000
    ```

    > [!NOTE]
    > -  Both HTTP and HTTPS are supported.
    > -  If you want the shape to display an image on a DataMiner Agent, see [Displaying images located on a DataMiner Agent](#displaying-images-located-on-a-dataminer-agent).

3. Save the Visio file.

> [!NOTE]
> By default, a thumbnail of type *Generic Images* always uses the DMA as a proxy. However, from DataMiner 9.0.0 CU22/9.5.8 onwards, you can add an extra URL parameter, “proxy”, in order to override this behavior. For example: <br>*http://\<DMA IP>/VideoThumbnails/video.htm?type=Generic%20Images&source=\<IMG URL>&proxy=false*.

### Displaying images located on a DataMiner Agent

If you want a shape to display an image located on a DMA, then do the following:

1. Place the image in the DMA’s *C:\\Skyline DataMiner\\Webpages* folder (or one of its subfolders e.g. *C:\\Skyline DataMiner\\Webpages\\MyImages\\*).

2. In the shape, specify the URL of the image (e.g. “http://DmaIpAddress/MyImages/Picture.png”).

> [!NOTE]
> If you get an “Invalid path” error, open the file *C:\\Skyline DataMiner\\Webpages\\VideoThumbnails\\Web.config* (or *C:\\Skyline DataMiner\\Webpages\\VideoThumbnails\\Proxy\\Web.config* in DataMiner versions prior to 9.0), and check whether the image folder (e.g. */MyImages/*) has been added to the *ExtraAllowedPaths* key. See also [Allowed paths in case of connection via DataMiner proxy](Linking_a_shape_to_a_video_thumbnail.md#allowed-paths-in-case-of-connection-via-dataminer-proxy).
>
