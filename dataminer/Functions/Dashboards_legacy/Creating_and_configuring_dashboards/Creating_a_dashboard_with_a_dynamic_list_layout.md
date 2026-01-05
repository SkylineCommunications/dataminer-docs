---
uid: Creating_a_dashboard_with_a_dynamic_list_layout
---

# Creating a dashboard with a dynamic list layout

> [!IMPORTANT]
> This information is applicable to the DMS Dashboards module, which is being retired as of DataMiner version 10.4.x. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement). We recommend using the [Dashboards app](xref:newR_D) instead.

If you configure a dashboard to have a dynamic list layout, the components added to the *List Item Template* zone will be repeated.

To create a dashboard with dynamic list layout:

1. Go to *Actions \> Feeds* to access the Feeds editor.

1. Create or select a feed in the Dynamic List Feed field. For more information, see [Feeds](xref:Configuring_dashboard_components1#feeds).

1. Go to *Actions \> Settings* to set the Dynamic List Options:

    - Under *List Type*, specify whether the list has to iterate over dynamic table rows, elements, parameters, redundancy groups or services. Different options will be available depending on your choice. See [List type options](#list-type-options).

    - Specify a *Minimal Alarm Level* to include only items that have at least the specified alarm state.

    - Use the *Mask* field to specify a mask to filter the displayed items. E.g. only elements that start with *MAIN\_\**

        > [!NOTE]
        > You can also use regular expressions in the mask field, if the mask starts with #.

    - In the *Appearance* dropdown list, you can select different options to display grid lines or an alternating background color.

    - Enter a value under *Rows Per Page* to limit the maximum number of rows displayed on one page to that value.

    - Enter a value under *Row Grouping* to group multiple rows into one single row. This can be of use when rows are relatively small.

1. Go to *Actions \> Configure Components* to add components. All components added to the *List Item Template* zone are immediately configured to use the Dynamic List Feed you configured earlier. For more information about adding components, see [Configure Components](xref:Configuring_dashboard_components1#configure-components).

## List type options

Depending on the list type you choose when configuring the *Dynamic List Options*, there are different configuration options.

### Dynamic Table Rows

When you choose this list type, each row in the dynamic list will represent a row of a dynamic table.

A dynamic list feed must be configured with "Parameter" as fixed selection, with a dynamic table parameter selected. The display key has to be empty. Components added to the "Dynamic List" layout of the dashboard will only be able to link to a column parameter of the selected dynamic table.

> [!NOTE]
>
> - You can use the *Mask* option on the *Settings* page to limit the included parameters to part of a table.
> - Unless the list is paginated, new rows will automatically appear in the dashboard when new rows are added to the table.

### Elements

When you choose this list type, each row in the dynamic list will represent an element that corresponds to the dynamic list feed.

The following options can be configured for this list type:

- Active Elements Only: if selected, only active elements will be included

- Spectrum Elements Only: if selected, only spectrum elements will be included

- Business Intelligence Only: if selected, only SLA elements will be included

### Parameters

When you choose this list type, each row in the dynamic list will represent a parameter that corresponds to the dynamic list feed. Dynamic table parameters are included in the list.

The following options can be configured for this list type:

- Monitored Parameters Only: if selected, only monitored parameters will be included

- Analog Parameters Only: if selected, only analog parameters will be included

- Discreet Parameters Only: if selected, only discreet parameters will be included

- Average Trended Parameters Only: if selected, only parameters with average trending enabled will be included

### Redundancy groups

When you choose this list type, each row in the dynamic list will represent a redundancy group that corresponds to the dynamic list feed. There are no additional options specific to this list type.

### Services

When you choose this list type, each row in the dynamic list will represent a service that corresponds to the dynamic list feed.

Select the option *Measurement Point Services Only* to include only measurement point services.
