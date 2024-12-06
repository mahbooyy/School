document.getElementById('apply-filter').addEventListener('click', () => {
    // Сбор данных из ползунков
    const idCountry = document.getElementById('idCountry').value;
    const adultMin = document.getElementById('adult-min-price').value;
    const adultMax = document.getElementById('adult-max-price').value;
    const childMin = document.getElementById('child-min-price').value;
    const childMax = document.getElementById('child-max-price').value;
    // Сбор данных из чекбоксов
    const mealTypes = Array.from(document.querySelectorAll('.meal-types input[type="checkbox"]:checked')).map(
        (checkbox) => checkbox.value
    );
    // Формирование данных для отправки
    const filterData = {
        idCountry: idCountry,
        priceAfultMin: adultMin,
        priceAfultMax: adultMax,
        priceChildMin: childMin,
        priceChildMax: childMax,
        Nutrition: mealTypes,
    };
    console.log('Отправляемые данные:', filterData);
// Отправка данных через fetch
        fetch('/Tours/Filter', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(filterData),
    })
            .then((response) => {
                if (!response.ok) {
                    throw new Error('Ошибка при фильтрации данных');
}
                return response.json(); // Преобразуем ответ в JSON
            })
            .then((data) => {
                console.log('Результаты фильтрации:', data);
                dataDisplay(data);
            })
            .catch((error) => {
                console.erroг('Ошибка:', еггог);
            });
});
const toursList = document.querySelector('.list-tours');
toursList.innerHTML = ''; // Очистить старые данные

if (Idata || data.length == 0) {
    // Если нет данных, отображаем сообщение
    const noToursMessage = '<h2>По данному фильтру нет туров</h2>';
    toursList.innerHTML = noToursMessage;
} else {
    // Если данные есть, создаем элементы для туров
    data.forEach((tour) => {
        const tourItem = `<div class="list-tours">
        <div class="tour-item">
        <div class="item-stars">
        ${'<img src="/images/star.jpg" class="star"/>'.repeat(tour.stars)}
        </div>
        <img src="${tour.pathImg}" class="item-tour-img" />
        <div class="item-info">
        <h2>${tour.city}</h2>
        <h2>${tour.nameHotel}</h2>
        </div >
            <table>
                <tbody>
                    <tr>
                        <td>Взрослый:</td>
                        <td>Ребенок: </td>
                    </tr>
                    <tr>
                        <td>${tour.priceAdult}$</td>
                        <td>${tour.priceChild}$</td>
                    </tr>
                </tbody>
            </table>
        </div >
        <input asp-for="@item.Id" value="${tour.id}" style="display: none" />
        <input asp-for="@item.IdCountry" value="${tour.idCountry}" style="display: none"
        </div>`;

        toursList.innerHTML += tourItem;
    });
}

