---
uid: Tutorial_Apps_Managing_Pages
---
# Managing the pages of an app

This tutorial shows how to add, change duplicate and remove pages in a low-code app.

> [!NOTE]
> A low-code app will only show the navigation sidebar if there are at least two pages. If an app has only one page, the sidebar is not displayed outside of edit mode.

## Overview

- [Step 1: Add pages to your app](#step-1-add-pages-to-an-app)
- [Step 2: Configure how pages are shown](#step-2-configure-how-pages-are-shown)
- [Step 3: Duplicate a page](#step-3-duplicate-a-page)

## Prerequisites

Make sure you have deployed the [IPAM - GQI dummy data sources](https://catalog.dataminer.services/catalog/5410) from the catalog. This package contains some data which will be used throughout the tutorial.

## Step 1: Add pages to an app

1. Make sure you are viewing the app in [edit mode](xref:Tutorial_Apps_Edit_Existing_App#step-1-edit-the-latest-version-of-your-app).

1. In the sidebar on the left, click the "+" icon (in case the sidebar is collapsed) or click *Create page* (if the sidebar is expanded).

   ![Create page button](~/user-guide/images/PageAdd.png)

## Step 2: Configure how pages are shown

1. To **rename** a page, you have two options. You can select the existing text of the page in navigation sidebar and specify a new name, or you can select the page and modify its name at the top of the gray details sidebar. Let's rename the page to "IP  addresses".

  ![Renaming a page](~/user-guide/images/PageRename.png)

1. To **select an icon** for a page, in the gray details sidebar, expand the *Icon* section. You can then search for and select an icon to represent your page.

  ![Selecting an icon](~/user-guide/images/PageIcon.png)

The navigation sidebar will display the selected icon at all times, even when it is collapsed.

### (Optional) Add data to our page

1. Add a web component to our page.

![Web component](~/user-guide/images/WebComponent.png)

1. Select the component, go to the settings tab on the right-hand side and give it some html content.

![HTML content](~/user-guide/images/WebComponentContent.png)

```html
<H1 style="margin-bottom:0px;;font-family: 'Space Grotesk','Segoe UI',Helvetica,Arial,sans-serif; font-size: 50px; background: linear-gradient(90deg, rgba(13,89,81,1) 0%, rgba(7,213,255,1) 32%); -webkit-text-fill-color: transparent;background-clip: text; -webkit-background-clip: text;">IP Addresses</h1>

<H2 style="color:#0d5951; font-family:'Segoe UI Light','Segoe UI Web Light','Segoe UI Web Regular','Segoe UI','Segoe UI Symbol',HelveticaNeue-Light,'Helvetica Neue',Arial,sans-serif;margin:0;font-weight:100">
Manage all your IP addresses
</H2>
```

1. Set the layout theme of the component to "Transparent".

![Transparent theme](~/user-guide/images/ComponentTransparentTheme.png)

1. Add a table to our page, configure a GQI query that uses the deployed ad hoc data source "IP addresses - Dummy".

![IP address query](~/user-guide/images/IPAddressesQuery.png)

## Step 3: Duplicate a page

You can quickly create a duplicate of an existing page, resulting in a new page that is identical to the original. The entire configuration, including feed references, will be preserved in this duplicated page.

> [!NOTE]
> While feed references are maintained when you duplicate a page, other pages that consume feeds from the duplicated page will only receive values from the original page.

1. To **duplicate** a page, in the navigation sidebar, click the ... icon next to the page name and select *Duplicate*. Create a duplicate of the "IP addresses" page.

  ![Duplicate option](~/user-guide/images/PageDuplicate.png)

  This will create a copy of the page. You can then customize the duplicated page to suit your requirements.

1. Change the page name to "Subnets" and use the "Switch" icon.
2. Change the content of the web component. Remove the query from the table and create a new query that fetches data from the "IP subnets - Dummy" ad hoc data source instead.

### (Opional) Reordering, hiding and deleting pages

- To **change the order** of the pages in your app, including the initial page (i.e. the one located at the top of the navigation sidebar), hover over a page until you see up and down arrows and then click those arrows as necessary.

  ![Reordering pages](~/user-guide/images/PageReorder.png)

The context menu of page also contains 2 additional capabilties. 

  ![Page context menu](~/user-guide/images/PageContextMenu.png)

1. To **hide pages** item ensures that the page is not included in the sidebar.

1. To **delete** item will prompt a confirmation window which lets the user delete the page and all of its content.

## Learning paths

This tutorial is part of the following learning path:

- [Low-Code Apps](xref:Tutorial_Apps)

## Related documentation

- [Configuring a page of a low-code app](xref:LowCodeApps_page_config)
