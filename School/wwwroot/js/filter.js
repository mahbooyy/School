
document.getElementById('price-discount-OOP').addEventListener('input', updatePriceValues)
document.getElementById('price-Nodiscount-OOP').addEventListener('input', updatePriceValues)
document.getElementById('price-discount-OAO').addEventListener('input', updatePriceValues)
document.getElementById('price-Nodiscount-OAO').addEventListener('input', updatePriceValues)
document.getElementById('price-discount-ZAO').addEventListener('input', updatePriceValues)
document.getElementById('price-Nodiscount-ZAO').addEventListener('input', updatePriceValues)
document.getElementById('price-discount-PAO').addEventListener('input', updatePriceValues)
document.getElementById('price-Nodiscount-PAO').addEventListener('input', updatePriceValues)

function updatePriceValues() {
    const priceDiscountOOP = document.getElementById('price-discount-OOP').value;
    const priceNodiscountOOP = document.getElementById('price-Nodiscount-OOP').value;

    const priceDiscountOAO = document.getElementById('price-discount-OAO').value;
    const priceNodiscountOAO = document.getElementById('price-Nodiscount-OAO').value;

    const priceDiscountZAO = document.getElementById('price-discount-ZAO').value;
    const priceNodiscountZAO = document.getElementById('price-Nodiscount-ZAO').value;

    const priceDiscountPAO = document.getElementById('price-discount-PAO').value;
    const priceNodiscountPAO = document.getElementById('price-Nodiscount-PAO').value;

    //Ползунки цен
    document.getElementById('price-OOP-values').innerText = `${priceDiscountOOP} - ${priceNodiscountOOP}`;

    document.getElementById('price-OAO-values').innerText = `${priceDiscountOAO} - ${priceNodiscountOAO}`;

    document.getElementById('price-ZAO-values').innerText = `${priceDiscountZAO} - ${priceNodiscountZAO}`;

    document.getElementById('price-PAO-values').innerText = `${priceDiscountPAO} - ${priceNodiscountPAO}`;
}

document.querySelectorAll('.price-filter input[type="range"]').forEach(slider => {
    slider.addEventListener('input', (event) => {
        const value = event.target.value;
        const min = event.target.min || 0;
        const max = event.target.max || 100;
        const percent = ((value - min) / (max - min)) * 100;

        // Проверка, является ли это ползунок со скидкой или без
        if (event.target.id.includes('Nodiscount')) {
            // Для ползунков со скидкой: прогресс слева направо
            event.target.style.background = `linear-gradient(to left, #ff9e3d 0%, #ff9e3d ${100 - percent}%, #ccc ${100 - percent}%, #ccc 100%)`;
        } else {
            // Для ползунков без скидки: прогресс справа налево
            event.target.style.background = `linear-gradient(to right, #ff9e3d 0%, #ff9e3d ${percent}%, #ccc ${percent}%, #ccc 100%)`;
        }
    });
});




const sortSelect = document.getElementById('sort-options');
const serviceContainer = document.querySelector('.container-services')

sortSelect.addEventListener('change', () => {

    const sortOption = sortSelect.value;

    const services = Array.from(serviceContainer.querySelectorAll('.service-item'));

    services.sort((a, b) => {
        switch (sortOption) {

            // OOP
            case 'price-OOP-asc': {
                const priceA = parseFloat(a.querySelector('table tr:nth-child(2) td:first-child').textContent.replace('$', ''));
                const priceB = parseFloat(b.querySelector('table tr:nth-child(2) td:first-child').textContent.replace('$', ''));

                return priceA - priceB;
            }

            case 'price-OOP-desc': {
                const priceA = parseFloat(a.querySelector('table tr:nth-child(2) td:first-child').textContent.replace('$', ''));
                const priceB = parseFloat(b.querySelector('table tr:nth-child(2) td:first-child').textContent.replace('$', ''));

                return priceA - priceB;
            }

            // OAO
            case 'price-OAO-asc': {
                const priceA = parseFloat(a.querySelector('table tr:nth-child(2) td:first-child').textContent.replace('$', ''));
                const priceB = parseFloat(b.querySelector('table tr:nth-child(2) td:first-child').textContent.replace('$', ''));

                return priceA - priceB;
            }

            case 'price-OAO-desc': {
                const priceA = parseFloat(a.querySelector('table tr:nth-child(2) td:first-child').textContent.replace('$', ''));
                const priceB = parseFloat(b.querySelector('table tr:nth-child(2) td:first-child').textContent.replace('$', ''));

                return priceA - priceB;
            }

            //ZAO
            case 'price-ZAO-asc': {
                const priceA = parseFloat(a.querySelector('table tr:nth-child(2) td:first-child').textContent.replace('$', ''));
                const priceB = parseFloat(b.querySelector('table tr:nth-child(2) td:first-child').textContent.replace('$', ''));

                return priceA - priceB;
            }

            case 'price-ZAO-desc': {
                const priceA = parseFloat(a.querySelector('table tr:nth-child(2) td:first-child').textContent.replace('$', ''));
                const priceB = parseFloat(b.querySelector('table tr:nth-child(2) td:first-child').textContent.replace('$', ''));

                return priceA - priceB;
            }

            //PAO
            case 'price-PAO-asc': {
                const priceA = parseFloat(a.querySelector('table tr:nth-child(2) td:first-child').textContent.replace('$', ''));
                const priceB = parseFloat(b.querySelector('table tr:nth-child(2) td:first-child').textContent.replace('$', ''));

                return priceA - priceB;
            }

            case 'price-PAO-desc': {
                const priceA = parseFloat(a.querySelector('table tr:nth-child(2) td:first-child').textContent.replace('$', ''));
                const priceB = parseFloat(b.querySelector('table tr:nth-child(2) td:first-child').textContent.replace('$', ''));

                return priceA - priceB;
            }
            default:
                location.reload();

        }

    });

    services.forEach(services => serviceContainer.appendChild(services));
});