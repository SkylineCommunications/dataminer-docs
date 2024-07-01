---
uid: Style_guide
---

# Style guide

Use this guide as a basis to build or improve low-code apps. 
These best pratices should allow you to create intuitive, visually appealing apps which have a consistent behavior with other apps.

> [!TIP]
> See also: [Kata #19: Transform low-code apps into visual delights](https://community.dataminer.services/courses/kata-19/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

<!-- TOC start -->

- [Colors / Themes](#colors-themes)
- [Layout](#layout)
- [Navigation](#navigation)
- [Panels](#panels)
- [Components ](#components)
   * [Titles](#titles)
   * [Buttons](#buttons)
   * [DOM Forms](#dom-forms)
   * [Tables](#tables)
   * [Grids](#grids)
   * [Using templates for tables and grids](#using-templates-for-tables-and-grids)
- [LCA inspiration](#lca-inspiration)

<!-- TOC end -->

## Colors / Themes

- when starting to work on a app it essential to start from a good **theme**. If you like the look and feel of certain app duplicate it and start tuning it for your own app. For more information on how customize a theme, see [Configuring the dashboard layout](xref:Configuring_the_dashboard_layout).
- Each theme **must** have a component style with a transparent background. Use this component style for titles, images, buttons.

  ![Transparent Theme](~/user-guide/images/LCA_Style_Guide_Theme_Transparent.png)
- when defining a background color for pages and panels (as part of the theme), never use full white (#FFFFFF) or full black (#000000). Some good defaults below:

   |☀️  Light background |🌙 Dark background|
   |------------------|----------------|
   |#F4F4F5          |#1E2530         |

- also make a component style with a background color which differs from the page/panel background, this way they can easily be distinguished from the background. This can be used for query filters, tables, timelines, ... (anything but titles, images, buttons). Choose a slightly lighter color then the page/panel background, some good defaults below:
  
   |☀️  Light background |🌙 Dark background|
   |------------------|----------------|
   |#FDFDFD           |#272E38        |
   |![Component light style](~/user-guide/images/LCA_Style_Guide_Component_Style_Light.png)|![Component dark style](~/user-guide/images/LCA_Style_Guide_Component_Style_Dark.png)|


- When picking colors pages, panels, buttons, grids, tables, it is a **must** to have enough contrast on text and icons in comparison with the background. Failing to do so will make your app hard to use. 

   |👍 Good |👎 Bad |
   |------|-----|
   |![Good Contrast](~/user-guide/images/LCA_Style_Guide_Contrast_Good.png)|![Bad Contrast](~/user-guide/images/LCA_Style_Guide_Contrast_Bad.png)|

- Same thing applies when picking a color for the app itself. If you choose an app color, the app will determine itself what the color of the text is based on the chosen background color. Be sure to pick a color which results in enough contrast between the text and background color, especially in the left-hand pages menu, as this will be a slightly darker color then the chosen app color.   

   |👍 Good |👎 Bad |
   |------|-----|
   |![Good App Color](~/user-guide/images/LCA_Style_Guide_App_Color_Good.png)|![Bad App Color](~/user-guide/images/LCA_Style_Guide_App_Color_Bad.png)|

- Limit the number of colors that you use in an app, don't make it too colorfull nor too monotone.
- Picking good colors to start from is often a challenge. One way to approach it is to pick some colours from a layout you find online, like this sample below: 

   |Sample UI | Color palette | Resulting app with same color palette|
   |----------|---------------|-----------------------|
   |![Sample UI](~/user-guide/images/LCA_Style_Guide_Sample_UI.webp)|![Color Palette](~/user-guide/images/LCA_Style_Guide_Color_Palette.png)|![Sample UI Result](~/user-guide/images/LCA_Style_Guide_Sample_UI_Result.png)|

- When using colors for states in tables and charts, you **must** be consistent to always use the same color to represent the same state. 
   
   ![State Color](~/user-guide/images/LCA_Style_Guide_Color_State.png)
   
## Layout

Make sure components on a page/panel are aligned vertically and horizontally

| 👍 Good | 👎 Bad |
|------|-----|
|![Good Alignment](~/user-guide/images/LCA_Style_Guide_Alignment_Good.png)|![Bad Alignment](~/user-guide/images/LCA_Style_Guide_Alignment_Bad.png)|

- Use consistent spacing/margin on a page on the left and right edge across pages. Avoid stretching components to the edge of the page with no spacing. 
- Use the available space, avoid huge empty areas on page. At the same time , don't clutter the interface with too much information, hide additional information on panels.
- Try to limit the number of different font styles and font sizes. Less is more!
- Adjust the size of components to how much information they contain , so avoid very big ring/status components or very small tables and timelines.
- You **must** ensure you have tested your layout on different screen sizes before releasing your app. Make sure it also works on a smaller screen like a laptop and not only on big monitors.

## Navigation

In order to have consistent navigation it is recommended to stick to the following order:

1. Sidebar : main navigation should be the different pages defined in the app

   ![Navigation via sidebar](~/user-guide/images/LCA_Style_Guide_Navigation_Pages.png)

   > [!NOTE]
   > Use a side panel to show additional information for each item on a page.

1. Headerbar : use this for navigation within a page, this can open up hidden page. In this case it make sense to change the title of each page to show where you are. 

   ![Navigation via menubar](~/user-guide/images/LCA_Style_Guide_Navigation_Menu.gif)

> [!CAUTION]
> It is generally **not** advised to use buttons for navigation.

## Panels

- Panels should primarly be used to show additional information about an item selected on a page. 
  For example : a DOM Form, additional details/metadata which were not shown on the original page
- Panels can be shown on the left/right of the screen or as a pop-up. Try to be consistent in an app to always show it in the same location, same width, ... A good default is show DOM forms in a popup, show additional information on selected table row in a right-hand side panel. 

  ![Form Popup](~/user-guide/images/LCA_Style_Guide_Form_Popup.gif)
- Every Panel should have a close button on top right, this could be in the menu bar or a separate button. 

## Components 

### Titles

- Titles are optional on pages. Depends on the fact if it needs to give more context to the user what he/she is actually looking at. Avoid repeating the app name as title on the pages.
- do not use a background color for titles
- don't make the titles too big, focus should be on the content of the page

When using a title, it is best to add it as a web component. Here is a sample

HTML code

```html
<div style="height:100%;display:flex;flex-direction:column;justify-content:center">
  <H1 style="color: rgb(20,33,42); font-family:'Segoe UI Light','Segoe UI Web Light','Segoe UI Web Regular','Segoe UI',Arial,sans-serif;margin:0;font-weight:100;font-size:24px">
    <b>People</b>
  </H1>
  <p style="color: rgb(20,33,42,0.7); font-family:'Segoe UI Light','Segoe UI Web Light','Segoe UI Web Regular','Segoe UI','Segoe UI Symbol',HelveticaNeue-Light,'Helvetica Neue',Arial,sans-serif;margin:0;font-weight:600;font-size:16px">
    An overview of all managed people
  </p>
</div>
```

Result

![Title Good](~/user-guide/images/LCA_Style_Guide_Title_Good.png)

### Buttons

Buttons can trigger different actions on page or panel. Some attention points when using buttons:
- Use short labels
- Make sure buttons have a transparent background

   | 👍 Good | 👎 Bad |
   |------|-----|
   |![Good Button](~/user-guide/images/LCA_Style_Guide_Button_Good.png)|![Bad Button](~/user-guide/images/LCA_Style_Guide_Button_Bad.png)|

- Add icon to the button whenever possible, this will allow a user to understand more easily what is possible 

### Images / Icons

- Do not add customer logos on the apps. This might look useful for marketing purposes, but for a customer it brings very little value.
- If you want to add images to an HTML component or a table/grid template you can convert the image to a data URI using a [converter](https://www.site24x7.com/tools/image-to-datauri.html). This way you can include the image inside the HTML. Only do this for small images.

```html

<img height="45px" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAACWAAAAlgCAYAAAAMTQxuAAAgAElEQVR4nOzcTWjl+13H8c//JPecPgjNXOhBrGBRMvjAhEDNCS2ziJPWhSBuPCCYhc3Cdjrj6bkLTTbKwZmgEp0UtVgE4S7Vi+suurkglj5QfEYoCIK1VlsSWmpzTe/Mz83l0nqfZjJJfv//Oa/X/s/v/d9/+CYAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA ....  />

```
- You can also use Emojis inside a text or HTML, but note that these can look differently depending no which machine they are shown. 

   ![Emoji](~/user-guide/images/LCA_Style_Guide_Emoji.png)

### DOM Forms

- Forms can best be shown in a popup or side panel. If you choose one over the other, make it consistent across the apps you build.
- Use the "As overlay" option when opening the popup/panel, this way the focus is on the popup/panel and not on the background
- Add any form actions, like **save** and **delete** as buttons on top of the form. 
- You **must** enable the **Fit to view** setting on a Form in a panel, this will make sure you form scales with the available screen size of the user. 
- If you make the popup/panel max 35% of the width the labels of the form will be shown above the inputs, which might be easier to read.
- If the Dom instance shown in the form has states, always show a stepper component on top showing the current state of the instance.

   ![Stepper](~/user-guide/images/LCA_Style_Guide_Form_Stepper.png)

- When performing an action (saving,updating) on a form, it is good practice to show a notification to the user on what the result was of the action:
   
   ![Notification](~/user-guide/images/LCA_Style_Guide_Form_Notification.gif)

A good example of a DOM Form with a stepper component inside a panel with save and close button:

![Example DOM Form](~/user-guide/images/LCA_Style_Guide_Form_Good.png)

### Tables

- Tables should only contain the most relevant data, try to limit the number of columns.
- It's generally good practice to add a title to the table component (via Layout > Title) to indicate what the content of the table is.
- Don't show guids in a table column, even if this data is part of your GQI query, it should be hidden in the table by using a filter on the columns that are shown.
- Be consistent when using tables in your app(s), they should all have similar look and feel.
- You **must** contextualize the *Empty result message* so that if clearly states why you don't see any data in the table. **Never** use the default message. 
  
   | 👍 Good | 👎 Bad |
   |------|-----|
   | ![Good Empty Table Message](~/user-guide/images/LCA_Style_Guide_Table_Empty_Good.png) | ![Bad Empty Table Message](~/user-guide/images/LCA_Style_Guide_Table_Empty_Bad.png) |

- Use a visual indication (using table templates) on first column to show clearly what row is selected:  
  ![Good Table Actions](~/user-guide/images/LCA_Style_Guide_Table_Select.gif)
- For adding actions (e.g. edit the row) you can add icons to the first column or as the last column. The disadvantage of using the last column is that the table quick filter often blocks the access to the last column of the first row of a table. As long as that issue exists it is advised to use the first column. Use a context menu (...) to hide actions if there are more than 3. 

   | 👍 Good | 👎 Bad |
   |------|-----|
   | ![Good Table Actions](~/user-guide/images/LCA_Style_Guide_Table_Actions_Good.png) | ![Bad Table Actions](~/user-guide/images/LCA_Style_Guide_Table_Actions_Bad.png) |

- Use the table templates on each column 
  - to add icons to each columns (where relevant)
  - to increase the row height. The default row height is a bit small, increase to about 46px for good readability. 
    
    See example of a good visualization of a table below:

    ![Good Table](~/user-guide/images/LCA_Style_Guide_Table_Good.png)

### Grids

Displaying multiple records in a LCA can be done by using a grid or a table. In most cases a table makes more sense as you have sorting and filtering options out of the box. Only when very specific visuals are needed with horizontal and/or vertical rows, it makes more sense to use a grid. Here are some examples 

- to create a button panel.

![Control Surface](~/user-guide/images/LCA_Style_Guide_Control_Surface.png)

- for button-style filters:

   | Horizontal filter |
   |-------------------|
   |![Grid Filter Horizontal](~/user-guide/images/LCA_Style_Guide_Grid_Filter_Horizontal.png)|

   | Vertical Filter |
   |-----------------|
   |![Grid Filter Vertical](~/user-guide/images/LCA_Style_Guide_Grid_Filter_Vertical.png)|

- to summarize / visualize items in a more creative way: 

   ![Grid Summary](~/user-guide/images/LCA_Style_Guide_Grid_Summary.png)

 > [!NOTE]
 > As with tables you **must** contextualize the *Empty result message* so that if clearly states why you don't see any data in the table. **Never** use the default message. 

### Using templates for tables and grids

When using HTML inside a grid or table template you **must** ensure you have an **outer HTML element** with a title attribute (with the same value of the table/grid cell), otherwise if you don't specific a title attribute the HTML will show up on hover:

<table>
<tr>
<td>👍 Good </td><td>👎 Bad</td>
</tr>
<tr>
<td>

```html
<span title="{Name}" style="font-weight:500">{Name}</span >
```

</td>
<td>

```html
<span style="font-weight:500">{Name}</span >
```

</td>
</tr>
<tr>
<td>

![Good Table Template](~/user-guide/images/LCA_Style_Guide_Table_Template_Good.png)

</td>
<td>

![Bad Table Template](~/user-guide/images/LCA_Style_Guide_Table_Template_Bad.png)

</td>
</table>


## LCA inspiration

The following apps can give some inspiration on how to build enjoyable low-code app experiences:

- [People & Organizations](https://ziine.skyline.be/app/06951cc4-5695-4f6c-a49b-55582d72f611/People%20Overview)
- [Media Asset Management Orchestration](https://ziine.skyline.be/app/6b56efeb-abad-4298-bf59-8f5ba6bf3750/Overview)
- [Techex Tx Core](https://ziine.skyline.be/app/299c8d59-bb34-4d58-b994-d56bf022fb95/Infrastructure)
- [Penalty Box](https://ziine.skyline.be/app/5b6adee8-ed7c-44ce-aabb-aba0de4b5ee6/Severity)


