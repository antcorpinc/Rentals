//function openPickup($event) {
//    $event.preventDefault();
//    $event.stopPropagation();
//}

$(document).ready(function () {
    openedPickup = true;
    $('#idopenpickup').click(function ($event) {
        $event.preventDefault();
        $event.stopPropagation();
        openedPickup = true;
    });
});