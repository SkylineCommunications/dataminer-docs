---
uid: Connecting_to_private_data_sources
---

# Connecting to private data sources with DaaS

If you are using a DaaS system, by default you will only be able to connect to data sources that can be accessed from dataminer.services over the internet. To make sure DaaS can also access private data sources, a site-to-site VPN connection will need to be set up. This will establish a secured connection between your DaaS system and your self-hosted network (which can be on-premises or hosted by the cloud provider of your choice).

To establish this connection:

1. Make sure the following prerequisites are met:

   - You have configured a [supported VPN device](https://learn.microsoft.com/en-us/azure/vpn-gateway/vpn-gateway-about-vpn-devices) for Skyline to connect to.

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

   Provide the following information in your email:

   - The public IP of your VPN device.

   - A pre-shared key to use for the VPN connection.

   - The address space of the network(s) that should be reachable by your DaaS system.
  
   - If BGP should be enabled, the ASN and BGP peer IP address.
  
   - Any other information that might be relevant for your specific setup.

   Skyline will enable an [Azure VPN Gateway](https://learn.microsoft.com/en-us/azure/vpn-gateway/vpn-gateway-about-vpngateways) in the virtual network of your DaaS environment. By default the [Generation 1 VPN Gateway SKU *VpnGw1AZ*](https://learn.microsoft.com/en-us/azure/vpn-gateway/about-gateway-skus) will be used. If you require another SKU, let us know. 

   By default, the IKEv2 protocol will be used. If you would prefer a [custom policy](https://learn.microsoft.com/en-us/azure/vpn-gateway/vpn-gateway-about-compliance-crypto?WT.mc_id=Portal-Microsoft_Azure_HybridNetworking#ipsecike-policy-faq), let us know.

1. Once the VPN Gateway has been enabled, Skyline will provide you with the following information:

   - The public IP of the Azure VPN Gateway.

   - The DaaS address space (by default 172.23.12.0/22, but this can be different to prevent an overlap with your address space).

   - The BGP ASN.
