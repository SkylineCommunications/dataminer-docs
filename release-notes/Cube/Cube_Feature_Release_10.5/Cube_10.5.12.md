---
uid: Cube_Feature_Release_10.5.12
---

# DataMiner Cube Feature Release 10.5.12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.4.0 [CU21] and 10.5.0 [CU9].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.12](xref:General_Feature_Release_10.5.12).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.12](xref:Web_apps_Feature_Release_10.5.12).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Parameter cache enhancements will improve overall visual overview loading performance [ID 43457]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

In order to reduce the time it takes to load a visual overview, a number of enhancements have been made to the parameter cache.

Throughout the lifecycle of a Cube session, the parameter cache will request and maintain certain parameter tables, and will keeping them updated.When data is requested from any of the tables in question, the data will be fetched from the cache instead of the DataMiner Agent.

##### Using wildcards in table keys

From now on, when retrieving data from the parameter cache, you can use \* and ? wildcards in table keys (\* representing any number of characters and ? representing one character in the specified spot).

For example, if a table has a display key named `qaTable 500_x` with `x` being a sequence number, and you want to fetch the fifth row, you will now be able to use the following filter: `<A>-A|MyElement|Parameter:507,qaTable*5|=Active` A display key named e.g. *qaTable 500_5* will then match the key specified in that filter.

##### Caching only certain columns

When [configuring caching of specific table parameters](https://aka.dataminer.services/configuring_caching_of_specific_table_parameters), it is now possible to configure that you only want certain columns of a table to be cached.

See the example configuration below. When configuring a table to be cached, you can now optionally add `"ColumnIDs":`, followed by a comma-separated list of column IDs. If you do so, only the columns you specified will be cached.

```json
{
    "DataMinerID": 956,
    "ElementID": 1846,
    "ParameterID": 1500,
    "SubscriptionFilter": null,
    "ColumnIDs": "1512"
},
{
    "DataMinerID": 956,
    "ElementID": 1845,
    "ParameterID": 1000,
    "SubscriptionFilter": null
},
{
    "DataMinerID": 41,
    "ElementID": 53742,
    "ParameterID": 1000,
    "SubscriptionFilter": null
}
```

In a `"SubscriptionFilter"` item, you can also specify a `COLUMNS=` filter. If you do so, this setting will take priority over any `"ColumnIDs"` item.

- If you specify a `COLUMNS=` filter inside a `"SubscriptionFilter"` item, only requests that use that specific subscription filter will use the cache. In other words, only Visio shapes with the same subscription filter as the one that is specified in the configuration file will then use the cache for the columns in question.

- If you add a separate `"ColumnIDs"` item, any request that matches the other settings for the table in question will make use of the cache if the column that is requested is the same as the column that is cached.

> [!NOTE]
>
> - If you do not specify a `"ColumnIDs"` item, the entire table will be cached.
> - If the `"SubscriptionFilter"` item contains a `COLUMNS=` filter, any `"ColumnIDs"` item specified for the same table will be ignored.
> - In the configuration file, each table can only be configured once. It is not allowed to configure the same table multiple times with e.g. other columns.

##### Placeholders of type [param:] can now refer to columns instead of rows

Up to now, when you had to refer to a table parameter in a [param:] placeholder, it was only allowed to refer to a specific row using the following syntax:

`[param:DmaID/ElementID,ParameterID,TableRow]`

From now on, it will also be possible to refer to an entire column of a table parameter by using the following syntax:

`[param:DmaID/ElementID,ParameterID,ColumnID]`

#### Custom Alarm Console hyperlinks linked to Automation scripts will no longer be hidden in the right-click menu of certain alarms [ID 43809]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Up to now, custom hyperlinks linked to an Automation script would not be displayed in the right-click menu of an alarm of the type *Error* or *Notice* referring to the functionality of the DataMiner System or an alarm of type "Incident". From now on, these hyperlinks will be displayed.

Example of a custom hyperlinks linked to an Automation script:

```xml
<HyperLinks xmlns="http://www.skyline.be/config/hyperlinks">
    <!-- SECOND-GENERATION HYPERLINKS -->
    <HyperLink id="29"
        version="2"
        name="Send QA report by e-mail"
        menu="Scripts"
        type="script"
        alarmColumn="true">
    QA report by e-mail||||Tooltip|NoConfirmation
    </HyperLink>
</HyperLinks>
```

### Fixes

#### Trend graph showing high-value predictions would not get updated when you scrolled the predictions beyond the viewport [ID 43776]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

When you opened a trend graph showing trend data values with low Y values and predictions with very high Y values, up to now, the graph that resembled a flatline would incorrectly not get updated when you scrolled the predictions beyond the viewport.

#### Problem when switching themes while trend graphs were open [ID 43777]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

When, in DataMiner Cube, you opened a trend graph and then switched to another theme, up to now, errors would start to appear in the logging.

Also, the trend graph colors would incorrectly not get updated.

#### Problem when routing requests related to a swarmed element or an element migrated via a DELT package [ID 43815]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

In some cases, a request from DataMiner Cube related to a swarmed element or an element migrated via a DELT package would not get routed to the correct DataMiner Agent.

For example, when an element card showing a table with context menus was open while the element in question was swarmed to another DMA, after the swarming operation, it would no longer be possible to select items from those context menus.

Also, it would not be possible to rename swarmed elements or elements migrated via a DELT package from the element list on a view card.
