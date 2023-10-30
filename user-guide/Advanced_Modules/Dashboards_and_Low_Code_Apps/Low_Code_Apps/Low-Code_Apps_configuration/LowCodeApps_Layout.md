---
uid: LowCodeApps_Layout
---

# Configuring the low-code app layout

## Customizing the icon and color of an app

To customize the color and icon for a low-code app, select the icon in the top-left corner.

You can then:

- Select any of the displayed icons to use that icon instead.

- Click the upload button to upload a custom icon of your own.

- Use the color picker to specify a different color for the app.

To close the color and icon editor, click the icon in the top-left corner again.

## Customizing the theme for a low-code app page

The theme of a low-code app page determines which colors are used on the page.

To apply an existing theme, see [Applying an existing theme to a low-code app page](#applying-an-existing-theme-to-a-low-code-app-page).

To create a new theme, see [Creating a new theme for a low-code app page](#creating-a-new-theme-for-a-low-code-app-page).

### Applying an existing theme to a low-code app page

1. Make sure the low-code app page is in edit mode and no components are selected. See [Editing a low-code application](xref:Editing_custom_apps).

1. In the panel on the right, select the *Layout* tab.

1. Click the box indicating the currently used theme.

   A list of available themes will be displayed below the box.

1. Select the theme you wish to use.

### Creating a new theme for a low-code app page

1. Make sure the low-code app page is in edit mode and no components are selected. See [Editing a low-code application](xref:Editing_custom_apps).

1. In the panel on the right, select the *Layout* tab.

1. Click *+ New theme*.

1. In the *New theme* pop-up window:

   - Specify a **name** in the *Theme name* box.

   - Specify the **background color** according to your preference, either by specifying an RGB value or by using the color picker box on the right.

   - In the ***Component Styles*** section, you can change the component theme in different ways.

     > [!NOTE]
     > A preview of what the component will look like after saving your changes is displayed under *Component themes*.

     - Specify a component theme name.

       > [!NOTE]
       > You cannot modify the component theme name when you are editing the default theme.

     - In the *Title* section, specify the following:

       - *Font*: Select a font type in the dropdown list.

       - *Font size*: The size (in pixels) of the title.

       - *Alignment*: Left, center, right, or justify.

       You can also further customize your title with *Bold*, *Italics*, and *Underline*.

     - In the *Color* section, specify a custom background color and/or font color, either by specifying the color in RGB format or by using the color picker box on the right.

       From DataMiner 10.0.12 onwards, under *Color palette*, you can customize additional component colors, e.g. for the lines in a line chart.

     - In the *Spacing* section, specify the following:

       - *Vertical margin*: The amount of space (in pixels) above the component.

       - *Horizontal margin*: The amount of space (in pixels) next to the component.

       - *Vertical padding*: The amount of space (in pixels) that should be left free at the top of the bottom inside the component.

       - *Horizontal padding*: The amount of space (in pixels) that should be left free on the left and right side of the component.

       > [!NOTE]
       > If a smaller value than the dashboard's default value is configured for these settings, it will not be taken into account.

     - In the *Border* section, specify the following:

       - *Roundness*: The roundness (in pixels) of the border that should be displayed around the components.

       - *Style*:

         - No border

         - Line

         - Dashes

         - Dots

       - *Sides*: Select which sides of the component border should be shown (from DataMiner 10.0.9 onwards).

       - *Thickness*: The thickness (in pixels) of the border that should be displayed around the components.

       - *Color*: Specify a custom border color, either by specifying the color in RGB format or by using the color picker box on the right.

     - In the *Shadow* section, select the size of the shadow displayed behind the components.

1. To add an additional component theme, click *+ Add component theme*. The theme name and background color remain the same, but all adjustments made to the component styles will be saved separately from the default component theme.

   > [!NOTE]
   >
   > - To duplicate a component theme, click the ![Duplicate](~/user-guide/images/Duplicate_Theme.png) button next to it.
   > - To delete a component theme, click the ![Delete](~/user-guide/images/Delete_Theme.png) button next to it.

1. Click *Save* in the lower right corner to save all changes.

   > [!NOTE]
   >
   > - To stop editing the theme and reset all changes, click *Cancel* in the lower right corner.
   > - To set the new theme as the default theme, click the toggle button next to *Set as default*.
