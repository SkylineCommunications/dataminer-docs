---
uid: Controlling_cloudfeed_data_offloads
keywords: offloading to the cloud
reviewer: Alexander Verkest
---

# Controlling performance and usage data offloads with the Admin app

When a DMS is connected to dataminer.services, it will start offloading alarm and change point events to dataminer.services. This data can then be used to improve DataMiner AI/Analytics features.

Performance and usage data offloads can be controlled both on organization level and on DMS level. If performance and usage data offloads are disabled for an organization, these are automatically also disabled for all DataMiner Systems within that organization.

## Controlling the performance and usage data offload setting of your organization

If you have the Owner or Admin role on dataminer.services for an organization, you can enable or disable performance and usage data offloads.

1. In the [Admin app](xref:Accessing_the_Admin_app), check whether the correct organization is mentioned in the header bar.

1. If a different organization should be selected, click the organization selector ![Organization selector](~/dataminer/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

1. In the sidebar on the left, under *Organization*, select the *Settings* page.

1. Toggle the *Performance and usage data offloads* setting to *On* or *Off*, depending on whether you want this to be allowed or disabled for all the DataMiner Systems in this organization.

> [!NOTE]
>
> - If a setting is disabled on organization level, it will not be possible to enable it for the DataMiner Systems in this organization.
> - When you change a setting from *On* to *Off*, it can take a minute before the change is applied.

## Controlling the performance and usage data offload setting of a DMS in your organization

If you have the Owner or Admin role on dataminer.services for a DMS, you can enable or disable performance and usage data offloads.

1. In the [Admin app](xref:Accessing_the_Admin_app), check whether the correct organization is mentioned in the header bar.

1. If a different organization should be selected, click the organization selector ![Organization selector](~/dataminer/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

1. In the pane on the left, under *DataMiner Systems*, expand the DataMiner System, and select the *Settings* page.

1. Toggle the *Performance and usage data offloads* setting to *On* or *Off*, depending on whether you want this to be enabled or not.

> [!NOTE]
>
> - If a setting is disabled on organization level, it will not be possible to enable it for a DataMiner System in that organization.
> - When you change a setting from *On* to *Off*, it can take a minute before the change is applied.
