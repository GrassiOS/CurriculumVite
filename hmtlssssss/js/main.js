document.addEventListener('DOMContentLoaded', function() {
    // Sidebar toggle
    const sidebarCollapse = document.getElementById('sidebarCollapse');
    const sidebar = document.getElementById('sidebar');
    const content = document.getElementById('content');

    if (sidebarCollapse) {
        sidebarCollapse.addEventListener('click', function() {
            sidebar.classList.toggle('active');
            content.classList.toggle('active');
        });
    }

    // Responsive sidebar
    function checkWidth() {
        if (window.innerWidth <= 768) {
            sidebar.classList.add('active');
            content.classList.add('active');
        } else {
            sidebar.classList.remove('active');
            content.classList.remove('active');
        }
    }

    // Check width on load and resize
    window.addEventListener('resize', checkWidth);
    checkWidth();

    // Active link handling
    const currentPath = window.location.pathname;
    const navLinks = document.querySelectorAll('#sidebar a');
    navLinks.forEach(link => {
        if (link.getAttribute('href') === currentPath) {
            link.parentElement.classList.add('active');
        }
    });

    // Print CV functionality
    const printCVButton = document.querySelector('.btn-accent');
    if (printCVButton) {
        printCVButton.addEventListener('click', function() {
            // Show loading spinner
            const spinner = document.createElement('div');
            spinner.className = 'spinner-overlay';
            spinner.innerHTML = '<div class="spinner"></div>';
            document.body.appendChild(spinner);

            // Get professor data using standard DOM methods
            const professorName = document.querySelector('.card-body h4').textContent;
            const professorTitle = document.querySelector('.card-body p.text-muted').textContent;
            
            // Get contact information
            const infoParagraphs = document.querySelectorAll('.card-body p');
            let email = '', phone = '', department = '';
            
            infoParagraphs.forEach(p => {
                const text = p.textContent;
                if (text.includes('Email:')) {
                    email = text.split('Email:')[1].trim();
                } else if (text.includes('Teléfono:')) {
                    phone = text.split('Teléfono:')[1].trim();
                } else if (text.includes('Departamento:')) {
                    department = text.split('Departamento:')[1].trim();
                }
            });

            // Create print-specific content
            const printContent = `
                <!DOCTYPE html>
                <html>
                <head>
                    <title>${professorName}</title>
                    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
                    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.0/font/bootstrap-icons.css">
                    <link rel="stylesheet" href="../css/styles.css">
                    <style>
                        @media print {
                            @page {
                                size: A4;
                                margin: 2cm;
                            }
                            body {
                                font-family: Arial, sans-serif;
                                font-size: 11pt;
                                line-height: 1.5;
                                color: #333;
                            }
                            .cv-header {
                                text-align: center;
                                margin-bottom: 2rem;
                                padding-bottom: 1rem;
                                border-bottom: 2px solid var(--primary-color);
                            }
                            .cv-section {
                                margin-bottom: 1.5rem;
                                break-inside: avoid;
                                page-break-inside: avoid;
                            }
                            .cv-section-title {
                                color: var(--primary-color);
                                font-size: 14pt;
                                font-weight: bold;
                                margin-bottom: 1rem;
                                border-bottom: 1px solid #ddd;
                                padding-bottom: 0.5rem;
                            }
                            .cv-item {
                                margin-bottom: 1rem;
                                break-inside: avoid;
                                page-break-inside: avoid;
                            }
                            .cv-item-title {
                                font-weight: bold;
                                color: var(--dark-color);
                            }
                            .cv-item-subtitle {
                                color: #666;
                                font-style: italic;
                            }
                            .cv-item-date {
                                color: #888;
                                font-size: 10pt;
                            }
                            .cv-item-description {
                                margin-top: 0.5rem;
                            }
                            .no-print { display: none !important; }
                            .card { border: none !important; box-shadow: none !important; }
                            .timeline::before { display: none; }
                            .timeline-badge { border: 1px solid var(--primary-color); }
                            .nav-tabs { display: none !important; }
                            .tab-content > .tab-pane { display: block !important; }
                            .tab-content > .tab-pane:not(.active) { display: none !important; }
                            a { color: var(--primary-color); text-decoration: none; }
                            a[href]:after { content: " (" attr(href) ")"; font-size: 9pt; }
                            @page { margin: 0; }
                            body { margin: 2cm; }
                            .page-break { page-break-before: always; }
                            .cv-header h1 { margin-top: 0; }
                            .cv-header h2 { margin-bottom: 0.5rem; }
                            .cv-header p { margin-bottom: 0.25rem; }
                            .cv-section:last-child { margin-bottom: 0; }
                            .cv-item:last-child { margin-bottom: 0; }
                            .cv-item-date { margin-bottom: 0.25rem; }
                            .cv-item-description { margin-bottom: 0.5rem; }
                            .cv-item-link { margin-top: 0.25rem; }
                            .cv-item-link:last-child { margin-bottom: 0; }
                            .cv-section-title { margin-top: 1.5rem; }
                            .cv-section-title:first-child { margin-top: 0; }
                            .cv-section:first-child { margin-top: 0; }
                            .cv-section:last-child { margin-bottom: 0; }
                            .cv-section:last-child .cv-item:last-child { margin-bottom: 0; }
                            .cv-section:last-child .cv-section-title { margin-bottom: 0.5rem; }
                            .cv-section:last-child .cv-item:last-child .cv-item-description { margin-bottom: 0; }
                            .cv-section:last-child .cv-item:last-child .cv-item-link { margin-bottom: 0; }
                            .cv-section:last-child .cv-item:last-child .cv-item-date { margin-bottom: 0; }
                            .cv-section:last-child .cv-item:last-child .cv-item-subtitle { margin-bottom: 0; }
                            .cv-section:last-child .cv-item:last-child .cv-item-title { margin-bottom: 0; }
                            .cv-section:last-child .cv-item:last-child .cv-item-description:last-child { margin-bottom: 0; }
                            .cv-section:last-child .cv-item:last-child .cv-item-link:last-child { margin-bottom: 0; }
                            .cv-section:last-child .cv-item:last-child .cv-item-date:last-child { margin-bottom: 0; }
                            .cv-section:last-child .cv-item:last-child .cv-item-subtitle:last-child { margin-bottom: 0; }
                            .cv-section:last-child .cv-item:last-child .cv-item-title:last-child { margin-bottom: 0; }
                        }
                    </style>
                </head>
                <body>
                    <div class="container-fluid">
                        <!-- Header -->
                        <div class="cv-header">
                            <h1>${professorName}</h1>
                            <h2>${professorTitle}</h2>
                            <div class="mt-2">
                                <p class="mb-1">${email} | ${phone}</p>
                                <p class="mb-0">${department}</p>
                            </div>
                        </div>

                        <!-- Formación Académica -->
                        <div class="cv-section">
                            <h3 class="cv-section-title">Formación Académica</h3>
                            <div class="timeline">
                                ${Array.from(document.querySelectorAll('#formacion .timeline-item')).map(item => `
                                    <div class="cv-item">
                                        <div class="cv-item-title">${item.querySelector('h5').textContent}</div>
                                        <div class="cv-item-subtitle">${item.querySelector('.text-muted').textContent}</div>
                                        <div class="cv-item-date">${item.querySelector('p:last-child').textContent}</div>
                                    </div>
                                `).join('')}
                            </div>
                        </div>

                        <!-- Experiencia Profesional -->
                        <div class="cv-section">
                            <h3 class="cv-section-title">Experiencia Profesional</h3>
                            <div class="timeline">
                                ${Array.from(document.querySelectorAll('#experiencia .timeline-item')).map(item => `
                                    <div class="cv-item">
                                        <div class="cv-item-title">${item.querySelector('h5').textContent}</div>
                                        <div class="cv-item-subtitle">${item.querySelector('.text-muted').textContent}</div>
                                        <div class="cv-item-date">${item.querySelector('p:nth-child(3)').textContent}</div>
                                        <div class="cv-item-description">${item.querySelector('p:last-child').textContent}</div>
                                    </div>
                                `).join('')}
                            </div>
                        </div>

                        <!-- Publicaciones -->
                        <div class="cv-section">
                            <h3 class="cv-section-title">Publicaciones</h3>
                            ${Array.from(document.querySelectorAll('#publicaciones .list-group-item')).map(item => `
                                <div class="cv-item">
                                    <div class="cv-item-title">${item.querySelector('h5').textContent}</div>
                                    <div class="cv-item-subtitle">${item.querySelector('p.mb-1').textContent}</div>
                                    <div class="cv-item-date">${item.querySelector('small.text-muted').textContent}</div>
                                    ${item.querySelector('a') ? `<div class="cv-item-link">${item.querySelector('a').href}</div>` : ''}
                                </div>
                            `).join('')}
                        </div>

                        <!-- Proyectos -->
                        <div class="cv-section">
                            <h3 class="cv-section-title">Proyectos de Investigación</h3>
                            ${Array.from(document.querySelectorAll('#proyectos .list-group-item')).map(item => `
                                <div class="cv-item">
                                    <div class="cv-item-title">${item.querySelector('h5').textContent}</div>
                                    <div class="cv-item-description">${item.querySelector('p.mb-1').textContent}</div>
                                    <div class="cv-item-date">${item.querySelector('small').textContent}</div>
                                </div>
                            `).join('')}
                        </div>

                        <!-- Certificaciones -->
                        <div class="cv-section">
                            <h3 class="cv-section-title">Certificaciones</h3>
                            ${Array.from(document.querySelectorAll('#certificaciones .card')).map(card => `
                                <div class="cv-item">
                                    <div class="cv-item-title">${card.querySelector('.card-title').textContent}</div>
                                    <div class="cv-item-subtitle">${card.querySelector('.card-text').textContent}</div>
                                    <div class="cv-item-date">${card.querySelector('.text-muted').textContent}</div>
                                </div>
                            `).join('')}
                        </div>

                        <!-- Congresos -->
                        <div class="cv-section">
                            <h3 class="cv-section-title">Congresos</h3>
                            ${Array.from(document.querySelectorAll('#congresos .list-group-item')).map(item => `
                                <div class="cv-item">
                                    <div class="cv-item-title">${item.querySelector('h5').textContent}</div>
                                    <div class="cv-item-subtitle">${item.querySelector('p.mb-1').textContent}</div>
                                    <div class="cv-item-date">${item.querySelector('small').textContent}</div>
                                </div>
                            `).join('')}
                        </div>
                    </div>
                </body>
                </html>
            `;

            // Create a new window for printing
            const printWindow = window.open('', '_blank');
            printWindow.document.write(printContent);
            printWindow.document.close();

            // Wait for resources to load
            printWindow.onload = function() {
                // Remove spinner
                document.body.removeChild(spinner);
                
                // Print
                printWindow.print();
                
                // Keep the window open after printing
                // Removed the onafterprint event to keep the window open
            };
        });
    }

    // Form Validation
    const forms = document.querySelectorAll('form');
    forms.forEach(form => {
        form.addEventListener('submit', function(event) {
            if (!form.checkValidity()) {
                event.preventDefault();
                event.stopPropagation();
            }
            form.classList.add('was-validated');
        });
    });

    // Toast Notifications
    function showToast(message, type = 'success') {
        const toast = document.createElement('div');
        toast.className = `toast ${type}`;
        toast.innerHTML = `
            <div class="toast-header">
                <strong class="me-auto">${type.charAt(0).toUpperCase() + type.slice(1)}</strong>
                <button type="button" class="btn-close" data-bs-dismiss="toast"></button>
            </div>
            <div class="toast-body">${message}</div>
        `;
        
        const container = document.querySelector('.toast-container') || document.createElement('div');
        container.className = 'toast-container';
        container.appendChild(toast);
        document.body.appendChild(container);
        
        const bsToast = new bootstrap.Toast(toast);
        bsToast.show();
        
        toast.addEventListener('hidden.bs.toast', function() {
            toast.remove();
        });
    }

    // Loading Spinner
    function showSpinner() {
        const spinner = document.createElement('div');
        spinner.className = 'spinner-overlay';
        spinner.innerHTML = '<div class="spinner"></div>';
        document.body.appendChild(spinner);
    }

    function hideSpinner() {
        const spinner = document.querySelector('.spinner-overlay');
        if (spinner) {
            spinner.remove();
        }
    }

    // Table Actions
    const actionButtons = document.querySelectorAll('.btn-action');
    actionButtons.forEach(button => {
        button.addEventListener('click', function() {
            const action = this.dataset.action;
            const id = this.dataset.id;
            
            if (action === 'delete') {
                if (confirm('¿Está seguro de eliminar este registro?')) {
                    showSpinner();
                    // Simulate API call
                    setTimeout(() => {
                        hideSpinner();
                        showToast('Registro eliminado exitosamente');
                    }, 1000);
                }
            }
        });
    });

    // Search functionality
    const searchInput = document.querySelector('.search-input');
    if (searchInput) {
        searchInput.addEventListener('input', function() {
            const searchTerm = this.value.toLowerCase();
            const tableRows = document.querySelectorAll('tbody tr');
            
            tableRows.forEach(row => {
                const text = row.textContent.toLowerCase();
                row.style.display = text.includes(searchTerm) ? '' : 'none';
            });
        });
    }

    // File upload preview
    const fileInput = document.querySelector('input[type="file"]');
    if (fileInput) {
        fileInput.addEventListener('change', function() {
            const file = this.files[0];
            if (file) {
                if (file.type.startsWith('image/')) {
                    const reader = new FileReader();
                    reader.onload = function(e) {
                        const preview = document.querySelector('.image-preview');
                        if (preview) {
                            preview.src = e.target.result;
                            preview.style.display = 'block';
                        }
                    };
                    reader.readAsDataURL(file);
                } else {
                    showToast('Por favor, seleccione una imagen válida', 'error');
                    this.value = '';
                }
            }
        });
    }

    // Date range picker initialization
    const dateInputs = document.querySelectorAll('input[type="date"]');
    dateInputs.forEach(input => {
        input.addEventListener('change', function() {
            const startDate = document.querySelector('input[data-type="start"]');
            const endDate = document.querySelector('input[data-type="end"]');
            
            if (startDate && endDate) {
                if (new Date(startDate.value) > new Date(endDate.value)) {
                    showToast('La fecha de inicio no puede ser posterior a la fecha final', 'error');
                    this.value = '';
                }
            }
        });
    });

    // Dropdown menu handling
    const dropdownToggle = document.querySelector('.dropdown-toggle');
    if (dropdownToggle) {
        dropdownToggle.addEventListener('click', function(e) {
            e.preventDefault();
            const dropdownMenu = this.nextElementSibling;
            dropdownMenu.classList.toggle('show');
        });
    }

    // Close dropdown when clicking outside
    document.addEventListener('click', function(e) {
        if (!e.target.matches('.dropdown-toggle')) {
            const dropdowns = document.querySelectorAll('.dropdown-menu.show');
            dropdowns.forEach(dropdown => {
                dropdown.classList.remove('show');
            });
        }
    });
}); 