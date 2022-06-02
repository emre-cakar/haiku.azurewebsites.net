
document.querySelector('#dropbox-sync').src = dropboxURI;

function openAttachment() {
    document.getElementById('attachment').click();
  }
  
  function fileSelected(input){
    document.getElementById('btnAttachment').value = "Resim : " + input.files[0].name
  }

[
{
  src: 'https://upload.wikimedia.org/wikipedia/commons/9/9b/Logo_of_Google_Drive.png',
  title: 'Google Drive',
  body: 'Configure to sync design and code files from Google Drive' },

{
  icon: 'ion-social-dropbox',
  title: 'Dropbox Sync',
  body: 'Configure to sync design and code files from Dropbox' },

{
  src: 'https://upload.wikimedia.org/wikipedia/en/8/88/Adobe_Creative_Cloud_Logo.png',
  title: 'Adobe Creative Cloud',
  body: 'Configure to sync design and code files from Adobe Creative Cloud' },

{
  src: 'https://upload.wikimedia.org/wikipedia/commons/0/00/Box_cyan.png',
  title: 'Box',
  body: 'Configure to sync design and code files from Box' },

{
  src: 'https://upload.wikimedia.org/wikipedia/en/f/f0/ICloud_logo_%28new%29.png',
  title: 'iCloud',
  body: 'Configure to sync design and code files from iCloud' }];

