---
uid: Customize_Component_Layout
---

# Customizing the component layout

Each component in a dashboard or low-code app has a number of default options. By default, the configuration of these options is determined by the layout of the [dashboard](xref:Configuring_the_dashboard_layout) or [low-code app](xref:LowCodeApps_Layout) on the whole. However, it is possible to override this. The way this can be done depends on the DataMiner version.

1. Select the component and go to the ***Layout*** pane on the right.

1. In the ***General*** section, you can configure basic component information:

   - *Title*: Enter a custom title that appears in the top-left corner of the component.

   - *Configuration name*: Available from DataMiner 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9 onwards<!--RN 43453-->. Enter a custom name for the component. Using a custom name can make it easier to identify components when configuring a dashboard or low-code app. When you leave this setting empty, the default name consists of the type of visualization followed by a sequence number (e.g. `Table 3`).

1. In the ***Styles*** section, you can then change the component theme in different ways:

   - To **change the component theme** to one of the different existing component themes for your current dashboard or low-code app theme, click the current theme and select a different theme in the drop-down list.

   - To **customize the component theme**, enable the *Customize* toggle button to customize the currently selected theme.

     - In the *Title* section, specify the following:

       - *Font*: Select a font type in the drop-down list

       - *Font size*: The size (in pixels) of the title

       - *Alignment*: Left, center, right, or justify

       You can also further customize your title with *Bold*, *Italics*, and *Underline*.

     - In the *Colors* section, specify a custom background color and/or font color, either by specifying the color in RGB format, by entering the hex value or HTML color name, or by using the color picker box on the right.

       Under *Colors* > *Accent color* (available from DataMiner 10.4.0 [CU12]/10.5.3 onwards<!--RN 41859-->), you can specify an accent color. If a component supports an accent color (e.g. the [toggle component](xref:Toggle)), it will inherit the selected color. By default, this is set to *Default*, meaning the accent color will match the theme of the dashboard or low-code app.

       Under *Colors* > *Data colors* or *Colors* > *Color palette* (prior to DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7<!--RN 39739-->), you can customize additional component colors, e.g. for the lines in a line chart.

       From DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7 onwards<!--RN 39739-->, under *Colors* > *Data colors*, you can specify conditional colors. If a display label of the data matches the specified text, that data will inherit the conditional color. These conditional colors override the normal data colors.

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
       > If a smaller value than the dashboard's or low code app's default value is configured for these settings, it will not be taken into account.

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

     > [!NOTE]
     > When you have customized a component theme, you can also save it, so that it becomes available with the other component themes for the current dashboard or low-code app theme. To do so, click *Save as component theme* and specify the name of the theme. However, note that this is only possible if the dashboard or low-code app is currently using a saved theme. If it is not, you will first need to save the dashboard or low-code app theme before you can save the component theme.
