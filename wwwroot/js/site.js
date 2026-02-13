// Предварительное скрытие футера - выполняется до полной загрузки DOM
    (function() {
        // Создаем стиль для немедленного скрытия футера на определенных страницах
        const currentPath = window.location.pathname.toLowerCase();
        const path = currentPath.replace(/^\//, '');
        
        // Проверяем, нужно ли скрыть футер
        const shouldHideFooter = 
            path === '' || 
            path === 'home' || 
            path === 'home/index' || 
            path.startsWith('home/') || 
            path === 'work/loadingview' || 
            path === 'work/loadingview/';
        
        if (shouldHideFooter) {
            // Добавляем стиль немедленного скрытия
            const style = document.createElement('style');
            style.id = 'immediate-footer-hide';
            style.textContent = '#appFooter { display: none !important; }';
            document.head.appendChild(style);
        }
    })();

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

    // Функция для управления видимостью футера
    function toggleFooterVisibility() {
        const currentPath = window.location.pathname.toLowerCase();
        const footer = document.getElementById('appFooter');
        
        if (!footer) return;
        
        const path = currentPath.replace(/^\//, '');
        
        const shouldHideFooter = 
            path === '' || 
            path === 'home' || 
            path === 'home/index' || 
            path.startsWith('home/') || 
            path === 'work/loadingview' || 
            path === 'work/loadingview/';
        
        // Удаляем ранее добавленный стиль, если он есть
        const existingStyle = document.getElementById('immediate-footer-hide');
        if (existingStyle) {
            existingStyle.remove();
        }
        
        if (shouldHideFooter) {
            footer.classList.add('hidden');
        } else {
            footer.classList.remove('hidden');
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

    // Функция для настройки кнопок футера
    function setupFooterButtons() {
        const createBtn = document.getElementById('createBtn');
        const editBtn = document.getElementById('editBtn');
        const copyBtn = document.getElementById('copyBtn');
        const deleteBtn = document.getElementById('deleteBtn');
        
        if (createBtn) createBtn.disabled = false;
        if (editBtn) editBtn.disabled = false;
        if (copyBtn) copyBtn.disabled = false;
        if (deleteBtn) deleteBtn.disabled = false;
        
        // Удаляем старые обработчики и добавляем новые
        const newCreateBtn = createBtn.cloneNode(true);
        const newEditBtn = editBtn.cloneNode(true);
        const newCopyBtn = copyBtn.cloneNode(true);
        const newDeleteBtn = deleteBtn.cloneNode(true);
        
        if (createBtn && createBtn.parentNode) {
            createBtn.parentNode.replaceChild(newCreateBtn, createBtn);
        }
        if (editBtn && editBtn.parentNode) {
            editBtn.parentNode.replaceChild(newEditBtn, editBtn);
        }
        if (copyBtn && copyBtn.parentNode) {
            copyBtn.parentNode.replaceChild(newCopyBtn, copyBtn);
        }
        if (deleteBtn && deleteBtn.parentNode) {
            deleteBtn.parentNode.replaceChild(newDeleteBtn, deleteBtn);
        }
        
        // Добавляем новые обработчики
        newCreateBtn.addEventListener('click', function() {
            alert('Создание нового элемента');
        });
        
        newEditBtn.addEventListener('click', function() {
            alert('Редактирование элемента');
        });
        
        newCopyBtn.addEventListener('click', function() {
            alert('Копирование элемента');
        });
        
        newDeleteBtn.addEventListener('click', function() {
            if (confirm('Вы уверены, что хотите удалить элемент?')) {
                alert('Удаление элемента');
            }
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
        toggleFooterVisibility();
    }

    // Инициализация после полной загрузки DOM
    document.addEventListener('DOMContentLoaded', function() {
        // Удаляем временный стиль, если он есть
        const tempStyle = document.getElementById('immediate-footer-hide');
        if (tempStyle) {
            tempStyle.remove();
        }
        
        setActiveNavLink();
        toggleFooterVisibility();
        adaptLayout();
        setupNavigationHandlers();
        setupFooterButtons();
        restoreFromSession();
    });

    // Оптимизированная загрузка
    window.addEventListener('load', function() {
        toggleFooterVisibility();
        setActiveNavLink();
        adaptLayout();
        setupFooterButtons();
    });

    window.addEventListener('popstate', function() {
        toggleFooterVisibility();
        setActiveNavLink();
    });