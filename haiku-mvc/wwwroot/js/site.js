// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function openAttachment() {
  document.getElementById('attachment').click();
}

function fileSelected(input){
  document.getElementById('btnAttachment').value = "Resim : " + input.files[0].name
}

function gizleGoster(clickedID){
  const obj = document.querySelector(clickedID);
  obj.replace('d-none', 'd-block');
}
