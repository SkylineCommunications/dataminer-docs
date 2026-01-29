---
uid: Subscriptions
keywords: subscriptions, billing, credits, data plane, automation, collaboration services
---

# Subscriptions

The Subscriptions page provides a comprehensive overview of all subscriptions associated with your organization's dataminer.services account. It allows you to monitor active subscriptions, review expired ones, track costs and savings, and view detailed breakdowns of what each subscription includes.

## Automatically Assigned Subscriptions

Certain subscriptions are automatically assigned to organizations:

- **Community Edition**: Automatically provided for all organizations at no cost. This subscription includes essential reservations for managed objects, metrics, unmanaged objects, actions, shares, and connectors, allowing you to use dataminer.services with a comprehensive set of features included. The subscription renews automatically every year at no cost to the user. For more information, see [DataMiner Community Edition](https://docs.dataminer.services/dataminer/About_DataMiner/Pricing/Pricing_Commercial_Models.html#dataminer-community-edition).

- **Hosting subscriptions**: Assigned only to [DataMiner as a Service (DaaS)](xref:DaaS_hosting) trial systems for a 7-day period. These limited-time subscriptions provide the hosting resources needed to run your trial environment, including metrics, alarm updates, information events, trend data points, and element data updates.

## Accessing Subscriptions

To access the Subscriptions page:

1. Navigate to the Billing page in the Admin app.
2. Click on **All subscriptions** in the Subscriptions Panel.

## Subscriptions Table

The **Subscriptions** table displays all your subscriptions, both current and historical. Each subscription entry includes:

### Name

The **Name** column displays the subscription name.

### State

The **State** column uses color-coded badges to indicate the subscription status:

- **Active** (green): The subscription is currently active and reservations are available for consumption.
- **Planned** (yellow): The subscription is scheduled to start in the future.
- **Expired** (red): The subscription has ended and is no longer providing reservations.
- **Expires soon** (orange): The subscription is nearing its expiration date and will end within 30 days.

### Timestamp

The **Timestamp** column shows important dates for the subscription:

- **From [date]**: For planned subscriptions, indicates when the subscription will start.
- **Until [date]**: For active subscriptions, indicates when the subscription will expire.
- **Ended [date]**: For expired subscriptions, shows when the subscription ended.

The timestamp helps you track renewal dates and plan for subscription management.

### Total Paid

The **Total paid** column displays the total amount of credits paid for the subscription. This represents:

- The actual cost of the subscription in credits.
- For promotional or free subscriptions, this may show 0.00 credits.

### Total Saved

The **Total saved** column shows the amount of credits saved through the subscription compared to pay-per-use pricing:

- Displayed in blue to highlight savings.
- Represents the difference between PPU costs and subscription pricing.
- Higher savings indicate better value from using subscription-based pricing.

### Subscription Details

Click the subscription row, or the information icon (i) in the last column to open a detailed panel showing the full breakdown of what's included in the subscription.

## Subscription Details Panel

When you click the information icon for a subscription, a **Subscription details** panel opens on the right side, displaying comprehensive information about the subscription.

### Header Information

At the top of the panel, you'll see:

- **Subscription name**: The name of the selected subscription.
- **State**: Current status (Active, Expired, or Expires soon).
- **From**: The start date of the subscription.
- **Until**: The end date of the subscription.
- **Auto-renewal**: Toggle indicator showing whether the subscription automatically renews.

### Resource Breakdown

The panel displays all reservations included in the subscription, organized into expandable categories.
At the bottom of the panel, the **Total** row displays:

- **PPU**: The total pay-per-use cost if resources were purchased individually.
- **Paid**: The actual amount paid for the subscription.
- The difference represents your total savings.

## Managing Subscriptions

### Adding a Subscription

To add a new subscription, click the **+ Add subscription** button in the top-right corner. For detailed information on purchasing and managing subscriptions, see [Adding a Subscription](xref:Adding_Subscription).

### Monitoring Expiration

Pay attention to subscriptions marked as **Expires soon** to ensure continuity:

- Review the expiration date in the Timestamp column.
- Purchase a new subscription before the current one expires to avoid service interruption.
- Subscriptions with **Planned** status will automatically become **Active** when their start date is reached.

### Auto-Renewal

If a subscription is configured with auto-renewal enabled:

- The subscription will automatically renew on the expiration date with the same duration and reservations, provided your organization has sufficient credits.
- Note that new pricing may apply at the time of renewal.
- If there are not enough credits in your balance, the subscription will not renew automatically.
- In case of insufficient credits, organization Owners and Admins will be notified via email.

You can check the auto-renewal status in the Subscription details panel.

### Understanding Savings

The subscription model provides cost savings when you fully utilize the included reservations:

- Compare the **Total saved** column to see the financial benefit of each subscription.
- Review the Subscription details panel to understand which reservations provide the most value.

## Search and Filter

Use the search icon in the top-right corner of the table to quickly find specific subscriptions by name or filter by status.

---

> [!NOTE]
> The Subscriptions page is only accessible to Owners and Admins of the organization.
