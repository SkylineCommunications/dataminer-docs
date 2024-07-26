---
uid: Automatic_incident_tracking
---

# Automatic incident tracking

This DataMiner Analytics feature groups active alarms that are related to the same incident, so that the Alarm Console provides a better overview of the current issues in the system. Unlike Correlation tracking, this can happen completely automatically, without any configuration by the user. DataMiner Analytics automatically detects which alarms share a common trait and groups them as one incident.

The following factors, in order, are taken into account for the grouping:

- Time

- Alarm focus information (see [Filtering alarms on alarm focus](xref:ApplyingAlarmFiltersInTheAlarmConsole#filtering-alarms-on-alarm-focus)).

- The polling IP (for timeout alarms only)

- Service information

- Relation Learning: parameter relationship data (from DataMiner 10.3.1/10.4.0 onwards) and alarm relationship data (from DataMiner 10.3.7/10.4.0 onwards)<!--RN 36337-->, on DataMiner Agents that are connected to dataminer.services, have the [DataMiner Extension Module *ModelHost*](xref:DataMinerExtensionModules#modelhost) installed, and have been configured to [offload alarm and change point events to the cloud](xref:Controlling_cloudfeed_data_offloads).

- The IDP location

  > [!NOTE]
  > The IDP location will only be taken into account if IDP is deployed and the option *Update alarms on value changed* is selected for the element properties 'Location Name', 'Location Building', 'Location Floor', 'Location Room', 'Location Aisle' and 'Location Rack'. See [Adding a custom property to an item](xref:Managing_element_properties#adding-a-custom-property-to-an-item).

- View information

- Parameter information

- Element information

- Alarm, element, service or view properties, if these have been configured for incident tracking (see [Advanced Configuration](#advanced-configuration)).

If a single factor is used, it is mentioned in the value of the created alarm group.

The above-mentioned factors are applied in order, meaning that if multiple factors apply, the one listed first takes precedence. For example, if two alarms are from the same device (element factor) and also belong to the same service (service factor), the value of the alarm group will refer to the service, not the device, because the *Service information* factor is listed before the *Element information* factor.

Sometimes, multiple factors are combined to create an alarm group. For example, if you have a device with two alarms (*Element information* factor), and Relation Learning indicates one of these alarms is related to a different alarm on another element, a group of three alarms is created. In this case, the alarm group's value will indicate it is a "multiple reasons group".

If no suitable match is found, alarms will not be grouped. Also, since only alarms with an alarm focus score are taken into account, automatic incident tracking does not apply to information events, suggestion events or notice messages.

The grouping of alarms into incidents is updated in real time whenever appropriate:

- New alarms are added to existing groups if they match.

- A group is cleared if its base alarms are cleared or if the reason for its original creation comes to an end.

- If a group is cleared, any alarms in the group that are still active may be regrouped if other matching alarms exist, either in a new group or in an existing one.

> [!NOTE]
>
> - Using automatic incident tracking with history sets is supported; however, keep in mind that this may trigger the creation and immediate clearing of a large number of alarm groups.
> - When an element is stopped or paused, the alarms associated with that element will not be taken into account when grouping alarms. Also, alarms associated with elements that are stopped or paused will be removed from any existing alarm group.

## Automatic incident tracking configuration in System Center

In DataMiner Cube, you can enable this feature in System Center, via *System settings* > *analytics config* > *automatic incident tracking*. From DataMiner 10.2.0/10.2.1 onwards, in new installations and in systems upgrading from DataMiner versions that did not support automatic incident tracking yet, it is enabled by default.

> [!NOTE]
> Automatic incident tracking relies on the [alarm focus](xref:ApplyingAlarmFiltersInTheAlarmConsole#filtering-alarms-on-alarm-focus) functionality. Ensure this feature is enabled in System Center, via *System Center* > *System settings* > *analytics config*, to guarantee the creation of alarm groups.

The following settings are available in System Center:

- *Enabled*: Allows you to activate or deactivate this feature. Note that when you upgrade to DataMiner 10.0.11, the feature is automatically disabled, unless it has previously been activated as a soft-launch feature.

- *Leader DataMiner ID*: The DMA performing all incident tracking calculations. By default, this is the DMA with the lowest DataMiner ID at the time when alarm grouping is enabled.

- *Maximum group size*: Available from DataMiner 10.1.11/10.2.0 onwards. When an alarm group reaches the maximum size specified in this setting, a new group will be created with all remaining alarms that belong to the same incident. Default value: 1000.

- *Maximum time interval*: The maximum time interval between alarms that can be grouped as one incident. If the root times of alarms are further apart than the configured interval, the alarms will not be grouped. Default value: 10 minutes.

- *Maximum group events rate*: Available from DataMiner 10.2.1/10.2.0 onwards. The maximum number of alarm group events that can be generated per second. This setting is used to avoid possible performance issues during alarm floods. If more events are generated per second than the specified number, the generation of events is slowed down, and a notice alarm is generated. As soon as the number of generated events drops below the threshold again, the notice alarm is cleared and events are again generated as quickly as possible. Default value: 100.

## Activating automatic incident tracking

When this feature has been enabled in System Center as detailed above, it still needs to be activated in the Alarm Console. To do so, in the Alarm Console hamburger menu, select *Automatic incident tracking*.

> [!NOTE]
> Automatic incident tracking is only shown for active alarms, not for history alarms. Consequently, from DataMiner 10.2.0 [CU12]/10.3.3 onwards, the *Automatic incident tracking* option is not available for a history tab in the Alarm Console. <!-- RN 35556 -->

## Advanced configuration

Automatic incident tracking strives to maximize the amount of information used for grouping alarms.
By default, every available source of information listed above will be taken into account. However, in some cases it can be beneficial to tweak this configuration by disabling specific grouping reasons or by defining custom ones.
This can be achieved by modifying the file found at *C:\\Skyline DataMiner\\analytics\\configuration.xml*.

Every source of information that can be used to group alarms on is called a *Property*.
The feature comes with a series of predefined properties, each identified by an xml block in the *configuration.xml* file:

    <item type="skyline::dataminer::analytics::workers::configuration::XMLConfigurationProperty&lt;class std::shared_ptr&lt;class skyline::dataminer::analytics::workers::configuration::VisitorConfiguration&gt; &gt;">
        <Value type="skyline::dataminer::analytics::workers::configuration::VisitorConfiguration">
            <enable>true</enable>
        </Value>
        <Accessibility>2</Accessibility>
        <Name>ElementProperty</Name>
    </item>

The \<Name> tag indicates the source of information used for grouping. For example, the above property refers to the ability to group alarms on the same element.

The \<enable> tag indicates if a source of information should be used or not. It can be set to *false* if no alarm group of that type is desired.

Some properties come with an additional \<threshold> tag. This extra configuration makes it possible to calibrate the statistical significance of the property when grouping alarms:

    <item type="skyline::dataminer::analytics::workers::configuration::XMLConfigurationProperty&lt;class std::shared_ptr&lt;class skyline::dataminer::analytics::workers::configuration::StatisticalVisitorConfiguration&gt; &gt;">
        <Value type="skyline::dataminer::analytics::workers::configuration::StatisticalVisitorConfiguration">
            <enable>true</enable>
            <threshold>0.5</threshold>
        </Value>
        <Accessibility>2</Accessibility>
        <Name>ViewProperty</Name>
    </item>

In the example above, Automatic Incident Tracking is configured to group alarms under the same view, but only if the proportion of elements in alarm among all elements under that view is greater than the configured threshold of 50%.
As a rule of thumb, a lower threshold results in a quicker but less reliable triggering on alarm groups. A higher threshold will result in slower triggering with a higher confidence.

From DataMiner 10.2.0/10.1.4 onwards, it is also possible to define custom properties: alarm, element, service or view properties can be taken into account when grouping alarms, as long as they have been configured as detailed below.
Alarms are grouped as soon as they have the same value for one of the configured alarm, service or view properties, the same focus value and approximately the same timestamp. For element properties, the grouping of alarms will also depend on a statistical threshold as explained above.

The following basic configuration is needed in Cube:

- For the properties that should be taken into account, the option *Update alarms on value changed* must be selected. See [Adding a custom property to an item](xref:Managing_element_properties#adding-a-custom-property-to-an-item).

In addition, the following configuration is needed in the *configuration.xml* file:

For each custom defined alarm, element, view or service property, add an \<item> tag within the \<Properties> tag of the Automatic Incident Tracking xml configuration group as below. Make sure to set the \<Name> tag to *GenericProperties*, any other name will result in a reading error.

  ```xml
  <item type="skyline::dataminer::analytics::workers::configuration::XMLConfigurationProperty&lt;class std::vector&lt;class std::shared_ptr&lt;class skyline::dataminer::analytics::workers::configuration:: IGenericPropertyVisitorConfiguration&gt;,class std::allocator&lt;class std::shared_ptr&lt;class skyline::dataminer::analytics::workers::configuration:: IGenericPropertyVisitorConfiguration&gt; &gt; &gt; &gt;">
    <Value>
      [One <item> tag per property that has to be taken into account. See below for details]
    </Value>
    <Accessibility>2</Accessibility>
    <Name>GenericProperties</Name>
  </item>
  ```

Fill the \<Value> tag with the appropriate information as illustrated below. Note that every item type specifies the type of property at hand. Therefore, there is no need to specify the property type suffix in the \<name> tag.
For example, when grouping alarms on the *Alarm.Node* property, make sure to select the Generic**Alarm**PropertyVisitorConfiguration type and specify just *Node* in the \<name> tag.

- For an **element property**, configure this \<item> tag as illustrated below. Make sure to replace \[PROPERTY_NAME\] with the name of the element property and \[THRESHOLD\] with the desired threshold.

  ```xml
  <item type="skyline::dataminer::analytics::workers::configuration::GenericElementPropertyVisitorConfiguration">
    <enable>true</enable>
    <threshold>[THRESHOLD]</threshold>
    <name>[PROPERTY_NAME]</name>
  </item>
  ```

- For an **alarm property**, configure this \<item> tag as illustrated below. Make sure to replace \[PROPERTY_NAME\] with the name of the alarm property.

  ```xml
  <item type="skyline::dataminer::analytics::workers::configuration::GenericAlarmPropertyVisitorConfiguration">
    <enable>true</enable>
    <name>[PROPERTY_NAME]</name>
  </item>
  ```

- For a **view property**, configure this \<item> tag as illustrated below. Make sure to replace \[PROPERTY_NAME\] with the name of the view property.

  ```xml
  <item type="skyline::dataminer::analytics::workers::configuration::GenericViewPropertyVisitorConfiguration">
    <enable>true</enable>
    <name>[PROPERTY_NAME]</name>
  </item>
  ```

- For a **service property**, configure this \<item> tag as illustrated below. Make sure to replace \[PROPERTY_NAME\] with the name of the service property.

  ```xml
  <item type="skyline::dataminer::analytics::workers::configuration::GenericServicePropertyVisitorConfiguration">
    <enable>true</enable>
    <name>[PROPERTY_NAME]</name>
  </item>
  ```

After editing and saving the configuration file, **restart the SLAnalytics process on the leader agent** to make sure the desired changes take effect.

  > [!TIP]
  > The *configuration.xml* files are not yet synced across a dataminer cluster. For this reason, it is important to always edit the file on the leader agent.
  > If possible, it is good practice to manually replace the file on all agents of a cluster at the same time.
  > This way, no unwanted behavior will occur when changing the leader agent at a later moment.

### Troubleshooting advanced configuration

The following steps should be taken if no change in grouping behavior can be noticed after going through all the above configuration steps:

- Check that the edited file is effectively located on the same agent as specified in the configuration under *Leader DataMiner ID*.
- Check that the SLAnalytics process was actually restarted on that same agent.
- If the *configuration.xml* file gets overwritten after an SLAnalytics restart, check the logs. Most likely a deserialization error occurred and the process fell back onto the default configuration. Check the edited parts of the file to make sure they comply with the xml structure described above.

> [!NOTE]
  > Because of some compatibility issues, systems where certain previous versions of dataminer have run in the past might be unable to apply these changes even if every step was correctly executed. This could be the case if every setting is correct an the logs contain no errors but the desired change in grouping behavior does not occur. As a workaround, it is possible to delete the xml file, restart the SLAnalytics process, wait for a new default file to be created and start again from there.

## Alarm groups in the Alarm Console

In the Alarm Console, alarm groups are displayed as a special kind of alarm entries:

- The icon of an alarm group is similar to that of a correlated alarm.

- The alarm color of an alarm group entry reflects the highest severity of the alarms within the group, but the severity of the group itself is *Suggestion*.

- The parameter description of the entry is *Alarm Group*.

- The value of the entry is the reason why the alarms are grouped. If there is no single obvious reason, the value will be Group with multiple reasons.

- The root time of the group is the time when the most recent alarm in the group occurred, at the moment when the group was created.

- If alarms are added to a group or removed from a group, the alarm type will be updated from *New alarm* to *Base alarms changed*.

- You can expand the group to view all alarms within it.

- If all alarm entries within an alarm group are masked, the group is automatically masked as well. However, as soon as one of the entries is unmasked, the group is also unmasked.

- [Manually clearing](xref:Clearing_alarms) alarm groups that were created automatically is supported from DataMiner 10.3.8/10.4.0 onwards<!-- RN 36600 -->. For [manually created/updated alarm groups](#manually-updating-an-alarm-group), this is supported from DataMiner 10.2.6/10.3.0 onwards.

## Manually updating an alarm group

From DataMiner 10.2.5/10.3.0 onwards, it is possible to manually update an alarm group or "incident". In the Alarm Console, you can add or remove alarms, create an alarm group manually, or rename an alarm group.

- To **create an alarm group**, right-click an alarm that is not part of an alarm group yet, and select *Add to incident*. In the pop-up window, select to create a new incident and add the alarm to it.

- To **add an alarm** to an existing alarm group, right-click an alarm that is not part of an alarm group yet, and select *Add to incident*. In the pop-up window, select to add the alarm to an existing incident.

  > [!NOTE]
  > The following types of alarms cannot be added to an alarm group: correlated alarms, information events, suggestion events, other alarm groups, and clearable alarms. Prior to DataMiner 10.2.9/10.3.0 it is also not possible to add alarms without focus information, such as notices and errors.

- To **remove an alarm** from an alarm group, right-click an alarm that is part of an incident and select *Remove from incident*.

- To **rename an alarm group**, click the pencil icon next to the alarm group name and specify a new name.

- To **move an alarm** from one alarm group to another (supported from DataMiner 10.2.6/10.3.0 onwards), right-click an alarm that is part of an incident and select *Move to another incident*. You will then be able to select a different incident or create a new one to add the alarm to.

- From DataMiner 10.2.7/10.3.0 onwards, you can also modify an alarm group with **drag-and-drop editing**. To do so:

  1. In the Alarm Console, open the side panel. See [Alarm Console right-click menu](xref:AlarmConsoleRightClickMenu).

  1. Select the alarm group in the Alarm Console.

  1. In the side panel, click *Drag-and-drop editing*.

     This will freeze the current alarm tab and lock the side panel to the currently selected alarm group. To make changes, you can then:

     - Drag an alarm from the alarm tab to the side panel to add it to the alarm group.
     - Click the *x* next to an alarm in the side panel to remove it from the alarm group.

     > [!NOTE]
     > If you right-click an alarm group and select *Edit incident*, this will open the side panel and activate drag-and-drop editing, so you can edit the alarm group in the same way as described here.

  1. When you are done, click *Apply*.

> [!NOTE]
>
> - When an alarm group has been updated manually, it will no longer be updated automatically.
> - From DataMiner 10.2.6/10.3.0 onwards, you can manually create an alarm group even when the *Automatic incident tracking* option is not activated in the alarm tab. From DataMiner 10.2.7/10.3.0 onwards, this is even possible when incident tracking is not [enabled in System Center](#automatic-incident-tracking-configuration-in-system-center).
> - From DataMiner 10.2.6/10.3.0 onwards, the right-click menu of an incident also allows you to take/(force) release ownership of the incident, add a comment, clear the incident in case it was created manually, assign a ticket to the incident, or view a ticket that was assigned to the incident.
> - From DataMiner 10.2.6/10.3.0 onwards, when an alarm group is created or edited manually, it will always receive focus. Automatically created alarm groups receive focus if at least one of the base alarms has focus. See [Filtering alarms on alarm focus](xref:ApplyingAlarmFiltersInTheAlarmConsole#filtering-alarms-on-alarm-focus).
