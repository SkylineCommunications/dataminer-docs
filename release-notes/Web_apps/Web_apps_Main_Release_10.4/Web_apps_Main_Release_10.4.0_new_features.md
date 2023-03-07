---
uid: Web_apps_Main_Release_10.4.0_new_features
---

# DataMiner web apps Main Release 10.4.0 – New features – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Highlights

#### Dashboards app & Low-Code Apps: Icon component [ID_34867]

<!-- MR 10.4.0 - FR 10.3.1 -->

The new icon component allows you to display an icon on a dashboard or a low-code app.

## Other new features

#### Dashboards app - GQI: New data sources [ID_34747] [ID_35027] [ID_34965] [ID_35058]

<!-- MR 10.4.0 - FR 10.3.3 -->

In the Generic Query Interface, the following new data sources are now available:

| Data source                   | Contents                                                   |
|-------------------------------|------------------------------------------------------------|
| Get trend data patterns       | All pattern matching tags created in the DataMiner System. |
| Get trend data pattern events | All pattern occurrences detected in the DataMiner System.  |
| Get behavioral change events  | All behavioral anomalies detected in the DataMiner System. |

The *Get trend data pattern events* and *Get behavioral change events* data sources contain time range metadata on each row. Each time range holds the start and end time of the event in question. When a table row is selected, the time range will be exposed as a feed.

#### Dashboards app & Low-Code Apps - GQI: 'Row by row' option [ID_35057] [ID_35565]

<!-- MR 10.4.0 - FR 10.3.3 -->

When configuring a Join operator, you can now select the *Row by row* option.

- When you do not select the *Row by row* option, the join will execute both the left and the right queries once, and directly combine their results (default behavior).

- When you select the *Row by row* option, the join will execute the left query first, and then execute the right query for each row  with a filter derived from the Join condition.

> [!NOTE]
>
> - The *Row by row* option will only be visible and configurable when you opened the dashboard or app with `showAdvancedSettings=true` added to the URL.
> - Currently, the *Row by row" option is only supported for inner and left joins. If you use it for an outer or right join, an exception will be thrown.

#### Monitoring app: Element name added to breadcrumbs of trend card [ID_35270]

<!-- MR 10.4.0 - FR 10.3.3 -->

As of now, the header of a trend card shows a breadcrumb trail with the element name of a parameter as a clickable item. Clicking this element name allows you to quickly navigate back to the element card.

#### GQI: 'State' column added to 'Get views' data source [ID_35333]

<!-- MR 10.4.0 - FR 10.3.3 -->

A `State` column has been added to the *Get views* data source. This column shows the alarm state of the view.

#### GQI: Multiple groupBy operations can now be applied after an aggregation operation [ID_35355]

<!-- MR 10.4.0 - FR 10.3.3 -->

After an aggregation operation, you can now apply multiple groupBy operations.

#### Dashboards app - GQI: New 'Get parameter relations' data source [ID_35443]

<!-- MR 10.4.0 - FR 10.3.3 -->

In the Generic Query Interface, the *Get parameter relations* data source is now available.

It can be used to retrieve the parameter relationships that are stored in a model managed by a DataMiner Extension Module named *ModelHost*.

> [!NOTE]
> This data source will only be available when *ModelHost* is running.

#### Dashboards app & Low-code apps: 'Lazy load components' setting [ID_35469] [ID_35486]

<!-- MR 10.4.0 - FR 10.3.4 -->

In the configuration settings of a dashboard or a page/panel of a low-code app, you can now find the *Lazy load components* setting.

When this settings is enabled, the components on the dashboard or the page/panel of the low-code app will only be initialized the first time they appear on the screen. This will considerably shorten the initial load time and enhance overall performance of large dashboards and large pages/panels of low-code apps.

> [!NOTE]
>
> - This setting, which is enabled by default for all new dashboards and all new pages/panels of low-code apps, is only available if you add the `showAdvancedSettings=true` option to the dashboard URL.
> - Even when this setting is enabled, components will not be lazy loaded in edit mode.

#### Monitoring app - Trending: Switching between trend graph and histogram [ID_35501]

<!-- MR 10.4.0 - FR 10.3.4 -->

When viewing a trend graph in the Monitoring app, you can now easily switch between trend graph and histogram by clicking either the trend graph or histogram icon in the top-right corner.

#### Monitoring app & Dashboards app - Line & area chart: Time range buttons [ID_35595]

<!-- MR 10.4.0 - FR 10.3.4 -->

A line & area chart component now has a number of time range buttons that allow you to quickly select one of the following preset time ranges:

- 1d (last 24 hours)
- 1w (last 7 days)
- 1m (last 30 days)
- 1y (last year)
- 5y (last 5 years)

> [!NOTE]
> In the *Dashboards* app, these time range buttons are disabled by default. When configuring the component, uou can enable them by selecting the *Show time range buttons* option in the *Component > Layout > Styling and Information* tab.

#### Web apps: New action 'Open monitoring card' [ID_35661]

<!-- MR 10.4.0 - FR 10.3.4 -->

In a low-code app, you can now configure a new type of action: *Open monitoring card*. When triggered, this action will open the card of a specific element, service or view in the *Monitoring* app.

> [!NOTE]
> When a low-code app is embedded in Cube (e.g. in a visual overview), an *Open monitoring card* action will open the specified card in Cube.
