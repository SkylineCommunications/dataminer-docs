---
uid: DashboardButton
---

# Button

> [!IMPORTANT]
> In the Dashboards app, this feature is currently still in preview. For more information, see [Soft-launch options](xref:SoftLaunchOptions). However, it is fully available in the [DataMiner Low-Code Apps](xref:Application_framework).

In the Dashboards app, this component is available in soft launch, if the soft-launch option *ReportsAndDashboardsButton* is enabled. In the DataMiner Low-Code Apps, it is available by default.

![Button](~/dataminer/images/Button.png)<br>*Button component in DataMiner 10.4.6*

To configure the component:

## [In the DataMiner Low-Code Apps](#tab/tabid-1)

1. In the *Component* > *Settings* pane, click the configuration icon next to *On click* and select the action(s) you want the button to execute. See [Configuring app events](xref:LowCodeApps_event_config).

1. Fine-tune the component layout. In the *Component* > *Layout* pane, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

   - *Label*: Determines which text is displayed on the button.

   - *Icon*: Allows you to select an icon to be displayed next to the label.

## [In the Dashboards app](#tab/tabid-2)

In the Dashboards app, the soft-launch button component can be used to execute the action of a button parameter. As such, it must be configured with button parameter data.

> [!NOTE]
> If the *ReportsAndDashboardsAutomationScript* soft-launch option is enabled as well, this component functions as an Automation script component, and you can link it directly to an Automation script in the *Settings* pane. However, if you add a button parameter to the component, it will still act as a parameter button even with this soft-launch option.

1. Apply parameter data. See [Adding data to a component](xref:Adding_data_to_component).

   You will only be able to select button parameters for the data. Several parameters can be added in the same component.

1. Fine-tune the component layout. In the *Component* > *Layout* pane, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

   - In case the component displays more than one parameter, in the *Advanced* > *Layout* section, you can adjust the way the different items are displayed:

     - *Layout*: Determines whether the different items are displayed next to each other or below each other. However, note that when the items are viewed on a small screen, they will always be displayed below each other.

     - *Maximum rows per page*: Determines how many items can at most be displayed below each other on a single page.

     - *Maximum columns per page*: Determines how many items can at most be displayed next to each other on a single page.

   - The *Button text* option allows you to customize the text that should be displayed on the button. By default, the button displays the same text as in Cube.

1. Optionally, configure the following settings in the *Component* > *Settings* pane:

   - To use a custom polling interval for this component, in the *WebSocket settings* section, clear the checkbox and specify a different polling interval (in seconds).

   - In case the component displays more than one parameter, configure how the parameters should be grouped: by parameter, by element, by table index (if relevant) or by all the above together.

   - In case the button triggers an Automation script, additional settings will also be available related to this script.

     - Depending on the script configuration, it may be possible to configure the parameters and/or dummies used in the script. For each of the parameters and dummies, a checkbox allows you to select whether these are required, i.e. whether the script can be executed only if these are filled in.

       > [!NOTE]
       > The input for an interactive Automation script can be specified by the user or retrieved via linked data. In case both are possible for the same component, user input always takes precedence.
       >
       > In case several data is linked to the component, they are considered in the order they were added. For example, if 2 data sources are used and the data that was first added is applicable, the second data input will be ignored.

     - The standard options for script execution can be configured. See [Script execution options](xref:Script_execution_options).

     - The following additional options are available:

       - *Ask for confirmation*: Determines whether the user will be asked for confirmation before the script is executed.

       - *Show success popup*: Determines whether a pop-up message is displayed when the script has been successfully executed. By default enabled.

       - *Custom success message*: Allows you to configure a custom message to be displayed when the script has been successfully executed.

***

> [!NOTE]
> From DataMiner 10.2.5/10.3.0 onwards, the output of an (interactive) Automation script can be used as data for other components, for example in a GQI query.

> [!TIP]
> See also: [Using button components and header bars in Low-Code Apps](https://www.youtube.com/watch?v=7Qhitj3fQB4) ![Video](~/dataminer/images/video_Duo.png)
