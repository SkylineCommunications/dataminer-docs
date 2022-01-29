---
uid: Checking_the_SLA_compliance
---

# Checking the SLA compliance

To view more information on SLA compliance, check the section *Compliance Info* on the *Main View* page of the SLA element. There you will find the following information:

- **Compliance**:

    Possible values:

    - *Compliant*: The SLA has never been violated and is currently not being violated.

    - *Breached*: The SLA has been violated beyond the acceptable limits, i.e. penalties could be due.

    - *Compliant (Degraded)*: The SLA has been violated, but not beyond the acceptable limits.

    - *Compliant (Degrading)*: The SLA is being violated right now, though not beyond the acceptable limits.

- **Predicted Compliance**:

    Possible values:

    - *Compliant*: The SLA is 100 percent compliant.

    - *Breached*: The SLA has been breached.

    - *Jeopardy*: If the service keeps on failing at the current ratio, the SLA will be breached by the end of the window.

    > [!NOTE]
    > From version 3.0.0 of the *Skyline SLA Definition Basic* protocol onwards, the *Predicted Compliance* has been moved to the *Predictions* page of the SLA. However, note that predictions will only work if, on the *Advanced Configuration* page of the SLA, *Outages* and *Predictions* have been set to *Enabled*. These settings can only be modified by users with at least security level 3.

- **Detailed violation information**:

    Total and single violation time left, number of violations left.

For more information on how to set these parameters, see [Configuring SLA Compliance](xref:Configuring_SLA_Compliance).
