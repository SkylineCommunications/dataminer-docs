---
uid: Variables
---

# Variables

Variables are reusable data objects that can be dynamically updated. They are defined independently from components and can be [passed to components as data](xref:Adding_data_to_component), linked in a [query](xref:Creating_GQI_query), used in a [flow](xref:Using_flows), and more.

Variables are available starting from DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41039-->.

## Creating a variable

To create a new variable:

1. In edit mode, go to the *Data* pane on the right, expand the *Variables* item, and click the + icon.

1. Specify a name for the variable. This name must be unique within the dashboard or the low-code app.

1. In the dropdown menu, select the **variable type**<!--RN 41063-->:

   - Element

   - Service

   - View

   - Object manager instance

   - Text

   - Boolean (available from DataMiner 10.4.0 [CU12]/10.5.3 onwards<!--RN 41845-->)

   - Number

   - Table <!--RN 41132-->

1. Optionally, enable the ***Read-only* setting** if you want the variable's value to remain fixed and unchangeable when interacting with the app. This setting is only available for Low-Code Apps, as Dashboard variables are always read-only.

1. Depending on the selected variable type, specify the **default value** for the variable.

   > [!NOTE]
   > In a low-code app, specifying a default value for a variable is optional, unless the variable is set to *Read-only*.

   - Default element: Enter the name of an element in your DataMiner System or select one from the dropdown list.

   - Default service: Enter the name of a service in your DataMiner System or select on from the dropdown list.

   - Default view: Enter the name of a view in your DataMiner System or select from the dropdown list.

   - Default object manager instance:

     1. Enter the name of a module in your DataMiner System or select from the dropdown list.

     1. Enter the name of an instance in your DataMiner System or select from the dropdown list.

     1. From DataMiner 10.4.0 [CU10]/10.5.0/10.5.1 onwards<!--RN 41251-->, select *Apply* to confirm your chosen DOM module and instance.

   - Default text: Enter custom text.

   - Default boolean: Choose *True* to enable the boolean variable by default, *False* to disable it, or *Empty* to leave it unset until a value is specified.

   - Default number: Enter a number or use the arrow icons to increase or decrease the value.

   - Default table: Configure a static table<!--RN 41132-->.

     1. Click the cogwheel icon to open the table editor.

        ![Table editor](~/dataminer/images/Variable_Table.png)<br>*Table editor in DataMiner 10.4.12*

     1. Under *Dimensions*, select the desired number of rows and columns and click *Resize*.

        > [!NOTE]
        >
        > - A table can contain a maximum of 20 columns and 100 rows.
        > - To add a row or column, hover over the table and click the + icon in the desired location.
        > - To change the order of rows or columns, click the ![drag-and-drop (rows)](~/dataminer/images/DragAndDrop.png) or ![drag-and-drop (columns)](~/dataminer/images/DragAndDropColumn.png) and drag the row or column to your preferred position.

     1. Enter names for each column.

     1. Add content to the cells.

        1. Click "ABC" in the top-right corner of a column header to select the data type (text, number, or boolean) for that column.

           ![data type](~/dataminer/images/Variable_DataType_Column.png)<br>*Table editor in DataMiner 10.4.12*

        1. Select a cell and enter a raw value, which will be used for business logic, such as sorting and filtering.

        1. Optionally, add a different display value, which will be used in the user interface. If left untouched, the display value defaults to the raw value.

        > [!NOTE]
        >
        > - Right-click a column header to insert or delete a column or change its data type.
        > - Right-click a cell to insert or delete a row or column.
        >
        >   ![Right-click menu](~/dataminer/images/Variables_Right-click_Menu.png)<br>*Table editor in DataMiner 10.4.12*

     1. Click *Save* in the lower-right corner.

1. Click the ![stop editing](~/dataminer/images/Stop_Editing.png) button to stop editing the variable.
