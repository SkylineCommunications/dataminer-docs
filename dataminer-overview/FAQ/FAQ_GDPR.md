---
uid: FAQ_GDPR
---

# Can DataMiner foresee GDPR-compliant processing of personal data?

In terms of General Data Protection Regulation (GDPR), DataMiner foresees a full range of possibilities to ensure GDPR-compliant processing of personal data.

Of course, to start with, it is important to understand that DataMiner is a generic data collection platform. It is hosted at the user’s premises. The user has full control over it, including which data is collected and how it is processed. Therefore, it is the user’s choice whether to process technical data only, or also personal data. Users can do so in their capacity of controller or processor, and based on a specified predefined legal basis.

In case the user chooses to process personal data through DataMiner, a specific retention period can perfectly be defined. This can be for example one hour, but also several months. It is up to the user to define, and to configure accordingly, a proportional retention period for the personal data that is being processed.

Typical examples include the following:

- **Regular polling of personal data**: In that case the user only keeps the last value fetched. If the value contains personal data, then the retention period ends when the new polling is executed. Access to this personal data can be controlled via the DataMiner Security configuration, i.e. you can decide which users in your company can access this information.

- **Alarm Records**: The user will only retain these records if alarm thresholds have been applied. This can be an alarm record containing personal data that is created and stored each time the user-defined threshold is reached. The time that DataMiner will store this alarm record that contains personal data is also fully user-definable (e.g. when a certain time expires, DataMiner will automatically delete the record).

- **Performance Graph**: The user can enable or disable performance tracking on metrics, including metrics that hold personal data. Similar to the alarm messages, the user can define how long the system will retain that personal data. Furthermore, DataMiner provides multiple privacy settings that users can apply within their organization. These settings consist of generic options that can be leveraged to flag, contain or fence off specific data. This includes access controls, visibility controls, custom properties on elements, etc.

From a security point of view, DataMiner itself has the capability to use industry-standard encryption. However, the methods used by DataMiner to extract data (which can include personal data as outlined above) from the third-party systems that are subject to being managed by DataMiner, is defined by those third-party systems. If such a third-party system does not support encryption, and personal data is extracted from it using DataMiner, then that data will be exchanged in a clear format that can be read from the wire.

All of these tools and configuration possibilities should allow each user to put in place the necessary GDPR controls when DataMiner is being used to process personal data. That being said, each user will still have to fulfill their proper obligations towards the data subject(s) in question (e.g. permissions, etc.).
