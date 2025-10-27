---
uid: EPM_Topology_app
---

# Using the EPM Topology app

From DataMiner Cube 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5 onwards<!-- RN 42221 -->, if your system has been correctly [configured to display the EPM Topology app](xref:Topology_app_configuration), you can access this app using the *Topology* button in the Cube sidebar. In earlier DataMiner versions, this feature is available in preview if the *CPEIntegration* [soft-launch option](xref:SoftLaunchOptions) is enabled.

![Topology app](~/dataminer/images/EPMIntegration_Topology_app.png)<br>
*Topology app in DataMiner Cube 10.5.5*

## Navigating to a topology level

In the filter pane on the left, you can select the front-end EPM Manager (in case more than one is available), select the topology chain, and drill down to any of the topology levels in that chain. You can then click the ">" button next to that level to open the corresponding page.

> [!NOTE]
> In the [Cube user settings](xref:User_settings#surveyorsidebar-settings), you can use the *Launch EPM card on filter selection* setting to have an EPM card opened as soon as an item is selected in the filter pane.

![Topology app navigation](~/dataminer/images/EPMIntegration_Open_card.png)<br>
*Topology app in DataMiner Cube 10.5.5*

The page for the topology level will display the data configured for this level in the EPM Manager protocol. When you navigate between (docked) EPM cards, the filter selection will be updated to match the displayed card.

If a topology level has child items, you can find these on the *Below this [EPM level name]* page.

![Topology app child items](~/dataminer/images/EPMIntegration_Below_this_page.png)<br>
*Topology app in DataMiner Cube 10.5.5*

On the *Topology* page, you can find an overview of the topology for the selected level. Double-clicking a block in this overview will navigate to that level and update the filters in the filter pane.

![Topology app topology page](~/dataminer/images/EPMIntegration_Topology_page.png)<br>
*Topology app in DataMiner Cube 10.5.5*

An overview of alarms for the selected level is available on the *Alarms* page.

## Accessing the front-end element configuration

With the cogwheel button at the top of the filter pane, you can access the front-end EPM Manager configuration in System Center, which can be used to add more front-end manager elements.

![Topology app cogwheel button](~/dataminer/images/EPMIntegration_Cogwheel_button.png)<br>
*EPM config settings in DataMiner Cube 10.5.5*

## Viewing masking info

If an EPM object in the topology is masked, you can get information on who masked it and when via the *Masking info* option in the hamburger menu of the Topology app:<!-- RN 26002 -->

![Masking info option](~/dataminer/images/EPMIntegration_Masking_info.png)<br>
*Topology app in DataMiner Cube 10.5.5*
