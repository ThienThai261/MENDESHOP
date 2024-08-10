//function toggleSearchPopup() {
//    var popup = document.getElementById('search-popup');
//    if (popup.style.display == 'none') {
//        popup.style.display = 'block';
//    } else {
//        popup.style.display = 'none';
//    }
//}
////function togAcount() {
////    var popu = document.getElementById('Acou-popup');
////    if (popu.style.display === 'none') {
////        popu.style.display = 'block';
////    } else {
////        popu.style.display = 'none';
////    }
////}
function toggleSearchPopup() {
    var searchPopup = document.getElementById("search-popup");
    searchPopup.classList.toggle("show-search-popup");
}

function toggleUserInfo() {
    var userInfoPopup = document.getElementById("user-info-popup");
    userInfoPopup.classList.toggle("show-user-info-popup");
}