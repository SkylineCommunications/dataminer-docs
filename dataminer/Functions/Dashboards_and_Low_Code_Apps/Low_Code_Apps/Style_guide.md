---
uid: LCA_Style_guide
reviewer: Rens Ampe
---

# Dashboards and Low-Code Apps style guide

Use this documentation as a basis to build or improve dashboards and low-code apps. This guide will allow you to create intuitive, visually appealing solutions, ensuring that users experience consistent behavior across different dashboards and low-code apps. For DevOps Engineers at Skyline, adhering to this style guide is mandatory. Note that many things will only be applicable for low-code apps, as dashboards have more limited possibilities.

> [!NOTE]
> If you come across something that has not been added to this style guide yet, [create a pull request](xref:CTB_Quick_Edit) to update this documentation.

> [!TIP]
> Are you new to designing low-code apps and dashboards? This will help you get started:
>
> - [Kata #19: Transform low-code apps into visual delights](https://community.dataminer.services/courses/kata-19/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)
> - Tutorial: [Creating a visually appealing and user-friendly low-code app](xref:Tutorial_App_Design)

## Themes

- When you choose the main color for a low-code app, ensure that there is enough contrast between the header, sidebar, and buttons.

- When you create a new app or dashboard, always start from a default theme. From DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4 onwards<!--RN 42179-->, the following default themes are available:

  - Skyline Light - White

  - Skyline Dark

- Use the same theme consistently across all pages and panels.

- [Customize component themes](xref:Customize_Component_Layout) only to make minor adjustments, such as removing padding inside a maps component.

- Always use the *Default* component style, except for the following components, where you should use the *Transparent* style:

  - [Text](xref:DashboardText)

  - [Image](xref:DashboardImage)

  - [Button](xref:DashboardButton)

  - [All components of the *Basic controls* category](xref:Available_visualizations#basic-controls)

- The default component styles include a predefined set of data colors. If you add custom colors to the color set, make sure they are complementary to the existing ones.

- Use the same color to represent the same data consistently across the app. To do this, configure [conditional colors](xref:LowCodeApps_Layout#creating-a-new-theme-for-a-low-code-app-page) as part of the theme.

## Templates

- Use the interface colors provided in the default themes to enhance usability and readability The table below shows how these colors are applied in both default themes. Combinations are suggested, but you can mix and match depending on your needs.

  | Purpose | Skyline Light - White  | Skyline Dark |
  |--|--|--|
  | Component background | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#FDFDFD" stroke="#C5C6C8"/></svg> #FDFDFD | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#23272F" stroke="#C5C6C8"/></svg> #23272F |
  | Secondary component background | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#F6F6F6" stroke="#C5C6C8"/></svg> #F6F6F6 | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#1C2129" stroke="#C5C6C8"/></svg> #1C2129 |
  | Page background | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#EFF0F0" stroke="#C5C6C8"/></svg> #EFF0F0 | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#151A22" stroke="#C5C6C8"/></svg> #151A22 |
  | 2nd background hover | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#E8E8E9" stroke="#C5C6C8"/></svg> #E8E8E9 | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#30353C" stroke="#C5C6C8"/></svg> #30353C |
  | Component border | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#E1E1E2" stroke="#C5C6C8"/></svg> #E1E1E2 | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#383C43" stroke="#C5C6C8"/></svg> #383C43 |
  | Secondary border | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#D3D4D5" stroke="#C5C6C8"/></svg> #D3D4D5 | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#44484E" stroke="#C5C6C8"/></svg> #44484E |
  | Hover state for component border | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#C5C6C8" stroke="#C5C6C8"/></svg> #C5C6C8 | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#4F5258" stroke="#C5C6C8"/></svg> #4F5258 |
  | Secondary hover state for component border | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#B8BABC" stroke="#C5C6C8"/></svg> #B8BABC | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#5B5E64" stroke="#C5C6C8"/></svg> #5B5E64 |
  | Disabled text | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#A0A2A6" stroke="#C5C6C8"/></svg> #A0A2A6 | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#727579" stroke="#C5C6C8"/></svg> #727579 |
  | Quiet text | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#727579" stroke="#C5C6C8"/></svg> #727579 | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#A0A2A6" stroke="#C5C6C8"/></svg> #A0A2A6 |
  | Subtle text | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#44484E" stroke="#C5C6C8"/></svg> #44484E | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#CECFD1" stroke="#C5C6C8"/></svg> #CECFD1 |
  | Default text | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#151A22" stroke="#C5C6C8"/></svg> #151A22 | <svg xmlns="http://www.w3.org/2000/svg" width="13" height="16" viewBox="0 0 13 16" fill="none"><rect x="0.5" y="0.5" width="12" height="12" rx="2.5" fill="#FDFDFD" stroke="#C5C6C8"/></svg> #FDFDFD |

- For selected states or call-to-action elements, use your app's main color or `#2563EB`.

  - For a selected state, use the color as a border and apply a background overlay using the same color with 10% opacity.

  - For a call to action, use the color as a background and pair it with the default light or dark text color, depending on contrast.

- Only use the default font.

- Limit templates to a maximum of 3 visible actions. If more actions are needed, add them behind a context menu.

  > [!TIP]
  > For an example, refer to [Styling a table component - Step 7: Add a context menu](xref:Tutorial_Apps_Style_A_Table#step-7-add-a-context-menu)

- Use tooltips or `title` attributes in HTML layers to clarify layered content.

- If your visualization does not have fixed dimensions, make sure your template is fully responsive. Use techniques such as CSS Flexbox, container queries, the `text-overflow` property, etc.

> [!TIP]
> Creating a template from scratch? You can find inspiration on [Dribbble](https://dribbble.com/search/shots/popular/product-design?q=cards), sketch and structure parts of your template in [Figma](https://figma.com), and test your HTML/CSS layers in [Codepen](http://codepen.io/).

## Layout

- Make sure components on a page/panel are aligned vertically and horizontally.

- Always use a 50-column grid for your page layout.

- Leave one column of spacing on the left and right sides of every page.

- Apply consistent spacing between components.

- Avoid clutter. Tailor the complexity of the interface to your target audience (e.g. technical users vs. management).

- Use the *fit to view* option when the content fits the screen.

- Adjust component sizes to the content they display (e.g. avoid oversized ring and state components or undersized tables and timelines filled with data).

- Before you publish a low-code app, test your layout on different screen resolutions to ensure that it displays correctly on all target devices.

## Navigation

- Use the sidebar as the main navigation to the different pages defined in the app. When there are too many pages in your sidebar, or if you want to show the same data in another way, use buttons in the header bar as tabs to open hidden pages.

  > [!NOTE]
  > When up to two components fill an entire page with no margins, you can place action buttons on the left side of the header bar. Just do not use them as tabs.

- If you are using buttons in the header bar as tabs, make sure you **show a title on each page** or **use a circle icon that is filled** on the selected page.

- Place the "About" page **at the bottom** of the sidebar and **use the info circle icon**.

- If your app has more than 10 pages (including sidebar and header tabs), **add an overview page**. It should highlight key data and provide quick links.

## Panels

- Show **additional information in a side panel on the right** for each item on a page.

- If your panel updates based on a selection, **add a title** with the selected item's name.

- Show **forms in a pop-up** panel.

- Always choose the **same width** in your actions if you are using the same panel more than once.

- Every panel should have a **close button in the top-right corner**. An icon is enough; the button does not need a label.

- If you have too much information in one panel, you can split it into multiple panels and **use buttons in the header bar as tabs**.

- **Use the “As overlay” option** when opening a panel.

- Do not use panels as pages.

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

- **Do not repeat the low-code app name** as a title on a page.

- Do not make the titles **too big**.

- Use **the same title styles** across your low-code app.

- Place titles in the exact **same place on every page**.

- **Do not add icons** in your title.

### Buttons

- Label your buttons with **enough context** so users understand exactly what each action will do.

- **Add an icon** whenever possible.

### Images

- Do not add customer logos.

- Do not add unnecessary images.

- **Only use dynamic images** with a web component on a page or HTML tool in templates.

### Forms (DOM and IAS components)

- Make sure forms are always shown **in a pop-up panel**.

- Place any **form actions**, such as "Save" or "Delete", **at the bottom of the form**.

- **Enable the "Fit to view"** option on a pop-up panel with a form.

- Make sure labels are shown above the inputs in DOM forms by **setting the pop-up width to 35%**.

- If the DOM instance shown in the form has states, **show a stepper component at the top** showing the current state of the instance.

### Tables

- **Limit the number of columns** so all columns shown fit the screen size for which the app is intended. Show any additional information in a panel.

- **Add a component title** to your table mentioning which kind of data it is.

- Do not show IDs.

- **Rename your column titles** to straightforward, clear but concise names.

- If you need a selected state, make sure it is **clear on the full row**.

- Add actions in the **first or last column** of your table.

- Use **49px row height**.

- Only use icons next to values if the **icon changes based on the value**.
