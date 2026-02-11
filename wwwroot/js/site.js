function adaptLayout() {
        const headerNav = document.querySelector('.nav-tabs-custom');
        const footerButtons = document.querySelector('.action-buttons');
        const screenWidth = window.innerWidth;
        
        // Для header
        if (headerNav) {
            const navItems = headerNav.querySelectorAll('.nav-item');
            const containerWidth = headerNav.clientWidth;
            let totalWidth = 0;
            
            navItems.forEach(item => {
                totalWidth += item.offsetWidth;
            });
            
            // Если элементы не помещаются, скрываем текст
            if (totalWidth > containerWidth) {
                navItems.forEach(item => {
                    const navText = item.querySelector('.nav-text');
                    if (navText) {
                        navText.style.display = 'none';
                    }
                });
            } else if (screenWidth >= 577) {
                // Если помещаются и экран не очень маленький, показываем текст
                navItems.forEach(item => {
                    const navText = item.querySelector('.nav-text');
                    if (navText) {
                        navText.style.display = 'inline-block';
                    }
                });
            }
        }
        
        // Для footer
        if (footerButtons) {
            const actionBtns = footerButtons.querySelectorAll('.action-btn');
            const containerWidth = footerButtons.clientWidth;
            let totalWidth = 0;
            
            actionBtns.forEach(btn => {
                totalWidth += btn.offsetWidth;
            });
            
            // Если кнопки не помещаются, скрываем текст
            if (totalWidth > containerWidth) {
                actionBtns.forEach(btn => {
                    const btnText = btn.querySelector('.btn-text');
                    if (btnText) {
                        btnText.style.display = 'none';
                    }
                });
            } else if (screenWidth >= 577) {
                // Если помещаются и экран не очень маленький, показываем текст
                actionBtns.forEach(btn => {
                    const btnText = btn.querySelector('.btn-text');
                    if (btnText) {
                        btnText.style.display = 'inline-block';
                    }
                });
            }
        }
    }
    
    // Запускаем при загрузке и изменении размера окна
    document.addEventListener('DOMContentLoaded', adaptLayout);
    window.addEventListener('resize', adaptLayout);
    window.addEventListener('load', adaptLayout);
    
    // Также запускаем с небольшой задержкой для полной загрузки DOM
    setTimeout(adaptLayout, 100);