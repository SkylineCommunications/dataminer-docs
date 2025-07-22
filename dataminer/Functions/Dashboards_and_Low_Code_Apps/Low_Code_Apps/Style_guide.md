---
uid: LCA_Style_guide
---

# Dashboards and Low-Code Apps style guide

Use this documentation as a basis to build or improve Dashboards and Low-Code Apps. These rules will allow you to create intuitive, visually appealing solutions, and they will allow users to experience consistent behavior across different Dashboards and Low-Code Apps. Note that many of the rules will only be applicable for Low-Code Apps, as Dashboards have more limited possibilities.

> [!NOTE]
> If you come across something that has not been added to this style guide yet: [Create a pull request](xref:CTB_Quick_Edit) to update this documentation.

## Themes

- When choosing the main color for a Low-Code App, **ensure there is enough contrast** in header, sidebar and buttons.

- When creating a new Low-Code App or Dashboard, always start from one of our default themes: **Skyline Light - White or Skyline Dark**. (From version 10.5.4)

  - Only **use customization on component themes for minor adjustments**, such as removing padding inside a Maps component.

  - Use that theme **consistently on every page and panel**.

  - Always use the default component style, except for **titles, images, buttons, and our basic controls**, which **should use the transparent component style**.

  - These default themes include our carefully chosen **data colors**. If you need to add colors to the color set, make sure they are **complementary (in the color theory sense) to the existing ones** as much as possible.

- The colors for data on your page must be used consistently, so **that the same color is always used to represent the same data**. The best way to achieve this is by using [conditional colors](xref:LowCodeApps_Layout#creating-a-new-theme-for-a-low-code-app-page) as part of the theme.

## Templates

- Use our carefully chosen set of **interface colors designed to enhance usability and readability**. These are also used in our default themes. 1st, 2nd and 3rd labels suggest combinations, but you can mix and match as needed.

| Purpose (used in theme) | Skyline Light - White  | Skyline Dark |
|--|--|--|
| 1st background (component background) | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#FDFDFD" stroke="#C5C6C8"/></svg> #FDFDFD | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#23272F" stroke="#C5C6C8"/></svg> #23272F |
| 2nd background | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#F6F6F6" stroke="#C5C6C8"/></svg> #F6F6F6 | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#1C2129" stroke="#C5C6C8"/></svg> #1C2129 |
| Background (page background) | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#EFF0F0" stroke="#C5C6C8"/></svg> #EFF0F0 | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#151A22" stroke="#C5C6C8"/></svg> #151A22 |
| 2nd background hover | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#E8E8E9" stroke="#C5C6C8"/></svg> #E8E8E9 | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#30353C" stroke="#C5C6C8"/></svg> #30353C |
| 1st border (component border) | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#E1E1E2" stroke="#C5C6C8"/></svg> #E1E1E2 | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#383C43" stroke="#C5C6C8"/></svg> #383C43 |
| 2nd border | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#D3D4D5" stroke="#C5C6C8"/></svg> #D3D4D5 | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#44484E" stroke="#C5C6C8"/></svg> #44484E |
| 1st border hover | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#C5C6C8" stroke="#C5C6C8"/></svg> #C5C6C8 | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#4F5258" stroke="#C5C6C8"/></svg> #4F5258 |
| 2nd border hover | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#B8BABC" stroke="#C5C6C8"/></svg> #B8BABC | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#5B5E64" stroke="#C5C6C8"/></svg> #5B5E64 |
| Disabled text | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#A0A2A6" stroke="#C5C6C8"/></svg> #A0A2A6 | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#727579" stroke="#C5C6C8"/></svg> #727579 |
| Quiet text | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#727579" stroke="#C5C6C8"/></svg> #727579 | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#A0A2A6" stroke="#C5C6C8"/></svg> #A0A2A6 |
| Subtle text | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#44484E" stroke="#C5C6C8"/></svg> #44484E | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#CECFD1" stroke="#C5C6C8"/></svg> #CECFD1 |
| Default text (text) | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#151A22" stroke="#C5C6C8"/></svg> #151A22 | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#FDFDFD" stroke="#C5C6C8"/></svg> #FDFDFD |

- If you need a selected state or call to action, use your Low-Code App's **main color or <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#2563EB" stroke="#C5C6C8"/></svg> #2563EB**.

  - Selected state: Use it as border and add a background overlay using the same color at 10% opacity.

  - Call to action: Use it as background and use the default text color (light or dark based on your main color) as text color.

- Do not use any fonts other than the default one.

- You can have a **maximum of 3 actions** in your template. If you have more, add them after a 3 dots menu.

- **Use tooltips on layers** or add title attributes to your HTML layers.

- If your template does not have fixed dimensions in your visualization, **make sure it is responsive**. Use CSS flexbox, container queries, text-overflow...

> [!TIP]
> Creating a template from scratch? Get inspired on [Dribbble](https://dribbble.com/search/shots/popular/product-design?q=cards), sketch and structure it in parts using [Figma](https://figma.com), then write your HTML/CSS layers in [Codepen](http://codepen.io/).

## Layout

- Make sure components on a page/panel are **aligned vertically and horizontally**.

- Always **use a 50-column grid** for your page layout.

- Give every page **one column of the page grid as spacing on the left and right** edge.

- Use **consistent spacing** between components.

- **Do not clutter the interface** with too much information. Think about whether your user is technical, so you can show more, or a user like management, who needs a simpler interface.

- Use the fit to view option **when everything fits on one**.

- **Adjust the size of components to fit the information** they contain. This means you should for example avoid very large ring/state components or very small tables and timelines that are filled with data.

- You should know which devices you are creating for, so you need to **test your layout on different screen resolutions** before publishing a Low-Code App.

## Navigation

- **Use the sidebar** for your navigation.

- If you have too many pages in your sidebar or want to show the same data in another way. **Use the header bar as tabs** where the buttons open hidden pages.

> [!NOTE]
> Exception: When up to two components fill the entire page with no margins, you can place action buttons on the left side of the header bar, just do not use them as tabs.

- If you are using the header bar as tabs, make sure you **show a title on each page** or **use a circle icon that is filled** on the selected page.

- Place the about page **at the bottom** of the sidebar and **use the info circle icon**.

- If your app has more than 10 pages (including sidebar and header tabs), **add an overview page**. It should highlight key data and provide quick links.

## Panels

- Show **additional information in a side panel on the right** for each item on a page.

- If your panel updates based on a selection, **add a title** with the selected item's name.

- Show **forms in a pop-up** panel.

- Always choose the **same width** in your actions if you are using the same panel more than once.

- Every panel should have a **close button in the top-right corner**. Close icon is enough, no need to add a label.

- If you have too much information in one panel, you can split it into multiple panels and **use the header bar as tabs**.

- **Use the “As overlay” option** when opening a panel.

- Do not use panels as pages

## Actions

- Only include **one access point** for a certain action per page/panel.

- **Confirm** important data change actions with a notification.

## Components

- Make sure you **choose the right visualization** for your data.

- Make sure you add **[a custom empty component message](xref:Tutorial_Dashboards_Displaying_a_custom_empty_component_message)** that guides your user.

### Title (Web component)

- Titles are optional on pages, depending on whether users will need **more context information** about what they are looking at.

- Start from this title:

```html
<div style="height: 100%; display: flex; flex-direction: column; justify-content: center; font-family: Segoe UI,Segoe UI Web Regular,Segoe UI Symbol,Helvetica Neue,BBAlpha Sans,S60 Sans,Arial,sans-serif;">
  <H1 style="color: #151A22; margin: 0; font-weight: 400; font-size: 24px">People</H1>
  <p style="color: #44484E; margin: 0; font-weight: 400; font-size: 16px">
  An overview of all managed people.
  </p>
</div>
```

- **Do not repeat the Low-Code App name** as a title on a page.

- Do not make the titles **too big**.

- Use **the same title styles** in the whole Low-Code App.

- Place titles in the exact **same place on every page**.

- **Do not add icons** in your title.

### Buttons

- Label your buttons with **enough context** so users understand exactly what the action will do.

- **Add an icon** whenever possible.

### Images

- Do not add customer logos.

- Do not add unnecessary images.

- **Only use dynamic images** with a web component on a page or HTML tool in templates.

### Forms (DOM & IAS components)

- Make sure forms are always shown **in a pop-up panel**.

- Place any **form actions**, such as 'Save' or 'Delete', **at the bottom of the form**.

- **Enable “Fit to view”** option on a pop-up panel with a form.

- Make sure labels are shown above the inputs in DOM forms by **setting the pop-up width to 35%**.

- If the DOM instance shown in the form has states, **show a stepper component at the top** showing the current state of the instance.

### Tables

- **Limit the number of columns** so all columns shown fit the screen size you're creating a Low-Code App for. Show additional information in a panel.

- **Add a component title** to your table mentioning which kind of data it is.

- Do not show IDs.

- **Rename your column titles** to straightforward, clear but concise names.

- If you need a selected state, make sure it's **clear on the full row**.

- Add actions in the **first or last column** of your table.

- Use **49px row height**.

- Only use icons next to values if the **icon changes based on the value**.
