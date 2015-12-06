/*********************************************=ImagesCarousel=****************************************************************/

function InitImagesCarousel(carouselWrapperId) {
    var carouselWrapper = $("#" + carouselWrapperId);
    var carousel = carouselWrapper.find('.owl-carousel');
    carousel.owlCarousel({
        items: 1,
        lazyLoad: true,
        dotsSpeed: 800,
        //smartSpeed:3000,
        animateOut: 'fadeOut',
        //nav: true,
        //animateIn: 'fadeIn'
    });

    //new next-prev buttons
    //carouselWrapper.find('.owl-carousel-prev').click(function () {
    //    carousel.trigger('prev.owl.carousel', [800]);
    //});
    //carouselWrapper.find('.owl-carousel-next').click(function () {
    //    carousel.trigger('next.owl.carousel', [800]);
    //});
}

/*********************************************=Featured Articles Carousel=***************************************************/

function InitImagesCarousel(carouselWrapperId) {
    var carouselWrapper = $("#" + carouselWrapperId);
    var carousel = carouselWrapper.find('.owl-carousel');
    carousel.owlCarousel({
        items: 1,
        lazyLoad: true,
        //autoplay: true,
        autoplayTimeout: 1800,
        autoplayHoverPause: true,
        loop: true,
        dotsSpeed: 800,
        //smartSpeed:3000,
        animateOut: 'fadeOut',
        //nav: true,
        //animateIn: 'fadeIn'
    });

    //new next-prev buttons
    //carouselWrapper.find('.owl-carousel-prev').click(function () {
    //    carousel.trigger('prev.owl.carousel', [800]);
    //});
    //carouselWrapper.find('.owl-carousel-next').click(function () {
    //    carousel.trigger('next.owl.carousel', [800]);
    //});
}

/*********************************************=News Left Sidebar=***************************************************/

function InitNewsLeftSidebar(newsCategoryAllInt, yearAllInt, weAreOnTheNewsOverview, newsOverviewUrl) {
    var currentRoute = {};

    function dealWithRoute(year, category, page) {
        currentRoute = {
            year: decodeURIComponent(year),
            category: decodeURIComponent(category),
            page: decodeURIComponent(page)
        };
        //alert(currentRoute.year + " " + currentRoute.category + " " + currentRoute.page);

        $("a.news-link").removeClass('active');
        $("a.news-link[year=" + currentRoute.year + "]").addClass('active');
        $("a.news-link[category=" + currentRoute.category + "]").addClass('active');
        $("a.news-link[page=" + currentRoute.page + "]").addClass('active');

        $.ajax({
            url: '/umbraco/surface/News/Index/',
            type: 'POST',
            dataType: 'json',
            data: JSON.stringify(currentRoute),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                //alert(data.category);
            }
        });
    }

    var routes = {
        '/year/:year/category/:category/page/:page': dealWithRoute,
        '/': function () {
            dealWithRoute(yearAllInt, newsCategoryAllInt, 1);
        }
    };
    var router = Router(routes);
    router.init('/');
    //var hash = window.location.hash.slice(2);
    //router.setRoute('/');
    //router.setRoute(hash);

    $("a.news-link").on('click', function (e) {
        e.preventDefault();
        var year = $(this).attr('year');
        var category = $(this).attr('category');
        var page = $(this).attr('page');
        year = year === undefined ? currentRoute.year : year;
        category = category === undefined ? currentRoute.category : category;
        page = page === undefined ? currentRoute.page : page;

        var hash = 'year/' + encodeURIComponent(year) +
            '/category/' + encodeURIComponent(category) +
            '/page/' + encodeURIComponent(page);
        if (weAreOnTheNewsOverview) {
            router.setRoute(hash);
        } else {
            location.href = newsOverviewUrl + "#/" + hash;
        }
    });
}


/***************************************************=Disqus=******************************************************************/

function InitDisqus(identifier) {
    /* * * CONFIGURATION VARIABLES: EDIT BEFORE PASTING INTO YOUR WEBPAGE * * */
    window.disqus_shortname = 'helenbozhko'; // required: replace example with your forum shortname
    window.disqus_identifier = identifier;
    /* * * DON'T EDIT BELOW THIS LINE * * */
    (function () {
        var dsq = document.createElement('script'); dsq.type = 'text/javascript'; dsq.async = true;
        dsq.src = '//' + disqus_shortname + '.disqus.com/embed.js';
        (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(dsq);
    })();
}

/**********************************************=Scroll to top=***************************************************************/

function InitScrollToTop() {
    var identifier = ".scroll-to-top";

    $(window).scroll(function () {
        if ($(this).scrollTop() > 150) {
            $(identifier).fadeIn("slow");
        } else {
            $(identifier).fadeOut("slow");
        }
    });

    //Click event to scroll to top
    $(identifier).click(function () {
        $('html, body').animate({ scrollTop: 0 }, 800);
        return false;
    });
}

/*****************************************Google analytics******************************************************************/
(function (i, s, o, g, r, a, m) {
    i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
        (i[r].q = i[r].q || []).push(arguments);
    }, i[r].l = 1 * new Date(); a = s.createElement(o),
    m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g;
    m.parentNode.insertBefore(a, m);
})(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

ga('create', 'UA-54105375-4', 'auto');
ga('send', 'pageview');
/*End of Google analytics*/