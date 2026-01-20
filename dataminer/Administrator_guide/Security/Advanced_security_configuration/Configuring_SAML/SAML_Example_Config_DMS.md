---
uid: SAML_Example_Config_DMS
---

# Example setup - DMS with Failover pair

This example illustrates how you can configure SAML with Microsoft Entra ID as identity provider for a complex DataMiner System that includes [Failover pairs](xref:About_DMA_Failover). This example will help make the information from the [general procedure](xref:SAML_using_Entra_ID) more concrete and will point out what you especially need to watch out for.

The DataMiner System in this example consists of two regular DataMiner Agents and a Failover pair, all SAML-enabled. All except one Agent are connected to dataminer.services. The example Agents are called *FOMain*, *FOBackup*, *CloudAgent*, and *RegularAgent*.

*FOShared* is used as the shared Failover hostname. However, if you have a Failover setup based on virtual IP, you should use the virtual IP instead.

## DataMiner.xml

For all Agents in the cluster, the *DataMiner.xml* file should have the same configuration:

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
> This configuration must be exactly the same for all Agents in a cluster. Mixing different types of configuration across Agents (e.g. `Groups claims="true"` for one Agent and `Groups claims="false"` for another) will cause problems with user access.

## Reply URLs at the identity provider side

The identity provider needs a complete list of all reply URLs that will be used in the cluster, which means at least one URL per Agent. Because part of the example cluster is connected to dataminer.services, the three standard reply URLs for this are needed as well. The identity provider side config will look like this:

- ``https://FOShared.example.com/API/``
- ``https://CloudAgent.example.com/API/``
- ``https://RegularAgent.example.com/API/``
- ``https://<dms-dns-name>-<organization-name>.on.dataminer.services/API/``
- ``https://<dms-dns-name>-<organization-name>.on.dataminer.services/account-linking``
- ``https://<dms-dns-name>-<organization-name>.on.dataminer.services/account-linking/``

## spMetadata.xml

This section details the differences in the *spMetadata.xml* file across the cluster. On each Agent, the file only needs to have the URLs defined that are needed for the Agent itself.

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
> The index for the reply URLs in the *spMetadata.xml* file will be different compared to the index on the identity provider. This will not cause issues but it still needs to be present in the XML files to have a correct metadata document.
