---
uid: Connector_help_Amazon_AWS_CloudFormation
---

# Amazon AWS CloudFormation

This connector integrates AWS CloudFormation functionality with DataMiner.

It allows you to list, create, and delete the AWS CloudFormation stacks in DataMiner. You can also link these stacks with DataMiner Stacks Deployment to integrate with SRM functionality.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                                  | **Based on** | **System Impact**                                               |
|----------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|-----------------------------------------------------------------|
| 1.0.0.x \[obsolete\] | Initial version                                                                                                                                                                                   | \-           | \-                                                              |
| 1.0.1.x \[SLC Main\] | \- Connector has been completely reworked and no longer directly refers to DataMiner SRM functionalities.-Allows creation and deletion of stacks from the connector.- Communicates using AWS API. | \-           | Parameter description changes. New elements need to be created. |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The AWS CloudFormation URL, in the following format: *https://cloudformation.\[aws region\].amazonaws.com*

### Initialization

When the element has been created, go to the **General** page, and fill in the parameters **Access Key ID** and **Secret Access Key**.

If network requires a proxy, also fill in the **Proxy Host** and **Proxy Port**.

### Debug

If the element is not working properly, activate **Information logging Level 1** and check the log file. It will show the actions that are being performed in the background.

## How to Use

When you have correctly set up the element, on the **Stacks** page, you will see the current AWS stacks listed in the **Stacks table**.

### Creating a Stack

To create a stack, click the **Create Stack** button. This will open a pop-up window where you will need to specify the **Stack Name** and **Stack Template** or **Stack Template URL**.Note: **Do not fill in both** the Stack Template and the Stack Template URL. It is not possible to use both of these at the same time.

You can also specify a **Stack Deployment** and define the **Stack Template Parameters** and the **Stack Template Capabilities**, following the structure of an AWS CLI command.

- To define **Stack Template Parameters**, use the following structure: *ParameterKey=Parameter_Name_1,ParameterValue=Parameter_Value_1 ParameterKey=Parameter_Name_2,ParameterValue=Parameter_Value_2.*
- To define **Stack Template Capabilities**, use the following structure: *CAPABILITY_ONE CAPABILITY_TWO*

Here is an example command using the **AWS CLI** to create a stack with the name "TestStack", the template URL "https://s3.amazonaws.com/my-bucket/my-template.json", two parameters ("InstanceType"with the value "t2.micro", and "KeyName" with the value "my-key-pair"), and requiring the capabilities "CAPABILITY_IAM" and "CAPABILITY_NAMED_IAM":

> aws cloudformation create-stack \\
>
> --stack-name **TestStack** \\ --template-url **https://s3.amazonaws.com/my-bucket/my-template.json \\**--parameters **ParameterKey=InstanceType,ParameterValue=t2.micro ParameterKey=KeyName,ParameterValue=my-key-pair \\**--capabilities **CAPABILITY_IAM CAPABILITY_NAMED_IAM**

During the creation process, the **Status** column will contain the value *Create in Progress*. If the creation was successful, it will contain the value *Created*.

If an error happens during the creation of a stack, a pop-up window will display an error message. You can then find more details on the **Stack Errors page** and in the **element log file**.

### Deleting a Stack

You can delete a stack by clicking the **Delete** button in the corresponding row.

The **Status** column will then display *Delete in Progress* until the stack is complete deleted. Deleted stacks are kept in the table for 5 minutes.

### Linking a Stack with Stack Deployment

After you create a stack, you can link it to DataMiner Stack Deployment by right-clicking the relevant row in the Stacks table and selecting **Link with Stack Deployment.** You will then be able to select the right deployment in a dialog box.

### Unlinking a Stack from Stack Deployment

To remove the link between a stack and a stack deployment, right-click the relevant row in the Stacks table and select **Unlink Stack Deployment**.

### Stacks Deployment

By default the element will hold 10 Stack Deployment entries. You can create, update, and delete entries via the right-click menu of the Stacks Deployment table. If you need to create many entries at the same time, use the **Create Stacks Deployments** button.

### External Request - Create Stack

External sources can also create stacks by setting a JSON object in parameter 120.

This JSON object should have the following structure:

{ "RequestId": *GUID that will be used to check errors in the Create Stack Errors Table*, "ResourceKey": *GUID of the Stacks Deployment*, "StackName": *String with the name of the stack*, "TemplateBody": *String with the template*, "ParametersList": *String with the parameters*, "CapabilitiesList": *String with the capabilities*}

**OR**

{ "RequestId": *GUID that will be used to check errors in the Create Stack Errors Table*, "ResourceKey": *GUID of the Stacks Deployment*, "StackName": *String with the name of the stack*, "TemplateUrl": *String with the URL*, "ParametersList": *String with the parameters*, "CapabilitiesList": *String with the capabilities*}

### Note

AWS CloudFormation allows you to define a stack using either a **template URL** or a **template body**. You cannot use both at the same time.
