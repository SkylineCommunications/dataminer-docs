---
uid: Configuring_the_dashboard_layout
---

# Configuring the dashboard layout

The layout of a dashboard can be configured on two levels:

- The layout of the dashboard on the whole. See [Customizing the dashboard theme](#customizing-the-dashboard-theme).

- Overrides for each specific component. See [Configuring dashboard components](xref:Customize_Component_Layout).

## Customizing the dashboard theme

The theme of the dashboard determines which colors are used in the dashboard.

- To create a new dashboard theme, see [Creating a new dashboard theme](#creating-a-new-dashboard-theme).

- To apply an existing theme, see [Applying an existing theme to a dashboard](#applying-an-existing-theme-to-a-dashboard).

> [!NOTE]
> To manage the available dashboard themes, click the cogwheel button in the header bar of the app. This will display an overview of all the themes, with the option to modify or delete them.

### Creating a new dashboard theme

1. Click the user icon in the top-right corner of the Dashboards app and select the *Configuration* or *Settings* option.

1. In the *Dashboards settings* window, click the *New theme* button.

   > [!NOTE]
   >
   > - You can also create a new theme directly from the *Layout* pane of a dashboard, using the *New theme* button there. The available options will be the same as described below.
   > - If a theme already exists that looks similar to what you have in mind, use the duplicate button to start from a duplicate of that theme.
   >
   >   ![Duplicate theme button](~/dataminer/images/Dashboards_duplicate_theme.png)<br>*Dashboard settings in DataMiner 10.5.4*

1. In the *Theme* name box, specify a unique name for the new theme.

1. Configure the theme:

   - Set a background color, either by specifying the color in RGB format, by entering the hex value or HTML color name, or by using the color picker box.

   - Configure the component layout:

     You can configure several component themes in the *Component themes* section:

     - To add a component theme, click *Add component theme* or click the duplicate icon on the right side of an existing theme.

     - To remove a component theme, click the red delete icon to the right side of the theme. This is not possible for the default theme.

     - Select a component theme to configure it in the *Component styles* section.

     The following settings can be configured for each component theme:

     - Under *Component theme name*, you can specify a custom name for the theme. This is not possible for the default theme.

     - In the *Title* section, you can configure the default layout for component titles, including the font, font size, alignment, and basic formatting options.

     - In the *Colors* section, you can set the default background color and font color for the components. From DataMiner 10.4.0 [CU12]/10.5.3 onwards<!--RN 41859-->, you can also set the accent color. If a component supports an accent color (e.g., the toggle component), it will inherit the selected color. By default, this is set to *Default*, meaning the accent color will match the theme of the dashboard. Under *Data colors* or *Color palette* (prior to DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7<!--RN 39739-->), you can configure additional colors, e.g., for the lines in a line chart component.

       From DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7 onwards<!--RN 39739-->, components displaying the same data use the same data color by default. Prior to DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7, each component independently takes the next color from the theme's assigned color palette.

       > [!NOTE]
       >
       > - To determine if data is considered identical, compare the display labels. If multiple components display the same labeled data, they will all use the same color for this label.
       > - Data may vary across different sessions. Refreshing the dashboard may result in different colors being used for the same data. To ensure consistent colors across multiple sessions, you can define conditional colors in a [component theme's color palette](xref:Customize_Component_Layout) by binding colors to specific regular expressions that match the display labels of the data.
       > - If you want a single color to be used across all components, include only one color in the component theme's data colors/color palette.

     - In the *Spacing* section (formerly called the *Containers* section), you can configure the margins, i.e., the amount of space (in pixels) around the components, as well as the padding, i.e., the amount of space (in pixels) that should be left free within the components.

     - In the *Borders* section, you can select the type of border that should be displayed around the components. You can also select for which sides of a component a border should be displayed, e.g., at the top and bottom only.

     - In the *Shadow* section, you can select the size of the shadow displayed behind the components.

1. Prior to DataMiner 10.2.8/10.2.0 [CU6], to set the new dashboard theme as the default theme, click the *Set as default* toggle button.

   > [!NOTE]
   > From DataMiner 10.2.8/10.2.0 [CU6] onwards, you can set a theme as the default by hovering the mouse pointer over the theme in the settings window and selecting *Set as default*.

1. When the theme is fully configured, click *Create* or *Save*, depending on your DataMiner version<!--RN 38278-->.

### Applying an existing theme to a dashboard

1. Make sure the dashboard is in edit mode and no components are selected. See [Editing a dashboard](xref:Editing_a_dashboard).

1. In the panel on the right, select the *Layout* pane.

1. Click the box indicating the currently used theme.

   A list of available themes will be displayed below the box.

1. Select the theme you wish to use.

## Configuring the default component layout

The default component layout is considered part of the default theme. It can be configured via the dashboards settings. See [Customizing the dashboard theme](#customizing-the-dashboard-theme).
