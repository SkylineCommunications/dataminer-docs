---
uid: Working_with_Asset_Management
---

# Working with the Asset Management application

To access the Asset Management application:

1. Go to `http(s)://[DMA name]/root`.

1. Select *Asset Management* to start using the application.

   ![Asset Management](~/user-guide/images/Asset_Management_Icon.png)

> [!TIP]
> See also: [Use case: Asset Management](https://community.dataminer.services/use-case/asset-management/) on DataMiner Dojo

## The Asset Management application user interface

### The Asset Management application sidebar

The sidebar on the left of the Asset Management application contains buttons that can be used to access different pages:

- ![Asset overview](~/user-guide/images/Asset_Overview_Icon.png) : Clicking the *Asset overview* button displays an overview of all your assets. You can use the query filter to quickly locate specific items. The [*Asset overview* page](#the-asset-overview-page) serves as the initial landing page upon accessing the application.

- ![QR code](~/user-guide/images/QR_code_Icon.png) : Clicking the *QR code* button displays an overview of all URLs. This functionality lets you create all QR codes simultaneously, which you can then attach to the corresponding devices. See [The *QR code* tab](#the-qr-code-page).

- ![Complete assets overview](~/user-guide/images/Complete_Assets_Overview_Icon.png) : Clicking the *Complete assets overview* button displays an overview of all the assets where a bulk update option is available through a pre-designed Excel sheet on this page, ensuring a smooth start to your asset management journey. See [The *Complete assets overview* tab](#the-complete-assets-overview-tab).

- ![Alarm history overview](~/user-guide/images/Alarm_History_Overview_Icon.png) : Clicking the *Alarms* button displays an overview of all asset alarms monitored in your DataMiner System. See [The *Alarm history page* tab](#the-alarm-history-overview-tab).

- ![Asset detail report page](~/user-guide/images/Asset_Detail_Report_Page_Icon.png) : The page is concealed within the sidebar, as it cannot be accessed directly via a button on the sidebar. This page can be reached via the *Asset detail report" button on a row of the asset overview table.  The asset's detailed report page, often accessed via its QR code link, provides a comprehensive summary of general, accounting, and location information, including a clear node-edge diagram, facilitating easy access to crucial details. See [The *Asset detail report page* tab](#the-asset-detail-report-page-tab).

### The 'Asset overview' page

The *Asset overview* page consists of the following main components:

- [Header bar]()

#### The header bar

The header bar is only available in the *Asset overview* tab. In this header bar, you can find the following functionalities:

| Icon | Name | Description |
|--|--|--|
| ![Add assets](~/user-guide/images/Add_Asset.png) | Add asset | Allows you to create an asset, specifying general asset, DataMiner, accounting, SLA, and location information. Because the asset object relies on other DOM definitions, certain information can be selected directly from a dropdown list, e.g. category, status, building, floor, and more. |
| ![Add categories](~/user-guide/images/Add_Categories.png) | Categories | Allows you to add new categories by specifying a category name and ID, or review the existing list of categories in a panel to the right. To delete or modify any of the categories, click the ellipsis button ("...") next to the category and select *Delete* or *Edit*. |
| ![Add status indicators](~/user-guide/images/Status_Indicators.png) | Status indicators | Allows you to add new status indicators, or review the existing list of status indicators. To delete or modify any of the status indicators, click the ellipsis button ("...") next to the status indicator and select *Delete* or *Edit*. |
| ![Add buildings](~/user-guide/images/Add_Buildings.png) | Buildings | Allows you to add new buildings, or review the existing list of buildings. To delete or modify any of the buildings, click the ellipsis button ("...") next to the building and select *Delete* or *Edit*. |
| ![Add floors](~/user-guide/images/Add_Floors.png) | Floor | Allows you to add new floors, or review the existing list of floors. To delete or modify any of the floors, click the ellipsis button ("...") next to the floor and select *Delete* or *Edit*. |
| ![Add rooms](~/user-guide/images/Add_Rooms.png) | Room | Allows you to add new rooms, or review the existing list of rooms. To delete or modify any of the rooms, click the ellipsis button ("...") next to the room and select *Delete* or *Edit*. |
| ![Add aisles](~/user-guide/images/Add_Aisles.png) | Aisle | Allows you to add new aisles, or review the existing list of aisles. To delete or modify any of the aisles, click the ellipsis button ("...") next to the aisle and select *Delete* or *Edit*. |
| ![Add racks](~/user-guide/images/Add_Racks.png) | Rack | Allows you to add new racks, or review the existing list of racks. To delete or modify any of the racks, click the ellipsis button ("...") next to the rack and select *Delete* or *Edit*. |
| ![Add slots](~/user-guide/images/Add_Slots.png) | Slots | Allows you to add new slots, or review the existing list of slots. To delete or modify any of the slots, click the ellipsis button ("...") next to the slot and select *Delete* or *Edit*. |

#### The filter pane

In the *Asset overview* page, a filter pane on the left enables you to narrow down assets based on their properties. ![Filter pane settings](~/user-guide/images/Asset_Management_Filter_Pane_2.png)

Within the settings, you have the option to toggle filter assistance on or off. Enabling this feature displays potential filter options, while disabling it allows you to directly input values for filtering purposes.

- The application opens with the asset overview page, offering a comprehensive view of all assets, with a query filter for specific searches.

- In the header bar, actions include manually adding assets via the "Add asset" button.

- Assets are defined using various categories, statuses, buildings, floors, rooms, aisles, racks and slots from a self-defined DOM list for versatility.

- Detailed information, including accounting specifics and precise locations, can be inserted, following a specific format for implementing the asset number: “CHASSISNUMBER.CARDNUMBER." This format is crucial for utilizing the parent-child relationship on the detail report page.

- Users can generate or modify categories, statuses, locations, etc., ensuring flexibility and customization. Deletion is controlled to prevent removal of in-use values.

![Asset overview page](~/user-guide/images/Asset_Management_Asset_Overview.png)

Within each row of the asset overview table, you'll find buttons enabling you to edit or delete existing assets. Additionally, there's a button leading directly to the hidden asset detail report page.

### The 'Asset detail report page' tab

- This frequently accessed page serves as the detailed report for an asset, accessible via its QR code link.

- It provides a summary of general information, accounting data, and SLA details, along with clear location visualization in a node-edge diagram.

- The parent-child relationship, if applicable, like a chassis with linked cards, is visually presented for easy understanding.

- Adhering to the specified asset number format ("CHASSISNUMBER.CARDNUMBER") is crucial for clarity.

- If the asset is monitored in DataMiner, direct access to its monitoring page is provided.

![Asset detail report page](~/user-guide/images/Asset_Management_Asset_Detail_Report.png)

### The 'QR code' tab

- The *QR code* tab provides an overview of active URLs for accessing the asset detail report page.

- Designed for customer convenience, the page facilitates exporting asset URL data in CSV format.

- This feature allows for the bulk creation of QR codes, simplifying their attachment to devices.

- Scanning these QR codes instantly links to the asset detail report page, offering immediate access to essential information.

![QR Code](~/user-guide/images/Asset_Management_QR_Code.png)

#### Adapting the URL

To adapt the URL to your personal system:

1. Click the hamburger button in the top-left corner to fully expand the sidebar.

1. Select *QR code*.

   A page containing a table with all asset URLs the QR codes can be generated from is displayed.

   ![Asset Management](~/user-guide/images/Asset_Management_url_Overview.png)<br/>*DataMiner Low-Code Apps in DataMiner 10.4.3*

1. In edit mode, select the table component and click the ![Data](~/user-guide/images/NewRD_datafeed.png) icon to see which query is used in the table.

1. Make sure no components are selected, navigate to this query in the *Data* tab in the pane to the right and click the pencil icon next to it.

   You can now see that this query was constructed using the *Assets all* query.

1. Click the pencil icon again to stop editing the query.

1. Navigate to *Data > Queries > Assets all* and click the pencil icon next to it to edit the query.

1. Scroll down until you reach the *Concatenate* method used to specify the URL in the query.

   ![Asset Management](~/user-guide/images/Asset_Management_url.png)<br/>*DataMiner Low-Code Apps in DataMiner 10.4.3*

1. Select the information specified below *Concatenate* and edit the URL in the *Format* field. Replace `slc-h79-g04.skyline.local` with your own DMA name.

   ![Asset Management](~/user-guide/images/Asset_Management_Change_url.png)

1. Click the pencil icon again to stop editing the query.

The table component now displays the updated URLs.

### The 'Complete assets overview' tab

The *Complete assets overview* tab offers a way for bulk data ingestion.

- Manual integration can be time-consuming for entering multiple assets individually.

- A bulk update option is provided via a pre-designed Excel sheet on this page.

- This facilitates a smoother start to your asset management process.

![Complete assets overview](~/user-guide/images/Asset_Management_Complete_Assets_Overview.png)

### The 'Alarm history overview' tab

The *Alarm history overview* tab offers a comprehensive overview of all asset alarms monitored in your DataMiner System. You can easily filter alarms based on specific elements with the filter tool at the top of the page.

![Alarm history page](~/user-guide/images/Asset_Management_Alarm_History_Page.png)

