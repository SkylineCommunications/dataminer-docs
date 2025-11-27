---
uid: About_Video_Thumbnails
---

# About video thumbnails

A video thumbnail is a built-in DataMiner feature that allows you to display a video feed or regularly refreshed image [in a Visio shape in Visual Overview](xref:Configuring_a_video_thumbnail_in_Visio) and [in a web component](xref:Configuring_a_video_thumbnail_in_a_web_component) in Dashboards and Low-Code Apps.

The thumbnail is displayed by a dedicated internal webpage hosted by the DataMiner Agent:

```txt
http(s)://<DMA>/VideoThumbnails/Video.htm?VideoServerParameters
```

The `VideoServerParameters` determine the type of feed, source URL, optional authentication, and rendering behavior. You can use placeholders to build dynamic URLs.

> [!TIP]

Both Visual Overview and the web component embed this webpage: Visual Overview through the *Link* shape data field, and the web component through its *URL* setting. For detailed instructions, see:

- [Configuring a video thumbnail for Visual Overview](xref:Configuring_a_video_thumbnail_in_Visio)

- [Configuring a video thumbnail in a web component](xref:Configuring_a_video_thumbnail_in_a_web_component)
