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


window.downloadFile = (fileName, contentType, content) => {
    const file = new Blob(
        [content],
        { type: contentType });
    const url = URL.createObjectURL(file);
    const a = document.createElement('a');
    a.href = url;
    a.download = fileName;
    a.click();
    URL.revokeObjectURL(url);
};