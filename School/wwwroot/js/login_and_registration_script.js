document.addEventListener('DOMContentLoaded', function () {
    // Функция для скрытия или показа формы
    function hiddenOpen_Closeclick(selector) {
        let x = document.querySelector(selector || ".container-login-registration");
        if (x.style.display == "none") {
            x.style.display = "grid";
        } else {
            x.style.display = "none";
        }
    }

    // Скрытие/открытие контейнера по клику
    document.getElementById("click-to-hide").addEventListener("click", function () {
        hiddenOpen_Closeclick();
    });

    document.getElementById("side-menu-button-click-to-hide").addEventListener("click", function () {
        hiddenOpen_Closeclick();
    });

    document.querySelector(".overlay").addEventListener("click", function () {
        hiddenOpen_Closeclick();
    });

    document.querySelector(".button_confirm_close").addEventListener("click", function () {
        hiddenOpen_Closeclick(".confirm-email-container");
    });

    // Обработка кнопок регистрации и входа
    const signInBtn = document.querySelector('.signin-btn');
    const signUpBtn = document.querySelector('.signup-btn');
    const formBox = document.querySelector('.form-box');
    const block = document.querySelector('.block');

    if (signInBtn && signUpBtn) {
        signUpBtn.addEventListener('click', function () {
            formBox.classList.add('active');
            block.classList.add('active');
        });

        signInBtn.addEventListener('click', function () {
            formBox.classList.remove('active');
            block.classList.remove('active');
        });
    }

    // Обработка кнопок входа и регистрации
    const form_btn_signin = document.querySelector('.form_btn_signin');
    const form_btn_signup = document.querySelector('.block-item_btn signup-btn');

    // Вход
    if (form_btn_signin) {
        form_btn_signin.addEventListener('click', function () {
            const requestURL = '/Home/Login';
            const errorContainer = document.getElementById('error-messages-singin');

            const form = {
                email: document.getElementById("signin_email"),
                password: document.getElementById("signin_password")
            };

            const body = {
                email: form.email.value,
                password: form.password.value
            };

            sendRequest('POST', requestURL, body)
                .then(data => {
                    cleaningAndClosingForm(form, errorContainer);
                    console.log('Успешный ответ:', data);
                    location.reload();
                })
                .catch(err => {
                    displayErrors(err, errorContainer);
                    console.log(err);
                });
        });
    }

    // Регистрация
    if (form_btn_signup) {
        form_btn_signup.addEventListener('click', function () {
            const requestURL = '/Home/Register';
            const errorContainer = document.getElementById('error-messages-signup');

            const form = {
                login: document.getElementById("signup_login"),
                email: document.getElementById("signup_email"),
                password: document.getElementById("signup_password"),
                passwordConfirm: document.getElementById("signup_confirm_password"),
            };

            const body = {
                login: form.login.value,
                email: form.email.value,
                password: form.password.value,
                passwordConfirm: form.passwordConfirm.value,
            };

            sendRequest('POST', requestURL, body)
                .then(data => {
                    cleaningAndClosingForm(form, errorContainer);
                    console.log('Успешный ответ:', data);
                    hiddenOpen_Closeclick(".confirm-email-container");
                    confirmEmail(data);
                    location.reload();
                })
                .catch(err => {
                    displayErrors(err, errorContainer);
                    console.log(err);
                });
        });
    }

    // Функция для отправки запросов
    function sendRequest(method, url, body = null) {
        const headers = {
            'Content-Type': 'application/json'
        };

        return fetch(url, {
            method: method,
            body: JSON.stringify(body),
            headers: headers
        }).then(response => {
            if (!response.ok) {
                return response.json().then(errorData => {
                    throw errorData;
                });
            }
            return response.json();
        });
    }

    // Отображение ошибок
    function displayErrors(errors, errorContainer) {
        errorContainer.innerHTML = '';
        errors.forEach(error => {
            const errorMessage = document.createElement('div');
            errorMessage.classList.add('error');
            errorMessage.textContent = error;
            errorContainer.appendChild(errorMessage);
        });
    }

    // Очистка формы и закрытие
    function cleaningAndClosingForm(form, errorContainer) {
        errorContainer.innerHTML = '';

        for (const key in form) {
            if (form.hasOwnProperty(key)) {
                form[key].value = ''; // Сброс значений полей формы
            }
        }

        hiddenOpen_Closeclick();
    }

    // Подтверждение email
    function confirmEmail(body) {
        const errorContainer = document.getElementById('error-messages-confirm-email');

        document.querySelector(".send_confirm").addEventListener('click', function () {
            body.codeConfirm = document.getElementById('code_confirm').value;
            const requestURL = '/Home/ConfirmEmail';

            sendRequest('POST', requestURL, body)
                .then(data => {
                    console.log("Код подтверждения:", data);
                    hiddenOpen_Closeclick(".confirm-email-container");
                    location.reload();
                })
                .catch(err => {
                    displayErrors(err, errorContainer);
                    console.log(err);
                });
        });
    }

    // Закрытие формы по клику на боковое меню
    document.getElementById("side-menu-button-click-to-hide").addEventListener("click", hiddenOpen_Closeclick);
});
