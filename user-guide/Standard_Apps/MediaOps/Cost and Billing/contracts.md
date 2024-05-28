---
uid: cost_billing_contracts
---

# Contracts

Contracts play a crucial role in managing financial aspects within our application. Let's delve into the key components of contracts:

1. **Validity Period**: Contracts have a defined validity period with a start and end time. This ensures that the terms and conditions apply only during the specified timeframe.

1. **Discount**: Contracts can include discounts that are applied when calculating the bill.

1. **Uplift**: Contracts can include an uplift that is applied when calculating the bill. This will increase the total amount to the specified uplift percentage.

1. **Speed Order Fees**: Contracts may have zero, one, or more Speed Order Fees. These fees are applied based on how quickly a job starts after its booking confirmation. Speed Order Fees can be fixed amounts or incremental charges added to the total billing price.

1. **Cancellation Fees**: Similar to Speed Order Fees, contracts can also have zero, one, or more Cancellation Fees. These fees come into play if a job is canceled. Like Speed Order Fees, Cancellation Fees can be fixed or incremental.

1. **Billing Type**: Determines how to charge the jobs associated to this contract. The Billing Type can be Workflow base, Resource based or Workflow+Resource based:

    * Workflow - Charges the job based on its Workflow. Billing calculation will not take job nodes into account.
    * Resource - Charges the job based on its Nodes. Billing calculation will not take the job's workflow into account.
    * Workflow+Resource - Charges the job based on its Workflow and Nodes.

1. **Default Ratecards**: Specify ratecards to be used when no ratecard was assigned to individual workflows or resources.

    * Default Workflow Ratecard - Ratecard used by default to charge the job's workflow. If the contract doesn't specify a ratecard to a particular workflow, this is the ratecard that will be used instead.
    * Default Resource Ratecard - Ratecard used by default to charge the job's nodes. If the contract doesn't specify a ratecard to a particular resource or resource pool, this is the ratecard that will be used instead.

1. **Workflow Specific Billing Ratecards**: Assgin a ratecard to an individual Workflow

    * Ratecard - The ratecard to assign to an individual workflow.
    * Workflow - The specific workflow to be assigned the ratecard.

1. **Pool Specific Billing Ratecards**: Assgin a ratecard to an individual Resource Pool

    * Ratecard - The ratecard to assign to an individual resource pool.
    * Workflow - The specific resource pool to be assigned the ratecard.

1. **Resource Specific Billing Ratecards**: Assgin a ratecard to an individual Resource

    * Ratecard - The ratecard to assign to an individual resource.
    * Workflow - The specific resource to be assigned the ratecard.

## Managing Contracts

The Contract's Overview page is a great starting point to know what is going on. In this page, you can find graphs and charts breaking down contracts by their Billing Type, Validity and States. Additionally, you can see the 5 most recent created contracts including some of their details.

<img src="~/user-guide/images/mediaops_cb_overview.png">

The main way to manage your contracts is done in the "List" page. It can be accessed from the Contract's Overview by clickin on the "List" button on the top left corner.

<img src="~/user-guide/images/mediaops_cb_contracts-list.png">

The table list all existing contracts and some of their most important details like Name, State, Billing Type, Uplift, Discount and Validity Period.
It is also possible to visualize further contract details like Default Ratecards, Speed Order or Cancellation fees and Ratecards attached to specific Workflows, Resource Pools and Resources.

### Creating a contract

You can create a contract from the Contracts Overview by clicking on the "+" button top right corner of the Contract's Overview page. Alternatively, you can click on the "List" button on the top left corner to open the Contract's list, and clicking on "+ New Contract" on the top right corner. A form will be displayed. After filling the form in, click on the "Save" button on the top right corner to finish creating the new contract.

### Editing a contract

To edit a contract, navigate to the Contract's list page by clicking on the "List" button on the top left of the Contract's Overview. Click on the pencil "Edit" button on the far right side of each row to edit the contract you want. A form with current filled in values will be displayed. When finished editing you can click the "Save" button on the top right corner of the form.

### Deleting a contract

You can delete a contract by navigating to its "Edit" form as explained in "Editing a contract" section above. To the delete the contract click on the "Delete" button on the top left of the Editing form.

### Default Ratecards and Fees

On the Contract's list page, accessible by clicking the "List" button on the top left of the Contract's Overview page, each contract row has a button in a column called "More". When clicking on this button a side panel from the right will appear. This panel will contain the selected Contract on the top, the **Default Ratecards** in use by the selected contract, and the description of the fees at the bottom.

### Assigned Organizations

On the Contract's list page, accessible by clicking the "List" button on the top left of the Contract's Overview page, each contract row has a button in a column called "Organizations". When clicking on this button a side panel from the right will appear. This panel will contain the selected Contract on the top and an horizontal band listing all **Organizations** the selected Contract was assigned to. When clicking on an individual organization, the table at the bottom will list additional Contracts assigned to the selected Organization.

### Specific Workflow Ratecards

On the Contract's list page, accessible by clicking the "List" button on the top left of the Contract's Overview page, each contract row has a button in a column called "Workflow RCS". When clicking on this button a side panel from the right will appear. This panel will contain the selected Contract on the top and an horizontal band listing all **Workflows** the selected Contract has specific ratecards assigned to. When clicking on an individual Workflow, the table at the bottom will list additional Contracts this individual Workflow is included in.

### Specific Resource Pool Ratecards

On the Contract's list page, accessible by clicking the "List" button on the top left of the Contract's Overview page, each contract row has a button in a column called "Pool RCS". When clicking on this button a side panel from the right will appear. This panel will contain the selected Contract on the top and an horizontal band listing all **Resource Pools** the selected Contract has specific ratecards assigned to. When clicking on an individual Resource Pool, the table at the bottom will list additional Contracts this individual Resource Pool is included in.

### Specific Resource Ratecards

On the Contract's list page, accessible by clicking the "List" button on the top left of the Contract's Overview page, each contract row has a button in a column called "Resource RCS". When clicking on this button a side panel from the right will appear. This panel will contain the selected Contract on the top and an horizontal band listing all **Resources** the selected Contract has specific ratecards assigned to. When clicking on an individual Resource, the table at the bottom will list additional Contracts this individual Resource is included in.
