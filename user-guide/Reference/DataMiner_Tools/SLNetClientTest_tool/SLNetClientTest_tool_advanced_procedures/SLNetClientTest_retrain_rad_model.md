---
uid: SLNetClientTest_retrain_rad_model
---

# Retraining the internal model used by RAD

In some cases, it can be useful to retrain the internal model used by [relational anomaly detection (RAD)](xref:Relational_anomaly_detection). This allows you to indicate the periods during which a parameter group was behaving as expected, so that RAD can better identify when the parameters deviate from that expected behavior in the future.

1. [Connect to the DMA hosting the grouped parameters using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to the *Build Message* tab of the main window of the SLNetCLientTest tool.

1. In the *Message Type* drop-down list, select the message *Skyline.DataMiner.Analytics.MAD.RetrainMADModelMessage*.

   In this message, "MAD" stands for "multivariate anomaly detection", which is another name for RAD.

1. Configure the following fields:

   - *GroupName*: The name of the parameter group as configured in *RelationalAnomalyDetection.xml*.
   - *StartTime*: The start time of the period during which the parameter group was behaving as expected.
   - *EndTime*: The end time of the period during which the parameter group was behaving as expected.

1. Click *Send Message*.
