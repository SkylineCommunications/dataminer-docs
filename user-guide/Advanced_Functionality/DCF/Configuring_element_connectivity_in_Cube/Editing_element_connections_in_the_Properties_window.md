---
uid: Editing_element_connections_in_the_Properties_window
---

# Editing element connections in the Properties window

To edit the connections for an element that has in/out interfaces defined in its protocol:

1. Right-click the element, select *Properties*, and go to the *connectivity* tab.

1. If you want to edit internal connections, go to the *internal* tab.

1. In the *State* column, select either *Not connected* to disconnect an input/output, or select *Connected to* to create a connection.

   > [!NOTE]
   > To quickly find a particular input or output, use the quick filter in the top right corner. See [Using quick filters](xref:Using_quick_filters).

1. To create an internal connection, click in the *interface* column and select the interface to connect to.

   To create an external connection, select an element in the *external element* column, and then click in the *interface* column and select the interface to connect to.

   > [!NOTE]
   >
   > - While it is possible to create an external connection to the same source element, you cannot make a connection to the same interface.
   > - Whenever manual changes are done to an external connection, an information event will be generated in the Alarm Console.

1. To create an additional connection from the same input/output, click the *+* icon to the right of the connection to duplicate the line, and proceed according to the previous step.

   You can remove additional connections by clicking the *x* icon next to the *+* icon.

1. Optionally, add a filter in the *filter* column.

   > [!NOTE]
   > This filter is a name that you can give to several connections that form a path. The filter can then be used to for instance highlight a path composed of connections with the same filter in a Visual Overview drawing. See also [Highlighting a connection chain based on a filter shape](xref:Highlighting_a_connection_chain_based_on_a_filter_shape).

1. When all the necessary connections have been configured, click the *Apply* button.

1. Click *OK* to close the *Properties* window.
