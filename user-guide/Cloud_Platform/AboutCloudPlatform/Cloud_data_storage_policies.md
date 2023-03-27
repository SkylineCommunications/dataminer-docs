---
uid: Cloud_data_storage_policies
---

# Cloud data storage policies

## Stored data

When a DataMiner Agent is connected to dataminer.services, the following data is stored in the cloud:

- **Alarm and change point events**: This data is used to improve DataMiner Analytics features. You can disable these data offloads using the [Admin app](xref:Controlling_cloudfeed_data_offloads).
- **System Performance Indicators (SPIs)**: These performance measurements are used exclusively to provide technical support and support our services.
- **Information related to shared dashboards**: When a dashboard is shared, no data of the dashboard itself is stored in the cloud. However, the information on who shared the dashboard and whom they shared it with is shared in the cloud, as well as information on when a shared dashboard is opened and by whom.
- **Information related to the Teams bot**: No operational data from a DMS is stored in the cloud. However, we do store the state of the conversations with the bot.
- **Information related to the catalog**: Information is stored on which user deployed which catalog item to a DMS.
- **Information about installed DxMs**: Information is stored about the installed DxM versions, i.e. which versions are installed on specific nodes in a DMS.
- **Security information**: Information is stored on which users belong to which organization and which users have access to each DMS of the organization.

## Data storage location

For dataminer.services, servers from around the world are used. The data used to provide you with the various services may be processed on servers located outside the country where you live. Data protection laws can vary among countries, with some providing more protection than others. We apply the same protections regardless of where your data is processed.
