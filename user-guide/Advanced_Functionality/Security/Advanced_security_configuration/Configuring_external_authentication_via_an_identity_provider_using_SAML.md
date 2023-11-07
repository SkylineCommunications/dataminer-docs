---
uid: Configuring_external_authentication_via_an_identity_provider_using_SAML
keywords: Azure AD, AzureAD, Microsoft Entra ID, SAML, Okta, Azure B2C
---

# Configuring external authentication via an identity provider using SAML

From DataMiner 9.6.11 onwards, it is possible to configure external authentication via an identity provider service using SAML (Security Assertion Markup Language).

## Requirements

- DataMiner integrates with **identity providers using version 2.0 of the SAML protocol**. Compatibility with older SAML versions is not supported.

- The identity provider must support **Redirect binding** for communication between the service provider and the identity provider. Most SAML identity providers support Redirect binding by default.

- DataMiner uses service provider-initiated **Single Sign-On (SSO)** through Redirect binding. It does not support the use of POST or SOAP binding for requests. However, standard POST binding is used for responses.

  > [!TIP]
  > For a comprehensive understanding of the SAML process, including the encoding and encryption guidelines that DataMiner follows, refer to the official SAML Documentation: [SAML Technical Overview](http://docs.oasis-open.org/security/saml/Post2.0/sstc-saml-tech-overview-2.0-cd-02.html#5.1.2.SP-Initiated%20SSO:%20%20Redirect/POST%20Bindings|outline).

## Establishing a trust relationship between the service provider and identity provider

To configure external authentication via an identity provider service using SAML, a trust relationship must be established between the service provider (i.e. DataMiner) and the identity provider. This is done by exchanging SAML metadata files.

The following metadata must be shared between the service provider (i.e. DataMiner) and the Identity Provider service: Entity ID, Cryptographic Keys, Protocol Endpoints (bindings, locations).

> [!TIP]
> See also: [Troubleshooting SAML issues](xref:Troubleshooting_SAML_Issues)

To configure this, follow the steps below:

1. Go to the *C:\\Skyline DataMiner* folder and open the *DataMiner.xml* file.

1. In *DataMiner.xml*, configure the *\<ExternalAuthentication>* tag as illustrated in the example below:

   ```xml
   <DataMiner ...>
     ...
     <ExternalAuthentication
       type="SAML"
       ipMetadata="[Path/URL of the identity provider’s metadata file]"
       spMetadata="[Path/URL of the service provider’s metadata file]"
       timeout="300" />
     ...
   </DataMiner>
   ```

   | Attribute | Description |
   | --------- | ----------- |
   | type | SAML (Identity federation using SAML assertions) |
   | ipMetadata | The path to or the URL of the identity provider's metadata file. The way in which to retrieve this metadata file will depend on the identity provider you are using. See [Identity providers](#identity-providers) |
   | spMetadata | The path to or the URL of the service provider's metadata file. See [Creating a DataMiner metadata file](#creating-a-dataminer-metadata-file) |
   | timeout | Optional attribute. The amount of time DataMiner should wait for the user to be authenticated by the identity provider. If this attribute is not specified, DataMiner will wait 300 seconds (5 minutes). |

1. Save and close the file, and restart the DMA.

Once this has been configured, if users try to log in to the DMA using external authentication via SAML, they will be redirected to a login page of the identity provider. That page will authenticate them and return a SAML response, which DataMiner can use to either grant or deny access.

> [!NOTE]
>
> - From DataMiner 10.2.0/10.1.4 onwards, Cube uses the **Chromium** web browser engine to handle SAML external authentication. That engine supports a wider range of identity providers than the Internet Explorer engine that was used previously.
> - DataMiner **10.3.5** or higher is required to use external authentication for DataMiner **Low-Code Apps**.
> - DataMiner will expect one of the claims provided by the identity provider to be the **"name" claim**: ``http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name``. This field must contain either the username or the email address.
> - Any DataMiner Agent configured for SAML external authentication should be accessible via [**HTTPS**](xref:Setting_up_HTTPS_on_a_DMA).
> - For **DataMiner Cube**, prior to DataMiner 10.1.11/10.2.0, only the Administrator user can bypass the external authentication provider by entering an explicit username/password combination. In later DataMiner versions, this is also allowed for any local DataMiner user account.
> - For the **Web apps**, when external authentication is enabled, it is no longer possible to log in with local accounts. As a workaround, since you do not need to configure external authentication on every DMA of the cluster, you can log in to the web apps using external authentication on one DMA and log in using a local account on another DMA.

> [!CAUTION]
> If there are two DataMiner users who share the same email address, both users will not be able to log in. To prevent this from happening, we recommended not using more than one method to add users. For example, do not add Windows domain users if the Entra ID users use the same email address.

> [!TIP]
> See also: [Authenticating Azure AD (i.e. Entra ID) users on DataMiner with SAML](https://community.dataminer.services/video/authenticating-azure-ad-users-on-dataminer-with-saml/) in the Dojo video library ![Video](~/user-guide/images/video_Duo.png)

### Creating a DataMiner metadata file

To create a DataMiner metadata file (also referred to as *Service Provider Metadata*), proceed as follows:

1. Copy the following template into a new XML file named e.g. *spMetadata.xml*:

   From DataMiner 10.3.5 onwards:

   ```xml
   <?xml version="1.0" encoding="UTF-8"?>
   <md:EntityDescriptor xmlns:md="urn:oasis:names:tc:SAML:2.0:metadata" xmlns:ds="http://www.w3.org/2000/09/xmldsig#" entityID="[ENTITYID]" validUntil="2050-01-04T10:00:00.000Z">
     <md:SPSSODescriptor AuthnRequestsSigned="false" WantAssertionsSigned="true" protocolSupportEnumeration="urn:oasis:names:tc:SAML:2.0:protocol">
       <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/API/" index="0" isDefault="true"/>
     </md:SPSSODescriptor>
   </md:EntityDescriptor>
   ```

   Older DataMiner versions:

   ```xml
   <?xml version="1.0" encoding="UTF-8"?>
   <md:EntityDescriptor xmlns:md="urn:oasis:names:tc:SAML:2.0:metadata" xmlns:ds="http://www.w3.org/2000/09/xmldsig#" entityID="[ENTITYID]" validUntil="2050-01-04T10:00:00.000Z">
     <md:SPSSODescriptor AuthnRequestsSigned="false" WantAssertionsSigned="true" protocolSupportEnumeration="urn:oasis:names:tc:SAML:2.0:protocol">
       <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/" index="0" isDefault="true"/>
       <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/API/" index="1" isDefault="false"/>
       <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/root/" index="2" isDefault="false"/>
       <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/dashboard/" index="3" isDefault="false"/>
       <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/monitoring/" index="4" isDefault="false"/>
       <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/jobs/" index="5" isDefault="false"/>
       <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/ticketing/" index="6" isDefault="false"/>
     </md:SPSSODescriptor>
   </md:EntityDescriptor>
   ```

   > [!NOTE]
   > You can place the *spMetadata.xml* anywhere, as long as the *spMetadata* attribute for the *ExternalAuthentication* tag in *DataMiner.xml* points to the correct file. However, we recommend placing it in the `C:\Skyline DataMiner` folder.

1. Replace \[ENTITYID\] with the unique service provider ID that is assigned to DataMiner when you register it with the identity provider.

   The way you can find this ID will depend on the identity provider you are using. See [Identity providers](#identity-providers).

1. Replace ``https://dataminer.example.com`` with the IP address or the DNS name of your DataMiner System. Make sure the endpoint addresses in the location attributes match the DataMiner application endpoints you specified when you registered DataMiner with the identity provider.

   The way you configure this will depend on the identity provider you are using. See [Identity providers](#identity-providers).

> [!NOTE]
> The ``WantAssertionsSigned`` flag is supported as from DataMiner version 10.2.1/10.2.0. If you are using an older version, then set this to false. SAML responses without signatures can be freely edited to tamper with permissions on the application, leading to severe vulnerabilities. We **highly recommend** setting ``WantAssertionsSigned`` to *true* to mitigate this.

> [!IMPORTANT]
> From DataMiner 10.3.4/10.4.0 onwards, ``WantAssertionsSigned`` **must** be set to *true*.

### Additional configuration for systems connected to dataminer.services

When your DataMiner System is connected to dataminer.services, the following additional configuration is required for both the *spMetadata.xml* file and the identity provider:

1. Specify the following URLs, replacing `<dms-dns-name>` with the DNS name in the *spMetadata.xml* file and `<organization-name>` with the name of the organization:

   - `https://<dms-dns-name>-<organization-name>.on.dataminer.services/API/`
   - `https://<dms-dns-name>-<organization-name>.on.dataminer.services/account-linking`
   - `https://<dms-dns-name>-<organization-name>.on.dataminer.services/account-linking/`

   > [!NOTE]
   > Note the trailing "/".

   Example of remote access URL: <https://dataminer-skyline.on.dataminer.services>

   In this example, the DMS DNS name is "dataminer" and the organization name is "skyline".

1. Extend the *spMetadata.xml* file with the following code:

   ```xml
   <?xml version="1.0" encoding="UTF-8"?>
   <md:EntityDescriptor xmlns:md="urn:oasis:names:tc:SAML:2.0:metadata" xmlns:ds="http://www.w3.org/2000/09/xmldsig#" entityID="[ENTITYID]" validUntil="2050-01-04T10:00:00.000Z">
    <md:SPSSODescriptor AuthnRequestsSigned="false" WantAssertionsSigned="true" protocolSupportEnumeration="urn:oasis:names:tc:SAML:2.0:protocol">
      ...
      <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer-skyline.on.dataminer.services/API/" index="1" isDefault="true"/>
      <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer-skyline.on.dataminer.services/account-linking" index="2" isDefault="false"/>
      <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer-skyline.on.dataminer.services/account-linking/" index="3" isDefault="false"/>
    </md:SPSSODescriptor>
   </md:EntityDescriptor>
    ```

1. Update your provider settings. See [Identity providers](#identity-providers).

## Identity providers

DataMiner currently supports the following identity providers:

- [Microsoft Entra ID](#microsoft-entra-id-formerly-azure-ad)
- [Azure B2C](#azure-b2c)
- [Okta](#okta)

### Microsoft Entra ID (formerly Azure AD)

DataMiner supports Entra ID (previously known as Azure Active Directory) as identity provider as from version 10.1.5. Entra ID is Microsoft's cloud-based identity and access management service, which helps users sign in and access resources.

> [!NOTE]
> Prior to July 2023, Microsoft Entra ID was called Azure Active Directory.

#### Setting up a Microsoft Entra ID Enterprise application

From DataMiner 10.3.4/10.4.0 onwards, you must create an Enterprise Application in Entra ID when setting up external authentication. In earlier DataMiner versions from DataMiner 10.2.0/10.2.1 onwards, creating an Enterprise Application is highly recommended, as otherwise not all features will be available.

> [!NOTE]
> Only a Global Administrator, Application Administrator, Cloud Application Administrator, and Application Developer have the necessary permissions to create Enterprise applications.

1. In Entra ID, register DataMiner as an Enterprise Application:

   1. Navigate to ``portal.azure.com`` and log in.
   1. Select the Azure Active Directory service.
   1. In the pane on the left, click *Enterprise applications*.
   1. At the top, click *New application*.
   1. Click *Create your own application*.
   1. Select *Integrate another application you don’t find in the gallery* and click *Create*.

1. In the pane on the left, go to *Users and groups*.

1. Add the necessary users and groups, and assign the necessary roles.

   > [!NOTE]
   > Make sure that all users have their *Email* field filled in. Azure will not authenticate users with an empty *Email* field.

1. Go to *Single sign-on*, select "SAML", and edit the following settings in *Basic SAML Configuration*:

   - Set *Entity ID* to the IP address or DNS name specified in the *spMetadata.xml* file, for example ``https://dataminer.example.com/``.

   - Under *Reply URL*, specify the following URL(s), replacing ``dataminer.example.com`` with the IP address or DNS name in the *spMetadata.xml* file (note the trailing "/"):

     From DataMiner 10.3.5 onwards:

     - ``https://dataminer.example.com/API/``

     Older DataMiner versions:

     - ``https://dataminer.example.com/root/``
     - ``https://dataminer.example.com/ticketing/``
     - ``https://dataminer.example.com/jobs/``
     - ``https://dataminer.example.com/monitoring/``
     - ``https://dataminer.example.com/dashboard/``
     - ``https://dataminer.example.com/API/``
     - ``https://dataminer.example.com/``

   - Set *Sign on URL* to the IP address or DNS name specified in the *spMetadata.xml* file, for example ``https://dataminer.example.com/``.

   > [!TIP]
   > - See also: [Creating a DataMiner metadata file](#creating-a-dataminer-metadata-file)
   > - See also: [Additional configuration for systems connected to dataminer.services](#additional-configuration-for-systems-connected-to-dataminerservices)

#### Retrieving the identity provider's metadata file on Microsoft Entra ID

In Entra ID, the ipMetadata URL can be found under *Single sign-on > SAML Signing Certificate – App Federation Metadata Url*.

#### Configuring DataMiner to import users and groups from Microsoft Entra ID

Once you have established a trust relationship between DataMiner (i.e. the service provider) and Entra ID (i.e. the identity provider), you can also configure DataMiner to import users and user groups from Entra ID. To do so, proceed as follows.

1. Gather the following information:

   - **Client ID**, **Object ID**, and **Tenant ID**: These GUIDs identify the application (DataMiner) in the Entra ID platform, and identify the users & groups directory on the Azure portal, respectively. You can find these fields on the root page of the application: *Microsoft Entra ID > App registrations > [your application name]*.

     Creating an Enterprise Application will also create an app registration with the same name, but you will not find it under *owned application*.

     > [!IMPORTANT]
     > Do not use the *Object ID* under *Azure Active Directory > Enterprise applications > [your application name]*. This is a different Object ID, which will not work.

     > [!NOTE]
     > From DataMiner 10.3.11/10.4.0 onwards<!-- RN 37162 -->, the **Object ID** is optional.

   - **Client Secret**: In the pane on the left, click *Certificates & secrets*.

     1. In the *Client secrets* section, click *New client secret*.
     1. Enter a description and an expiration date for the application secret.
     1. Copy the secret value for later on.

        > [!IMPORTANT]
        > Once you leave this page, you will no longer be able to access the secret value.

   - **Username** and **Password**: The Entra ID user account that DataMiner will use to request data from Azure. Technically this can be any account, but we recommend that you create an account that will be use exclusively for this purpose. Note that, depending on the method of querying, specifying this account can be optional from DataMiner 10.1.11/10.2.0 onwards (see note below).

1. Configure DataMiner with this information:

   1. Stop the DMA for which you want to configure this.

   1. On the DMA, go to the *C:\\Skyline DataMiner* folder and open the *DataMiner.xml* file.

   1. In the *DataMiner.xml* file, specify the information you previously gathered using the same syntax as in the following example:

      ```xml
      <AzureAD
       tenantId="[GUID]"
       objectId="[GUID]"
       clientId="[GUID]"
       clientSecret="[the DataMiner application secret value]"
       username="[username]"
       password="[password]" />
      ```

      > [!NOTE]
      > From DataMiner 10.1.11/10.2.0 onwards, DataMiner supports Entra ID application querying. If this is used instead of delegated querying, an authentication secret will suffice and no username and password will need to be specified here.

   1. Save the file and restart DataMiner.

   > [!NOTE]
   > As the client secret and password are sensitive data, after DataMiner has been restarted, this information is encrypted and replaced with a GUID in the *clientSecret* and *password* attributes of the *DataMiner.xml* file.

1. On the application (DataMiner) root page, click *API Permissions* in the pane on the left and make sure the necessary permissions are enabled:

   For delegated querying:

   - Microsoft Graph \> Application.Read.All – Delegated – Read applications
   - Microsoft Graph \> GroupMember.Read.All – Delegated – Read groups memberships
   - Microsoft Graph \> User.Read – Delegated – Sign in and read user profile
   - Microsoft Graph \> User.Read.All – Delegated – Read all users’ full profiles

   For application querying (supported from DataMiner 10.1.11/10.2.0 onwards):

   - Microsoft Graph \> Application.Read.All – Application – Read applications
   - Microsoft Graph \> GroupMember.Read.All – Application – Read groups memberships
   - Microsoft Graph \> User.Read.All – Application - Read all users’ full profiles
   - Microsoft Graph \> User.Read – Delegated – Sign in and read user profile

1. Add the Entra ID users to DataMiner:

   1. Open DataMiner Cube and log in with an existing Administrator account.
   1. Add the users/groups as described in [Adding a user](xref:Adding_a_user) and [Adding a user group](xref:Adding_a_user_group). If you choose to add an existing user or group, you will be presented a list of all users and groups available on Entra ID.
   1. When you have added the necessary users, configure their permissions. See [Configuring a user group](xref:Configuring_a_user_group).

   It is now possible to log in to DataMiner with any of the Entra ID user accounts you have added, using either the domain and username (DOMAIN\\user) or the email address.

#### Configuring automatic creation of users authenticated by Entra ID using SAML

From DataMiner 10.2.0/10.1.12 onwards, users authenticated by Entra ID using SAML can be automatically created and assigned to groups in DataMiner. This is often referred to as JIT (Just-In-Time) Provisioning.

1. Go to *Single Sign-on > Attributes & Claims* and add a group claim.

   > [!NOTE]
   > If you add a group claim, the account name of the group will only be sent via SAML when the groups are synchronized. Otherwise, the ID of the group will be sent instead.

1. In DataMiner Cube, add the groups corresponding with the groups you added in Entra ID. See [Adding a user group](xref:Adding_a_user_group).

1. Stop DataMiner.

1. Go to the *C:\\Skyline DataMiner* folder and open the *DataMiner.xml* file.

1. In the *DataMiner.xml* file, configure the *\<ExternalAuthentication>* tag as illustrated in the example below:

   ```xml
   <DataMiner ...>
     ...
     <ExternalAuthentication
       type="SAML"
       ipMetadata="[Path/URL of the identity provider’s metadata file]"
       spMetadata="[Path/URL of the service provider’s metadata file]"
       timeout="300">
       <AutomaticUserCreation enabled="true">
         <EmailClaim>http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress</EmailClaim>
         <Givenname>http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname</Givenname>
         <Surname>http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname</Surname>
         <Groups claims="true">[group claim name]</Groups>
       </AutomaticUserCreation>
     </ExternalAuthentication>
     ...
   </DataMiner>
   ```

   > [!NOTE]
   >
   > - User groups have to exist in DataMiner both for *Groups* claims set to true and to false. Make sure all the necessary groups have been added earlier, so that it will be possible to add users to them.
   > - If you set the *claims* attribute of the *Groups* element to "false", no claims will be used to add users to groups. In this case:
   >   - Instead of a claim for user groups, replace `[group claim name]` with a security group that exists in DataMiner as described above.
   >   - It will only be possible to add a user to a single group.
   >   - The user information that is created will not be updated.

1. Save the *DataMiner.xml* file.

1. Restart the DataMiner Agent.

> [!NOTE]
> If your default username is not in email format or if DataMiner is unable to locate it, configure the *\<PreferredEmailClaim>* tag to ensure it points to the correct email address.

### Azure B2C

DataMiner supports Azure B2C as identity provider from version 10.2.6/10.3.0 onwards. To configure this:

1. Configure Azure B2C. See [Azure Active Directory B2C documentation | Microsoft Docs](https://docs.microsoft.com/en-us/azure/active-directory-b2c/).
1. Create a DataMiner metadata file. You can do this in the same way as for [Entra ID](#creating-a-dataminer-metadata-file).
1. Set up an Entra ID Enterprise application. You can do this in the same way as for [Entra ID](#setting-up-a-microsoft-entra-id-enterprise-application).
1. Configure policies for Azure B2C. See [Tutorial: Create user flows and custom policies in Azure Active Directory B2C | Microsoft Docs](https://docs.microsoft.com/en-us/azure/active-directory-b2c/tutorial-create-user-flows?pivots=b2c-custom-policy).
1. Get the metadata URL:

   1. In Azure, go to *App registrations*, select your app, and select *Overview* > *Endpoints*.
   1. Select the Azure AD B2C SAML metadata endpoint, e.g. `https://dataminerservices.b2clogin.com/dataminerservices.onmicrosoft.com/<policy-name>/Samlp/metadata`, and replace \<policy-name> with the name of the policy you created earlier.

1. Configure DataMiner to automatically create users from Azure B2C. You can do this in the same way as for [Entra ID](#configuring-automatic-creation-of-users-authenticated-by-entra-id-using-saml). For the ipMetadata link, use the link created in the previous step.

   > [!NOTE]
   > To create SAML users in DataMiner using Azure B2C, a domain is required in the usernames. For this reason, email addresses must be used as the usernames. If the default username of the identity provider is not a valid email address, add a \<PreferredLoginClaim> element to the \<AutomaticUserCreation> element in *DataMiner.xml* that refers to a claim containing a valid email address.

### Okta

DataMiner supports Okta as identity provider as from version 10.1.11. Use Okta's App Integration Wizard to create a new app integration and connect Okta with DataMiner.

> [!IMPORTANT]
>
> - Prior to DataMiner 10.3.0/10.3.2, it may not be possible to log in using Okta because of a software issue. We strongly recommend that you upgrade to DataMiner 10.3.0 or 10.3.2 to use this feature.
> - When Okta is used, automatic user creation must be enabled. It is currently not possible to import users and groups from Okta. Alternatively, you can add local or domain users. See [User directories](xref:User_management#user-directories) and [Local users](xref:User_management#local-users). After that, you can have Okta authenticate these users by following the guide below, except that you omit the *AutomaticUserCreation* tag in *DataMiner.xml*.

1. Launch the App Integration Wizard

   1. In the Admin Console, go to *Applications \> Applications*.
   1. Click *Create App Integration*.
   1. To create a SAML integration, select "SAML 2.0" as the *Sign-on method*.
   1. Click *Next*.

1. Configure the general settings:

   - **App name**: The name of your application. Fill in “DataMiner” (or some other preferred name).

   - **App logo**: Optional logo to be linked to your application.

     - Format: PNG, JPG or GIF
     - Max. size: 1 MB
     - Min. resolution: 420 x 120 pixels

     > [!TIP]
     > It is recommended to use a PNG image with a transparent background and a landscape orientation.

1. Configure the Okta SAML settings:

   - **Single sign on URL**: The location where the SAML assertion is sent with a POST operation.

     - In this box, enter e.g. ``https://dataminer.example.com/root/``.
     - Select the following checkboxes:

       - *Use this for Recipient URL and Destination URL*
       - *Allow this app to request other SSO URLs*

     - Open *Show Advanced Settings* and enter the following additional URLs to *Other Requestable SSO URLs*:

       From DataMiner 10.3.5 onwards:
       - ``https://dataminer.example.com/API/``

       Older DataMiner versions:
       - ``https://dataminer.example.com/root/``
       - ``https://dataminer.example.com/API/``
       - ``https://dataminer.example.com/dashboard/``
       - ``https://dataminer.example.com/monitoring/``
       - ``https://dataminer.example.com/jobs/``
       - ``https://dataminer.example.com/ticketing/``

       > [!NOTE]
       > The indexes here should be the same as the indexes in `C:\Skyline DataMiner\okta-sp-metadata.xml`, which we will create in a further step.

       > [!TIP]
       > See also: [Additional configuration for systems connected to dataminer.services](#additional-configuration-for-systems-connected-to-dataminerservices)

   - **Audience URI (SP Entity ID)**: The intended audience of the SAML assertion.

     In this box, enter ``https://dataminer.example.com/``.

   - **Name ID format**: The username format you are sending in the SAML Response.

     Select "EmailAddress".

   - **Application username**: The default value to use for the username with the application.

     Select "Email".

   - **Attribute Statements**: Add the following attribute statements, all with "Basic" format:

      - name "Email", value "user.email"
      - name "Firstname", value "user.firstName"
      - name "Lastname", value "user.lastName"

   - **When using group claims:**

      - Create groups in DataMiner with the exact same names as in Okta (this is case-sensitive). See [Adding a user group](xref:Adding_a_user_group).
      - Add a group attribute statement.
      - Use the name "userGroups", and "Basic" format.
      - Under *Filter*, select the type of filter you want, and then add a statement that will match the groups you want to send for that user.

      > [!Note]
      >
      > - The name fields can be anything you want, but we recommend giving them a name that clearly reflects the claim they refer to. All of these are case-sensitive.
      > - Make sure that what you put under "name" for each claim matches exactly with the claim names in *DataMiner.xml*.

1. Stop DataMiner.

1. Go to the *C:\\Skyline DataMiner* folder and open the *DataMiner.xml* file.

1. In the *DataMiner.xml* file, configure the *\<ExternalAuthentication>* tag as illustrated in the example below:

   ```xml
   <DataMiner ...>
     ...
     <ExternalAuthentication
       type="SAML"
       ipMetadata="[Path/URL of the identity provider’s metadata file]"
       spMetadata="[Path/URL of the service provider’s metadata file]"
       timeout="300">
       <AutomaticUserCreation enabled="true">
         <EmailClaim>[email claim name]</EmailClaim>
         <Givenname>[firstname claim name]</Givenname>
         <Surname>[lastname claim name]</Surname>
         <Groups claims="true">[group claim name]</Groups>
       </AutomaticUserCreation>
     </ExternalAuthentication>
     ...
   </DataMiner>
   ```

   > [!NOTE]
   >
   > - The claim name refers to the attribute statement names that were added in Okta.
   > - User groups have to exist in DataMiner both for *Groups* claims set to true and to false. Make sure all the necessary groups have been added earlier, so that it will be possible to add users to them.
   > - If you set the *claims* attribute of the *Groups* element to "false", no claims will be used to add users to groups. In this case:
   >   - Instead of a claim for user groups, replace `[group claim name]` with a security group that exists in DataMiner as described above.
   >   - It will only be possible to add a user to a single group.
   >   - The user information that is created will not be updated.

1. Save the *DataMiner.xml* file.

1. Open the *Sign On* tab of your Okta application and scroll down to *SAML Signing Certificates*.

1. In the *Actions* column of the *Active* certificate, click *View IdP metadata*.

1. Save this identity provider’s metadata XML file to the DataMiner Agent, e.g. `C:\Skyline DataMiner\okta-ip-metadata.xml`.

1. Copy the following template to a new XML file named e.g. `C:\Skyline DataMiner\okta-sp-metadata.xml` to create the service provider’s metadata file. You can find the EntityID in the previously created file `C:\Skyline DataMiner\okta-ip-metadata.xml`.

   From DataMiner 10.3.5 onwards:

   ```xml
   <?xml version="1.0" encoding="UTF-8"?>
   <md:EntityDescriptor xmlns:md="urn:oasis:names:tc:SAML:2.0:metadata" xmlns:ds="http://www.w3.org/2000/09/xmldsig#" entityID="[ENTITYID]" validUntil="2050-01-04T10:00:00.000Z">
     <md:SPSSODescriptor AuthnRequestsSigned="false" WantAssertionsSigned="true" protocolSupportEnumeration="urn:oasis:names:tc:SAML:2.0:protocol">
       <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/API/" index="0" isDefault="false"/>
     </md:SPSSODescriptor>
   </md:EntityDescriptor>
   ```

   Older DataMiner versions:

   ```xml
   <?xml version="1.0" encoding="UTF-8"?>
   <md:EntityDescriptor xmlns:md="urn:oasis:names:tc:SAML:2.0:metadata" xmlns:ds="http://www.w3.org/2000/09/xmldsig#" entityID="[ENTITYID]" validUntil="2050-01-04T10:00:00.000Z">
     <md:SPSSODescriptor AuthnRequestsSigned="false" WantAssertionsSigned="true" protocolSupportEnumeration="urn:oasis:names:tc:SAML:2.0:protocol">
       <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/API/" index="0" isDefault="false"/>
       <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/root/" index="1" isDefault="false"/>
       <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/dashboard/" index="2" isDefault="false"/>
       <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/monitoring/" index="3" isDefault="false"/>
       <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/jobs/" index="4" isDefault="false"/>
       <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/ticketing/" index="5" isDefault="false"/>
     </md:SPSSODescriptor>
   </md:EntityDescriptor>
   ```

1. Restart DataMiner.
