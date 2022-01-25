---
uid: Configuring_external_authentication_via_an_identity_provider_using_SAML
---

# Configuring external authentication via an identity provider using SAML

From DataMiner 9.6.11 onwards, it is possible to configure external authentication via an identity provider service using SAML (Security Assertion Markup Language).

For this to be possible, a trust relationship must be established between the service provider (i.e. DataMiner) and the identity provider. This is done by exchanging SAML metadata files. The following metadata must be shared between the service provider (i.e. DataMiner) and the Identity Provider service: Entity ID, Cryptographic Keys, Protocol Endpoints (bindings, locations).

To configure this, follow the steps below:

1. Go to the *C:\\Skyline DataMiner* folder and open the *DataMiner.xml* file.

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

    | Attribute | Description |
    | --------- | ----------- |
    | type | SAML (Identity federation using SAML assertions) |
    | ipMetadata | The path to or the URL of the identity provider's metadata file.<br/>The way in which to retrieve this metadata file will depend on the identity provider you are using. See [Identity providers](#identity-providers) |
    | spMetadata | The path to or the URL of the service provider's metadata file.<br/> See [Creating a DataMiner metadata file](#creating-a-dataminer-metadata-file) |
    | timeout | Optional attribute. The amount of time DataMiner should wait for the user to be authenticated by the identity provider. If this attribute is not specified, DataMiner will wait 300 seconds (5 minutes). |

3. Save and close the file, and restart the DMA.

Once this has been configured, if users try to log in to the DMA using external authentication via SAML, they will be redirected to a login page of the identity provider. That page will authenticate them and return a SAML response, which DataMiner can use to either grant or deny access.

> [!NOTE]
> - From DataMiner 10.2.0/10.1.4 onwards, Cube uses the Chromium web browser engine to handle SAML external authentication. That engine supports a wider range of identity providers than the Internet Explorer engine that was used previously.
> - When external authentication is enabled, it is no longer possible to log in with local accounts, except the local Administrator account.
> - DataMiner will expect one of the claims provided by the identity provider to be the "name" claim: ``http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name``. This field must contain either the username or the email address.
> - Prior to DataMiner 10.1.11/10.2.0, only the Administrator user can bypass the external authentication provider by entering an explicit username/password combination. In later DataMiner versions, this is also allowed for any local DataMiner user account.
> - If there are two DataMiner users who share the same email address, both users will not be able to log in. To prevent this from happening, it is recommended to avoid using more than one method to add users. For example, do not add Windows domain users if the Azure AD users use the same email address.

> [!TIP]
> See also:
> [Authenticating Azure AD Users on DataMiner with SAML](https://community.dataminer.services/video/authenticating-azure-ad-users-on-dataminer-with-saml/) in the Dojo video library

## Creating a DataMiner metadata file

To create a DataMiner metadata file, proceed as follows:

1. Copy the following template into a new XML file named e.g. *spMetadata.xml*:

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

   The way in which you can find this ID will depend on the identity provider you are using. See [Identity providers](#identity-providers)

3. Replace ``https://dataminer.example.com`` with the IP address or the DNS name of your DataMiner System. Make sure the endpoint addresses in the location attributes match the DataMiner application endpoints you specified when you registered DataMiner with the identity provider.

    The way in which you configure this will depend on the identity provider you are using. See [Identity providers](#identity-providers)

> [!NOTE]
> The ``WantAssertionsSigned`` flag is supported as from DataMiner version 10.2.1/10.2.0. If you are using an older version, then set this to false.

## Identity providers

DataMiner currently supports the following identity providers:

- [Azure Active Directory](#azure-active-directory)
- [Okta](#okta)

### Azure Active Directory

DataMiner supports Azure AD as identity provider as from version 10.1.5. Azure Active Directory is Microsoft's cloud-based identity and access management service, which helps users sign in and access resources.

#### Setting up an Azure AD Enterprise application

As from DataMiner 10.2.0/10.2.1, it is recommended to create Enterprise Applications in Azure AD when setting up external authentication. When you create regular App registrations, certain features will not be available.

1. In Azure AD, register DataMiner as an Enterprise Application:

    1. Navigate to ``portal.azure.com`` and log in.
    2. Select the Azure Active Directory service.
    3. In the pane on the left, click *Enterprise applications*.
    4. At the top, click *New application*.
    5. Click *Create your own application*.
    6. Select *Integrate another application you don’t find in the gallery* and click *Create*.

2. In the pane on the left, go to *Users and groups*.

3. Add the necessary users and groups, and assign the necessary roles.

   > [!NOTE]
   > Make sure that all users have their *Email* field filled in. Azure will not authenticate users with an empty *Email* field.

4. Go to *Single sign-on*, select "SAML", and edit the following settings in *Basic SAML Configuration*:

    - Set *Entity ID* to ``https://[your application name]``. This entity ID must be identical to the one that is specified in the ``spMetadata.xml`` file.

    - Under *Reply URL*, specify the following URLs:

        - ``https://[your application name]/root/``
        - ``https://[your application name]/ticketing``
        - ``https://[your application name]/jobs``
        - ``https://[your application name]/monitoring``
        - ``https://[your application name]/dashboard``
        - ``https://[your application name]/root``
        - ``https://[your application name]/login``
        - ``https://[your application name]``

    - Set *Sign on URL* to ``https://[your application name]``.

#### Retrieving the identity provider's metadata file on Azure AD

In Azure AD, the ipMetadata URL can be found under *Single sign-on > SAML Signing Certificate – App Federation Metadata Url*.

#### Configuring DataMiner to import users and groups from Azure AD

Once you have established a trust relationship between DataMiner (i.e. the service provider) and Azure AD (i.e. the identity provider), you can also configure DataMiner to import users and user groups from Azure AD. To do so, proceed as follows.

1. Gather the following information:

    - **Client ID** and **Tenant ID**: These GUIDs identify the application (DataMiner) in the Azure AD platform, and identify the users & groups directory on the Azure portal, respectively. You can find these fields on the root page of the application: *Azure Active Directory > App registrations > [your application name]*.

        Creating an Enterprise Application will also create an app registration with the same name, but you will not find it under *owned application*.

    - **Client Secret**: In the pane on the left, click *Certificates & secrets*.

        1. In the *Client secrets* section, click *New client secret*.
        2. Enter a description and an expiration date for the application secret.
    
    - **Username** and **Password**: The Azure AD user account that DataMiner will use to request data from Azure AD. Technically this can be any account, but we recommend that you create an account that will be use exclusively for this purpose. Note that, depending on the method of querying, specifying this account can be optional from DataMiner 10.1.11/10.2.0 onwards (see note below).

2. Configure DataMiner with this information:

    1. Stop the DMA for which you want to configure this.

    2. On the DMA, go to the *C:\\Skyline DataMiner* folder and open the *DataMiner.xml* file.

    3. In the *DataMiner.xml* file, specify the information you previously gathered using the same syntax as in the following example:

        ```xml
        <AzureAD
         tenantId="[GUID]"
         clientId="[GUID]"
         clientSecret="[the DataMiner application secret]"
         username="[username]"
         password="[password]" />
        ```

        > [!NOTE]
        > From DataMiner 10.1.11/10.2.0 onwards, DataMiner supports Azure AD application querying. If this is used instead of delegated querying, an authentication secret will suffice and no username and password will need to be specified here.

    4. Save the file and restart DataMiner.

3. On the application (DataMiner) root page, click *API Permissions* in the pane on the left and make sure the necessary permissions are enabled:

    For delegated querying:

    - Microsoft Graph \> GroupMember.Read.All – Delegated – Read groups memberships
    - Microsoft Graph \> User.Read – Delegated – Sign in and read user profile
    - Microsoft Graph \> User.Read.All – Delegated – Read all users’ full profiles

    For application querying (supported from DataMiner 10.1.11/10.2.0 onwards):

    - Microsoft Graph \> GroupMember.Read.All – Application
    - Microsoft Graph \> User.Read.All – Application
    - Microsoft Graph \> User.Read – Delegated

4. Restart DataMiner.

5. Add the Azure AD users to DataMiner:

    1. Open DataMiner Cube and log in with an existing Administrator account.
    2. Add the users/groups as described in [Adding a user](xref:Adding_a_user) and [Adding a user group](xref:Adding_a_user_group). If you choose to add an existing user or group, you will be presented a list of all users and groups available on Azure AD.
    3. When you have added the necessary users, configure their permissions. See [Configuring a user group](xref:Configuring_a_user_group).

    It is now possible to log in to DataMiner with any of the Azure AD user accounts you have added, using either the domain and username (DOMAIN\\user) or the email address.

#### Configuring automatic creation of users authenticated by Azure AD using SAML

From DataMiner 10.2.0/10.1.12 onwards, users authenticated by Azure AD using SAML can be automatically created and assigned to groups in DataMiner.

1. Go to *User Attributes & Claims* and add a group claim.

    > [!NOTE]
    > If you add a group claim, the account name of the group will only be sent via SAML when the groups are synchronized. Otherwise, the ID of the group will be sent instead.

2. In DataMiner Cube, add the groups corresponding with the groups you added in Azure AD.

3. Stop DataMiner.

4. Go to the *C:\\Skyline DataMiner* folder and open the *DataMiner.xml* file.

5. In the *DataMiner.xml* file, configure the *\<ExternalAuthentication>* tag as illustrated in the example below:

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
    > If you set the *claims* attribute of the *Groups* element to "false", no claims will be used to add users to groups. In this case:
    > - The name of the group as specified in Cube will be used instead.
    > - It will only be possible to add a user to a single group.
    > - The user information that is created will not be updated.

6. Save the *DataMiner.xml* file.

7. Restart the DataMiner Agent.

### Okta

DataMiner supports Okta as identity provider as from version 10.1.11. Use Okta's App Integration Wizard to create a new app integration and connect Okta with DataMiner.

1. Launch the App Integration Wizard

    1. In the Admin Console, go to *Applications \> Applications*.
    2. Click *Create App Integration*.
    3. To create a SAML integration, select "SAML 2.0" as the *Sign-on method*.
    4. Click *Next*.

2. Configure the general settings:

   **App name**

   The name of your application. Fill in “DataMiner” (or some other preferred name).

   **App logo**

   Optional logo to be linked to your application.

   - Format: PNG, JPG or GIF
   - Max. size: 1 MB
   - Min. resolution: 420 x 120 pixels
    
   > [!TIP]
   > It is recommended to use a PNG image with a transparent background and a landscape orientation.

3. Configure the SAML settings:

    **Single sign on URL**

    The location where the SAML assertion is sent with a POST operation.

    - In this box, enter e.g. ``https://dataminer.example.com/root``.
    - Select the following checkboxes:
    
        - *Use this for Recipient URL and Destination URL*
        - *Allow this app to request other SSO URLs*
        
    - Enter the following additional URLs:
    
        - ``https://dataminer.example.com/login``
        - ``https://dataminer.example.com/dashboard``
        - ``https://dataminer.example.com/monitoring``
        - ``https://dataminer.example.com/jobs``
        - ``https://dataminer.example.com/ticketing``
        
    **Audience URI**

    The intended audience of the SAML assertion.

    In this box, enter ``https://dataminer.example.com/root``.

    **Name ID format**

    The username format you are sending in the SAML Response.

    Select "EmailAddress".

    **Application username**

    The default value to use for the username with the application.

    Select "Email".

## Error messages

### General errors

Object reference not set to an instance of an object.

- Application: Cube
- Cause: Incorrect or unexpected data in *spMetadata.xml*.

Cannot connect to the DMA; exception trapped: Failed getting the user info (empty response).

- Application: Web apps
- Cause: Incorrect or unexpected data in *spMetadata.xml*.

Expected one and only one default assertion consumer service endpoint.

- Application: Web apps
- Cause: In *spMetadata.xml*, none of the Assertion Consumer Service URLs are marked as the default URL. Typically, the /root URL is marked as the default URL.

Assertion consumer service \<URL> was not found.

- Application: Web apps
- Cause: The Assertion Consumer Service URL is spelled incorrectly or cannot be found in *spMetadata.xml*.

### Azure AD errors

AADSTS50011: The reply URL specified in the request does not match the reply URLs configured for the application: '\<ID>'.

- Application: Cube
- Cause: The URL marked as default URL is either missing or spelled differently in the app registration form.

AADSTS50011: The reply URL specified in the request does not match the reply URLs configured for the application: '\<ID>'.

- Application: Web apps
- Cause: The reply URL of a specific web app is either missing or spelled differently in the app registration form.

AADSTS500113: No reply address is registered for the application.

- Application: Web apps
- Cause: No reply URL is specified in the app registration form.

AADSTS650056: Misconfigured application. This could be due to one of the following: the client has not listed any permissions for 'AAD Graph' in the requested permissions in the client's application registration. Or, the admin has not consented in the tenant. Or, check the application identifier in the request to ensure it matches the configured client application identifier. Or, check the certificate in the request to ensure it's valid. Please contact your admin to fix the configuration or consent on behalf of the tenant. Client app ID: \<ID>.

- Cause: The required API permissions are missing in the app registration form.

AADSTS700016: Application with identifier '\<ID>' was not found in the directory '\<ID>'. This can happen if the application has not been installed by the administrator of the tenant or consented to by any user in the tenant. You may have sent your authentication request to the wrong tenant.

- Cause: Entity ID incorrect or not found.
