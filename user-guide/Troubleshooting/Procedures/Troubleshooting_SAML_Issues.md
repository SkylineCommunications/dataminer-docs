---
uid: Troubleshooting_SAML_Issues
---

# Troubleshooting SAML issues

When dealing with SAML-related issues, follow the steps listed on this page and utilize the provided tools to diagnose and resolve problems effectively. This guide outlines key troubleshooting steps and relevant tools to assist you throughout the process.

## Logs to check

When you encounter SAML issues, investigate the logs detailed below, in the specified order:

1. SLSAML.txt: `C:\Skyline DataMiner\logging\SLSAML.txt`

1. [SLNet.txt](xref:DataMiner_processes#slnet): `C:\Skyline DataMiner\logging\SLNet.txt`

1. [Cube logging](xref:Cube_logging): *DataMiner Cube > Apps > System Center > Logging > cube*

1. [SLDataMiner.txt](xref:DataMiner_processes#sldataminer): `C:\Skyline DataMiner\logging\SLDataMiner.txt`

## Troubleshooting

> [!IMPORTANT]
> Before proceeding with any troubleshooting procedures, we highly recommend reading [Configuring external authentication via an identity provider using SAML](xref:Configuring_external_authentication_via_an_identity_provider_using_SAML).

This troubleshooting section addresses the following common SAML issues:

- [Partial setup](#partial-setup)

- [SAML authentication issues in Cube/online](#saml-authentication-issues-in-cubeonline)

- [Missing or incorrect attribute statements](#missing-or-incorrect-attribute-statements)

- [Other frequent issues](#other-frequent-issues)

### Partial setup

Partial setups are not compatible with SAML. Ensure that all settings are correctly configured for both DataMiner and the identity provider before attempting to log in. See [Configuring external authentication via an identity provider using SAML](xref:Configuring_external_authentication_via_an_identity_provider_using_SAML).

### SAML authentication issues in Cube/online

You may encounter an issue where the expected redirection to the identity provider's login page does not occur when you try to log into your DMA via the web using external authentication through SAML. This issue can also manifest in Cube, where the SAML login window fails to appear.

If you are accessing your DMA via the web, check if the user credential boxes are visible during the login process. If they are visible, this suggests the external authentication is not in use.

If the external authentication is working properly, you will get the option to log in via identity provider.

![Logging in via identity provider](~/user-guide/images/Logging_In_SAML.png)<br/>*DataMiner version 10.3.10*

#### The password field is filled in

If the password field is already filled in, leave it empty. Local logon attempts take precedence over external authentication.

#### DataMiner fails to connect to the identity provider

DataMiner may face difficulties connecting to the identity provider because of various reasons:

- An incorrect ipMetadata URL in the *DataMiner.xml* file (when connecting through a URL)

- Improperly formatted *ipMetadata.xml* file (when a local file is used)

  Resolution:

  - Ensure that the *ipMetadata.xml* file is correctly formatted, using tools like [Notepad++](https://notepad-plus-plus.org/downloads/) with an XML plugin. Missing `<?xml version="1.0" encoding="utf-8"?>` headers often lead to namespace issues.

  - Be cautious with XML syntax restrictions, especially the use of "&," which should be replaced with `&amp;`.

#### Using SAML together with a proxy

When using SAML with a proxy, use the following configuration to avoid authentication issues:

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

The SAML attribute names must always match those in the identity provider and the *DataMiner.xml* file.

1. Go to the *C:\Skyline DataMiner* folder and open the *DataMiner.xml* file.

1. Verify that the `<ExternalAuthentication>` tag is configured correctly and the tag name for your attribute matches the definition.

   For example, if the claim name is "email," your *DataMiner.xml* emailClaim tag should be `<EmailClaim>email</EmailClaim>`.

1. If issues persist, use the *SAML-tracer* tool, a browser extension that captures SAML traffic.

   1. In your browser, add the SAML-tracer extension ([Chrome](https://chrome.google.com/webstore/detail/saml-tracer/mpdajninpobndbfcldcmbpnnbhibjmch), [Firefox](https://addons.mozilla.org/nl/firefox/addon/saml-tracer/)).

   1. Go to `http(s)://[DMA name]/`.

   1. Click the puzzle icon in the top-right corner of your browser and select *SAML-tracer* from the list of available extensions.

   1. Click any received SAML response marked with an orange bubble labeled "SAML".

      ![SAML-tracer](~/user-guide/images/SAML_Tracer.png)

   1. In the pane on the bottom, select *SAML*. Now compare the attribute names in the response to those in the identity provider and the *DataMiner.xml* file.

      ![SAML-tracer tabs](~/user-guide/images/SAML_Tracer_Tabs.png)

### Other frequent issues

Here are some other common SAML-related issues:

- **Duplicate users**: Ensure there are no duplicate users and each email address in the *security.xml* file is unique.

- **Groups in DataMiner**: Verify that groups exist in DataMiner before attempting to add users to them. This is necessary for setups using a separate claim for groups or a default group.

- **Username format**:

  - Ensure that the username is always an email address.

  - In [Azure setups](xref:Configuring_external_authentication_via_an_identity_provider_using_SAML#identity-providers), missing email field values can cause problems, even though the default username is an email.
