(function ($) {
    "use strict";

    //Spinner
    var spinner = function () {
        setTimeout(function () {
            if ($('#spinner').length > 0) {
                $('#spinner').removeClass('show');
            }
        }, 1);
    };
    spinner();
    // Initiate the wowjs
    new WOW().init();

})(jQuery);


const arry = [
    "Every Detail Dazzles",
    "Adding Sparkle to Every Work",
    "Transform Ordinary into Extraordinary",
    "Glittering Ideas, Lasting Results",
    "Your Vision, Our Glittering Execution",
    "Elevate Your Brand with a Touch of Glitter",
    "Elevate Your Story, Dazzle Your Audience",
    "Brilliance in Every Detail",
    "Let Your Ideas Sparkle",
    "Sparkle Beyond Expectations",
];
// Wrap every letter in a span
var textWrapper = $('div.slogans');

async function main() {
    do {
        for (let t of arry) {
            await new Promise(resolve => {
                setTimeout(() => {
                    resolve(fadeText(t))
                }, 3000);
            })
        }
    } while (true);
}
main().then();

function fadeText(t) {
    textWrapper.textContent = "";
    textWrapper.html("<span class='letter'>" + t + "</span>");
    anime.timeline({ loop: true })
        .add({
            targets: '.slogans .letter',
            translateX: [40, 0],
            translateZ: 0,
            opacity: [0, 1],
            easing: "easeOutExpo",
            duration: 1000,
            delay: (el, i) => 700 + 30 * i
        }).add({
            targets: '.slogans .letter',
            translateX: [0, -30],
            opacity: [1, 0],
            easing: "easeInExpo",
            duration: 1000,
            delay: (el, i) => 700 + 30 * i
        })
}

$("address").each(function () {
    var address = $(this).text() + "King Fahad street";
    address.replace(/\,/g, ' '); // get rid of commas
    var url = address.replace(/\ /g, '%20'); // convert address into approprite URI for google maps
    $(this).wrap('<a href="http://maps.google.com/maps?q=' + url + '" target="_blank"></a>');
});

// Wrap every letter in a span
//var textWrapperClient = document.querySelector('.ml11 .letters');
//textWrapperClient.innerHTML = textWrapperClient.textContent.replace(/([^\x00-\x80]|\w)/g, "<span class='letter'>$&</span>");

//anime.timeline({ loop: true })
//    .add({
//        targets: '.ml11 .line',
//        scaleY: [0, 1],
//        opacity: [0.5, 1],
//        easing: "easeOutExpo",
//        duration: 700
//    })
//    .add({
//        targets: '.ml11 .line',
//        translateX: [0, document.querySelector('.ml11 .letters').getBoundingClientRect().width + 10],
//        easing: "easeOutExpo",
//        duration: 700,
//        delay: 100
//    }).add({
//        targets: '.ml11 .letter',
//        opacity: [0, 1],
//        easing: "easeOutExpo",
//        duration: 600,
//        offset: '-=775',
//        delay: (el, i) => 34 * (i + 1)
//    }).add({
//        targets: '.ml11',
//        opacity: 0,
//        duration: 1000,
//        easing: "easeOutExpo",
//        delay: 1000
//    });

const mes = document.querySelector("h6.mes");
const info = document.querySelectorAll(".info");
info.forEach(el => {
    el.onclick = function () {
        document.execCommand("copy");
    }
    el.addEventListener("copy", function (event) {
        event.preventDefault();
        if (event.clipboardData) {
            mes.classList.add("show");
            event.clipboardData.setData("text/plain", el.textContent);
            console.log(event.clipboardData.getData("text") + mes.getAttribute("opacity"));
            setTimeout(() => {
                mes.classList.remove("show");
            }, 2000);
        }
    });
});

$('#ContactModal').on('shown.bs.modal', function () {
    $('input[name="Name"]').focus();
});


