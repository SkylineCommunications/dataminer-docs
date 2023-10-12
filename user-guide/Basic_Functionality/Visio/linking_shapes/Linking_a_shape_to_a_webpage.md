---
uid: Linking_a_shape_to_a_webpage
---

# Linking a shape to a webpage

Using a shape data field of type **Link**, you can link a shape to a webpage.

When you link a shape to a webpage, that page will be opened each time a user clicks that shape.

> [!TIP]
> For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[linking > WEB]* page.

## Configuring the shape data field

Add a shape data field of type **Link** to the shape, and set its value to:

```txt
http://URL||Tooltip
```

Default tooltip: *Link to 'http://URL'*

> [!NOTE]
>
> - Both HTTP and HTTPS are supported.
> - If you put a "#" sign in front of the URL, the webpage will be displayed inside the shape.
> - Links starting with "mailto:" are not supported in the DataMiner web apps prior to DataMiner 10.2.0/10.1.8.

## Options for shapes linked to a webpage

The following options can be configured for shapes linked to a webpage.

### BorderVisibility

By default, webpages displayed inside a shape do not have a border. If you want embedded webpages to have a border, then add a shape data field of type **Options** to the shape containing the web browser control, and set its value to "BorderVisibility=true".

### DisposeWebBrowserWhenNotSelectedPage

By default, DataMiner Cube disposes of embedded web browser controls when you change pages in a Visio drawing.

To override this default behavior, add a shape data field of type **Options** to the shape containing the web browser control, and set its value to "DisposeWebBrowserWhenNotSelectedPage=false". As a result, the web browser control will only be disposed of when you close the card.

### EnableZoom

From DataMiner version 9.0 onwards, by default, if a Visual Overview page contains an embedded webpage, zooming in and out on the page is not possible.

To override this default behavior, add a shape data field of type **Options** to the page and set its value to "EnableZoom".

### NavigationUIVisibility

By default, webpages displayed inside a shape do not have a Back and Forward button. If you want embedded webpages to have a Back and Forward button, then add a shape data field of type **Options** to the shape containing the web browser control, and set its value to "NavigationUIVisibility=true".

### RefreshButtonVisibility

By default, webpages displayed inside a shape do not display a refresh button. If you want to add a refresh button to an embedded browser, add a shape data field of type **Options** to the shape containing the web browser control, and set its value to "RefreshButtonVisibility=true".

> [!NOTE]
> To force refresh the page (i.e. clear the cache), click the refresh button while pressing CTRL.

### SingleSignOn

To always pass an authentication ticket to the embedded webpage, regardless of the content of the URL, add a shape data field of type **Options** to the shape containing the web browser control, and set its value to "SingleSignOn". (Available from DataMiner 9.5.6 onwards.)

Even if this option is not specified, by default an authentication ticket is passed to embedded applications of type .xbap, embedded DataMiner Maps, the embedded Ticketing app, embedded dashboards (created in the new Dashboards app), and the embedded [DataMiner Comparison tool](xref:DataMinerComparisonTool).

### UseChrome

From DataMiner 9.6.3 onwards, if you want to make sure the webpage is displayed using the Chromium web browser regardless of the default browser settings in Cube, add a shape data field of type **Options** to the shape containing the web browser control, and set its value to "UseChrome".

### UseIE

From DataMiner 10.0.10 onwards, by default Chromium is used to display webpages embedded in DataMiner Cube. To use the deprecated Internet Explorer browser instead, add a shape data field of type **Options** to the shape containing the web browser control, and set its value to "UseIE". Note that this is **not recommended**.

### UseEdge

From DataMiner 10.1.11/10.2.0 onwards, you can use Microsoft Edge (WebView2) to display an embedded webpage in DataMiner Cube. To do so, add a shape data field of type **Options** to the shape containing the web browser control, and set its value to "UseEdge".

> [!NOTE]
>
> - The WebView2 Runtime is automatically installed with Office 365 Apps and/or Windows 11. It is not included in DataMiner upgrade packages.
> - This browser engine has the advantage that web content is rendered directly to the graphics card and proprietary codecs such as H.264 and AAC are supported. In addition, the browser engine automatically receives updates via Windows Update, regardless of the DataMiner or Cube version.
> - From DataMiner 10.3.4/10.4.0 onwards, interactions between DataMiner web apps and Cube (e.g. a web app opening an element card in Cube) now also work when those web apps are embedded in Microsoft Edge (WebView2). Prior to DataMiner 10.3.4/10.4.0, this functionality is already supported when [Chromium](#usechrome) is used to display web apps. <!-- RN 35655 -->

### UseLoginCredentials

If you want to pass on the user credentials of the current user to a webpage displayed inside a shape, then add a shape data field of type **Options** to the shape containing the web browser control, and set its value to "UseLoginCredentials".

> [!NOTE]
> This feature only works when you have logged on to DataMiner Cube explicitly using Basic Authentication (i.e. with a username and a password). It will not work when you have logged on with your Windows user credentials.

## Allowing pop-ups

In DataMiner Cube, embedded browser windows suppress pop-ups by default. If, for any reason, you want an embedded browser window to allow pop-ups (e.g. when it has to show an authentication dialog), then you can use the following URL suffix (in upper case):

```txt
#SL_ALLOW_POPUPS#
```

Examples:

```txt
http://localhost/foo/#SL_ALLOW_POPUPS#
http://localhost/foo/index.html#SL_ALLOW_POPUPS#
http://localhost/foo/test.php?id=123&action=save#SL_ALLOW_POPUPS#
```

## Special placeholders that can be used within a URL

| Placeholder | Description |
| ----------- | ----------- |
| \<ElementID> | Element ID |
| \<ElementIP> | Polling IP address of the element |
| \<ElementName> | Name of the element |
| \<DataMinerID> | DataMiner ID |
| \<DMAIP> | The certificate address, hostname or IP address of the DataMiner Agent to which the user is connected. See [\<DMAIP>](xref:Placeholders_for_variables_in_shape_data_values#dmaip). |
| \<PageFilter> | Value of the drop-down filter box in the top-right corner of the Visio drawing. See [Specifying an EPM parameter that can be used to filter](xref:Specifying_an_EPM_parameter_that_can_be_used_to_filter). |

> [!NOTE]
>
> - \<ElementID>, \<ElementIP> and \<ElementName> are only to be used if the shape is also linked to an element.
> - From DataMiner version 9.0.5 onwards, these placeholders can also be used inside another placeholder in the URL, e.g. `#http://www.skyline.be?MyParam=[param:<elementname>,1]`
> - Prior to DataMiner 10.3.6/10.4.0, adding a URL fragment to a linked webpage causes the connection info to be automatically added after the fragment, rendering the URL invalid and requiring a reload of the page, which means the user may need to log in again. From DataMiner 10.3.6/10.4.0 onwards, Visual Overview can recognize if a URL fragment is added or changed and update only the necessary parts of the page, avoiding the need to recreate the browser instance. <!-- RN 36044 + 36104 -->

## Configuring a link to a DataMiner object within a webpage embedded in Visual Overview

Within a webpage displayed in Visual Overview via a shape data field of type **Link**, you can create a link that will allow the user to navigate to a particular DataMiner element or view. From DataMiner 10.2.9/10.3.0 onwards, you can also create a link to an EPM object based on its system name and system type.

To do so, use the following configuration in the webpage:

- For a link to a view:

  ```xml
  <a href='javascript:window.external.NavigateViewByName("My View Name");'>
    My link description
  </a>
  ```

- For a link to an element:

  ```xml
  <a href='javascript:window.external.NavigateElementByName("My Element Name");'>
    My link description
  </a>
  ```

- For a link to an EPM object:

  ```xml
  <a href='javascript:window.external.NavigateCPEByName("[system type]", "[system name]");'>
    My link description
  </a>
  ```

  For example:

  ```xml
  <a href='javascript:window.external.NavigateCPEByName("Region","California");'>Open Region California</a>
  ```

## Examples

```txt
http://www.skyline.be
```

Clicking the shape will cause the specified webpage to open in a new internet browser window (or tab).

```txt
#http://www.skyline.be
```

Clicking the shape will have no effect. However, the specified webpage will be displayed inside the shape.

```txt
#http://[Property:MySpecialProperty]
```

This example is identical to the one above. The only difference is that the URL will be retrieved from the "MySpecialProperty" property of the element or service to which the shape is linked.

```txt
http://<DMAIP>
```

Clicking the shape will cause the default client application of the DMA to open in a new internet browser window (or tab).
