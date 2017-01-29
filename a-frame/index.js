AFRAME.registerComponent('start-tour', {
  schema: {
    on: {type: 'string'},
    id: {type: 'string'}
  },

  init: function () {
    var data = this.data;
    var element = this.el;

    element.addEventListener(data.on, function () {
      // remove elements from homepage
    	var button = document.querySelector('#property');
      var title = document.querySelector('#title');
      button.parentNode.removeChild(button);
      title.parentNode.removeChild(title);

      constructTour(data.id);
	}); 
  }
});

function constructTour(id){
      console.log(id);
      // retreive virtual tour from Sitecore based off id (return type should be similar to json below)

      var roomList = '{ "rooms" : [{ "id":"thode" , "src":"images/pano2.jpeg" }, {"id":"livingRoom" , "src":"images/pano.jpeg" } ]}';
      var tour = JSON.parse(roomList);
      var currentRoom = 0;

      var assets = document.querySelector('a-assets');

      // add images for each of the rooms contained in the tour
      for (var i = 0; i < tour.rooms.length; i++){
        var image = document.createElement('img');
        assets.appendChild(image);
        image.setAttribute('id', tour.rooms[i].id);
        image.setAttribute('src', tour.rooms[i].src);
      }

      var sky = document.querySelector('#image-360');
      sky.setAttribute('material', 'src', '#'+ tour.rooms[0].id);

      var scene = document.querySelector('a-scene');
      var next = document.createElement('a-entity');
      var nextClick = document.createElement('a-entity');
      var previous = document.createElement('a-entity');
      var previousClick = document.createElement('a-entity');
      scene.appendChild(next);
      scene.appendChild(previous);
      scene.appendChild(nextClick);
      scene.appendChild(previousClick);

      next.setAttribute('position', '1, 1, -3');
      next.setAttribute('scale', '1.5 1.5 1.5');
      next.setAttribute('bmfont-text', 'text', 'Next Room');
      next.setAttribute('bmfont-text', 'color', '#000');

      nextClick.setAttribute('geometry', { primitive: 'sphere', radius: 0.2 });
      nextClick.setAttribute('material', 'color', 'red');
      nextClick.setAttribute('position', '0.75 1.1 -3');

      previous.setAttribute('position', '-2.5, 1, -3');
      previous.setAttribute('scale', '1.5 1.5 1.5');
      previous.setAttribute('bmfont-text', 'text', 'Previous Room');
      previous.setAttribute('bmfont-text', 'color', '#000');

      previousClick.setAttribute('geometry', { primitive: 'sphere', radius: 0.2 });
      previousClick.setAttribute('material', 'color', 'red');
      previousClick.setAttribute('position', '-2.8 1.1 -3');

      nextClick.addEventListener('click', function () {
          if (currentRoom < tour.rooms.length){
            currentRoom++;
          }
          sky.setAttribute('material', 'src', '#' + tour.rooms[currentRoom].id);
      });

      previousClick.addEventListener('click', function (){
          if (currentRoom > 0){
            currentRoom--;
          }
          sky.setAttribute('material', 'src', '#' + tour.rooms[currentRoom].id);
      });
}