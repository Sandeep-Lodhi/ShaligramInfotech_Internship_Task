$(document).ready(() => {
    $('.mdl-navigation__link').each((index, el) => {
        $(el).removeClass('mdl-navigation__link--current');
        if (window.location.href.toString().includes($(el).attr('href'))) {
            $(el).addClass('mdl-navigation__link--current');
        }
    })
})