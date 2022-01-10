## Adding a custom command to the Alarm Console shortcut menu

1. Go to the *C:\\Skyline DataMiner* root directory of one of your DataMiner Agents and open the file *Hyperlinks.xml*.

    If this file does not exist, create it.

2. In the XML file, specify all custom commands. For more information, see [Hyperlinks.xml](../../part_7/SkylineDataminerFolder/Hyperlinks_xml.md#hyperlinksxml).

3. Force a synchronization of the file *Hyperlinks.xml* throughout your DataMiner System:

    1. In DataMiner Cube, go to *Apps* > *System Center*.

    2. Go to the *Tools* tab and select *synchronization*.

    3. In the drop-down list next to *Type*, select *File*.

    4. In the *File* box, specify the following path: *C:\\Skyline DataMiner\\Hyperlinks.xml*.

    5. Click the *Sync now* button.

In case DataMiner Cube was open while you edited the settings, the changes will only be applied after you close and reopen Cube.

> [!NOTE]
> Even after a forced synchronization, the hyperlinks you added or updated will only be visible when you right-click an alarm raised after the update of the *Hyperlinks.xml* file.

> [!TIP]
> See also:
> - <https://community.dataminer.services/video/alarm-console-extending-the-right-click-menu/>
> - [Linking a shape to an Automation script](../visio/Linking_a_shape_to_an_Automation_script.md)
>
