---
uid: FAQ_Clustered_DMAs
---

# What are the benefits of using clustered DataMiner Agents as opposed to separate ones?

When you have a non-clustered system, that means you have one or more separate DataMiner Agents. If you instead cluster several DataMiner Agents together into one DataMiner System, this brings multiple benefits.

- Every piece of functionality can be visualized as one. One system can, for example, present you with a [dashboard](xref:newR_D) that combines data collected from multiple DataMiner Agents.

- Capacity can be combined and utilized efficiently across the entire cluster.

- Elements can be [swarmed from one DataMiner Agent to another](xref:Swarming), allowing easy load balancing and eliminating downtime from maintenance activities.

- The DataMiner connectors on the individual DataMiner Agents are combined and made available across all Agents in the cluster, allowing these connectors to be used more efficiently.

- An end-to-end view on all services will improve service monitoring.

- End-to-end [Correlation](xref:About_DMS_Correlation) and [Automation](xref:automation) functionality (i.e., cross-system Automation and Correlation).

- [Reports](xref:Generating_a_report_based_on_a_dashboard_Cube) containing data from multiple Agents.

- [Correlation rules](xref:About_DMS_Correlation) based on alarms from multiple Agents.

- One-time setup of all your [email notification filters](xref:Configuring_user_notifications).

- Administrative tasks only need to be performed once (e.g., setting up automated backups).

- Unified [alarm templates](xref:About_alarm_templates) and several admin level settings.

- Cross-system [advanced analytics](xref:Overview_Augmented_Operations) (e.g., cross-system behavioral analysis).

- Unified [Mobile Gateway](xref:MobileGateway) integration.

- Integration of ticketing platforms.

- Unified [user and group permissions](xref:User_rights).

- ...
