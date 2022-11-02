---
uid: Configuring_Alerter
---

# Configuring Alerter

It is possible to configure Alerter to your personal preferences. These user settings are stored on the server, so that you will always have your personal settings, no matter from which device you log on to Alerter.

This section consists of the following topics:

- [Connecting Alerter to another DataMiner System](#connecting-alerter-to-another-dataminer-system)

- [Setting your startup preferences for Alerter](#setting-your-startup-preferences-for-alerter)

- [Setting an alarm filter in Alerter](#setting-an-alarm-filter-in-alerter)

- [Configuring alarm storm prevention in Alerter](#configuring-alarm-storm-prevention-in-alerter)

- [Setting the notification options in Alerter](#setting-the-notification-options-in-alerter)

- [Configuring Alerter pop-up balloons](#configuring-alerter-pop-up-balloons)

- [Configuring options related to acknowledging alarms](#configuring-options-related-to-acknowledging-alarms)

## Connecting Alerter to another DataMiner System

Do the following if you want Alerter to connect to another DataMiner System.

1. Go to *Settings \> DMS Connections*.

1. In the *Account* section, click *Edit Account*.

1. In the *Add Connection* dialog box, make the necessary changes to the following settings.

    - **Name of DMS**: The name of the DataMiner System. You can enter an arbitrary name.

    - **Host**: The name or the IP address of the DataMiner Agent to which you want to connect.

1. If you want to change the default connection settings, click *Advanced*, make the necessary changes to the settings, and click *OK*.

1. In the *Add Connection* dialog box, click *OK*.

1. In the *Options* dialog box, click *OK*.

> [!NOTE]
>
> - In the DMS Connections tab, the option *Show message when SLAlerter loses connection* determines whether users will be notified when the connection to the DMS is lost. By default, this option is enabled.
> - If the connection to the DMS is lost, this is logged in the Event Viewer with an "SLAlerter lost connection" message. In the Alerter application itself, the user will be redirected to the login screen, in the same manner as when the connection is lost in DataMiner Cube.

## Setting your startup preferences for Alerter

Do the following to configure the startup settings of Alerter.

1. Go to *Settings \> Preferences*.

1. If you want Alerter to start automatically when you turn on your computer, select the *Run Skyline Alerter when Windows starts* option.

1. If you want Alerter to automatically connect to the DataMiner System when it starts, select the *Automatic login* option, and specify the logon account it has to use to do so.

    - **As Window user**: If you select this option, Alerter will connect to the DataMiner System using your current Windows account.

    - **As custom user**: If you select this option, then Alerter will connect to the DataMiner System using the logon credentials you specify.

    > [!NOTE]
    > When you change the user account with which Alerter logs on to the DataMiner System, Alerter will automatically reconnect.

1. Click *OK*.

## Setting an alarm filter in Alerter

It is possible to filter the alarms that will generate alerts, so that your attention is only drawn to a specific subset of alarms. To do so, you can use a combination of client-side filters and server-side filters.

To configure Alerter filters:

1. Go to *Settings \> Filter*.

1. Select the options you wish to apply:

    | Filter option          | Description                                                                                                                                                                                                                                                                                                                                                                                                                                              |
    |--------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Client-side filter       | In this section, you can configure a client-side severity filter. Select the severities for which an alert should be displayed. Though this will not stop alarms from entering the Alerter *Alarms* list, only the alarms with the selected severities will generate alerts.                                                                                                                                         |
    | Use server-side filter   | If you select this option, click the ellipsis button on the right, and select one or more of the available alarm filters. Only alarms matching the alarm filters will be sent to Alerter.                                                                                                                                                                                                                                                                |
    | Use client-side filter   | If you select this option, click the ellipsis button on the right, and select one or more of the available alarm filters. Though all alarms will be sent to Alerter, only alarms matching the alarm filters will generate an alert. If you combine this option with the first *Client-side filter* option, alerts will only be generated for alarms that match the selected filters and have the selected severities. |
    | Only retrieve new alarms | If you select this option, Alerter will not receive any alarms that already exist at the moment when you connect to the DMS. Only alarms that are generated from that moment onwards are sent to Alerter and can potentially generate alerts, depending on the client-side filter configuration.                                                                                                                                                         |
    | Hide acknowledged alarms | If you select this option, when Alerter receives an alarm that is acknowledged, that alarm will still be added to the *Alarms* list, but no alert will be generated, even if the alarm matches the client-side filters.                                                                                                                                                                                                   |
    | Hide cleared alarms      | If you select this option, when Alerter receives an alarm that is cleared, that alarm will still be added to the *Alarms* list, but no alert will be generated, even if the alarm matches the client-side filters.                                                                                                                                                                                                        |

    > [!NOTE]
    > The alarm filters that you can select with the *Use server-side filter* and *Use client-side filter* options can be configured in DataMiner Cube. See [Working with saved alarm filters](xref:ApplyingAlarmFiltersInTheAlarmConsole#working-with-saved-alarm-filters).

1. Click *OK*.

> [!NOTE]
> Alerter never shows masked alarms.

## Configuring alarm storm prevention in Alerter

In case many alarms occur at the same time, it is possible to make sure that you are not flooded with alarm notifications. Instead, an alarm storm can be triggered, so that you receive only one notification that warns about the start of an alarm storm.

To configure alarm storm prevention:

1. Go to *Settings \> Filter*.

1. Click the button *Alarm storm prevention*.

1. In the *Alarm storm prevention* window, select *Override default alarm storm prevention*

1. Enter the *Minimum number of alarms* that triggers an alarm storm, and specify whether this number should be counted *Per filter* or *For all filters*.

1. Below this, enter the time span in which these alarms need to occur.

1. Click *OK*.

> [!NOTE]
> Alerter alarm storm prevention can also be configured on system level, rather than on user level only. For more information, see [Configuring alarm storm prevention for notifications](xref:Configuring_alarm_storm_prevention_for_notifications).

## Setting the notification options in Alerter

Do the following if you want to change settings with regard to alarm sounds and pop-up balloons:

1. Go to *Settings \> Notification type*.

1. If you want the pop-up balloons to disappear automatically after a period of time, select the option *Automatically hide balloon notification*, and enter the number of milliseconds you want the balloon to stay visible.

1. If you want to hear specific sounds when a pop-up balloon appears:

    1. Select the *Enable sound* option

    1. Right-click underneath *Filter* and select *Add*.

    1. In the *Filter and sound selection* window, do the following:

        - Select the filter or filters for which you want to play a particular sound file.

        - Select the *.wav* file to be played.

        - Select the *Repeat* option if you want the file to be played over and over again.

        - Select the *Stop playing after* option and enter a number of seconds if you want the file to be played for an exact number of seconds.

    1. Click *OK*.

    1. To play a different sound for another filter, repeat from step 2 to add another filter and sound.

    > [!NOTE]
    > To use this feature, you must have Windows Media Player installed on your client computer.

1. If you just want to hear the generic computer beep when a pop-up balloon appears, select the *Enable beep* option.

## Configuring Alerter pop-up balloons

By default, a pop-up balloon only shows the alarm severity, element name, parameter name, parameter value and timestamp. However, it is possible to configure the balloons to also show any of the alarm properties that can be shown in the DataMiner Cube Alarm Console.

To do so:

1. Go to *Settings \> Balloon*.

1. For every property you wish to add, click the *Add property* button, and select the property. E.g. *Service impact*, *Services*, etc.

1. To remove a property, select it in the list of additional properties, and click *Remove property*.

    > [!NOTE]
    > The default properties cannot be removed.

1. To change the order in which the additional properties will appear in the balloon, use the *Up* and *Down* buttons to move a selected property accordingly.

> [!NOTE]
> - You can add as many alarm properties to the pop-up balloons as you like. If too many properties are added to show them at once in the balloon, it will be possible to scroll through them with a scrollbar.
> - An element name, service name or view name will be underlined to indicate that you can click these to respectively open the element, service or view information in your default client application.

## Configuring options related to acknowledging alarms

From DataMiner 10.0.10 onwards, it is possible to fine-tune what happens when an alarm is acknowledged via an Alerter pop-up balloon.

To do so:

1. Go to *Settings* > *Acknowledge*.

1. Select the checkboxes for the following options according to your preference:

    - *Hide the comment window when acknowledging an alarm*: By default, when you take ownership of an alarm via an Alerter pop-up balloon, you also need to specify a comment. If this option is selected, the comment window is not shown.

    - *Set the alarm as read in Cube after the alarm has been acknowledged*: If both Alerter and DataMiner Cube are used on the same client machine and the same user is connected to both applications, you can select this option to have an alarm marked as read as soon as you acknowledge it via an Alerter pop-up balloon.
