---
uid: Using_dashboard_feeds
---

# Component data sources

Many components in dashboards and low-code apps can be configured to be linked to a component data source, so that their content can be dynamically adjusted by the users.

To have components updated based on a component data source, you can add one of the compatible components to the dashboard or low-code app:

- [Time range](xref:DashboardTimeRange)

- [List](xref:DashboardList)

- [Tree](xref:DashboardTree)

- [Parameter picker](xref:DashboardParameterPicker)

- [EPM picker](xref:DashboardEPMPicker)

- [Query filter](xref:DashboardQueryFilter)

- [Trigger](xref:DashboardTrigger)

After adding one of the components above to the dashboard or app, a new component data source can be found in the *Components* section of the *Data* tab. Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41141-->, you can find these data sources under *Feeds* in the *Data* tab.

Data input for such a component can then be selected by the user. Alternatively, you can also [specify data input for a feed in a dashboard URL](xref:Specifying_data_input_in_a_dashboard_URL).

You can [configure feed components](xref:Configuring_feed_components) by adding the desired feed components and using them as data feeds. In instances where you want to link a component to data in the URL without using any feed components, you can configure a dashboard to [use data in a URL without a dedicated component](xref:Using_data_in_URL_without_dedicated_component). Additionally, you can [incorporate dynamic references to feed values within text](xref:Feed_Link).

> [!IMPORTANT]
> For more information on configuring query (GQI) data feeds, see [Creating a GQI query](xref:Creating_GQI_query).
