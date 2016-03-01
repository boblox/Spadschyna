[
    {
        "name": "Редактор тексту",
        "alias": "rte",
        "view": "rte",
        "icon": "icon-article"
    },
    {
        "name": "Редактор тексту, який вміє складатись",
        "alias": "collapsible-rte",
        "render": "/App_Plugins/Grid/Editors/Render/collapsible-rte.cshtml",
        "view": "/App_Plugins/Grid/Editors/Views/collapsible-rte.html",
        "icon": "icon-article",
        "config": {
            "style": "font-size: 25px; line-height: 35px; font-weight: normal; color: white;"
        }
    },
    {
        "name": "Світлина",
        "alias": "media",
        "view": "media",
        "icon": "icon-picture"
    },
    {
        "name": "Макро",
        "alias": "macro",
        "view": "macro",
        "icon": "icon-settings-alt"
    },
    {
        "name": "Відео",
        "alias": "embed",
        "view": "embed",
        "icon": "icon-movie-alt"
    },
    {
        "name": "Маленький заголовок",
        "alias": "headline-small",
        "view": "textstring",
        "icon": "icon-forms-paypal",
        "config": {
            "style": "font-size: 18px; line-height: 22px; font-weight:bold;",
            "markup": "<h4>#value#</h4>"
        }
    },
    {
        "name": "Нормальний заголовок",
        "alias": "headline-normal",
        "view": "textstring",
        "icon": "icon-forms-paypal",
        "config": {
            "style": "font-size: 22px; line-height: 27px; font-weight:bold;",
            "markup": "<h3>#value#</h3>"
        }
    },
    {
        "name": "Великий заголовок",
        "alias": "headline-big",
        "view": "textstring",
        "icon": "icon-forms-paypal",
        "config": {
            "style": "font-size: 30px; line-height: 37px; font-weight:bold;",
            "markup": "<h2>#value#</h2>"
        }
    },
    {
        "name": "Кольоровий заголовок",
        "alias": "coloured-header",
        "render": "/App_Plugins/Grid/Editors/Render/coloured-header.cshtml",
        "view": "/App_Plugins/Grid/Editors/Views/coloured-header.html",
        "icon": "icon-forms-paypal",
        "config": {
            "style": "font-size: 25px; line-height: 35px; font-weight: normal; color: white;"
        }
    },
    {
        "name": "Цитата",
        "alias": "quote",
        "view": "textstring",
        "icon": "icon-quote",
        "config": {
            "style": "border-left: 3px solid #ccc; padding: 10px; color: #ccc; font-family: serif; font-variant: italic; font-size: 18px",
            "markup": "<blockquote>#value#</blockquote>"
        }
    },
    {
        "name": "Карусель світлин",
        "alias": "Carousel",
        "view": "/App_Plugins/LeBlender/editors/leblendereditor/LeBlendereditor.html",
        "icon": "icon-layers-alt",
        "render": "/App_Plugins/LeBlender/editors/leblendereditor/views/Base.cshtml",
        "config": {
            "editors": [
                {
                    "name": "Images",
                    "alias": "images",
                    "propretyType": {},
                    "dataType": "7e3962cc-ce20-4ffc-b661-5897a894ba7e"
                }
            ],
            "renderInGrid": "1",
            "frontView": "",
            "max": null
        }
    },
    {
        "name": "Галерея світлин",
        "alias": "Gallery",
        "view": "/App_Plugins/LeBlender/editors/leblendereditor/LeBlendereditor.html",
        "icon": "icon-layers-alt",
        "render": "/App_Plugins/LeBlender/editors/leblendereditor/views/Base.cshtml",
        "config": {
            "editors": [
                {
                    "name": "Images",
                    "alias": "images",
                    "propretyType": {},
                    "dataType": "7e3962cc-ce20-4ffc-b661-5897a894ba7e"
                }
            ],
            "renderInGrid": "1",
            "frontView": "",
            "max": null
        }
    }
]