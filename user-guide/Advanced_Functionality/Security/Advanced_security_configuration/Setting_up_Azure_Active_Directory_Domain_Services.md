---
uid: Setting_up_Azure_Active_Directory_Domain_Services
---

# Setting up Azure Active Directory Domain Services

The recommended way to connect your DataMiner System with Microsoft Entra ID (formerly known as Azure AD) is via SAML. See [Configuring SAML settings](xref:Configuring_external_authentication_via_an_identity_provider_using_SAML). However, if this is not possible, you also have the possibility to connect via LDAP. To do so, you will first need to deploy the Azure AD Domain Services and then configure the DNS servers.

### Deploying the Azure AD DS

1. Navigate to *portal.azure.com* and log in.

1. Create a virtual network:

   1. Click *Create a resource*.

   1. Enter "VNet" into the search bar, and select *Virtual Network* from the search suggestions.

   1. Click *Create* and complete the wizard.

1. Create Azure AD domain services:

   1. Click *Create a resource.*

   1. Enter "Azure AD DS" into the search bar and select *Azure AD Domain Services* from the search suggestions.

   1. Click *Create.*

   1. In the *Networking* step of wizard, add the virtual network you created earlier and create a subnet.

   1. Complete the wizard.

1. Wait until the status of the Azure AD domain services is "Running". This may take about an hour.

> [!NOTE]
> In a production environment, it is recommended to create the virtual network and the Azure AD domain services in different resource groups.

### Configuring the DNS servers

1. Navigate to portal.azure.com and do the following:

   1. Go to the Azure AD domain services.

   1. On the *Overview* page, click *Configure* in the configure/update DNS card to automatically configure the DNS server.

   1. Go to the virtual network.

   1. In the navigation pane on the left, under *Settings*, select *DNS servers*, and verify that the DNS servers point to the IP address of your Azure AD domain services.

1. Apply the following configuration on your Windows server:

   - If you are using an Azure VM:

     1. Navigate to *portal.azure.com.*

     1. Click *Create a Resource*, click *Compute*, and click *Create*.

     1. In the *Networking* step of the wizard, deploy the Windows Server virtual machine you are creating in your virtual network.

        > [!NOTE]
        > If you want to connect to this virtual machine via RDP, you need to create a rule that allows connecting to the port of the machine. To create such a rule, in the navigation pane, go to *Settings* > *Networking.*

     1. Complete the wizard to create a Windows Server virtual machine.

     1. Connect to the virtual machine with the Administrator account of the machine.

   - If you are not using an Azure machine: If you want to add a non-Azure VM or computer to the domain, you need to create a VPN gateway that the VM or computer can then use to connect to the virtual network. For more information, see [Connect an on-premises network to a Microsoft Azure virtual network](https://docs.microsoft.com/en-us/microsoft-365/enterprise/connect-an-on-premises-network-to-a-microsoft-azure-virtual-network?view=o365-worldwide) (external link).

1. Regardless of whether you use an Azure VM, make the server join the domain as follows:

   1. On the Windows server, open a command prompt, and enter *ipconfig /all* to check whether the IP addresses of the DNS servers are correct.

   1. In the server manager, go to *Local Server* and click *Workgroup* to add the Windows server to the domain.

   1. Click *Change*.

   1. Under *Member of*, select *Domain*, enter the domain name, and click OK.

   1. Log in with a user account that has permission to add Windows servers to the domain (Entra ID).

      > [!NOTE]
      > If the login fails, DO NOT try again. If you do, the server will be locked. Instead, on the Azure Portal, go to the user account in question, make sure the user has an email address under *Contact Info*, and reset the password of the user account. After resetting the password, go back to the Windows server and try to log in again.

   1. When the Windows server has been added to the domain, restart the server.

1. Install the Active Directory tools and features:

   1. In the Windows server, in the navigation bar, open the *Manage* menu, and click *Add Roles and Features*.

   1. Follow the wizard, and in the *Features* step, select all tools under *Remote Server Administration Tools* > *Role Administration Tools* > *AD DS and AD LDS Tools*, and click *Install*.

> [!NOTE]
>
> - To manage the domain users on the Windows server, make sure you are logged in with an administrator of the domain (Entra ID), click *Start* and open *Active Directory Users and Computers*.
> - In case logging in to the Windows server using RDP with the credentials of an Entra ID account fails, this can have the following reasons:
>
>   - The user does not have permission to access the server remotely. To fix this, in the control panel, go to Remote settings, click *Select Users*, and add the user to the list of users who are allowed to access the server remotely.
>   - The Entra ID user does not have an email address. To fix this, on the Azure portal, go to *Users*, and make sure all users have an email address under *Contact Info*. Users also need an email address to be able to log on to DataMiner.
>   - The user’s password has not been reset yet. On the Azure portal, go to the user account in question and reset its password.
