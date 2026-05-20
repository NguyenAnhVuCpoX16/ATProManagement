window.browserSize = {
    registerResizeCallback: function (dotNetHelper) {
        function updateSize() {

            dotNetHelper.invokeMethodAsync(
                'UpdateBrowserWidth',
                window.innerWidth
            );
        }

        window.addEventListener('resize', updateSize);

        updateSize();
    }
};