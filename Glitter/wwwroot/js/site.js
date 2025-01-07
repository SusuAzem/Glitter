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


    // Sticky Navbar
    $(window).scroll(function () {
        if ($(this).scrollTop() > 45) {
            $('.navbar').addClass('sticky-top');
        } else {
            $('.navbar').removeClass('sticky-top');
        }
    });

    // Dropdown on mouse hover
    //const $dropdown = $(".dropdown");
    //const $dropdownToggle = $(".dropdown-toggle");
    //const $dropdownMenu = $(".dropdown-menu");
    //const showClass = "show";

    //$(window).on("load resize", function () {
    //    if (this.matchMedia("(min-width: 992px)").matches) {
    //        $dropdown.hover(
    //            function () {
    //                const $this = $(this);
    //                $this.addClass(showClass);
    //                $this.find($dropdownToggle).attr("aria-expanded", "true");
    //                $this.find($dropdownMenu).addClass(showClass);
    //            },
    //            function () {
    //                const $this = $(this);
    //                $this.removeClass(showClass);
    //                $this.find($dropdownToggle).attr("aria-expanded", "false");
    //                $this.find($dropdownMenu).removeClass(showClass);
    //            }
    //        );
    //    } else {
    //        $dropdown.off("mouseenter mouseleave");
    //    }
    //});


})(jQuery);

//const sections = document.querySelectorAll('section');
//const config = {
//    rootMargin: '0px 0px -55%'
/*};*/
//rootMargin: '-50px 0px -55%'

//let observer = new IntersectionObserver(function (entries, self) {
//    entries.forEach(entry => {
//        console.log(entry);
//        if (entry.isIntersecting) {
//            intersectionHandler(entry);
//        }
//    });
//}, config);

//sections.forEach(section => {
//    observer.observe(section);
//});

//function intersectionHandler(entry) {
//    const id = entry.target.id;
//    const currentlyActive = document.querySelector('.navbar-nav a.active');
//    const shouldBeActive = document.querySelector('.navbar-nav a[href="#' + id + '"]');

//    if (currentlyActive) {
//        currentlyActive.classList.remove('active');
//    }
//    if (shouldBeActive) {
//        shouldBeActive.classList.add('active');
//    }
//}

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
                    console.log(t);
                    resolve(fadeText(t))
                }, 3000);
                setTimeout(() => {
                    resolve(ballrotation());
                }, 11000);
            })
        }
    } while (true);
}
main().then();

function fadeText(t) {
    textWrapper.textContent = "";
    textWrapper.html("<span class='letter'>"+t+"</span>");
    console.log(t);
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
var textWrapperClient = document.querySelector('.ml11 .letters');
textWrapperClient.innerHTML = textWrapperClient.textContent.replace(/([^\x00-\x80]|\w)/g, "<span class='letter'>$&</span>");

anime.timeline({ loop: true })
    .add({
        targets: '.ml11 .line',
        scaleY: [0, 1],
        opacity: [0.5, 1],
        easing: "easeOutExpo",
        duration: 700
    })
    .add({
        targets: '.ml11 .line',
        translateX: [0, document.querySelector('.ml11 .letters').getBoundingClientRect().width + 10],
        easing: "easeOutExpo",
        duration: 700,
        delay: 100
    }).add({
        targets: '.ml11 .letter',
        opacity: [0, 1],
        easing: "easeOutExpo",
        duration: 600,
        offset: '-=775',
        delay: (el, i) => 34 * (i + 1)
    }).add({
        targets: '.ml11',
        opacity: 0,
        duration: 1000,
        easing: "easeOutExpo",
        delay: 1000
    });