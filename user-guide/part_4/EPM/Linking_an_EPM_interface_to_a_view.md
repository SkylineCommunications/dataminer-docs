---
uid: Linking_an_EPM_interface_to_a_view
---

# Linking an EPM interface to a view

If you want an EPM interface to be displayed when you select a view in the Surveyor, add the following properties to the view in question:

- **DDAElement:** The element ID of the EPM element.

    Syntax:

    ```txt
    DMA ID / Element ID
    ```

    Example:

    ```txt
    6/110936
    ```

- **DDAChain**: The EPM chain (optional). Set this property to the name of the EPM chain to select.

- **DDASelection**: The filter criterion (optional).

    Syntax:

    ```txt
    FieldPid=value
    ```

    Example:

    ```txt
    21001=Colorado
    ```

> [!NOTE]
> - You can select a chain without making a filter selection by leaving *DDASelection* empty and filling in *DDAChain*. If you specify a filter selection but leave *DDAChain* empty, the default chain is selected.
> - After you change these properties, you will need to reconnect in order to see the changes in effect.
> - To add a property to a view, follow the same procedure as to add a property to an element. See [Managing element properties](xref:Managing_element_properties).
