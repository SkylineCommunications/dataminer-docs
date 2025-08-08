---
uid: SAML_using_Azure_B2C
---

# Configuring SAML with Azure B2C as identity provider

From DataMiner 10.2.6/10.3.0 onwards, DataMiner supports Azure B2C as an identity provider for external authentication via SAML.

To configure this:

1. Configure Azure B2C. See [Azure Active Directory B2C documentation | Microsoft Docs](https://docs.microsoft.com/en-us/azure/active-directory-b2c/).

1. Set up an Entra ID Enterprise application. You can do this in the same way as for [Entra ID](xref:SAML_using_Entra_ID#setting-up-a-microsoft-entra-id-enterprise-application).

1. Create a DataMiner metadata file. You can do this in the same way as for [Entra ID](xref:SAML_using_Entra_ID#creating-a-dataminer-metadata-file).

1. Configure policies for Azure B2C. See [Tutorial: Create user flows and custom policies in Azure Active Directory B2C | Microsoft Docs](https://docs.microsoft.com/en-us/azure/active-directory-b2c/tutorial-create-user-flows?pivots=b2c-custom-policy).

1. Get the metadata URL:

   1. In Azure, go to *App registrations*, select your app, and select *Overview* > *Endpoints*.

      ![App endpoints](~/dataminer/images/SAML_B2C_endpoints.png)

   1. Select the Azure AD B2C SAML metadata endpoint, e.g. `https://dataminerservices.b2clogin.com/dataminerservices.onmicrosoft.com/<policy-name>/Samlp/metadata`, and replace \<policy-name> with the name of the policy you created earlier.

1. Configure DataMiner to use external authentication. You can do this in the same way as for [Entra ID](xref:SAML_using_Entra_ID#configuring-dataminerxml-to-use-external-authentication).

   For the *ipMetadata* link, use the link created in the previous step.

1. Configure DataMiner to automatically create users from Azure B2C. You can do this in the same way as for [Entra ID](xref:SAML_using_Entra_ID#configuring-automatic-creation-of-users-authenticated-by-entra-id-using-saml).

   > [!NOTE]
   >
   > - If you use Azure B2C, users can only be provisioned automatically. Provisioning users by importing them is not possible.
   > - To create SAML users in DataMiner using Azure B2C, a domain is required in the usernames. For this reason, email addresses must be used as the usernames. If the default username of the identity provider is not a valid email address, add a `<PreferredLoginClaim>` element to the `<AutomaticUserCreation>` element in *DataMiner.xml* that refers to a claim containing a valid email address.
