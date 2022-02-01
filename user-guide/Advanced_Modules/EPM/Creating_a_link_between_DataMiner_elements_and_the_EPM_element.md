---
uid: Creating_a_link_between_DataMiner_elements_and_the_EPM_element
---

# Creating a link between DataMiner elements and the EPM element

In DataMiner, two different kinds of links can exist between a regular DataMiner element and an EPM element:

- From an EPM element to a DataMiner element. This is the case when an EPM diagram item and a DataMiner element share the same name. The EPM diagram item will then automatically contain a link to the DataMiner element (i.e. a triangle in the top-right corner).

- From a DataMiner element to an EPM element.

    To create a link from a DataMiner element to an EPM element, configure the following element properties:

    | Element property | Value                              |
    |--------------------|------------------------------------|
    | DDAElement         | ID or name of the EPM element.     |
    | DDAChain           | Name of the EPM chain.             |
    | DDAField           | Name of the EPM field.             |
    | DDAPKValue         | Primary key value of the EPM item. |

Once the properties have been set correctly, in the right-click menu of the element you will be able to select *Open in Aggregation* to immediately view the relevant information in the EPM interface.
