---
uid: Using_DataMiner_Objects_Tool
---

# Using the DataMiner Objects Tool

## Low-Code App

All functionality of the tool is accessible via the *Filter All DataMiner Objects* button, highlighted in the screenshot below by number 1. It launches an interactive Automation script *DataMiner Objects Tool* giving an overview of each supported DataMiner object type. Pressing one of the types will open a new dialog where the filters can be defined.

There are 3 more buttons available in the app. Each button is related to a common DataMiner object type, being resources, reservation instances and DOM instances. For each of these types, the app shows some high level statistics about the system.

For **reservation instances**, the app shows the total number of reservation instances in the system along with a pie chart that groups the reservation instances by state.  The button next to these stats launches the same *DataMiner Objects Tool* script, but immediately opens the dialog to filter reservation instances. This part is indicated in the screenshot by number 2.

For **resources**, the app shows the total number of resources in the system along with a pie chart that groups the resources by resource pool.  The button next to these stats launches the same *DataMiner Objects Tool* script, but immediately opens the dialog to filter resources. This part is indicated in the screenshot by number 3.

For **DOM instances**, the app shows the total number of DOM instances in the system along with a pie chart that groups the DOM instances by module.  The button next to these stats launches the same *DataMiner Objects Tool* script, but immediately opens the dialog to filter DOM instances. This part is indicated in the screenshot by number 4.

![Low-Code App buttons](~/user-guide/images/Using_DataMiner_Objects_Tool.png)

## Interactive Automation script

### Configuring Filters

See the screenshot below for more details.

1. **Including/excluding filters** can be done by checking or unchecking the checkbox next to the item property name.

1. **Filter type** can be selected using the dropdowns marked with number 2. Different properties allow different filter types depending on their possible values.

1. **Filter value** can be filled in in the boxes marked with number 3. Depending on the property that is being filtered on, this will we strings, integers, Guids or datetimes.

1. **Adding more filters** can be done using the duplicate button, marked with number 4. There is no limit on the amount of filters you can include.

1. **Executing the query** with the included filters can be done using the button at the bottom. Marked in the screenshot below with number 5.

> [!IMPORTANT]
> All included filters will be combined with an AND operation. There is currently no way of adding OR filters.

![Configuring filters](~/user-guide/images/Using_DataMiner_Objects_Tool_ConfiguringFilters.png)

### Fine-tuning results

Once the items are retrieved based on the filters, there is the possibility to fine-tune the selection manually, as shown in the screenshot below.

1. The **amount of matching items** is displayed to give a quick view on how many total items are in the system that match the filters.

1. **Selecting/unselecting all items** can be done using the buttons marked with number 2.

1. The **amount of selected items** is also displayed to keep the user aware of his current selection.

1. A scrollable checkbox list allows users to **individually select/unselect** items to fine-tune the result to their wishes.

![Fine-tuning results](~/user-guide/images/Using_DataMiner_Objects_Tool_FinetuningResults.png)
