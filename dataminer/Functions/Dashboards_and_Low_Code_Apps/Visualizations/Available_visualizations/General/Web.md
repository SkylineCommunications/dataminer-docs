---
uid: DashboardWeb
---

# Web

The web component is a versatile visualization that allows you to embed external content directly into your dashboards and low-code apps. It can display webpages, custom HTML content, or serve as a **video thumbnail** for streaming content.

![Web](~/dataminer/images/Web_Component.png)<br>*Web component in DataMiner 10.4.5*

With this component, you can:

- **Display external webpages** by embedding any accessible URL directly into your dashboard or app.

- **Render custom HTML** content to create tailored visual elements and layouts.

- **Show video thumbnails** and livestreams from various sources.

- **Integrate third-party content** seamlessly into your DataMiner environment while maintaining security controls.

- **Dynamically reference data** in URLs to create context-aware web content that updates based on feeds.

These capabilities make the web component ideal for integrating external resources and creating rich, interactive dashboards.

## Supported content types

The web component supports two main types of content:

- **Webpages**: Display any accessible webpage by providing its URL. The component will render the page content within an embedded frame.

- **Custom HTML**: Render HTML content directly in the component, for example to add a custom layout or styling.

> [!NOTE]
> From DataMiner 10.3.0 [CU14]/10.4.0 [CU2]/10.4.5 onwards<!--RN 38993-->, you can [dynamically reference data](xref:Dynamically_Referencing_Data_in_Text) in URLs to create data-driven web content. The URL is limited to 2,000 characters and HTML code to 100,000 characters.

## Embedding video content

### Configuring a video thumbnail

You can configure the web component to display a video stream based on an image URL. To do so, configure the URL similar to the value of the *Link* shape data field when you [configure a video thumbnail in Visual Overview](xref:Linking_a_shape_to_a_video_thumbnail).

### Embedding online video streams

You can display YouTube livestreams or other online videos by using their embed links:

1. Open the video on the streaming platform.
1. Select *Share* > *Embed*.
1. Copy the URL from the `src` property of the embed code.
1. Use this URL in the web component configuration.

**Example**: `https://www.youtube.com/embed/0FBiyFpV__g?si=WUgPIJUk2s_Wzfy8`

![Embed link](~/dataminer/images/Web_component_embed_video.png)

## Embedding local content

When you need to embed local resources (files hosted on your DataMiner Agent) in the web component, there are important considerations for ensuring accessibility and proper functionality.

### Guidelines for local resources

There are two key things to keep in mind when referencing local resources:

- **Public folder requirement**: Local resources are not accessible over dataminer.services unless they are in the DMA's `C:\Skyline DataMiner\Webpages\public` folder. All other local resources are blocked for security reasons. Note that all resources in this folder are accessible to all users.

- **Relative URL usage**: Your URL should be a relative URL, so that for both local and remote access (which use different URLs), the resource can be accessed consistently.

### Best practices

- **Store files in the public directory**: Place your local HTML files, images, and other resources in the DMA's `C:\Skyline DataMiner\Webpages\public` folder or its subfolders to ensure that they are accessible both locally and via dataminer.services.

- **Use relative paths**: Instead of absolute URLs, use relative paths like `./folder/file.html` or `../resources/page.html` to ensure compatibility across different access methods.

- **Consider sandboxing**: When referencing local resources in the `public` folder, you can disable sandboxing in the component settings if absolutely necessary, but only do so when required, as it reduces browser security.

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
> - **Dynamic data referencing**: From DataMiner 10.3.0 [CU14]/10.4.0 [CU2]/10.4.5 onwards<!--RN 38993-->, you can [dynamically reference data](xref:Dynamically_Referencing_Data_in_Text) in URLs to create data-driven web content. The URL is limited to 2,000 characters and HTML code to 100,000 characters. HTML highlighting is disabled from 15,000 characters onwards.
> - **DMAIP placeholder**: From DataMiner 10.3.0 [CU14]/10.4.0 [CU2]/10.4.5 onwards<!--RN 38993-->, if the component is configured as a webpage, you can use the `<DMAIP>` placeholder to insert the current hostname and port in the URL.
> - **Security restrictions**: This component does not allow the use of scripts, buttons, or other input controls for security purposes.
