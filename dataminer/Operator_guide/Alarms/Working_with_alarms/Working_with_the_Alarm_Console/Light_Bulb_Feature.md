---
uid: Light_Bulb_Feature
---

# Working with the Alarm Console light bulb feature

From DataMiner 10.3.10/10.4.0 onwards, you can leverage the Alarm Console's light bulb feature to stay updated on alarms and suggestion events related to SLAnalytics features. To access this feature, click the *light bulb* button located in the top-right corner of the Alarm Console: ![Light bulb button](~/dataminer/images/LightBulb_button.png) <!--RN 36777--> <!-- RN 37184-->

The Alarm Console light bulb feature supports the following advanced analytics features:

- Alarm focus
- Automatic incident tracking
- Behavioral anomaly detection
- Relational anomaly detection
- Proactive cap detection
- Pattern matching

> [!NOTE]
> If your DataMiner System does not meet the requirements, the light bulb feature will notify you of this<!--RN 37136-->. For more information about the DataMiner setup required to work with these analytics features, see [Advanced analytics features in the Alarm console](xref:Advanced_analytics_features_in_the_Alarm_Console).

## Navigating the light bulb menu

- **When the light bulb feature detects any alarms or suggestion events**, the *light bulb* button turns blue: ![Light bulb blue](~/dataminer/images/BlueLightBulb.png)

  In this case, the light bulb menu may display any of the following notifications, depending on the behavior detected by the light bulb feature:

  | Notification | Action when clicked |
  |--|--|
  | X alarms require your focus in the current tab <!--RN 37057--> | Applies a filter that narrows down the current tab to list only the focused alarms. |
  | Also show alarms not requiring focus <!--RN 37057-->| Clears the above-mentioned filter, listing all alarms in the current tab. |
  | X incidents are present on the system <!--RN 36918--> <!--RN 37145--> | Opens a new tab listing all active incidents. |
  | X anomalies were found in your trend data <!--RN 37145--> | Opens a new tab listing all anomaly suggestions/alarms. |
  | X relational anomalies were found | Opens a new tab listing all relational anomaly suggestions |
  | X alarms are predicted in the near future <!--RN 37145--> | Opens a new tab listing all prediction suggestions/alarms. |
  | X recent pattern occurrence detected <!--RN 37145--> | Opens a new tab listing all trend pattern suggestions. |

- **When no insights are available**, the *light bulb* button retains its default gray color, and clicking the button will alert you that no insights are currently available<!--RN 37167-->.

- If any of the analytics features are disabled or if your DataMiner System does not meet the requirements for the light bulb feature to detect alarms or suggestion events, a message in the light bulb menu will alert you of this<!--RN 37136-->. You can activate or deactivate any features in System Center, via *System Center > System settings > analytics config*.
