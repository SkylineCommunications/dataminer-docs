---
uid: Failover_AWS
---

# DataMiner Failover on Amazon Web Services

When you set up a [DataMiner Failover](xref:failover) configuration, you need to assign virtual IP addresses to the corporate and acquisition networks of the active DMA. Switching from the active to the passive DMA requires that those virtual IP addresses are reassigned. This is done seamlessly by DataMiner.

If you use Amazon Web Services (AWS) for your system database, you need to assign secondary private IPv4 addresses to the network interfaces of your EC2 instances. You also need to transfer those addresses between your instances whenever a switch in DataMiner occurs.

> [!NOTE]
> For more information on this data storage architecture, see [Supported system data storage architectures](xref:Supported_system_data_storage_architectures). However, note that we recommend using [DataMiner STaaS](xref:STaaS) instead.

> [!IMPORTANT]
> This method assumes that the EC2 instances are in the same availability zone. If your instances are in different zones, you should use Failover with DNS instead.

## Setting up Failover

1. [Set up DataMiner Failover](xref:Configuring_Failover).

   When you configure Failover, by default the IP addresses from the DMA on which you are configuring Failover are selected as the virtual IPs. Since these addresses are already assigned as primary addresses in AWS, you need to assign these back to the DMA and modify the virtual IPs according to your addressing scheme.

   *Open this image in a new tab to view the full resolution.*
   ![Virtual IPs](~/user-guide/images/DataMiner_Failover.png)

1. In the AWS Management Console, go to the EC2 section and, under *Network & Security*, select *Network Interfaces*. Locate the network interfaces of your active DMA and add the virtual IPs.

   ![Manage IP Addresses](~/user-guide/images/Manage_IP_Addresses.png)

## Installing the AWS Tools

Install the AWS Tools for Windows PowerShell on both Failover DMAs.

1. Open PowerShell in an administrative window.

1. Execute the following command: `Install-Module -Name AWSPowerShell`

> [!TIP]
> For more information, see [AWSPowerShell 4.1.7.0](https://www.powershellgallery.com/packages/AWSPowerShell/4.1.7.0).

## Creating an access key

In order to programmatically make changes in AWS, you need an API access key. To create one, taking into account the principle of least privilege, follow the procedure below.

> [!NOTE]
> You will need this information later when configuring DataMiner.

1. Create a policy:

   1. In the AWS Management Console, go to the Identity and Access Management (IAM) section.

   1. Under *Access management*, select *Policies*.

   1. Click *Create policy*.

   1. Define a new policy that contains the **EC2 service**, allows the **action AssignPrivateIpAddresses** and is limited to the **network interface resources** from your EC2 instances.

   1. To find the network interface IDs, in the AWS Management Console, go to the EC2 section and, under *Network & Security*, select *Network Interfaces*. Locate the network interfaces of your DMAs and write down the network interface IDs.

      ![Create policy](~/user-guide/images/Create_Policy.png)

1. Create a group:

   1. In the AWS Management Console, go to the Identity and Access Management (IAM) section.

   1. Under *Access management*, select *Groups*.

   1. Click *Create New Group*.

   1. Specify a name for the group and assign the policy created in the previous step.

      ![Create group](~/user-guide/images/Create_Group.png)

1. Create a user:

   1. In the AWS Management Console, go to the Identity and Access Management (IAM) section.

   1. Under *Access management*, select *Users*.

   1. Click *Add user*.

   1. Specify a user name and select the access type *Programmatic access*.

   1. Add the user to the group created in the previous step.

      ![Create user](~/user-guide/images/Create_User.png)

   1. Click *Create user*. You will now be able to copy the access key ID and secret access key needed to perform API calls to AWS.

      ![Copy Access Key ID](~/user-guide/images/Success_User.png)

      > [!NOTE]
      > You will not be able to copy the secret access key once you have closed this screen. If you lose the key, you will have to create a new one.

## Configuring DataMiner

In order for DataMiner to be able to acquire the virtual IP addresses, these addresses need to be re-assigned in AWS first. To accomplish this, DataMiner can execute a script before it acquires the virtual IP.

1. Using the template below, create 2 scripts, one for the active DMA and one for the passive DMA, and fill in the variables.

1. If you do not have an acquisition network, you can remove the acquisition section.

1. Save the script under the name *VIPAcquired.ps1* in the *C:\Skyline DataMiner\Tools* folder on the correct DMA.

```txt
#----------------------------------AWS-----------------------------------#
$AWS_ACCESS_KEY_ID = "";
$AWS_SECRET_ACCESS_KEY = "";
$AWS_REGION = "";

#-----------------------------CORPORATE----------------------------------#
$VIP_CORPORATE = "";
$NETWORK_INTERFACE_ID_CORPORATE = "";

Register-EC2PrivateIpAddress -NetworkInterfaceId
$NETWORK_INTERFACE_ID_CORPORATE -PrivateIpAddress $VIP_CORPORATE -
AllowReassignment 1 -Region $AWS_REGION -AccessKey $AWS_ACCESS_KEY_ID -
SecretKey $AWS_SECRET_ACCESS_KEY

#----------------------------ACQUISITION---------------------------------#
$VIP_ACQUISITION = "";
$NETWORK_INTERFACE_ID_ACQUISITION = "";

Register-EC2PrivateIpAddress -NetworkInterfaceId
$NETWORK_INTERFACE_ID_ACQUISITION -PrivateIpAddress $VIP_ACQUISITION -
AllowReassignment 1 -Region $AWS_REGION -AccessKey $AWS_ACCESS_KEY_ID -
SecretKey $AWS_SECRET_ACCESS_KEY
```
