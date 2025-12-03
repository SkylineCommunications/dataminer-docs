---
uid: dataminer_services_home_page
keywords: cloud home page
reviewer: Alexander Verkest
---

# The dataminer.services home page

To access the dataminer.services home page:

- Go directly to the link <https://dataminer.services> and [log on](xref:Logging_on_to_dataminer_services), or

- In DataMiner Cube, go to the System Center > *Cloud* page and select *Open dataminer.services* (Available from DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38715-->).

<div style="width: 100%; max-width: 800px;">
  <video style="width: 100%; aspect-ratio: 16 / 9; height: auto;" controls>
    <source src="~/dataminer/images/dataminer.services-home-page.mp4" type="video/mp4">
  </video>
</div>

## dataminer.services apps

At the top of the dataminer.services home page, you will find links to the different available dataminer.services apps:

- [Collaboration](xref:About_the_Collaboration_app)

- [Catalog](xref:About_the_Catalog_app)

- [Sharing](xref:About_the_Sharing_app)

- [Community](xref:Community)

- [Admin](xref:About_the_Admin_app)

> [!TIP]
> Both on the dataminer.services home page and in many of the dataminer.services apps, you can provide direct feedback to Skyline via the *Feedback* option in the user menu.<!-- RN 41926 -->
>
> ![Feedback option](~/dataminer/images/Cloud_feedback.png)

## DataMiner Cube installation button

You can install DataMiner Cube from the dataminer.services home page. To do so, click the *Desktop installation* button in the top-right corner.

> [!TIP]
> See also: [Installing DataMiner Cube](xref:Installing_the_DataMiner_Cube_desktop_application)

## System overview

Below the apps overview, the home page lists the DataMiner Systems within your organization that have been [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

For each of the DataMiner Systems, the URLs are displayed that can be used for [remote access](xref:About_Remote_Access).

Here you can also [link your dataminer.services and DataMiner account](xref:Linking_your_DataMiner_and_dataminer_services_account).

### Connection states

In the system overview, you can see the state of the connection between your system and the dataminer.services platform. Next to the name of each DMS, an icon indicates the connection state:

- **DMS is connected to dataminer.services**

  It is possible to access the system and all dataminer.services features are available. This is indicated by a green icon and a green bar next to the DMS information.

  ![Connection status ok](~/dataminer/images/DMS_status_overview_ok.png)

- **DMS is connected to dataminer.services but not online**

  The DMS is connected to dataminer.services but the DMS itself is not running. This is indicated by an orange icon and an orange bar next to the DMS information. You also get an indication of the last point in time when the system was detected as online.

  ![DMS offline](~/dataminer/images/DMS_status_overview_dms_offline.png)

- **DMS has no connection to dataminer.services**

  The DMS is not connected to dataminer.services. This is indicated by a red colored icon with a line through it and a red bar next to the DMS information. You also get an indication of the last point in time when the system was detected as connected.

  ![No connection](~/dataminer/images/DMS_status_overview_no_connection.png)

- **Something is wrong in the cloud**

  If an error in dataminer.services makes it impossible to determine the status of the connection, a warning is displayed.

  ![Problem in dataminer.services](~/dataminer/images/DMS_status_overview_cloud_error.png)
