---
uid: Consulting_general_SLA_information
---

# Consulting general SLA information

To view more information on the SLA in general, check the section *General Info* on the *Main View* page of the SLA element. There you will find the following information.

- **Service Name**: The name of the service the SLA applies to.

- **Service Alarm State**: The current alarm state of the service.

- **Current Outage Impact**: Shows the impact of the current outage, in percent. This is influenced by several factors such as whether or not the service is currently in the offline window, or if violation filters have been applied to the SLA.

  > [!NOTE]
  > By default, timeout alarms have 0% impact, but you can change this using violation filters.

  > [!TIP]
  > See [Setting a violation filter](xref:Configuring_the_alarm_settings_for_an_SLA#setting-a-violation-filter).

- **Admin State**: Indicates whether the SLA is currently activated or not.

- **Service Live State**: Shows whether the service is online or offline, and the time until the start or end of the offline window.

- **Start Time**: Indicates when the window started.

- **End Time**: Indicates when the window ends. If you set a sliding window, this will be *Now*.
