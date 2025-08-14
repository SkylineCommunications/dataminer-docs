---
uid: installing_processing_pdf_documents
---

# Installing and configuring the solution

## Prerequisites

- DataMiner version 10.5.8 or higher
- DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud)

## Deploying the sample solution

1. Go to the [Processing PDF documents using AI](https://catalog.dataminer.services/details/cb4988f9-f3e5-45b7-aade-144f21e9755a) package in the Catalog.

1. Click the *Deploy* button.

1. Select the target DataMiner System and confirm the deployment.

   The package will be pushed to the DataMiner System.

## Setting up cloud services in Azure

To make use of the cloud services required by the sample applications, you will need an Azure subscription and resource group, and you will need to deploy the following resources in it:

- [Azure OpenAI](https://azuremarketplace.microsoft.com/en-us/marketplace/apps/Microsoft.CognitiveServicesOpenAI?tab=Overview): 

  To deploy this, follow the steps in the [Microsoft Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource?pivots=web-portal).

  - Make sure to complete the steps related to [deploying a model](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource?pivots=web-portal#deploy-a-model).
  - For the configuration of the model, select **gpt-4o** as a model (used in this sample, but others can be used). You can choose the name freely (e.g. `openai-pdf-processing-sample`), use *Standard* as the deployment type, and leave the advanced options set to the default.

  When this is done, you should be able to see your deployed model in the Azure AI Foundry.

- [Document Intelligence](https://azuremarketplace.microsoft.com/en-us/marketplace/apps/Microsoft.CognitiveServicesFormRecognizer?tab=Overview):

  To deploy this, follow the steps in the [Microsoft Documentation](https://learn.microsoft.com/en-us/azure/ai-services/document-intelligence/how-to-guides/create-document-intelligence-resource?view=doc-intel-4.0.0). No additional setup is required.

> [!NOTE]
>
> - For non-productions trials, feel free to contact [Skyline Product Marketing](mailto:team.product.marketing@skyline.be) to get secrets to connect to pre-configured AI services by Skyline.
> - The sample applications use [Semantic Kernel](https://learn.microsoft.com/en-us/semantic-kernel/overview/) to connect to cloud AI services in Azure. Semantic Kernel is a open-source development kit for integrating AI models and it is perfectly possible to integrate with other models than the onces used in this sample, see [Chat completion using Semantic Kernel](https://learn.microsoft.com/en-us/semantic-kernel/concepts/ai-services/chat-completion/?tabs=csharp-AzureOpenAI%2Cpython-AzureOpenAI%2Cjava-AzureOpenAI&pivots=programming-language-csharp).

## Configuring DataMiner to use the AI services

DataMiner requires the necessary endpoint information and keys to make use of the AI services in Azure. To configure this, both the Interactive Prompt Tool app and the Satellite Parameter Extractor app contain a configuration page where a file can be uploaded with the required information.

1. Create a JSON file called `secrets.json`.

   You can find an example of this file in the Documents folder after installing the package.

   This file must have the following structure:

    ```json
    {
      "AzureOpenAIEndpoint": "{YOUR-OPENAI-ENDPOINT}",
      "AzureOpenAIKey": "{YOUR-OPENAI-KEY}",
      "ModelDeploymentName": "{YOUR-MODEL-NAME}",
      "DocumentIntelligenceEndpoint": "{YOUR-DI-ENDPOINT}",
      "DocumentIntelligenceKey": "{YOUR-DI-KEY}"
    }
    ```

   - For `{YOUR-OPEN-AI-ENDPOINT}` and `{YOUR-OPEN-AI-KEY}`, use the values from the [Azure Portal](https://portal.azure.com/)
   - For `{YOUR-MODEL-NAME}`, use the name configured on [Azure AI Foundry](https://ai.azure.com/) (e.g. `openai-pdf-processing-sample` if you used the example name mentioned above).

1. Open one of the two apps that were installed when you deployed the package by going to the [DataMiner landing page](xref:Accessing_the_web_apps) and selecting either *Interactive Prompt Tool* or *Satellite Feed Ingest*.

   ![Processing PDF documents Apps](~/dataminer/images/pdf_processing_AI_Apps.png)

1. Upload the file using the configuration page of the app.

   ![Configuration](~/dataminer/images/pdf_processing_AI_configuration.png)

   This will automatically store the file in the right location so that the scripts used in the apps can access it.

> [!CAUTION]
> At the moment, this will store the secrets file as a plain JSON file within the folder structure of your DataMiner System. Be aware that everyone with direct access to the system machine or with access to Automation will be able to access the credentials.
