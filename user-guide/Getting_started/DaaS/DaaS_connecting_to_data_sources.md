---
uid: DaaS_connecting_to_data_sources
---

# Connecting to data sources using a DaaS system

To connect to data sources so that you can see their information in DataMiner, you need to [create DataMiner elements](xref:Adding_elements).

However, if you are using a DaaS system, by default you will only be able to access data sources that can be accessed from dataminer.services over the internet.

If this is not sufficient, contact <daas@dataminer.services> to set up a site-to-site VPN connection. Skyline will enable an [Azure VPN Gateway](https://learn.microsoft.com/en-us/azure/vpn-gateway/vpn-gateway-about-vpngateways) in the virtual network of your DaaS environment. This will establish a secured connection between your DaaS system and your self-hosted network (which can be on-premises or hosted by the cloud provider of your choice).

In order to create a connection, you will have to configure a [supported VPN device](https://learn.microsoft.com/en-us/azure/vpn-gateway/vpn-gateway-about-vpn-devices). On Azure, a [Generation 1 VpnGw1](https://learn.microsoft.com/en-us/azure/vpn-gateway/about-gateway-skus) gateway SKU will be used. By default, the IKEv2 protocol will be used.

These are the default encryption and authentication combinations:

- For Phase 1:

  - AES256 and SHA1
  - 3DES and SHA1
  - AES256 and SHA256

- For Phase 2:

  - AES256 and SHA1
  - 3DES and SHA1
  - AES256 and SHA256

If you would prefer a [custom policy](https://learn.microsoft.com/en-us/azure/vpn-gateway/vpn-gateway-about-compliance-crypto?WT.mc_id=Portal-Microsoft_Azure_HybridNetworking#ipsecike-policy-faq), contact <daas@dataminer.services>.
