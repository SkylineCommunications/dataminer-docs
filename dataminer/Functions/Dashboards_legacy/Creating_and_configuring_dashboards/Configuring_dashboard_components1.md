---
uid: Configuring_dashboard_components1
---

# Configuring dashboard components

> [!IMPORTANT]
> This information is applicable to the DMS Dashboards module, which is being retired as of DataMiner version 10.4.x. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement). We recommend using the [Dashboards app](xref:newR_D) instead.

To configure the components of a dashboard, you must first access the dashboard editor. This can be done in two ways:

- After creating or editing a dashboard, click *Save & Start Configuring Components*, or

- Simply click an existing dashboard in the *Dashboards* app.

In the dashboard editor, click *Actions* in the top-right corner to access the various configuration options:

- Add/Remove Components, see [Add/Remove Components](#addremove-components).

- Configure Components, see [Configure Components](#configure-components).

- Feeds, see [Feeds](#feeds).

- Settings, see [Settings](#settings).

## Add/Remove Components

1. Go to *Actions \> Add/Remove Components*.

1. Select a category from the list underneath *Add/Remove Components* to choose components from.

1. Select one of the available components for the selected category. For more information about the available components, see [Dashboard components](xref:Dashboard_components).

1. Add the component to a zone of your dashboard, either with the *Add to* selection box and the *Add* button below the list, or by dragging the component to the zone.

    The component will show a thumbnail of the result, as well as some information regarding the configuration.

    > [!NOTE]
    > Once a component has been added to a particular zone of the dashboard, you can still drag and drop it to a different zone.

1. Click the *Configure* button underneath a component to start configuring it.

> [!NOTE]
> You can also click the downward arrow to the right of a component header to access the following options:
>
> - Delete: removes the component from the dashboard.
> - Duplicate: duplicates the component on the dashboard.
> - Edit: allows you to configure the component.
> - View Info: opens a pop-up window with some more details about the component.

## Configure Components

1. Go to *Actions \> Configure Components* and select a component, or click the *Configure* button for one of the components.

1. In the *Feed* section of the configuration panel, choose what data the component will display. Depending on the type of component you have added, you will be able to choose a particular fixed input or configure a feed.

    To configure a feed:

    1. Either select an existing feed in the *Feed* selection box, or click *New*.

    1. Click *Edit* to edit the feed. You will have the same options for editing as in the Feeds editor. See [Feeds](#feeds).

    1. Click *Save Feed* to apply the changes you have made.

    1. Depending on the component type and the feed, you may then be able to select a particular element, parameter, service, etc. corresponding to the feed.

1. In the *Options* section, determine how the information should be visualized in the component. The available options depend on the type of component you chose. Some options return for most components:

    - *Fixed width*: specify a number of pixels to which the width of the component will be fixed.

    - *Title*: change the title to have a different title shown above the component while it is being edited.

    - *Display title*: select to always show the component title on the dashboard.

    - *Display border*: select to put a border around the component.

    - *Background image*: click the *...* button to choose a background image for the component.

    - *Background mode*: use the dropdown list to choose how the background image will be displayed.

    - *Text color*: click the *...* button to determine the text color of the component.

    - Under *Extra CSS*, more advanced customizations can be applied, for example, `border:1px solid red;`.

1. Click *Apply* to save your changes.

> [!NOTE]
> To see a preview of your dashboard at this point, click *Preview dashboard* below the list of configuration options. The preview will open in a different window.

## Feeds

1. Go to *Actions \> Feeds* to access the Feeds editor.

1. Click the pencil icon next to an existing feed in the top selection box, or click *Add new feed* to configure a new feed.

1. Enter a name for the feed

1. Determine either a *User selection* or a *Fixed selection*.

    - Possible selections for *User selection* are: Aggregation rule, Data display page, DataMiner Agent, Element, Linked dashboard, Nothing (fixed feed), Parameter, Protocol, Redundancy group, Service, View, Visual overview page.

    - Possible selections for *Fixed selection* are: Alarm, DataMiner Agent, Element, None, Parameter, Protocol, Redundancy group, Service, View.

    - When you choose a fixed selection, different dropdown lists will appear underneath depending on your choice.

    > [!NOTE]
    > - A user selection determines the type of input a user has to provide. If you for instance choose "Element" for the user selection, the user will have to specify an element. A fixed selection acts as a selection filter. If you for instance specify a particular protocol for the fixed selection, the user will only be able to specify items that use this protocol.
    > - For a trend parameter component, if you configure a feed with a table parameter, there are two possibilities regarding the table index. You can either select a unique name in the dropdown list, or select *Other value* in the list, and then enter a value. If you enter a value, you can use an asterisk ("\*") as a wildcard.

1. If necessary, in order to further limit the feed selection, you can enter a mask for the element name. To do so, click *Advanced* and enter a mask next to *Element mask*. In this mask you can use placeholders like *\[this service\]* and *\[param:dmaid/eid:pid:dispidx\]*.

    > [!NOTE]
    > An element mask can for instance be useful in a dashboard that is linked to a *Service state LED* component, as it will make it easier for the system to link any feeds that have "Element" configured as *User selection*.

1. Click *Save Settings* to save the feed.

> [!NOTE]
>
> - In the Feeds editor, you can delete feeds that are not in use by clicking the red x next to the feed.
> - In a dashboard where a user must select a feed, in the feed selection panel, it is possible to save a particular feed as default.

## Settings

Go to *Actions \> Settings* to access the general dashboard settings.

You can configure several options here:

- To make the dashboard pop up in a smaller window, select *Pop up as mini-dashboard* and enter a width and height for the mini-dashboard.

- Click the *...* button under *Background image* to choose a background image for the dashboard.

- Choose a *Background mode* to determine how the background image will be displayed

- Click the *...* button under *Text color* to determine the text color of the dashboard.

- Under *Extra CSS*, more advanced customizations can be applied, for example, `border:1px solid red;`.
