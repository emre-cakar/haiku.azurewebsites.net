

function openAttachment() {
    document.getElementById('attachment').click();
}

function fileSelected(input) {
    document.getElementById('btnAttachment').value = "Resim : " + input.files[0].name;
}

function profilgizleGoster() {
    alert("Hello");
    /*const obj = document.querySelector('#profil');
    obj.replace('d-none', 'd-block');*/
}

function guvenlikgizleGoster() {
    alert("Hello");
    /*const obj = document.querySelector('#guvenlik');
    obj.replace('d-none', 'd-block');*/
}

    function bildirimgizleGoster() {
    alert("Hello");
    /*const obj = document.querySelector('#bildirim');
    obj.replace('d-none', 'd-block');*/
}
