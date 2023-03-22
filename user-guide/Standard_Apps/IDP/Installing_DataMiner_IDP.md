---
uid: Installing_DataMiner_IDP
---

# Installing DataMiner IDP

To install and set up DataMiner IDP:

1. Make sure the necessary prerequisites are available:

   - DataMiner version **10.1.0 CU10** or higher must be installed in your DMS. For older IDP versions (prior to IDP 1.1.20), the minimum supported version is DataMiner 10.0.0 CU9.

   - If you want to use scheduled activities, your DMS must use an **Elasticsearch database**.

   - If you want to use Process Automation, make sure **DataMiner SRM, Process Automation, and Token activity** are installed before you install the IDP package. If you want to be able to repeat processes with a timer, the **Repeat Gateway** also has to be installed.

1. Download the DataMiner IDP package from [DataMiner Dojo](https://community.dataminer.services/downloads/).

1. Double-click the IDP package, and install the package in the same manner as a DataMiner upgrade.

   > [!NOTE]
   > DataMiner will restart during the installation of the package.

   > [!TIP]
   > See also: [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent)

1. In DataMiner Cube, go to *Apps* > *Automation*.

1. Select the script *IDP_SetupWizard* and click *Execute*.

1. On the first page, click the button *Execute Now*.

1. On the welcome page, click *Next*.

1. On the view selection page, specify which views should be used by DataMiner IDP:

   1. For each of the sections, either select *Create a new view* or select *Use existing view* and select the view in the drop-down list.

   1. In case you use an existing view that is not yet under the TOP view, select the option *Move existing views under TOP* view.

   1. Click *Confirm*.

1. On the confirmation page, click *Confirm*.

1. If you are using an IDP version prior to IDP 1.1.18, on the following page, specify whether a new or an existing user account will be used for internal IDP communication:

   1. If no suitable user account exists in your system yet, click *Yes*, *go ahead*. Otherwise, click *No*, *I would like to use an existing user* and select the account in the drop-down list.

   1. Specify the password for the user account in both the *Password* and *Confirm Password* boxes, and click *Confirm*.

   > [!NOTE]
   >
   > - Do not specify a user account of which the password is subject to an expiration policy. We recommend creating a dedicated IDP account if no such account exists yet.
   > - If you run the setup wizard again after the initial setup, you can choose to specify different user credentials. However, by default the same user credentials will continue to be used, so you do not have to specify anything.
   > - As the Provisioning API is no longer used from IDP 1.1.18 onwards, this step is obsolete. From IDP 1.2.0 onwards, it is no longer displayed in the wizard.

1. On the *IDP Extra Configurations* page:

   - Optionally customize the HTTP binding address, with the corresponding HTTP mode and port.
   - Optionally specify the path and credentials for the configuration archive.
   - Optionally specify the credentials for file transfers. Note that prior to IDP 1.1.20 (from IDP version 1.1.18 onwards), these are mentioned as the credentials for the working directories.

    > [!NOTE]
    > Aside from the HTTP binding address, mode and port, you can also configure these settings in the IDP app after the initial setup, via *Admin* > *Configuration* > *Network Shares*.

1. Click *Next* until you reach the last page of the wizard.

1. On the last page of the wizard, click *Confirm*.

1. When the configuration of the IDP module has finished, which may take some time, click *Finish*, and on the next page, click *Close*.

> [!NOTE]
> To upgrade IDP if the app is already installed, follow the same procedure as detailed above. However, instead running the *IDP_SetupWizard* script from the Automation app, you can do so by going to *Admin* > *Settings* in the IDP app and clicking the button next to *Setup Wizard*.
