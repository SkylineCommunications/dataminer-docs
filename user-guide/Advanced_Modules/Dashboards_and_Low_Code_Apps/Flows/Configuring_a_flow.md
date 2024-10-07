---
uid: Configuring_a_flow
---

# Configuring a Flow

The **Flows** data item allows you to build a flow that lets you manipulate any available data according to your specific requirements.

  > [!NOTE]  
  > Flows are available from dataminer version 10.4.12/10.4[CU9] and 10.3.9 server version with web only upgrade higher then 10.4.12/10.4[CU9]. 

## Creating a Flow

1. In edit mode, navigate to the data pane on the right-hand side of Dashboards or Low Code Apps. Select **Flows**, then click the **+** icon to create a new flow from scratch.

1. The Flow editor will now open. Here, you can design your flow. Begin by entering a descriptive name for the flow in the 'Name' textbox on the right-hand side of the editor.

![Renaming a Flow](~/user-guide/images/Flow_Rename.png)<br>
*Renaming a Flow*

1. On the left side, under the **Data** section, locate the data source you want to manipulate with the flow. Click and drag it into the center of the editor. At this stage, you've created a valid flow, though without any operators applied, it behaves the same as using the data directly from the component.

![Adding Data to a Flow](~/user-guide/images/Flow_Add_Data.gif)<br>
*Adding Data to a Flow*

1. Now, let's apply a **Merge** operator to combine this data with another source available in your dashboard or Low Code App. Add the second data source using the same method as before. Notice that the flow is no longer valid—flows must always have a single output.

1. Navigate to the **Operators** section and drag the **Merge** operator into the editor.

![Adding Operator to a Flow](~/user-guide/images/Flow_Add_Operator.gif)<br>
*Adding Operator to a Flow*

1. Connect the data blocks and the operator to create a valid flow with one output.

![Connecting Blocks in the Flow](~/user-guide/images/Flow_Connecting_Blocks.gif)<br>
*Connecting Blocks in the Flow*

1. Save the flow. You have now created a flow that merges two data sources into a single output.
