function openAttachment() {
    document.getElementById('attachment').click();
}

function profilGoster() {
    //profil kısmını görünür yap
    const obj = document.querySelector('#profil');
    obj.classList.remove('d-none');
    //güvenlik ve bildirim kısmını görünmez yap
    const obj2 = document.querySelector('#guvenlik');
    obj2.classList.add('d-none');
    const obj3 = document.querySelector('#bildirim');
    obj3.classList.add('d-none');
}

function guvenlikGoster() {
    //güvenlik kısmını görünür yap
    const obj = document.querySelector('#guvenlik');
    obj.classList.remove('d-none');
    //profil ve bildirim kısmını görünmez yap
    const obj2 = document.querySelector('#profil');
    obj2.classList.add('d-none');
    const obj3 = document.querySelector('#bildirim');
    obj3.classList.add('d-none');
}

function bildirimGoster() {
    //bildirim kısmını görünür yap
    const obj = document.querySelector('#bildirim');
    obj.classList.remove('d-none');
    //profil ve guvenlik kısmını görünmez yap
    const obj2 = document.querySelector('#profil');
    obj2.classList.add('d-none');
    const obj3 = document.querySelector('#guvenlik');
    obj3.classList.add('d-none');
}
