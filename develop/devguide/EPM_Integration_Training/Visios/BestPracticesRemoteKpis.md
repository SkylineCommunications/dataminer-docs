---
uid: BestPracticesRemoteKpis
---

# Best practices for retrieving parameters

## Use a cardvar placeholder to display data from an EPM element

To display data from an EPM element in a visual overview on an EPM object card, it is better to use a [cardvar](xref:Placeholders_for_variables_in_shape_data_values#cardvarvariablename) placeholder with the element information instead of using a [this element] placeholder.

The *cardvar* will provide a static variable for the visual overview, which will prevent it from doing a lookup on the placeholder every time.

![cardVar variable example](~/develop/images/EPM_cardVar_with_element_info.png)

In the example above:

```txt
InitVar = _field:
```

```txt
Execute = [sep:-$]SET|CardVariable|_field|[Field]|SetTrigger=ValueChanged
```

Example of a live system:

![Live system](~/develop/images/Cardvar_Placeholder_Live_System_Example.png)

## Use a DMA ID/element ID column in the EPM Object table to retrieve data from remote elements

In an EPM environment, it can occur that data from other elements needs to be displayed in a visual overview. In this case, we recommend using a DMA ID/element ID column in the EPM Object table. This will allow for more efficient retrieval of data from the different elements.

Once this is in place, you can create a card variable in the visual overview that will store this element information.

The card variable should be set using the *Execute* shape data field. In the value of the shape data field, use a [param](xref:Placeholders_for_variables_in_shape_data_values#paramdmaidelementidparameteridtablerow) placeholder to retrieve the value for a specific EPM object based on the primary key. Since this value will be the DMA ID/element ID, it will now be possible to use the card variable as an element object in Visio.

For example, this will create an empty card variable named "_partitionElement":

```txt
InitVar = _field:|_partitionElement:|_epmFe:[this element]
```

```txt
Execute = _partitionElement|[param:[cardVar:_epmFe],2509,[cardVar:_field]]|SetTrigger=ValueChanged
```

Example of a live system:

![Live system](~/develop/images/Retrieve_Data_from_Remote_Elements_Live_System_Example.png)

> [!TIP]
> See also:
>
> - [Initializing a session variable](xref:Initializing_a_session_variable).
> - [Configuring a page to update a session variable](xref:Configuring_a_page_to_update_a_session_variable_when_another_session_variable_changes)
