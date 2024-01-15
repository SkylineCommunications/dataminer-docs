---
uid: Tutorial_Apps_Managing_Pages
---

# Managing the pages of an app

This tutorial shows how to add, change, duplicate, and remove pages in a low-code app.

The content and screenshots for this tutorial were created in DataMiner version 10.3.11.

Expected duration: 5 minutes.

> [!TIP]
> See also: [Kata #7: Pages, panels and headers in a low-code app](https://community.dataminer.services/courses/kata-7/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## Prerequisites

- A DataMiner System using DataMiner 10.3.11 or higher, which is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Overview

- [Step 1: Install the dummy data sources package](#step-1-install-the-dummy-data-sources-package)
- [Step 2: Add a page to your app](#step-2-add-a-page-to-your-app)
- [Step 3: Configure how your page is shown](#step-3-configure-how-your-page-is-shown)
- [Step 4: Add data to the page](#step-4-add-data-to-the-page)
- [Step 5: Duplicate a page](#step-5-duplicate-a-page)
- [Step 6: (Optional) Reorder, hide, and delete pages](#step-6-optional-reorder-hide-and-delete-pages)

## Step 1: Install the dummy data sources package

1. Go to <https://catalog.dataminer.services/catalog/5410>

1. Click the *Deploy* button to deploy the *IPAM - GQI dummy data sources* packages on your DMA.

   This package contains data that will be used in this tutorial.

## Step 2: Add a page to your app

1. Make sure you are viewing the app in [edit mode](xref:Tutorial_Apps_Edit_Existing_App#step-1-edit-the-latest-version-of-your-app).

1. In the sidebar on the left, click the "+" icon (in case the sidebar is collapsed) or click *Create page* (if the sidebar is expanded).

   ![Create page button](~/user-guide/images/PageAdd.png)

> [!NOTE]
> A low-code app will only show the navigation sidebar if there are at least two pages. If an app has only one page, the sidebar is not displayed outside of edit mode.

## Step 3: Configure how your page is shown

1. Try to **rename** your new page to "IP addresses".

   There are two ways you can do this:

   - Select the existing text of the page in the navigation sidebar and specify a new name.

     ![Renaming a page](~/user-guide/images/PageRename.png)

   - Select the page and modify its name at the top of the gray details sidebar.

1. Select an **icon** for your page:

   1. In the gray details sidebar, expand the *Icon* section.

   1. Use the box at the top to search for a suitable icon

   1. Select the icon to represent your page.

      ![Selecting an icon](~/user-guide/images/PageIcon.png)

   The navigation sidebar will display the selected icon at all times, even when it is collapsed.

## Step 4: Add data to the page

1. Add a web component to the page.

   ![Web component](~/user-guide/images/WebComponent.png)

1. Select the component you have added, go to the *Settings* tab on the right-hand side, and add HTML content in the *HTML* box:

   ![HTML content](~/user-guide/images/WebComponentContent.png)

   ```html
   <H1 style="margin-bottom:0px;;font-family: 'Space Grotesk','Segoe UI',Helvetica,Arial,sans-serif; font-size: 50px; background: linear-gradient(90deg, rgba(13,89,81,1) 0%, rgba(7,213,255,1) 32%); -webkit-text-fill-color: transparent;background-clip: text; -webkit-background-clip: text;">IP Addresses</h1>

   <H2 style="color:#0d5951; font-family:'Segoe UI Light','Segoe UI Web Light','Segoe UI Web Regular','Segoe UI','Segoe UI Symbol',HelveticaNeue-Light,'Helvetica Neue',Arial,sans-serif;margin:0;font-weight:100">
   Manage all your IP addresses
   </H2>
   ```

1. In the *Layout* tab, set the theme of the component to "Transparent".

   ![Transparent theme](~/user-guide/images/ComponentTransparentTheme.png)

1. In the *Data* pane, configure a GQI query that uses the ad hoc data source *IP addresses - Dummy*.

   This is a data source that was added to your system when you deployed the package in step 1.

   ![IP address query](~/user-guide/images/IPAddressesQuery.png)

1. Add a table component to the page and configure it to show the query you have just configured.

## Step 5: Duplicate a page

You can quickly create a duplicate of an existing page, resulting in a new page that is identical to the original. The entire configuration, including feed references, will be preserved in this duplicated page.

1. In the navigation sidebar, click the ... icon next to the page name of your new page and select *Duplicate*.

   ![Duplicate option](~/user-guide/images/PageDuplicate.png)

   This will create a copy of the page. You can then customize the duplicated page to suit your requirements.

1. Change the page name to "Subnets" and use the "Switch" icon.

1. Remove the query from the table and create a new query that fetches data from the *IP subnets - Dummy* ad hoc data source instead.

## Step 6: (Optional) Reorder, hide, and delete pages

1. Try changing the order of the pages in your app: Hover over a page until you see up and down arrows and then click those arrows as necessary.

   ![Reordering pages](~/user-guide/images/PageReorder.png)

1. Add another new page to the app.

1. In the navigation sidebar, click the ... icon next to the page name of your new page, and try out the following options:

   - *Hide from sidebar*: This will ensure that the page is not shown in the sidebar.

   - *Delete*: This will ask you if you are sure you want to delete the page. If you confirm, the page will be removed along with all its content.

   ![Page context menu](~/user-guide/images/PageContextMenu.png)

## Next tutorial

In addition to pages, you can also show panels in a low-code app:

- [Creating and showing a panel](xref:Tutorial_Apps_Panel)

## Learning paths

This tutorial is part of the following learning path:

- [Low-Code Apps](xref:Tutorial_Apps)

## Related documentation

- [Configuring a page of a low-code app](xref:LowCodeApps_page_config)
