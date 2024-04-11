---
uid: BestPracticesRemoteKpis
---

# Best practices to retrieve parameters

## Retrieving data from EPM element

If you want to display data from an EPM Object card onto a Visio, it is best practice to create a cardVar that holds the element information instead of using placeholder [this Element]. This will provide a static variable for the Visio, this prevent it from doing a look up on the placeholder every time.

![image](~/user-guide/images/EPM_cardVar_with_element_info.png)

## Retrieving data from a remote element

In EPM environment, there can be data in other elements that a user needs to be displayed on a Visio. In this case, it is recommended to have an DMA ID/Element ID column in the EPM Object table. This will allow for more efficient retrieval of data from the different elements.

Once this is in place you can create a card Variable in the Visio that will store this element information. The card variable will be set using the Execute shape data field, where you will be using the param option to retrieve the value for a specific EPM Object based on the primary key. Since this will be the DMA ID/Element ID, the card variable will now be able to be used as an element object in Visio.

Here is example of how the syntax would look.

This will create an empty CardVariable

![image](~/user-guide/images/EPM_syntax_example_partitionElement.png)

![image](~/user-guide/images/EPM_syntax_example_partitionElement2.png)

> [!NOTE]
>
> - From DataMiner 10.0.2 onwards, you can configure the shape so that clicking it opens an alarm tab in the Alarm Console.
> - The FilterContext option will allow you to link the shape to an EPM object by using one or both of the following options
>   - From DataMiner 10.3.0/10.2.3 onwards, you can add an EPM system name filter. In that case, "X" should be "SystemName=" followed by the EPM system name.
>   - From DataMiner 10.3.0/10.2.3 onwards, you can add an EPM system type filter. In that case, "X" should be "SystemType="followed by the EPM system type.
>   - The SystemName and SystemType context can be combined using the syntax FilterContext=SystemName=X;SystemType=Y.

Links to more detailed information:

- [Initializing a session variable](xref:Initializing_a_session_variable).
- [Configuring a page to update a session variable](xref:Configuring_a_page_to_update_a_session_variable_when_another_session_variable_changes)
