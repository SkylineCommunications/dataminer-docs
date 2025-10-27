---
uid: URL_data
---

# URL data

You can link a component to data in the URL without relying on specific components in the dashboard or app.

To link a component to URL data:

1. Select the component you want to link to a URL.

1. Access the URL data:

   - From DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12 onwards<!--RN 41141-->: In the *Data* pane, go to *URL*.

   - Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12: In the *Data* pane, go to *Feeds* > *URL*.

1. Locate the URL data you want to use:

   - *Data* category: Only available in the Dashboards app. This category includes various URL categories such as *Booking*, *Object manager definition*, *EPM selection*, *Element*, *Number*, etc. Prior to DataMiner 10.4.0 [CU11]/10.5.2<!--RN 41561-->, these categories can be found directly underneath *URL* in the *Data* pane.

   - *DMAIP* data object: Available from DataMiner 10.4.0 [CU11]/10.5.2 onwards<!--RN 41561-->. This data object allows you to pass the hostname and the IP port from the URL to a component.

     For example:

     | URL | DMAIP value |
     |--|--|
     | `https://myaddress.skyline.local/dashboard/#/db/SLC/QA%20tables.dmadb` | myaddress.skyline.local |
     | `https://localhost:4200/#/db/SLC/QA%20tables.dmadb` | localhost:4200 |

1. Drag the URL data to the component.

> [!NOTE]
> When the dashboard has a specific component that contains the same data as the URL, that data will overwrite the data from the URL.
