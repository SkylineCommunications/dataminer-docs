---
uid: Tutorial_Apps_Managing_Pages
---
# Managing the pages of an app

This tutorial shows how to add, change, and remove pages in a low-code app.

> [!NOTE]
> A low-code app will only show the navigation sidebar if there are at least two pages. If an app has only one page, the sidebar is not displayed outside of edit mode.

## Overview

- [Step 1: Adding pages to your app](#step-1-adding-pages-to-an-app)
- [Step 2: Configure how pages are shown](#step-2-configure-how-pages-are-shown)
- [Step 3: Duplicating and deleting a page](#step-3-duplicating-and-deleting-a-page)

## Step 1: Adding pages to an app

1. Make sure you are viewing the app in [edit mode](xref:Tutorial_Apps_Edit_Existing_App#step-1-edit-the-latest-version-of-your-app).

1. In the sidebar on the left, click the "+" icon (in case the sidebar is collapsed) or click *Create page* (if the sidebar is expanded).

   ![Create page button](~/tutorials/images/PageAdd.png)

## Step 2: Configure how pages are shown

- To **rename** a page, you have two options. You can select the existing text of the page in navigation sidebar and specify a new name, or you can select the page and modify its name at the top of the gray details sidebar.

  ![Renaming a page](~/tutorials/images/PageRename.png)

- To **select an icon** for a page, in the gray details sidebar, expand the *Icon* section. You can then search for and select an icon to represent your page.

  ![Selecting an icon](~/tutorials/images/PageIcon.png)

  The navigation sidebar will display the selected icon at all times, even when it is collapsed.

1. To **remove pages** from the navigation sidebar, click the ... button and select *Hide from sidebar* in the menu.

  ![Hiding a page](~/tutorials/images/PageHideFromSidebar.png)

  This will ensure that the page is not included in the sidebar.

- To **change the order** of the pages in your app, including the initial page (i.e. the one located at the top of the navigation sidebar), hover over a page until you see up and down arrows and then click those arrows as necessary.

  ![Reordering pages](~/tutorials/images/PageReorder.png)

## Step 3: Duplicating and deleting a page

You can quickly create a duplicate of an existing page, resulting in a new page that is identical to the original. The entire configuration, including feed references, will be preserved in this duplicated page.

> [!NOTE]
> While feed references are maintained when you duplicate a page, other pages that consume feeds from the duplicated page will only receive values from the original page.

- To **duplicate** a page, in the navigation sidebar, click the ... icon next to the page name and select *Duplicate*.

  ![Duplicate option](~/tutorials/images/PageDuplicate.png)

  This will create a copy of the page. You can then customize the duplicated page to suit your requirements.

1. To **delete** a page from your app completely, click the ... icon next to the page name and select *Delete*.

   ![Delete option](~/tutorials/images/PageDelete.png)

## Learning paths

This tutorial is part of the following learning path:

- [Low-Code Apps](xref:Tutorial_Apps)

## Related documentation

- [Configuring a page of a low-code app](xref:LowCodeApps_page_config)
