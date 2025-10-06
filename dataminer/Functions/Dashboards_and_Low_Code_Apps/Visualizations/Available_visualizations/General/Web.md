---
uid: DashboardWeb
---

# Web

This component displays a webpage or a block of static HTML. It can also be used to display a [video thumbnail](#configuring-a-video-thumbnail).

![Web](~/dataminer/images/Web_Component.png)<br>*Web component in DataMiner 10.4.5*

## Configuration options

### Web component layout

In the *Layout* pane, only the default options are available for this component. See [Customizing the component layout](xref:Customize_Component_Layout).

### Web component settings

In the *Settings* pane for this component, you can customize its behavior to suit your requirements.

| Section | Option | Description |
|--|--|--|
| General | Type | Choose whether you want to configure the component as a webpage or as a block of HTML by selecting *Webpage* or *Custom HTML* respectively. |
| General | HTML | Only available if *Type* is set to *Custom HTML*. Enter the HTML code. |
| General | URL | Only available if *Type* is set to *Webpage*. Enter the URL of the webpage. |
| Security | Open in sandbox | Available from DataMiner 10.4.0 [CU19]/10.5.0 [CU7]/10.5.10 onwards<!-- RN 43584 -->, if *Type* is set to *Webpage*. Toggle the switch to enable or disable sandboxing for the webpage. If the URL points to a file in the DMA's *Webpages/public/* folder (or one of its subfolders) and sandboxing is not required, you can disable this option. Only disable it if absolutely necessary, as doing so lowers browser security. |

> [!NOTE]
>
> - From DataMiner 10.3.0 [CU14]/10.4.0 [CU2]/10.4.5 onwards<!--RN 38993-->, you can link this component to data by [dynamically referencing data](xref:Dynamically_Referencing_Data_in_Text) in the URL. However, note that the URL is limited to 2,000 characters and the HTML code to 100,000 characters. HTML highlighting is disabled from 15,000 characters onwards.
> - From DataMiner 10.3.0 [CU14]/10.4.0 [CU2]/10.4.5 onwards<!--RN 38993-->, if the component is configured as a webpage, you can use the `<DMAIP>` placeholder to insert the current hostname and port in the URL.
> - This component does not allow the use of scripts, buttons, or other input controls.

## Configuring a video thumbnail

You can make a web component display a video stream based on an image URL.

To do so, configure the URL similar to the value of the *Link* shape data field when you [configure a video thumbnail in Visual Overview](xref:Linking_a_shape_to_a_video_thumbnail).

> [!TIP]
> You can also display a YouTube livestream or other online video by using its embed link. To do so, open the video on the streaming platform, select *Share* > *Embed*, and copy the URL from the `src` property of the embed code. For example: `https://www.youtube.com/embed/0FBiyFpV__g?si=WUgPIJUk2s_Wzfy8`.
>
> ![Embed link](~/dataminer/images/Web_component_embed_video.png)
