---
uid: LowCodeApps_Layout
---

# Configuring the app layout

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

1. Make sure the low-code app page is in edit mode and no components are selected. See [Editing an app](xref:Editing_custom_apps).

1. In the panel on the right, select the *Layout* pane.

1. Click the box indicating the currently used theme.

   A list of available themes will be displayed below the box.

1. Select the theme you wish to use.

### Creating a new theme for a low-code app page

1. Make sure the low-code app page is in edit mode and no components are selected. See [Editing an app](xref:Editing_custom_apps).

1. In the panel on the right, select the *Layout* pane.

1. Click *+ New theme*.

1. In the *New theme* pop-up window:

   - Specify a **name** in the *Theme name* box.

   - Specify the **background color** according to your preference, either by specifying the color in RGB format, by entering the hex value or HTML color name, or by using the color picker box on the right.

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

     - In the *Color* section, specify the following:

       - *Background color*: Specify a custom background color, either by specifying the color in RGB format, by entering the hex value or HTML color name, or by using the color picker box on the right.

       - *Font color*: Specify a custom font color, either by specifying the color in RGB format, by entering the hex value or HTML color name, or by using the color picker box on the right.

       - *Accent color*: Available from DataMiner 10.4.0 [CU12]/10.5.3 onwards<!--RN 41859-->. If a component supports an accent color (e.g., the toggle component), it will inherit the selected color. By default, this is set to *Default*, meaning the accent color will match the theme of the low-code app.

       - *Data colors*/*Color palette* (prior to DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7<!--RN 39739-->): Customize additional component colors, e.g., for the lines in a line chart.

         From DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7 onwards<!--RN 39739-->, components displaying the same data use the same data color by default. Prior to DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7, each component independently takes the next color from the theme's assigned color palette.

         > [!NOTE]
         >
         > - To determine if data is considered identical, compare the display labels. If multiple components display the same labeled data, they will all use the same color for this label.
         > - Data colors may vary across different sessions. Refreshing the low-code app may result in different colors being used for the same data. To ensure consistent colors across multiple sessions, you can define conditional colors in the *Component Styles* section of a low-code app page theme or in a [component theme's color palette](xref:Customize_Component_Layout) by binding colors to specific regular expressions that match the display labels of the data.
         > - If a low-code app created prior to DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7 relies on the color order assigned in the theme's color palette, you will need to manually bind these colors to the data using conditional coloring to achieve the same result.
         > - If you want a single color to be used across all components, include only one color in the component theme's data colors/color palette.

       - *Conditional colors*: Available from DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7 onwards<!--RN 39739-->. If a display label of the data matches the specified text, that data will inherit the conditional color. These conditional colors override the normal data colors.

         To add a conditional color:

         1. Expand the *Conditional colors* section below *Data colors*.

         1. Select *Add conditional color*.

         1. Enter a regular expression to match the display label. For example, entering `Tot` will match data labeled `Total`, while entering `^Tot$` will only match data labeled `Tot`.

         1. Choose a custom color, either by specifying the color in RGB format, by entering the hex value or HTML color name, or by using the color picker box on the right.

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

       - *Sides*: Select which sides of the component border should be shown.

       - *Thickness*: The thickness (in pixels) of the border that should be displayed around the components.

       - *Color*: Specify a custom border color, either by specifying the color in RGB format, by entering the hex value or HTML color name, or by using the color picker box on the right.

     - In the *Shadow* section, select the size of the shadow displayed behind the components.

1. To add an additional component theme, click *+ Add component theme*. The theme name and background color remain the same, but all adjustments made to the component styles will be saved separately from the default component theme.

   > [!NOTE]
   >
   > - To duplicate a component theme, click the ![Duplicate](~/dataminer/images/Duplicate_Theme.png) button next to it.
   > - To delete a component theme, click the ![Delete](~/dataminer/images/Delete_Theme.png) button next to it. This is not possible for the default theme.

1. Click *Create* or *Save* (depending on your DataMiner version<!--RN 38278-->) in the lower-right corner to save all changes.

   > [!NOTE]
   >
   > - To stop editing the theme and reset all changes, click *Cancel* in the lower-right corner.
   > - To set the new theme as the default theme, click the toggle button next to *Set as default*.
