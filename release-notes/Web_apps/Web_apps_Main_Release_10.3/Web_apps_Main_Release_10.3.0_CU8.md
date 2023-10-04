---
uid: Web_apps_Main_Release_10.3.0_CU8
---

# DataMiner web apps Main Release 10.3.0 CU8 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Main Release 10.3.0 CU8](xref:General_Main_Release_10.3.0_CU8).

### Enhancements

#### BREAKING CHANGE: One single authentication app for all web apps [ID_35772] [ID_35896]

<!-- MR 10.3.0 [CU8] - FR 10.3.5 -->

Up to now, every web app had its own login screen and its own way of authenticating users. When using external authentication via SAML, this meant that, for every web app, a separate `AssertionConsumerService` element had to be added to the `spMetadata.xml` file.

A new dedicated authentication app has now been created. This app will be used by all current and future DataMiner web apps.

When using external authentication via SAML, this means that all existing `AssertionConsumerService` elements specified in the `spMetadata.xml` file can now be replaced by one single element. See the example below.

```xml
<md:AssertionConsumerService Binding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" Location="https://dataminer.example.com/API/" index="1" isDefault="true"/>
```

In this element, `https://dataminer.example.com` has to be replaced with the IP address or the DNS name of your DataMiner System. Make sure the endpoint address in the `Location` attribute matches the address you specified when you registered DataMiner with the identity provider. The way you configure this will depend on the identity provider you are using (for example, in the case of Azure AD, this address has to be entered in the *Entity ID* field).

> [!NOTE]
>
> - When using external authentication via SAML, DataMiner should be configured to use HTTPS.
> - This new authentication app will also be used by DataMiner Cube, but only to authenticate users who want to access a web page stored on a DataMiner Agent, not to authenticate users who log in to Cube itself.

#### Dashboards app & Low-Code Apps: A backup of all existing dashboards and low-code apps will now be made when performing a DataMiner upgrade  [ID_37413]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

When you install a DataMiner upgrade (either a full upgrade or a web-only upgrade), a backup of all existing dashboards and low-code apps on the system will now be made.

After a DataMiner upgrade, all dashboards and low-code apps will, if necessary, be migrated in order to make them compatible with the newer software versions. If an error occurs during this migration, or if you need to perform a DataMiner downgrade, you will now be able to restore the dashboards and low-code apps stored in the backup. However, note that restoring these items will have to be done manually.

All backups of dashboards and low-code apps will be stored in `C:\Skyline DataMiner\System Cache\Web\Backups`.

### Fixes

#### Dashboards app: Problem when opening a dashboard of which the URL was longer than 2048 characters [ID_36382] [ID_36510]

<!-- MR 10.3.0 [CU8] - FR 10.3.7 -->

When you opened a dashboard of which the URL was longer than 2048 characters, the authentication app would fail to open, causing IIS to either stop operating or throw a 404 or 414 error.

#### Dashboards app/Low-Code Apps: Seconds of multiple clock components would not be in sync [ID_37193]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.10 -->

When you enabled the *Show seconds* option of multiple clock components on the same dashboard or app panel, the seconds would incorrectly not all be in sync.

#### Low-Code Apps: Problem when two State components were fed the same query row data with a column filter applied [ID_37206]

<!-- MR 10.3.0 [CU8] - FR 10.3.10 -->

When two *State* components were fed the same query row data and had a column filter applied, the app would become unresponsive.

#### Dashboards app/Low-Code Apps: Problem when migrating a query containing only a 'start from' node linking to another query with only a 'start from' node [ID_37224]

<!-- MR 10.3.0 [CU8] - FR 10.3.10 -->

Up to now, it would not be possible to migrate a query with only a *start from* node linking to another query with only a *start from* node linking to another query.

#### Dashboards app/Low-Code Apps: Stepper component would apply an incorrect theme color [ID_37263]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

In some cases, the *Stepper* component would not apply the correct theme color.

#### Dashboards app/Low-Code Apps: Problem with custom time zones [ID_37278]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

When a custom time zone was used, in some cases, that time zone would not be processed correctly.

For example, when you set a custom time zone in a *Clock* component, the current time of that custom time zone would not be identical to the current time of the local time zone.

> [!NOTE]
> This problem would mostly occur when using a time zone that no longer observed daylight saving time (e.g. Altai Standard Time).

#### Problem with the IIS web server when redirecting the user to the login page [ID_37288]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

In some cases, an error could occur in the IIS web server when redirecting the user to the login page.

#### Low-Code Apps: Problem when accessing apps of which page and/or panel names contained special characters [ID_37474]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 [CU0] -->

After an upgrade to version 10.3.10, it would no longer be possible to access existing apps of which page and/or panel names contained special characters. Also, when adding a page or a panel, it would no longer be possible to enter a page or panel name that contained special characters.
