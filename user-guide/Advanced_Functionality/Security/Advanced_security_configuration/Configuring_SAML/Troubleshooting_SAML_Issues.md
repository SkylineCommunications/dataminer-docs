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
> Before you proceed with any troubleshooting procedures, we highly recommend that you read [Configuring SAML settings](xref:Configuring_external_authentication_via_an_identity_provider_using_SAML).

This troubleshooting section addresses the following common SAML issues:

- [Partial setup](#partial-setup)

- [SAML authentication issues in Cube/online](#saml-authentication-issues-in-cubeonline)

- [Missing or incorrect attribute statements](#missing-or-incorrect-attribute-statements)

- [Other frequent issues](#other-frequent-issues)

- [Error messages](#error-messages)

### Partial setup

Partial setups are not compatible with SAML. Ensure that all settings are correctly configured for both DataMiner and the identity provider before attempting to log in. See [Configuring SAML settings](xref:Configuring_external_authentication_via_an_identity_provider_using_SAML).

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

1. If issues persist, use the *SAML-tracer* tool, a browser extension available for Google Chrome and Firefox, designed to capture SAML traffic.

   1. Add the SAML-tracer extension to your chosen web browser:

      - For Google Chrome, visit the [Chrome Web Store](https://chrome.google.com/webstore/detail/saml-tracer/mpdajninpobndbfcldcmbpnnbhibjmch).

      - For Firefox, visit the [Firefox Add-ons page](https://addons.mozilla.org/nl/firefox/addon/saml-tracer/).

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

  - If [Microsoft Entra ID](xref:SAML_using_Entra_ID) is used as the identity provider for external authentication, missing email field values can cause problems, even though the default username is an email.

### Error messages

#### General errors

Object reference not set to an instance of an object.

- Application: Cube
- Cause: Incorrect or unexpected data in *spMetadata.xml*.

Failed to build External Authentication for SAML. System.ArgumentException: An entry with the same key already exists.

- Application: Cube/Alarm Console
- Cause: In *spMetadata.xml*, the index attribute per AssertionConsumerService endpoint must be unique. Make sure all index values are unique.

Cannot connect to the DMA; exception trapped: Failed getting the user info (empty response).

- Application: Web apps
- Cause: Incorrect or unexpected data in *spMetadata.xml*.

Expected one and only one default assertion consumer service endpoint.

- Application: Web apps
- Cause: In *spMetadata.xml*, none of the Assertion Consumer Service URLs are marked as the default URL. Typically, the /root URL is marked as the default URL.

Assertion consumer service \<URL> was not found.

- Application: Web apps
- Cause: The Assertion Consumer Service URL is spelled incorrectly or cannot be found in *spMetadata.xml*.

### Entra ID (formerly Azure AD) errors

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
