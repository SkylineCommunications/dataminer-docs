---
uid: implementation_details_the_apps_processing_pdf_documents
---

# Implementation Details

This page explains in detail how the sample applications have been built and allow to easily start from this sample to build your own solution that levarages LLM models to transform unstructured data from within DataMiner. Source code of this solution can be found on [GitHub](https://github.com/SkylineCommunications/SLC-TextAnalysisDemo).

## Interactive Prompt Tool

The Run Prompt button launches the interactive automation script *SLC_TextAnalysis_Prompt* which allows to upload a document and enter text. The automation will execute the following:

1. Process the file using the Document Intelligence AI service. The AI service will return markdown formatted text to the script.

1. Provide the user input text together with the markdown formatted text to the LLM model configured

1. Write the name of the file that the user entered, together with the response from the LLM to the script output which is returned to the Low-Code app.

1. In the LCA, the script outputs from the Run Prompt button are used to visualize the name of the file that was entered and the response from the model.

## Satellite Parameter Extractor

The Load From File button launches an interactive automation script *SLC-TextAnalysis-Upload* which allow to enter a document that contains a information on a Satellite Feed. After uploading the document and storing it on DataMiner, a subscript *SLC_TextAnalysis_Script* is run that will process the file using the following steps:

1. Process the file using the Document Intelligence AI service. The AI service will return markdown formatted text to the script.

1. Provide the markdown formatted text from the document to the LLM together with a predefined prompt. The script uses the text file in the DataMiner documents folder */AI-sample/* called *Extract_Parameters_Prompt.txt* as predefined prompt. The prompt defines the parameters to be returned, the format of the response and some additional rules to make the response more reliable.

1. Provide the response from the previous step together with a list of potential values for the parameters. The LLM model will intelligently map the raw results from the documents to the predefined values. The script will give these predefined values to the LLM by filling in placeholders in the prompt specified in the text file in the DataMiner documents folder */AI-sample/* called *Map_Parameters_Prompt.txt*. Currently, it will do this by reading the possible enum values for the parameters in the predefined [DOM](xref:DOM) model. Virtually, the script can fetch this information from any source on DataMiner or external to DataMiner (e.g. SRM parameters, DOM tables, ...).

1. It will use the results from the LLM models to create two DOM instances. It will create one instance that contain the raw values for the extracted parameters from the document (not shown in the app), and another containing the mapped results.

1. The app visualizes a list of the processed documents (on the left), together with an embedded view of the PDF and the mapped parameters extracted from the parameters (on the right).
