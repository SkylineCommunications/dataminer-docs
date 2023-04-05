---
uid: Managing_DCP_keys
---

# Managing dataminer.services keys

In the Admin app, you can manage keys that can for example be used with the [GitHub action to deploy Automation scripts](xref:Deploying_Automation_scripts_from_a_GitHub_repository) to DMS that is connected to dataminer.services.

To do so:

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

   > [!TIP]
   > See also: [Accessing the Admin app](xref:Accessing_the_Admin_app)

1. If a different organization should be selected, click the organization selector ![Organization selector](~/user-guide/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

1. In the pane on the left, under *DataMiner Systems*, select your DataMiner System and select the *Keys* page.

   On this page, each set of keys consists of a (user-defined) label, a primary key, and a secondary key. The following options are available to manage these keys:

   - To **view information** on a set of keys, click the entry in the list. This will open a side panel with detailed information, including when the keys were created and by whom.
   - To **view the value** of a primary or secondary key, click the eye icon next to the key.
   - To **copy** a primary or secondary key, click the copy icon next to the key.
   - To **add** a new set of keys, click *New Key* at the top of the page and specify the label for the keys.
   - To **regenerate** a primary or secondary key, click the "..." button to the right of the entry and select *Regenerate primary key* or *Regenerate secondary key*, respectively.

     When you regenerate a key, this will invalidate the key and generate a new value. As this can cause your CI/CD pipelines to no longer run successfully if they have not been updated accordingly, you will need to confirm that you indeed want to regenerate the key by specifying its label.

   - To **revoke** a set of keys, click the "..." button to the right of the entry and select *Revoke*.

     When you revoke a set of keys, this will effectively delete the keys. To avoid unwanted deletion, you will need to confirm that you indeed want to revoke the keys by specifying their label.

> [!TIP]
> Regenerating primary or secondary keys can also be done from the side panel.

> [!NOTE]
> Audit information about dataminer.services keys is available on the *Organization* > *Audit* page (see [Consulting dataminer.services audit logs](xref:DCP_Auditing)).
