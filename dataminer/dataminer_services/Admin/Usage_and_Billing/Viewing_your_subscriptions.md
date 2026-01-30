---
uid: Viewing_your_subscriptions
keywords: subscriptions, billing, credits, data plane, automation, collaboration services
---

# Viewing your subscriptions

In the Admin app, you can find a comprehensive overview of all subscriptions associated with your organization's dataminer.services account. It allows you to monitor active subscriptions, review expired ones, track costs and savings, and view detailed breakdowns of what each subscription includes.

To access this overview, go to the **Billing** page in the Admin app, and click **All subscriptions** in the subscriptions panel.

> [!NOTE]
> The subscriptions information is only accessible for users with the Admin or Owner role.

## Automatically assigned subscriptions

Certain subscriptions are automatically assigned to organizations:

- **Community Edition**: Automatically provided for all organizations at no cost. This subscription includes essential reservations for managed objects, metrics, unmanaged objects, actions, shares, and connectors, allowing you to use dataminer.services with a comprehensive set of features included. The subscription renews automatically every year at no cost to the user. For more information, see [DataMiner Community Edition](xref:Pricing_Commercial_Models#dataminer-community-edition).

- **Hosting subscriptions**: Assigned only to [DataMiner as a Service (DaaS)](xref:DaaS_hosting) trial systems for a 7-day period. These limited-time subscriptions provide the hosting resources needed to run your trial environment, including metrics, alarm updates, information events, trend data points, and element data updates.

## Subscriptions overview

The **Subscriptions** table displays all your subscriptions, both current and historical. Each subscription entry includes the following information:

- **Name**: The subscription name.

- **State**: Indicates the subscription status using color-coded badges:

  - **Active** (green): The subscription is currently active and reservations are available for consumption.
  - **Planned** (yellow): The subscription is scheduled to start in the future.
  - **Expired** (red): The subscription has ended and is no longer providing reservations.
  - **Expires soon** (orange): The subscription is nearing its expiration date and will end within 30 days.

- **Timestamp**: Shows important dates for the subscription, helping you track renewal dates and plan for subscription management:

  - **From [date]**: For planned subscriptions, indicates when the subscription will start.
  - **Until [date]**: For active subscriptions, indicates when the subscription will expire.
  - **Ended [date]**: For expired subscriptions, shows when the subscription ended.

- **Total Paid**: Displays the total credits paid for the subscription. This represents the actual cost of the subscription in credits. For promotional or free subscriptions, this may show 0.00 credits.

- **Total saved**: The number of credits saved through the subscription compared to pay-per-use pricing:

  - Displayed in blue to highlight savings.
  - Represents the difference between PPU costs and subscription pricing.
  - Higher savings indicate better value from using subscription-based pricing.

- **Subscription Details**: Click the subscription row or the information icon (i) in the last column to open a detailed panel showing the full breakdown of what is included in the subscription.

> [!TIP]
> With the search icon in the top-right corner of the overview, you can quickly find specific subscriptions by name or filter by status.

## Subscription details

When you click the information icon for a subscription, comprehensive information about the description is shown in a separate **subscription details** panel.

At the top of the panel, you will see the following information:

- **Subscription name**: The name of the selected subscription.
- **State**: Current status (Active, Expired, or Expires soon).
- **From**: The start date of the subscription.
- **Until**: The end date of the subscription.
- **Auto-renewal**: Toggle indicator showing whether the subscription automatically renews.

The panel displays all reservations included in the subscription, organized into expandable categories.

At the bottom of the panel, the **Total** row displays:

- **PPU**: The total pay-per-use cost if resources were purchased individually.
- **Paid**: The actual amount paid for the subscription.
- The difference represents your total savings.

## Managing subscriptions

### Adding a subscription

See [Adding a subscription](xref:Adding_Subscription).

### Monitoring expiration

Pay attention to subscriptions marked as **Expires soon** to ensure continuity:

- Review the expiration date in the *Timestamp* column.
- Purchase a new subscription before the current one expires to avoid service interruption.
- Subscriptions with **Planned** status will automatically become **Active** when their start date is reached.

### Auto-renewal

If a subscription is configured with auto-renewal enabled:

- The subscription will automatically renew on the expiration date with the same duration and reservations, provided your organization has sufficient credits.
- Note that new pricing may apply at the time of renewal.
- If there are not enough credits in your balance, the subscription will not renew automatically.
- In case of insufficient credits, organization Owners and Admins will be notified via email.

You can check the auto-renewal status in the subscription details panel.

### Understanding savings

The subscription model provides cost savings when you fully utilize the included reservations:

- Compare the **Total saved** column to see the financial benefit of each subscription.
- Review the subscription details panel to understand which reservations provide the most value.
