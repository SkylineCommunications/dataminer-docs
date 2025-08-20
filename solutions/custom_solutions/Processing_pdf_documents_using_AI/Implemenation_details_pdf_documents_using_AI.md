---
uid: implementation_details_the_apps_processing_pdf_documents
---

# Implementation Details

This page explains in detail how the sample applications have been built. This way, you will easily be able to start from this sample to build your own solution that leverages LLM models to transform unstructured data from within DataMiner.

You can start from the source code of this solution, which is available on [GitHub](https://github.com/SkylineCommunications/SLC-TextAnalysisDemo).

## Interactive File Prompt app

The *Run Prompt* button launches the interactive Automation script *SLC_TextAnalysis_Prompt*, which allows users to upload a document and enter text.

The script will execute the following steps:

1. Process the file using the Document Intelligence AI service.

   The AI service will return Markdown-formatted text to the script.

1. Provide the user input text together with the Markdown-formatted text to the configured LLM model.

1. Write the name of the file that the user entered, together with the response from the LLM, to the script output, which is returned to the low-code app.

1. In the low-code app, use the output from the previous steps to visualize the name of the file that was entered and the response from the model.

## Satellite Parameter Extractor app

The *Load From File* button launches an interactive Automation script *SLC-TextAnalysis-Upload*, which allows users to enter a document that contains information on a satellite feed. After the document is uploaded and stored in DataMiner, a subscript *SLC_TextAnalysis_Script* is run that will process the file using the following steps:

1. Process the file using the Document Intelligence AI service.

   The AI service will return Markdown-formatted text to the script.

1. Provide the Markdown-formatted text from the document to the LLM together with a predefined prompt.

   The script uses the text file *Extract_Parameters_Prompt.txt* in the DataMiner documents folder */AI-sample/* as a predefined prompt. The prompt defines the parameters to be returned, the format of the response, and some additional rules to make the response more reliable.

1. Provide the response from the previous step together with a list of potential values for the parameters.

   The LLM model will intelligently map the raw results from the documents to the predefined values. The script will give these predefined values to the LLM by filling in placeholders in the prompt specified in the text file *Map_Parameters_Prompt.txt* in the DataMiner documents folder */AI-sample/*. Currently, it will do this by reading the possible enum values for the parameters in the predefined [DOM](xref:DOM) model. The script can fetch this information from virtually any source in DataMiner or external to DataMiner (e.g. SRM parameters, DOM tables, etc.).

1. Use the results from the LLM models to create two DOM instances.

   The script will create one instance containing the raw values for the extracted parameters from the document (not shown in the app) and another containing the mapped results.

1. Visualize a list of the processed documents (on the left), together with an embedded view of the PDF and the mapped parameters extracted from the parameters (on the right).
