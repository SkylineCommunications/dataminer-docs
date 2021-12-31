## Embedding a dashboard component in a webpage or Visio drawing

From DataMiner 10.0.8 onwards, you can embed individual components in a Visio drawing or a web page.

To do so:

1. In the Dashboards app, open the dashboard that contains the component you want to embed.

2. Click the *Start editing* button in the top-right corner.

3. Right-click the component and select *Copy embed URL*.

4. Use the URL of the component in either a Visio page (see [Linking a shape to a dashboard component](../../part_2/visio/Linking_a_shape_to_a_dashboard_component.md)) or a web page (e.g. in an \<img> tag).

    A component URL has the following syntax:

    ```txt
    http://<DMA>/embed?component=<SERIALIZED-COMPONENT>
    ```

    > [!NOTE]
    > -  “SERIALIZED-COMPONENT” is a serialized representation of the component in JSON format.
    > -  If the component contains data, that data will automatically be included into the URL. See [Configuring a dashboard to use a URL feed without a feed component](Configuring_a_dashboard_to_use_a_URL_feed_without_a_feed_component.md).
    >
