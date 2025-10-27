---
uid: How_to_NevionVideoIPath_App
---

# Using the Nevion Video IPath app

To access the application:

1. Go to `http(s)://[DMA name]/root`.

1. Select *Nevion Video IPath* to start using the application.

   ![Nevion Video IPath](~/dataminer/images/NevionAppLogo.png)

## The Nevion Video IPath interface

The sidebar on the left of the Nevion Video IPath application contains two buttons:

| Button | Page description |
|:--:|--|
| ![Connect](~/dataminer/images/Nevion_Connect.png) | Opens the [*Connect* page](#connect-page), which displays profiles, sources, and destinations. The connection between a source and a destination establishes a service. |
| ![Services](~/dataminer/images/Nevion_Services.png) | Opens the [*Services* page](#services-page), which provides an overview of all available services. |

## Connect page

The *Connect* page allows you to establish a connection between sources and destinations.

![Overview page](~/dataminer/images/Nevion_OverviewPage.png)

To establish a connection:

1. Select a specific **profile** to see compatible sources and destinations.

   These profiles correspond to logical, predefined sets of configurations that apply to specific types of connections.

1. Select a **source and destination** to connect.

   Nevion allows you to use tags to categorize, filter, and organize sources (inputs) and destinations (outputs).

1. Click **Connect** to link the source and destination.

   Alternatively, you can also use the **Schedule** button, which allows you to perform the connect operation with a specific start and end time.

   The *Last Connection Status* will show whether the connection was successful.

   Once a source and destination have been connected, you can disconnect them again with the **Disconnect** button.

## Services page

The *Services* page provides an overview of the services in the system, which correspond to established connections between sources and destinations. With the X button for each service in the overview, you can quickly delete a service.

![Overview page](~/dataminer/images/Nevion_ServicesPage.png)

> [!NOTE]
> Hover the mouse pointer over the table to access easy filtering.
>
> ![Easy filtering](~/dataminer/images/Nevion_ServicesHover.png)
