---
uid: Making_a_shape_or_page_visible_only_for_a_particular_access_level
---

# Making a shape or page visible only for a particular access level

A shape or a page can be set to be visible only to users with a particular security access level.

> [!NOTE]
> - If the security settings have been configured so as to deny a user access to particular views or elements, then shapes linking to these views or elements will automatically not be displayed in Visual Overview.
> - For more information on how to make items in a table-based dynamically generated tree control visible based on security access level, see [Creating a tree control](xref:Adding_options_to_a_session_variable_control#creating-a-tree-control).

## Configuring the shape data field

Add a shape data field of type **Level** to the shape or page, and set its value to the minimum access level the user should have to be able to see the shape or the page.

The shape or the page will only be visible if the access level specified in the shape data field is higher than or equal to the user’s level of access to the object (view, element, service or redundancy group) to which the shape, the page or the Visio drawing is linked.

If, for example, the access level of a shape is 2, then users will only see that shape or that page if their level of access to the object (view, element, service or redundancy group) to which the shape or the page is linked is 1 or 2.

## ExactLevelMatch option

By default, when an access level is specified, it is interpreted as the minimum security level the user should have. If, however, you want it to the interpreted as the actual security level the user should have, then you can add the “*ExactLevelMatch*” option.

If, for example, you want a Visio page only to be visible to users who have explicitly been granted access level 3 to the object to which the Visio file is linked, then add two shape data items to the page:

- One of type **Level**, in which you specify the security access level “3”.

- One of type **Options**, in which you specify the option “*ExactLevelMatch*”.
