---
uid: Grafana_plugin
---

# Grafana Data Source plugin

The Grafana Data Source plugin allows you to visualize data from DataMiner in [Grafana](https://grafana.com/), instead of for example in the [Dashboards app](xref:newR_D).

> [!NOTE]
> The Grafana Labs Marks are trademarked by Grafana Labs and are used with Grafana Labs’ permission. We are not affiliated with, endorsed by, or sponsored by Grafana Labs or its affiliates.

> [!CAUTION]
> The Grafana Data Source plugin is still in the alpha stage, which entails that everything is subject to change. Backwards compatibility is not guaranteed. All changes made with this version may need to be redone once the plugin is effectively released.

## Prerequisites

- DataMiner version 10.2.9 or higher.

- Grafana version 9.2.5 or higher. Grafana Cloud is not supported.

- Grafana should be able to connect to a DataMiner Agent over HTTPS.

## Installation

1. Find your Grafana configuration file.

   > [!TIP]
   > For more information on where to find the Grafana configuration file, see [Configuration file location](https://grafana.com/docs/grafana/latest/setup-grafana/configure-grafana/#configuration-file-location).

1. Open the configuration file and set `allow_loading_unsigned_plugins` to the ID of our plugin:

    ```ini
    [plugins]
    # Enter a comma-separated list of plugin identifiers to identify plugins to load even if they are unsigned. Plugins with modified signatures are never loaded.
    allow_loading_unsigned_plugins = skylinecommunications-dataminer-datasource
    ```

1. Save the configuration file.

1. Download the [latest version of the Data Source plugin](https://github.com/SkylineCommunications/dataminer-grafana-plugin/releases). This will be a ZIP file.

1. Extract the entire ZIP file to the *plugins* folder of Grafana:

   - **Windows**: `C:\Program Files\GrafanaLabs\grafana\data\plugins`

   - **Linux**: `/var/lib/grafana/plugins`

   - **macOS**: `/usr/local/var/lib/grafana/plugins`

1. Restart the Grafana service.

1. Open Grafana and go to *Configuration > Plugins*.

1. Click *DataMiner* and select *Create a DataMiner data source*.

1. Configure the connection with your DataMiner Agent:

   - *User*: Specify the username and password that Grafana should use to authenticate on the DMA. These credentials will only provide access to data inside DataMiner as configured in the DataMiner security.

   - *HTTP*: Specify the URL to connect to your DataMiner Agent, for example `https://mydma.company.com`.

     > [!CAUTION]
     > Use a secure HTTPS connection. Without an HTTPS connection, your username and password will be sent over the network/internet unencrypted, which means that they may be visible to others.
     > For more information on how to configure your DataMiner System to use HTTPS, see [Setting up HTTPS on a DMA](xref:Setting_up_HTTPS_on_a_DMA).

   - Other configuration settings can be ignored.

1. Click *Save & test*. A *Success* message should be displayed.

## Features

### Generic Query Interface (GQI)

A GQI query should be specified in JSON format. To get a correctly configured query, you can make use of the [DataMiner Dashboards app](xref:newR_D):

1. In the Dashboards app, create a dashboard and create a query.

   > [!TIP]
   >
   > - See [Creating and configuring dashboards](xref:Creating_and_configuring_dashboards).
   > - See [Creating a GQI query](xref:Creating_GQI_query)

1. Visualize this query on the dashboard.

1. Press F12 to open the developer tools and go to the *Network* tab.

1. Press F5 to refresh the dashboard.

1. In the *Name* column of the *Network* tab, select the *OpenQuerySession* network call.

1. Go to the *Payload* subtab, right-click *query:* and select *Copy value* to save the JSON code to your clipboard.

1. Open Grafana and navigate to the panel you want to add the GQI query to.

1. Paste the previously copied JSON code in the *Query* section that is using the DataMiner data source, as configured during [installation](#installation).

#### Time range filter

Your GQI query can contain one or more *datetime* filters. To apply the *time range* filter from Grafana, you can manually edit the filter condition of the GQI query by replacing the numeric timestamp value with one of the following placeholders: `[gf-starttime]` and `[gf-endtime]`.

Example:

``` JSON
{
    "ID": "Value",
    "Value": {
        "Value": [gf-starttime],
        "Type": "datetime",
        "__type": "Skyline.DataMiner.Web.Common.v1.DMAPrimitiveValue"
    },
    "Type": "datetime",
    "__type": "Skyline.DataMiner.Web.Common.v1.DMAGenericInterfaceQueryChosenOption"
}
```

#### Transformations

After configuring a query in Grafana, you may have to add a transformation to some GQI results. This could be the case when you have a GQI query that gets the latitude and longitude from element properties.

Since properties in DataMiner are strings, you will need to add a [*Convert field type* transformation](https://grafana.com/docs/grafana/latest/panels-visualizations/query-transform-data/transform-data/#convert-field-type) to convert the latitude and longitude values to numbers before you can display them on a map visualization.

> [!TIP]
> For more instructions on how to add a transformation, see [Add a transformation function to data](https://grafana.com/docs/grafana/latest/panels-visualizations/query-transform-data/transform-data/#add-a-transformation-function-to-data).

#### Annotations

You can use data from a GQI result to annotate the data on your dashboard. This can be configured in the settings of your Grafana dashboard.

> [!TIP]
> For more information about annotations, see [Annotate visualizations](https://grafana.com/docs/grafana/latest/dashboards/build-dashboards/annotate-visualizations/).

### Trend data

To get the trend data of a parameter, do the following:

1. In Grafana, navigate to the panel you want to extract trend data from.

1. Go to the *Query* section that is using the DataMiner data source and click *Trend*.

1. Specify the parameter using the following format: `dmaID/elementID/parameterID` or `dmaID/elementID/tableColumnParameterID/tableRowIndex`.

This way you request the trend data from within the time range specified on the dashboard. If the time range amounts to less than 48 hours, 5-minute interval points will be returned instead of the usual 60-minute interval points.

> [!NOTE]
> Only numeric average trending is supported. The Grafana Data Source plugin currently does not support real-time trending, discrete values, or exception values.
