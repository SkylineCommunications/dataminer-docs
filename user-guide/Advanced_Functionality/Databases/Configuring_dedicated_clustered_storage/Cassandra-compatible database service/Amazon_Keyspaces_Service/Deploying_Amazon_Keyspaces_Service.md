---
uid: Deploying_Amazon_Keyspaces_Service
---

# Deploying the Amazon Keyspaces Service

## Installing the Starfield certificate

For Amazon Keyspaces, the Starfield certificate must be present on the local Windows machine DataMiner is running on. To install the certificate, you will need to add it to the *Trusted Root Certification Authorities* section of the Windows certificate store:

1. Download the [sf-class2-root.crt certificate file](https://certs.secureserver.net/repository/sf-class2-root.crt).

1. To import the certificate to your machine, press WINDOWS + R and enter the `mmc` command.

    If necessary, confirm that you want to allow the app to make changes to the device. A Console window will be opened.

1. In the Console window, go to *File* > *Add/Remove Snap-in*.

1. In the *Available snap-ins* list, select *Certificates*, and click *Add >*.

1. Select *Computer account*, and click *Next*.

1. Make sure *Local computer* is selected, and click *Finish*.

1. Click *OK*.

1. In the *Console Root* tree view on the left, select the folder *Certificates (Local Computer)* > *Trusted Root Certification Authorities* > *Certificates*.

1. Right-click the *Certificates* folder you have just selected, and select *All Tasks* > *Import*.

1. Click *Next* until you can browse to the location of the certificate file.

1. Keep selecting *Next* or *Finish* until the certificate is successfully imported.

   You should now see the certificate listed as shown in the example screenshot below.

   ![Add Certificate](~/user-guide/images/aks_add_certificate.png)

## Generating credentials for Amazon Keyspaces

In the [Identity and Access Management (IAM) Service](https://console.aws.amazon.com/iam), you can generate new credentials that are used to access the Amazon Keyspaces service. Those credentials are then linked to the account that created them.

1. Log in with your AWS account and open the [IAM Service](https://console.aws.amazon.com/iam).

1. Go to *IAM* > *Users*.

   ![IAM](~/user-guide/images/Amazon_Keyspaces_IAM.png)

1. Search for the account that should have access.

   ![SearchUser](~/user-guide/images/Amazon_Keyspaces_SearchUser.png)

1. Verify that this account has full access to Amazon Keyspaces, i.e. the permission *AmazonKeyspacesFullAccess*.

   ![Permissions](~/user-guide/images/Amazon_Keyspaces_Permissions.png)

   If the permission is present, move to the next step.

   If the account does not have this permission, add it first:

   1. Select *Add permissions*.

      ![AddPermissions](~/user-guide/images/Amazon_Keyspaces_AddPermissions.png)

   1. Go to *Attach policies directly*.

   1. Search for *AmazonKeyspacesFullAccess*.

   1. Select the permission and click *Next*.

      ![AddKeyspacesPermission](~/user-guide/images/Amazon_Keyspaces_AddKeyspacesPermission.png)

1. To generate the credentials, go to the *Security credentials* tab.

   ![SecurityCredentials](~/user-guide/images/Amazon_Keyspaces_Security_Tab.png)

1. Scroll down to the Amazon Keyspaces part.

   ![AmazonKeyspacesSecurityCredentials](~/user-guide/images/Amazon_Keyspaces_Credentials.png)

1. Click *Generate credentials*.

   You can generate up to two sets of username-password credentials at a time, which can be deactivated or deleted at any time, separate from your AWS account.

## Connecting your DMS to your Amazon Keyspaces

To configure the connection to an Amazon Keyspaces database, configure the settings as detailed in [Amazon Keyspaces](xref:Configuring_the_database_settings_in_Cube#amazon-keyspaces).

> [!IMPORTANT]
> An Amazon Keyspaces database requires a separate indexing database.
>
> For information on how to configure an indexing database, see [Configuring an indexing database](xref:Indexing_Database).
