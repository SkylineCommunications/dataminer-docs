---
uid: Specifying_data_input_in_a_URL
---

# Specifying data input in a dashboard or app URL

It is possible to specify data input for a dashboard using the dashboard URL. This way, you can immediately make the dashboard display specific data when it is opened. From DataMiner 10.2.0/10.2.2 onwards<!--RN 31833-->, you can pass the data using a [JSON object](#json-syntax) in the URL. Prior to DataMiner 10.2.0/10.2.2, you can use the [legacy syntax](#legacy-syntax), which continues to be supported in recent DataMiner versions for now.

From DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4 onwards<!--RN 42031-->, low-code apps also support specifying data input in an app URL, using either the JSON syntax or the legacy syntax. Prior to this, the low-code app URL can only be used to set a component's default value, for example to select a default element in a dropdown.

> [!NOTE]
>
> - From DataMiner 10.2.0/10.2.2 onwards<!--RN 31833-->, when a dashboard updates its own URL, it will use a compressed JSON syntax. In this compressed syntax, the query parameter `d` is used instead of `data`.
> - To only display a dashboard without the rest of the app, add the argument "*embed=true*". To display the *Clear all* button for an embedded dashboard, add "*subheader=true*" as well. For example: `https://[DMA IP]/dashboard/#/MyDashboards/dashboard.dmadb?embed=true&subheader=true`
> - The *showAdvancedSettings=true* URL option can be used with some components in order to make additional functionality available.
> - When data is selected in a component, the URL of a dashboard changes. However, unlike dashboards, low-code apps will not push data to the URL.

> [!IMPORTANT]
> To guarantee support across all browsers and prevent possible issues, the URL value should be encoded. If, for example, the JSON structure contains any ampersands ("&"), this will not work unencoded. See [URL-encoded equivalents](#url-encoded-equivalents).

## JSON syntax

You can pass the data using a JSON object in the URL:

``url?data=<URL-encoded JSON object>``

This JSON object has to have the following structure:

```json
{
"version": <version-number>,
"feedAndSelect": <data>, (optional)
"feed": <data>, (optional)
"select": <data>, (optional)
"components": <component-data>
}
```

> [!TIP]
> See [Example](#example).

- The version number is currently always 1.

- ``<data>`` is a JSON object with a number of property keys (corresponding with the [objects listed below](#supported-objects)) and property values (as an array of strings). For example:

  ```json
  {
  "parameters": ["1/2/3", "1/4/6"],
  "elements": ["1/2", "1/8", "212/123"]
  ...
  }
  ```

- When you provide data in the (optional) *feedAndSelect* item, that data will be interpreted as if it was passed using the [legacy syntax](#legacy-syntax) described below.

- When you provide data in the (optional) *feed* item, that data will only be used in the URL feed. It will not be used to select items in selection boxes on the dashboard or app page.

  > [!NOTE]
  > The (optional) *feed* item is currently only available for passing data input in a dashboard URL.

- When you provide data in the (optional) *select* item, that data will only be used to select items in selection boxes on the dashboard or app page. It will not be used in the URL feed.

- In the *components* item, you can provide data to be selected in specific components referred to by their ID. ``<component-data>`` is an array of objects containing the component ID and the data that should be passed to the component:

  ```json
  {
  "cid": <component-id>,
  "select": <data>
  }
  ```

  > [!NOTE]
  > You can find the ID of each component in the lower right corner of the component while in edit mode. However, if a custom configuration name has been set for the component, the ID will not be displayed. To view the ID, go to the *Layout* pane and temporarily clear the configuration name.

### URL-encoded equivalents

To guarantee support across all browsers and prevent possible issues, the URL value should be encoded.

| character | URL-encoded equivalent |
|--|--|
| " | %22 |
| : | %3A |
| , | %2C |
| [ | %5B |
| ] | %5D |
| / | %2F |
| { | %7B |
| } | %7D |
| & | %26 |
| Space | %20 |

### Example

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

## Legacy syntax

> [!NOTE]
> To ensure backwards compatibility, this syntax continues to be supported in recent DataMiner versions for now. However, we recommend that you use the JSON syntax instead, as it allows more flexibility. In addition, at some point in the future, the legacy syntax may no longer be supported.

Prior to DataMiner 10.2.0/10.2.2, you can pass data to a dashboard using the following URL syntax:

``url?<datatype1>=<datakeys1>&<datatype2>=<datakeys2>&...``

In the syntax above, "datatype" is one of the objects mentioned below (e.g. "elements"), and "datakeys" is its identifier (e.g. the DMA ID and element ID).

Within one object, use a slash ("/") as the separator between its components. If different objects of the same type are specified, use "%1D" as the separator between the objects.

For example:

- ``https://myDma/Dashboard/#/myDashboard?elements=1/1%1D1/2&views=1&parameters=1/1/1%1D1/1/2/myIndex``

  This URL opens a dashboard in which the elements 1/1 and 1/2, view 1 and parameters 1/1/1 and 1/1/2/myIndex are selected by default.

- ``https://myDma/Dashboard/#/myDashboard?timespans=1549753200000/1549835265007``

  This URL opens a dashboard with a time range filter from 1549753200000 to 1549835265007.

## Supported objects

Within the dashboard or app URL, the following data objects can be specified:

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

- *timespans*: Requires the start and/or end time stamp. If you leave out the start time stamp, the time span will be interpreted as starting at midnight. If you leave out the end time stamp, the time span will be interpreted as ending at the current time.

  > [!NOTE]
  > From DataMiner 10.2.0/10.1.1 onwards, for a predefined time span in a time range component, the URL can contain the name of that time span (e.g. today, yesterday, etc.) instead of the start time and end time of the time span.

- *bookings*: Requires the booking ID.

- *service definitions*: Requires the service definition ID.

- *cpes*: Deprecated from DataMiner 10.2.0 [CU1] and 10.2.4 onwards (but still supported for the sake of backwards compatibility). To specify an EPM filter. Requires the DMA ID, the element ID, the field PID, the field value, the table index PID, and the index value.

- *epm-selections*: Available from DataMiner 10.2.0 [CU1] and 10.2.4 onwards (replaces "cpes")<!-- RN 32594 -->. To specify an EPM filter. Requires the DMA ID, element ID, field PID and primary key value, separated by forward slashes. Unlike the deprecated "cpes", "epm-selections" allows forward slashes in the primary key value.

- *strings*: Supported from DataMiner 10.3.5/10.4.0 onwards<!--  RN 35902 -->. A text string, which will serve as the default value for a **text input** component. Note that prior to DataMiner 10.4.1<!-- RN 37752 -->, you can only specify a default value for all text input components, while in recent DataMiner versions you can specify data per component.

- *numbers*: Supported from DataMiner 10.3.5/10.4.0 onwards<!--  RN 35911 -->. Numbers, which will serve as the default value for a **numeric input** component. Note that prior to DataMiner 10.4.1<!-- RN 37752 -->, you can only specify a default value for all numeric input components, while in recent DataMiner versions you can specify data per component.

- *object manager definitions*: Supported from DataMiner 10.3.6/10.4.0 onwards<!-- RN 36124 -->. Allows referencing a specific DOM definition. Use the following format: `object manager definitions=[Module]/[Definition]`.

  - `[Module]`: the [DOM module name](xref:DOM_ModuleId).

  - `[Definition]`: the [DOM definition guid.](xref:DomDefinition).

  For example: `?object manager definitions=Jobs/7a58af57-58d6-4027-8b55-40d5ba97c368`

- *object manager instances*: Supported from DataMiner 10.3.6/10.4.0 onwards<!-- RN 36124 -->. Allows referencing a specific DOM instance. Use the following format: `object manager instances=[Module]/[Instance]`.

  - `[Module]`: the [DOM module name](xref:DOM_ModuleId).

  - `[Instance]`: the [DOM instance guid.](xref:DomInstance).

  For example: `?object manager instances=Jobs/e91fe0cf-51e8-40f1-add4-f4752561890b`

- *object manager modules*: Supported from DataMiner 10.3.6/10.4.0 onwards<!-- RN 36124 -->. Allows referencing a specific DOM module. Use the following format: `object manager modules=[Module]`.

  - `[Module]`: the [DOM module name](xref:DOM_ModuleId).

  For example: `?object manager modules=Jobs`

- *queries*: Allows referencing a query in the dashboard or app URL. Use the following format: `?queries=[alias]\x1F[queryJsonString]`.

  - `[alias]`: the name of the query.

  - `[queryJsonString]`: the query in the format of a JSON string.

  For example: `?queries=Get Elements/{"ID": "Elements"}`

- *query columns*: Supported from DataMiner 10.3.9/10.4.0 onwards. A GQI query filter, structured as follows: `query columns=[query ID]%1e[column ID]%1e[filter type]%1e[filter values]`. The following filter types are supported: *list*, *range*, *boolean*, *number*, and *string*.

  For example:

  - To treat the values of column *239db862-31bf-4905-a08b-3656b499b160_State* of query *8f149a38-7a53-4baa-b0fc-9bdedbe80c87* as a list in which the *Hidden* and *Stopped* options are selected:

    `?query columns=8f149a38-7a53-4baa-b0fc-9bdedbe80c87%1e239db862-31bf-4905-a08b-3656b499b160_State%1elist%1eHidden%1fStopped`

  - To treat the values of column *23ea428c-d52c-4041-8fd9-76ce3f436a6d_Number* of query *3af9e5a7-91fc-4333-94c0-e39a59f0d900* as a range from 5 to 10, with 5 included but 10 not included:

    `?query columns=3af9e5a7-91fc-4333-94c0-e39a59f0d900%1e23ea428c-d52c-4041-8fd9-76ce3f436a6d_Number%1erange%1e5%1f10%1ffalse%1ftrue`

- *query rows*: Supported from DataMiner 10.3.0 [CU12]/10.4.3 onwards<!-- RN 39369 -->.  An array of query rows.

  Each table must be in the following format: `VERSION\u001FCOLUMNS\u001ECELLS\u001EKEYS`.

  - *VERSION*: A parameter with the data version, currently always `v:1`.

  - *COLUMNS*: A list of the column ID, name, and client type (*string*, *number*, *guid*, *boolean* or *date*) of each column. As the separator between the items for each column, use `\u000E`. As the separator between the columns, use `\u001F`.

  - *CELLS*: A list of rows, each consisting of cells represented in the format `VALUE\u000EDISPLAYVALUE`. As the separator between the cells, use `\u000E`. As the separator between the rows, use `\u001F`.

  - *KEYS*: A list of the keys of the rows, separated by `\u001F`. This key is unique for the row.

  For example, to add a query row with two columns to the URL, of which the first column, *ID*, contains string values, and the second column, *Value*, contains numbers:

  `v:1\u001FIDColumn\u000EID\u000Estring\u001FValueColumn\u000EValue\u000Enumber\u001Evalue1\u000EValue 1\u001F5\u000EFive\u001ERowKey`

- *booleans*: Supported from DataMiner 10.4.0 [CU12]/10.5.3 onwards<!--RN 41845-->. Used to specify whether a boolean value is set to "true" or "false" when the dashboard or app is loaded.
