---
uid: dataminer_services_change_log_2026
---

# dataminer.services change log - 2026

The dataminer.services platform gets updated continuously. This change log can help you trace when specific features and changes have become available in 2026.

> [!NOTE]
> Many features on dataminer.services are dependent on DxMs. You can find the change logs for these under [DxM release notes](xref:DxM_RNs_index).

### 7 May 2026 - Enhancement - Admin - Billing overview now shows services table at unit level

On the Billing overview page in the Admin app, the services table now shows data at unit level instead of capping out at service level, giving users a deeper insight into what is affecting their billing the most.

### 5 May 2026 - New feature - Admin - Draft subscriptions

On the Billing page of the Admin app, the Subscriptions page now shows draft subscriptions, which are marked as *Draft* in the state column. The following changes have also been introduced:

- The *Total paid* column has been renamed to *Cost*, and the *Total saved* column has been renamed to *Saved*.
- Subscription details now support draft subscriptions, with *Continue from draft* and *Abandon draft* actions available.
- When continuing from a draft, the *Add Subscription* panel is prefilled with the draft details.
- Drafts can be saved and updated in the *Add Subscription* panel.
- A draft is automatically removed when the subscription is purchased.

### 5 May 2026 - Fix - Problem with session token refresh could cause unexpected redirect to login page

It could occur that users were unexpectedly redirected to a login page because session tokens were not refreshed correctly. This issue has been resolved.

### 5 May 2026 - Enhancement - Admin - 'Renewal failed' state and toggle button to hide expired subscriptions

On the Billing page of the Admin app, if subscriptions are set to auto-renew but have expired without a reference to a new subscription, these will now show a *Renewal failed* state.

In addition, a toggle button has been introduced to hide expired subscriptions. By default, expired subscriptions are set to be shown.

### 5 May 2026 - Enhancement - Admin - Discount tooltip updated in Add Subscription panel

On the Billing page of the Admin app, the tooltip for the discount in the *Add Subscription* panel has been updated.

### 5 May 2026 - Enhancement - Billing - Estimated subscription based on current usage

When creating a new subscription on the Billing page, users can now choose to start from estimated data based on their current subscriptions and pay-per-use costs.

### 5 May 2026 - Enhancement - Billing - Amounts smaller than 0.01 displayed as "< 0.01"

On the Billing page, numbers smaller than 0.01 are now displayed as "< 0.01" instead of being rounded down to zero.

### 5 May 2026 - Fix - Admin - Aborted calls when navigating to DMS user page not handled gracefully

When you navigated to the user page of a DataMiner System, it could occur that some calls to retrieve the DMS users were aborted, which was not handled gracefully and could result in errors. This issue has been resolved.

### 5 May 2026 - Fix - Home - Password feedback incorrectly shown after clearing password field

When a value that had been entered in a password field was cleared, it could occur that the password feedback was still shown. This issue has been resolved.

### 27 April 2026 - Fix - Admin - Audit page DMS incorrectly also shown in sidebar

In the Admin app, it could occur that the DMS used as the filter for the Audit page was incorrectly also shown in the sidebar.

### 27 April 2026 - Enhancement - Grammar and styling in notifications streamlined across apps

The notifications across apps have now been streamlined to have the same grammatical structure. The styling of the notifications has also been updated.

### 27 April 2026 - Fix - Home - Geo-replication error not shown when expected

When you switch from a region with geo-replication available to a region that does not have geo-replication available, a geo-replication error message should be shown on the home page, but this did not happen.

### 27 April 2026 - Fix - Catalog - Custom Markdown parser now correctly shows alert blocks

In the Catalog app, some messages would not show the first line because of an issue with the custom Markdown parser. Now all messages are fully visible.

### 27 April 2026 - Fix - Admin - Nodes with same DMA ID but no Failover info shown as Failover pair in DMS overview

In the DMS overview of the Admin app, nodes with the same DMA ID but no Failover info were incorrectly displayed as a Failover pair. This issue has been resolved.

### 27 April 2026 - Enhancement - Catalog - Catalog categories cached in session storage

Catalog categories are now cached in session storage, avoiding an unnecessary web API call and loading animation in the UI.

### 27 April 2026 - Fix - Admin - Regenerated key not correctly updated in side panel

When a new key (primary or secondary) was generated in the Admin app, the side panel was not correctly updated. This issue has been resolved.

### 27 April 2026 - Fix - Admin - Admin app no longer working after deletion of organization

When an organization was deleted, it could occur that the Admin app was no longer working correctly. Now another available organization will be selected if possible, and otherwise the home page will be shown instead.

### 27 April 2026 - Enhancement - Home - Updated geo-replicated error message

The geo-replicated storage error message on the home page has been updated.

### 27 April 2026 - New feature - Admin - Credit and discount rate overrides on organization level

On the Billing page of the Admin app, credit and discount rates can now be overridden on organization level.

### 27 April 2026 - Fix - Catalog - Menu actions not available for test packages

In the Catalog app, the menu actions (delete, make private) were incorrectly not available for test packages.

### 27 April 2026 - Fix - Admin - Incorrect description delete DMS button

The description above the delete DMS button incorrectly mentioned the admin role, but only the owner can delete the DMS. This has now been corrected.

### 27 April 2026 - Enhancement - Catalog - DMS name included in deployment result notification

In the Catalog app notifications related to deployments of packages, the DMS name is now included.

### 27 April 2026 - Enhancement - Admin - DMS filter on Audit page now includes all systems

On the Audit page of the Admin app, the DMS filter now includes all DataMiner Systems regardless of access.

### 27 April 2026 - Enhancement - 'DCP' terminology adjusted to 'dataminer.services'

References to 'DCP Keys' have been adjusted to 'dataminer.services Keys' to ensure consistent terminology throughout the dataminer.services apps.

### 27 April 2026 - Enhancement - Admin/Home - Delete DMS flow refactored to prevent stale deleted systems

When you try to delete a DMS on the dataminer.services home page, this will now open the delete confirmation dialog in the Admin app, navigating within the current tab of the browser. Once the deletion has been confirmed, the home page will be shown again. This refactored deletion flow will ensure that deleted systems are never still shown on the home page, while previously they could still be shown until the page was refreshed.

### 27 April 2026 - Enhancement - Admin - Improved filtering on Audit page

The following improvements have been applied to the checkbox filters on the Audit page of the Admin app:

- The list of options is now virtualized for better performance.
- A select/deselect all button is now available.
- A toggle button is available to show selected only.
- The filter box no longer shifts when options are selected.

### 27 April 2026 -Enhancement - Favicons updated

The website icons for all applications have been changed to the updated DataMiner logo.

### 27 April 2026 - Enhancement - Status page - Event types shown for incidents

On the status page, incidents are now shown as events, with possible event types (*Incident* and *Maintenance*) shown as a label for the event.

### 16 April 2026 - Fix - Admin - Both info and error message shown when no available nodes were found in the DMS

On the DMS overview page of the Admin app, it could occur that both an info message and an error message were shown when there were no available nodes for the system. This issue has been resolved.

### 16 April 2026 - Enhancement - Home - Improved tracking of progress and results of corporate website

When an *onboard_complete* event is logged to Google analytics, the organization and coordination ID are now included to allow improved tracking of the progress and results of the corporate website.

### 16 April 2026 - Fix - Password incorrectly remained shown after peek button had been used

When the peek button was clicked to show the password in a password input box, it could occur that the password was still shown when the peek button was released again and the mouse pointer was moved outside the bounds of the button. This issue has been resolved.

### 16 April 2026 - Fix - Admin - Error shown after quickly toggling filter boxes for audit logs

When the filter checkboxes on the Audit page in the Admin app were toggled quickly, an error could be shown.

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
