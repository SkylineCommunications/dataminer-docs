---
uid: Configuring_the_dashboard_layout
---

# Configuring the dashboard layout

The layout of a dashboard can be configured on two levels:

- The layout of the dashboard on the whole. See [Customizing the dashboard theme](#customizing-the-dashboard-theme).

- Overrides for each specific component. See [Configuring dashboard components](xref:Configuring_dashboard_components).

## Customizing the dashboard theme

The theme of the dashboard determines which colors are used in the dashboard.

- To create a new dashboard theme, see [Creating a new dashboard theme](#creating-a-new-dashboard-theme).

- To override a dashboard theme, see [Overriding a dashboard theme](#overriding-a-dashboard-theme).

- To apply an existing theme, see [Applying an existing theme to a dashboard](#applying-an-existing-theme-to-a-dashboard).

> [!NOTE]
> To manage the available dashboard themes, click the cogwheel button in the header bar of the app. This will display an overview of all the themes, with the option to modify or delete them.

### Creating a new dashboard theme

#### [From DataMiner 10.0.2 onwards](#tab/tabid-1)

1. Click the user icon in the top-right corner of the Dashboards app and select the *Configuration* or *Settings* option.

1. In the *Dashboards settings* window, click the *New theme* button.

   > [!NOTE]
   > From DataMiner 10.0.12 onwards you can also create a new theme directly from the Layout pane of a dashboard, using the *New theme* button there. The available options will be the same as described below.

1. In the *Theme* name box, specify a unique name for the new theme.

1. Configure the theme:

   - Set a background color in RGB format.

   - Add and configure the other colors of the theme (in RGB format).

   - Configure the component layout:

     From DataMiner 10.0.8 onwards, you can configure several component themes in the *Component themes* section:

     - To add a component theme, click *Add component theme* or click the duplicate icon on the right side of an existing theme.

     - To remove a component theme, click the red delete icon to the right side of the theme. This is not possible for the default theme.

     - Select a component theme to configure it in the *Component styles* section.

     The following settings can be configured for each component theme:

     - Under *Component theme name*, you can specify a custom name for the theme. This is not possible for the default theme.

     - In the *Title* section, you can configure the default layout for component titles, including the font, font size, alignment, and basic formatting options.

     - In the *Colors* section, you can set the default background color and font color for the components. Under *Color palette*, you can configure additional columns, e.g. for the lines in a line chart component.

     - In the *Spacing* section (formerly called the *Containers* section), you can configure the margins, i.e. the amount of space (in pixels) around the components, as well as the padding, i.e. the amount of space (in pixels) that should be left free within the components.

     - In the *Borders* section, you can select the type of border that should be displayed around the components. From DataMiner 10.0.9 onwards, you can also select for which sides of a component a border should be displayed, e.g. at the top and bottom only.

     - In the *Shadow* section, you can select the size of the shadow displayed behind the components.

1. Prior to DataMiner 10.2.8/10.2.0 [CU6], to set the new dashboard theme as the default theme, click the *Set as default* toggle button.

   > [!NOTE]
   > From DataMiner 10.2.8/10.2.0 [CU6] onwards, you can set a theme as the default by hovering the mouse pointer over the theme in the settings window and selecting *Set as default*.

1. When the theme is fully configured, click *Save*.

#### [Earlier versions](#tab/tabid-2)

1. Make sure the dashboard is in edit mode and no components are selected. See [Editing a dashboard](xref:Editing_a_dashboard).

1. In the panel on the right, select the *Layout* tab.

1. In the *Custom* section of the panel, specify the following custom colors according to your preference, either by specifying an RGB value or by using the color picker boxes on the right:

    - *Background*: The background color of the dashboard itself.

    - *Component background*: The default background color for each of the components.

    - *Font color*: The default color of the font used in the dashboard.

    - *Theme colors*: Expand this section to specify up to 10 custom theme colors, which will determine which secondary colors are used within the components.

        At the top of the *Custom* section, the selected theme colors are displayed for your reference.

1. If you wish to use this same dashboard theme in other dashboards, specify a name in the *Theme name* box and click *Save theme*.

***

### Overriding a dashboard theme

It is possible to customize the theme for one dashboard by overriding the applied theme, without creating or applying a new theme. Note that this is no longer possible from DataMiner 10.0.12 onwards.

#### [From DataMiner 10.0.2 onwards](#tab/tabid-1)

1. Make sure the dashboard is in edit mode and no components are selected. See [Editing a dashboard](xref:Editing_a_dashboard).

1. In the panel on the right, select the *Layout* tab.

1. Select the *Override* checkbox.

1. Specify the colors and component layout according to your preference. See [Creating a new dashboard theme](#creating-a-new-dashboard-theme).

> [!NOTE]
> If you do want to save the modified dashboard theme as a new theme, click *Save as new theme*. However, if you only want to customize the theme for a single dashboard, there is no need to click this button.

#### [Earlier versions](#tab/tabid-2)

To configure a dashboard to use different colors without creating a theme, follow the steps detailed in the section [Creating a new dashboard theme](#creating-a-new-dashboard-theme), but do not apply the last step.

***

### Applying an existing theme to a dashboard

1. Make sure the dashboard is in edit mode and no components are selected. See [Editing a dashboard](xref:Editing_a_dashboard).

1. In the panel on the right, select the *Layout* tab.

1. Click the box *Search for a theme*. From DataMiner 10.0.12 onwards, just click the box indicating the currently used theme.

   A list of available themes will be displayed below the box. Enter a term in the box to filter the displayed themes (prior to DataMiner 10.0.12 only).

1. Select the theme you wish to use.

## Configuring the default component layout

### [From DataMiner 10.0.2 onwards](#tab/tabid-1)

From DataMiner 10.0.2 onwards, the default component layout is considered part of the default theme. It can be configured via the dashboards settings. See [Customizing the dashboard theme](#customizing-the-dashboard-theme).

### [Earlier versions](#tab/tabid-2)

To configure the default layout for each of the components in a dashboard:

1. Make sure the dashboard is in edit mode and no components are selected. See [Editing a dashboard](xref:Editing_a_dashboard).

1. In the panel on the right, select the *Layout* tab.

1. Configure the following options in the expandable sections according to your preference:

   - In the *Title* section, you can configure the default layout for component titles, including the font, font size, alignment, and basic formatting options.

   - In the *Container* section, specify the following:

     - *Show indicators*: Enable this option to visualize the margin, padding and component zones of each component.

     - *Vertical margin*: The amount of space (in pixels) above the components.

     - *Horizontal margin*: The amount of space (in pixels) next to the components.

     - *Vertical padding*: The amount of space (in pixels) that should be left free at the top of the bottom inside the components.

     - *Horizontal padding*: The amount of space (in pixels) that should be left free on the left and right side of the components.

   - In the *Borders* section, select the type of border that should be displayed around the components.

   - In the *Shadow* section, select the size of the shadow displayed behind the components.

> [!NOTE]
> For each separate component, it is possible to override this default layout. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).

***
