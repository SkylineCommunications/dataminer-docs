---
uid: Specifying_data_input_in_URL
---

# Specifying data input in an app URL

From DataMiner 10.2.11/10.3.0 onwards, you can specify default data for a low-code app via URL parameters. This way, you can for instance specify the elements, parameters, views, etc. that need to be selected in the app.

## Syntax

You can pass the data using a JSON object in the URL:

`url?data=<URL-encoded JSON object>`

This JSON object has to have the following structure:

```json
{
   "version": <version-number>,
   "components": <component-data>
}
```

- The version number is currently always 1.

- The component data is an array of component input objects, configured as follows:

  ```json
  {
   "cid": <component-id>,
   "select": <data>
  }
  ```

- For an overview of the supported data objects, refer to the [Supported objects](xref:Specifying_data_input_in_a_dashboard_URL#supported-objects) for dashboard URLs.

> [!IMPORTANT]
> To guarantee support across all browsers and prevent possible issues, the URL value should be encoded. If, for example, the JSON structure contains any ampersands ("&"), this will not work unencoded.

## Example

The following example URL selects one default element on the initial page. The component ID is "1", and the element ID is "1/6"

```url
https://<dma>/<app-id>?data={"version":1,"components":[{"cid":1,"select":{"elements":["1/6"]}]}}
```

> [!NOTE]
> For the example above, this is the encoded equivalent: `https://<dma>/<app-id>?data=%7B%22v%22:1,%22components%22:%5B%7B%22cid%22:1,%22select%22:%7B%22elements%22:%5B%221%2F6%22%5D%7D%5D%7D%7D`
