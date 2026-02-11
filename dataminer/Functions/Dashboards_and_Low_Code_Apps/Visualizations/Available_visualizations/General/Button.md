---
uid: DashboardButton
---

# Button

The button component is a customizable element used to trigger actions in a low-code app.

![Button](~/dataminer/images/Button.png)<br>*Button component in DataMiner 10.4.6*

> [!TIP]
> See also: [Using button components and header bars in Low-Code Apps](https://www.youtube.com/watch?v=7Qhitj3fQB4) ![Video](~/dataminer/images/video_Duo.png)

## Configuration options

### Button layout

In the *Layout* pane, you can find the default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

Additionally, the following layout options are also available:

| Section | Option | Description |
|--|--|--|
| Advanced | Label | Determine which text is displayed on the button. |
| Advanced | Icon | Select an icon to be displayed next to the label. |

### Button settings

In the *Settings* pane for this component, you can customize its behavior to suit your requirements:

| Section | Option | Description |
|--|--|--|
| WebSocket settings | Inherit WebSocket settings from page/panel | Clear the checkbox to use a custom polling interval for this component. When cleared, you can specify a different polling interval (in seconds). |
| General | On click | Configure the action(s) that will be triggered by clicking the button. See [Configuring app events](xref:LowCodeApps_event_config). |

## Using the button in dashboards (preview)

The button component is **currently still in preview** in the Dashboards app, and requires the [soft-launch option *ReportsAndDashboardsButton*](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsbutton) to be enabled.

When used in dashboards, the soft-launch button component can be used to **execute the action of a button parameter**. As such, it must always be configured with button parameter data. Multiple parameters can be added to the same element.

> [!NOTE]
>
> - If the *ReportsAndDashboardsAutomationScript* soft-launch option is enabled as well, this component functions as an automation script component, and you can link it directly to an automation script in the *Settings* pane. However, if you add a button parameter to the component, it will still act as a parameter button even with this soft-launch option.
> - From DataMiner 10.2.5/10.3.0 onwards, the output of an (interactive) Automation script can be used as data for other components, for example in a GQI query.

### Dashboard button layout

In the *Layout* pane, you can find the default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

Additionally, the following layout options are available. Some options only appear when the component displays multiple parameters:

| Section | Option | Description |
|--|--|--|
| Advanced | Layout | Determine whether the different items are displayed next to each other or below each other. However, note that when the items are viewed on a small screen, they will always be displayed below each other. |
| Advanced | Maximum rows per page | Determine how many items can at most be displayed below each other on a single page. |
| Advanced | Maximum columns per page | Determine how many items can at most be displayed next to each other on a single page. |
| Advanced | Button text | Customize the text that should be displayed on the button. By default, the button displays the same text as in Cube. |
| Advanced | Simple button text size | Select the size of the button text: small, medium, or large. |

### Dashboard button settings

The following optional settings are available for the soft-launch button component:

- In case the component displays more than one parameter, configure how the parameters should be grouped: by parameter, by element, by table index (if relevant) or by all the above together.

- In case the button triggers an automation script, additional settings will also be available related to this script.

  - Depending on the script configuration, it may be possible to configure the parameters and/or dummies used in the script. For each of the parameters and dummies, a checkbox allows you to select whether these are required, i.e. whether the script can be executed only if these are filled in.

    > [!NOTE]
    > The input for an interactive automation script can be specified by the user or retrieved via linked data. In case both are possible for the same component, user input always takes precedence.
    >
    > In case several data is linked to the component, they are considered in the order they were added. For example, if 2 data sources are used and the data that was first added is applicable, the second data input will be ignored.

  - The standard options for script execution can be configured. See [Script execution options](xref:Script_execution_options).

  - The following additional options are available:

    - *Ask for confirmation*: Determines whether the user will be asked for confirmation before the script is executed.

    - *Show success popup*: Determines whether a pop-up message is displayed when the script has been successfully executed. By default enabled.

    - *Custom success message*: Allows you to configure a custom message to be displayed when the script has been successfully executed.
