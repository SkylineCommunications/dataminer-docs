---
uid: processing_pdf_documents
---

# Sample solution: Processing PDF documents using AI

## About

This sample package shows how cloud AI tools, such as OCR (Optical Character Recognition) and LLM (Large Language Models, e.g. GPT-4o) can be integrated with DataMiner to automate steps in a DataMiner-powered operational workflow. This can facilitate any use case where you want to interpret unstructured text in an automated way.

Here are some examples of **use cases**:

- Processing PDF documents to extract parameters from them (implemented in this example package)
- Processing order information from unstructured text such as emails
- Processing incident information from unstructured text

> [!TIP]
> Feel free to [contact us](mailto:team.product.marketing@skyline.be) with additional use cases.

The package contains two **applications**:

- **Interactive File Prompt Tool**: Can be used to interact with the GPT model as you would do from the ChatGPT web interface, but from within DataMiner.
- **Satellite Parameter Extractor**: Uses a predefined prompt to read a set of parameters from PDF files containing satellite parameters.

## Key features

### Combination of OCR and LLM models

This sample package uses a combination of OCR (Optical Character Recognition) and LLM (Large Language Models, e.g. GPT-4o). When a file is uploaded by a user, an Automation script will first process the document using OCR and then send the plain text extracted from the file to an LLM together with a prompt for further interpretation.

### Satellite Parameter Extractor app

This app uses a predefined prompt in the background to process satellite parameters from PDF documents. When a user uploads a PDF file, the system will use the AI tools to process the information in the document and create a new satellite feed instance from it in [DOM](xref:DOM).

![Satellite Parameter Extractor app](~/dataminer/images/pdf_processing_AI_Satellite_Feed_Ingest.png)

### Interactive File Prompt app

This is very basic app that allows you to write any prompt, upload a file, and have it processed by AI tools. This tool can be used for any use case, going from asking the tool to tell a joke to uploading a document and asking the tool to get some data from the document.

![Interactive File Prompt app](~/dataminer/images/pdf_processing_interactive_prompt_tool_prompt.png)

## Pricing

The applications in this package will consume DataMiner credits, based on the level of usage of these apps. The DataMiner credits will be deducted monthly based on the metered usage. For more information about the pricing of DataMiner usage-based services, refer to the [DataMiner Pricing Overview](xref:Pricing_Usage_based_service).

## Support

For additional help or to discuss additional use cases, reach out to [Skyline Product Marketing](mailto:team.product.marketing@skyline.be).
