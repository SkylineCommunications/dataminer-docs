---
uid: SAML_config_to_connect_to_cloud
keywords: cloud connection
---

# Additional configuration for systems connected to dataminer.services

When you connect a DataMiner System for which SAML has already been configured to dataminer.services, three URLs need to be added to the identity provider configuration and the DataMiner metadata file:

1. Update the identity provider configuration:

   - If you are using **Microsoft Entra ID** or **Azure B2C**, update the configuration of your DataMiner enterprise application:

     1. Navigate to ``portal.azure.com`` and log in.

     1. In the search box at the top, enter *Enterprise applications* to go to the Enterprise Applications page.

     1. Select the application that was created for DataMiner.

     1. In the pane on the left on your DataMiner application page, click *Single sign-on*.

     1. Next to *Basic SAML Configuration*, click *Edit*.

     1. Under *Reply URL*, add the following URLs, replacing `<dms-dns-name>` with the DNS name in the *spMetadata.xml* file and `<organization-name>` with the name of the organization:

        - `https://<dms-dns-name>-<organization-name>.on.dataminer.services/API/`
        - `https://<dms-dns-name>-<organization-name>.on.dataminer.services/account-linking`
        - `https://<dms-dns-name>-<organization-name>.on.dataminer.services/account-linking/`

        > [!NOTE]
        > Note the trailing "/".

        Example of remote access URL: `https://dataminer-skyline.on.dataminer.services`

        In this example, the DMS DNS name is "dataminer" and the organization name is "skyline".

     1. In the top-left corner, click *Save*.

   - If you are using **Okta**, add the three URLs mentioned above to *Other Requestable SSO URLs*. See [Configuring SAML with Okta](xref:SAML_using_Okta).

1. Update your DataMiner metadata file:

   1. Open the file *spMetadata.xml*. Usually, this is located in the `C:\Skyline DataMiner` folder.

   1. Add the new URLs to this file as illustrated below.

      In the example below, the remote access URL is `https://dataminer-skyline.on.dataminer.services`:

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

> [!IMPORTANT]
> Make sure SAML is configured on all DMAs in your cluster that are running the CloudGateway DxM or that are part of a [DMZ-configured CloudGateway setup](xref:Connect_to_cloud_with_DMZ). If some of these DMAs use SAML but others do not, this could cause unpredictable or unwanted behavior.
