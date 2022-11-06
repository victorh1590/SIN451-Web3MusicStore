function disablePlayAll(element) {
  var buttons = document.querySelectorAll('[id=play-btn]');
  for (var i = 0; i < buttons.length; i++) {
    if(!(buttons[i].classList.item(0) === element.classList.item(0))) {
      buttons[i].innerHTML = '<i class="fa-solid fa-play"></i>';

    }
  }
}

function enablePlayClicked(element) {
  var newElement = element;

  console.log(newElement.innerHTML === '<i class="fa-solid fa-pause"></i>');
  if(newElement.innerHTML === '<i class="fa-solid fa-pause"></i>') {
    newElement.innerHTML = '<i class="fa-solid fa-play"></i>';
  }
  else {
    newElement.innerHTML = '<i class="fa-solid fa-pause"></i>';
  }
}