---
uid: Working_with_Asset_Management
---

# Working with the Asset Management application

To access the Asset Management application:

1. Go to `http(s)://[DMA name]/root`.

1. select *Asset Management* to start using the application.

   ![Asset Management](~/user-guide/images/Asset_Management_Icon.png)

> [!TIP]
> See also: [Asset Management](https://community.dataminer.services/use-case/asset-management/) on the Use Case library on the Dojo community.

To adapt the url to your personal system:

1. Go to the QR code page where the table can be found with all the asset URLs where the QR codes can be generated from. ![Asset Management](~/user-guide/images/Asset_Management_url_Overview.png)

1. Go on edit mode and by clicking on the table, you can see on the data tab which query is attached to the table. ![Asset Management](~/user-guide/images/Asset_Management_url_Data.png)

1. Navigate to the specified query and click on the pencil icon located on the right to inspect its composition. Within this query, you'll observe that it's constructed using the Assets all query.

1. Go to that query and and click on the pencil on the right again to edit the query.

1. Look for the place where you see the concatenate of the url in the query. ![Asset Management](~/user-guide/images/Asset_Management_url.png)

1. Click on the concatenate and change the url to the url of your DMA.![Asset Management](~/user-guide/images/Asset_Management_Change_url.png)

## The Asset Management application user interface

The Asset Management application UI consists of the following main components:

- [Header bar](#the-asset-management-application-header-bar) (1)

- [Sidebar](#the-asset-management-application-sidebar) (2)

- [Overview pane](#the-asset-management-application-overview-pane) (3)

![Asset Management UI](~/user-guide/images/Asset_Management_UI.png)

### The Asset Management application header bar

You can find the following functionalities in the header bar of the application. Available only in the [*Asset overview* tab](#the-asset-overview-tab). :

- **Add asset**: This action involves manually creating an asset using the “Add asset” button. As the asset object relies on other DOM definitions, ensuring versatility, you can directly select the category, status, building, floor, room, aisle, rack, and slot from the self-defined DOM list.![Add asset](~/user-guide/images/Asset_Management_Add_Asset.png)

- **Categories**: You can manually generate new categories or review the existing list of categories. Within the list overview, you also have the capability to delete or modify a category as needed.

- **Status indicators**: You can manually generate new status indicators or review the existing list of status indicators. Within the list overview, you also have the capability to delete or modify a status indicator as needed. ![Status Indicators](~/user-guide/images/Asset_Management_Status_Indicators.png)

- **Buildings**: You can manually generate new buildings or review the existing list of buildings. Within the list overview, you also have the capability to delete or modify a building as needed.

- **Floor**: You can manually generate new floors or review the existing list of floors. Within the list overview, you also have the capability to delete or modify a floor as needed.

- **Room**: You can manually generate new rooms or review the existing list of rooms. Within the list overview, you also have the capability to delete or modify a room as needed.

- **Aisle**: You can manually generate new aisles or review the existing list of aisles. Within the list overview, you also have the capability to delete or modify an aisle as needed.

- **Rack**: You can manually generate new racks or review the existing list of racks. Within the list overview, you also have the capability to delete or modify a rack as needed.

- **Slots**: You can manually generate new slots or review the existing list of slots. Within the list overview, you also have the capability to delete or modify a slot as needed.

### The Asset Management application sidebar

The sidebar on the left of the Asset Management application contains buttons that can be used to expand different panes:

- ![Asset overview](~/user-guide/images/Asset_Overview_Icon.png) : When you open the application, the first page you encounter is the asset overview page. This page offers a comprehensive overview of all your assets, and the query filter facilitates the search for specific items. See [The *Asset overview* tab](#the-asset-overview-tab).

- ![QR code](~/user-guide/images/QR_code_Icon.png) : Clicking the *QR code* button displays an overview of urls. This functionality enables the simultaneous creation of all QR codes, which can then be affixed to the respective devices. See [The *QR code* tab](#the-qr-code-tab).

- ![Complete assets overview](~/user-guide/images/Complete_Assets_Overview_Icon.png) : Clicking the *Complete assets overview* button gives an overview of all the assets where a bulk update option is available through a pre-designed Excel sheet on this page, ensuring a smooth start to your asset management journey. See [The *Complete assets overview* tab](#the-complete-assets-overview-tab).

- ![Alarm history overview](~/user-guide/images/Alarm_History_Overview_Icon.png) : Clicking the *Alarms* button displays an overview of all asset alarms monitored in your DataMiner System. See [The *Alarm history page* tab](#the-alarm-history-overview-tab).

- ![Asset detail report page](~/user-guide/images/Asset_Detail_Report_Page_Icon.png) : The page is concealed within the sidebar, as it cannot be accessed directly via a button on the sidebar. This page can be reached via the *Asset detail report" button on a row of the asset overview table.  The asset's detailed report page, often accessed via its QR code link, provides a comprehensive summary of general, accounting, and location information, including a clear node-edge diagram, facilitating easy access to crucial details. See [The *Asset detail report page* tab](#the-asset-detail-report-page-tab).

### The Asset Management application overview pane

#### The 'Asset overview' tab

- The application opens with the asset overview page, offering a comprehensive view of all assets, with a query filter for specific searches.

- In the header bar, actions include manually adding assets via the "Add asset" button.

- Assets are defined using various categories, statuses, buildings, floors, rooms, aisles, racks and slots from a self-defined DOM list for versatility.

- Detailed information, including accounting specifics and precise locations, can be inserted, following a specific format for implementing the asset number: “CHASSISNUMBER.CARDNUMBER." This format is crucial for utilizing the parent-child relationship on the detail report page.

- Users can generate or modify categories, statuses, locations, etc., ensuring flexibility and customization. Deletion is controlled to prevent removal of in-use values.

![Asset overview page](~/user-guide/images/Asset_Management_Asset_Overview.png)

Within each row of the asset overview table, you'll find buttons enabling you to edit or delete existing assets. Additionally, there's a button leading directly to the hidden asset detail report page.

#### The 'Asset detail report page' tab

- This frequently accessed page serves as the detailed report for an asset, accessible via its QR code link.

- It provides a summary of general information, accounting data, and SLA details, along with clear location visualization in a node-edge diagram.

- The parent-child relationship, if applicable, like a chassis with linked cards, is visually presented for easy understanding.

- Adhering to the specified asset number format ("CHASSISNUMBER.CARDNUMBER") is crucial for clarity.

- If the asset is monitored in DataMiner, direct access to its monitoring page is provided.

![Asset detail report page](~/user-guide/images/Asset_Management_Asset_Detail_Report.png)

#### The 'QR code' tab

- The *QR code* tab provides an overview of active URLs for accessing the asset detail report page.

- Designed for customer convenience, the page facilitates exporting asset URL data in CSV format.

- This feature allows for the bulk creation of QR codes, simplifying their attachment to devices.

- Scanning these QR codes instantly links to the asset detail report page, offering immediate access to essential information.

![QR Code](~/user-guide/images/Asset_Management_QR_Code.png)

#### The 'Complete assets overview' tab

The *Complete assets overview* tab offers a way for bulk data ingestion.

- Manual integration can be time-consuming for entering multiple assets individually.

- A bulk update option is provided via a pre-designed Excel sheet on this page.

- This facilitates a smoother start to your asset management process.

![Complete assets overview](~/user-guide/images/Asset_Management_Complete_Assets_Overview.png)

#### The 'Alarm history overview' tab

The *Alarm history overview* tab offers a comprehensive overview of all asset alarms monitored in your DataMiner System. You can easily filter alarms based on specific elements with the filter tool at the top of the page.

![Alarm history page](~/user-guide/images/Asset_Management_Alarm_History_Page.png)

#### The filter pane

In the *Asset overview* tab, a filter pane on the left enables you to narrow down assets based on their properties. ![Filter pane settings](~/user-guide/images/Asset_Management_Filter_Pane_2.png)

Within the settings, you have the option to toggle filter assistance on or off. Enabling this feature displays potential filter options, while disabling it allows you to directly input values for filtering purposes.
