---
uid: SCH_Filter_Pools
---

# Filtering resource pools by category

For systems that have many resource pools, it might become cumbersome to find the pools in the long list of pools. To make it easier to find the relevant pools, you can filter the pools by a selected category. For this, categories need to be created in the *Categories* app.

For now, a resource pool can only be assigned to one category.

## Creating categories

1. Go to the *Categories* application.

   ![Categories app on the DataMiner landing page](~/solutions/images/Scheduling_Categories_Application.png)

1. Select the *Resource Pools* scope.

   ![Selecting the Resource Pools scope in the Categories app](~/solutions/images/Scheduling_Categories_Scope.png)

1. Click the *New Category* button to add a category.

   ![Clicking the New Category button](~/solutions/images/Scheduling_Categories_Add.png)

1. Specify a name for the category and save.

   Ensure that the *Parent Category* is set to *(No Parent Category)*, as nested categories are not yet supported for resource pools. We also recommend choosing a name of less than 13 characters to ensure that it is displayed optimally in the Scheduling application.

   ![Create New Category dialog with the example category name SAT](~/solutions/images/Scheduling_Categories_Add_Window.png)

## Assigning a resource pool to a category

1. Go to the *Resource Studio* application.

   ![Resource Studio app on the DataMiner landing page](~/solutions/images/Resource_Studio_Application.png)

1. Click the pencil icon next to a resource pool to open the *Edit Resource Pool* panel.

   ![The pencil icon that opens the Edit Resource Pool panel](~/solutions/images/Resource_Studio_Categories_Edit_Pool.png)

1. Select the *Category* checkbox and make sure the category of your choice is selected.

   ![Edit Resource Pool panel where the SAT category is selected for the Antennas resource pool](~/solutions/images/Resource_Studio_Categories_Set_Category.png)

## Filtering pools in the Scheduling app

From the *Resource View* page or the *Add/Pick/Swap/Link Node* panels, you can filter the resource pools by selecting a category.

| Before filtering | After filtering |
|:--:|:--:|
| ![Unfiltered Resource View page](~/solutions/images/Scheduling_Categories_Before.png) | ![Resource View page filtered on the SAT category](~/solutions/images/Scheduling_Categories_After.png) |
