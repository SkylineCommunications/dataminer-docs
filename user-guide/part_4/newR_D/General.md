## General

This category contains the following visualizations:

- [Block](#block)

- [Button](#button)

- [Button panel](#button-panel)

- [Clock (analog)](#clock-analog)

- [Clock (digital)](#clock-digital)

- [Generic map](#generic-map)

- [Group](#group)

- [Image](#image)

- [Text](#text)

- [Web](#web)

### Block

This component consists of an empty block, which can be used as a divider between other components.

In the *Component* > *Layout* tab, only the default options are available for this component. See [Customizing the component layout](Configuring_dashboard_components.md#customizing-the-component-layout).

### Button

> [!WARNING]
> This feature is currently still in preview. For more information, see *[Soft-launch options](https://community.dataminer.services/documentation/soft-launch-options/)*.

This component is available in soft launch from DataMiner 10.0.3 onwards, if the soft-launch option *ReportsAndDashboardsButton* is enabled.

The component can be linked to one or more button parameters, so that users can click a button to execute a particular action.

To configure the component:

1. Apply a parameter data feed. See [Applying a data feed](Configuring_dashboard_components.md#applying-a-data-feed).

    You will only be able to select button parameters for the data feed. Several parameters can be added in the same component.

2. Fine-tune the component layout. In the *Component* > *Layout*, tab the following options are available:

    - The default options available for all components. See [Customizing the component layout](Configuring_dashboard_components.md#customizing-the-component-layout).

    - In case the component displays more than one parameter, in the *Advanced* > *Layout* section, you can adjust the way the different items are displayed:

        - *Layout*: Determines whether the different items are displayed next to each other or below each other. However, note that when the dashboard is used on a small screen, they will always be displayed below each other.

        - *Maximum rows per page*: Determines how many items can at most be displayed below each other on a single page.

        - *Maximum columns per page*: Determines how many items can at most be displayed next to each other on a single page.

    - The *Button text* option allows you to customize the text that should be displayed on the button. By default, the button displays the same text as in Cube.

3. Optionally, configure the following settings in the *Settings* tab:

    - To use a different polling interval for this component than the standard interval configured for the dashboard, in the *WebSocket settings* section, clear the checkbox and specify a different polling interval (in seconds).

    - In case the component displays more than one parameter, configure how the parameters should be grouped: by parameter, by element, by table index (if relevant) or by all of the above together.

    - In case the button triggers an Automation script, additional settings will also be available related to this script.

        - Depending on the script configuration, it may be possible to configure the parameters and/or dummies used in the script. For each of the parameters and dummies, a checkbox allows you to select whether these are required, i.e. whether the script can be executed only if these are filled in.

            > [!NOTE]
            > The input for an interactive Automation script in a dashboard can be specified by the user or retrieved via linked feeds. In case both are possible for the same component, user input always takes precedence.
            >
            > In case several feeds are linked to the component, they are considered in the order they were added. For example, if 2 feeds are used and the feed that was first added is applicable, the second feed will be ignored.

        - The standard options for script execution can be configured. See [Script execution options](../automation/Script_execution_options.md).

        - The following additional options are available:

            - *Ask for confirmation*: Determines whether the user will be asked for confirmation before the script is executed.

            - *Show success popup*: Determines whether a pop-up message is displayed when the script has been successfully executed. By default enabled.

            - *Custom success message*: Allows you to configure a custom message to be displayed when the script has been successfully executed.

### Button panel

> [!WARNING]
> This feature is currently still in preview. For more information, see *[Soft-launch options](https://community.dataminer.services/documentation/soft-launch-options/)*.

This component is available in soft launch from DataMiner 10.0.3 onwards, if the soft-launch option *ReportsAndDashboardsButtonPanel* is enabled.

This component will display a button panel with buttons representing the rows of a table parameter. Using an element with a custom button panel protocol, you can configure what kind of buttons are displayed and how the buttons are displayed. The following types of buttons can be configured:

- Simple buttons used only to set parameters.

- HTML buttons.

- Rotate buttons, resembling a control dial, used to decrement or increment the value of a particular parameter. The buttons can be used by dragging and dropping with the mouse, by using the arrow keys on the keyboard, or by sliding on a mobile device.

To avoid unwanted interaction with the buttons, they are not active while the button panel is being edited. However, it is possible to press them or rotate them in order to check what they look like when a user interacts with them. Buttons can also be locked in the button panel element to keep users from interacting with them.

#### Configuring the button panel component

To configure the component in the Dashboards app:

1. Make sure the button panel element is correctly configured. See [Configuring the button panel element](#configuring-the-button-panel-element).

2. Add the table parameter from the button panel element as the data feed.

3. Optionally, add a parameter feed as a filter, in order to determine which page is displayed.

4. In the *Component* > *Layout* tab, optionally configure the following options:

    - *Override number of columns*: When you select this option, the *Number of columns* option becomes available, which allows you to specify a different number of columns than is configured in the button panel element. The size and position of the buttons will then be adapted to match this configuration.

    - *Simple button text size*: Determines the size of the text displayed on buttons of type “Simple”.

5. In case the component should be set to configuration mode, in the *Component* > *Settings* tab, select *In configuration mode*.

    In that case, clicking a button will not execute the action of the button, but instead select the button. This selection can be linked to a button component that launches an Automation script. When that button is clicked, an interactive Automation script will be executed that can be used to configure the button of the button panel.

6. Optionally, to use a different polling interval for this component than the standard interval configured for the dashboard, in the *WebSocket settings* section, clear the checkbox and specify a different polling interval (in seconds).

#### Configuring the button panel element

In the button panel element, you can configure how the buttons should be displayed in a dashboard.

##### Button panel table

In the table listing the buttons, add the buttons that you want to display and specify their *Position*, *Height*, *Width*, etc. The available columns depend on the protocol configuration (see [Configuring the button panel element protocol](#configuring-the-button-panel-element-protocol)). However, the following possible columns are of particular note:

- *Lock Status*: *Locked* or *Unlocked*. Set to *Locked* to keep users from using the button.

- *Layout Type*: Determines the type of button. The following types are available:

    - *Simple*: Button with simple click action that performs a parameter set. Requires no further configuration.

    - *Rotate*: Buttons that allow users to increase or decrease a value, simulating an actual rotate button. The possible increment sizes are determined by the *Possible Operations* column. By default, at least a small increase and decrease are possible.

    - *HTML - Advanced*: HTML button, configured in the *Advanced Layout* column. For HTML buttons, a separate CSS parameter can also be available, which allows you to specify the CSS for all HTML buttons (allowing overrides in the *Advanced Layout* column).

    - *UI*: Available from DataMiner 9.6.13 onwards. This button will not trigger a parameter set when it is clicked, but is only used to display information.

- *Advanced Layout*: Allows you to configure the layout of the button using a JSON string. <br>For example:

    - For a button with custom HTML:

        ```txt
        {"buttonLayout":{                                                                  
            "alignHorizontal":"Left",                                                          
            "alignVertical":"Center",                                                          
            "html":"<div class='button-container'><div class='button'>Button</div></div>"},
         "version":"1.0.0.0"}                                                              
        ```

    - For a rotate button:

        ```txt
        {"rotateButtonLayout":{           
            "sliderOrientation":"Horizontal"},
         "version":"1.0.0.0"}             
        ```

    - For a button with images (supported from DataMiner 9.6.13 onwards):

        ```txt
        {"buttonLayout": {                                                                              
            "alignHorizontal": "Left",                                                                      
            "alignVertical": "Center",                                                                      
            "sources": [{"var":"$btn1", "image": "button1.png"}, {"var":"$btn2", "image": "button2.png"}],
            "html": "<div class='content'><img src='$btn1'><img src='$btn2'></div>"},                   
         "version":"1.0.0.0"}                                                                           
        ```

        In the example above, *buttonLayout.sources* is a list of mappings. In the “html”, you can then refer to a source, e.g. *$btn1*, to display the corresponding image, in this case *button1.png*.

        > [!NOTE]
        > Any images you refer to in the advanced layout of a button must be placed in the folder *C:\\Skyline DataMiner\\Dashboards\\\_IMAGES\\buttons*.

- *Container* or *Page*: Allows you to link the button to a particular container or page. In that case, a separate parameter can be used to select the currently active container or page.

- *Possible Operations*: Allows you to specify the possible operations that can be executed with the button. For example:

    - For a simple button: *click* 

    - For a rotate button: largedecrease;smalldecrease;smallincrease;largeincrease 

##### Other parameters

From DataMiner 9.6.13 onwards, if a separate parameter is used for the advanced configuration of the entire panel, it can be configured with a setting to allow free configuration of the button panel layout:

```txt
{"panelLayout": {"layoutStyle": "FreeLayout"} }
```

If the configuration above is specified, and the button panel component setting *In configuration mode* is selected in the Dashboard app, you can then reposition buttons on the panel in the dashboard by dragging and dropping them. You can select multiple buttons at the same time by keeping the Ctrl key pressed when you select them, and reposition them at the same time.

Note that this same parameter also allows you to set the panel to a fixed layout, if you configure it as follows:

```txt
{"panelLayout": {"layoutStyle": "FixedLayout"} }
```

> [!NOTE]
> This parameter must be defined using the *panelAdvancedLayout* dashboard option in the protocol. See [Configuring the button panel element protocol](#configuring-the-button-panel-element-protocol).

#### Configuring the button panel element protocol

Within the *Param* tag of the protocol, the following tags can be used to configure the button panel functionality.

- **Param.Dashboard.Type**: Optional. Indicates the type of button panel. Can be set to the following values:

    | Value                 | Description                                                                                                                                                                                                                                                                                                                                                                                         |
    |-------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Button panel            | The parameter is a table containing all the buttons. Every row in the table represents a button. A button could be linked to a page (see button panel containers).                                                                                                                                                                                                                                  |
    | Button panel containers | The parameter lists the different “pages” or "containers".                                                                                                                                                                                                                                                                                                                                          |
    | Button panel collection | The parameter contains grouping information. A group is a collection of one or more button panels. Every row of this table parameter represents one group with all the necessary information for the dashboard to be able to display the button panels of that group.<br> This parameter can be used as a feed in the dashboard that will allow the user to easily switch between dashboard groups. |

- **Param.Dashboard.DashboardOptions.DashboardOption**: These tags allow you to configure the options that will determine how the button panel is displayed. Each *DashboardOption* tag has the following attributes:

    | Attribute | Description                                                                                                                                                                                                                                                                        |
    |-------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | type        | Should be set to either *idx* if the option applies to a particular column in the table, or to *pid* if it applies to a specific parameter. Depending on this type setting, the tag contains either an IDX or a PID. |
    | name        | The name of the option (cf. below).                                                                                                                                                                                                                                                |

    The following options can be configured:

    | Option name                  | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
    |--------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | activeContainer                | Determines which container is to be displayed by the dashboard. For this option, *type* should be set to *pid* and the tag should contain the PID of the parameter that allows the user to select the active container.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
    | advancedLayout                 | Allows the user to specify the layout of the button using a JSON string. For example:<br> -  For a button with custom HTML: <br>{"buttonLayout":{"alignHorizontal":"Left","alignVertical":"Center","html":"\<div class='button-container'>\<div class='button'>Button\</div>\</div>"},"version":"1.0.0.0"}<br> -  For a rotate button: <br>{"rotateButtonLayout":{"sliderOrientation":"Horizontal"},"version":"1.0.0.0"}<br> NOTE: Using the HTML class *toggled*, you can determine what the button will look like when it is interacted with. Using the HTML class *locked*, you can determine what the button will look like when it is locked. |
    | height                         | Determines the height of the button (in percent).                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |
    | container                      | Determines the container the button is located in.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
    | css                            | Determines the CSS to apply to HTML content of buttons. For this option, *type* should be set to *pid* and the tag should contain the PID of the parameter that contains the CSS.<br> NOTE: To apply a different CSS to a specific button, you can specify this in line in the advancedLayout JSON.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |
    | panelAdvancedLayout            | Allows the user to specify the general layout of the panel using a JSON string. For this option, *type* should be set to *pid* and the tag should contain the PID of the parameter that contains the JSON string.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
    | panelButtonName                | Determines the name of the button.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
    | panelButtonOperation           | Displays the different buttons, which are the same for all rows. The next option, panelButtonPossibleOperations, will determine which of these buttons are used.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
    | panelButtonPossible­Operations | Allows the user to specify which operations are possible with the button. For rotate buttons, four types of increments are possible. By default, at least a small decrease and increase are available, but it is possible to add a large increase and decrease. <br> For example: click, <br>largedecrease;smalldecrease;smallincrease;largeincrease                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
    | panelButtonType                | Determines the type of button. The user will be able to select one of the following types:<br> -  Simple<br> -  Advanced - HTML. The *advancedLayout* option should be used to further configure a button of this type.<br> -  Rotate<br> -  UI                                                                                                                                                                                                                                                                                                                                                                                                                         |
    | width                          | Determines the width of the button (in percent).                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
    | xpos                           | Determines the position of the button on the X-axis (in percent).                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |
    | ypos                           | Determines the position of the button on the Y-axis (in percent).                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |

    For example:

    ```xml
    <Param id="100">                                                                      
      <Name>mainButtonPanel</Name>                                                         
      <Description>Main Button Panel</Description>                                         
      <Type>array</Type>                                                                   
      <ArrayOptions index="0" options=";naming=/101,102">                                   
        <ColumnOption idx="0" pid="101" type="retrieved" options=""/>                         
        <ColumnOption idx="1" pid="102" type="retrieved" options=";save" />                   
        <ColumnOption idx="2" pid="103" type="retrieved" options=";save" />                   
        <ColumnOption idx="3" pid="104" type="retrieved" options=";save" />                   
        <ColumnOption idx="4" pid="105" type="retrieved" options=";save" />                   
        <ColumnOption idx="5" pid="106" type="retrieved" options=";save" />                   
        <ColumnOption idx="6" pid="107" type="retrieved" options=";save" />                   
        <ColumnOption idx="7" pid="108" type="retrieved" options=";save" />                   
        <ColumnOption idx="8" pid="109" type="retrieved" options=";save" />                   
        <ColumnOption idx="9" pid="110" type="retrieved" options=";save" />                   
        <ColumnOption idx="10" pid="111" type="retrieved" options=";save;foreignKey=200" />   
        <ColumnOption idx="11" pid="112" type="retrieved" options=";save" />                  
        <ColumnOption idx="12" pid="139" type="retrieved" options="" />                       
        <ColumnOption idx="13" pid="140" type="displaykey" options="" />                      
      </ArrayOptions>                                                                       
      ...                                                                                    
      <Dashboard>                                                                           
        <Type>button panel</Type>                                                            
        <DashboardOptions>                                                                    
          <DashboardOption type="idx" name="panelButtonName">1</DashboardOption>               
          <DashboardOption type="idx" name="xpos">3</DashboardOption>                          
          <DashboardOption type="idx" name="ypos">4</DashboardOption>                          
          <DashboardOption type="idx" name="height">5</DashboardOption>                        
          <DashboardOption type="idx" name="width">6</DashboardOption>                         
          <DashboardOption type="idx" name="panelButtonType">8</DashboardOption>               
          <DashboardOption type="idx" name="advancedLayout">9</DashboardOption>                
          <DashboardOption type="pid" name="panelAdvancedLayout">147</DashboardOption>         
          <DashboardOption type="pid" name="css">148</DashboardOption>                         
          <DashboardOption type="idx" name="container">10</DashboardOption>                    
          <DashboardOption type="pid" name="activeContainer">149</DashboardOption>             
          <DashboardOption type="idx" name="panelButtonPossibleOperations">11</DashboardOption>
          <DashboardOption type="idx" name="panelButtonOperation">12</DashboardOption>         
        </DashboardOptions>                                                                   
      </Dashboard>                                                                          
    </Param>                                                                              
    ```

### Clock (analog)

This component displays an analog clock that indicates the current time.

In the *Settings* tab, the following settings can be configured for this component:

- To use a different polling interval for this component than the standard interval configured for the dashboard, in the *WebSocket settings* section, clear the checkbox and specify a different polling interval (in seconds).

- In the *General* section, you can specify whether the current DataMiner time should be displayed (i.e. the time of the DataMiner Agent to which you are connected) or the local time.

In the *Component \> Layout* tab, the following options can be configured:

- The default options available for all components. See [Customizing the component layout](Configuring_dashboard_components.md#customizing-the-component-layout).

- *Show seconds*: Select this option to include the second hand in the clock.

- *Show date*: Select this option to display the date below the clock.

### Clock (digital)

This component displays a digital clock that indicates the current time.

In the *Settings* tab, the following settings can be configured for this component:

- To use a different polling interval for this component than the standard interval configured for the dashboard, in the *WebSocket settings* section, clear the checkbox and specify a different polling interval (in seconds).

- In the *General* section, you can specify whether the current DataMiner time should be displayed (i.e. the time of the DataMiner Agent to which you are connected) or the local time.

In the *Component \> Layout* tab, the following options can be configured:

- The default options available for all components. See [Customizing the component layout](Configuring_dashboard_components.md#customizing-the-component-layout).

- *Show seconds*: Select this option to have the clock display the seconds.

- *Show date*: Select this option to display the date below the clock.

### Generic map

To configure the component, in the *Settings* tab, specify a map configuration.

> [!NOTE]
> For more information, see [Displaying a DataMiner Map in a DataMiner dashboard](../maps/Displaying_a_DataMiner_Map_in_a_DataMiner_dashboard.md).

### Group

Available from DataMiner 9.6.12 onwards. This component can be used to display a group of other components. This is especially used in order to repeat the same components for each data item in a group feed, for example for each parameter in a group of parameters.

As soon as more than one data item is displayed by the group component, the component will display a legend on the right-hand side, listing the included items. You can show and hide data items by clicking them in this legend. Next to each item in the legend, the color is displayed that is associated with it in the group. If you click an item in the group, all related information in parameter state, line chart and pivot table components within the group will be highlighted with this color.

To configure this component:

1. Add one or more data feeds. See [Applying a data feed](Configuring_dashboard_components.md#applying-a-data-feed).

    The component accepts elements, parameters, redundancy groups, services and views as data feeds.

2. Drag additional visualizations to the placeholder boxes on the component.

    Once a visualization has been added, you can delete it again using a delete icon. You can also replace an added visualization by a different one by dragging that other visualization to the same location. By clicking a visualization within the group, you can gain access to its specific layout options and settings.

3. Optionally, in the *Component* > *Layout* tab, configure the following options:

    - *Page Layout* \> *Layout*: Determines whether the different items are displayed next to each other or below each other. However, note that when the dashboard is used on a small screen, they will always be displayed below each other.

    - *Page Layout* \> *Maximum rows per page*: Determines how many items can at most be displayed below each other on a single page.

    - *Page Layout* \> *Maximum columns per page*: Determines how many items can at most be displayed next to each other on a single page.

    - *Group Layout* \> *Number of components*: Determines how many child components can be displayed within the group

    - *Group Layout* \> *Layout*: Determines the size and position of the different child components within the group.

    - *Expand legend initially*: Available from DataMiner 10.0.0/10.0.2 onwards. Select this option to immediately show the group legend in the component. Otherwise, the legend section is initially collapsed and you can display it using the arrow icon in the top-right corner of the component.

4. Optionally, in the *Component* > *Settings* tab, configure the following options:

    - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

    - *Data limit*: Determine the maximum number of items for which the component can display data.

### Image

This component displays an uploaded image.

To configure this component:

- In the *Settings* tab, select the image you want to display in the *Image* drop-down list.

    This list shows all images available on the DMA. If the image you want is not yet in the list, you can upload it using the option *Upload a new image* below the drop-down list. The following image types are supported: PNG, JPEG, GIF, APNG, SVG and WEBP.

In the *Component \> Layout* tab, the following options can be configured:

- The default options available for all components. See [Customizing the component layout](Configuring_dashboard_components.md#customizing-the-component-layout).

- *Image size*: Available from DataMiner 10.0.11 onwards. Can be set to:

    - *Fit*: Scales the image to the maximum possible size without stretching or cropping.

    - *Fill*: Scales the image to the maximum possible size without stretching.

    - *Stretch*: Scales the image to the maximum possible size without preserving the aspect ratio. If this option is picked, the alignment options below become unnecessary.

- *Horizontal alignment*: Allows you to set the horizontal alignment of the image within the component to *Left*, *Center* or *Right*.

- *Vertical alignment*: Allows you to set the vertical alignment of the image within the component to *Top*, *Center* or *Bottom*.

### Text

This component displays a block of static text.

To configure this component:

- In the *Settings* tab, add the text in the *Text* box.

In the *Component \> Layout* tab, the following options can be configured:

- The default options available for all components. See [Customizing the component layout](Configuring_dashboard_components.md#customizing-the-component-layout).

- *Font*: Allows you to select the font of the text.

- *Font size*: Allows you to set the font size.

- *Bold*/*Italic*/*Underline*: Select these text boxes to apply these formatting options.

- *Horizontal alignment*: Allows you to set the horizontal alignment of the text to *Left*, *Center* or *Right*.

### Web

This component displays a webpage or a block of static HTML.

- To configure the component as a webpage:

    1. In the *Settings* tab, set *Type* to *Webpage*.

    2. In the URL box below this, specify the URL of the webpage.

- To configure the component as a block of HTML:

    1. In the *Settings* tab, set *Type* to *Custom HTML*.

    2. In the *HTML* box below this, add the HTML code.

In the *Component* > *Layout* tab, only the default options are available for this component. See [Customizing the component layout](Configuring_dashboard_components.md#customizing-the-component-layout).

> [!NOTE]
> This component does not allow the use of scripts, buttons or other input controls. 
>
