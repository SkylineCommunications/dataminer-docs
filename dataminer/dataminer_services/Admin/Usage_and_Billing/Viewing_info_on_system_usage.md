---
uid: Viewing_info_on_system_usage
keywords: cloud usage
reviewer: Alexander Verkest
---

# Viewing information on system usage

In the Admin app, you can view information about the usage of certain DataMiner features in your organization and the number of DataMiner credits that correspond with this usage. This does not take into account any subscriptions or other benefits you may have.

Currently, only usage data for Storage as a Service (STaaS) are displayed, i.e., the number of ingest operations per data type. In the future, more information will become available here.

> [!TIP]
> For more information about the metering and conversion rates, see [Metering](xref:Pricing_Usage_based_service#metering-units).

To view your usage:

1. In the [Admin app](xref:Accessing_the_Admin_app), check whether the correct organization is mentioned in the header bar.

1. If a different organization should be selected, click the organization selector ![Organization selector](~/dataminer/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

1. In the pane on the left, under *Organization*, select *Usage*.

   This will open the page with usage information.

   If the selected organization does not use any of the features for which usage reporting is currently supported, you will see a message stating that there is no data to display.

1. Optionally, filter the displayed information by month or select one or more DataMiner Systems to view the total usage for the selected systems.

   Note that filtering by month is always available, even if there is no usage for this period.

> [!NOTE]
> It is possible to export the usage data to CSV, with the *Export usage* button at the top of the *Usage* page.<!-- RN 41117 -->
