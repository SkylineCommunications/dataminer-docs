---
uid: Creating_a_Scheduler_template
---

# Creating a Scheduler template

To create scheduler templates, which will show up in the EVENT list in Scheduler, use the Automation module:

1. In DataMiner Cube, go to *Apps* > *Automation*.

1. In the folder pane on the left, create a script folder called “Scheduler Templates” if no such folder exists yet. For more information, see [Adding a new Automation script folder](xref:Managing_Automation_scripts#adding-a-new-automation-script-folder).

   Any scripts in this folder will be detected by DataMiner Scheduler as possible events.

1. Select the “Scheduler Templates” folder, and click the *Add script* button to add a script.

1. Configure the script as described in the section [Designing Automation scripts](xref:Designing_Automation_scripts). However, in order for the script to be usable as a Scheduler template, add a parameter named “Action”.

   > [!NOTE]
   > While the scheduled task runs, the value of the “Action” parameter will automatically be set to “START” or “STOP”, in accordance with the start and stop timestamps linked to the left and right border of the task rectangle in Scheduler.

1. Additional configuration of the scheduler event is possible by adding comments at the top of the script:

   - For each profile you want to create for the event, add a comment as follows:

     ```txt
     Preset="ProfileName" [Parameter name]="value"[Dummy name]="[DMA ID]/[Element ID]"
     ```

     Example: To define an Event Profile called “MyPresets” containing a preset value for two parameters called “From” and “To” and one dummy called “MyDummy”, the following comment is added: *Preset="MyPresets" From="a" To="b" MyDummy="34/2"*. In this example, the dummy value is “34/2”, meaning Element ID 2 of DMA ID 34.

   - To display text on the task rectangle for an event, add a comment as follows:

     ```txt
     Display="Text to be displayed".
     ```

     You can also have script dummies or script parameters displayed this way, by using the following syntax:

     - For a dummy: *Display="{d:MyDummy}"*

     - For a parameter: *Display="{p:MyParameter}"*

   - To display a custom tooltip over the task rectangle for an event, add a comment as follows:

     ```txt
     ToolTip="Tooltip text"
     ```

     > [!NOTE]
     > If no custom tooltip is defined, the default tooltip will be displayed, which shows the value of every parameter and dummy.
