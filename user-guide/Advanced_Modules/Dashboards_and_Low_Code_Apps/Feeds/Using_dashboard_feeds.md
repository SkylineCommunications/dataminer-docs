---
uid: Component_Data_Sources
---

# Component data sources

> [!NOTE]
> Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41141-->, component data sources are called feeds instead.

Many components in dashboards and low-code apps can be configured to be linked to a component data source, so that their content can be dynamically adjusted by the users.

To have components updated based on a component data source, you can add one of the compatible components to the dashboard or low-code app:

- [Time range](xref:DashboardTimeRange)

- [List](xref:DashboardList)

- [Tree](xref:DashboardTree)

- [Parameter picker](xref:DashboardParameterPicker)

- [EPM picker](xref:DashboardEPMPicker)

- [Query filter](xref:DashboardQueryFilter)

- [Trigger](xref:DashboardTrigger)

After adding one of the components above to the dashboard or app, a new component data source can be found in the *Components* section of the *Data* tab, which can then be selected. Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41141-->, you can find these data sources under *Feeds* in the *Data* tab. Alternatively, you can also [specify data input for a feed in a dashboard URL](xref:Specifying_data_input_in_a_dashboard_URL).

You can [configure feed components](xref:Configuring_feed_components) by adding the desired components and using them as data sources. You can also [link a component to data in the URL without using any dedicated components](xref:Using_data_in_URL_without_dedicated_component). Additionally, you can [incorporate dynamic references to data values within text](xref:Dynamically_Referencing_Data_in_Text).

> [!IMPORTANT]
> For more information on configuring query (GQI) data sources, see [Creating a GQI query](xref:Creating_GQI_query).
