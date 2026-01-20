---
uid: SAML_Example_Config_DMS
---

# Example config for SAML agents in a cluster

This example illustrates how you can configure SAML with Microsoft Entra ID as identity provider for a complex DataMiner System that includes multiple Failover pairs. As the configuration for such a setup can be quite complex, this example will help make the information from the general procedure more concrete and will point out what you especially need to watch out for.

In this example we'll show a cluster of 2 regular agents and a Failover pair, all SAML enabled. All except one agent are cloud connected. Our example agents will be called FOMain, FOBackup, CloudAgent and RegularAgent. We'll use FOShared as our shared Failover hostname, replace this with the VIP if using that instead.

## DataMiner.xml

All agents in the cluster's DataMiner.xml should have the same config

   ```xml
   <DataMiner ...>
     ...
     <ExternalAuthentication
       type="SAML"
       ipMetadata="[Path/URL of the identity provider’s metadata file]"
       spMetadata="[Path/URL of DataMiner's metadata file]"
       timeout="300">
       <AutomaticUserCreation enabled="true">
         <EmailClaim>http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress</EmailClaim>
         <Givenname>http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname</Givenname>
         <Surname>http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname</Surname>
         <Groups claims="true">http://schemas.microsoft.com/ws/2008/06/identity/claims/groups</Groups>
       </AutomaticUserCreation>
     </ExternalAuthentication>
     ...
   </DataMiner>
   ```
   
   > [!IMPORTANT]
   > Don't mix Groups claims true and false in the cluster as this will lead to problems with >  user access. This config needs to be the exact same across the cluster for SAML agents.

## Reply URLs at the Identity Provider side

The IDP needs a complete list of all Reply URLs that will be used in the cluster. This means at least one URL per agent and since part of our cluster is cloud connected, we need the 3 standard Reply URLs for this as well. Our IDP side config would look like this:

   - ``https://FOShared.example.com/API/``
   - ``https://CloudAgent.example.com/API/``
   - ``https://RegularAgent.example.com/API/``
   - ``https://<dms-dns-name>-<organization-name>.on.dataminer.services/API/``
   - ``https://<dms-dns-name>-<organization-name>.on.dataminer.services/account-linking``
   - ``https://<dms-dns-name>-<organization-name>.on.dataminer.services/account-linking/``

## spMetadata.xml 

In this section we'll go over the differences in the spMetadata.xml file across the cluster. The basic principle here is that the file only needs the URLs defined that are needed for the agent itself.

### FOMain and FOBackup

     ```xml
     <?xml version="1.0" encoding="UTF-8"?>
     <md:EntityDescriptor xmlns:md="urn:oasis:names:tc:SAML:2.0:metadata" xmlns:ds="http://www.w3.org/2000/09/xmldsig#" entityID="[CLUSTERNAME]" validUntil="2050-01-04T10:00:00.000Z">
       <md:SPSSODescriptor AuthnRequestsSigned="false" WantAssertionsSigned="true" protocolSupportEnumeration="urn:oasis:names:tc:SAML:2.0:protocol">
         <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://FOShared.example.com/API/" index="0" isDefault="true"/>
         <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://<dms-dns-name>-<organization-name>.on.dataminer.services/API/" index="1" isDefault="false"/>
         <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://<dms-dns-name>-<organization-name>.on.dataminer.services/account-linking" index="2" isDefault="false"/>
         <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://<dms-dns-name>-<organization-name>.on.dataminer.services/account-linking/" index="3" isDefault="false"/>
       </md:SPSSODescriptor>
     </md:EntityDescriptor>
     ```

### CloudAgent

     ```xml
     <?xml version="1.0" encoding="UTF-8"?>
     <md:EntityDescriptor xmlns:md="urn:oasis:names:tc:SAML:2.0:metadata" xmlns:ds="http://www.w3.org/2000/09/xmldsig#" entityID="[CLUSTERNAME]" validUntil="2050-01-04T10:00:00.000Z">
       <md:SPSSODescriptor AuthnRequestsSigned="false" WantAssertionsSigned="true" protocolSupportEnumeration="urn:oasis:names:tc:SAML:2.0:protocol">
         <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://CloudAgent.example.com/API/" index="0" isDefault="true"/>
         <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://<dms-dns-name>-<organization-name>.on.dataminer.services/API/" index="1" isDefault="false"/>
         <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://<dms-dns-name>-<organization-name>.on.dataminer.services/account-linking" index="2" isDefault="false"/>
         <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://<dms-dns-name>-<organization-name>.on.dataminer.services/account-linking/" index="3" isDefault="false"/>
       </md:SPSSODescriptor>
     </md:EntityDescriptor>
     ```

### RegularAgent

     ```xml
     <?xml version="1.0" encoding="UTF-8"?>
     <md:EntityDescriptor xmlns:md="urn:oasis:names:tc:SAML:2.0:metadata" xmlns:ds="http://www.w3.org/2000/09/xmldsig#" entityID="[CLUSTERNAME]" validUntil="2050-01-04T10:00:00.000Z">
       <md:SPSSODescriptor AuthnRequestsSigned="false" WantAssertionsSigned="true" protocolSupportEnumeration="urn:oasis:names:tc:SAML:2.0:protocol">
         <md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://RegularAgent.example.com/API/" index="0" isDefault="true"/>
       </md:SPSSODescriptor>
     </md:EntityDescriptor>
     ```

   > [!NOTE]
   > The index for the reply URLs in the spmetadata file will be different compared to the index on the IDP. This won't cause issues but it still needs to be present in the xml files to have a correct metadata document.
   