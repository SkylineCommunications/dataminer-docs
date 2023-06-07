---
uid: DashboardClockAnalog
---

# Clock (analog)

This component displays an analog clock that indicates the current time.

In the *Component* > *Settings* tab, the following settings can be configured for this component:

- To use a custom polling interval for this component, in the *WebSocket settings* section, clear the checkbox and specify a different polling interval (in seconds).

- In the *General* section, you can specify whether the current DataMiner time should be displayed (i.e. the time of the DataMiner Agent to which you are connected) or the local time.

  > [!NOTE]
  > From DataMiner 10.3.8/10.4.0 onwards, you can now make the clock display the date and time in a specific time zone. To do so, select the *Custom time zone* option, and select a time zone from the *Time zone* selection box. <!-- RN 36534 -->

In the *Component \> Layout* tab, the following options can be configured:

- The default options available for all components. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).

- *Show seconds*: Select this option to include the second hand in the clock.

- *Show date*: Select this option to display the date below the clock.
