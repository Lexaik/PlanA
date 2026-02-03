class BootstrapRouteManager {
            constructor() {
                this.currentRoute = 'Index';
                this.selectedItem = null;
                this.footer = document.querySelector('.footer');
                this.init();
            }

            init() {
                this.bindEvents();
                this.updateActions();
            }

            bindEvents() {
                // Навигация по маршрутам
                document.querySelectorAll('[data-route]').forEach(button => {
                    button.addEventListener('click', (e) => {
                        this.switchRoute(e.target.dataset.route);
                    });
                });

                // Выбор элемента
                document.querySelectorAll('.item-card').forEach(card => {
                    card.addEventListener('click', (e) => {
                        this.selectItem(card);
                    });
                });

                // Действия кнопок
                document.getElementById('createBtn').addEventListener('click', () => this.handleCreate());
                document.getElementById('editBtn').addEventListener('click', () => this.handleEdit());
                document.getElementById('copyBtn').addEventListener('click', () => this.handleCopy());
                document.getElementById('deleteBtn').addEventListener('click', () => this.handleDelete());
            }

            switchRoute(route) {
                this.currentRoute = route;
                
                // Обновляем активные табы
                document.querySelectorAll('[data-route]').forEach(btn => {
                    btn.classList.toggle('active', btn.dataset.route === route);
                });

                // Показываем соответствующий раздел
                document.querySelectorAll('.content-section').forEach(section => {
                    section.classList.toggle('active', section.id === route);
                });

                // Сбрасываем выбранный элемент
                this.selectedItem = null;
                document.querySelectorAll('.item-card').forEach(card => {
                    card.classList.remove('selected');
                });
                
                // Скрываем информацию о выборе
                document.querySelectorAll('.selection-info').forEach(info => {
                    info.classList.remove('show');
                });

                // Управляем видимостью футера
                this.toggleFooterVisibility();

                // Обновляем состояние кнопок
                this.updateActions();
            }

            toggleFooterVisibility() {
                // Скрываем футер только на вкладке "Настройки"
                if (this.currentRoute === 'Index' || this.currentRoute === 'LoadingView' || this.currentRoute === 'ProcessView') {
                    this.footer.classList.add('hidden');
                } else {
                    this.footer.classList.remove('hidden');
                }
            }

            selectItem(card) {
                // На вкладке настроек и отчетов выбор не активен
                if (this.currentRoute === 'settings' || this.currentRoute === 'reports') return;
                
                // Сбрасываем предыдущий выбор
                document.querySelectorAll('.item-card').forEach(c => {
                    c.classList.remove('selected');
                });

                // Устанавливаем новый выбор
                card.classList.add('selected');
                this.selectedItem = {
                    id: card.dataset.id,
                    title: card.querySelector('.card-title').textContent,
                    type: this.currentRoute
                };

                // Показываем информацию о выборе
                const infoElement = document.getElementById(`${this.currentRoute}SelectionInfo`);
                if (infoElement) {
                    const titleElement = infoElement.querySelector('strong');
                    if (titleElement) {
                        titleElement.textContent = this.selectedItem.title;
                    }
                    infoElement.classList.add('show');
                }

                // Обновляем состояние кнопок
                this.updateActions();
            }

            updateActions() {
                const createBtn = document.getElementById('createBtn');
                const editBtn = document.getElementById('editBtn');
                const copyBtn = document.getElementById('copyBtn');
                const deleteBtn = document.getElementById('deleteBtn');

                // Правила доступности кнопок в зависимости от маршрута
                const routeRules = {
                    'documents': {
                        create: true,
                        edit: !!this.selectedItem,
                        copy: !!this.selectedItem,
                        delete: !!this.selectedItem
                    },
                    'users': {
                        create: true,
                        edit: !!this.selectedItem,
                        copy: !!this.selectedItem,
                        delete: !!this.selectedItem
                    },
                    'settings': {
                        create: false,
                        edit: false,
                        copy: false,
                        delete: false
                    },
                    'reports': {
                        create: false,
                        edit: false,
                        copy: false,
                        delete: false
                    }
                };

                const rules = routeRules[this.currentRoute];

                createBtn.disabled = !rules.create;
                editBtn.disabled = !rules.edit;
                copyBtn.disabled = !rules.copy;
                deleteBtn.disabled = !rules.delete;

                // Обновляем Bootstrap классы для disabled кнопок
                [createBtn, editBtn, copyBtn, deleteBtn].forEach(btn => {
                    if (btn.disabled) {
                        btn.classList.add('disabled');
                    } else {
                        btn.classList.remove('disabled');
                    }
                });
            }

            handleCreate() {
                const modal = new bootstrap.Modal(document.getElementById('createModal'));
                modal.show();
            }

            handleEdit() {
                if (this.selectedItem) {
                    alert(`Редактирование "${this.selectedItem.title}" (ID: ${this.selectedItem.id})`);
                    // Здесь будет логика редактирования
                }
            }

            handleCopy() {
                if (this.selectedItem) {
                    alert(`Копирование "${this.selectedItem.title}" (ID: ${this.selectedItem.id})`);
                    // Здесь будет логика копирования
                }
            }

            handleDelete() {
                if (this.selectedItem) {
                    const modal = new bootstrap.Modal(document.getElementById('deleteModal'));
                    modal.show();
                }
            }

            getRouteName(route) {
                const names = {
                    'Index': 'Index',
                    'documents': 'Документы',
                    'users': 'Пользователи',
                    'settings': 'Настройки',
                    'reports': 'Отчеты'
                    'loading': 'Загрузка'
                };
                return names[route] || route;
            }
        }

        // Инициализация при загрузке страницы
        document.addEventListener('DOMContentLoaded', () => {
            new BootstrapRouteManager();
            
            // Пример обработки модальных окон
            const deleteModal = document.getElementById('deleteModal');
            if (deleteModal) {
                deleteModal.addEventListener('show.bs.modal', function () {
                    const manager = new BootstrapRouteManager();
                    if (manager.selectedItem) {
                        const modalBody = this.querySelector('.modal-body');
                        modalBody.innerHTML = `
                            <div class="alert alert-danger">
                                <i class="bi bi-exclamation-triangle-fill"></i>
                                Вы уверены, что хотите удалить "<strong>${manager.selectedItem.title}</strong>"?
                            </div>
                            <p>Это действие нельзя отменить. Все данные будут удалены безвозвратно.</p>
                        `;
                    }
                });
            }
        });