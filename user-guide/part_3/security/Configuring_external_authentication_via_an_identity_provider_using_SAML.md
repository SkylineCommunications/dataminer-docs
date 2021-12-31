## Configuring external authentication via an identity provider using SAML

From DataMiner 9.6.11 onwards, it is possible to configure external authentication via an identity provider service using SAML (Security Assertion Markup Language).

For this to be possible, a trust relationship must be established between the service provider (i.e. DataMiner) and the identity provider. This is done by exchanging SAML metadata files. The following metadata must be shared between the service provider (i.e. DataMiner) and the Identity Provider service: Entity ID, Cryptographic Keys, Protocol Endpoints (bindings, locations).

To configure this, follow the steps below:

1. In the folder *C:\\Skyline DataMiner,* open the file *DataMiner.xml*.

2. In *DataMiner.xml*, configure the *\<ExternalAuthentication>* tag as illustrated in the example below:

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

    | Attribute | Description                                                                                                                                                                                                                                                                                                                                 |
    |-------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | type        | SAML (Identity federation using SAML assertions)                                                                                                                                                                                                                                                                                            |
    | ipMetadata  | The path to or the URL of the identity provider’s metadata file.<br> -  If the identity provider is **Azure AD**, see [Retrieving the identity provider’s metadata file on Azure AD](#retrieving-the-identity-providers-metadata-file-on-azure-ad). |
    | spMetadata  | The path to or the URL of the service provider’s metadata file.<br> See [Creating a DataMiner metadata file](#creating-a-dataminer-metadata-file)                                                                                                                                                                                           |
    | timeout     | Optional attribute. The amount of time DataMiner should wait for the user to be authenticated by the identity provider. If this attribute is not specified, DataMiner will wait 300 seconds (5 minutes).                                                                                                                                    |

3. Save and close the file and restart the DMA.

Once this has been configured, if a user tries to log in to the DMA using external authentication via SAML, they will be redirected to a login page of the identity provider. That page will authenticate the user and return a SAML response, which DataMiner can use to either grant or deny the user access.

> [!NOTE]
> -  From DataMiner 10.2.0/10.1.4 onwards, Cube uses the Chromium web browser engine to handle SAML external authentication, which supports a wider range of identity providers than the Internet Explorer engine that was used previously.
> -  When external authentication is enabled, it is no longer possible to log in with local accounts, except the local Administrator account.
> -  DataMiner will expect one of the claims provided by the identity provider to be the “name” claim: “http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name”. This field must contain either the user name of the email address.
> -  Prior to DataMiner 10.1.11/10.2.0, only the Administrator user can bypass the external authentication provider by entering an explicit username/password combination. In later DataMiner versions, this is also allowed for any local DataMiner user account.

> [!TIP]
> See also:
> [Authenticating Azure AD Users on DataMiner with SAML](https://community.dataminer.services/video/authenticating-azure-ad-users-on-dataminer-with-saml/) in the Dojo video library

### Creating a DataMiner metadata file

To create a DataMiner metadata file, proceed as follows:

1. Copy the following template into a new XML file named e.g. spMetadata.xml:

    ```xml
    <?xml version="1.0" encoding="UTF-8"?>                                                                                                                                                                                                                                                                        
    <md:EntityDescriptor xmlns:md="urn:oasis:names:tc:SAML:2.0:metadata" xmlns:ds="http://www.w3.org/2000/09/xmldsig#" entityID="[ENTITYID]" validUntil="2050-01-04T10:00:00.000Z">                                                                                                
      <md:SPSSODescriptor AuthnRequestsSigned="false" WantAssertionsSigned="true" protocolSupportEnumeration="urn:oasis:names:tc:SAML:2.0:protocol">                                                                                                                                                                
        <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com" index="0" isDefault="true"/>                                                                                                                      
        <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/login" index="1" isDefault="false"/>                                                                                                               
        <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/root" index="2" isDefault="false"/>                                                                                                                
        <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/dashboard" index="3" isDefault="false"/>                                                                                                           
        <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/monitoring" index="4" isDefault="false"/>                                                                                                          
        <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/jobs" index="5" isDefault="false"/>                                                                                                                
        <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/ticketing" index="6" isDefault="false"/>                                                                                                           
        <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="[FOR EVERY CUSTOM APP URL, ADD AN ASSERTION LIKE THE ONES ABOVE WITH AN INCREMENTED INDEX. IF YOU DO NOT HAVE CUSTOM APPS, REMOVE THIS EXAMPLE.]" index="7" isDefault="false"/>
      </md:SPSSODescriptor>                                                                                                                                                                                                                                                                                         
    </md:EntityDescriptor>                                                                                                                                                                                                                                                                                        
    ```

2. Replace \[ENTITYID\] with the unique service provider ID that is assigned to DataMiner when you register it with the identity provider.

    - If the identity provider is **Azure AD**, this unique service provider ID is called “Application ID”. See [Registering DataMiner as an application in Azure AD](#registering-dataminer-as-an-application-in-azure-ad).

3. Replace “https://dataminer.example.com” with the IP address or the DNS name of your DataMiner System. Make sure the endpoint addresses in the Location attributes match the DataMiner application endpoints you specified when you registered DataMiner with the identity provider.

    - If the identity provider is **Azure AD**, then see [Registering DataMiner as an application in Azure AD](#registering-dataminer-as-an-application-in-azure-ad).

### Using Azure AD as identity provider

DataMiner supports Azure AD as identity provider as from version 10.1.5. Azure Active Directory is Microsoft’s cloud-based identity and access management service, which helps employees sign in and access resources.

#### Registering DataMiner as an application in Azure AD

You will need to register DataMiner as an application in Azure and generate a client secret. To do so:

1. Navigate to *portal.azure.com* and log in.

2. Select the *Azure Active Directory* service.

3. In the pane on the left, click *App registrations*.

4. Register DataMiner as a new application:

    1. In the top menu bar, click *New Registration*.

    2. In the* Register an application* form, fill in “DataMiner” (or some other preferred name) as the name of the application.

    3. Under *Supported account types*, select *Accounts in this organizational directory only.* 

    4. Under *Redirect URI*, fill in the following DataMiner application endpoints:

        - https://dataminer.example.com

        - https://dataminer.example.com/login

        - https://dataminer.example.com/root

        - https://dataminer.example.com/dashboard

        - https://dataminer.example.com/monitoring

        - https://dataminer.example.com/jobs

        - https://dataminer.example.com/ticketing

    5. Click *Register*. The new application will now be listed and a unique ID will be assigned to it (i.e. the Application ID).

    6. On the home page of the App registration, do the following:

        - Assign the Application ID URI. This is the unique identifier of your App (SP) represented as an URI, e.g. *https://dataminer.example.com*.

        - In the pane on the left, click *API Permissions* and make sure the following permission is enabled:

            - Microsoft Graph \> User.Read – Delegated – sign in and read user profile

#### Retrieving the identity provider’s metadata file on Azure AD

To retrieve the identity provider’s metadata file on Azure AD, proceed as follows:

1. Navigate to the App registration you created as mentioned under [Registering DataMiner as an application in Azure AD](#registering-dataminer-as-an-application-in-azure-ad).

2. In the top header bar, click *Endpoints*. An Endpoints panel will expand from the right.

3. Access the identity provider’s metadata file via the URL on the *Federation Metadata Document* field.

#### Configuring DataMiner to import users and groups from Azure AD

> [!NOTE]
> From DataMiner 10.2.0/10.1.12 onwards, users authenticated by Azure AD using SAML can be automatically created and assigned to groups. However, if you want to make use of this feature, do not configure DataMiner to import users and groups from Azure AD, as this could cause users to be created twice. See [Configuring automatic creation of users authenticated by Azure AD using SAML](#configuring-automatic-creation-of-users-authenticated-by-azure-ad-using-saml)

Once you have established a trust relationship between DataMiner (i.e. the service provider) and Azure AD (i.e. the identity provider), you can also configure DataMiner to import users and user groups from Azure AD. To do so, proceed as follows.

1. Gather the following information:

    - **Client ID** and **Tenant ID**: These GUIDs identify the application (DataMiner) in the Azure AD platform, and identify the users & groups directory on the Azure portal, respectively. You can find these fields on the root page of the application: *Azure Active Directory* > *App registrations* > *DataMiner*.

    - **Client Secret**: A shared secret in string form. You can find this information under Certificates & secrets, as mentioned under [Registering DataMiner as an application in Azure AD](#registering-dataminer-as-an-application-in-azure-ad).

    - **Username** and** Password**: The Azure AD user account and corresponding password that DataMiner will use to request data from Azure AD. Technically this can be any account, but we recommend that you create an account specifically for this purpose. Note that depending on the method of querying, these can be optional from DataMiner 10.1.11/10.2.0 onwards (see note below).

2. Configure DataMiner with this information:

    1. Stop the DMA for which you want to configure this.

    2. In the folder *C:\\Skyline DataMiner* of the DMA, open the file *DataMiner.xml*.

    3. Specify the information you previously gathered using the same syntax as in the following example:

        ```xml
        <AzureAD                                             
           tenantId="[GUID]"                                
           clientId="[GUID]"                                
           clientSecret="[the DataMiner application secret]"
           username="[username]"                            
           password="[password]" />                         
        ```

        > [!NOTE]
        > From DataMiner 10.1.11/10.2.0 onwards, DataMiner supports Azure AD application querying. If this is used instead of delegated querying, an authentication secret is sufficient, so that the username and password do not need to be specified here.

    4. Save the file and restart DataMiner.

3. On the application (DataMiner) root page, do the following:

    1. Click *API Permissions* in the pane on the left and make sure the necessary permissions are enabled:

        For delegated querying:

        - Microsoft Graph \> GroupMember.Read.All – Delegated – Read groups memberships

        - Microsoft Graph \> User.Read – Delegated – Sign in and read user profile

        - Microsoft Graph \> User.Read.All – Delegated – Read all users’ full profiles

        For application querying (supported from DataMiner 10.1.11/10.2.0 onwards):

        - Microsoft Graph \> GroupMember.Read.All – Application

        - Microsoft Graph \> User.Read.All – Application

        - Microsoft Graph \> User.Read – Delegated

    2. Click *Certificates & secrets* in the pane on the left.

        - In the *Client secrets* section, click *+ New client secret*.

        - Fill in a description and an expiration date for the application secret.

4. Restart DataMiner.

5. Add the Azure AD users to DataMiner:

    1. Log on to DataMiner Cube with an existing Administrator account.

    2. Add the users/groups as described in [Adding a user](Adding_a_user.md) and [Adding a user group](Adding_a_user_group.md). If you opt to add an existing user or group, you will have a list of all users and groups available on Azure AD.

    3. When you have added the users, configure their permissions. See [Configuring a user group](Configuring_a_user_group.md).

        It is now possible to log on to DataMiner with any of the Azure AD user accounts you have added, using either the domain and username (DOMAIN\\user) or the email address.

#### Configuring automatic creation of users authenticated by Azure AD using SAML

From DataMiner 10.2.0/10.1.12 onwards, users authenticated by Azure AD using SAML can be automatically created and assigned to groups in DataMiner.

> [!NOTE]
> If you want to use this feature, make sure DataMiner is not configured to import users and/or groups from Azure AD. This might cause users to be created twice.

To configure DataMiner to automatically (a) create users authenticated by Azure AD using SAML and (b) assign them to groups, proceed as follows:

1. In the Azure Portal, make sure DataMiner is registered as an Enterprise Application in Azure AD:

    1. Navigate to *portal.azure.com* and log in.

    2. Select the *Azure Active Directory* service.

    3. In the pane on the left, click *Enterprise applications*.

    4. At the top, click *New application*.

    5. Click *Create your own application*.

    6. Select *Integrate an other application you don’t find in the gallery* and click *Create*.

2. In the pane on the left, go to *Users and groups.* 

3. Add the necessary users and groups and edit them to assign a role.

    All users that should be auto-created in DataMiner must be added to the application in Azure AD. To add a user, you can either add the group containing a user, or add the user separately.

4. Go to *Single sign-on*, select *SAML*, and edit the following settings in “Basic SAML Configuration”:

    - Set *Entity ID* to “https://\[your application name\]”.

    - Under *Reply URL*, specify the following URLs:

        ```txt
        https://[your application name]/root/     
        https://[your application name]/ticketing 
        https://[your application name]/jobs      
        https://[your application name]/monitoring
        https://[your application name]/dashboard 
        https://[your application name]/root      
        https://[your application name]/login     
        https://[your application name]           
        ```

    - Set *Sign on URL* to “https://\[your application name\]”.

5. Go to *User Attributes & Claims* and add a group claim.

    > [!NOTE]
    > If you add a group claim, the account name of the group will only be sent via SAML when the groups are synchronized. Otherwise, the ID of the group will be sent instead.

6. In DataMiner Cube, add the groups corresponding with the groups you added in Azure AD.

7. Stop DataMiner.

8. In the folder *C:\\Skyline DataMiner,* open the file *DataMiner.xml*.

9. In *DataMiner.xml*, configure the *\<ExternalAuthentication>* tag as illustrated in the example below:

    ```xml
    <DataMiner ...>                                                                                                                                                                                                            
      ...                                                                                                                                                                                                                         
      <ExternalAuthentication      type="SAML"      ipMetadata="[Path/URL of the identity provider’s metadata file]"      spMetadata="[Path/URL of the service provider’s metadata file]"      timeout="300">
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
    > -  In Azure AD, the ipMetadata URL can be found under *Single sign-on \> SAML Signing Certificate – App Federation Metadata*.
    > -  If you set the *claims* attribute of the *Groups* element to “false”, no claims will be used to add users to groups. In this case:
    >     - The name of the group as specified in Cube will be used instead. 
    >     - A user can only be added to a single group.
    >     - The user information that is created will not be updated.

10. Save the DataMiner.xml file.

11. Create an spMetadata file as described in [Creating a DataMiner metadata file](#creating-a-dataminer-metadata-file). However, the EntityID in this case can be found under *Single sign-on*. It is not the application ID.

12. Restart the DataMiner Agent.

### Using Okta as identity provider

DataMiner supports Okta as identity provider as from version 10.1.11. Use Okta’s App Integration Wizard to create a new app integration and connect Okta with DataMiner.

1. Launch the App Integration Wizard

    1. In the Admin Console, go to *Applications \> Applications*.

    2. Click *Create App Integration*.

    3. To create a SAML integration, select “SAML 2.0” as the *Sign-on method*.

    4. Click *Next*.

2. Configure the general settings:

    | Setting | Description                                                                                                                                                                                                                                                                                                                                                                                                                                          |
    |-----------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | App name  | The name of your application. Fill in “DataMiner” (or some other preferred name).                                                                                                                                                                                                                                                                                                                                                                    |
    | App logo  | Optional logo to be linked to your application.<br> -  Format: PNG, JPG or GIF<br> -  Max. size: 1 MB<br> -  Min. resolution: 420 x 120 pixels<br> Tip: It is recommended to use a PNG image with a transparent background and a landscape orientation. |

3. Configure the SAML settings:

    | Setting            | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
    |----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Single sign on URL   | The location where the SAML assertion is sent with a POST operation.<br> -  In this box, enter e.g. https://dataminer.example.com/root<br> -  Select the following checkboxes:<br> •    - *Use this for Recipient URL and Destination URL*<br> •    - *Allow this app to request other SSO URLs*<br> -  Enter the following additional URLs:<br>     - https://dataminer.example.com/login
>     - https://dataminer.example.com/dashboard
>     - https://dataminer.example.com/monitoring
>     - https://dataminer.example.com/jobs
>     - https://dataminer.example.com/ticketing|
| Audience URI         | The intended audience of the SAML assertion.<br> -  In this box, enter https://dataminer.example.com/root                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
| Name ID format       | The username format you are sending in the SAML Response.<br> -  Select “EmailAddress”                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |
| Application username | The default value to use for the username with the application.<br> -  Select “Email”                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |

### Error messages

#### General errors

| Error message                                                                                | Application       | Cause                                                                                                                                                                                 |
|----------------------------------------------------------------------------------------------|-------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Object reference not set to an instance of an object.                                        | Cube              | Incorrect or unexpected data in *spMetadata.xml*.                                                                                                      |
| Cannot connect to the DMA; exception trapped: Failed getting the user info (empty response). | Web apps          | Incorrect or unexpected data in *spMetadata.xml*.                                                                                                      |
| Expected one and only one default assertion consumer service endpoint.                       | Cube<br> Web apps | In *spMetadata.xml*, none of the Assertion Consumer Service URLs are marked as the default URL. Typically, the /root URL is marked as the default URL. |
| Assertion consumer service \<URL> was not found.                                             | Cube<br> Web apps | The Assertion Consumer Service URL is spelled incorrectly or cannot be found in *spMetadata.xml*.                                                      |

#### Azure AD errors

| Error message                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          | Application | Cause                                                                                                      |
|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------|------------------------------------------------------------------------------------------------------------|
| AADSTS50011: The reply URL specified in the request does not match the reply URLs configured for the application: '\<ID>'.                                                                                                                                                                                                                                                                                                                                                                                                                                             | Cube        | The URL marked as default URL is either missing or spelled differently in the app registration form.       |
| AADSTS50011: The reply URL specified in the request does not match the reply URLs configured for the application: '\<ID>'.                                                                                                                                                                                                                                                                                                                                                                                                                                             | Web apps    | The reply URL of a specific web app is either missing or spelled differently in the app registration form. |
| AADSTS500113: No reply address is registered for the application.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      | Web apps    | No reply URL is specified in the app registration form.                                                    |
| AADSTS650056: Misconfigured application. This could be due to one of the following: the client has not listed any permissions for 'AAD Graph' in the requested permissions in the client's application registration. Or, the admin has not consented in the tenant. Or, check the application identifier in the request to ensure it matches the configured client application identifier. Or, check the certificate in the request to ensure it's valid. Please contact your admin to fix the configuration or consent on behalf of the tenant. Client app ID: \<ID>. |             | The required API permissions are missing in the app registration form.                                     |
| AADSTS700016: Application with identifier '\<ID>' was not found in the directory '\<ID>'. This can happen if the application has not been installed by the administrator of the tenant or consented to by any user in the tenant. You may have sent your authentication request to the wrong tenant.                                                                                                                                                                                                                                                                   |             | Entity ID incorrect or not found.                                                                          |
