---
uid: FAQs_Pricing
---

# Pricing

## Commercial models

### What commercial and deploy models does Skyline offer?

Commercial models define how you pay for software and determine ownership and usage rights. We offer two models:

- [Usage-based services](xref:Pricing_Usage_based_service)
- [Perpetual-use licenses](xref:Pricing_Perpetual_Use_Licensing)

Deploy or delivery models determine how that same software is deployed. We offer three models:

- Self-managed on private/public cloud or on-premises
- Software-as-a-Service (SaaS)
- Hybrid: self-managed DataMiner nodes with Storage-as-a-Service (STaaS)

Usage-based services can use any of the deploy models.

Perpetual-use licenses can be fully self-managed (DataMiner nodes and storage nodes) or hybrid.

### Regarding hosted services, is Skyline's SaaS offering a single-tenant or multitenant environment?

Skyline's DataMiner SaaS platform is composed of:

- DataMiner nodes responsible for data collection, control and processing, and
- storage nodes to store collected data, ensuring data persistence, redundancy, and high availability.

DataMiner nodes (DaaS — DataMiner as a Service) are not multitenant because DaaS uses isolated compute nodes independent from other users. This offers some advantages related to increased security and isolation for access to your managed objects.

Storage nodes (STaaS - Storage as a Service), on the other hand, are multitenant, with data for each specific DataMiner System being isolated in a logical partition. You can only ever access the logical partition dedicated to your own DataMiner System, and all partitions are strictly isolated from each other.

### Can different commercial models exist in the same organization?

Yes. Licensing and usage are measured at the DMS (DataMiner System) level. An organization can have perpetual licenses on one DMS while running usage-based services on a different DMS.

### Can different commercial models exist in the same DataMiner System?

Yes, but limited. If a DMS has a perpetual license, it can use Collaboration Services, Unmanaged Objects, and STaaS from the usage services.

### Can I transition my perpetual licenses into a subscription?

Yes. Your Account Manager will be able to provide more information and assist you with this.

### Are there any sign-up fees or one-time fees for usage-based models?

No.

## Professional Service credits

### What is the difference between buying specific product codes (e.g. DataMiner Fundamentals Training) and credits?

There is no difference in pricing: whether you buy a specific product or an equivalent number of credits, the cost is the same. The difference is **flexibility**:

- **Service credits** can be used for **any** type of service.
- **Product codes** can only be used for that specific service.

Procurement teams often need to define budgets before knowing exactly what services are needed. This makes credits a more practical option. Product-specific purchases often result in unused services or scope changes, which create administrative overhead (change orders, new quotes, etc.).

### Can I use Professional Service credits in exchange for DataMiner credits?

No.

### Can I order specific product codes instead of credits?

Yes. You can always request a quote from the Skyline Sales Team.

## DataMiner credits

### What are DataMiner credits?

DataMiner credits are a form of currency used to subscribe to DataMiner software and hosting services. They are typically used for usage-based offerings such as DaaS (DataMiner as a Service) or STaaS (Storage as a Service).

> [!TIP]
> For definitions of related terms such as "DataMiner credits," see [Usage terms](xref:Pricing_Usage_based_service#usage-terms).

### Where can I check the current DataMiner credit balance of my organization?

You can view the current DataMiner credit balance for your organization in the [Admin app](https://admin.dataminer.services/).

### How can I acquire more DataMiner credits?

You can order additional DataMiner credits through the Azure Marketplace.  
See [Order DataMiner credits](xref:Order_DataMiner_credits).

For further assistance, contact [your Account Manager](https://community.dataminer.services/get-in-touch/sales-team/).

---
