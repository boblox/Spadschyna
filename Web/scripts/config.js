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

function InitFeaturedArticlesCarousel(carouselWrapperId) {
    var carouselWrapper = $("#" + carouselWrapperId);
    var carousel = carouselWrapper.find('.owl-carousel');
    carousel.owlCarousel({
        items: 1,
        lazyLoad: true,
        autoplay: true,
        autoplayTimeout: 4500,
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
    function updateRoute(route, el) {
        var year = $(el).attr('year');
        var category = $(el).attr('category');
        var page = $(el).attr('page');
        route.year = year === undefined ? route.year : year;
        route.category = category === undefined ? route.category : category;
        route.page = page === undefined ? route.page : page;
    }

    function getInitRoute() {
        var route = {
            year: yearAllInt,
            category: newsCategoryAllInt,
            page: 1
        };
        $("a.news-link.active").each(function () {
            updateRoute(route, $(this));
        });
        return route;
    }

    function bindControllers(route, router) {
        $("a.news-link").off('click');

        $("a.news-link").on('click', function (e) {
            e.preventDefault();
            updateRoute(route, this);

            var hash = 'year/' + encodeURIComponent(route.year) +
                '/category/' + encodeURIComponent(route.category) +
                '/page/' + encodeURIComponent(route.page);
            if (weAreOnTheNewsOverview) {
                router.setRoute(hash);
            } else {
                location.href = newsOverviewUrl + "#/" + hash;
            }
        });
    }

    function dealWithRoute(route, router) {
        //If it's NewsItem page then it is set on server side
        if (weAreOnTheNewsOverview) {
            $("a.news-link").removeClass('active');
            $("a.news-link[year=" + route.year + "]").addClass('active');
            $("a.news-link[category=" + route.category + "]").addClass('active');
            $("a.news-link[page=" + route.page + "]").addClass('active');

            $.ajax({
                url: '/umbraco/surface/News/Index/',
                type: 'POST',
                dataType: 'html',
                data: JSON.stringify(route),
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    $("#news-list").html(data);
                    bindControllers(route, router);
                    //alert(data.category);
                },
                error: function (request, status) {
                    showDialog("Вибачте, не можливо завантажити новини");
                }
            });
        }
    }

    var routes = {
        '/year/:year/category/:category/page/:page':
            function (year, category, page) {
                currentRoute = {
                    year: decodeURIComponent(year),
                    category: decodeURIComponent(category),
                    page: decodeURIComponent(page)
                };
                dealWithRoute(currentRoute, router);
            },
        '/': function () {
            currentRoute = getInitRoute();
            dealWithRoute(currentRoute, router);
        }
    };
    var currentRoute = getInitRoute();
    var router = Router(routes);

    //Routing should work only on NewsOverview page
    if (weAreOnTheNewsOverview) {
        router.init('/');
    }

    //var hash = window.location.hash.slice(2);
    //router.setRoute('/');
    //router.setRoute(hash);

    bindControllers(currentRoute, router);
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