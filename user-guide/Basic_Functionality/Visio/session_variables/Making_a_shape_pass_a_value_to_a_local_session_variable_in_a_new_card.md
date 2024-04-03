---
uid: Making_a_shape_pass_a_value_to_a_local_session_variable_in_a_new_card
---

# Making a shape pass a value to a local session variable in a new card

From DataMiner 9.0.1 onwards, it is possible to configure a shape so that when it is clicked by a user, a new card opens and a value is passed to a local session variable on that card.

## Configuring the shape data field

Add the following two additional shape data fields to a shape that opens a card when clicked (i.e. a shape linked to an element, a service, a view, etc.):

| Shape data field | Value                                                                                                                                                                                                                          |
|------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| SetVar           | *VariableName*:*Value*<br> “VariableName” is the name of the session variable, and “Value” is the value that should be assigned to it when the shape is clicked. |
| Options          | *NewCardVariable*                                                                                                                                                                                   |

> [!NOTE]
> This feature is not operational within Mobile Visual Overviews (such as in the Monitoring app, Dashboards and Low code apps).
