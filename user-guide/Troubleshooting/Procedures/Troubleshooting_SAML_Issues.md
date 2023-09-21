---
uid: Troubleshooting_SAML_Issues
---

# Troubleshooting SAML issues

When dealing with SAML-related issues, follow the steps listed on this page and utilize the provided tools to diagnose and resolve problems effectively. This guide outlines key troubleshooting steps and relevant tools to assist you throughout the process.

## Logs to check

When you encounter SAML issues, investigate the logs detailed below, in the specified order:

1. SLSAML.txt

1. [SLNet.txt](xref:DataMiner_processes#slnet): *C:\Skyline DataMiner\logging\SLNet.txt*

1. [Cube logging](xref:Cube_logging): *DataMiner Cube > Apps > System Center > Logging > cube*

1. [SLDataMiner.txt](xref:DataMiner_processes#sldataminer): *C:\Skyline DataMiner\logging\SLDataMiner.txt*

## Troubleshooting

> [!IMPORTANT]
> Before proceeding with any troubleshooting procedures, we highly recommend reading [Configuring external authentication via an identity provider using SAML](xref:Configuring_external_authentication_via_an_identity_provider_using_SAML).

This troubleshooting section addresses the following common SAML issues:

- [Partial setup](#partial-setup)

- [SAML authentication issues in Cube/online](#saml-authentication-issues-in-cubeonline)

- [Missing or incorrect attribute statements](#missing-or-incorrect-attribute-statements)

- [Other frequent issues](#other-frequent-issues)

### Partial setup

Partial setups are not compatible with SAML. Ensure that all settings are correctly configured for both DataMiner and the identity provider (IDP) before attempting to log in. See [Configuring external authentication via an identity provider using SAML](xref:Configuring_external_authentication_via_an_identity_provider_using_SAML).

### SAML authentication issues in Cube/online

You may encounter an issue where the expected redirection to the identity provider's login page does not occur when trying to log into your DMA via the web using external authentication through SAML. This issue can also manifest in Cube, where the SAML login window fails to appear.

#### The password field is filled in

If the password field is already filled in, leave it empty. Local logon attempts take precedence over external authentication.

#### DataMiner fails to connect to the IDP

DataMiner may face difficulties connecting to the identity provider due to various reasons:

- An incorrect ipMetadata URL in the *Dataminer.xml* file (when connecting through a URL)

- Improperly formatted *ipMetadata.xml* file (when using a local file)

  Resolution:

  - Ensure that the *ipMetadata.xml* file is correctly formatted, using tools like [Notepad++](https://notepad-plus-plus.org/downloads/) with an XML plugin. Missing `<?xml version="1.0" encoding="utf-8"?>` headers often lead to namespace issues.

  - Be cautious with XML syntax restrictions, especially the use of "&," which should be replaced with `&amp;`.

#### Using SAML together with a proxy

When using SAML with a proxy, make these configurations to avoid authentication issues:

- For 32-bit processes, execute the following command: `netsh winhttp set proxy proxy-server="<ip>:<port>" bypass-list="localhost"`

- In *SLnet.exe.config*, add the following input under `<configuration>.<System.net>`:

  ```xml
  <defaultProxy>
    <proxy
     proxyaddress=[proxy address]
     bypassonlocal="true"
   />
  ```

  Replace placeholders with the correct IP addresses, ports, and addresses.

### Missing or incorrect attribute statements

The SAML attribute names must always match those in the IDP and the *DataMiner.xml* file.

1. Go to the *C:\Skyline DataMiner* folder and open the *DataMiner.xml* file.

1. Verify that the `<ExternalAuthentication>` tag is configured correctly, and the tag name for your attribute matches the definition.

   For example, if the claim name is "email," your *Dataminer.xml* emailClaim tag should be `<EmailClaim>email</EmailClaim>`.

1. If issues persist, use the *SAML-tracer* tool, a browser extension that captures SAML traffic.

   1. In the Chrome web browser, add the [SAML-tracer extension](https://chrome.google.com/webstore/detail/saml-tracer/mpdajninpobndbfcldcmbpnnbhibjmch).

   1. Go to `http(s)://[DMA name]/monitoring/`.

   1. Click any received SAML response marked with an orange bubble labeled "SAML". Select this from the list and click *SAML* in the bottom window. Compare attribute names in the response to those in the IDP and the *Dataminer.xml* file.

### Other frequent issues

Here are some other common SAML-related issues:

- **Duplicate users**: Ensure there are no duplicate users, and each email address in the *security.xml* file is unique.

- **Groups in DataMiner**: Verify that groups exist in DataMiner before attempting to add users to them. This is necessary for setups using a separate claim for groups or a default group.

- **Username format**:

  - Ensure that the username is always an email address.

  - In Azure setups, missing email field values can cause problems, even though the default username is an email.

  - For other IDPs, configure DataMiner to use the correct claim, as outlined in the PreferredEmailClaim documentation.
