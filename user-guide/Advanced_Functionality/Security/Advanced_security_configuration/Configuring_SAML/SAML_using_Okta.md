---
uid: SAML_using_Okta
---

# Configuring SAML with Okta as the identity provider

> [!IMPORTANT]
> We strongly recommend that you upgrade to DataMiner 10.3.0 or 10.3.2 to use this feature. While Okta is supported from DataMiner 10.1.11 onwards, a software issue may make it impossible for users to log in with Okta prior to DataMiner 10.3.0/10.3.2.

One of the identity providers that is supported for external authentication via SAML is Okta.

There are two ways to configure this setup: with or without group claims. If group claims are used, when a user logs in for the first time, they will be added to an existing group that exists both in Okta and in DataMiner. If no group claims are used, any user that logs in for the first time will be added to one default security group, which you will need to configure during the procedure detailed below. Both possibilities are detailed below.

> [!NOTE]
> When Okta is used, automatic user creation must be enabled. It is currently not possible to import users and groups from Okta. As an alternative, you can add [local users](xref:User_management#local-users) or [domain users](xref:User_management#user-directories) in DataMiner, and then you can have Okta authenticate these users by following the guide below, except that you omit the *AutomaticUserCreation* tag in *DataMiner.xml*.

1. Launch Okta's App Integration Wizard.

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
     > We recommend using a PNG image with a transparent background and a landscape orientation.

1. Configure the Okta SAML settings:

   - **Single sign on URL**: The location where the SAML assertion is sent with a POST operation.

     - In this box, enter IP address or the DNS name of your DataMiner System, followed by `/root/`, e.g. ``https://dataminer.example.com/root/``.

     - Select the following checkboxes:

       - *Use this for Recipient URL and Destination URL*

       - *Allow this app to request other SSO URLs*

     - Open *Show Advanced Settings* and enter the following additional URLs to *Other Requestable SSO URLs* (replacing `dataminer.example.com` with the actual IP address or DNS name of your DMS):

       From DataMiner 10.3.5 onwards:

       - ``https://dataminer.example.com/API/``

       Older DataMiner versions:

       - ``https://dataminer.example.com/root/``

       - ``https://dataminer.example.com/API/``

       - ``https://dataminer.example.com/dashboard/``

       - ``https://dataminer.example.com/monitoring/``

       - ``https://dataminer.example.com/jobs/``

       - ``https://dataminer.example.com/ticketing/``

       If the DMA is connected to dataminer.services, also add the following URLs, replacing `<dms-dns-name>` with the DNS name of the DataMiner System and `<organization-name>` with the name of the organization

        - `https://<dms-dns-name>-<organization-name>.on.dataminer.services/API/`

        - `https://<dms-dns-name>-<organization-name>.on.dataminer.services/account-linking`

        - `https://<dms-dns-name>-<organization-name>.on.dataminer.services/account-linking/`

       > [!NOTE]
       > The indexes here should be the same as the indexes in `C:\Skyline DataMiner\okta-sp-metadata.xml`, which you will create later in this procedure.

       > [!TIP]
       > See also: [Additional configuration for systems connected to dataminer.services](xref:SAML_config_to_connect_to_cloud)

   - **Audience URI (SP Entity ID)**: The intended audience of the SAML assertion.

     In this box, enter the IP address or the DNS name of your DataMiner System, e.g. ``https://dataminer.example.com/``.

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

1. In *DataMiner.xml*, configure the *\<ExternalAuthentication>* tag as illustrated in the example below:

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

   For a DMA connected to dataminer.services, add the three following additional bindings within the `<md:SPSSODescriptor>` element:

   ```xml
     <md:SPSSODescriptor AuthnRequestsSigned="false" WantAssertionsSigned="true" protocolSupportEnumeration="urn:oasis:names:tc:SAML:2.0:protocol">
       ...
       <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://<dms-dns-name>-<organization-name>.on.dataminer.services/API/" index="1" isDefault="true"/>
       <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://<dms-dns-name>-<organization-name>.on.dataminer.services/account-linking" index="2" isDefault="false"/>
       <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://<dms-dns-name>-<organization-name>.on.dataminer.services/account-linking/" index="3" isDefault="false"/>
     </md:SPSSODescriptor>
     ```

1. Restart DataMiner.
