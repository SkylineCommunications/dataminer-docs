---
uid: Provisioning
---

# Provisioning

On the *Provisioning* subtab of the *Admin* tab, you can verify and configure which DMAs can host devices in particular IP ranges. The provisioning API can then create new devices on specific DMAs based on their IP.

The IP ranges are displayed in the table *Configured IP Ranges*. This table displays the start IP, the end IP and the DMA name for each configured IP range. If one of the IP ranges is selected in the table, more detailed information is displayed above the table, including the DMA ID for the IP range.

The following actions are available on this page:

- To enable or disable automatic provisioning, use the toggle button next to *Automatically Create Elements After Discovery*. However, note that automatic provisioning will only be possible if both this option and the *Provisioning* option on the *Admin* > *Activities* page (or the *Processes* > *Automation* page in older IDP versions) are enabled.

- To add an IP range, click the *Create* button above the *Configured IP Ranges* table. To the right above the table, you will then need to specify the start IP address, end IP address, and DataMiner Agent for the IP range. When you have done so, click the *Add* button to create the IP range.

- To remove an IP range, select an IP range in the *Configured IP Ranges* table and click the *Delete* button above the table.

- To configure the default hosting Agent, next to *Fallback Agent* click the *Set* button and specify the Agent.

- To refresh the list of DMAs for which you can configure IP ranges and from which you can select a DMA to be the Fallback Agent, click *Refresh Agents*.

> [!NOTE]
> Both IPv4 and IPv6 ranges are supported. Both types of ranges can be combined in the same request.
>
