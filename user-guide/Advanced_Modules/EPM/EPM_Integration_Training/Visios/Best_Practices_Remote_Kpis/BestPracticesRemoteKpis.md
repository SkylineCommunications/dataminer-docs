---
uid: BestPracticesRemoteKpis
---

# Best Practies to Retrieve Paramters



# Retrieving Data from EPM Element
If you would like to display data from an EPM Object card onto a Visio, it is best practice to create a cardVar that holds the element information instead of using placeholder [this Element]. This will provide a static variable for the Visio, this prevent it from doing a look up on the placeholder everytime.

![image](https://github.com/Daniela-Prada/dataminer-docs/assets/102039927/1f21e879-03ad-4820-a6aa-b531c8f68089)

# Retrieving Data from Remote Element
In EPM environment, there can be data in other elements that a user needs to be displayed on a Visio. In this case, it is recommended to have an DMA ID/Element ID column in the EPM Object table. This will allow for more efficient retrieval of data from the different elements.

Once this is in place you can create a card Variable in the Visio that will store this element information. The card variable will be set using the Execute shape data field, where you will be using the param option to retrieve the value for a specific EPM Object based on the primary key. Since this will be the DMA ID/Element ID, the card variable will now be able to be used as an element object in Visio. 
Here is example of how the syntax would look.

This will create an empty CardVariable

![image](https://github.com/Daniela-Prada/dataminer-docs/assets/102039927/b1aed891-d64f-45df-a0fe-2502456bf90b)
![image](https://github.com/Daniela-Prada/dataminer-docs/assets/102039927/025996b5-75c2-4f67-a595-71b50b426976)

> [!NOTE]
> - From DataMiner 10.0.2 onwards, you can configure the shape so that clicking it opens an alarm tab in the Alarm Console.
> - The FilterContext option will allow you to link the shape to an EPM object by using one or both of the following options
>   - From DataMiner 10.3.0/10.2.3 onwards, you can add an EPM system name filter. In that case, "X" should be "SystemName=" followed by the EPM system name.
>   - From DataMiner 10.3.0/10.2.3 onwards, you can add an EPM system type filter. In that case, "X" should be "SystemType="followed by the EPM system type.
>   - The SystemName and SystemType context can be combined using the syntax FilterContext=SystemName=X;SystemType=Y.

Links to more detailed information: 
- [Initializing a session variable](https://docs.dataminer.services/user-guide/Basic_Functionality/Visio/session_variables/Initializing_a_session_variable.html).
- [Configuring a page to update a session variable](https://docs.dataminer.services/user-guide/Basic_Functionality/Visio/session_variables/Configuring_a_page_to_update_a_session_variable_when_another_session_variable_changes.html)
