## Configuring job domains

From DataMiner 10.0.9 onwards, different job domains can be configured, each with its own job section configuration.

To **add** a job domain:

1. Click the user icon in the top-right corner and select *Configuration*.

2. Click* + New* in the header bar.

3. Specify the name of the new domain.

4. Optionally, to hide the domain, select the *Hide* checkbox.

    This can be especially useful to keep a domain hidden while it is still being configured. Once the configuration is ready, you can then edit the domain to clear the *Hide* option.

5. Click *Save*.

To **edit** the name of a job domain or change its “hidden” status:

1. If you are not already on the configuration page, click the user icon in the top-right corner and select *Configuration*.

2. In the drop-down box at the top, make sure the right job domain is selected.

3. Click *Edit* in the header bar.

4. Specify a different name for the domain or clear or select the *Hide* box.

5. Click *Save*.

To **duplicate** a domain:

1. If you are not already on the configuration page, click the user icon in the top-right corner and select *Configuration*.

2. In the drop-down box at the top, make sure the right job domain is selected.

3. Click *Duplicate* in the header bar. This will open a menu where you can select one of the following options:

    - *Share sections across domains*: Select this option if you want to copy the domain by reference, which means that the new domain will use the same sections as the domain you are duplicating.

    - *Create copies of sections*: Select this option if you want to create a hard copy of the domain, which means that the new domain will use new sections that are copies of the sections in the domain you are duplicating.

4. Specify the name of the new domain.

5. Optionally, to hide the new domain, select the *Hide* checkbox.

6. Click *Duplicate*.

To **delete** a job domain:

1. If you are not already on the configuration page, click the user icon in the top-right corner and select *Configuration*.

2. In the drop-down box at the top, make sure the right job domain is selected.

3. Click *Delete* in the header bar and click *Yes* in the pop-up window to confirm the deletion.

> [!NOTE]
> If a DataMiner System using an earlier software version is upgraded to DataMiner 10.0.9 or higher, its existing job section definitions will be placed in a job domain named "DefaultJobDomain". The name of this domain can be adjusted if necessary.
>
