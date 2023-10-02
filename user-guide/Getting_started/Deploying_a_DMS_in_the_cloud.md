---
uid: Deploying_a_DMS_in_the_cloud
---

# Deploying a DataMiner System in the cloud (DaaS)

> [!IMPORTANT]
> At present, this feature is only available in preview for the "Empower" organization.

> [!TIP]
> If you have any questions or need support with the DaaS feature, contact <daas@dataminer.services>.

With **DataMiner as a Service (DaaS)**, you can deploy a complete DataMiner System (DMS) in mere minutes. The DataMiner System is fully hosted in the cloud, so that you can immediately enjoy all the benefits of being connected to the [dataminer.services platform](xref:AboutCloudPlatform). As DaaS uses our [Storage as a Service (STaaS) solution](xref:STaaS), you will be able to make use of a scalable and user-friendly cloud-native storage platform. Scaling will be easy, both vertically (adding or removing resource), and horizontally (adding or removing nodes), whenever you need.

## Deploying a new DMS on dataminer.services

1. Log on to [dataminer.services](https://dataminer.services).

   > [!TIP]
   > For more detailed information, see [Logging on to dataminer.services](xref:Logging_on_to_the_DataMiner_Cloud_Platform).

1. Under *DataMiner Systems*, click *Deploy a new DataMiner System*.

   ![Deploy a new DataMiner System button](~/user-guide/images/deploy_001.png)

1. Click *Deploy a DataMiner System*.

   ![Deploy a DataMiner System button](~/user-guide/images/deploy_002.png)

1. Select the *Organization* under which you want to register the DataMiner System.

1. Enter a *DataMiner System Name*.

1. Enter a custom *DataMiner System URL* if you do not want the URL to be the same as the *DataMiner System Name*.

1. Select the box next to *I agree to the terms of service*.

1. Click *Deploy*.

   ![DataMiner System deployment configuration](~/user-guide/images/deploy_003.png)

1. Wait until your DataMiner System has been deployed.

   The following message will be displayed:

   ![DataMiner System deployment confirmation](~/user-guide/images/deploy_005.png)

## Accessing a newly deployed DMS for the first time

1. Log on to [dataminer.services](https://dataminer.services).

   > [!TIP]
   > For more detailed information, see [Logging on to dataminer.services](xref:Logging_on_to_the_DataMiner_Cloud_Platform).

1. Under *DataMiner Systems*, click *Cube*.

   ![Cube icon on dataminer.services](~/user-guide/images/deploy_006.png "Access Cube")

1. If required, confirm by clicking *Open DataMiner Cube*.

   ![Open DataMiner Cube](~/user-guide/images/deploy_007.png)

1. Click *Connect*

   ![Connecting to Cube](~/user-guide/images/deploy_008.png)

1. Log in with the following credentials:

   - Username: *DataMinerAdmin*

   - Password: *DataMiner123!*

   ![Logging into Cube](~/user-guide/images/deploy_009.png)

Now that you are logged in, you can configure your DataMiner System to your specific preferences.

> [!IMPORTANT]
> We strongly recommend that you **start by configuring security**. You should in the very least change the password for the *DataMinerAdmin* account, but it would be even better to configure your own admin account and then remove the *DataMinerAdmin* account. Next, configure the necessary rights and privileges for the other users of your DataMiner System. See [User management](xref:User_management).
