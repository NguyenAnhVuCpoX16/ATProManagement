window.cookieHelper = {

    setCookie: function (name, value, days) {

        const expires =
            new Date(
                Date.now() + days * 86400000
            ).toUTCString();

        document.cookie =
            `${encodeURIComponent(name)}=` +
            `${encodeURIComponent(value)}; ` +
            `expires=${expires}; ` +
            `path=/; SameSite=Lax`;
    },

    getCookie: function (name) {

        const cookies =
            document.cookie.split('; ');

        for (const cookie of cookies) {

            const [key, value] =
                cookie.split('=');

            if (
                decodeURIComponent(key) === name
            ) {
                return decodeURIComponent(value);
            }
        }

        return null;
    },

    removeCookie: function (name) {

        document.cookie =
            `${encodeURIComponent(name)}=; ` +
            `expires=Thu, 01 Jan 1970 00:00:00 GMT; ` +
            `path=/`;
    },

    clearCookies: function () {

        document.cookie
            .split(';')
            .forEach(cookie => {

                const eqPos =
                    cookie.indexOf('=');

                const key =
                    eqPos > -1
                        ? cookie.substring(0, eqPos)
                        : cookie;

                document.cookie =
                    `${key}=; ` +
                    `expires=Thu, 01 Jan 1970 00:00:00 GMT; ` +
                    `path=/`;
            });
    }
};