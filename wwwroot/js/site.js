// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Скрипт для управления состоянием футера и кнопок
    document.addEventListener('DOMContentLoaded', function() {
        const footer = document.querySelector('.footer-fixed');
        const createBtn = document.getElementById('createBtn');
        const editBtn = document.getElementById('editBtn');
        const copyBtn = document.getElementById('copyBtn');
        const deleteBtn = document.getElementById('deleteBtn');
        
        // Функция для скрытия футера на вкладке "Операции"
        function checkCurrentRoute() {
            const currentPath = window.location.pathname;
            
            // Скрываем футер на странице "Операции"
            if (currentPath.includes('OperationsView') || 
                currentPath.includes('Operations') ||
                currentPath.includes('operations')) {
                footer.classList.add('hidden');
                
                // Отключаем все кнопки на странице операций
                createBtn.disabled = true;
                editBtn.disabled = true;
                copyBtn.disabled = true;
                deleteBtn.disabled = true;
            } else {
                footer.classList.remove('hidden');
                
                // Включаем кнопки на других страницах
                createBtn.disabled = false;
                
                // На остальных страницах включаем только кнопки создания
                // Кнопки редактирования, копирования и удаления будут включаться при выборе элемента
                editBtn.disabled = true;
                copyBtn.disabled = true;
                deleteBtn.disabled = true;
            }
        }
        
        // Проверяем текущий маршрут при загрузке
        checkCurrentRoute();
        
        // Пример: обработчики для кнопок
        createBtn.addEventListener('click', function() {
            alert('Создание нового элемента');
            // Здесь будет ваша логика создания
        });
        
        editBtn.addEventListener('click', function() {
            alert('Редактирование элемента');
            // Здесь будет ваша логика редактирования
        });
        
        copyBtn.addEventListener('click', function() {
            alert('Копирование элемента');
            // Здесь будет ваша логика копирования
        });
        
        deleteBtn.addEventListener('click', function() {
            if (confirm('Вы уверены, что хотите удалить элемент?')) {
                alert('Удаление элемента');
                // Здесь будет ваша логика удаления
            }
        });
        
        // Пример: функция для активации кнопок при выборе элемента
        window.selectItem = function(itemId, itemName) {
            // Включаем кнопки действий
            editBtn.disabled = false;
            copyBtn.disabled = false;
            deleteBtn.disabled = false;
            
            // Здесь можно добавить логику для работы с выбранным элементом
            console.log('Выбран элемент:', itemId, itemName);
        };
    });