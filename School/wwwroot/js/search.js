document.addEventListener('DOMContentLoaded', function () {
    const mySearch = document.querySelector("#mySearch");

    if (mySearch) {

        const clear = document.querySelector('.clear');
        if (clear) {
            clear.addEventListener("click", function () {
                mySearch.value = '';
                triggerSearch();
            });
            {
                mySearch.oninput = triggerSearch;
            }
        }
    }
    function insertMark(str, pos, len) {
        return str.slice(0, pos) + '<mark>' + str.slice(pos, pos + len) + '</mark>' + str.slice(pos + len);
    }
    function triggerSearch() {
        let val = mySearch.value.trim().toLowerCase();
        let products = document.querySelectorAll('.product-item');
        products.forEach(function (product_item) {
            let city = product_item.querySelector('.city').innerText.toLowerCase();
            let nameHotel = product_item.querySelector('.nameHotel').innerText.toLowerCase();
            if (city.search(val) === -1 && nameHotel.search(val) === -1) {
                product_item.classList.add('hide');
            } else {
                product_item.classList.remove('hide');
                if (city.search(val) != -1) {
                    let str = product_item.querySelector('.city').innerText;
                    product_item.querySelector('.city').innerHTML = insertMark(str, city.search(val), val.length);
                } else {
                    product_item.querySelector('.city').innerHTML = product_item.querySelector('.city').innerText;
                }
                if (nameHotel.search(val) !== -1) {
                    let str = product_item.querySelector('.nameHotel').innerText;
                    product_item.querySelector('.nameHotel').innerHTML = insertMark(str, nameHotel.search(val), val.length);
                } else {
                    product_item.querySelector('.nameHotel').innerHTML = product_item.querySelector('.nameHotel').innerText;
                }
            }
        });
    }
});