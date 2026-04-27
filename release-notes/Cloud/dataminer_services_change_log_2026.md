---
uid: dataminer_services_change_log_2026
---

# dataminer.services change log - 2026

The dataminer.services platform gets updated continuously. This change log can help you trace when specific features and changes have become available in 2026.

> [!NOTE]
> Many features on dataminer.services are dependent on DxMs. You can find the change logs for these under [DxM release notes](xref:DxM_RNs_index).

### 27 April 2026 - Fix - Admin - Audit - Change coordination service

Fixed an issue where audit was using an old coordination service that the sidebar also uses. This resulted in DMS destined for the audit page filter to also be shown in the sidebar of the admin app.

### 27 April 2026 - General - Generalize notifications & update styling

The notifications across apps have now been streamlined to have the same grammatical structure. The styling of the notifications has also been updated.

### 27 April 2026 - Home - Improving error geo-replication

In the home app, the geo-replication error was not shown when switching from a region with geo-replication available to a region that does not have geo-replication available.

### 27 April 2026 - Fix - Catalog - Custom Markdown parser now correctly shows alert blocks

In the catalog app, some messages would not show the first line due to an issue with the custom markdown parser. Now, all messages are fully visible.

### 27 April 2026 - Fix - Admin - DMS Overview - Nodes with the same DMA ID but no failover info are shown as failover pair

In the DMS overview of the admin app, nodes with same same DMA ID but no failover info would be displayed as failover pairs. This issue has been resolved.

### 27 April 2026 - Catalog - Cache catalog categories in sessionstorage

Catalog categories are now cached in session storage, this avoids an unnecessary webAPI call and loading animation in the UI.

### 27 April 2026 - Fix - Admin - Keys - A regenerated key is not correctly updated in the sidepanel

All info in the side panel is now updated when a new key (primary or secondary) is generated.

### 27 April 2026 - Fix - Admin - Organization deleted leaving admin in a blocking state

Deleting an organization would leave the admin app in an invalid state. Now, another available organization will be selected if possible, otherwise the user will be navigated to the home app.

### 27 April 2026 - Home - Updated geo-replicated error message

The geo-replicated storage error message on the home app has been updated.

### 27 April 2026 - Billing - Credit & discount rate overrides on organization level

Credit and discount rates can now be overridden on organization level.

### 27 April 2026 - Fix -Catalog - Make publishing state toggle and delete available for test packages

In the catalog app, the menu actions (delete, make private) where incorrectly not available for some packages.

### 27 April 2026 - Fix - Admin - Update delete dms description

The description above the delete DMS button now no longer mentions the admin role, since only the owner can delete the DMS.

### 27 April 2026 - Catalog - Indicate DMS name in Deployment result notification

In the catalog app notifacations related to deployments of catalog packages now include the DMS name.

### 27 April 2026 - Fix - Admin - Audit - Include all systems in filter regardless of access

On the Audit page of the Admin app, the DMS filter now includes all DMS regardless of access.

### 27 April 2026 - General - Updated some visible DCP terms into dataminer.services

References to DCP Keys around the app have been renamed to dataminer.services Keys for consistency.

### 27 April 2026 - Admin/Home - Refactor Delete DMS flow to prevent stale deleted systems

When deleting a DMS from home, it will now navigate in the current tab of the browser.
This will open the delete confirmation popup in Admin and, after deletion, navigate back to the home application.

### 27 April 2026 - Admin - Audit - Improved filtering

The checkbox filters on the Audit page of the Admin app has had a few improvements: 
- List of options is virtualized for better performance
- Select/deselect all button
- Show selected only toggle
- Filter box no longer shifts when selecting options

### 27 April 2026 - General - Align favicons

The favicons for all applications have been changed to the modern DataMiner logo.

### 27 April 2026 - Status page - Event types

On the status page, incidents are now shown as events, with possible event types (Incident and Maintenance) shown as a label in the event.

### 16 April 2026 - Fix - Admin - Bypass the NotFound errors for NodeInfo in favor of no node info message

In Admin on the DMS overview page, it could occur that both an info message and error message were shown when there were no available nodes for the system. This has been fixed by marking the NodeNotFound errors and bypassing them locally in the DMS Overview component.

### 16 April 2026 - Enhancement - Home - Track progress and results of corporate website

This change adds extra info (organization and coordination id) when an onboard_complete event is logged to Google analytics

### 16 April 2026 - Fix - Inputs - Password stays shown when pressing peak button and releasing mouse outside of button bounds

Fixed an issue where the password in a password input would stay visible when pressing the peek button and releasing the mouse outside the peek button.

### 16 April 2026 - Fix - Admin - Failed to fetch audit logs when (de)selecting initiator quickly

When quickly toggling the filter checkboxes on the audit page in Admin, an error could be shown.

### 13 April 2026 - Enhancement - Admin - Cleaner title and description input on Support page

On the Support page in the Admin app, titles and descriptions are now cleaned automatically when you type, paste, or drop text, so unsupported characters are removed immediately.

### 13 April 2026 - Fix - Marketplace - Authentication loop

An issue has been resolved where users could get stuck in an authentication loop when activating a subscription for DataMiner credits. This behavior has been fixed.

### 13 April 2026 - Enhancement - Admin - Improved grouping for adding a subscription

On the Add Subscription panel in the Admin app, service names are now shown instead of unit names to make it clearer which selection applies to which service.

Unit names have been moved into the input boxes.

### 13 April 2026 - Enhancement - dataminer.services - DaaS configuration options added to deployment flow

For users deploying a DaaS system, it is now possible to select the DaaS region and STaaS region, as well as to configure geo-replication, directly from the dataminer.services deployment flow.

### 13 April 2026 - Enhancement - Admin - Documentation link added to Add Subscription panel

On the Add Subscription panel in the Admin app, a new section with a link to the metering documentation is now available to help guide users with creating their subscription.

### 13 April 2026 - Enhancement - Admin - DMS subscription indicator added

On the Billing page in the Admin app, the subscription detail pop-up box now indicates if the subscription is scoped to a specific DataMiner System.

### 13 April 2026 - Fix - dataminer.services - DaaS deployment in new organization appeared to fail while actually succeeding

On dataminer.services, creating a DaaS system in a new organization while an existing organization was selected could cause a faulty redirect, giving the impression that the deployment failed while the system had actually been successfully deployed in the new organization.

### 13 April 2026 - Fix - Admin - Error notifications on organization switch

In the Admin app, changing the selected organization while on certain pages could result in notifications about failed calls. This issue has been resolved.

### 13 April 2026 - Fix - Admin - DMS pages not expanding on navigation

In the Admin app, navigating to a page within a collapsed DataMiner System section did not auto-expand that section as it should. This behavior has been fixed.

### 13 April 2026 - Fix - Catalog - Deploy buttons incorrectly disabled on Empower page

On the Empower page in the Catalog app, it could occur that "Deploy" buttons were incorrectly disabled. This behavior has been fixed.

### 13 April 2026 - Enhancement - Admin - UOSA page filter support

On the Support page of the Admin app, you can now filter support tickets by time range and optionally include closed tickets.

Filters are applied server-side, improving page performance.

### 13 April 2026 - Fix - Admin - UOSA page Customer field showed assignee instead of customer

On the Support page of the Admin app, the *Customer* field incorrectly displayed the name of the assignee instead of the customer name. This issue has been resolved.

### 13 April 2026 - Enhancement - Admin - Link to Collaboration project added to UOSA page Order field

On the Support page of the Admin app, the *Order* field is now a clickable link to the Collaboration project.

### 4 March 2026 - Enhancement - Catalog - Dependency tags shown in version overview

On the *Versions* tab for a Catalog item, tags can now show the DataMiner and DataMiner Web version dependencies.

### 4 March 2026 - Enhancement - Catalog - Empower page update

In the Catalog app, the Empower page now has a new layout.

Users can now search for specific sessions and deploy packages directly from the page.

### 4 March 2026 - Enhancement - dataminer.services - DaaS startup message update

When DaaS startup takes longer than usual, the message shown after 15 minutes has been adjusted to indicate that startup may still be in progress.

### 4 March 2026 - Enhancement - Admin - URL support for ticket details

In the Admin app, ticket details can now be opened directly through URL support.

### 4 March 2026 - Fix - Admin - Table search box opened behind table

On the Support page of the Admin app, it could occur that the table search box opened behind the table.

### 4 March 2026 - Enhancement - Admin - Billing and Subscription page improvements

On the Billing pages in the Admin app, the renew tooltip has been improved and timestamp dates now use a medium date format.

When there are no active or expired subscriptions, a direct path to the subscription page is now available.

### 23 February 2026 - Enhancement - Admin - Deployment event chain error details

On the Deployments page of the Admin app, event chain errors now better highlight where an error occurred.

In addition, metadata now detects and shows stack traces in a separate box, with an option to copy the stack trace text. Text wrapping has also been improved to avoid horizontal scrollbars.

### 23 February 2026 - New feature - Admin - Delete DataMiner System from settings

In the Admin app, organization owners can now delete a DataMiner System directly from the settings page.

Deleting a DataMiner System from the home page now opens the Admin app in a new tab.

### 23 February 2026 - Enhancement - Home - Organization creation from home page, Admin app, or Catalog

It is now possible to create an organization from the dataminer.services home page as well as from the Admin app and the Catalog, via the organization selector. The organization creation flow uses a shared pop-up component across these locations.

When an organization is created successfully, it will automatically be selected.

### 23 February 2026 - Enhancement - Admin - Redirect after deleting last organization

When a user deletes their last organization, they are now redirected to the dataminer.services home page.

### 23 February 2026 - Enhancement - Billing - Yearly credit history filter

On the Billing credit history page, the date filter now uses a yearly format.

You can retrieve the credit history for the past five years, including the current year.

URL parameters have also been updated to support both the monthly billing page range and the yearly credit history range.

### 17 February 2026 - Enhancement - Admin - Confirmation email for ticket creation

When you create a support ticket via the Admin app, you will now receive a confirmation email. A sharepoint folder is also created for the ticket when possible.

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

Starting from February 2026, automatic monthly billing will be implemented for Automation Actions, Connectors, and Managed Objects. On the 5th day of each month, the expended DataMiner credits for the previous month's usage will be subtracted from the organization's balance. This billing will not take effect retroactively. See [Billing and metering](xref:Pricing_billing_and_metering) for more details. Note that the Community Edition base allowance has also been updated.

Perpetual-licensed systems will have usage-based billing only for Automation Object Modeling, Collaboration, and Storage as a Service.

In case an organization does not have sufficient DataMiner credits, their balance will go negative, and it will need to be topped up as soon as possible. Organizations with a negative balance will not be able to deploy new DaaS systems.

### 8 January 2026 - Enhancement - Billing - Dashboard Sharing & Unmanaged Objects usage billing

Starting from January 2026, automatic monthly billing will be implemented for Dashboard Sharing & Unmanaged Objects. On the 5th day of each month, the expended DataMiner credits for the previous month's usage will be subtracted from the organization's balance. This billing will not take effect retroactively. See [Billing and metering](xref:Pricing_billing_and_metering) for more details.

In case an organization does not have sufficient DataMiner credits, their balance will go negative, and it will need to be topped up as soon as possible. Organizations with a negative balance will not be able to deploy new DaaS systems.

### 8 January 2026 - Enhancement - Admin - Update time range selectors

On the Deployments and Audit pages of the Admin app, the time range components have been replaced with more modern selectors.

### 8 January 2026 - New feature - Catalog - Test package support

In the Catalog app, support has been added for a new type of item: "Test package". This type can be found within the *Productivity & Utility* category. Test packages follow a different flow from other Catalog types. These packages cannot be deployed directly. Instead, their ID is copied into the QAOps application, where the download and execution will be handled.

### 8 January 2026 - Fix - dataminer.services - DaaS deployments

When deploying a DaaS system on dataminer.services, users were able to keep clicking the *Deploy* button. This action should now correctly be disabled when a deployment has been started.

### 8 January 2026 - Fix - Admin - Remove node button

On the *DxMs* page of the Admin app, the option to remove a node was previously visible to all users. It is now only available to users with the Owner or Admin role for the DataMiner System.
