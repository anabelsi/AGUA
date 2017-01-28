AFRAME.registerComponent('update-tiles', {
  schema: {
    on: {type: 'string'},
		tileNum: {type: 'int'},
    goBack: {type: 'boolean'}
  },

  init: function () {
    var data = this.data;
    var element = this.el;

		if(typeof(Storage) == "undefined") {
			console.error('Storage undefined');
			return;
		}


    element.addEventListener(data.on, function () {
      updateTiles(data.tileNum, data.goBack);
		});

		console.log(data.tileNum);
		if (data.tileNum == 0) {
			sessionStorage.state = 'init';
			updateTiles(null, false);
		}

  }
});

function updateTiles(tileNum, goBack){
	console.log('updateTiles - ' + tileNum + ' ' + goBack + ' ' + sessionStorage.state);

	var sceneEl = document.querySelector('a-scene');

	if (goBack) {
		if (sessionStorage.state == 'categories') {
			return;
		} else if (sessionStorage.state == 'subcategories') {
			sessionStorage.state = 'init';
			var categoryText = sceneEl.querySelector('#category-text');
			categoryText.setAttribute('bmfont-text', 'text: ; color: #BBB');
		} else if (sessionStorage.state == 'properties') {
			sessionStorage.state = 'categories';
			tileNum = sessionStorage.categoryTileNum;
			var subcategoryText = sceneEl.querySelector('#subcategory-text');
			subcategoryText.setAttribute('bmfont-text', 'text: ; color: #BBB');
		}
	}

	var categoriesArray = ['Price', 'Style', 'Location'];
	var categoriesDict = {
		'Price': ['< $200,000', '$200,000 - $499,999', '$500,000 - $699,999', '$700,000 - $1,000,000', '> $1,000,000'],
		'Style': ['Bachelor', 'Apartment - 1 bedroom', 'Apartment - 2 bedroom', 'House - 2 bedroom'],
		'Location': ['Downtown Toronto', 'GTA', 'Hamilton', 'Kitchener/Waterloo'
	]};

	if (sessionStorage.state == 'init') {
		var optionBoxes = sceneEl.querySelectorAll('[mixin=option]');
		for (var i = 0; i < optionBoxes.length; i++) {
			var textBox = optionBoxes[i].querySelector('[bmfont-text]');
			var newText = '';
			if (i < categoriesArray.length) {
				newText = categoriesArray[i];
			}
			textBox.setAttribute('bmfont-text', 'text: ' + newText + '; color: #FFF');
		}

		sessionStorage.state = 'categories';
	} else if (sessionStorage.state == 'categories') {
		if (tileNum >= categoriesArray.length) {
			return;
		}

		var selectedCategory = categoriesArray[tileNum];
		var categoryText = sceneEl.querySelector('#category-text');
		categoryText.setAttribute('bmfont-text', 'text: ' + selectedCategory + '; color: #BBB');

		sessionStorage.categoryTileNum = tileNum;

		var optionBoxes = sceneEl.querySelectorAll('[mixin=option]');
		var subcategories = categoriesDict[selectedCategory];
		for (var i = 0; i < optionBoxes.length; i++) {
			var textBox = optionBoxes[i].querySelector('[bmfont-text]');
			var newText = '';
			if (i < subcategories.length) {
				newText = subcategories[i];
			}
			textBox.setAttribute('bmfont-text', 'text: ' + newText + '; color: #FFF');
		}

		sessionStorage.state = 'subcategories';
	} else if (sessionStorage.state == 'subcategories') {
		var selectedCategory = categoriesArray[sessionStorage.categoryTileNum];
		if (tileNum >= categoriesDict[selectedCategory].length) {
			return;
		}
		var selectedSubcategory = categoriesDict[selectedCategory][tileNum];
		var subcategoryText = sceneEl.querySelector('#subcategory-text');
		subcategoryText.setAttribute('bmfont-text', 'text: ' + selectedSubcategory + '; color: #BBB');

		sessionStorage.subcategoryTileNum = tileNum;

		var optionBoxes = sceneEl.querySelectorAll('[mixin=option]');
		for (var i = 0; i < optionBoxes.length; i++) {
			var textBox = optionBoxes[i].querySelector('[bmfont-text]');
			textBox.setAttribute('bmfont-text', 'text: Property ' + (i + 1) + '; color: #FFF');
		}

		sessionStorage.state = 'properties';
	}

}
