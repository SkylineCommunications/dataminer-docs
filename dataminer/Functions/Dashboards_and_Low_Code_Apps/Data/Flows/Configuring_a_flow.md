---
uid: Configuring_a_flow
---

# Configuring a flow

The *Flows* data item in a dashboard or low-code app allows you to build a flow that lets you manipulate any available data according to your specific requirements.

Flows are available starting from DataMiner web 10.4.12. The minimum required server version is 10.4.0 or 10.3.9.<!-- RN 40974 -->

To create a flow:

1. In edit mode, go the *Data* pane on the right, expand the *Flows* item, and click the + icon.

   This will open the flow editor pop-up window.

1. In the *Name* box, enter a descriptive name for the new flow.

   ![Renaming a flow](~/dataminer/images/Flow_Rename.png)<br>
   *Renaming a flow in DataMiner 10.4.12*

1. In the *Data* pane on the left, select one or more data sources you want to manipulate with the flow and drag them to the center of the editor.

   If you add only one data source, this will be considered a valid flow. If no operators have been added yet, it will behave in the same way as if you were using the data directly. When you add another data source, the flow will no longer be considered valid until an operator has been applied, as a flow always has to have a single output.

   ![Adding data to a flow](~/dataminer/images/Flow_Add_Data.gif)<br>
   *Adding data to a flow in DataMiner 10.4.12*

1. In the *Operators* pane on the left, select the operator you want to use and drag it to the editor.

   You could for example add the *Merge* operator to combine two data sources:

   ![Adding Operator to a Flow](~/dataminer/images/Flow_Add_Operator.gif)<br>
   *Adding an operator to a flow in DataMiner 10.4.12*

1. Connect the data blocks and the operator to create a valid flow with one output.

   For example:

   ![Connecting Blocks in the Flow](~/dataminer/images/Flow_Connecting_Blocks.gif)<br>
   *Connecting blocks in a flow in DataMiner 10.4.12*

1. Click *Create* to save the flow.
