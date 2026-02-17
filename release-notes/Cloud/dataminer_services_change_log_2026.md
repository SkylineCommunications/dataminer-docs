---
uid: dataminer_services_change_log_2026
---

# dataminer.services change log - 2026

The dataminer.services platform gets updated continuously. This change log can help you trace when specific features and changes have become available in 2026.

> [!NOTE]
> Many features on dataminer.services are dependent on DxMs. You can find the change logs for these under [DxM release notes](xref:DxM_RNs_index).

### 17 February 2026 - Enhancement - Admin - Confirmation email for ticket creation

When creating a support ticket via the Admin app, a confirmation email is now sent to the user.  
A sharepoint folder is also created for the ticket when possible.

### 16 February 2026 - Fix - Home - Account linking with a SAML DMS

On the dataminer.services home page, trying to link a dataminer.services account with your DMS using SAML could sometimes load infinitely. This behavior is now fixed.

### 16 February 2026 - Fix - Home - Organization creation error

On the dataminer.services home page, when the creation of a new organization failed, the error box showed an [Object Object] error instead of the actual error. This has been fixed.

### 9 February 2025 - New feature - Admin - Organization deletion

Organization owners can now delete an organization via the settings page in the Admin app.

> [!NOTE]
> Before an organization can be deleted, all DataMiner Systems for the organization have to be removed; otherwise, the delete option is disabled.

### 5 February 2025 - Enhancement - Admin - Billing page update

In the Admin app, the Billing page now shows the current cost for an organization.

In addition, opening a subscription panel will now update the URL so it can be shared with other users.

### 2 February 2026 - New feature - Admin - Billing page

In the Admin app, a new *Billing* page is now available, which will serve as a dedicated space for organization owners and admins to monitor and manage their organization’s spending. The page provides access to credit history, monthly bills, and subscription management, including any available discounts.

### 29 January 2026 - Enhancement - dataminer.services - Improved DaaS deployment credit validation

You will now be notified earlier during DaaS deployment if your organization has insufficient credits, allowing you to top up before proceeding with the deployment.

### 29 January 2026 - Enhancement - Admin - Usage page simplification

To simplify the Usage page, the totals and credits columns have been removed.

Note that a new page is being developed that will restore usage breakdowns per system, feature, and service without credit costs.

### 29 January 2026 - Fix - Admin - Not possible to export audit log

An issue has been resolved that prevented the audit log from being exported.

### 28 January 2026 - Enhancement - Billing - Automation Actions, Connectors, and Managed Objects usage billing

Starting from February 2026, automatic monthly billing will be implemented for Automation Actions, Connectors, and Managed Objects. On the 5th day of each month, the expended DataMiner credits for the previous month's usage will be subtracted from the organization's balance. This billing will not take effect retroactively. See [Usage-based services – Metering units](xref:Pricing_Usage_based_service#metering-units) for more details. Note that the Community Edition base allowance has also been updated.

Perpetual-licensed systems will have usage-based billing only for Automation Object Modeling, Collaboration, and Storage as a Service.

In case an organization does not have sufficient DataMiner credits, their balance will go negative, and it will need to be topped up as soon as possible. Organizations with a negative balance will not be able to deploy new DaaS systems.

### 8 January 2026 - Enhancement - Billing - Dashboard Sharing & Unmanaged Objects usage billing

Starting from January 2026, automatic monthly billing will be implemented for Dashboard Sharing & Unmanaged Objects. On the 5th day of each month, the expended DataMiner credits for the previous month's usage will be subtracted from the organization's balance. This billing will not take effect retroactively. See [Usage-based services – Metering units](xref:Pricing_Usage_based_service#metering-units) for more details.

In case an organization does not have sufficient DataMiner credits, their balance will go negative, and it will need to be topped up as soon as possible. Organizations with a negative balance will not be able to deploy new DaaS systems.

### 8 January 2026 - Enhancement - Admin - Update time range selectors

On the Deployments and Audit pages of the Admin app, the time range components have been replaced with more modern selectors.

### 8 January 2026 - New feature - Catalog - Test package support

In the Catalog app, support has been added for a new type of item: "Test package". This type can be found within the *Productivity & Utility* category. Test packages follow a different flow from other Catalog types. These packages cannot be deployed directly. Instead, their ID is copied into the QAOps application, where the download and execution will be handled.

### 8 January 2026 - Fix - dataminer.services - DaaS deployments

When deploying a DaaS system on dataminer.services, users were able to keep clicking the *Deploy* button. This action should now correctly be disabled when a deployment has been started.

### 8 January 2026 - Fix - Admin - Remove node button

On the *DxMs* page of the Admin app, the option to remove a node was previously visible to all users. It is now only available to users with the Owner or Admin role for the DataMiner System.
