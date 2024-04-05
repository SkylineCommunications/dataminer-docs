# Best Practies to Retrieve Paramters

---
uid: EpmIntegrationTrainingAggregations
---

# Retrieving Data from EPM Element
If you would like to display data from an EPM Object card onto a Visio, it is best practice to create a cardVar that holds the element information instead of using placeholder [this Element], this will provide a static variable for the Visio and would not have to look up the placeholder everytime.

# Retrieving Data from Remote Element
In EPM where other data is in other elements and need to be displayed on a Visio, it is recommended to have an DMA ID/Element ID column in the EPM Object table. This will allow for more efficient retrieval of data from the different elements.

Once this is in place you can create a card Variable in the Visio that will store this element information. The card variable will be set using the Execute shape data field, where you will be using the param option to retrieve the value for a specific EPM Object based on the primary key. Since this will be the DMA ID/Element ID, the card variable will now be able to be used as an element object in Visio. 
Note: Hardcode the name of the frontend for best results
Here is example of how the syntax would look.
This will create an empty CardVariable


> [!NOTE]
> - From DataMiner 10.0.2 onwards, you can configure the shape so that clicking it opens an alarm tab in the Alarm Console.
> - The FilterContext option will allow you to link the shape to an EPM object by using one or both of the following options
>   - From DataMiner 10.3.0/10.2.3 onwards, you can add an EPM system name filter. In that case, "X" should be "SystemName=" followed by the EPM system name.
>   - From DataMiner 10.3.0/10.2.3 onwards, you can add an EPM system type filter. In that case, "X" should be "SystemType="followed by the EPM system type.
>   - The SystemName and SystemType context can be combined using the syntax FilterContext=SystemName=X;SystemType=Y.

For more detailed information [click here](https://docs.dataminer.services/user-guide/Basic_Functionality/Visio/linking_shapes/Linking_a_shape_to_an_alarm_filter.html).

# Visual Example
![image](https://github.com/Daniela-Prada/dataminer-docs/assets/102039927/e989dc61-20ff-41ce-b444-9d1e3808bd99)


