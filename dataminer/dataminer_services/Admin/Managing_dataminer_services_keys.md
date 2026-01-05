---
uid: Managing_dataminer_services_keys
keywords: cloud keys
reviewer: Alexander Verkest
---

# Managing dataminer.services keys

## System keys

System keys can be used with the [DataMinerDeploy .NET tool to deploy packages](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Tools.DataMinerDeploy/tree/main/CICD.Tools.DataMinerDeploy#deploying-from-a-volatile-upload) to a DMS that is connected to dataminer.services.

To view your system keys:

1. In the [Admin app](xref:Accessing_the_Admin_app), check whether the correct organization is mentioned in the header bar.

1. If a different organization should be selected, click the organization selector ![Organization selector](~/dataminer/images/Cloud_Admin_Selector_icon.png) in the top-right corner, and select the organization.

1. In the pane on the left, under *DataMiner Systems*, expand the DataMiner System, and select the *Keys* page.

   Here you will be able to manage your system keys.

   > [!NOTE]
   > To be able to see the keys page for a system, you need to be at least an Admin for that system.

## Organization keys

Organization keys are among others used to [register new Catalog items](xref:Register_Catalog_Item), [change the publishing state of a Catalog item](xref:Change_Catalog_Publishing_State), or add new DataMiner nodes.

To view your organization keys:

1. In the [Admin app](xref:Accessing_the_Admin_app), check whether the correct organization is mentioned in the header bar.

1. If a different organization should be selected, click the organization selector ![Organization selector](~/dataminer/images/Cloud_Admin_Selector_icon.png) in the top-right corner, and select the organization.

1. In the pane on the left, under *Organization*, select the *Keys* page.

   Here you will be able to manage your organization keys.

   > [!NOTE]
   > To be able to see the keys page for an organization, you need to be at least an Admin for that organization.

## Managing your keys

Each set of keys consists of a (user-defined) label, a primary key, and a secondary key. The following options are available to manage these keys:

- To **view information** on a set of keys, click the entry in the list. This will open a side panel with detailed information, including when the keys were created and by whom.
- To **view the value** of a primary or secondary key, click the eye icon next to the key.
- To **copy** a primary or secondary key, click the copy icon next to the key.
- To **add** a new set of keys, click *New Key* at the top of the page, and specify a label.
  
  When adding a new key, you have to specify permissions for the key. The *Register catalog items* permission will allow the key to be used to [register new Catalog items](xref:Register_Catalog_Item). The *Add DataMiner System* permission will allow the key to be used to add new DataMiner Systems, e.g. when creating a DMS with the [pre-installed DataMiner Virtual Hard Disk](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk).

- To **regenerate** a primary or secondary key, click the *...* button to the right of the entry, and click *Regenerate primary key* or *Regenerate secondary key* respectively.

  When you regenerate a key, this will invalidate the key and generate a new value. As this can cause your CI/CD pipelines to no longer run successfully if they have not been updated accordingly, you will need to confirm that you indeed want to regenerate the key by specifying its label.

- To **revoke** a set of keys, click the *...* button to the right of the entry, and click *Revoke*.

  When you revoke a set of keys, this will effectively delete the keys. To avoid unwanted deletion, you will need to confirm that you indeed want to revoke the keys by specifying their label.

> [!TIP]
> Regenerating primary or secondary keys can also be done from the side panel.

> [!NOTE]
> Audit information about dataminer.services keys is available on the *Organization* > *Audit* page (see [Consulting dataminer.services audit logs](xref:Auditing)).
