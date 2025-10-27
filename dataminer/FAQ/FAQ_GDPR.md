---
uid: FAQ_GDPR
---

# Does DataMiner process personal data in a GDPR-compliant manner?

With regard to the General Data Protection Regulation (GDPR), DataMiner provides a full range of possibilities to ensure that all personal data is processed in a GDPR-compliant manner.

It is important to understand that DataMiner is a generic data collection platform. The user has full control over it, including which data is collected and how it is processed. Therefore, it is up to the user to decide whether to process technical data only or to also include personal data. Users can do so in their capacity of controller or processor, and based on a specified predefined legal basis.

In case the user chooses to process personal data via DataMiner, a specific retention period can perfectly be defined. This can be for e.g. one hour, but also several months. It is up to the user to define and to configure a proportional retention period for the personal data that is being processed.

Typical examples include the following:

- **Regular polling of personal data**: In this case, the user will only keep the last value that is fetched. If the value contains personal data, then the retention period ends when the data is polled again. Access to this personal data can be controlled via the DataMiner Security configuration, where you can specify which users in your company can access this information.

- **Alarm Records**: The user will only retain these records if alarm thresholds have been applied. This can be an alarm record containing personal data that is created and stored each time the user-defined threshold is reached. The time that DataMiner will keep this alarm record is also fully user-definable (e.g. after a certain time, DataMiner will automatically delete the record).

- **Performance Graph**: The user can enable or disable performance tracking on metrics, including metrics that hold personal data. Similar to the alarm messages, the user can define how long the system will retain that personal data. Moreover, DataMiner provides multiple privacy settings that users can apply within their organization. These settings consist of generic options that can be leveraged to flag, contain or fence off specific data. This includes access controls, visibility controls, custom properties on elements, etc.

From a security point of view, DataMiner has the capability to use industry-standard encryption. However, the methods used by DataMiner to extract data (which can include personal data as outlined above) from the third-party systems that are managed by DataMiner are defined by those third-party systems. If such a third-party system does not support encryption, and personal data is extracted from it using DataMiner, then that data will be exchanged in a clear format that can be read from the wire.

All of these tools and configuration possibilities should allow each user to put in place the necessary GDPR controls when DataMiner is being used to process personal data. Nevertheless, each user will still have to fulfill their proper obligations towards the data subject(s) in question (e.g. permissions, etc.).
