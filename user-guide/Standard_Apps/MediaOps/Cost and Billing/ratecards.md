---
uid: cost_billing_ratecards
---

# Ratecards

Ratecards provide essential information for cost calculation and billing calculation. Let's explore the details of ratecards:

1. **Billing Ratecards**:
   - These ratecards are attached to job nodes (such as workflows, resources, and resource pools). They describe how these nodes are charged based on their usage duration during job execution.
   - Billing ratecards define the currency used for billing.

1. **Cost Ratecards**:
   - These ratecards are attached independently to resources and resource pools. They describe the cost associated with these nodes.
   - Cost ratecards also define the currency used for describing costs.

Both Cost and Billing ratecards contain the same key components:

1. **Currency**: Contracts can include discounts that are applied when calculating the bill.

1. **Minimal time interval**: Represents the minimum amount of time a job will be charged. If a job's duration is less than this interval, the minimal time interval is applied.

1. **Minimal time increment**: Specifies the unit of increments added beyond the minimal time interval. If a job's duration exceeds the minimal time interval, the time charged is in multiples of the minimal time increment.

1. **Capped rate per job**: Sets a limit on the payment for the attached job node's duration.

1. **Rates**: Rates describe how much is charged per each unit of time (minutes, hours, days or use). Example: A truck driver costs 75 USD each hour. A ratecard can have multiple rates with different units of time.

    - **Rate**: The amount of money to be charged by a specified unit of time.
    - **Unit**: The specified unit of time during which the rate applies.

    > [!WARNING]
    > It is not possible to add 2 different rates with the same unit of time. This is yet to be enforced by the UX!

## Managing ratecards

The Ratecard's Overview page quickly summarizes the state of your managed Ratecards. In this page you will find a pie chart that clearly describes how many Cost and Billing Ratecards you have. How many are in a Draft state and how many were Archived. Additionally, you can see the last five created ratecards along with their most important details.

<img src="~/user-guide/images/mediaops_cb_ratecards-overview.png">

The main way to manage your ratecards is done in the "List" page. It can be accessed from the Ratecards's Overview by clickin on the "List" button on the top left corner.

<img src="~/user-guide/images/mediaops_cb_ratecards-list.png">

The table list all existing ratecards and some of their most important details like Currency, Type (Definition Name), Minimal Time Interval, Minimal Time Increment, Capped Rate per Job and more.

### Creating a ratecard

You can create a Cost or Billing Ratecard from the Ratecards Overview by clicking on the "+ New Billing Ratecard" or "+ New Cost Ratecard" button on the right corner of the page. Alternatively, you can click on the "List" button on the top left corner to navigate to the Ratecards list page. In the Ratecards list page, you can click on the "+ New Billing Ratecard" or "New Cost Ratecard" on the top right corner of the page. A new ratecard form will be displayed in the center of the screen. After filling in the form, you can click on the "Save" button on the top right corner to complete creating the new Ratecard.

<img src="~/user-guide/images/mediaops_cb_new-ratecard-form.png">

### Editing a ratecard

To edit an existing ratecard, navigate to the Ratecards list page by clicking on the "List" button on the top left of the Ratecard's Overview page. Each row represents a ratecard and contains a *pencil* button at the end of the row. Click on this button to edit the ratecard. A form will be displayed in the middle of the page with the current ratecard data already filled in. After changed the desired fields you can click on the "Save" button on the top right corner of the form to save your changes.

<img src="~/user-guide/images/mediaops_cb_new-ratecard-form.png">

### Deleting a ratecard

To delete a ratecard, start by Editing the Ratecard as explained in the section above. Then, click on the "Delete" button on the top left corner of the form.

### Rates

To visualize the rates included in a ratecard, navigate to the Ratecards List page, accessible by clicking on the "List" button from the Ratecards Overview page. A table with all existing ratecards will be displayed. Each row represents one ratecard and contains a button in a column called "Rates". When clicking that button, a panel will appear from the right side of the screen listing the available rates described by the selected ratecard.

<img src="~/user-guide/images/mediaops_cb_ratecard-rates.png" width="400">

### Contracts

It is possible to visualize which Contracts a Ratecard is being used on. On the Ratecard List page, each row represents an individual Ratecard. On the far right there is a button on a column called "Contracts". When you click on this button a panel will appear from the right. It contains the selected Contract on the top, and below, a list of Contracts where the selected Ratecard is being used in.

<img src="~/user-guide/images/mediaops_cb_ratecard-contracts.png" width="400">
