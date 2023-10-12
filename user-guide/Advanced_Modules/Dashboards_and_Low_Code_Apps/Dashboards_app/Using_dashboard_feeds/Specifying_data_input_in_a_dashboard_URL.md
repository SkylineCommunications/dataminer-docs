---
uid: Specifying_data_input_in_a_dashboard_URL
---

# Specifying data input in a dashboard URL

If a dashboard has been configured with one or more feed components, it is possible to specify data input for these feeds in a dashboard URL. This way, you can immediately make the dashboard display specific data when it is opened.

> [!NOTE]
>
> - From DataMiner 10.2.0/10.2.2 onwards, when a dashboard updates its own URL, it will use a compressed JSON syntax. In this compressed syntax, the query parameter “d” is used instead of “data”.
> - To refer to a query in the dashboard URL, use the following format: *?queries=\[***alias***\]\\x1F\[***queryJsonString***\]*. In this format, \[alias\] is the name of the query and \[queryJsonString\] is the query in the format of a JSON string, for example: *?queries=Get Elements/{"ID": "Elements"}*.
> - From DataMiner 10.0.2 onwards, to only display a dashboard without the rest of the app, add the argument “*embed=true*”. To display the *Clear all* button for an embedded dashboard, add “*subheader=true*” as well. For example: *https://**\[DMA IP\]**/dashboard/#/MyDashboards/dashboard.dmadb?embed=true&subheader=true*
> - The *showAdvancedSettings=true* URL option can be used with some components in order to make additional functionality available.

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

> [!TIP]
> See [Example of passing the data using a JSON object in the URL](#example-passing-the-data-using-a-json-object-in-the-url)

- ``<data>`` is a JSON object with a number of property keys (corresponding with the [objects listed below](#supported-objects)) and property values (as an array of strings). For example:

  ```json
  {
  "parameters": ["1/2/3", "1/4/6"],
  "elements": ["1/2", "1/8", "212/123"]
  ...
  }
  ```

- When you provide data in the (optional) *feedAndSelect* item, that data will be interpreted as if it was passed using the [legacy syntax](#legacy-syntax) described below.

- When you provide data in the (optional) *feed* item, that data will only be used in the URL feed. It will not be used to select items in selection boxes on the dashboard.

- When you provide data in the (optional) *select* item, that data will only be used to select items in selection boxes on the dashboard. It will not be used in the URL feed.

- In the *components* item, you can provide data to be selected in specific components referred to by their ID. ``<component-data>`` is an array of objects containing the component ID and the data that should be passed to the component:

  ```json
  {
  "cid": <component-id>,
  "select": <data>
  }
  ```

  > [!NOTE]
  > You can find the ID of each component in the lower right corner of the component while in edit mode.

### Example: passing the data using a JSON object in the URL

With the following JSON object, three different elements ("1/2","1/8", and "212/123") and two parameters ("1/2/3" and "1/4/6") will be selected for the component with ID 123:

```json
{
"version": 1,
"components": [
    {
      "cid": 123,
      "select": {
          "elements": [
              "1/2",
              "1/8",
              "212/123"
          ],
          "parameters": [
              "1/2/3",
              "1/4/6"
          ]
      }
    }
  ]
}
```

This JSON object adheres to the required structure specified in [JSON syntax](#json-syntax).

To pass this JSON object as part of a URL, it needs to be URL-encoded.

`https://[DMA IP]/dashboard/#/MyDashboards/dashboard.dmadb?data=%7B%22version%22%3A1%2C%22components%22%3A%5B%7B%22cid%22%3A123%2C%22select%22%3A%7B%22elements%22%3A%5B%221%2F2%22%2C%221%2F8%22%2C%22212%2F123%22%5D%2C%22parameters%22%3A%5B%221%2F2%2F3%22%2C%221%2F4%2F6%22%5D%7D%7D%5D%7D`

> [!NOTE]
>
> - " is encoded as %22.
> - : is encoded as %3A.
> - , is encoded as %2C.
> - [ is encoded as %5B.
> - ] is encoded as %5D.
> - / is encoded as %2F.

## Legacy syntax

> [!NOTE]
> To ensure backwards compatibility, this syntax continues to be supported in recent DataMiner versions for now. However, we recommend that you use the JSON syntax instead, as it allows more flexibility. In addition, at some point in the future, the legacy syntax may no longer be supported.

Prior to DataMiner 10.2.0/10.2.2, you can pass data to a dashboard using the following URL syntax:

``url?<datatype1>=<datakeys1>&<datatype2>=<datakeys2>&...``

In the syntax above, "datatype" is one of the objects mentioned below (e.g. "elements"), and "datakeys" is its identifier (e.g. the DMA ID and element ID).

Within one object, use a slash (“/”) as the separator between its components. If different objects of the same type are specified, use “%1D” as the separator between the objects.

For example:

- ``https://myDma/Dashboard/#/myDashboard?elements=1/1%1D1/2&views=1&parameters=1/1/1%1D1/1/2/myIndex``

  This URL opens a dashboard in which the elements 1/1 and 1/2, view 1 and parameters 1/1/1 and 1/1/2/myIndex are selected by default.

- ``https://myDma/Dashboard/#/myDashboard?time%20spans=1549753200000/1549835265007``

  This URL opens a dashboard with a time range filter from 1549753200000 to 1549835265007.

## Supported objects

Within the dashboard URL, the following data objects can be specified:

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

- *cpes*: Deprecated from DataMiner 10.2.0 [CU1] and 10.2.4 onwards (but still supported for the sake of backwards compatibility). To specify an EPM filter. Requires the DMA ID, the element ID, the field PID, the field value, the table index PID, and the index value. Prior to DataMiner 10.0.5, the DMA ID, the element ID, the field PID, the table PID, and the value are required.

- *epm-selections*: Available from DataMiner 10.2.0 [CU1] and 10.2.4 onwards (replaces "cpes")<!-- RN 32594 -->. To specify an EPM filter. Requires the DMA ID, element ID, field PID and primary key value, separated by forward slashes. Unlike the deprecated "cpes", "epm-selections" allows forward slashes in the primary key value.

- *strings*: Supported from DataMiner 10.3.5/10.4.0 onwards<!--  RN 35902 -->. A text string, which will serve as the default value for a Text input component.

- *numbers*: Supported from DataMiner 10.3.5/10.4.0 onwards<!--  RN 35911 -->. Numbers, which will serve as the default value for a Numeric input component.

- *object manager definitions*: Supported from DataMiner 10.3.6/10.4.0 onwards<!-- RN 36124 -->. Requires the [DOM definition ID](xref:DomDefinition).

- *object manager instances*: Supported from DataMiner 10.3.6/10.4.0 onwards<!-- RN 36124 -->. Requires the [DOM instance ID](xref:DomInstance).

- *object manager modules*: Supported from DataMiner 10.3.6/10.4.0 onwards<!-- RN 36124 -->. Requires the [DOM module ID](xref:DOM_ModuleId).
