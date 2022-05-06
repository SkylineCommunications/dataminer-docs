$(function () {
  console.log('search.js loaded');

  let parent = $('#search').parent();

  // Gets the old search box and removes the html
  $('#search').remove();

  // Add a search button to the navbar where the search used to be located.
  const button = $('<button class="search-button navbar-form navbar-right"><i class="glyphicon glyphicon-search"></i></button>');
  parent.append(button);


  const searchBox = searchOverlay();
  searchOverlayToggle(button);

  // creates the hidden search overlay in the html body.
  function searchOverlay() {
    // add hidden overlay to body.
    const overlay = $('<div id="overlay"><div id="overlay-content" class="overlay-content"><span class="closebtn" title="Close">&times;</span></div><div class="overlay-results"></div></div>');
    $('body').append(overlay);

    const searchBox = $('<input id="searchinput" type="text" placeholder="Search.." name="search">');
    $('#overlay-content').append(searchBox);

    // search on Text change
    searchBox.on('keyup', delay(function (event) {
      search();
    }, 250));
  }

  //the delay function I got from
	//https://stackoverflow.com/questions/1909441/how-to-delay-the-keyup-handler-until-the-user-stops-typing
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

  // shows or hides the search overlay
  function searchOverlayToggle(searchButton) {
  
    searchButton.on('click', function () {
      // show the overlay
      $('#overlay').show();
      // remove the outer scroll bar 
      $('html, body').css('overflowY', 'hidden'); 
      // focus the input box
      $('#searchinput').focus();
    });
    
    //the close button in the overlay
	var closeSearch = $('.closebtn');
    //attach a click handler to the close icon
    closeSearch.on('click', function () {
      $('#overlay').hide(); //hide the overlay
      $('html, body').css('overflowY', 'auto'); //add the outer scroll bar
    });
  }

  //the actual search function
	function search() {
		// my api key
		var apikey = '444C49DF0A7CC8D8B8FDF188A3BC3D19';
		// get the search query
		var query = $('#searchinput').val();

		// properly encode it for the URL
		var encodedQuery = encodeURIComponent(query);
    
    const url = 'https://srch-docs-001.search.windows.net/indexes/docs-index-001/docs?api-version=2021-04-30-Preview&$top=10&search=' + encodedQuery + '&api-key=' + apikey;
  
    searchUrl(url);
	}

  function searchUrl(url) {
    // build the ajax call with the query url and the api key
    $.ajax({
      type: "GET",
      url: url,
      dataType: "json",
      success: function (data) {
        processSearchResults(data);
      }
    });
  }

  function processSearchResults(data) {
    // clear the old results
    const resultElement = $(".overlay-results");
    resultElement.empty();

    // required for the "no results" template
    data.noResults = !data.value || data.value.length < 1;

    if (data.noResults) {
      // no results found
      resultElement.append(resultElement.html('<p>No results found</p>'));
    } else {
      // loop through the results and add them to the overlay
      const html = [];
      for (let i = 0; i < data.value.length; i++) {
        const result = data.value[i];
        const relativeUrl = GetUrlFromResult(result);
        html.push('<div class="result"><a href="' + 'relativeUrl' + '">' + result.metadata_title + '</a></div>');
      }
      resultElement.append(html.join(''));
    }
  }

  function GetUrlFromResult(res) {
    let path = res.metadata_storage_path;

    // base64 decode the path
    console.log(path)
    path = utoa(encodeURIComponent(path));

    console.log(path)

    // path = path.replace(/\\/g, '/');


    return path;
  }

  function b64DecodeUnicode(str) {
    // Going backwards: from bytestream, to percent-encoding, to original string.
    return decodeURIComponent(atob(str).split('').map(function(c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));
}
});
