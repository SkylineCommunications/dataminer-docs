---
uid: DashboardServiceDefinition
---

# Service definition

This component displays a service definition as a node edge graph. It can display the graph based on service definition data or booking data. Any nodes that are linked to a particular resource will display alarm and element info in the graph. The alarm state will be displayed with a colored border at the top of the node, and in the node icon in case the default icon is shown. In addition, a link icon in the node will open the corresponding element card in the Monitoring app when clicked.

To configure the component:

1. Add an input for the data:

   - Add a service definition data, or

   - Add booking data, or

   - Add service data (supported from DataMiner 10.2.0/10.1.3 onwards), or

   - Add component data, which can use bookings data filtered by service definition data.

   > [!NOTE]
   > If you use service data, in addition to the service definition, by default, the current booking will be displayed. To display bookings for a different time range, add a time range filter.

1. Optionally, configure one or more actions for nodes of the service definition. An action is a script that is executed when a user clicks a specific icon in the component.

   1. In the *Settings* pane, click the + icon below *Actions* to add an action.

   1. In the *Script* box, specify the script that should be executed by the action.

   1. In the *Icon* box, specify the icon that should be displayed for this action in the component.

   1. If necessary, specify dummies and/or parameters for the script.

      > [!NOTE]
      > The booking ID or service definition ID used in the component and the node ID of the node for which the icon was clicked will automatically be passed to the script as parameter ID 1 and parameter ID 2, respectively.

   1. In the tree view below *Add action to*, select the nodes for which the action should be available.

   1. Repeat from step a for each new action you want to add.

   If you want to reorder the configured actions, hover the mouse pointer over an action, and click the up or down arrow at the top of the action. Similarly, to delete a configured action, hover the mouse pointer over the action and click the red garbage can icon.

1. Optionally, fine-tune the way the component is displayed with the following settings in the *Layout* pane:

   - *Show ID*: Determines whether node IDs are displayed.

   - *Show interfaces*: Determines whether the interfaces of the nodes are displayed.

   - *Show nodes without a resource assigned*: Determines whether nodes that have no resource assigned are displayed. By default, this option is not selected, so these nodes are not displayed.

   - *Visible nodes*: Allows you to select which nodes should be displayed. Below this option, a tree view is displayed, showing the nodes in the service definition. Only the selected nodes will be displayed in the component.

   - *Enable zooming*: Determines whether users will be able to zoom in and out on the graph.

     - From DataMiner 10.4.0 [CU10]/10.5.1 onwards<!--RN 41387-->, you can configure whether pressing the Ctrl key is required to zoom in or out. To do so, in the *Settings* pane, toggle the *Advanced* > *Hold Ctrl to zoom* option:

       - Enabled: Hold the Ctrl key while scrolling up or down to zoom in or out.

       - Disabled: Scroll up or down to zoom in or out. This is the default option.

     - From DataMiner 10.3.0[CU18]/10.4.0 [CU6]/10.4.9<!--RN 40017--> up to DataMiner 10.4.0 [CU9]/10.4.12, you can zoom in or out by pressing Ctrl while using the scroll wheel.

     - Prior to DataMiner 10.3.0[CU18]/10.4.0 [CU6]/10.4.9, you can zoom in or out using the scroll wheel.

   - *Edge style*: Determines whether curly or straight edges are used in the graph.

> [!NOTE]
> From DataMiner 10.2.5/10.3.0 onwards, service definitions of type "Skyline Process Automation" are displayed differently from other service definitions. From DataMiner 10.2.8/10.3.0 onwards, service definition of type "Custom Process Automation" are also displayed this way.
>
> - Arrows will automatically be drawn to represent the detected connections between the nodes.
> - Different function shapes will reflect the different function types, if these have been configured in the Process Automation framework.
> - Function nodes will display the number of tokens currently in queue or in progress.
> - From DataMiner 10.2.9/10.3.0 onwards, instead of the function definition names, nodes will display the value of their *Label* property if this is present.
