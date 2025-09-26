---
uid: Tutorial_App_Design
---

# Creating a visually appealing and user-friendly low-code app

This tutorial delves into the practical techniques to create intuitive, visually appealing, and user-friendly low-code apps, highlighting best practices in low-code app design.

Expected duration: 30 minutes.

> [!TIP]
> See also: [Kata #19: Transform low-code apps into visual delights](https://community.dataminer.services/courses/kata-19/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

> [!NOTE]
> This tutorial uses DataMiner version 10.4.3.

## Prerequisites

- DataMiner 10.4.2 or higher.

- Deploy the *KataDesign* package from the [Catalog](https://catalog.dataminer.services/details/d248cdd3-8960-47fa-9190-ada5e32d0cc4).

  > [!TIP]
  > For information on how to deploy a package, see [Deploying a Catalog item](xref:Deploying_a_catalog_item).

## Overview

- [Step 1: Access the low-code app](#step-1-access-the-low-code-app)

- [Step 2: Customize the app color and icon](#step-2-customize-the-app-color-and-icon)

- [Step 3: Add page icons](#step-3-add-page-icons)

- [Step 4: Configure a new theme](#step-4-configure-a-new-theme)

- [Step 5: Apply the new theme](#step-5-apply-the-new-theme)

- [Step 6: Improve the page layout](#step-6-improve-the-page-layout)

- [Step 7: Enhance the titles](#step-7-enhance-the-titles)

- [Step 8: Enhance the contact forms](#step-8-enhance-the-contact-forms)

- [Step 9: Enhance the appearance of the grid component](#step-9-enhance-the-appearance-of-the-grid-component)

- [Step 10: Enhance the appearance of the table component](#step-10-enhance-the-appearance-of-the-table-component)

## Step 1: Access the low-code app

1. After installing the app via the [Catalog](https://catalog.dataminer.services/details/d248cdd3-8960-47fa-9190-ada5e32d0cc4), go to `http(s)://[DMA name]/root`.

1. Sign in using your DataMiner credentials.

1. Select the *Best Practices in Low-Code App Design* app.

   You now see the home page of the application. Since the initial package does not contain any contacts, no contacts are listed on this page yet.

   ![Initial app](~/dataminer/images/tutorial_app_design_intial_app.png)

1. To add sample contacts to the application, click the *Add contact* button.

1. In the pop-up window, provide the name, address, email address, phone number, country, and company of the contact, along with any additional notes about the contact.

1. Click the *+ Add* button at the bottom of the form.

## Step 2: Customize the app color and icon

The app's primary color results in low contrast between the text and the background color in the sidebar (visible when fully expanded).

![Low contrast](~/dataminer/images/tutorial_app_design_low_contrast.png)

Additionally, the app does not have a customized, identifiable icon. These are the first two aspects you will look into.

1. Click the user icon in the top-right corner of the app and select *Edit*.

   If you are using a more recent DataMiner version (DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 onwards or higher<!--RN 40077-->), click the pencil icon in the top-right corner instead.

1. Click the clipboard icon in the top-left corner to open the app's theme editor. Here you can change your app's icon and color.

   ![Clipboard icon](~/dataminer/images/Change_app_Style.png)

1. Enter the following hex value in the *Hex* field in the lower-left corner: #503e6f.

   Optionally, choose your color of choice, but make sure there is enough contrast between the background color and the text color (#000000 or #ffffff, depending on the background color).

   > [!TIP]
   > If you are uncertain about the contrast, use the online [*Contrast Checker*](https://webaim.org/resources/contrastchecker/) tool.

1. Next, enter *contact* in the filter box and select the *Contact* icon.

   ![Contact icon](~/dataminer/images/Contact_icon.png)

   Optionally, select your icon of choice.

1. Click the new icon in the top-left corner to exit the theme editor.

   ![Better contrast](~/dataminer/images/tutorial_app_design_better_contrast.png)

## Step 3: Add page icons

The different pages currently still have generic icons, which makes them hard to distinguish.

1. Make sure the page is selected in the leftmost pane of the app editor.

1. In the *icon* section in the top-left corner of the app, select your icon of choice.

1. Repeat these steps for the second page.

   In this example, the *contact* icon was chosen for the *Contacts* page and the *eDiscovery* icon for the *Organizations* page.

   ![Page icons](~/dataminer/images/tutorial_app_design_page_icons.png)

## Step 4: Configure a new theme

To ensure an aesthetically pleasing app, start with an appealing theme, which determines default styling for pages and components. Applying a good theme can make your app look a lot better with limited effort.

1. Click the user icon in the top-right corner, and select *View published app* to temporarily leave edit mode.

   If you are using a more recent DataMiner version (DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 or higher<!--RN 40077-->), click the ellipsis button ("...") in the top-right corner instead, and select *View published app*.

1. Click the ![Waffle](~/dataminer/images/Waffle_icon.png) icon in the top-left corner, and select *Dashboards*.

   ![Switch to Dashboards](~/dataminer/images/tutorial_app_design_switch_to_dashboards.gif)

1. Click the user icon in the top-right corner, and select *Settings*.

1. Click *+ New theme*.

1. In the *New theme* pop-up window, enter a theme name.

1. Configure the following properties for the theme:

   - *Background color*: rgb(243,243,245)

   - *Title > Font size*: 16px

   - *Title > Alignment*: Center

   - *Color > Background color*: rgb(253,253,253)

   - *Color > Font color*: rgb(0,7,54)

   - *Color > Color palette*:

     - *Color 1*: rgb(139,115,255)

     - *Color 2*: rgb(66,204,126)

     - *Color 3*: rgb(255,72,66)

     - *Color 4*: rgb(255,194,8)

     - *Color 5*: rgb(255,152,97)

   - *Spacing > Vertical Margin*: 8px

   - *Spacing > Horizontal Margin*: 8px

   - *Spacing > Vertical Padding*: 10px

   - *Spacing > Horizontal Padding*: 10px

   - *Border > Roundness*: 5px

   - *Border > Style*: Line

   - *Border > Sides*: Top, Right, Bottom, Left

   - *Border > Thickness*: 1px

   - *Border > Color*: rgb(233,234,237)

1. Click the *Duplicate* button next to the default component theme and change the component theme name from "Default (1)" to "Transparent".

1. Edit the following component style properties:

   - Set the opacity of the background color to 0%.

     ![Zero opacity](~/dataminer/images/Zero_Opacity.gif)

   - Set the opacity of the border color to 0%

1. Click *Create* in the lower-right corner to save the theme.

1. In the list of themes, click the *Duplicate* button next to your new theme to create a copy of the theme.

1. Click the pencil icon next to it, and change the name of your theme so that it ends in "- Panel", e.g. "Tutorial theme - Panel".

   This is the theme you will use for the app panels.

1. Set the background color to rgb(253,253,253).

1. Edit the following component style properties:

   - *Title > Font size*: 14px

   - *Color > Background color*: rgb(248,248,249)

1. Click *Save* in the lower-right corner.

## Step 5: Apply the new theme

Now that you have created a theme, you can apply it to your low-code app.

1. Click the ![Waffle](~/dataminer/images/Waffle_icon_Dashboards.png) icon in the top-left corner, and select the *Best Practices in Low-Code App Design* application.

1. Click the user icon in the top-right corner, and select *Edit*.

   If you are using a more recent DataMiner version (DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 or higher<!--RN 40077-->), click the pencil button in the top-right corner instead.

1. Make sure the *Contacts* page is selected in the leftmost pane of the app editor.

   Depending on your DataMiner version, you may need to click the pencil icon next to "Contacts".

1. Make sure no components are selected, and navigate to the *Layout* pane on the right.

1. Click the box indicating the currently used theme.

   A list of available themes will be displayed below the box.

1. Select the theme you just created in the previous step.

1. Make sure components displaying **titles, buttons, and images do not have a background color**:

   1. Select the component, and navigate to *Layout > Styles* in the configuration pane to the right.

   1. Click the box indicating the currently used theme, and select *Transparent*.

1. Click the ![Publish](~/dataminer/images/AppPublishIcon.png) icon in the header bar.

   As you can see, the app already looks better. For example, note the clearly distinguishable colors in the pie chart compared to the default theme.

   ![Theme applied](~/dataminer/images/tutorial_app_design_theme_applied.png)

## Step 6: Improve the page layout

### Set the page to 'fit to view'

To ensure the page adapts to different screen sizes and avoids scroll bars, set it to *Fit to view*:

1. Click the user icon in the top-right corner, click *Edit*, and click the pencil icon in the pane to the left.

   If you are using a more recent DataMiner version (DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9 or higher<!--RN 40077-->), click the pencil icon in the top-right corner instead.

1. Navigate to *Settings > Page/Panel configuration* in the configuration pane to the right.

1. Enable the *Fit to view* setting.

### Rearrange and resize the components

Rearrange and resize components on the page, following these guidelines:

- Maintain equal spacing on both sides of the page.

- Use available space effectively, minimizing excessive white space.

- Align components both vertically and horizontally, ensuring consistent height.

- Adjust component widths; if multiple components share a row and are equally important, keep their widths identical (e.g. a chart and grid component each occupy 1/3rd of the width).

Here is an example of a rearrangement for a visually appealing result:

![Rearranged components](~/dataminer/images/tutorial_app_design_rearranged_components.png)

## Step 7: Enhance the titles

Titles can be more than simple text boxes. To make them a little more interesting, use a [web component](xref:DashboardWeb) and incorporate HTML. In the app, a web component is already used to display the title. However, the HTML is rather basic.

1. Select the web component that displays the *Contacts* title, and go to the *Settings* pane on the right.

1. Paste the following HTML in the *HTML* field:

```html
<div style="height:100%;display:flex;flex-direction:column;justify-content:center;margin:0;"><H1 style="color: rgb(0,9,54); font-family:'Segoe UI Light','Segoe UI Web Light','Segoe UI Web Regular','Segoe UI','Segoe UI Symbol',HelveticaNeue-Light,'Helvetica Neue',Arial,sans-serif;margin:0;font-weight:100;font-size:24px">
<b>Contacts</b> </H1>
<p style="color: rgb(0,9,54,0.7); font-family:'Segoe UI Light','Segoe UI Web Light','Segoe UI Web Regular','Segoe UI','Segoe UI Symbol',HelveticaNeue-Light,'Helvetica Neue',Arial,sans-serif;margin:0;font-weight:600;font-size:16px">
An overview of your contacts
</p>
</div>
```

The result should look like this:

![Rearranged components](~/dataminer/images/tutorial_app_design_fancy_title.png)

## Step 8: Enhance the contact forms

You may have noticed earlier, but the form used for creating new contacts also has room for improvement.

### Change the form layout

1. In the *panels* section to the left, select the pencil icon next to *Contact Form*.

1. Go to the *Layout* pane on the right, and click the box indicating the currently used theme.

1. Select the theme you created earlier, which ended in "- Panel".

1. In the *Settings* pane, enable the *Fit to view* setting to take on the full panel height.

1. Hover your mouse pointer over the *+Add* button component and select the trash icon.

1. Extend the height of the form all the way to the bottom, and adjust the width to occupy most of the available space.

### Add a new title

1. Add a web component above the form.

   > [!TIP]
   > See also: [Configuring components](xref:Configuring_components)

1. Go to the *Settings* pane on the right, and paste the following HTML in the *HTML* field:

```html
<div style="height:100%;display:flex;flex-direction:row;justify-content:space-between;align-items:center;margin:0;margin:0 4%;"><H1 style="color: rgb(0,9,54); font-family:'Segoe UI Light','Segoe UI Web Light','Segoe UI Web Regular','Segoe UI','Segoe UI Symbol',HelveticaNeue-Light,'Helvetica Neue',Arial,sans-serif;margin:0;font-weight:100;font-size:20px">
<b>New contact</b> </H1>
<p style="color: rgb(0,9,54,0.7); font-family:'Segoe UI Light','Segoe UI Web Light','Segoe UI Web Regular','Segoe UI','Segoe UI Symbol',HelveticaNeue-Light,'Helvetica Neue',Arial,sans-serif;margin:0;font-weight:600;font-size:14px">
Here you can <b style="color: rgb(0,9,54)">create</b> a new contact.</p></div>
```

### Add a functional save button to the header bar

1. Click the "+" button in the top-right corner and label it "Save".

1. In the *header bar* section, select *Icon* and enter "Save" in the filter box.

1. Select the *Save* icon.

   ![Save icon](~/dataminer/images/Save_icon.png)

1. Configure an on-click action:

   1. Select *Events*, and click the *Configure actions* button next to *On click*.

   1. From the dropdown list, select *Execute component action*.

   1. Specify the following details:

      - *I want to*: Form, Save current Changes

      - *Which form?*: Form 1

   1. Select *Upon completion*, and add a *Close a panel* action.

   1. In the *Panel* box, select "This panel(Contact Form)".

   1. Select *Upon completion*, and add a second *Execute component action*.

   1. Specify the following details:

      - *I want to*: Table, Fetch the data

      - *Which table?*: Table 6

1. Click *Ok* in the lower-right corner of the pop-up window.

### Configure a functional close button

1. Click *+ Add* in the top-right corner, and rename it "Close" in the *header bar* section.

1. In the *Icon* section, enter "Close" in the filter box, and select the "X" icon.

1. Configure an on-click action:

   1. Select *Events*, and click the *Configure actions* button next to *On click*.

   1. From the dropdown list, select *Close a panel*.

   1. In the *Panel* box, select "This panel(Contact Form)".

1. Click *Ok* in the lower-right corner of the pop-up window.

In edit mode, the panel should resemble this:

![Panel edit mode](~/dataminer/images/tutorial_app_design_panel_edit.png)

Once you publish the app and click the *Add contact* button, the panel should look similar to this:

![Panel published](~/dataminer/images/tutorial_app_design_panel_published.png)

## Step 9: Enhance the appearance of the grid component

Avoid using too many colors in one app. Currently, the grid component in our sample app is too colorful.

1. In edit mode, select the grid component and navigate to *Layout > Item templates* in the configuration pane to the right.

1. Click *Edit* to access the Template Editor.

1. Select the *Rectangle* layer in the side pane to the left.

1. In the *Setting* pane to the right, change the color of the rectangle to #D3D3DB.

1. Select *Save* in the lower-right corner of the Template Editor.

   ![Grid color](~/dataminer/images/tutorial_app_design_gridcolor.gif)

1. Navigate to *Layout > Advanced* and click the two ![Scaled to fit (scaling)](~/dataminer/images/Scaling.png) icons to auto-size the rows and columns.

   ![Grid auto size](~/dataminer/images/tutorial_app_design_grid_autosize.png)

## Step 10: Enhance the appearance of the table component

Last but not least, you will improve the appearance of the table component displaying the different contacts.

### Reduce the number of columns

Reduce the number of columns displayed in the table component by adding a filter:

1. Navigate to *Data > All available data > Queries* in the pane to the right, and select *Contacts*.

1. Click and drag the different necessary columns onto the yellow filter icon in the table component.

![Table columns](~/dataminer/images/tutorial_app_design_table_columns.gif)

> [!IMPORTANT]
> Never show guides in a table!

### Edit the table template

You can improve the appearance of each column by editing the template applied to that column:

1. Select the table component, and go to *Layout > Column appearance* in the pane to the right.

1. Select *Full name* from the *Select a column* dropdown list.

1. Click the ellipsis button ("...") in the top-right corner and select *Customize preset*.

1. To modify the template settings, make sure no layers are selected by clicking the gray background.

   In the *Settings* pane to the right, you now see the *Dimensions* settings for the entire template.

1. Change the height of the template to 46 to make your table rows taller.

1. Select the *Text* layer in the side pane to the left, and specify the following properties in the *Settings* pane:

   - *Border radius*: 5px

   - *Horizontal padding*: 35px

   - *Vertical padding*: 5px

   > [!TIP]
   > For more information about the different *Text* layer properties, see [Customizing layer appearance and behavior](xref:Template_Editor#customizing-layer-appearance-and-behavior).

1. Make the font bold by entering the following HTML in the text box:

   ```html
       <span style="font-weight:500">{Full name}</span>
   ```

1. In the side pane to the left, switch to the *Tools* tab, and click *Icon*.

1. Add an icon to the left of the `{Full name}` text.

   > [!TIP]
   > For more information about adding an icon, see [Adding new layers](xref:Template_Editor#adding-a-new-layer).

1. In the *Properties* section of the *Settings* pane, click *Icon* and choose a fitting new icon, e.g. an icon depicting a person.

   ![Person icon](~/dataminer/images/Person_Icon.png)

1. In the *Dimensions* section of the *Settings* pane, specify the following properties:

   - *Width*: 16px

   - *Height*: 16px

   - *Top*: 15px

   - *Left*: 13px

   > [!TIP]
   > See also: [Resizing and positioning a layer](xref:Template_Editor#resizing-and-positioning-a-layer).

1. Click *Save* in the lower-right corner.

1. In the header bar of the low code app, click the ![Publish](~/dataminer/images/AppPublishIcon.png) button to publish the app.

   The *Full name* column should now appear like this:

   ![table name column](~/dataminer/images/tutorial_app_design_table_name_column.png)

1. Repeat these steps for the *E-mail* and *Phone* columns, using different appropriate icons.

   Once you are finished, your final result should resemble this:

   ![End result](~/dataminer/images/tutorial_app_design_end_result.png)

> [!TIP]
> Ready to get started designing your own apps? Make sure to follow our [style guide](xref:LCA_Style_guide) for a consistent and great user experience.
