---
uid: Specifying_data_input_in_a_dashboard_URL
---

# Specifying data input in a dashboard URL

If a dashboard has been configured with one or more feed components, it is possible to specify data input for these feeds in a dashboard URL. This way, you can immediately make the dashboard display specific data when it is opened.

> [!NOTE]
> From DataMiner 10.2.0/10.2.2 onwards, when a dashboard updates its own URL, it will use a compressed JSON syntax. In this compressed syntax, the query parameter “d” is used instead of “data”.

## JSON syntax

From DataMiner 10.2.0/10.2.2 onwards, you can pass the data using a JSON object in the URL:

``url?data=<URL-encoded JSON object>``

This JSON object has to have the following structure:

```json
{
"version": 1,
"feedAndSelect": <data>, (optional)
"feed": <data>, (optional)
"select": <data>, (optional)
"components": <component-data>
}
```

- ``<data>`` is a JSON object with a number of property keys (corresponding with the objects listed below) and property values (as an array of strings). For example:

  ```json
  {
  "parameters": ["1/2/3", "1/4/6"],
  "elements": ["1/2", "1/8", "212/123"]
  ...
  }
  ```

- When you provide data in the (optional) *feedAndSelect* item, that data will be interpreted as if it was passed using the legacy syntax described below.

- When you provide data in the (optional) *feed* item, that data will only be used in the URL feed. It will not be used to select items in selection boxes on the dashboard.

- When you provide data in the (optional) *select* item, that data will only be used to select items in selection boxes on the dashboard. It will not be used in the URL feed.

- In the *components* item, you can provide data to be selected in specific components referred to by their ID. ``<component-data>`` is an array consisting of the component ID and the data that should be passed to the component:

  ```json
  {
  "cid": <component-id>,
  "select": <data>
  }
  ```

  > [!NOTE]
  > You can find the ID of each component in the lower right corner of the component while in edit mode.

## Legacy syntax

Prior to DataMiner 10.2.0/10.2.2, you can pass data to a dashboard using the following URL syntax:

``url?<datatype1>=<datakeys1>&<datatype2>=<datakeys2>&...``

In the syntax above, "datatype" is one of the objects mentioned below (e.g. elements), and "datakeys" is its identifier (e.g. the DMA ID and element ID).

Within one object, use a slash (“/”) as the separator between its components. If different objects of the same type are specified, use “%1D” as the separator between the objects.

For example:

- ``http://myDma/Dashboard/#/myDashboard?elements=1/1%1D1/2&views=1&parameters=1/1/1%1D1/1/2/myIndex``

  This URL opens a dashboard in which the elements 1/1 and 1/2, view 1 and parameters 1/1/1 and 1/1/2/myIndex are selected by default.

- ``http://myDma/Dashboard/#/myDashboard?time%20spans=1549753200000/1549835265007``

  This URL opens a dashboard with a time range filter from 1549753200000 to 1549835265007.

> [!NOTE]
> - This syntax continues to be supported in recent DataMiner versions.
> - Additional URL options are possible from DataMiner 10.0.2 onwards. To only display a dashboard, without the rest of the app, add the argument “*embed=true*”. To display the *Clear all* button for an embedded dashboard, add “*subheader=true*” as well. For example: *http://**\[DMA IP\]**/dashboard/#/MyDashboards/dashboard.dmadb?embed=true&subheader=true*
> - The *showAdvancedSettings=true* URL option can be used with some components in order to make additional functionality available.

## Supported objects

Within the dashboard URL, the following objects can be specified:

- *elements*: Requires the DMA ID and element ID.

- *services*: Requires the DMA ID and service ID.

- *redundancy groups*: Requires the DMA ID and redundancy group ID.

- *parameters*:

  - By protocol: Requires the protocol name, protocol version and protocol ID.

  - By element: Requires the DMA ID, the element ID, the parameter ID, and optionally the parameter index.

- *views*: Requires the view ID.

- *slas*: To specify SLAs. Requires the DMA ID and element ID.

- *agents*: To specify DataMiner Agents. Requires the DMA ID.

- *protocols*: Requires the protocol name and protocol version.

- *protocol pages*: To specify Data Display pages by protocol. Requires the protocol name, protocol version, and page name.

- *parameter pages*: To specify Data Display pages by element. Requires the DMA ID, the element ID, and the page name.

- *indices*: Requires the index.

- *time spans*: Requires the start and/or end time stamp. If you leave out the start time stamp, the time span will be interpreted as starting at midnight. If you leave out the end time stamp, the time span will be interpreted as ending at the current time.

  > [!NOTE]
  > From DataMiner 10.2.0/10.1.1 onwards, for a predefined time span in a time range component, the URL can contain the name of that time span (e.g. today, yesterday, etc.) instead of the start time and end time of the time span.

- *bookings*: Requires the booking ID. Supported from DataMiner 10.0.3 onwards.

- *service definitions*: Requires the service definition ID. Supported from DataMiner 10.0.5 onwards.

- *cpes*: To specify an EPM filter. Requires the DMA ID, the element ID, the field PID, the field value, the table index PID, and the index value. Prior to DataMiner 10.0.5, the DMA ID, the element ID, the field PID, the table PID, and the value are required.
