---
uid: Viewing_billing_information
keywords: billing, credits, balance, usage costs, subscriptions, services
---

# Viewing billing information

On the *Billing* page of the Admin app, you can find a comprehensive overview of your organization's credit usage and costs for dataminer.services. This page allows you to monitor your credit balance, track service consumption, view subscription costs, and analyze historical spending patterns to manage your DataMiner System expenses effectively.

With the **date selector** at the top, you can view billing information for different months, allowing you to analyze costs across different time periods.

> [!TIP]
> For more information about commercial and deploy models, see [What commercial and deploy models does Skyline offer?](xref:FAQs_Pricing#what-commercial-and-deploy-models-does-skyline-offer)

> [!NOTE]
> This page is only accessible for users with the Admin or Owner role.

## Balance

The *Balance* displays your current credit balance available for dataminer.services usage. This represents the total number of credits remaining in your account that can be used to pay for various services and subscriptions.

- Credits are consumed when you use pay-per-use (PPU) services or when you create, renew, or commit to a subscription (charged up front for the whole period).
- You can purchase additional credits using the **Buy credits** button in the top-right corner.
- The balance is updated in real time when services are consumed or when new credits are purchased.
- A low balance may impact your ability to use certain services, so monitoring this regularly is important.
- Click the **Credit history** button to view all credit transactions. See [Viewing your credit history](xref:Viewing_your_credit_history) for more information.

## Services overview

The *Services* table provides a detailed breakdown of all services consuming credits in the selected time period. Services are organized into categories that can be expanded or collapsed for better overview.

Use the month selector at the top of the page to view costs for different months. Note:

- The current month's data is updated on a daily basis with real-time usage.
- Previous months show finalized billing data.
- Billing for each month is processed on the 5th of the following month (for example, January usage is billed on February 5th).

Each service displays its credit cost with a color-coded indicator:

- **Green**: Subscriptions cost.
- **Orange**: PPU cost.

The costs shown reflect the consumption for the currently selected time period.

## Monthly savings

The *Monthly Savings* indicator shows the amount of credits saved, when fully consuming all reservations in subscriptions, during the current month compared to standard pricing.

## Subscriptions panel

- **Active subscriptions**: A list of all current subscriptions with their total costs.
- **Add subscription**: See [Adding a subscription](xref:Adding_Subscription).
- **All subscriptions**: Link to view detailed information about all available and active subscriptions. See [Viewing your subscriptions](xref:Viewing_your_subscriptions).

## Historical cost breakdown

The **Historical cost breakdown** chart visualizes your credit consumption over time, allowing you to:

- **Identify spending trends**: Track how your costs evolve over multiple months.
- **Compare cost types**: The chart distinguishes between:
  - **Subscription costs** (green bars): Fixed costs for active subscriptions. These costs are calculated pro rata if a subscription does not start or end on the first or last day of the month.
  - **PPU costs** (orange bars): Variable costs based on actual service usage.
- **Plan budget**: Use historical data to forecast future costs and budget accordingly.
- **Detect anomalies**: Quickly spot unusual spikes in consumption that may require investigation.

The chart typically displays data for the last several months. Hover over individual bars to see exact credit amounts for each cost type.
