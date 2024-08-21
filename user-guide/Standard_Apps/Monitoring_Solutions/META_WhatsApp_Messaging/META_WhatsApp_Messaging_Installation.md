---
uid: META_WhatsApp_Messaging_Installation
---

# Installing the META WhatsApp Messaging solution

## Prerequisites

### 1. Register on Meta Developers platform

- Follow the steps described in the following page to [*register as META developer*](https://developers.facebook.com/docs/development/register).
- Once registered, go to *“My Apps”* and then, press *“Create App”*.
- Select *“I don't want to connect a business portfolio yet”*.
- For use case, select *“Other”*.
- The app type should be *“Business”* in this case.
- Give a name to the app and attach an email to it.

![App in META Developers Account](~/user-guide/images/META_WhatsApp_Messaging_MetaRegister.png)

### 2. Create a Business Manager account

- Go to the [*Meta Business Suite*](https://business.facebook.com/).
- Create a new account by specifying a business name, the owner name, and the email desired to be associated with the business.
- Set the required details of the business.
- Confirm the business email address.

![META Business Account](~/user-guide/images/META_WhatsApp_Messaging_BusinessAccount.png)

### 3. Add WhatsApp to the App and send Test Message

- Back on the developer page, in the *"Add Products"* section, find WhatsApp and press *"Set up"*.
- Go to the WhatsApp *"Quick Start"* and select the commercial portfolio you created in the previous step.
- In the *“API Configuration”* section, add a new recipient’s phone number.
- Enter the verification code you received in the recipient's WhatsApp app to verify the phone number.
- Select the recipient's phone number and send the test message by pressing the "*Send Message*" button.
- Save the ***"Phone Number Identifier"*** and the ***"WhatsApp Business Account ID"*** located just below the sender's number for the **connector configuration**.

****Note that here you need to add all the recipient numbers to which you want to send the WhatsApp alarm notifications.***

![META App](~/user-guide/images/META_WhatsApp_Messaging_MetaApp.png)

### 4. Create a System User

- Go to [*Meta Business Suite*](https://business.facebook.com/) again.
- In the *Users > System Users* section, add a new system user giving it a name and a role (*Employee* or *Admin*).
- Select the user you created, press the three dots button and select the “*Assign assets*”.
- Assign your app and give the user the appropriate permissions.
- Then press “*Generate token*”.
- Select the app.
- Choose the desired time for the token to expire (60 recommended for security).
- Assign the following permissions: *business_management, whats_app_business_messaging, whats_app_business_management*
- Save the **generated token** in a safe place, as it will be needed for the **connector configuration**.

![META Business Account](~/user-guide/images/META_WhatsApp_Messaging_UserToken.png)

## Installation

1. Look up the [*META WhatsApp Messaging* solution](https://catalog.dataminer.services/details/909de004-7a8f-43bd-b40c-824051fe3fe1) in the DataMiner Catalog.
1. Click the *Deploy* button.
1. Select the target DataMiner System and confirm the deployment. The package will be pushed to the DataMiner System.
    - *If this is the first time you install the solution, a new automation script named **"Meta Alarm Detection"**, a new view called **"Dataminer Apps & Solutions"** and an element named **"META WhatsApp Alerter"** will automatically be created. Optionally, you can rename the element and view, and you can change their location in the Surveyor.*
1. Create a correlation rule.
    1. Set the alarm filter desired to trigger the correlation.
    1. Set an action to run the ***"META Alarm Detection"*** script recently included in the proper DMA.

*For more info about correlation rules visit [Orchestration & Automation courses](https://community.dataminer.services/learning/courses/orchestration-automation/) and [About DataMiner Correlation](https://docs.dataminer.services/user-guide/Advanced_Modules/Correlation/About_DMS_Correlation.html)*.

### Connector Configuration

For the instructions to configure the ***META WhatsApp Messaging connector***, refer to the [***connector documentation***](https://docs.dataminer.services/connector/doc/META_WhatsApp_Messaging.html).
