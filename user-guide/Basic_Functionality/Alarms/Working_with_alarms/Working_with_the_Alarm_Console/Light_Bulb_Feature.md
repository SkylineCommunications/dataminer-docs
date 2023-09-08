---
uid: Light_Bulb_Feature
---

# Working with the Alarm Console light bulb feature

From DataMiner 10.3.10/10.4.0 onwards, in the Alarm Console, you can display a menu that shows notifications if there are alarms or suggestion events related to an SLAnalytics feature. To do so, click the *light bulb* button in the top-right corner of the Alarm Console: ![Light bulb button](~/user-guide/images/LightBulb_button.png) <!--RN 36777-->

The Alarm Console light bulb feature supports the following advanced analytics features:

- Alarm focus
- Automatic incident tracking
- Behavioral anomaly detection
- Proactive cap detection
- Pattern matching

> [!NOTE]
> These features are only available on systems with a Cassandra database. Pattern matching is only available on systems with an [indexing database](xref:Elasticsearch_database). If your DataMiner system does not meet the requirements, the light bulb feature will alert you of such<!--RN 37136-->.

> [!TIP]
> For more information on these analytics features, see [Advanced analytics features in the Alarm console](xref:Advanced_analytics_features_in_the_Alarm_Console).

If the light bulb feature has detected any alarms or suggestion events, the light bulb button will take on a blue color: ![Light bulb blue](~/user-guide/images/BlueLightBulb.png)

In this case, any of the following notifications can be displayed:

| Notification | Action when clicked |
|--|--|
| X alarms require your focus in the current tab <!--RN 37057--> | Applies a filter that makes the current tab only list the focused alarms. |
| Also show alarms not requiring focus <!--RN 37057-->| Clears the above-mentioned filter and makes the current tab list all alarms. |
| X incidents are present on the system <!--RN 36918--> <!--RN 37145--> | Opens a new tab listing all active incidents. |
| X anomalies were found in your trend data <!--RN 37145--> | Opens a new tab listing all anomaly suggestions/alarms. |
| X alarms are predicted in the near future <!--RN 37145--> | Opens a new tab listing all prediction suggestions/alarms. |
| X recent pattern occurrence detected <!--RN 37145--> | Opens a new tab listing all trend pattern suggestions. |

If no insights are available, the light bulb has a grey color and clicking the button will alert you that no insights are available at the moment.

If one or multiple of the analytics features are switched off, the light bulb feature will alert you that it can tell you more if all supported features are enabled<!--RN 37136-->. All features can be activated or deactivated in System Center, via *System Center \> System settings* > *analytics config*.
