---
uid: Connecting_to_private_data_sources
---

# Connecting to private data sources with DaaS

If you are using a DaaS system, by default you will only be able to connect to data sources that can be accessed from dataminer.services over the internet. To make sure DaaS can also access private data sources, a site-to-site VPN connection will need to be set up. This will establish a secured connection between your DaaS system and your self-hosted network (which can be on-premises or hosted by the cloud provider of your choice).

<!-- todo: image -->

To establish this connection:

1. Make sure the following prerequisites are met:

   - You have configured [supported VPN device](https://learn.microsoft.com/en-us/azure/vpn-gateway/vpn-gateway-about-vpn-devices) for Skyline to connect to.

   - One of the following supported encryption and authentication combinations is used:

     - For Phase 1:

       - AES256 and SHA1
       - 3DES and SHA1
       - AES256 and SHA256

     - For Phase 2:

       - AES256 and SHA1
       - 3DES and SHA1
       - AES256 and SHA256

1. Contact <daas@dataminer.services> to set up a site-to-site VPN connection.

   Skyline will enable an [Azure VPN Gateway](https://learn.microsoft.com/en-us/azure/vpn-gateway/vpn-gateway-about-vpngateways) in the virtual network of your DaaS environment. Skyline will use a [Generation 1 VpnGw1](https://learn.microsoft.com/en-us/azure/vpn-gateway/about-gateway-skus) gateway SKU. By default, the IKEv2 protocol will be used.

> [!NOTE]
> If you would prefer a [custom policy](https://learn.microsoft.com/en-us/azure/vpn-gateway/vpn-gateway-about-compliance-crypto?WT.mc_id=Portal-Microsoft_Azure_HybridNetworking#ipsecike-policy-faq), contact <daas@dataminer.services>.
