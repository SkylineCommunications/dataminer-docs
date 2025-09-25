---
uid: Creating_a_DaaS_system_FAQ
keywords: cloud faq
---

# Frequently asked questions related to DaaS

### What are DataMiner credits?

DataMiner credits are a form of currency used to subscribe to DataMiner software and hosting services.

<div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
  <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
    <b>💡 TIPS TO TAKE FLIGHT</b><br>Unfamiliar with terms like "DataMiner credits"? Take a look at our list of <a href="xref:Pricing_Usage_based_service#usage-terms" style="color: #657AB7;">usage terms</a>.
  </div>
  <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
</div>

### Where can I check the current DataMiner credit balance of my organization?

The DataMiner credit balance of an organization is displayed in the [Admin app](https://admin.dataminer.services/).

### How can I acquire more DataMiner credits?

You can order DataMiner credits through the Azure Marketplace. See [Order DataMiner credits](xref:Order_DataMiner_credits).

For more information, contact [your Account Manager](https://community.dataminer.services/get-in-touch/sales-team/).

### When does maintenance take place on a DaaS system?

See [DaaS Planned Maintenance Policy](xref:DaaS_Planned_Maintenance_Policy).

### When does a DaaS system expire?

A DataMiner Community Edition DaaS system will be scheduled to expire as soon as the organization does not have sufficient DataMiner credits to extend its lifetime.

> [!NOTE]
> When an organization has multiple DaaS systems, they will be extended in chronological order. When your organization does not have enough credits left to extend one of your DaaS systems, that DaaS system will be scheduled to expire. However, at this point, you may still have a number of DataMiner credits left that will be considered reserved for your other DaaS systems.

### What happens when my DaaS system expires or is deleted?

When your DaaS system expires or is deleted, the system and all associated resources and data will be decommissioned.
However, the system can still be recovered within a limited grace period:

- 10 days &rarr; if the system was created less than 10 days ago.
- 30 days &rarr; if the system has been running for more than 10 days at the time of expiration/deletion.

To recover the system, contact [daas@dataminer.services](mailto:daas@dataminer.services). The cloud identity and shares will be lost, and the system will receive a new cloud identity within your organization upon recovery.

> [!NOTE]
> If you are an owner of the organization of a DaaS system or an owner of a DaaS system, you will get an email notification if your system is about to expire, for example because you do not have enough DataMiner credits left. Depending on how many DataMiner credits you use for other purposes, you will get this notification up to 5 days before the system expires. Another email notification will be sent when the system effectively expires.

### How can I manually delete my DaaS system?

You can delete your DaaS system at any time before its expiration. See [Removing a DaaS system](xref:Removing_a_DaaS_system).

### How can I create a new DaaS system?

Follow the instructions under [Creating a new DMS on dataminer.services](xref:Creating_a_DMS_on_dataminer_services).

### What is the expected availability of a DaaS system?

By default, a DaaS system has a target availability of 99.5%. This can be adjusted as part of a Master Service Agreement (MSA).

For more information, please contact <sales@skyline.be>.

### What data redundancy policy does a DaaS system have?

By default, a DaaS system has zone-redundant storage (ZRS). Geo-redundant storage (GRS) is optional at an additional subscription cost.

See also: [Data location and redundancy](xref:STaaS_features#data-location-and-redundancy).

### What system redundancy policy does a DaaS system have?

As of Q4 of 2024, DaaS systems can use [Swarming](xref:Swarming). Starting from June 23, 2025, this feature is enabled by default.

### What backup policy does a DaaS system have?

- **Daily backups:** DaaS performs daily backups. These are kept for 7 days.

- **Weekly backups:** DaaS performs additional weekly backups (taken on Monday). These are kept for 4 weeks.

- **Data restoration and support:** In the event a rollback is necessary, our support team will assist you. To submit a rollback request, please contact <daas@dataminer.services>.

> [!NOTE]
> For the STaaS database layer, see [Data resilience and backups](xref:STaaS_features#data-resilience-and-backups).

### Where are DaaS backups stored?

Backups are stored in zone-redundant storage (ZRS) managed by Azure backup, in the same region as the DaaS system.

### Is it possible to make a local backup of all data?

This is currently not possible. Skyline takes regular backups of all systems, which they can use to restore systems. If you want to get access to a backup of your system, please contact <daas@dataminer.services>.

### Is it possible to copy data from Azure and store it locally?

You can use the DataMiner API to copy data from Azure at no additional subscription cost. This requires a site-to-site VPN connection. To set up this connection, contact <daas@dataminer.services>.

### How can a DaaS system connect to on-premises and cloud resources?

For more information, see [Connecting to data sources using a DaaS system](xref:DaaS_connecting_to_data_sources)

### Can DaaS use custom DNS servers?

Yes. These can be set either for the whole DMS, or per node.

DaaS uses the [Azure-provided DNS](https://learn.microsoft.com/en-us/azure/virtual-network/virtual-networks-name-resolution-for-vms-and-role-instances?tabs=redhat#azure-provided-name-resolution) by default.

To request a change, contact <daas@dataminer.services>.

### Are additional costs due in order to connect to Azure?

All costs related to Azure VPN Gateway are included in your DaaS subscription. When other options are used, your providers may charge additional fees. In that case, note that Skyline will not act as a broker.

Additional query costs may be due when using e.g. Azure ExpressRoute or Amazon CloudWatch to retrieve data from other cloud providers. The costs for retrieving data from Amazon Web Services are usually negligible.

### How are user accounts managed? Where are the passwords stored?

User management on DaaS systems is similar to that on on-premises system. Although local accounts are available by default, user accounts are typically integrated by an identity provider.

See also: [User management](xref:User_management).

### Are there specific limitations that apply for DaaS?

As DaaS relies on DataMiner STaaS for data storage, the [limitations for STaaS](xref:STaaS_features#limitations) also apply for DaaS.

In addition, because of the additional security layer used in DaaS systems, at present, it is not possible to connect to a DaaS system using the [Web Services (v1)](xref:Using_the_Web_Services_v1).

### Where is my DaaS system hosted?

If you create a new DataMiner System via <https://dataminer.services>, it will by default be hosted in the West-Europe region.

However, you can request for it to be hosted in a different available region without incurring any additional costs. To do so, please contact <daas@dataminer.services>.

> [!NOTE]
> When choosing a region, make sure to opt for a region that supports availability zones. For an overview, refer to [Azure Regions List](https://learn.microsoft.com/en-us/azure/reliability/regions-list).

### Where is the data for my DaaS system hosted?

If you create a new DataMiner System via <https://dataminer.services>, the data for your system will by default be hosted in the West-Europe region.

However, you can request for it to be hosted in any of the available STaaS regions. To do so, please contact <daas@dataminer.services>. For detailed information, refer to [Data location and redundancy](xref:STaaS_features#data-location-and-redundancy).

> [!NOTE]
> It is perfectly possible to host your DaaS system in one region and your data in another region.

### Can I add additional DataMiner nodes to my DaaS system?

If you need additional nodes to be added to your DaaS system, please contact <daas@dataminer.services>.

### Can I add additional DataMiner nodes in a different region to my DaaS system?

Yes. Within a single DaaS system, it is possible to have different nodes running in different regions.

> [!NOTE]
> While you can have different nodes running in different regions, your data can only be in one region.

### How can I make changes to configuration files on the DataMiner server?

To make changes to configuration files on the DataMiner server, for example to [enable alarm blinking](xref:Making_alarms_without_owner_blink), contact <daas@dataminer.services>.
