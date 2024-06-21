---
uid: Style_guide
---

# Style guide

Use this guide as a basis to build or improve low-code apps. 
These best pratices should allow you to create intuitive, visually appealing apps which have a consistent behavior with other apps.

> [!TIP]
> See also: [Kata #19: Transform low-code apps into visual delights](https://community.dataminer.services/courses/kata-19/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## Colours / Themes

- when starting to work on a app it essential to start from a good **theme**. :If you like the look and feel of certain app duplicate that one and start tuning it for your own app, more information on how customize a theme see [Configuring the dashboard layout](xref:Configuring_the_dashboard_layout).
- when defining a background color for pages and panels (as part of the theme), never use full white or full black. Some good defaults below:
  | Light background | Dark background|
  |------------------|----------------|
  |#F2F2F2           |#1E232F         |
- make sure your theme has a component style with a transparent background. Use this component style for titles, logos, buttons.
  TODO: show image
- also make a component style with a background color which differs from the page/panel background. Some good defaults below:
  | Light background | Dark background|
  |------------------|----------------|
  |#FDFDFD           |#282F3E         |
- Make sure when picking colors, that there is enough contrast on text and icons in comparison with the background. This will greatly improve readability for the end user.

  | Good | Bad |
  |------|-----|
  |![Good Contrast](~/user-guide/images/LCA_Style_Guide_Contrast_Good.png)|![Bad Contrast](~/user-guide/images/LCA_Style_Guide_Contrast_Bad.png)|

 
- Limit the number of colors that you use in an app. 


## Navigation

In order to have consistent navigation it is recommended to stick to the following order:

1. Sidebar : main navigation should be the different pages defined in the app.
1. Menubar : use this for navigation within a page, this can open up hidden page. In this case it make sense to change the title of each page to show where you are. 

It is generally **not** advised to use buttons for navigation.

## Titles

Titles are optional on pages. Depends on the fact if it needs to give more context to the user what he is actually looking at.

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

## Buttons

Buttons can trigger different actions on page or panel. Some attention points when using buttons:
- Use short labels
- Make sure buttons have a transparent background

| Good | Bad |
|------|-----|
|![Good Button](~/user-guide/images/LCA_Style_Guide_Button_Good.png)|![Bad Button](~/user-guide/images/LCA_Style_Guide_Button_Bad.png)|

- Add icon to the button whenever possible, this will allow a user to understand more easily what is possible 

## Forms



## Tables

Tables should only contain the most relevant data 

Don't show guids in a table column, even if this data is part of your GQI query, it should be hidden in the table by using a filter on the columns that are shown.

## Panels

Panels should be used to show additional information about an item selected on a page. 
For example : a DOM Form, additional details/metadata which were not shown on the original page

## Layout

Make sure components on a page/panel are aligned verticall:y and horizontally

| Good | Bad |
|------|-----|
|![Good Alignment](~/user-guide/images/LCA_Style_Guide_Alignment_Good.png)|![Bad Alignment](~/user-guide/images/LCA_Style_Guide_Alignment_Bad.png)|

## Grids

## 

> [!TIP]
> When using HTML inside a grid or table template make sure you have an outer element with an empty title attribute, otherwise the HTML will show up on hover:
