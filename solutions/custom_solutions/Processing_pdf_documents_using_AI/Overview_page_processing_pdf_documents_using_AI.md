---
uid: processing_pdf_documents
---

# Sample solutions: processing PDF documents using AI

## About

This sample package shows how cloud AI tools, such as OCR (Optical Character Recognition) & LLM (Large Language Models, e.g. GPT-4o) can be integrated with DataMiner to automate steps in a DataMiner powered operational workflow. This allows to facilitate any use-case where you want to interpret unstructured text in an automated way. Examples of **use-cases** are the following:

- Process PDF documents to extract parameters from it (implemented in this example)
- Processing order information from unstructured text such as emails
- Processing incident information from unstructured text
- ... (feel free to contact us with use-cases)

The package contains two **applications**:

- Interactive File Prompt Tool: can be used to interact with the GPT model as you would do from the ChatGPT web interface but from within DataMiner
- Satellite Parameter Extractor: uses a predefined prompt to read a set of parameters from PDF files containing satellite parameters

## Key Features

### Combination of OCR and LLM models

The sample package uses a combination of OCR (Optical Character Recognition) & LLM (Large Language Models, e.g. GPT-4o) for the applications described in more detail in the following sections. When a file is uploaded by the user, an automation script will first process the document using OCR and will send the plain text extracted from the file to an LLM together with a prompt for further interpretation.

### Satellite Parameter Extractor

This app uses a predefined prompt in the background to process Satellite parameters from PDF documents. The user simply uploads a PDF file and the system will use the AI tools to process the information in the document and create a new Satellite Feed instance from it in [DOM](https://docs.dataminer.services/solutions/Advanced_Modules/DOM/DOM.html?q=dataminer%20object%20mo).

 ![Satellite Parameter Extractor App](~/solutions/images/processing_pdf_documents_using_AI/pdf_processing_AI_Satellite_Feed_Ingest.png)

### Interactive File Prompt App

This is very basic app which allows the user to write any prompt and upload a file and have it processed by AI tools. It allows the user to write a prompt and upload a file and the tool will process the file and prompt together using the AI tools described [above](#combination-of-ocr-and-llm-models).

The tool can be used for any use-case, going from asking the tool to tell a joke, to uploading a document and ask the tool to get some data from the document (see the example below).

 ![Interactive File Prompt App](~/solutions/images/processing_pdf_documents_using_AI/pdf_processing_interactive_prompt_tool_prompt.png)
