document.addEventListener('DOMContentLoaded', function() {
        const navLinks = document.querySelectorAll('.nav-tabs-custom .nav-link[data-route]');
        
        // Функция установки активной ссылки
        function setActiveLink(linkToActivate) {
            // Быстро убираем active со всех, кроме той, которую хотим активировать
            navLinks.forEach(link => {
                if (link !== linkToActivate) {
                    link.classList.remove('active');
                }
            });
            
            // Активируем нужную ссылку
            if (linkToActivate) {
                linkToActivate.classList.add('active');
            }
        }
        
        // Обработчики событий
        navLinks.forEach(link => {
            let timeoutId = null;
            
            link.addEventListener('mousedown', function() {
                // Немедленно активируем нажатую ссылку
                setActiveLink(this);
                
                // Очищаем предыдущий таймаут, если есть
                if (timeoutId) clearTimeout(timeoutId);
            });
            
            link.addEventListener('click', function() {
                // При клике ничего не делаем - пусть страница переходит
                // Активное состояние установится после загрузки новой страницы
            });
        });
        
        // Функция установки активной ссылки из URL
        function setActiveFromURL() {
            const currentPath = window.location.pathname.toLowerCase();
            const pathSegments = currentPath.split('/').filter(s => s);
            const currentRoute = pathSegments.length > 0 ? pathSegments[pathSegments.length - 1] : 'index';
            
            // Находим и активируем соответствующую ссылку
            navLinks.forEach(link => {
                link.classList.remove('active');
                
                const route = link.getAttribute('data-route');
                if (route === currentRoute) {
                    // Небольшая задержка для плавности
                    setTimeout(() => {
                        link.classList.add('active');
                    }, 10);
                }
            });
        }
        
        // Инициализация
        setTimeout(setActiveFromURL, 100);
        window.addEventListener('popstate', setActiveFromURL);
    });