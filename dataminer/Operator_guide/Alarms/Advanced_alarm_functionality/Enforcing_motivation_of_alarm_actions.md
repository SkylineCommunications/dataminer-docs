---
uid: Enforcing_motivation_of_alarm_actions
---

# Enforcing motivation of alarm actions

For specific alarm actions (mask, unmask, clear, etc.), you can specify that users must motivate their intention to take that action before they are allowed to proceed. As those user motivations are stored in alarm properties, all settings with regard to alarm action motivation requests have to be configured in the *PropertyConfiguration.xml* file, located in the folder `C:\Skyline DataMiner`.

To configure enforced motivation of alarm actions:

1. Go to the `C:\Skyline DataMiner` root directory of one of your DataMiner Agents and open the file *PropertyConfiguration.xml*.

1. In the XML file, create or update the properties that contain the motivations as follows:

   - In the *\<Property>* tag corresponding with the property, set the *motivationSource* attribute of the property to the action(s) that will require the user to specify a motivation.

     The following values can be specified:

     - Mask

     - UnMask

     - Acknowledge

     - UnResolved

     - Comment

     - Clear

     - MaskElement

     - UnMaskElement

     > [!NOTE]
     > To specify multiple actions for one property, separate them by commas.

   - If you want the user to select a motivation from a list, add *\<Entry>* subtags containing the predefined motivations they can choose from.

     For example, with the configuration below, users can choose between two predefined motivations when they attempt to perform a Mask or a MaskElement action:

     ```xml
     <Property id="21"
       type="Alarm"
       name="MaskMotivation"
       filterEnabled="true"
       visibleInSurveyor="false"
       motivationSource="Mask,MaskElement">
         <Entry metric="1">because I cannot fix it</Entry>
         <Entry metric="1">because it's not urgent</Entry>
     </Property>
     ```

     If you do not specify predefined motivations, a text box will be displayed instead of a selection box.

1. Save and close the file.

1. If the DMA is part of a cluster of several DMAs, force a synchronization of the *PropertyConfiguration.xml* throughout your DataMiner System:

   1. In DataMiner Cube, go to *Apps* > *System Center*.

   1. Go to the *Tools* tab and select *synchronization*.

   1. In the dropdown list next to *Type*, select *File*.

   1. In the *File* box, specify the following path: `C:\Skyline DataMiner\PropertyConfiguration.xml`.

   1. Click the *Sync now* button.

1. Restart DataMiner.

> [!TIP]
> See also:
> [Configuring alarm properties to motivate actions](xref:PropertyConfiguration_xml#configuring-alarm-properties-to-motivate-actions)
