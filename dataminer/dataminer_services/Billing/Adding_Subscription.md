---
uid: Adding_Subscription
keywords: add, purchase, subscription, pricing, credits, reservations, buy, charge, usage, consumption, perpetual, license
---

# Adding a Subscription

The Add subscription dialog allows you to configure and purchase a new subscription for your organization. You can select the services and reservations you need, choose the subscription duration, and see the total cost before confirming your purchase.

## Opening the Add Subscription Dialog

To add a new subscription:

1. Navigate to the [Billing](xref:Billing) page in the Admin app.
2. Click the **+ Add subscription** button in the top-right corner.

The Add subscription dialog will open, displaying all available service categories and configuration options.

## Configuring your Subscription

### Service Categories and Reservations

The left side of the dialog displays all available service categories organized into expandable sections. Each category contains specific services that you can include in your subscription.

For each service, you can specify:

- **Volume / Month**: Use the number input to set how many units of each service you want to reserve per month.
- **Rate**: Displays the cost per unit in credits (e.g., "0.40 ⊙ / Each" or "2.00 ⊙ / 1,000"). When a discount is applied, the original price is shown with a strikethrough and the discounted price is displayed alongside a discount percentage badge (e.g., "-10%").
- **Cost**: Shows the calculated cost for your selected volume (automatically updated as you adjust volumes).
- **Info icon**: Hover over the information icon to view available volume discount tiers for applicable services.

#### Volume Discounts

Some services offer volume-based discounts. As you adjust the volume, the discount is automatically applied and displayed in the Rate column:

- The original price appears with a strikethrough.
- The discounted price is shown next to it.
- A blue badge displays the discount percentage (e.g., "-10%", "-15%", etc.).

You can hover over the information icon to see all available discount tiers for the service. Higher volumes and longer subscription durations typically unlock greater discount percentages.

### Subscription Configuration Panel

The right side of the dialog provides configuration options for your subscription:

#### Name

Enter a custom name for your subscription in the **Subscription name** field. This helps you identify the subscription later in the Subscriptions table.

#### Duration

Select the subscription duration:

- **1 year**: Standard annual subscription.
- **3 years**: Extended subscription for long-term commitment.
- **Custom**: Specify a custom number of months for the subscription duration.

Longer durations may qualify for additional discounts. 
You can also add shorter durations without discounts to lock in on the current credit rate.

#### From

Use the date picker to select when the subscription should start. By default, this is set to the current date. Note that you cannot select a date in the past.

#### Auto Renew

Toggle the **Auto renew** switch to enable automatic renewal:

- When enabled, the subscription will automatically renew on the expiration date with the same duration and reservation amounts, using the rates and discounts applicable at the time of renewal.
- Renewal requires sufficient credits in your organization's balance.
- New pricing may apply at renewal time.
- If insufficient credits are available, the subscription will not renew and the **Auto renew** switch will turn off.

For more information, see [Auto-Renewal](xref:Subscriptions#auto-renewal).

### Cost Summary

The bottom right panel displays the financial summary:

- **Savings**: Shows the total credits saved compared to pay-per-use pricing. Higher volumes and longer durations typically result in greater savings.
- **Total cost**: The total credit amount that will be charged for the subscription.
- **Current balance**: Your organization's current credit balance.
- **New balance**: Your projected balance after purchasing the subscription (Current balance - Total cost).

Make sure your new balance will be sufficient for ongoing operations.

## Purchasing your Subscription

Once you've configured all the desired services and settings:

1. Review the total cost and ensure your organization has sufficient credits.
2. Verify the subscription name, duration, and auto-renewal settings.
3. Click the **Confirm subscription** button to complete the purchase.
    - Credits will be deducted immediately after the purchase.

The new subscription will be created and will appear in the [Subscriptions](xref:Subscriptions) table with an "Active" or "Planned" status.

## Tips for Creating Subscriptions

- **Plan your volumes carefully**: Estimate your monthly usage to ensure you purchase adequate reservations while maximizing savings.
- **Check volume discounts**: For services with high usage, increasing volume may unlock significant discount tiers.
- **Consider longer durations**: Multi-year subscriptions often provide better pricing and reduce administrative overhead.
- **Monitor your balance**: Ensure you have enough credits for both the subscription purchase and ongoing pay-per-use services.
- **Use descriptive names**: Give subscriptions meaningful names to easily identify them later, especially if you have multiple.

---

> [!NOTE]
> The Add subscription feature is only accessible to Owners and Admins of the organization.
