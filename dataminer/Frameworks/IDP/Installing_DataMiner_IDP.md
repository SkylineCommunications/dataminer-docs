---
uid: Installing_DataMiner_IDP
---

# Installing DataMiner IDP

## Deploying the IDP package

1. Make sure DataMiner version **10.3.0 CU0** or higher is installed in your DMS.

1. If you intend to upgrade an existing IDP installation, and you are using a DataMiner version **lower than 10.4.0 or 10.4.3**, install the **[IDP Migration](https://community.dataminer.services/download/idp-migration/) package**.

   > [!TIP]
   > See also: [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent)

1. Deploy the [IDP package](https://catalog.dataminer.services/details/fdaa2902-cbb7-4d83-831d-91428ac5e88d) from the Catalog.

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

## Customizing the IDP setup

When you deploy the IDP package, IDP will be installed with the default settings. If you want to customize the setup, run the IDP setup wizard as detailed below:

1. Start the IDP setup wizard in one of the following ways:

   - Via the Automation module:

      1. In DataMiner Cube, go to *Apps* > *Automation*.

      1. Select the script *IDP_SetupWizard* and click *Execute*.

   - Via the IDP app:

      1. In DataMiner Cube, go to the *DataMiner IDP* element.

      1. Go the *Admin* > *Settings*.

      1. Click the button next to *Setup Wizard*.

1. On the first page, click the button *Execute Now*.

1. On the welcome page, click *Next*.

1. On the view selection page, specify which views should be used by DataMiner IDP:

   1. For each of the sections, either select *Create a new view* or select *Use existing view* and select the view in the drop-down list.

   1. In case you use an existing view that is not yet under the TOP view, select the option *Move existing views under TOP* view.

   1. Click *Confirm*.

1. On the confirmation page, click *Confirm*.

1. On the *IDP Extra Configurations* page:

   - Optionally customize the HTTP binding address, with the corresponding HTTP mode and port.

   - Optionally specify the path and credentials for the configuration archive.

   - Optionally specify the credentials for file transfers.

   > [!NOTE]
   > You can also configure these settings in the IDP app after the initial setup, via *Admin* > *Configuration* > *Network Shares*. However, this is not possible for the HTTP binding address, mode, and port.

1. Click *Next* until you reach the last page of the wizard.

1. On the last page of the wizard, click *Confirm*.

1. When the configuration of the IDP module has finished, which may take some time, click *Finish*, and on the next page, click *Close*.
