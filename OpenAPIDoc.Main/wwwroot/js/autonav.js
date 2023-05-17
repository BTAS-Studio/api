// cache the navigation links 
var $navigationLinks = $('ul.vertical-nav-menu > li > a');
// cache (in reversed order) the sections
var $sections = $($(".app-inner-layout__content, .method").get().reverse());

let $curNav = null;
var $curParent, $curPos;

// map each section id to their corresponding navigation link
var sectionIdTonavigationLink = {};
$sections.each(function () {
    var id = $(this).attr('id');
    sectionIdTonavigationLink[id] = $('ul.vertical-nav-menu > li > a[href=\\#' + id + ']');
    if (sectionIdTonavigationLink[id].length <= 0) {
        sectionIdTonavigationLink[id] = $('ul.methodNav > li > a[href=\\#' + id + ']');
    }
});

// throttle function, enforces a minimum time interval
function throttle(fn, interval) {
    var lastCall, timeoutId;
    return function () {
        var now = new Date().getTime();
        if (lastCall && now < (lastCall + interval)) {
            // if we are inside the interval we wait
            clearTimeout(timeoutId);
            timeoutId = setTimeout(function () {
                lastCall = now;
                fn.call();
            }, interval - (now - lastCall));
        } else {
            // otherwise, we directly call the function 
            lastCall = now;
            fn.call();
        }
    };
}

function highlightNavigation() {
    // get the current vertical position of the scroll bar
    var scrollPosition = $(window).scrollTop();
    if (scrollPosition != $curPos) {
        $curPos = scrollPosition;
    } else {
        return false;
    }
    // iterate the sections
    setTimeout(function () {
        $sections.each(function () {
            var currentSection = $(this);
            // get the position of the section
            var sectionTop = currentSection.offset().top - 150;

            // if the user has scrolled over the top of the section  
            if (scrollPosition >= sectionTop) {
                // get the section id
                var id = currentSection.attr('id');

                // get the corresponding navigation link
                var $navigationLink = sectionIdTonavigationLink[id];
                var $parentNav = $navigationLink.parent().parent();

                if ($curNav != $navigationLink) {
                    if ($curNav != null) {
                        if ($curNav.parent().parent().prev().hasClass("methods") || $parentNav.prev().hasClass("methods")) {
                            if ($curNav.hasClass("methods")) {
                                $curNav.next().removeClass("mm-show");
                            }
                            $curNav.parent().parent().removeClass("mm-show");
                            $parentNav.addClass("mm-show").removeAttr("style");
                        }

                    }
                    $curNav = $navigationLink;
                    /*$curParent = $curNav.parent().parent();*/
                }
                // if the link is not active
                if (!$navigationLink.parent().hasClass('mm-active')) {
                    // remove .active class from all the links
                    $("li").removeClass("mm-active"); //$navigationLinks.parent().removeClass('mm-active');

                    // add .active class to the current link
                    $navigationLink.parent().addClass('mm-active');
                    /*  var $parentNav = $navigationLink.parent().parent();*/
                    if ($navigationLink.hasClass("methods")) {
                        $navigationLink.parent().addClass("mm-active")
                            .find("ul.methodNav").addClass("mm-show").removeAttr("style");
                    } else {
                        if ($parentNav.hasClass("methodNav")) {
                            $navigationLink.parent().addClass("mm-active")
                                .find("ul.methodNav").addClass("mm-show").removeAttr("style");
                            $parentNav.parent().addClass("mm-active");
                        } else {
                            $curNav.parent().removeClass("mm-show");
                        }
                    }

                }
                // we have found our section, so we return false to exit the each loop
                return false;
            }
        });
    }, 50);
    
}

//$(window).scroll(throttle(highlightNavigation, 100));

// if you don't want to throttle the function use this instead:
$(window).scroll(highlightNavigation);