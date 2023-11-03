---
uid: Customize_Component_Layout
---

# Customizing the component layout

Each component in a dashboard or low-code app has a number of default options. By default, the configuration of these options is determined by the layout of the [dashboard](xref:Configuring_the_dashboard_layout) or [low-code app](xref:LowCodeApps_Layout) on the whole. However, it is possible to override this. The way this can be done depends on the DataMiner version.

## [From DataMiner 10.0.8 onwards](#tab/tabid-1)

1. Select the component and go to the ***Layout*** tab on the right.

1. In the ***Styles*** section, you can then change the component theme in different ways:

   - To **change the component theme** to one of the different existing component themes for your current dashboard or low-code app theme, click the current theme and select a different theme in the drop-down list.

   - To **customize the component theme**, enable the *Customize* toggle button to customize the currently selected theme.

     - In the *Title* section, specify the following:

       - *Font*: Select a font type in the drop-down list

       - *Font size*: The size (in pixels) of the title

       - *Alignment*: Left, center, right, or justify

       You can also further customize your title with *Bold*, *Italics*, and *Underline*.

     - In the *Colors* section, specify a custom background color and/or font color, either by specifying the color in RGB format or by using the color picker box on the right.

       From DataMiner 10.0.12 onwards, under *Colors* > *Color palette*, you can customize additional component colors, e.g. for the lines in a line chart.

     - In the *Spacing* section, specify the following:

       - *Vertical margin*: The amount of space (in pixels) above the component.

       - *Horizontal margin*: The amount of space (in pixels) next to the component.

       - *Vertical padding*: The amount of space (in pixels) that should be left free at the top of the bottom inside the component.

       - *Horizontal padding*: The amount of space (in pixels) that should be left free on the left and right side of the component.

       > [!NOTE]
       > If a smaller value than the dashboard's or low code app's default value is configured for these settings, it will not be taken into account.

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

     > [!NOTE]
     > When you have customized a component theme, you can also save it, so that it becomes available with the other component themes for the current dashboard or low-code app theme. To do so, click *Save as component theme* and specify the name of the theme. However, note that this is only possible if the dashboard or low-code app is currently using a saved theme. If it is not, you will first need to save the dashboard or low-code app theme before you can save the component theme.

## [Prior to DataMiner 10.0.8](#tab/tabid-2)

1. Select the component and go to the *Layout* tab on the right.

1. Clear the checkbox *Inherit from dashboard*.

1. Configure the following options in the expandable sections according to your preference:

    - In the *Title* section, select the alignment for the component title and specify whether a border should be displayed around the title.

    - In the *Colors* section specify a custom background color and/or font color, either by specifying the color in RGB format or by using the color picker box on the right.

    - In the *Container* section, specify the following:

        - *Vertical margin*: The amount of space (in pixels) above the component.

        - *Horizontal margin*: The amount of space (in pixels) next to the component.

        - *Vertical padding*: The amount of space (in pixels) that should be left free at the top of the bottom inside the component.

        - *Horizontal padding*: The amount of space (in pixels) that should be left free on the left and right side of the component.

        > [!NOTE]
        > If a smaller value than the dashboard's or low code app's default value is configured for these settings, it will not be taken into account.

    - In the *Borders* section, select the type of border that should be displayed around the components.

    - In the *Shadow* section, select the size of the shadow displayed behind the components.

Depending on the visualization, additional layout options may be available. For more information, refer to the relevant section in [Available visualizations](xref:Available_visualizations).

***
