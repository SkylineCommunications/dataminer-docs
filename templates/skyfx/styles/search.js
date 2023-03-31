$(function () {
  const docFxSearchBox = $('#search');
  let parent = docFxSearchBox.parent();

  // remove the old search box
  docFxSearchBox.remove();

  // Add html for search button
  parent.append('<div class="navbar-right"><button id="new-search-btn" class="btn navbar-btn search-button"><i class="glyphicon glyphicon-search"></i></button></div>');

  createSearchResultsNewHtml();
  initEventHandlersCloseOpenSearch();

  function createSearchResultsNewHtml() {
    // default search must be deactivated
    const html = $('<div class="container body-content"><div id="search-results-new"><div id="search-box"><button id="search-close-btn" class="btn btn-link">Close search</button></div><div id="search-result-items"></div></div></div>');
    // add as between header and div with content to hide
    html.insertBefore('.container.body-content.hide-when-search');

    const searchBox = $('<input id="search-input" type="search" placeholder="Search..." autocomplete="off">');
    $('#search-box').append(searchBox);

    // init event handler
    searchBox.keyup(delay(function (event) {
      search($(this).val());
    }, 250))

  }

  function delay(callback, ms) {
    var timer = 0;
    return function () {
      var context = this, args = arguments;
      clearTimeout(timer);
      timer = setTimeout(function () {
        callback.apply(context, args);
      }, ms || 0);
    };
  }

  function getTitle(str) {
    const endsWith = "| DataMiner Docs"

    if (str.length >= endsWith.length) {
      const lastIndex = str.lastIndexOf(endsWith);
      if (lastIndex === (str.length - endsWith.length)) {
        // strings ends with endsWith
        return str.slice(0, lastIndex);
      }
    }
    return str;


  }

  function getUrl(str) {
    // example url: "https://docshelp.blob.core.windows.net/docs/user-guide/Advanced_Functionality/DataMiner_Systems/DataminerSystems.html"
    const startsWith = "https://docshelp.blob.core.windows.net/docs/"

    if (str.startsWith(startsWith)) {
      return `https://docs.dataminer.services/${str.substring(startsWith.length)}`;
    }
    return str;
  }

  function initEventHandlersCloseOpenSearch() {

    $('#new-search-btn').click(function () {
      showSearch(true);
      $('#search-input').focus();
    });

    //attach a click handler to the close icon
    $('#search-close-btn').click(function () {
      showSearch(false);
      clearResults();
      clearSearchInput();
    });

  }

  function search(searchTerm) {
    if (searchTerm.length) {
      doGetHttpRequest(searchTerm);
    } else {
      clearResults();
    }
  }

  function doGetHttpRequest(searchTerm) {
    var url = `https://docs-srch.search.windows.net/indexes/docs-blob-index2/docs/search?api-version=2021-04-30-Preview&api-key=5630827C003AFD513AA4D8D21A0A79B7`;
    var searchTermEnhanced = searchTerm;
    var pattern = /[a-zA-Z]$/;
    if (pattern.test(searchTermEnhanced)) {
      searchTermEnhanced += "*";
    }
    var body= '{"search": \'' + searchTermEnhanced + '\',"searchMode": "all","queryType": "full","top": 200}';
    $.ajax({
      type: 'POST',
      url: url,
      contentType: 'application/json',
      dataType: 'json',
      data: body,
      success: function (data) {
        processSearchResults(data, searchTerm);
      },
      error: function(XMLHttpRequest, textStatus, errorThrown) {
        clearResults();
        addHtmlToResultElement('<p>Unsupported search query.</p>');
      }
    });
  }

  function clearResults() {
    const resultElement = $("#search-result-items");
    resultElement.empty();
  }

  function clearSearchInput() {
    $('#search-input').val('');
  }

  function addHtmlToResultElement(html) {
    const resultElement = $("#search-result-items");
    resultElement.append(html);
  }

  function processSearchResults(data, searchTerm) {
    clearResults();

    if (!data.value || data.value.length < 1) {
      addHtmlToResultElement('<p>No results found.</p>')
    } else {
      const html = [];

      for (const result of data.value) {
        if (result.metadata_storage_name !== "toc.html" && result.metadata_title !== null) {
          // results with toc.html files (table of contents) + without title are skipped
          const title = getTitle(result.metadata_title);
          const url = getUrl(result.storage_path);
          const htmlString = `<div class="result"><a href="${url}?q=${encodeURIComponent(searchTerm)}"><div class="url">${url}</div><div class="title">${title}</div></a></div>`;
          html.push(htmlString)
        }

      }

      addHtmlToResultElement(html.join(''))
    }
  }

  function showSearch(showSearch) {
    if (showSearch) {
      $('.hide-when-search').hide();
      $('#search-results-new').show();
    } else {
      $('.hide-when-search').show();
      $('#search-results-new').hide();
    }
  }

});
