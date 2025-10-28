---
uid: Customizing_alarm_grouping_rules
---

# Customizing alarm grouping rules

DataMiner Analytics strives to maximize the amount of information used for grouping alarms. By default, all [available source of information](xref:Automatic_incident_tracking) are taken into account for alarm grouping. However, in some cases, it can be beneficial to tweak this configuration by disabling specific rules for grouping or defining custom ones.

You can do so by modifying the *configuration.xml* file, located in the `C:\Skyline DataMiner\analytics\` folder of the leader Agent. If you are using a DataMiner System that consists of multiple DMAs, it is important that you modify the file on the server hosting that leader Agent. To find out which DMA is the leader Agent, see [Automatic alarm grouping configuration in System Center](xref:Automatic_incident_tracking#automatic-alarm-grouping-configuration-in-system-center).

Below you can find information about the [basic syntax](#basic-syntax), as well as detailed procedures for some of the rules. Customizing the other rules can be done in a very similar way to the described procedures.

After you have modified the file, you will also need to restart the *SLAnalytics.exe* process on the leader Agent for the changes to take effect.

> [!IMPORTANT]
> The *configuration.xml* files are not synced across a DataMiner cluster, and only the configuration on the leader Agent is taken into account. For this reason, it is important to always edit the file on the leader Agent. If possible, it is good practice to also synchronize the file across the cluster, so that no unwanted behavior will occur when the leader Agent is changed at a later moment. From DataMiner 10.5.1/10.6.0 onwards<!-- RN 41270 -->, you can [force the synchronization of the file via Cube](xref:Synchronizing_data_between_DataMiner_Agents). In earlier DataMiner versions, you will need to manually replace the file on all Agents in the cluster at the same time.

## Basic syntax

Every alarm grouping rule is based on a "Property" in the *configuration.xml* file. The feature includes a set of predefined properties and also allows you to define custom properties.

Each property is identified by an XML block in the *configuration.xml* file. For example:

```xml  
    <item type="skyline::dataminer::analytics::workers::configuration::XMLConfigurationProperty&lt;class std::shared_ptr&lt;class skyline::dataminer::analytics::workers::configuration::VisitorConfiguration&gt; &gt;">
        <Value type="skyline::dataminer::analytics::workers::configuration::VisitorConfiguration">
            <enable>true</enable>
        </Value>
        <Accessibility>2</Accessibility>
        <Name>ElementProperty</Name>
    </item>
```

- The \<Name> tag indicates the source of information used for grouping. The example above shows the property that determines whether alarms on the same element are grouped.

- The \<enable> tag indicates whether the rule should be applied or not. It can be set to *false* if no alarm group of that type is desired.

- Some properties include an additional \<threshold> tag. This configuration allows calibration of the statistical significance of the property when grouping alarms:

  ```xml
    <item type="skyline::dataminer::analytics::workers::configuration::XMLConfigurationProperty&lt;class std::shared_ptr&lt;class skyline::dataminer::analytics::workers::configuration::StatisticalVisitorConfiguration&gt; &gt;">
        <Value type="skyline::dataminer::analytics::workers::configuration::StatisticalVisitorConfiguration">
            <enable>true</enable>
            <threshold>0.5</threshold>
        </Value>
        <Accessibility>2</Accessibility>
        <Name>ViewProperty</Name>
    </item>
  ```

  In the example above, alarms under the same view are configured to be grouped, but only if the proportion of elements in alarm among all elements under that view exceeds the configured threshold of 50%.

  Generally, a lower threshold results in quicker but less reliable alarm group triggering, while a higher threshold results in slower triggering with higher confidence.

> [!TIP]
> For an introduction to the different properties and how you can use them, see [Tutorial: Fine-tune alarm grouping for your system](xref:Incident_Tracking_Configuration_Tutorial). Below you can also find some detailed procedures for specific properties.

## Enabling or disabling service-based alarm grouping

In the *configuration.xml* file, the *ServiceProperty* rule determines whether alarms are automatically grouped on parameters from the same service. By default, this is enabled.

To enable or disable service-based alarm grouping:

1. In the *configuration.xml* file on the leader Agent, locate the property with the name *ServiceProperty*.

1. Set `<enable>` to *true* or *false*, depending on whether you want to enable or disable the feature, respectively.

   For example, below this is set to *true*:

   ```xml
   <item type="skyline::dataminer::analytics::workers::configuration::XMLConfigurationProperty&lt;class std::shared_ptr&lt;class skyline::dataminer::analytics::workers::configuration::VisitorConfiguration&gt; &gt;">
      <Value type="skyline::dataminer::analytics::workers::configuration::VisitorConfiguration">
         <enable>true</enable>
      </Value>
      <Accessibility>2</Accessibility>
      <Name>ServiceProperty</Name>
   </item>
   ```

1. Save the file.

1. Restart the *SLAnalytics.exe* process on the leader Agent (e.g. using Windows Task Manager).

## Fine-tuning alarm grouping based on parameter and alarm relations

In the *configuration.xml* file, the *RelationsProperty* rule refers to the parameter relationship data (from DataMiner 10.3.1/10.4.0 onwards) and alarm relationship data (from DataMiner 10.3.7/10.4.0 onwards) available on DataMiner Agents that are connected to dataminer.services, have the [DataMiner Extension Module *ModelHost*](xref:DataMinerExtensionModules#modelhost) installed, and have been configured to [offload alarm and change point events to the cloud](xref:Controlling_cloudfeed_data_offloads).

This functionality assigns a *relation score* to any two parameters in your system. The score is a number between 0 and 1, where the value 1 refers to a very strong relation and the value 0 to a non-existing relation. The rule states that alarms on parameters with a relation score higher than mentioned in the *relationThreshold* tag will be grouped. The default relation threshold is 0.7.

You can enable or disable this type of alarm grouping, or adjust this threshold:

1. In the *configuration.xml* file on the leader Agent, locate the property with the name *RelationsProperty*.

1. Set `<enable>` to *true* or *false*, depending on whether you want to enable or disable the feature, respectively.

   For example, below this is set to *true*:

   ```xml
   <item type="skyline::dataminer::analytics::workers::configuration::XMLConfigurationProperty&lt;class std::shared_ptr&lt;class skyline::dataminer::analytics::workers::configuration::RelationVisitorConfiguration&gt; &gt;">
      <Value type="skyline::dataminer::analytics::workers::configuration::RelationVisitorConfiguration">
         <enable>true</enable>
         <relationThreshold>0.7</relationThreshold>
      </Value>
      <Accessibility>2</Accessibility>
      <Name>RelationsProperty</Name>
   </item>
   ```

1. Set the `<relationThreshold>` tag to a desired value between 0 and 1.

1. Save the file.

1. Restart the *SLAnalytics.exe* process on the leader Agent (e.g. using Windows Task Manager).

## Fine-tuning location-based alarm grouping

In the *configuration.xml* file, the *LocationProperty* rule determines whether alarms on devices in the same location are grouped. These are grouped if the fraction of devices in alarm at that location exceeds the value set in the *threshold* tag.

> [!NOTE]
> This rule can only be used if [DataMiner IDP](xref:SolIDP) is deployed in the DataMiner System.

You can enable or disable this type of alarm grouping, or adjust the threshold:

1. In the *configuration.xml* file on the leader Agent, locate the property with the name *LocationProperty*.

1. Set `<enable>` to *true* or *false*, depending on whether you want to enable or disable the feature, respectively.

   For example, below this is set to *true*:

   ```xml
   <item type="skyline::dataminer::analytics::workers::configuration::XMLConfigurationProperty&lt;class std::shared_ptr&lt;class skyline::dataminer::analytics::workers::configuration::StatisticalVisitorConfiguration&gt; &gt;">
       <Value type="skyline::dataminer::analytics::workers::configuration::StatisticalVisitorConfiguration">
           <enable>true</enable>
           <threshold>0.75</threshold>
       </Value>
       <Accessibility>2</Accessibility>
       <Name>LocationProperty</Name>
   </item>
   ```

1. Set the `<threshold>` tag to a desired value between 0 and 1.

1. Save the file.

1. Restart the *SLAnalytics.exe* process on the leader Agent (e.g. using Windows Task Manager).

## Defining custom properties for grouping

From DataMiner 10.2.0/10.1.4 onwards, it is possible to define custom properties. Alarm, element, service, or view properties can be taken into account when grouping alarms, if these have been configured as detailed below. Alarms are grouped as soon as they have the same value for one of the configured alarm, service, or view properties, the same focus value, and approximately the same timestamp. For element properties, alarm grouping also depends on a statistical threshold as explained above.

The following basic configuration is needed in Cube:

- For the properties that should be taken into account, the option *Update alarms on value changed* must be selected. See [Adding a custom property to an item](xref:Managing_element_properties#adding-a-custom-property-to-an-item).

In addition, the following configuration is needed in the *configuration.xml* file:

- For each custom-defined alarm, element, view, or service property, add an \<item> tag within the \<Properties> tag of the Automatic Alarm Grouping XML configuration group as shown below. Make sure the \<Name> tag is set to *GenericProperties*, as using any other name will result in a reading error.

  ```xml
  <item type="skyline::dataminer::analytics::workers::configuration::XMLConfigurationProperty&lt;class std::vector&lt;class std::shared_ptr&lt;class skyline::dataminer::analytics::workers::configuration:: IGenericPropertyVisitorConfiguration&gt;,class std::allocator&lt;class std::shared_ptr&lt;class skyline::dataminer::analytics::workers::configuration:: IGenericPropertyVisitorConfiguration&gt; &gt; &gt; &gt;">
    <Value>
      [One <item> tag per property that has to be taken into account. See below for details.]
    </Value>
    <Accessibility>2</Accessibility>
    <Name>GenericProperties</Name>
  </item>
  ```

  Make sure to replace the placeholder in the \<Value> section with the appropriate information. Each item type specifies the corresponding type of property, so you do not need to include the property type suffix in the \<name> tag.

  For example, when grouping alarms on the *Alarm.Node* property, make sure to select the `GenericAlarmPropertyVisitorConfiguration` type and use only *Node* in the \<name> tag.

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

After editing and saving the configuration file, **restart the SLAnalytics process on the leader Agent** to make sure the desired changes take effect.

## Troubleshooting

If you do not see the expected changes in grouping behavior after you have customized the *configuration.xml* file:

- Check whether the edited file is located on the Agent specified in the configuration under *Leader DataMiner ID*. (See [Automatic alarm grouping configuration in System Center](xref:Automatic_incident_tracking#automatic-alarm-grouping-configuration-in-system-center).

- Check whether the SLAnalytics process was restarted on that Agent.

- If the *configuration.xml* file gets overwritten after an SLAnalytics restart, check the logs for deserialization errors that may have caused a fallback to the default configuration. Review the edited parts of the file to make sure they comply with the XML structure described above.

Because of compatibility issues, systems that previously operated on certain older versions of DataMiner may not reflect changes in grouping behavior, even if all steps were executed correctly. This may happen when all settings are correct, and the logs show no errors, yet the expected change in grouping behavior does not take effect. As a workaround, you can delete the XML file, restart the SLAnalytics process, wait for a new default file to be generated, and then start the process again.
