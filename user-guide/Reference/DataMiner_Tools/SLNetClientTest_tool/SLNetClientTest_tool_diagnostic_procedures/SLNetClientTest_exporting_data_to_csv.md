---
uid: SLNetClientTest_exporting_data_to_csv
---

# Exporting data to a CSV file

For debugging purposes, you can export data from the SLNetClientTest tool to a CSV file that is updated whenever the data is refreshed. The data in that file can then, for example, be used to track the evolution of a certain value over time.

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Request information that can be displayed in a refreshable text window, for example: *Diagnostics \> SLNet \> StackSizes*.

1. Double-click the relevant message in the main window to open the text window.

1. In the text window, select *Export* and either select an existing export file or select *\<Add New>* to add a new file.

   > [!NOTE]
   > Multiple exports can be added for the same window.

1. Configure the export file in the *Export Configuration* window and click *Save*.

   A line will be added to the CSV file whenever the data is refreshed (manually or automatically).

   Closing the main window will stop the export.

To delete existing exports, follow the same procedure, and click delete in the *Export Configuration* window.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
