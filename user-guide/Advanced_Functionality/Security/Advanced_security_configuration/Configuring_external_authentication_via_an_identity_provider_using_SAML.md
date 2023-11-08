---
uid: Configuring_external_authentication_via_an_identity_provider_using_SAML
keywords: Azure AD, AzureAD, Microsoft Entra ID, SAML, Okta, Azure B2C
---

# Configuring SAML settings

If you want to configure your DataMiner System to use external authentication, the best way to do so is using SAML (Security Assertion Markup Language). This is supported from DataMiner 9.6.11 onwards.

If users try to log in to the DMA using external authentication via SAML, they will be redirected to a login page of the identity provider. That page will authenticate them and return a SAML response, which DataMiner will use to either grant or deny access.

The following identity providers are supported:

- [Microsoft Entra ID](xref:SAML_using_Entra_ID) (formerly Azure AD)
- [Azure B2C](xref:SAML_using_Azure_B2C)
- [Okta](xref:SAML_using_Okta)

Please note the following:

- Any DataMiner Agent configured for SAML external authentication must be **accessible via [HTTPS**](xref:Setting_up_HTTPS_on_a_DMA).

- DataMiner integrates with **identity providers using version 2.0 of the SAML protocol**. Compatibility with older SAML versions is not supported. In addition, the identity provider must support **redirect binding** for communication between the service provider (i.e. DataMiner) and the identity provider. Most SAML identity providers support redirect binding by default.

- DataMiner uses service provider-initiated **Single Sign-On (SSO)** through redirect binding. It does not support the use of POST or SOAP binding for requests. However, standard POST binding is used for responses.

  > [!TIP]
  > For a comprehensive understanding of the SAML process, including the encoding and encryption guidelines that DataMiner follows, refer to the official SAML Documentation: [SAML Technical Overview](http://docs.oasis-open.org/security/saml/Post2.0/sstc-saml-tech-overview-2.0-cd-02.html#5.1.2.SP-Initiated%20SSO:%20%20Redirect/POST%20Bindings|outline).

- To use external authentication for DataMiner **Low-Code Apps**, you must use DataMiner **10.3.5 or higher**.

- For **DataMiner Cube**, it is possible to bypass the external authentication provider by entering an explicit username/password combination. However, prior to DataMiner 10.1.11/10.2.0, this is only possible for the Administrator user.

- For the **Web apps**, when external authentication is enabled, it is no longer possible to log in with local accounts. As a workaround, since you do not need to configure external authentication on every DMA of the cluster, you can log in to the web apps using external authentication on one DMA and log in using a local account on another DMA.

> [!TIP]
> See also: [Troubleshooting SAML issues](xref:Troubleshooting_SAML_Issues)
