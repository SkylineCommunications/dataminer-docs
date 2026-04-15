---
uid: Using_aws_ami
description: Launch a pre-configured DataMiner Agent on AWS from the AWS Marketplace using the DataMiner SelfHosted AWS Edition AMI.
---

# Deploying a DataMiner Agent using the AWS AMI

The [DataMiner SelfHosted AWS Edition](https://aws.amazon.com/marketplace/pp/prodview-xiamo4fgjihji) is available on the AWS Marketplace as an Amazon Machine Image (AMI). It allows you to rapidly launch a production-ready DataMiner environment on Amazon EC2 without complex installation or setup.

To deploy DataMiner using the AWS AMI, you will need to follow the steps below:

1. [Launch the EC2 instance from the AWS Marketplace](#launching-the-ec2-instance).
1. [Connect to the instance](#connecting-to-the-instance).
1. [Configure DataMiner](#configuring-dataminer).

> [!NOTE]
>
> - We assume you have a valid AWS account and know how to use the AWS management console. You can always look into the [official docs](https://docs.aws.amazon.com/awsconsolehelpdocs/).
> - The DataMiner license is separate from AWS infrastructure costs. You will be charged by AWS for the EC2 instance and any other AWS resources you use.
> - After launching the AWS VM, you will be able to choose if you want to continue with the default **Community Edition license** or use your perpetual license.
> - For information on pricing and limitations for this license, see [DataMiner Community Edition](xref:Pricing_Commercial_Models#dataminer-community-edition).

## Launching the EC2 instance

1. Go to the [DataMiner SelfHosted AWS Edition](https://aws.amazon.com/marketplace/pp/prodview-xiamo4fgjihji) listing on the AWS Marketplace and click *View purchase options*.

1. Subscribe to the product. By default, DataMiner will be deployed with a free [Community Edition](xref:Pricing_Commercial_Models#dataminer-community-edition) license. If you need a paid license, you will need to purchase it outside of AWS Marketplace.

   > [!NOTE]
   > For more information about available licensing options, see [Pricing](xref:Pricing).

1. After subscribing, click *Launch your software*.

   This opens the *Launch DataMiner SelfHosted AWS Edition* page.

1. Select **Launch from EC2 Console** as the launch method, select a region and click *Launch from EC2*.

   > [!NOTE]
   > The *One-click launch from AWS Marketplace* option is not recommended, as it uses AWS default settings that may not be suitable for a DataMiner deployment (e.g. instance type, network, and security group settings).

   This opens the EC2 *Launch an instance* page.

1. In the *Name and tags* section, enter a name for your instance and optionally add tags.

1. The AMI is pre-selected based on your subscription. You do not need to change this.

1. In the *Instance type* section, select the instance type. A **t2.xlarge** (4 vCPU, 16 GiB memory) or larger is recommended.

1. In the *Key pair (login)* section, select an existing key pair or create a new one.

   > [!IMPORTANT]
   > A key pair is required to retrieve the Windows Administrator password after launch. Do not proceed without a key pair, as you will not be able to connect to your instance.

1. In the *Network settings* section, configure the network, ensuring the instance has internet access for [dataminer.services](xref:Cloud_connectivity_and_security#connecting-to-dataminerservices) connectivity, and configure a security group that allows at least inbound RDP access (TCP port 3389) from your IP address. Let it assign a public IP so you can RDP after the instance is launched.

   > [!NOTE]
   > By default, the instance is launched in the default VPC. If you want to use a custom IP address space, you will need to create a new VPC first and select it here. For more information, see [Create a VPC](https://docs.aws.amazon.com/vpc/latest/userguide/create-vpc.html) in the AWS documentation.

1. In the *Configure storage* section, configure the storage. The default root volume size is 54 GiB, but you can increase this before launching. You can also increase the volume size at any time after the instance has been launched.

1. Optionally you can further configure advanced details.

1. Launch the instance.

## Connecting to the instance

1. Once the EC2 instance is in the *running* state, retrieve the Windows Administrator password using your key pair via the AWS Management Console (*Actions > Security > Get Windows password*).

1. Connect to the instance using Remote Desktop Protocol (RDP) with the retrieved Administrator password. The default username is **Administrator**.

## Configuring DataMiner

As soon as you log in to the instance, the DataMiner Configurator window will be shown where you can configure your DataMiner System.

> [!IMPORTANT]
> At this point, the DataMiner core software is fully installed. If you continue with the steps below, the wizard will also automatically take care of the license and data storage configuration. However, if you **do not want a default installation**, you may not want to use this automatic configuration:
>
> - If you intend to **restore a backup** coming from another machine because of e.g. a hardware migration or during disaster recovery, skip the configuration below and follow the steps under [Restoring a backup onto a newly installed DataMiner Agent](xref:Restoring_backup_on_newly_installed_DMA).
> - If you are installing a **Failover** Agent, skip the configuration below, and follow the steps under [Configuring the new DataMiner Agent as a new Agent in a Failover pair](xref:Configuring_a_new_DMA_in_Failover_pair).

> [!NOTE]
> If you accidentally close the configuration window, you can run it manually from `C:\Skyline DataMiner\Tools\FirstStartupChoice\FirstStartupChoice.exe`. Make sure to run it with administrator privileges.
> Normally a shortcut is created on the desktop the first time you close it. You can delete this shortcut if you've succesfully started DataMiner.

Follow the steps below to configure your DataMiner Agent:

1. Click *Next* to get started.

1. Select the desired database type:

   - [Storage as a Service (STaaS)](xref:STaaS) (recommended).

   - *Self-hosted - External Storage*: A regular [dedicated clustered storage setup](xref:Configuring_dedicated_clustered_storage). If you select this option, you will also need to fill in the connection details for both Cassandra and OpenSearch.

     > [!NOTE]
     > Make sure these clusters are active and reachable from the instance you are setting up. You are responsible for the management of these external database clusters.

1. Click *Next*, and fill in the required details to connect your DataMiner Agent to dataminer.services:

   - *Organization API Key*: Provide an organization key that has the necessary permissions to add DataMiner Systems in your organization. For more information on how to add a new organization key to your organization on dataminer.services, see [Managing dataminer.services keys](xref:Managing_dataminer_services_keys).
   - *System Name*: This name will be used to identify the DataMiner System in various dataminer.services applications.
   - *System URL*: This URL will grant you remote access to your DataMiner System web applications. You can choose to either [disable or enable this remote access feature](xref:Controlling_remote_access) at any time.
   - *Admin Email*: This email address must be associated with a dataminer.services account that is a member of your organization. It will become the owner of the DMS on dataminer.services.
   - *STaaS Region*: If you have selected to use [STaaS](xref:STaaS) for data storage, select the region where your data should be hosted.

   > [!NOTE]
   > By default, the configurator will guide you in subscription mode with a [Community Edition](xref:Pricing_Commercial_Models#dataminer-community-edition) license. If you want to install DataMiner with a [perpetual license](xref:Permanent_license), click the link below the registration fields and enter the DataMiner ID provided by Skyline. If you do not have a DataMiner ID yet, contact [dataminer.licensing@skyline.be](mailto:dataminer.licensing@skyline.be).
   >
   > You can also deploy DataMiner in subscription mode first and [switch to a perpetual license](xref:Switching_from_subscription_mode_to_perpetual_license) or [switch to an offline demo license](xref:Switching_from_subscription_mode_to_offline_demo) later.

1. Click *Next*, and verify the selected configuration.

1. To start the configuration, click *Next*.

   The configuration progress will now be displayed. When the configuration is complete, you can close the window.

   DataMiner will automatically start up and connect to dataminer.services. DataMiner Cube will also be installed, so you can connect to DataMiner locally.

1. [Log in to DataMiner Cube](xref:Logging_on_to_DataMiner_Cube) using the previously configured Administrator account.

   Logging in automatically with the built-in Administrator account is not possible, so you will need to fill in the username and password.

> [!IMPORTANT]
> For security reasons, we strongly recommend creating a second user and disabling the built-in administrator account once the setup is complete. See [Managing users](xref:Managing_users).
