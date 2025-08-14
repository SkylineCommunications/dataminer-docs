---
uid: installing_processing_pdf_documents
---

# Installing & configuring the solution

## Prerequisites

- DataMiner version 10.5.8 or higher

## Pricing

The applications part of this package will consume DataMiner credits, based on the level of usage of the apps. The DataMiner credits will be deducted monthly based on the metered usage. More information about the pricing of DataMiner usage-based services can be found in the [DataMiner Pricing Overview](https://docs.dataminer.services/dataminer-overview/Pricing/Pricing_Usage_based_service.html).

## Support

For additional help or to discuss additional use-cases, reach out to [Skyline Product Marketing](mailto:team.product.marketing@skyline.be).

## Deploy the Sample Solution

1. Lookup the [Package](https://catalog.dataminer.services/details/cb4988f9-f3e5-45b7-aade-144f21e9755a) from the Catalog.
2. Click the Deploy button to install button.
3. Select the target DataMiner System and confirm the deployment. The package will be pushed to the DataMiner System.

## Setup Cloud Services in Azure

To make use of the cloud services required by the sample applications, you will need an Azure subscription and resource group and deploy the following resources in it:

1. [Azure OpenAI](https://azuremarketplace.microsoft.com/en-us/marketplace/apps/Microsoft.CognitiveServicesOpenAI?tab=Overview): follow the step on the [Microsoft Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource?pivots=web-portal).

    - Make sure to complete the steps related to [Deploy a model](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource?pivots=web-portal#deploy-a-model).
    - For the configurations of the model, please choose gpt-4o as a model (used in this sample, but others can be used). Next to that you are free to choose a name (e.g. openai-pdf-processing-sample), use Standard as a deployment type and leave the advanced options as default.
    - After that you should be able to see your deployed model on the Azure AI Foundry.

2. [Document Intelligence](https://azuremarketplace.microsoft.com/en-us/marketplace/apps/Microsoft.CognitiveServicesFormRecognizer?tab=Overview): follow the step on the [Microsoft Documentation](https://learn.microsoft.com/en-us/azure/ai-services/document-intelligence/how-to-guides/create-document-intelligence-resource?view=doc-intel-4.0.0). No additional setup required.

> [!NOTE]
> For non-productions trials, feel free to contact [Skyline Product Marketing](mailto:team.product.marketing@skyline.be) to get secrets to connect to pre-configured AI services by Skyline.

> [!NOTE]
> The sample applications use [Semantic Kernel](https://learn.microsoft.com/en-us/semantic-kernel/overview/) to connect to cloud AI services in Azure. Semantic Kernel is a open-source development kit for integrating AI models and it is perfectly possible to integrate with other models than the onces used in this sample, see [Chat completion using Semantic Kernel](https://learn.microsoft.com/en-us/semantic-kernel/concepts/ai-services/chat-completion/?tabs=csharp-AzureOpenAI%2Cpython-AzureOpenAI%2Cjava-AzureOpenAI&pivots=programming-language-csharp).

## Configurations in DataMiner

DataMiner requires the necessary endpoint information and keys to make use of the AI services in Azure. To configure this, both the Interactive Prompt Tool app and the Satellite Parameter Extractor app contain a configuration page where a file can be uploaded with the required information.

1. Create a json file called `secrets.json` (you can also find this file in the documents folder after installing the package). `{YOUR-OPEN-AI-ENDPOINT}` and `{YOUR-OPEN-AI-KEY}` are the ones found in the [Azure Portal](https://portal.azure.com/), while the `{YOUR-MODEL-NAME}` is the name configured on [Azure AI Foundry](https://ai.azure.com/) (e.g., such as openai-pdf-processing-sample in the example above).

    ```json
    {
      "AzureOpenAIEndpoint": "{YOUR-OPENAI-ENDPOINT}",
      "AzureOpenAIKey": "{YOUR-OPENAI-KEY}",
      "ModelDeploymentName": "{YOUR-MODEL-NAME}",
      "DocumentIntelligenceEndpoint": "{YOUR-DI-ENDPOINT}",
      "DocumentIntelligenceKey": "{YOUR-DI-KEY}"
    }
    ```

2. Open one of the two apps that come with the package deployed in an earlier step. Go to `http(s)://[DMA name]/root`. Select *Interactive Prompt Tool* and *Satellite Feed Ingest*  to start using the applications.

![Processing PDF documents Apps](~/dataminer/images/pdf_processing_AI_Apps.png)

3. Upload the file using the configuration page on either the Interactive Prompt Tool or Satellite Parameter Extractor application. The interactive automation will automatically store the file in the right location to be accessible by the scripts used in the apps.

![Configuration](~/dataminer/images/pdf_processing_AI_configuration.png)

> [!CAUTION]
> At the moment, this automation will store the secrets file as a plain json file within the folder structure of your DataMiner system. Be aware that everyone with direct access to the system machine or with access to Automation will be able to access the credentials.
