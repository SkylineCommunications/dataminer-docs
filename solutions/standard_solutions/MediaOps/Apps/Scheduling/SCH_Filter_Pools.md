---
uid: SCH_Filter_Pools
---

# Filter resource pool by category

For systems that have many resource pools it might become cumbersome to find the pools in the long list of pools. To make it easier to find back the relevant pools, you can filter the pools by a selected category. For now, a resource pool can only be assigned to one category.

## Creating categories

1. Go to the *Categories* application.

   ![Categories Application](~/solutions/images/Scheduling_Categories_Application.png)

1. Select the *Resource Pools* scope.

   ![Resource Pools Scope](~/solutions/images/Scheduling_Categories_Scope.png)

1. Click the *New Category* button to add a category.

   ![New Category](~/solutions/images/Scheduling_Categories_Add.png)

1. Give a name and save

   Ensure that the *Parent Category* is set to *(No Parent Category)*, as nested categories is not yet supported for resource pools. It is advised to keep the name under 13 characters to ensure it is nicely displayed in the Scheduling application.

   ![New Category](~/solutions/images/Scheduling_Categories_Add_Window.png)

## Assigning a category for a resource pool

1. Go to the *Resource Studio* application.

   ![Resource Studio Application](~/solutions/images/Resource_Studio_Application.png)

1. Open the *Edit Resource Pool* panel.

   ![Open Edit Resource Pool](~/solutions/images/Resource_Studio_Categories_Edit_Pool.png)

1. Set the category on the pool.

   ![Set category on Resource Pool](~/solutions/images/Resource_Studio_Categories_Set_Category.png)

## Filter pools from Scheduling

From the *Resource View* page or the *Add/Pick/Swap/Link Node* panels it is possible to filter down the pools by selecting a category.

Before Filtering | After Filtering
:---------------:|:------------------:
![Before Filtering](~/solutions/images/Scheduling_Categories_Before.png) | ![After filtering](~/solutions/images/Scheduling_Categories_After.png)
