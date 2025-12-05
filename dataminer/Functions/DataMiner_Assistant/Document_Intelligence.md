---
uid: docintel
---

# Document Intelligence

Starting from version 2.0.7, the [DataMiner Assistant](xref:Assistant_DxM) DxM will be able to analyze documents based on specific instructions.
Both the document and the instructions need to be provided by the user when sending a Document Intelligence request.

Example of such requests could be:

- Processing order information from emails
- Processing incident information from unstructured text
- Extracting parameters from a pdf file

> [!TIP]
> Eager to see Document Intelligence in action? The [insert final name of Jonas' package] package offers a ready-to-use Satellite Parameter Extractor app. This app showcases how to extract parameters from a pdf file as a fully automated step in the context of a satellite reservations pipeline. Go to the [Catalog app](https://catalog.dataminer.services/) to deploy the package and start diving into this feature!

DataMiner Assistant uses a combination of OCR (Optical Character Recognition) & LLMs (Large Lanaguage Models) to perform the desired operations on a file. When a file is uploaded for analysis, the DxM will first process the document using OCR, which provides a plain text representation of the file content. As a second step, this information is packed together with the provided user instructions (prompt) and sent to an LLM for further interpretation. This two-step approach ensures maximum flexibility and reliability.

> [!TIP]
> The quality of the generated response is tightly bound to the quality of the provided inputs. It is strongly advised to use well structured files containing as little unrelevant information as possible. Instructions on how to interpret the file content should also be carefully selected. Check section [User instructions](xref:docintel#user-instructions) for tips on how to structure prompts optimally.

## Input files

In principle, every file format supported by Azure Document Intelligence Service can be analyzed via the Document Intelligence feature.
At this point in time, the following formats are supported:

- Images (JPEG/JPG, PNG, BMP, HEIF)
- PDF
- TIFF
- Word (DOCX): embedded or linked images not supported
- Excel (XLSX): embedded or linked images not supported
- PowerPoint (PPTX): embedded or linked images not supported
- HTML: embedded or linked images not supported

## User instructions

Generally speaking, any text containing instructions formulated in natural language will be accepted.
However, some basic guidelines can truly make a difference between an excellent and a mediocre Document Intelligence response:

- **Be specific**. Vague requests often result in poor responses. The more context and specificity you provide, the more targeted and useful the response will be. 
- **Focus on the essentials**. Extra information that is not directly relevant to your main question can sometimes pull the response in unintended directions. Avoiding tangential details is key.
- **Mention your desired format**. Specify if the response should conform to a specific structure. For example, if the response should be in json format, it is best to explain in advance which fields and values are allowed and/or required. 
- **Show, don't tell**. One good example is worth a thousand instructions. If possible, include a practical example of the response you would like to get.

## Cloud services

The Document Intelligence features relies on external AI services, both for OCR as for LLM usage. More specifically, **Azure Document Intelligence Service** and **Azure OpenAI Service (Global Standard Deployment)** are used. Therefore, data is transmitted to Microsoft Azure endpoints for processing. Azure AI Services process data in accordance with Microsoft's data handling policies and all data is encrypted while in transit. 

> [!IMPORTANT]
> - When data is sent to the Document Intelligence Service, both input data and analysis results may be temporarily encrypted and stored in an Azure Storage for a maximum of 24h after the operation has completed. Data is guaranteed to never leave the services's region. For the time being, this will be Western Europe for any user.
> - The Global Standard Deployment of Azure OpenAI ensures the highest availability and lowest costs by processing data across Azure's global infrastructure: while temporarily stored data should never leave the designated region, prompts and responses **might be processed in any geographic area**. In this case, the service's region currently is Sweden for every user.
> - It is the user's responsibility to ensure that the uploaded content complies with their organization's data handling policies, security requirements, and applicable regulations (e.g., GDPR, CCPA).
> - It is highly recommended to review the [Azure Document Intelligence data privacy documentation](https://learn.microsoft.com/en-us/legal/cognitive-services/document-intelligence/data-privacy-security) and the [Azure OpenAI data privacy and security documentation](https://learn.microsoft.com/en-us/legal/cognitive-services/openai/data-privacy).

## Pricing

Document Intelligence consumes **DataMiner credits** proportionally to the amount of data analyzed. The DataMiner credits will be deducted monthly based on metered usage. More information about the pricing of DataMiner usage-based services can be found in the [DataMiner Pricing Overview](xref:Pricing_Usage_based_service#usage-terms)