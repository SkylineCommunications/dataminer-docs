---
uid: EpmIntegrationTrainingAggregations
---

# Alarm Console Navigation
You can link a shape to an alarm filter in Visio, allowing the user to navigate to the alarm filter tab in the alarm console. This can be done by adding shape data fields called AlarmSummary and AlarmTab with the following syntax.
- AlarmSummary
  ```xml
      type|sharedfiltername|ApplyLinkedViewServiceOrElementFilter|Alarm|FilterContext=X
  ```
- AlarmTab
    ```xml
      Name=MyFilteredTab
    ```
> [!NOTE]
> - From DataMiner 10.0.2 onwards, you can configure the shape so that clicking it opens an alarm tab in the Alarm Console.
> - The FilterContext option will allow you to link the shape to an EPM object by using one or both of the following options
>   - From DataMiner 10.3.0/10.2.3 onwards, you can add an EPM system name filter. In that case, "X" should be "SystemName=" followed by the EPM system name.
>   - From DataMiner 10.3.0/10.2.3 onwards, you can add an EPM system type filter. In that case, "X" should be "SystemType="followed by the EPM system type.
>   - The SystemName and SystemType context can be combined using the syntax FilterContext=SystemName=X;SystemType=Y.

For more detailed information [click here](https://docs.dataminer.services/user-guide/Basic_Functionality/Visio/linking_shapes/Linking_a_shape_to_an_alarm_filter.html).

# Visual Example
![image](https://github.com/Daniela-Prada/dataminer-docs/assets/102039927/e989dc61-20ff-41ce-b444-9d1e3808bd99)

