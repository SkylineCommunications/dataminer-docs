---
uid: Tutorial_App_Design
---

# Best practices in low-code app design

This tutorial delves into the practical techniques to create intuitive, visually appealing and user-friendly low-code apps.

Expected duration: 30 minutes.

> [!TIP]
> See also:
>
> - [Kata #19: Transform Low-Code Apps into visual delights](https://community.dataminer.services/courses/kata-19/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

> [!NOTE]
> This tutorial uses DataMiner version 10.4.1.

## Prerequisites

- DataMiner 10.4.2 or higher.

- Deploy the package called *KataDesign* directly to your DataMiner System via the [Catalog](https://catalog.dataminer.services/details/package/5883).

  > [!TIP]
  > For information on how to deploy a package, see [Deploying a Catalog item](xref:Deploying_a_catalog_item).

## Overview

- [Best practices in low-code app design](#best-practices-in-low-code-app-design)
  - [Prerequisites](#prerequisites)
  - [Overview](#overview)
  - [Step 1: Open the low-code app to start from](#step-1-open-the-low-code-app-to-start-from)
  - [Step 2: Choose a good app color and icon](#step-2-choose-a-good-app-color-and-icon)
  - [Step 3: Adding page icons](#step-3-adding-page-icons)
  - [Step 4: Setting up themes](#step-4-setting-up-themes)
  - [Step 5: Apply a theme](#step-5-apply-a-theme)
  - [Step 6: Improve page layout](#step-6-improve-page-layout)
  - [Step 7: Enhance titles](#step-7-enhance-titles)
  - [Step 8: Fancy forms](#step-8-fancy-forms)
  - [Step 9: Fixing the grid](#step-9-fixing-the-grid)
  - [Step 10: Enhancing the table look](#step-10-enhancing-the-table-look)

## Step 1: Open the low-code app to start from

1. Once you have the app installed through the [Catalog](https://catalog.dataminer.services/details/package/5883) go to the apps homepage at /root/

1. If everything installed correctly, you should find an app there called **Best Practices in Low-Code App Design**. Open it and you should see the following home page:

    [Initial app](~/user-guide/images/tutorial_app_design_intial_app.png)

1. As the intial package does not contain any contacts yet, add some sample contacts to the application by clicking the **Add contact** button, filling in the form and clicking the big **+ Add** button at the bottom of the form.

## Step 2: Choose a good app color and icon

1. The main color of the app results in low contrast between the text in the left hand menu and the background color. Also the pages have no distinguishing icon. These are the first things that needs fixing.

    ![Low contrast](~/user-guide/images/tutorial_app_design_low_contrast.png)

1. In the top left corner click on the waffle icon to open the page where you can change the icon and the color of the low-code app

1. Pick a general color for the app, make sure that there is enough contrast between the color and text color. As an example here we are using the hex color **#503e6f**. Also pick an icon for the app, in this case we picked an icon representing people by searching on "contact" in the icon list.

1. Use preview mode of the app to verify that the contrast is better between background and text.

    ![Better contrast](~/user-guide/images/tutorial_app_design_better_contrast.png)

## Step 3: Adding page icons

The pages still have very generic icons per page, which make the pages hard to distinguish. Make sure you have good icons assigned to a page. To do this edit the page again and assign a icon in the **icon** menu next to the page.
    ![Page icons](~/user-guide/images/tutorial_app_design_page_icons.png)

## Step 4: Setting up themes

In order to have a good looking app you need to start from a good looking theme. A theme determines how the pages and components are styled by default. By applying a good theme your app will already look much better with limited effort.

1. In order to create / edit / delete themes we need to go to the dashboards application.

    ![Switch to dashboards](~/user-guide/images/tutorial_app_design_switch_to_dashboards.gif)

1. In the dashboards app , click top right on the User icon and open the **Settings**. This should show a list of available themes.

1. Create a new theme here and give it a useful name.

1. Set the following properties on the theme:
   1. Set the background color of the theme to: rgb(243,243,245)
   1. Edit the **Default** component theme
      1. Under Title
         1. set **font size** to *16px*
         1. set alignment to *Center*
      1. Under Color
         1. set **background color** to rgb(253,253,253)
         1. set **font** color to rgb(0,7,54)
         1. Under Color palette define:
            1. Color 1:  rgb(139,115,255)
            1. Color 2:  rgb(66,204,126)
            1. Color 3:  rgb(255,72,66)
            1. Color 4:  rgb(255,194,8)
            1. Color 5:  rgb(255,152,97)
      1. Under Spacing
         1. set **Vertical Margin** to 8px
         1. set **Horizontal Margin** to 8px
         1. set **Vertical Padding** to 10px
         1. set **Horizontal Padding** to 10px
      1. Under Border
         1. set **Roundness** to 5px
         1. set **Style** to Line
         1. enable all sides
         1. set **Thickness** to 1px
         1. set **Color** to rgb(233,234,237)
   1. Duplicate the Default component theme and call it **Transparent**
      1. Set the opacity of the background color to 0%
      1. Set the opacity of the border color to 0%
   1. Save the theme

1. Dupiclate the theme we just created and add **- Panel** to the name. This is the theme we are going to use for our panels in the app.
   1. Set the **background color** for the panel to rgb(253,253,253)
   1. For the Default component:
      1. Under Title
         1. set **font size** to *14px*
      1. Under Color
         1. set **background color** to rgb(248,248,249)
   1. Save the theme

## Step 5: Apply a theme

1. To apply the Theme to the app we are working on, go back to the app and edit it.

1. Edit the Contacts page and go to **Layout** in the right-hand column. Select the theme that you just created in the previous step.

1. Components like titles, buttons, images should never have a background color. Select each of these components separately, go to Layout and select the Style **Transparent**

1. Publish the app and now you should see an app which is already a little more appealing.

    ![Theme applied](~/user-guide/images/tutorial_app_design_theme_applied.png)

## Step 6: Improve page layout

1. In order to have the page resize to different screens sizes and avoid scroll bars, set the page to **Fit to view**. This can be done by editing the page, go to **Settings** and under **PAGE/PANEL CONFIGURATION** enable the checkbox **Fit to view**

1. Next start rearrange and resize the components on the page, taking the following guidelines into account:
   1. Ensure identical spacing left and right on the page.
   1. Use the available space, don't leave too much white space.
   1. Align components both vertically and horizontally, make them same height.
   1. Adjust width of components. If components are positioned on the same row and are equally important, make their width identical (e.g. chart and grid component are each 30% of the width).
   1. This is an example on how you could rearrange them to have a good looking result:

    ![Rearranged components](~/user-guide/images/tutorial_app_design_rearranged_components.png)

## Step 7: Enhance titles

Titles can be styled as just text boxes, but these are often very bland. To make them a little more interesting use a web component and add some HTML to it. In the app we already use a web component for it but the HTML is pretty basic. 

1. Select the Contacts title and go to **Setting** in the right-hand column.

1. Paste the following in the **HTML** field:

```html
<div style="height:100%;display:flex;flex-direction:column;justify-content:center;margin:0;"><H1 style="color: rgb(0,9,54); font-family:'Segoe UI Light','Segoe UI Web Light','Segoe UI Web Regular','Segoe UI','Segoe UI Symbol',HelveticaNeue-Light,'Helvetica Neue',Arial,sans-serif;margin:0;font-weight:100;font-size:24px">
<b>Contacts</b> </H1>
<p style="color: rgb(0,9,54,0.7); font-family:'Segoe UI Light','Segoe UI Web Light','Segoe UI Web Regular','Segoe UI','Segoe UI Symbol',HelveticaNeue-Light,'Helvetica Neue',Arial,sans-serif;margin:0;font-weight:600;font-size:16px">
An overview of your contacts
</p>
</div>
```

1. The result should look like this:

    ![Rearranged components](~/user-guide/images/tutorial_app_design_fancy_title.png)

## Step 8: Fancy forms

The form that is used to create new contacts also has room for improvement.

1. Edit the app and open the panel called **Contact Form**

1. Go to **Layout** in the right-hand column and select the **- Panel** theme.

1. Go to **Settings** and enable **Fit to view** to make the form take the full panel height.

1. Remove the **+ Add** button at the bottom of the panel

1. Adjust the height of the form, extend it to the bottom. Adjust the width of the form to take most of the available space

1. Add a **Web** component on top of the form to add a title.

1. In the **HTML** field on the **Settings** of the web component paste the following:

```html
<div style="height:100%;display:flex;flex-direction:row;justify-content:space-between;align-items:center;margin:0;margin:0 4%;"><H1 style="color: rgb(0,9,54); font-family:'Segoe UI Light','Segoe UI Web Light','Segoe UI Web Regular','Segoe UI','Segoe UI Symbol',HelveticaNeue-Light,'Helvetica Neue',Arial,sans-serif;margin:0;font-weight:100;font-size:20px">
<b>New contact</b> </H1>
<p style="color: rgb(0,9,54,0.7); font-family:'Segoe UI Light','Segoe UI Web Light','Segoe UI Web Regular','Segoe UI','Segoe UI Symbol',HelveticaNeue-Light,'Helvetica Neue',Arial,sans-serif;margin:0;font-weight:600;font-size:14px">
Here you can <b style="color: rgb(0,9,54)">create</b> a new contact.</p></div>
```

1. Add a Save action to the header bar, by clicking the + icon on the top left, enter 'Save' as the label.

1. Choose an icon for it (search for save)

1. In the *On click* events add the following actions
   1. Execute component action / I want to 'Form, Save current Changes' / Which form: 'Form 1'
   1. Click the *Upon completion* button and add the following action: Close a panel / Panel : This panel(Contact Form)
   1. Click the *Upon completion* button and add the following action: Execute component action / I want to 'Table, Fetch the data' / Which table?: 'Table 6'

1. On the top right of the panel, rename the '+Add' action 'Close', choose an X icon and as action add "Close a panel" / this panel

1. The result for the panel (in edit mode) should look something like this:

    ![Panel edit mode](~/user-guide/images/tutorial_app_design_panel_edit.png)

1. Once you publish the app and click the **Add contact** button, the panel should look similar to this:

    ![Panel published](~/user-guide/images/tutorial_app_design_panel_published.png)

## Step 9: Fixing the grid

Try to not use too many colors in an app. The grid in our sample is too colorful, as every cell has a very bright color. Let's change this.

1. Edit the page again and click on the grid component

1. Open the **Layout** menu on the right and scroll to the bottom

1. Click **Edit** on the Item template, this should open the template editor for the grid.

1. Select the background layer on the left, and change the background color to #D3D3DB, save the template

    ![Grid color](~/user-guide/images/tutorial_app_design_gridcolor.gif)

1. Next on the Layout tab under **Grid template**, click the checkbox above the columns and next to the rows. This will now auto size the columns and rows of the grid component.

    ![Grid auto size](~/user-guide/images/tutorial_app_design_grid_autosize.png)

## Step 10: Enhancing the table look

Last but not least is improving the look and feel of our contact table at the bottom of the page.

1. Never show guids in a table! Reduce the number of colums in the table by adding column filter and selecting just the columns that you need from the Contacts query and dropping them onto the filter icon on the table:

    ![Table columns](~/user-guide/images/tutorial_app_design_table_columns.gif)

1. We can also improve the look and feel of each column by editing the template for that column. To do that, select the table, go to **Layout** and under **Column Appearance** select the **Full Name** column

1. Click the '...' icon on the top right and select **Customize preset**

1. Click on the gray background (not the checkered background) to see the **Dimensions** settings of the full canvas. Enter **46** as the height, you can leave 128 as the width. This will make our table rows a bit taller.

1. Click on the {Full name} text, under **Dimensions** set the Left padding to 35px, all the rest can stay at 5px

1. To make our font in the first column bold: in the text field replace the {Full name} with the following HTML:

```html
    <span style="font-weight:500">{Full name}</span>
```

1. Under **Tools** on the left, click on Icon to select it

1. Draw an icon on the left side of the {Full name} text

1. Select an icon which looks like a person (under the properties section on the right)

1. Set the size of the icon to width: 16 px and height: 16 px

1. Set the top padding to 15px and the left padding to 13px

1. Save the template and publish

1.  The first column in the table should now look as follows:

    ![table name column](~/user-guide/images/tutorial_app_design_table_name_column.png)

1.  Do the same thing for the columns e-mail and phone and choose appropriate icons

If you have reached the end of this tutorial: Congratulations! Your end result should hopefully look something like this:
    ![End result](~/user-guide/images/tutorial_app_design_end_result.png)
