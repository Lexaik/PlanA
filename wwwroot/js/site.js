    // Функция для определения активного маршрута и подсветки кнопки
    function setActiveNavLink() {
        const currentPath = window.location.pathname.toLowerCase();
        const navLinks = document.querySelectorAll('.nav-tabs-custom .nav-link[data-route]');
        
        // Удаляем класс active у всех ссылок
        navLinks.forEach(link => {
            link.classList.remove('active');
        });
        
        // Получаем последний сегмент пути
        const pathSegments = currentPath.split('/').filter(s => s);
        let currentRoute = '';
        
        if (pathSegments.length >= 2) {
            currentRoute = pathSegments.slice(0, 2).join('/');
        } else if (pathSegments.length === 1) {
            currentRoute = pathSegments[0];
        } else {
            currentRoute = 'home/index';
        }
        
        // Активируем соответствующую ссылку
        let foundActive = false;
        navLinks.forEach(link => {
            const route = link.getAttribute('data-route');
            if (route === currentRoute) {
                link.classList.add('active');
                foundActive = true;
            }
        });
        
        if (!foundActive) {
            navLinks.forEach(link => {
                const href = link.getAttribute('href');
                if (href) {
                    const hrefPath = href.toLowerCase().replace(/\/$/, '');
                    if (currentPath === hrefPath || 
                        (currentPath === '/' && hrefPath === '/home/index') ||
                        currentPath.startsWith(hrefPath + '/')) {
                        link.classList.add('active');
                    }
                }
            });
        }
    }

    // Функция для адаптации макета
    function adaptLayout() {
        const headerNav = document.querySelector('.nav-tabs-custom');
        const footerButtons = document.querySelector('.action-buttons');
        const screenWidth = window.innerWidth;
        
        if (headerNav) {
            const navItems = headerNav.querySelectorAll('.nav-item');
            const containerWidth = headerNav.clientWidth;
            let totalWidth = 0;
            
            navItems.forEach(item => {
                totalWidth += item.offsetWidth;
            });
            
            if (totalWidth > containerWidth) {
                navItems.forEach(item => {
                    const navText = item.querySelector('.nav-text');
                    if (navText) {
                        navText.style.display = 'none';
                    }
                });
            } else if (screenWidth >= 577) {
                navItems.forEach(item => {
                    const navText = item.querySelector('.nav-text');
                    if (navText) {
                        navText.style.display = 'inline-block';
                    }
                });
            }
        }
        
        if (footerButtons) {
            const actionBtns = footerButtons.querySelectorAll('.action-btn');
            const containerWidth = footerButtons.clientWidth;
            let totalWidth = 0;
            
            actionBtns.forEach(btn => {
                totalWidth += btn.offsetWidth;
            });
            
            if (totalWidth > containerWidth) {
                actionBtns.forEach(btn => {
                    const btnText = btn.querySelector('.btn-text');
                    if (btnText) {
                        btnText.style.display = 'none';
                    }
                });
            } else if (screenWidth >= 577) {
                actionBtns.forEach(btn => {
                    const btnText = btn.querySelector('.btn-text');
                    if (btnText) {
                        btnText.style.display = 'inline-block';
                    }
                });
            }
        }
        
        setActiveNavLink();
    }

    // Функция для настройки обработчиков кликов
    function setupNavigationHandlers() {
        const navLinks = document.querySelectorAll('.nav-tabs-custom .nav-link[data-route]');
        
        navLinks.forEach(link => {
            link.addEventListener('click', function(e) {
                navLinks.forEach(l => l.classList.remove('active'));
                this.classList.add('active');
                
                const route = this.getAttribute('data-route');
                sessionStorage.setItem('lastClickedRoute', route);
                
                // Сохраняем информацию о том, нужно ли скрывать футер
                const shouldHide = route === 'home/index' || 
                                 route === 'home/privacy' || 
                                 route === 'work/loadingview';
                sessionStorage.setItem('shouldHideFooter', shouldHide ? 'true' : 'false');
                
                return true;
            });
        });
    }

    // Функция для восстановления состояния после загрузки
    function restoreFromSession() {
        const lastRoute = sessionStorage.getItem('lastClickedRoute');
        if (lastRoute) {
            const navLinks = document.querySelectorAll('.nav-tabs-custom .nav-link[data-route]');
            navLinks.forEach(link => {
                const route = link.getAttribute('data-route');
                if (route === lastRoute) {
                    link.classList.add('active');
                }
            });
            sessionStorage.removeItem('lastClickedRoute');
        }
        
        // Дополнительно проверяем видимость футера
        //toggleFooterVisibility();
    }

    // Инициализация после полной загрузки DOM
    document.addEventListener('DOMContentLoaded', function() {
        // Удаляем временный стиль, если он есть
        const tempStyle = document.getElementById('immediate-footer-hide');
        if (tempStyle) {
            tempStyle.remove();
        }
        
        setActiveNavLink();
        //toggleFooterVisibility();
        adaptLayout();
        setupNavigationHandlers();
        //setupFooterButtons();
        restoreFromSession();
    });

    // Оптимизированная загрузка
    window.addEventListener('load', function() {
        //toggleFooterVisibility();
        setActiveNavLink();
        adaptLayout();
        //setupFooterButtons();
    });

    window.addEventListener('popstate', function() {
        toggleFooterVisibility();
        setActiveNavLink();
    });
    
    //260302
    
    
    // Загружаем данные из скрытых полей
        let tableData = JSON.parse(document.getElementById('tableOrderJson').value);
        let availableProducts = JSON.parse(document.getElementById('availableAssetsJson').value);
        
        // Остальной JavaScript код остается без изменений
        // ...
    // Список доступных товаров (в реальном приложении загружается с сервера)
            /*let availableProducts = [
                { id: 1, name: 'Ноутбук' },
                { id: 2, name: 'Мышь' },
                { id: 3, name: 'Клавиатура' },
                { id: 4, name: 'Монитор' },
                { id: 5, name: 'Наушники' },
                { id: 6, name: 'Веб-камера' },
                { id: 7, name: 'Микрофон' },
                { id: 8, name: 'Внешний диск' },
                { id: 9, name: 'Флешка' },
                { id: 10, name: 'Принтер' },
                { id: 11, name: 'Сканер' },
                { id: 12, name: 'Планшет' },
                { id: 13, name: 'Смартфон' },
                { id: 14, name: 'Зарядное устройство' },
                { id: 15, name: 'Чехол' }
            ];*/
    
            // Исходные данные с контактами и товарами
            /*let tableData = [
                { 
                    id: 1, 
                    firstName: 'Иван', 
                    lastName: 'Иванов', 
                    emails: [
                        'ivan@example.com',
                        'ivan.work@company.com'
                    ],
                    phones: [
                        '+7 (999) 123-45-67',
                        '+7 (495) 234-56-78'
                    ],
                    products: [
                        { productId: 1, quantity: 2 }, // Ноутбук
                        { productId: 2, quantity: 3 }  // Мышь
                    ]
                },
                { 
                    id: 2, 
                    firstName: 'Петр', 
                    lastName: 'Петров', 
                    emails: [
                        'petr@example.com'
                    ],
                    phones: [
                        '+7 (999) 234-56-78',
                        '+7 (926) 345-67-89'
                    ],
                    products: [
                        { productId: 13, quantity: 1 }, // Смартфон
                        { productId: 14, quantity: 2 }, // Зарядное устройство
                        { productId: 15, quantity: 1 }  // Чехол
                    ]
                },
                { 
                    id: 3, 
                    firstName: 'Мария', 
                    lastName: 'Сидорова', 
                    emails: [
                        'maria@example.com',
                        'maria.personal@gmail.com'
                    ],
                    phones: [
                        '+7 (999) 345-67-89',
                        '+7 (903) 456-78-90'
                    ],
                    products: [
                        { productId: 12, quantity: 1 }, // Планшет
                        { productId: 3, quantity: 1 }   // Клавиатура
                    ]
                },
                { 
                    id: 4, 
                    firstName: 'Анна', 
                    lastName: 'Смирнова', 
                    emails: [
                        'anna@example.com',
                        'anna.work@corp.com'
                    ],
                    phones: [
                        '+7 (999) 456-78-90'
                    ],
                    products: [
                        { productId: 4, quantity: 2 },  // Монитор
                        { productId: 5, quantity: 1 }   // Наушники
                    ]
                },
                { 
                    id: 5, 
                    firstName: 'Дмитрий', 
                    lastName: 'Козлов', 
                    emails: [
                        'dmitry@example.com',
                        'dmitry.work@corp.com'
                    ],
                    phones: [
                        '+7 (999) 567-89-01',
                        '+7 (916) 678-90-12'
                    ],
                    products: [
                        { productId: 10, quantity: 1 }, // Принтер
                        { productId: 8, quantity: 2 },  // Внешний диск
                        { productId: 9, quantity: 5 }   // Флешка
                    ]
                }
            ];*/
    
            // Состояние приложения
            let appState = {
                mode: 'add',
                editingId: null,
                originalData: null,
                expandedRows: new Set()
            };
    
            // Текущие фильтры
            let currentFilters = {
                Название: '',
                Изделия: ''
            };
    
            // Функция для получения названия товара по ID
            function getProductName(productId) {
                const product = availableProducts.find(p => p.id === productId);
                return product ? product.name : 'Неизвестный товар';
            }
    
            // Функция для получения выбранных ID товаров из формы
            function getSelectedProductIds() {
                const selectedIds = [];
                const productSelects = document.querySelectorAll('#productContainer .product-select');
                productSelects.forEach(select => {
                    const value = parseInt(select.value);
                    if (value) {
                        selectedIds.push(value);
                    }
                });
                return selectedIds;
            }
    
            // Функция для обновления опций в выпадающем списке без замены элемента
            function updateSelectOptions(select, selectedProductId = null) {
                const selectedIds = getSelectedProductIds();
                
                // Сохраняем текущее значение
                const currentValue = select.value;
                
                // Очищаем select
                select.innerHTML = '';
                
                // Добавляем пустой option
                const emptyOption = document.createElement('option');
                emptyOption.value = '';
                emptyOption.textContent = 'Выберите товар...';
                select.appendChild(emptyOption);
                
                // Добавляем товары
                availableProducts.forEach(product => {
                    // Показываем товар, если он не в списке исключенных или это текущий выбранный товар
                    if (!selectedIds.includes(product.id) || product.id === parseInt(currentValue)) {
                        const option = document.createElement('option');
                        option.value = product.id;
                        option.textContent = product.name;
                        if (product.id === parseInt(currentValue)) {
                            option.selected = true;
                        }
                        select.appendChild(option);
                    }
                });
            }
    
            // Функция для обновления всех выпадающих списков товаров без потери фокуса
            function updateAllProductSelects() {
                const productSelects = document.querySelectorAll('#productContainer .product-select');
                productSelects.forEach(select => {
                    // Сохраняем текущее значение
                    const currentValue = select.value;
                    // Обновляем опции
                    updateSelectOptions(select, currentValue);
                });
            }
    
            // Функция для проверки, соответствует ли запись фильтрам
            function rowMatchesFilters(row) {
                // Проверка ID
                /*if (currentFilters.id && !row.id.toString().toLowerCase().includes(currentFilters.id.toLowerCase())) {
                    return false;
                }*/
                
                // Проверка имени
                if (currentFilters.Name && !row.Name.toLowerCase().includes(currentFilters.Name.toLowerCase())) {
                    return false;
                }
                
                // Проверка фамилии
                /*if (currentFilters.lastName && !row.lastName.toLowerCase().includes(currentFilters.lastName.toLowerCase())) {
                    return false;
                }*/
                
                // Проверка email
                /*if (currentFilters.email) {
                    const emailMatches = row.emails.some(email => 
                        email.toLowerCase().includes(currentFilters.email.toLowerCase())
                    );
                    if (!emailMatches) return false;
                }*/
                
                // Проверка телефона
                /*if (currentFilters.phone) {
                    const phoneMatches = row.phones.some(phone => 
                        phone.toLowerCase().includes(currentFilters.phone.toLowerCase())
                    );
                    if (!phoneMatches) return false;
                }*/
                
                // Проверка товаров
                if (currentFilters.product) {
                    const productMatches = row.products.some(product => {
                        const productName = getProductName(product.productId);
                        return productName.toLowerCase().includes(currentFilters.product.toLowerCase());
                    });
                    if (!productMatches) return false;
                }
                
                return true;
            }
    
            // Функция для применения фильтров к данным
            function filterData(data) {
                return data.filter(row => rowMatchesFilters(row));
            }
    
            // Новая функция для применения фильтров без перерисовки всей таблицы
            function applyFilters() {
                const tbody = document.querySelector('#dataTable tbody');
                const rows = tbody.querySelectorAll('tr:not(#editRow)');
                
                rows.forEach(row => {
                    // Пропускаем строки с сообщениями
                    if (row.classList.contains('expanded-row') || row.querySelector('.no-data')) {
                        return;
                    }
                    
                    const idCell = row.cells[1];
                    if (idCell) {
                        const id = parseInt(idCell.textContent);
                        const dataRow = Model.find(item => item.id === id);
                        if (dataRow) {
                            const matches = rowMatchesFilters(dataRow);
                            row.style.display = matches ? '' : 'none';
                            
                            // Также скрываем соответствующую развернутую строку, если она есть
                            const nextRow = row.nextElementSibling;
                            if (nextRow && nextRow.classList.contains('expanded-row')) {
                                nextRow.style.display = matches ? '' : 'none';
                            }
                        }
                    }
                });
                
                // Обновляем счетчики
                const filteredData = filterData(Model);
                document.getElementById('displayedRecords').textContent = filteredData.length;
                
                // Показываем сообщение, если нет результатов
                const existingNoData = tbody.querySelector('.no-data');
                if (filteredData.length === 0 && Model.length > 0) {
                    if (!existingNoData) {
                        const tr = document.createElement('tr');
                        tr.innerHTML = '<td colspan="8" class="no-data"><i class="bi bi-funnel me-2"></i>Нет записей, соответствующих фильтрам</td>';
                        tbody.appendChild(tr);
                    }
                } else if (existingNoData) {
                    existingNoData.remove();
                }
                
                // Обновляем индикаторы фильтров
                updateFilterIndicators();
                
                // Показываем/скрываем кнопки сброса фильтров
                const hasFilters = hasActiveFilters();
                document.getElementById('clearFiltersBtn').style.display = hasFilters ? 'inline-block' : 'none';
                document.getElementById('clearFiltersFooterBtn').style.display = hasFilters ? 'inline-block' : 'none';
                document.getElementById('activeFiltersBadge').style.display = hasFilters ? 'inline-block' : 'none';
            }
    
            // Функция для получения всех email для отображения
            /*function getEmailBadges(emails) {
                return emails.map(email => 
                    `<span class="contact-badge email-badge" title="${email}">
                        <i class="bi bi-envelope"></i>
                        <span class="value">${escapeHtml(email)}</span>
                    </span>`
                ).join('');
            }*/
    
            // Функция для получения всех телефонов для отображения
            /*function getPhoneBadges(phones) {
                return phones.map(phone => 
                    `<span class="contact-badge phone-badge" title="${phone}">
                        <i class="bi bi-telephone"></i>
                        <span class="value">${escapeHtml(phone)}</span>
                    </span>`
                ).join('');
            }*/
    
            // Функция для получения всех товаров для отображения
            function getProductBadges(products) {
                return products.map(product => {
                    const productName = getProductName(product.productId);
                    return `<span class="product-badge" title="${productName} - ${product.quantity} шт.">
                        <i class="bi bi-box"></i>
                        <span class="value">${escapeHtml(productName)}</span>
                        <span class="quantity">${product.quantity}</span>
                    </span>`;
                }).join('');
            }
    
            // Функция для переключения развернутой строки
            function toggleRowExpanded(id) {
                if (appState.expandedRows.has(id)) {
                    appState.expandedRows.delete(id);
                } else {
                    appState.expandedRows.add(id);
                }
                renderTable();
            }
    
            // Функция для добавления поля email
            /*function addEmailField(email = '') {
                const container = document.getElementById('emailContainer');
                const emailId = 'email_' + Date.now() + '_' + Math.random();
                
                const emailDiv = document.createElement('div');
                emailDiv.className = 'field-input-group';
                emailDiv.id = emailId;
                
                emailDiv.innerHTML = `
                    <input type="email" class="form-control form-control-sm email-input" 
                           placeholder="email@example.com" value="${escapeHtml(email)}">
                    <button class="btn-remove-field btn-sm" onclick="removeField('${emailId}')">
                        <i class="bi bi-x"></i>
                    </button>
                `;
                
                container.appendChild(emailDiv);
                
                // Добавляем обработчик для фильтрации
                const input = emailDiv.querySelector('.email-input');
                input.addEventListener('input', function(e) {
                    updateFilter('email', e.target.value);
                });
            }*/
    
            // Функция для добавления поля телефона
            function addPhoneField(phone = '') {
                const container = document.getElementById('phoneContainer');
                const phoneId = 'phone_' + Date.now() + '_' + Math.random();
                
                const phoneDiv = document.createElement('div');
                phoneDiv.className = 'field-input-group';
                phoneDiv.id = phoneId;
                
                phoneDiv.innerHTML = `
                    <input type="tel" class="form-control form-control-sm phone-input" 
                           placeholder="+7 (999) 123-45-67" value="${escapeHtml(phone)}">
                    <button class="btn-remove-field btn-sm" onclick="removeField('${phoneId}')">
                        <i class="bi bi-x"></i>
                    </button>
                `;
                
                container.appendChild(phoneDiv);
                
                // Добавляем обработчик для фильтрации
                const input = phoneDiv.querySelector('.phone-input');
                input.addEventListener('input', function(e) {
                    updateFilter('phone', e.target.value);
                });
            }
    
            // Функция для добавления поля товара
            function addProductField(product = null) {
                const container = document.getElementById('productContainer');
                const productId = 'product_' + Date.now() + '_' + Math.random();
                
                const productDiv = document.createElement('div');
                productDiv.className = 'field-input-group';
                productDiv.id = productId;
                
                // Создаем select
                const select = document.createElement('select');
                select.className = 'form-select form-select-sm product-select';
                
                // Заполняем select опциями
                const selectedIds = getSelectedProductIds();
                let options = '<option value="">Выберите изделие...</option>';
                availableProducts.forEach(p => {
                    if (!selectedIds.includes(p.id) || p.id === (product ? product.productId : null)) {
                        const selected = p.id === (product ? product.productId : null) ? 'selected' : '';
                        options += `<option value="${p.id}" ${selected}>${escapeHtml(p.name)}</option>`;
                    }
                });
                select.innerHTML = options;
                
                productDiv.appendChild(select);
                
                // Добавляем input для количества
                const quantityInput = document.createElement('input');
                quantityInput.type = 'number';
                quantityInput.className = 'form-control form-control-sm quantity-input';
                quantityInput.placeholder = 'Кол-во';
                quantityInput.min = '1';
                quantityInput.value = product ? product.quantity : 1;
                productDiv.appendChild(quantityInput);
                
                // Добавляем кнопку удаления
                const removeBtn = document.createElement('button');
                removeBtn.className = 'btn-remove-field btn-sm';
                removeBtn.setAttribute('onclick', `removeField('${productId}')`);
                removeBtn.innerHTML = '<i class="bi bi-x"></i>';
                productDiv.appendChild(removeBtn);
                
                container.appendChild(productDiv);
                
                // Добавляем обработчики
                select.addEventListener('change', function(e) {
                    const selectedOption = select.options[select.selectedIndex];
                    if (selectedOption && selectedOption.text !== 'Выберите товар...') {
                        updateFilter('product', selectedOption.text);
                    } else {
                        updateFilter('product', '');
                    }
                    updateAllProductSelects();
                });
            }
    
            // Функция для удаления поля
            function removeField(fieldId) {
                const element = document.getElementById(fieldId);
                if (element) {
                    element.remove();
                    
                    // После удаления обновляем фильтры
                    const emailInputs = document.querySelectorAll('#emailContainer .email-input');
                    /*const phoneInputs = document.querySelectorAll('#phoneContainer .phone-input');*/
                    const productSelects = document.querySelectorAll('#productContainer .product-select');
                    
                    let hasEmailValue = false;
                    let hasPhoneValue = false;
                    let hasProductValue = false;
                    
                    emailInputs.forEach(input => {
                        if (input.value.trim() !== '') hasEmailValue = true;
                    });
                    
                    phoneInputs.forEach(input => {
                        if (input.value.trim() !== '') hasPhoneValue = true;
                    });
                    
                    productSelects.forEach(select => {
                        if (select.value) hasProductValue = true;
                    });
                    
                    if (!hasEmailValue) {
                        currentFilters.email = '';
                    }
                    
                    if (!hasPhoneValue) {
                        currentFilters.phone = '';
                    }
                    
                    if (!hasProductValue) {
                        currentFilters.product = '';
                    }
                    
                    // Обновляем списки товаров
                    if (productSelects.length > 0) {
                        updateAllProductSelects();
                    }
                    
                    // Применяем фильтры
                    applyFilters();
                }
            }
    
            // Функция для сбора email из формы
            function collectEmailsFromForm() {
                const emails = [];
                const emailInputs = document.querySelectorAll('#emailContainer .email-input');
                
                emailInputs.forEach(input => {
                    const value = input.value.trim();
                    if (value) {
                        emails.push(value);
                    }
                });
                
                return emails;
            }
    
            // Функция для сбора телефонов из формы
            function collectPhonesFromForm() {
                const phones = [];
                const phoneInputs = document.querySelectorAll('#phoneContainer .phone-input');
                
                phoneInputs.forEach(input => {
                    const value = input.value.trim();
                    if (value) {
                        phones.push(value);
                    }
                });
                
                return phones;
            }
    
            // Функция для сбора товаров из формы
            function collectProductsFromForm() {
                const products = [];
                const productGroups = document.querySelectorAll('#productContainer .field-input-group');
                
                productGroups.forEach(group => {
                    const select = group.querySelector('.product-select');
                    const productId = parseInt(select.value);
                    const quantity = parseInt(group.querySelector('.quantity-input').value);
                    
                    if (productId && quantity > 0) {
                        products.push({ productId, quantity });
                    }
                });
                
                return products;
            }
    
            // Функция для загрузки контактов и товаров в форму
            function loadDataToForm(data) {
                // Очищаем контейнеры
                document.getElementById('emailContainer').innerHTML = '';
                document.getElementById('phoneContainer').innerHTML = '';
                document.getElementById('productContainer').innerHTML = '';
                
                // Загружаем email
                if (data.emails && data.emails.length > 0) {
                    data.emails.forEach(email => addEmailField(email));
                } else {
                    addEmailField();
                }
                
                // Загружаем телефоны
                if (data.phones && data.phones.length > 0) {
                    data.phones.forEach(phone => addPhoneField(phone));
                } else {
                    addPhoneField();
                }
                
                // Загружаем товары
                if (data.products && data.products.length > 0) {
                    data.products.forEach(product => addProductField(product));
                } else {
                    addProductField();
                }
            }
    
            // Функция для сброса всех фильтров
            function clearAllFilters() {
                currentFilters = {
                    id: '',
                    firstName: '',
                    lastName: '',
                    email: '',
                    phone: '',
                    product: ''
                };
                
                document.getElementById('editId').value = '';
                document.getElementById('editFirstName').value = '';
                document.getElementById('editLastName').value = '';
                
                // Применяем фильтры
                applyFilters();
                showToast('Фильтры сброшены', 'info');
            }
    
            // Функция для заполнения полей данными
            function populateEditFields(data) {
                document.getElementById('editId').value = data.id || '';
                document.getElementById('editFirstName').value = data.firstName || '';
                document.getElementById('editLastName').value = data.lastName || '';
                loadDataToForm(data);
            }
    
            // Функция для переключения режима
            function setMode(mode, data = null) {
                const editRow = document.getElementById('editRow');
                const mainBtn = document.getElementById('mainActionBtn');
                const cancelBtn = document.getElementById('cancelBtn');
                const editBadge = document.getElementById('editModeBadge');
                
                if (mode === 'edit' && data) {
                    appState.mode = 'edit';
                    appState.editingId = data.id;
                    appState.originalData = JSON.parse(JSON.stringify(data));
                    
                    populateEditFields(data);
                    
                    editRow.classList.add('editing-mode');
                    mainBtn.innerHTML = '<i class="bi bi-check-circle me-1"></i>Применить';
                    mainBtn.className = 'btn btn-apply btn-sm flex-grow-1';
                    cancelBtn.style.display = 'block';
                    editBadge.style.display = 'inline-block';
                } else {
                    appState.mode = 'add';
                    appState.editingId = null;
                    appState.originalData = null;
                    
                    editRow.classList.remove('editing-mode');
                    mainBtn.innerHTML = '<i class="bi bi-plus-circle me-1"></i>Добавить';
                    mainBtn.className = 'btn btn-add btn-sm flex-grow-1';
                    
                    clearAllFilters();
                    
                    cancelBtn.style.display = 'none';
                    editBadge.style.display = 'none';
                }
            }
    
            // Обработка основного действия
            function handleMainAction() {
                if (appState.mode === 'add') {
                    addNewRow();
                } else {
                    applyEdit();
                }
            }
    
            // Функция для добавления новой строки
            function addNewRow() {
                const newId = document.getElementById('editId').value.trim();
                const newFirstName = document.getElementById('editFirstName').value.trim();
                const newLastName = document.getElementById('editLastName').value.trim();
                const emails = collectEmailsFromForm();
                const phones = collectPhonesFromForm();
                const products = collectProductsFromForm();
                
                // Проверка заполнения основных полей
                if (!newId || !newFirstName || !newLastName) {
                    showToast('Пожалуйста, заполните ID, Имя и Фамилию', 'warning');
                    return;
                }
                
                // Проверка наличия хотя бы одного контакта или товара
                if (emails.length === 0 && phones.length === 0 && products.length === 0) {
                    showToast('Добавьте хотя бы один email, телефон или товар', 'warning');
                    return;
                }
                
                // Проверка ID
                const idNum = parseInt(newId);
                if (isNaN(idNum) || idNum <= 0) {
                    showToast('ID должен быть положительным числом', 'warning');
                    return;
                }
                
                // Проверка уникальности ID
                if (Model.some(item => item.id === idNum)) {
                    showToast('Пользователь с таким ID уже существует', 'danger');
                    return;
                }
                
                // Добавление записи
                Model.push({
                    id: idNum,
                    firstName: newFirstName,
                    lastName: newLastName,
                    emails: emails,
                    phones: phones,
                    products: products
                });
                
                // Сбрасываем только фильтры, поля остаются
                clearAllFilters();
                
                showToast('Запись успешно добавлена', 'success');
            }
    
            // Применение редактирования
            function applyEdit() {
                if (!appState.editingId) return;
                
                const editedData = {
                    id: parseInt(document.getElementById('editId').value),
                    firstName: document.getElementById('editFirstName').value.trim(),
                    lastName: document.getElementById('editLastName').value.trim(),
                    emails: collectEmailsFromForm(),
                    phones: collectPhonesFromForm(),
                    products: collectProductsFromForm()
                };
                
                // Проверка заполнения основных полей
                if (!editedData.id || !editedData.firstName || !editedData.lastName) {
                    showToast('Пожалуйста, заполните ID, Имя и Фамилию', 'warning');
                    return;
                }
                
                // Проверка наличия хотя бы одного контакта или товара
                if (editedData.emails.length === 0 && editedData.phones.length === 0 && editedData.products.length === 0) {
                    showToast('Добавьте хотя бы один email, телефон или товар', 'warning');
                    return;
                }
                
                // Проверка уникальности ID (если изменился)
                if (editedData.id !== appState.originalData.id) {
                    if (tableData.some(item => item.id === editedData.id)) {
                        showToast('Пользователь с таким ID уже существует', 'warning');
                        return;
                    }
                }
                
                // Находим и обновляем запись
                const index = tableData.findIndex(item => item.id === appState.editingId);
                if (index !== -1) {
                    tableData[index] = editedData;
                }
                
                // Выходим из режима редактирования
                setMode('add');
                
                // Сбрасываем только фильтры
                clearAllFilters();
                
                showToast('Запись успешно обновлена', 'success');
            }
    
            // Отмена редактирования/ввода
            function cancelEditing() {
                if (appState.mode === 'edit') {
                    setMode('add');
                    clearAllFilters();
                    showToast('Редактирование отменено', 'info');
                } else {
                    clearAllFilters();
                }
            }
    
            // Начало редактирования
            function startEditing(id) {
                const row = tableData.find(item => item.id === id);
                if (row) {
                    setMode('edit', row);
                    renderTable();
                }
            }
    
            // Функция для обновления фильтра (ТЕПЕРЬ БЕЗ renderTable)
            function updateFilter(column, value) {
                currentFilters[column] = value;
                applyFilters(); // Применяем фильтры без перерисовки
            }
    
            // Функция для отображения таблицы (используется только при начальной загрузке и смене режима)
            function renderTable() {
                const tbody = document.querySelector('#dataTable tbody');
                
                // Сохраняем строку редактирования
                const editRow = document.getElementById('editRow');
                
                // Очищаем tbody
                tbody.innerHTML = '';
                
                // Добавляем строку редактирования обратно
                tbody.appendChild(editRow);
                
                // Подсвечиваем поля с активными фильтрами
                highlightFilterFields();
                
                // Добавляем строки данных
                if (tableData.length > 0) {
                    tableData.forEach(row => {
                        renderNormalRow(row, tbody);
                    });
                } else {
                    const tr = document.createElement('tr');
                    tr.innerHTML = '<td colspan="8" class="no-data"><i class="bi bi-inbox me-2"></i>Нет данных для отображения</td>';
                    tbody.appendChild(tr);
                }
                
                // Применяем фильтры
                applyFilters();
                
                // Обновляем счетчики
                document.getElementById('totalRecords').textContent = tableData.length;
                document.getElementById('displayedRecords').textContent = filterData(tableData).length;
                
                // Обновляем индикаторы фильтров
                updateFilterIndicators();
                
                // Показываем/скрываем кнопки сброса фильтров
                const hasFilters = hasActiveFilters();
                document.getElementById('clearFiltersBtn').style.display = hasFilters ? 'inline-block' : 'none';
                document.getElementById('clearFiltersFooterBtn').style.display = hasFilters ? 'inline-block' : 'none';
                document.getElementById('activeFiltersBadge').style.display = hasFilters ? 'inline-block' : 'none';
            }
    
            // Функция для отображения обычной строки
            function renderNormalRow(row, tbody) {
                const isExpanded = appState.expandedRows.has(row.id);
                
                const tr = document.createElement('tr');
                tr.className = 'align-middle';
                
                if (appState.mode === 'edit' && appState.editingId === row.id) {
                    tr.style.backgroundColor = '#e3f2fd';
                }
                
                tr.innerHTML = `
                    <td class="text-center">
                        <i class="bi bi-chevron-right expand-btn ${isExpanded ? 'expanded' : ''}" 
                           onclick="toggleRowExpanded(${row.id})"></i>
                    </td>
                    <td><span class="badge bg-secondary">${row.id}</span></td>
                    <td>${escapeHtml(row.Name)}</td>
                    
                    <td>
                        <div class="contacts-badge">
                            ${getProductBadges(row.products)}
                        </div>
                    </td>
                    <td>
                        <div class="btn-group btn-group-sm" role="group">
                            <button onclick="startEditing(${row.id})" class="btn btn-outline-primary btn-action" title="Редактировать" ${appState.mode === 'edit' ? 'disabled' : ''}>
                                <i class="bi bi-pencil"></i>
                            </button>
                            <button onclick="deleteRow(${row.id})" class="btn btn-outline-danger btn-action" title="Удалить" ${appState.mode === 'edit' ? 'disabled' : ''}>
                                <i class="bi bi-trash"></i>
                            </button>
                        </div>
                    </td>
                `;
                
                tbody.appendChild(tr);
                
                // Добавляем развернутую строку с подробной информацией
                if (isExpanded) {
                    const expandedTr = document.createElement('tr');
                    expandedTr.className = 'expanded-row';
                    expandedTr.innerHTML = `
                        <td colspan="8">
                            <div class="expanded-content">
                                <div class="contact-details">
                                    <div class="contact-group">
                                        <h6><i class="bi bi-envelope me-1"></i> Email адреса</h6>
                                        <ul class="contact-list">
                                            ${row.emails.map(email => `
                                                <li>
                                                    <span class="contact-type-icon">
                                                        <i class="bi bi-envelope text-primary"></i>
                                                    </span>
                                                    <span class="contact-value">
                                                        ${escapeHtml(email)}
                                                    </span>
                                                </li>
                                            `).join('')}
                                            ${row.emails.length === 0 ? '<li class="text-muted">Нет email адресов</li>' : ''}
                                        </ul>
                                    </div>
                                    <div class="contact-group">
                                        <h6><i class="bi bi-telephone me-1"></i> Телефоны</h6>
                                        <ul class="contact-list">
                                            ${row.phones.map(phone => `
                                                <li>
                                                    <span class="contact-type-icon">
                                                        <i class="bi bi-telephone text-success"></i>
                                                    </span>
                                                    <span class="contact-value">
                                                        ${escapeHtml(phone)}
                                                    </span>
                                                </li>
                                            `).join('')}
                                            ${row.phones.length === 0 ? '<li class="text-muted">Нет телефонов</li>' : ''}
                                        </ul>
                                    </div>
                                    <div class="contact-group">
                                        <h6><i class="bi bi-box me-1"></i> Товары</h6>
                                        <ul class="contact-list">
                                            ${row.products.map(product => {
                                                const productName = getProductName(product.productId);
                                                return `
                                                    <li>
                                                        <span class="contact-type-icon">
                                                            <i class="bi bi-box text-warning"></i>
                                                        </span>
                                                        <span class="contact-value">
                                                            ${escapeHtml(productName)}
                                                        </span>
                                                        <span class="product-quantity">${product.quantity} шт.</span>
                                                    </li>
                                                `;
                                            }).join('')}
                                            ${row.products.length === 0 ? '<li class="text-muted">Нет товаров</li>' : ''}
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </td>
                    `;
                    tbody.appendChild(expandedTr);
                }
            }
    
            // Подсветка полей с активными фильтрами
            function highlightFilterFields() {
                const fields = [
                    { element: 'editId', filter: currentFilters.id },
                    { element: 'editFirstName', filter: currentFilters.firstName },
                    { element: 'editLastName', filter: currentFilters.lastName }
                ];
                
                fields.forEach(field => {
                    const input = document.getElementById(field.element);
                    if (input) {
                        if (field.filter) {
                            input.classList.add('filter-active');
                        } else {
                            input.classList.remove('filter-active');
                        }
                    }
                });
                
                // Подсвечиваем email поля
                const emailInputs = document.querySelectorAll('#emailContainer .email-input');
                emailInputs.forEach(input => {
                    if (currentFilters.email) {
                        input.classList.add('filter-active');
                    } else {
                        input.classList.remove('filter-active');
                    }
                });
                
                // Подсвечиваем телефон поля
                const phoneInputs = document.querySelectorAll('#phoneContainer .phone-input');
                phoneInputs.forEach(input => {
                    if (currentFilters.phone) {
                        input.classList.add('filter-active');
                    } else {
                        input.classList.remove('filter-active');
                    }
                });
                
                // Подсвечиваем поля товаров
                const productSelects = document.querySelectorAll('#productContainer .product-select');
                productSelects.forEach(select => {
                    if (currentFilters.product) {
                        select.classList.add('filter-active');
                    } else {
                        select.classList.remove('filter-active');
                    }
                });
            }
    
            // Функция для экранирования HTML
            function escapeHtml(text) {
                if (text === undefined || text === null) return '';
                const div = document.createElement('div');
                div.textContent = text;
                return div.innerHTML;
            }
    
            // Функция для обновления индикаторов фильтрации
            function updateFilterIndicators() {
                const columns = ['id', 'firstName', 'lastName', 'email', 'phone', 'product'];
                columns.forEach(column => {
                    const indicator = document.getElementById(`${column}FilterIndicator`);
                    if (indicator) {
                        if (currentFilters[column]) {
                            indicator.innerHTML = `<span class="filter-badge"><i class="bi bi-funnel-fill"></i> ${currentFilters[column]}</span>`;
                        } else {
                            indicator.innerHTML = '';
                        }
                    }
                });
            }
    
            // Функция для проверки наличия активных фильтров
            function hasActiveFilters() {
                return Object.values(currentFilters).some(value => value !== '');
            }
    
            // Функция для удаления строки
            function deleteRow(id) {
                if (confirm('Вы уверены, что хотите удалить эту запись?')) {
                    if (appState.mode === 'edit' && appState.editingId === id) {
                        setMode('add');
                    }
                    
                    tableData = tableData.filter(item => item.id !== id);
                    appState.expandedRows.delete(id);
                    renderTable(); // Перерисовываем таблицу после удаления
                    showToast('Запись успешно удалена', 'success');
                }
            }
    
            // Показ уведомлений
            function showToast(message, type = 'info') {
                let toastContainer = document.querySelector('.toast-container');
                if (!toastContainer) {
                    toastContainer = document.createElement('div');
                    toastContainer.className = 'toast-container position-fixed bottom-0 end-0 p-3';
                    document.body.appendChild(toastContainer);
                }
                
                const toastId = 'toast-' + Date.now();
                const toastHtml = `
                    <div id="${toastId}" class="toast align-items-center text-white bg-${type} border-0" role="alert">
                        <div class="d-flex">
                            <div class="toast-body">
                                ${message}
                            </div>
                            <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast"></button>
                        </div>
                    </div>
                `;
                
                toastContainer.insertAdjacentHTML('beforeend', toastHtml);
                
                const toastElement = document.getElementById(toastId);
                const toast = new bootstrap.Toast(toastElement, { delay: 3000 });
                toast.show();
                
                toastElement.addEventListener('hidden.bs.toast', function() {
                    this.remove();
                });
            }
    
            // Инициализация
            document.addEventListener('DOMContentLoaded', function() {
                // Добавляем обработчики для полей ввода (фильтрация)
                const fields = [
                    { element: 'editId', column: 'id' },
                    { element: 'editFirstName', column: 'firstName' },
                    { element: 'editLastName', column: 'lastName' }
                ];
                
                fields.forEach(field => {
                    const input = document.getElementById(field.element);
                    if (input) {
                        input.addEventListener('input', function(e) {
                            updateFilter(field.column, e.target.value);
                            
                            if (appState.mode === 'add') {
                                const hasValue = e.target.value.trim() !== '' || 
                                               document.querySelector('#emailContainer .field-input-group') !== null ||
                                               document.querySelector('#phoneContainer .field-input-group') !== null ||
                                               document.querySelector('#productContainer .field-input-group') !== null;
                                document.getElementById('cancelBtn').style.display = hasValue ? 'block' : 'none';
                            }
                        });
                    }
                });
                
                // Добавляем начальные пустые поля
                //addEmailField();
                //addPhoneField();
                addProductField();
                
                // Первоначальное отображение
                renderTable();
            });