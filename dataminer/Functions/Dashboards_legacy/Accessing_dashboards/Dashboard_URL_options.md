---
uid: Dashboard_URL_options
---

# Dashboard URL options

> [!IMPORTANT]
> This information is applicable to the DMS Dashboards module, which is being retired as of DataMiner version 10.4.x. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement). We recommend using the [Dashboards app](xref:newR_D) instead.

When you go directly to a dashboard in a browser using a dashboard URL, you can add options to the dashboard URL to change the way the dashboard is displayed or to determine the dashboard feed. These options are simply added after the URL, and some options can also be combined.

## UI options

The following options apply to the way the user interface is represented.

| URL option             | Description                                                                                                                                                                                                                                              |
|------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ?border=true/false     | Shows or hides a border around the dashboard. If the border is hidden, no scrollbars will be shown.                                                                                                                                                      |
| ?chrome=true/false     | Shows or hides the header, the navigation controls and the edit panel. As such, this option combines the *?header*, *?navigation* and *?edit* options into one setting. |
| ?header=true/false     | Shows or hides the header.                                                                                                                                                                                                                               |
| ?edit=true/false       | Shows or hides the edit panel.                                                                                                                                                                                                                           |
| ?mini=true/false       | Shows or hides the header, the navigation controls and the edit panel. As such, this option combines the *?header*, *?navigation* and *?edit* options into one setting. |
| ?navigation=true/false | Shows or hides the navigation controls.                                                                                                                                                                                                                  |
| ?w=...&h=...           | Specifies a fixed dashboard size (in pixels). If you do not specify this option or if you specify incorrect values, the default width and height of 800x600px will be used.                                                                              |

> [!NOTE]
> Most of these settings are saved in your browser session, and will be applied to all dashboard pages to which you navigate during that session. This does not apply for the option *?mini=true/false*.

## Feed selection options

The following options determine what feed is used for the dashboard.

| URL option     | Description                                                                                                                                     |
|----------------|-------------------------------------------------------------------------------------------------------------------------------------------------|
| ?element=...   | Passes an element to a dashboard. See [?element=...](#element)*.*               |
| ?parameter=... | Passes a parameter to a dashboard. See [?parameter=...](#parameter)*.*          |
| ?selection=... | Passes a selection of feeds to a dashboard. See [?selection=...](#selection)*.* |
| ?service=...   | Passes a service to a dashboard. See [?service=...](#service)*.*                |

> [!NOTE]
> In a dashboard where a user must select a feed, the feed selection panel contains a "Permanent link". Right-click *Permanent link* and select *Copy shortcut* in order to copy the full dashboard URL for the current selection.

### ?element=...

You can pass an element to a dashboard by means of the following option:

```txt
?element=DmaID/ElementID
?element=ElementName
```

The specified element will then be used to fill out feeds automatically.

When you use this option, the following action will occur:

- For feeds that require an ELEMENT, an attempt will be made to automatically link these feeds to the selected element. To do this, additional conditions can be specified by selecting a fixed protocol in the feed and/or by specifying an element mask in the advanced feed options.

### ?parameter=...

You can pass a parameter to a dashboard by means of the following option:

```txt
?parameter=DmaID/ElementID/ParameterID/Index
```

The specified element will then be used to fill out feeds automatically, and to replace *\[this row\]* placeholders.

When you use this option, the following actions will occur:

- For feeds that require an ELEMENT, an attempt will be made to automatically link these feeds to the selected element. To do this, additional conditions can be specified by selecting a fixed protocol in the feed and/or by specifying an element mask in the advanced feed options.

- For feeds that require a PARAMETER, an attempt will be made to automatically link these to the selected parameter. To do this, additional conditions can be specified by selecting a fixed protocol or element.

- For components that take a parameter with a table index, the table index field can contain a *\[this row\]* placeholder, which will be replaced by the table row index as specified in the URL.

### ?selection=...

You can pass an entire feed selection to a dashboard by means of the *?selection* option.

Format:

```txt
?selection=feedselection1@feedid1@feedselection2@feedid2
```

Examples:

```txt
?selection=element|7|123
?selection=element|7|123@abcdefdhsdgjkhsdjgh@service|7|45@dfsdgsghzerughuzegh
?selection=element|7|123!parameter|100!idx|abc
```

In one *?selection* option, you can specify selections for multiple feeds using the following syntax:

```txt
selection1!selection2!selection3
```

When you specify only one selection without feed ID, the default feed is chosen by looking at all the feeds and selecting the first one for which client selection is required.

> [!NOTE]
>
> - For more examples, open a dashboard and click *Feeds* > *Permanent link*.
> - Feed IDs are GUIDs. To find a list of all feed IDs used in a particular dashboard, open the *dashboard.config* file of that dashboard, and look for IDs like the following: "\<feed id="93098909-cda2-4f50-b936-f6ef7c0dcb97" ...>".

List of selection types (each with their own syntax):

```txt
alarm|dmaid|id
custom|key|value
dma|dmaid
element|dmaid|eid
elementname|name
idx|idx
parameter|pid
parameter|name
protocol|name|version
redundancy|dmaid|rid
redundancyname|name
service|dmaid|sid
servicename|name
view|id
viewname|name
```

> [!NOTE]
>
> - In case of *elementname\|name*, the element name can contain wildcards, e.g., "elementname\|\*-MODEM\*". When an additional *?service* parameter is specified in the URL, the element will be searched for within the specified service using the name mask.
> - *idx\|idx* refers to a row index of a dynamic table.
> - If you specify strings containing "!" or "\|" characters, you can encode them as "!!" and "\|\|".

### ?service=...

You can pass a service to a dashboard by means of the following option:

```txt
?service=DmaID/ServiceID
?service=ServiceName
```

The selected service will then be used to fill out feeds automatically, and to replace *\[this service\]* placeholders.

When you use this option, the following actions will occur:

- For feeds that require an ELEMENT, an attempt will be made to automatically link these feeds to elements taken from the service. To do this, additional conditions can be specified by selecting a fixed protocol in the feed and/or by specifying an element mask in the advanced feed options.

- For feeds that require a SERVICE, the selected service will be linked to the feed.

- For components that take a parameter with a table index, the table index field can contain a *\[this service\]* placeholder, which will be replaced by the service name.

- For components that link to a linked dashboard (state LEDs), a custom specification of the linked dashboard title can contain a *\[this service\]* placeholder, which will also be replaced by the service name.

    > [!NOTE]
    > For a service state led, the *\[this service\]* placeholder in the linked dashboard title will be replaced by the name of the service for which the LED is displayed.

## Other options

The following options are mainly for internal use or for debugging purposes.

| URL option     | Description                                                                                                                                                                                                                                                                                             |
|----------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ?noRender=true | When specified, rendering of component contents will be skipped. Use this option to solve problems in cases where the dashboard cannot be opened and you need to get into the dashboard edit mode.                                                                                                      |
| ?prefetch=true | When specified, this will cause the aspx page to be compiled and loaded, without requesting any actual data. This option is used by SLNet when prefetching dashboard pages.                                                                                                                             |
| ?skipIWA=true  | When specified, Internal Windows Authentication will be skipped. Use this option when, for some reason, it is impossible to log on using a Windows account. When this option is specified, a user who is not logged on will be presented a web page with a logon form (instead of a windows logon box). |
