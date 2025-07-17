---
uid: DashboardClockDigital
---

# Clock (digital)

This component displays a digital clock that indicates the current time.

![Clock (digital)](~/dataminer/images/Clock_Digital.png)<br>*Digital clock component in DataMiner 10.4.6*

In the *Component* > *Settings* pane, the following settings can be configured for this component:

- To use a custom polling interval for this component, in the *WebSocket settings* section, clear the checkbox and specify a different polling interval (in seconds).

- In the *General* section, the *Type* box allows you to select whether the current DataMiner time should be displayed (i.e. the time of the DataMiner server to which you are connected) or the local time (i.e. the DataMiner client time).

  Alternatively, from DataMiner 10.3.8/10.4.0 onwards, you can make the clock display the date and time in a specific time zone. To do so, in the *Type* box, select *Custom time zone*, and then select a time zone in the *Time zone* box. <!-- RN 36534 -->

In the *Component \> Layout* tab, the following options can be configured:

- The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

- *Show seconds*: Select this option to have the clock display the seconds.

- *Show date*: Select this option to display the date below the clock.
