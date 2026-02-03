// Theme Manager for Battle Cabbage Movie Viewer
// Uses cookies for SSR compatibility and #theme-root for Blazor enhanced navigation compatibility

(function() {
    'use strict';

    function getThemeRoot() {
        return document.getElementById('theme-root');
    }

    function getCookie(name) {
        var value = "; " + document.cookie;
        var parts = value.split("; " + name + "=");
        if (parts.length === 2) return parts.pop().split(";").shift();
        return null;
    }

    function setCookie(name, value, days) {
        var expires = "";
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            expires = "; expires=" + date.toUTCString();
        }
        document.cookie = name + "=" + (value || "") + expires + "; path=/; SameSite=Lax";
    }

    function getStoredTheme() {
        var theme = getCookie('theme') || localStorage.getItem('theme');
        if (theme === 'dark') return 'dark';
        if (theme === 'light') return 'light';
        // Default to dark (cinema-first design)
        return 'dark';
    }

    function applyTheme(theme) {
        var root = getThemeRoot();
        if (!root) return;

        if (theme === 'dark') {
            root.classList.add('dark');
        } else {
            root.classList.remove('dark');
        }

        // Update meta theme-color for mobile browsers
        var meta = document.querySelector('meta[name="theme-color"]');
        if (meta) {
            meta.setAttribute('content', theme === 'dark' ? '#0D0D0F' : '#FAFAFA');
        }
    }

    function applyStoredTheme() {
        applyTheme(getStoredTheme());
    }

    // Apply theme immediately on script load
    applyStoredTheme();

    // Theme Manager API for Blazor components
    window.themeManager = {
        getTheme: function() {
            var root = getThemeRoot();
            return root && root.classList.contains('dark') ? 'dark' : 'light';
        },

        setTheme: function(theme) {
            applyTheme(theme);
            setCookie('theme', theme, 365);
            localStorage.setItem('theme', theme);
        },

        toggleTheme: function() {
            var root = getThemeRoot();
            if (!root) return 'dark';

            var isDark = root.classList.toggle('dark');
            var theme = isDark ? 'dark' : 'light';
            setCookie('theme', theme, 365);
            localStorage.setItem('theme', theme);
            return theme;
        },

        initialize: function() {
            applyStoredTheme();
            return getStoredTheme();
        }
    };

    // MutationObserver to preserve theme during Blazor enhanced navigation
    function setupObserver() {
        var root = getThemeRoot();
        if (!root) return;

        var observer = new MutationObserver(function(mutations) {
            mutations.forEach(function(mutation) {
                if (mutation.type === 'attributes' && mutation.attributeName === 'class') {
                    var storedTheme = getStoredTheme();
                    var hasDarkClass = root.classList.contains('dark');

                    if (storedTheme === 'dark' && !hasDarkClass) {
                        root.classList.add('dark');
                    } else if (storedTheme === 'light' && hasDarkClass) {
                        root.classList.remove('dark');
                    }
                }
            });
        });

        observer.observe(root, {
            attributes: true,
            attributeFilter: ['class']
        });
    }

    setupObserver();

    // Re-apply theme after Blazor enhanced navigation
    if (typeof Blazor !== 'undefined') {
        Blazor.addEventListener('enhancedload', function() {
            applyStoredTheme();
            setupObserver();
        });
    }
})();
