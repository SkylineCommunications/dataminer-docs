---
uid: Replicating_an_existing_SLA
---

# Replicating an existing SLA

To replicate an existing SLA located in another DMS, follow the same procedure as for the creation of a new SLA. However, in the *General* section, select the checkbox *Replicate*.

You will then need to enter the IP address or the hostname of the DMA, and connect to the DMA with a user account.

After you click the *Retrieve SLAs* button, depending on the rights the account you used has been granted on the remote DMA, a list of SLAs will be displayed from which you can select the SLA you want to replicate.

> [!NOTE]
> External authentication credentials cannot be used when replicating SLAs. This is for instance the case when users are authenticated against an Atlassian Crowd server.
