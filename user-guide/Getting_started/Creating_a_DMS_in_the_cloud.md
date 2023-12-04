---
uid: Creating_a_DMS_in_the_cloud
---

# Creating a DataMiner System in the cloud (DaaS)

> [!TIP]
> If you have any questions or need support with the DaaS feature, contact <daas@dataminer.services>.

With **DataMiner as a Service (DaaS)**, you can create a complete DataMiner System (DMS) in mere minutes. The DataMiner System is fully hosted in the cloud, so that you can immediately enjoy all the benefits of being connected to the [dataminer.services platform](xref:AboutCloudPlatform). As DaaS uses our [Storage as a Service (STaaS) solution](xref:STaaS), you will be able to make use of a scalable and user-friendly cloud-native storage platform. Scaling will be easy, both vertically (adding or removing resource), and horizontally (adding or removing nodes), whenever you need.

## Creating a new DMS on dataminer.services

> [!IMPORTANT]
> You must be a member of an [organization](xref:Pricing_Usage_based_service#organization) to create a new DaaS instance and have sufficient DataMiner Credits.

1. Log on to [dataminer.services](https://dataminer.services).

   > [!TIP]
   > For more detailed information, see [Logging on to dataminer.services](xref:Logging_on_to_the_DataMiner_Cloud_Platform).

1. Under *DataMiner Systems*, click *Add a new DataMiner System*.

   ![Add a new DataMiner System button](~/user-guide/images/daas_create_001.png)

1. Click *DataMiner as a Service*.

1. Select the *Organization* under which you want to register the DataMiner System.

1. Enter a *DataMiner System Name*.

1. Enter a custom *DataMiner System URL* if you want the URL to be different from the *DataMiner System Name*.

1. Enter a username and password for your DataMiner account.

   > [!IMPORTANT]
   > Do not use an ampersand ("&") in your password. This is currently not supported.

1. Select the box next to *I agree to the terms of service*.

1. Click *Deploy*.

> [!NOTE]
>
> - It is possible to create a DaaS system as a staging system. Our Pay-per-Use model is used for this. For detailed information, see [DataMiner Express](xref:Pricing_Commercial_Models#dataminer-express).
> - When you create a DaaS system, your dataminer.services account will automatically be linked to your DataMiner account, so you can easily access DataMiner web apps such as the Monitoring app via remote access.

## Accessing a newly created DMS for the first time

1. Log on to [dataminer.services](https://dataminer.services).

   > [!TIP]
   > For more detailed information, see [Logging on to dataminer.services](xref:Logging_on_to_the_DataMiner_Cloud_Platform).

1. Under *DataMiner Systems*, click *Open in desktop app*.

   ![Open in desktop app on dataminer.services](~/user-guide/images/daas_access_001.png "Open dekstop app")

1. If required, confirm by clicking *Open DataMiner Cube*.

   ![Open DataMiner Cube](~/user-guide/images/daas_access_002.png)

1. Click *Connect*

   ![Connecting to Cube](~/user-guide/images/daas_access_003.png)

1. Log in with your credentials from the creation process.

   ![Logging into Cube](~/user-guide/images/daas_access_004.png)

Now that you are logged in, you can configure your DataMiner System to your specific preferences.
