---
uid: mbgNMS_MeinbergOrDataMiner
---

# Meinberg NMS or DataMiner? How to migrate?

As the Meinberg NMS is based on a standard DataMiner platform, both Meinberg and Skyline customers can benefit from this. You can start off with a Meinberg NMS and add third-party products to it, or you can transition a Meinberg NMS into a full DataMiner System. Moreover, existing DataMiner customers can always expand their system and add the "Meinberg Element Manager" to get everything the Meinberg NMS offers.

The overview below illustrates four basic migration scenarios.

![Customer overview](~/develop/images/mbgNMS_MeinbergvDataMiner.png)

## Start with mbgNMS

- Out-of-the-box solution, based on DataMiner and sold by Meinberg

- Comes with fixed set of features and functionalities to manage, control, and monitor a Meinberg ecosystem (consolidated in the Meinberg Element Manager app).

- Allows expansion with third-party products, e.g., switches.

![Meinberg customer](~/develop/images/mbgNMS_MeinbergCustomer.png)

## Transition into full DataMiner System & Skyline customer

- True multivendor and fully customizable DataMiner System, sold by Skyline Communications

- Supports the Meinberg Element Manager app, Meinberg products, and any product from any vendor

![Skyline customer](~/develop/images/mbgNMS_SkylineCustomer.png)

<br>

> [!NOTE]
>
> - *1 Requires one license per non-modular Meinberg product, one license per modular Meinberg chassis, and one license per Meinberg modular card (IMS series).
>
>   - HPS card: by default one DataMiner element is created per PTP instance, i.e., more than one license is required per card. This behavior can be turned off.  
>   - SyncMon card: SyncMon cards can optionally create a separate DataMiner element. If this feature is activated, each SycnMon card needs an element license.  
>   - Meinberg Element Manager, IDP elements: no element license required.  
>
> - *2 Mandatory.  
> - *3 Requires one license per third-party product instance.  
> - *4 Engineering services on top of mbgNMS, e.g., add visual or create an automation script. The Meinberg Element Manager app itself cannot be changed.  
> - *5 No need to order Meinberg connectors or Meinberg Element Manager; those will be transitioned to the DataMiner platform.  
> - *6 DataMiner IDP app needs to be purchased separately. Please reach out to your Skyline sales representative in case you already have IDP running on your system. Checks will be required to make sure the existing system will be compatible.  
> - *7 LANTIME connectors:
>
>   - LANTIME Modular series requires SYSII-connector (includes all connectors to manage all supported LANTIME cards).
>   - LANTIME Non-Modular requires DEVII-connector per Meinberg series (e.g., two connectors required to support M100 and M300, one connector required for M300 and M320)
>   - Sync-Mon Node connector is included with the purchase of any LANTIME modular or non-modular connector
>   - Connectors can be updated free of charge from LANTIME V8 to V10 API connector versions (requires active M&S agreement)
